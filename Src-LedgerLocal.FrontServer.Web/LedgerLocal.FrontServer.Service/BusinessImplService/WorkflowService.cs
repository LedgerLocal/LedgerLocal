using LedgerLocal.FrontServer.Data.FullDomain.Infrastructure;
using LedgerLocal.FrontServer.Model.FullDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LedgerLocal.FrontServer.Api.Web.Models;
using System.Threading.Tasks;
using LedgerLocal.FrontServer.Service.LedgerLocalServiceContract;
using LedgerLocal.FrontServer.Model.FullDomain;
using LedgerLocal.Common.Core;
using Newtonsoft.Json;
using AutoMapper;
using LedgerLocal.FrontServer.Service.Contract;
using Microsoft.Extensions.Logging;

namespace LedgerLocal.FrontServer.Service
{
    public class WorkflowService : IWorkflowService
    {
        private readonly ILedgerLocalDbFullDomainRepository<WorkflowContainer> _workflowRepository;
        private readonly ILedgerLocalDbFullDomainRepository<WorkflowGenericAttributeMap> _workflowGenericAttributeMapRepository;
        private readonly ILedgerLocalDbFullDomainRepository<User> _userRepository;
        private readonly ILedgerLocalDbFullDomainUnitOfWork _unitOfWork;
        
        private readonly IAttributeService _attributeService;

        private readonly ILogger<WorkflowService> _logger;

        private IMapper _mapper;

        public WorkflowService(ILogger<WorkflowService> logger,
            ILedgerLocalDbFullDomainRepository<WorkflowContainer> workflowRepository,
            ILedgerLocalDbFullDomainRepository<WorkflowGenericAttributeMap> workflowGenericAttributeMapRepository,
            ILedgerLocalDbFullDomainRepository<User> userRepository,
            ILedgerLocalDbFullDomainUnitOfWork unitOfWork,
            IAttributeService attributeService,
            MapperConfiguration mapperConfiguration)
        {
            _logger = logger;

            _workflowRepository = workflowRepository;
            _workflowGenericAttributeMapRepository = workflowGenericAttributeMapRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;

            _attributeService = attributeService;

            _mapper = mapperConfiguration.CreateMapper();
        }

