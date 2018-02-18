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
using Microsoft.Extensions.Logging;

namespace LedgerLocal.FrontServer.Service
{
    public class PolicyService : IPolicyService
    {
        private readonly ILedgerLocalDbFullDomainRepository<LedgerLocalPolicyGenericAttributeMap> _LedgerLocalPolicyGenericAttributeMapRepository;
        private readonly ILedgerLocalDbFullDomainRepository<User> _userRepository;
        private readonly ILedgerLocalDbFullDomainUnitOfWork _unitOfWork;

        private readonly IAttributeService _attributeService;

        private readonly ILogger<PolicyService> _logger;

        private IMapper _mapper;

        public PolicyService(ILogger<PolicyService> logger,
            ILedgerLocalDbFullDomainRepository<LedgerLocalPolicyGenericAttributeMap> LedgerLocalPolicyGenericAttributeMapRepository,
            ILedgerLocalDbFullDomainRepository<User> userRepository,
            ILedgerLocalDbFullDomainUnitOfWork unitOfWork,
            IAttributeService attributeService,
            MapperConfiguration mapperConfiguration)
        {
            _logger = logger;
            
            _LedgerLocalPolicyGenericAttributeMapRepository = LedgerLocalPolicyGenericAttributeMapRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;

            _attributeService = attributeService;

            _mapper = mapperConfiguration.CreateMapper();
        }

        public async Task<LedgerLocalPolicyGenericAttributeMap> CreatePolicy(PolicyCreateOrUpdate info)
        {
            Check.Require(info != null, "PolicyCreateOrUpdate must be valid.");

            var now = DateTime.UtcNow;

            var pam = new LedgerLocalPolicyGenericAttributeMap();

            pam.Name = info.Name;
            pam.CreatedOn = now;
            pam.ModifiedOn = now;
            pam.CreatedBy = "System";
            pam.ModifiedBy = "System";

            var ga = await _attributeService.CreateOrGetAttribute(info.KeyValue, info.ItemValue.ToString(), null, info.ItemValue);

            pam.GenericAttributeId = ga.GenericAttributeId;

            await _LedgerLocalPolicyGenericAttributeMapRepository.AddAsync(pam);

            var errors = await _unitOfWork.CommitHandledAsync();

            if (!errors)
            {
                _logger.LogError($"Can't create policy ! {JsonConvert.SerializeObject(pam, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
            }

            var p1 = _LedgerLocalPolicyGenericAttributeMapRepository.DbSet
                    .Include("Program")
                    .Include("GenericAttribute")
                    .Include("GenericAttribute.GenericAttributeType")
                    .Include("GenericAttribute.GenericAttributeValue")
                    .Where(x => x.LedgerLocalPolicyGenericAttributeId == pam.LedgerLocalPolicyGenericAttributeId).First();
            return p1;
        }

        public async Task<PolicyDescription> CreatePolicyAsync(PolicyCreateOrUpdate policy)
        {
            var p = await CreatePolicy(policy);
            return _mapper.Map<LedgerLocalPolicyGenericAttributeMap, PolicyDescription>(p);
        }

        public async Task<PolicyDescription> UpdatePolicyAsync(PolicyCreateOrUpdate policy)
        {
            var p1 = _LedgerLocalPolicyGenericAttributeMapRepository.DbSet
                        .Include("Program")
                        .Include("GenericAttribute")
                        .Include("GenericAttribute.GenericAttributeType")
                        .Include("GenericAttribute.GenericAttributeValue")
                        .Where(x => x.LedgerLocalPolicyGenericAttributeId.ToString() == policy.PolicyGenericAttributeId).First();

            var dateNow = DateTime.UtcNow;


            p1.Name = policy.Name;

            var ga = await _attributeService.CreateOrGetAttribute(policy.KeyValue, policy.ItemValue.ToString(), null, policy.ItemValue);

            p1.GenericAttributeId = ga.GenericAttributeId;
            p1.ModifiedOn = dateNow;

            await _LedgerLocalPolicyGenericAttributeMapRepository.UpdateAsync(p1);

            var errors2 = await _unitOfWork.CommitHandledAsync();

            if (!errors2)
            {
                _logger.LogError($"Can't update policy !");
            }

            var pFinal = _LedgerLocalPolicyGenericAttributeMapRepository.DbSet
                .Include("Program")
                .Include("GenericAttribute")
                .Include("GenericAttribute.GenericAttributeType")
                .Include("GenericAttribute.GenericAttributeValue")
                .Where(x => x.LedgerLocalPolicyGenericAttributeId == p1.LedgerLocalPolicyGenericAttributeId).First();

            return _mapper.Map<LedgerLocalPolicyGenericAttributeMap, PolicyDescription>(pFinal);
        }
        
        public async Task<List<PolicyDescription>> GetPolicyByNameAsync(string name)
        {
            IList<LedgerLocalPolicyGenericAttributeMap> ps = null;

            await Task.Factory.StartNew(() =>
            {
                ps = _LedgerLocalPolicyGenericAttributeMapRepository.DbSet
                    .Include("Program")
                    .Include("GenericAttribute")
                    .Include("GenericAttribute.GenericAttributeType")
                    .Include("GenericAttribute.GenericAttributeValue")
                    .Where(x => string.Compare(x.Name, name, true) == 0)
                .ToList();
            });

            return _mapper.Map<IEnumerable<LedgerLocalPolicyGenericAttributeMap>, IEnumerable<PolicyDescription>>(ps).ToList();
        }
    }
}