        public async Task<WorkflowContainer> CreateWorkflow(WorkflowCreateOrUpdate info)
        {
            Check.Require(info != null, "WorkflowCreateOrUpdate must be valid.");

            var now = DateTime.UtcNow;

            var p = _mapper.Map<WorkflowCreateOrUpdate, WorkflowContainer>(info);
            p.CreatedOn = now;
            p.ModifiedOn = now;
            p.CreatedBy = "System";
            p.ModifiedBy = "System";

            var lstAttr = new List<GenericAttribute>();

            if (info.Arguments != null && info.Arguments.Count > 0)
            {
                foreach (var kv in info.Arguments)
                {
                    var ga = await _attributeService.CreateOrGetAttribute(kv.Key, kv.Value.ToString(), null, kv.Value);
                    lstAttr.Add(ga);
                }
            }

            await _workflowRepository.AddAsync(p);

            var errors = await _unitOfWork.CommitHandledAsync();

            if (!errors)
            {
                _logger.LogError($"Can't create workflow ! {JsonConvert.SerializeObject(p, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
            }

            foreach(var la1 in lstAttr)
            {
                var vlam = new WorkflowGenericAttributeMap();
                vlam.GenericAttributeId = la1.GenericAttributeId;
                vlam.WorkflowContainerId = p.WorkflowContainerId;
                vlam.Active = true;

                vlam.CreatedOn = now;
                vlam.ModifiedOn = now;
                vlam.CreatedBy = "System";
                vlam.ModifiedBy = "System";

                await _workflowGenericAttributeMapRepository.AddAsync(vlam);
            }

            var errors2 = await _unitOfWork.CommitHandledAsync();

            if (!errors2)
            {
                _logger.LogError($"Can't create arguments !");
            }

            var p1 = _workflowRepository.DbSet
                    .Include("Category")
                    .Include("WorkflowGenericAttributeMap")
                    .Include("WorkflowGenericAttributeMap.GenericAttribute")
                    .Include("WorkflowGenericAttributeMap.GenericAttribute.GenericAttributeType")
                    .Include("WorkflowGenericAttributeMap.GenericAttribute.GenericAttributeValue")
                    .Where(x => x.WorkflowContainerId == p.WorkflowContainerId).First();
            return p1;
        }

        public async Task<WorkflowDescription> CreateWorkflowAsync(WorkflowCreateOrUpdate workflow)
        {
            var p = await CreateWorkflow(workflow);
            return _mapper.Map<WorkflowContainer, WorkflowDescription>(p);
        }

        public async Task<WorkflowDescription> UpdateWorkflowAsync(WorkflowCreateOrUpdate workflow)
        {
            var p1 = _workflowRepository.DbSet
                                .Include("Category")
                                .Include("WorkflowGenericAttributeMap")
                                .Where(x => x.WorkflowContainerId.ToString() == workflow.WorkflowId).First();

            var dateNow = DateTime.UtcNow;

            var voucherUpdated = _mapper.Map<WorkflowCreateOrUpdate, WorkflowContainer>(workflow, p1);
            voucherUpdated.ModifiedOn = dateNow;

            await _workflowRepository.UpdateAsync(voucherUpdated);

            var errors2 = await _unitOfWork.CommitHandledAsync();

            if (!errors2)
            {
                _logger.LogError($"Can't update workflow !");
            }

            if (workflow.Arguments != null && workflow.Arguments.Count > 0)
            {
                var lstAttributes = await _workflowGenericAttributeMapRepository
                        .DbSet
                                .Include("GenericAttribute")
                                .Include("WorkflowContainer")
                        .Where(x => x.WorkflowContainerId.ToString() == workflow.WorkflowId).ToListAsync();

                foreach (var kv in workflow.Arguments)
                {
                    var fdAttr = lstAttributes
                                    .Where(x => x.GenericAttribute.TypeString == kv.Key && x.GenericAttribute.ValueString == kv.Value.ToString())
                                    .FirstOrDefault();

                    if (fdAttr == null)
                    {
                        var ga = await _attributeService.CreateOrGetAttribute(kv.Key, kv.Value.ToString(), null, kv.Value);

                        var vlam = new WorkflowGenericAttributeMap();
                        vlam.GenericAttributeId = ga.GenericAttributeId;
                        vlam.WorkflowContainerId = p1.WorkflowContainerId;
                        vlam.Active = true;

                        vlam.CreatedOn = dateNow;
                        vlam.ModifiedOn = dateNow;
                        vlam.CreatedBy = "System";
                        vlam.ModifiedBy = "System";

                        await _workflowGenericAttributeMapRepository.AddAsync(vlam);
                    }
                    else
                    {
                        fdAttr.ModifiedOn = dateNow;
                        await _workflowGenericAttributeMapRepository.UpdateAsync(fdAttr);
                    }
                }
                
                var errors3 = await _unitOfWork.CommitHandledAsync();

                if (!errors3)
                {
                    _logger.LogError($"Can't create arguments !");
                }

                var lstAttributesToDelete = await _workflowGenericAttributeMapRepository
                    .DbSet
                    .Include("GenericAttribute")
                    .Where(x => x.WorkflowContainerId.ToString() == workflow.WorkflowId
                        && x.ModifiedOn != dateNow).ToListAsync();

                foreach(var deleteAttr in lstAttributesToDelete)
                {
                    await _workflowGenericAttributeMapRepository.DeleteAsync(deleteAttr);
                }

                var errors4 = await _unitOfWork.CommitHandledAsync();

                if (!errors4)
                {
                    _logger.LogError($"Can't delete arguments !");
                }
            }

            var pFinal = _workflowRepository.DbSet
                    .Include("Category")
                    .Include("WorkflowGenericAttributeMap")
                    .Include("WorkflowGenericAttributeMap.GenericAttribute")
                    .Include("WorkflowGenericAttributeMap.GenericAttribute.GenericAttributeType")
                    .Include("WorkflowGenericAttributeMap.GenericAttribute.GenericAttributeValue")
                    .Where(x => x.WorkflowContainerId.ToString() == workflow.WorkflowId).First();

            return _mapper.Map<WorkflowContainer, WorkflowDescription>(pFinal);
        }

        public async Task<IList<WorkflowDescription>> GetAllWorkflowAsync()
        {
            IList<WorkflowContainer> vl = null;

            await Task.Factory.StartNew(() =>
            {
                var dbContext = (IDbContextService)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(IDbContextService));
                dbContext.RefreshFullDomain();
                var wr1 = (ILedgerLocalDbFullDomainRepository<WorkflowContainer>)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(ILedgerLocalDbFullDomainRepository<WorkflowContainer>));


                vl = wr1.DbSet
                    .Include("WorkflowGenericAttributeMap")
                    .Include("WorkflowGenericAttributeMap.GenericAttribute")
                    .Include("WorkflowGenericAttributeMap.GenericAttribute.GenericAttributeType")
                    .Include("WorkflowGenericAttributeMap.GenericAttribute.GenericAttributeValue")
                    .ToList();
            });

            return _mapper.Map<IEnumerable<WorkflowContainer>, IEnumerable<WorkflowDescription>>(vl).ToList();
        }

        public async Task<WorkflowDescription> GetWorkflowByIdAsync(string workflowId)
        {
            IList<WorkflowContainer> vl = null;

            await Task.Factory.StartNew(() =>
            {
                var dbContext = (IDbContextService)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(IDbContextService));
                dbContext.RefreshFullDomain();
                var wr1 = (ILedgerLocalDbFullDomainRepository<WorkflowContainer>)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(ILedgerLocalDbFullDomainRepository<WorkflowContainer>));

                vl = wr1.DbSet
                    .Include("WorkflowGenericAttributeMap")
                    .Include("WorkflowGenericAttributeMap.GenericAttribute")
                    .Include("WorkflowGenericAttributeMap.GenericAttribute.GenericAttributeType")
                    .Include("WorkflowGenericAttributeMap.GenericAttribute.GenericAttributeValue")
                    .Where(x => x.WorkflowContainerId.ToString() == workflowId)
                    .ToList();
            });

            return _mapper.Map<WorkflowContainer, WorkflowDescription>(vl.First());
        }

    }
}
