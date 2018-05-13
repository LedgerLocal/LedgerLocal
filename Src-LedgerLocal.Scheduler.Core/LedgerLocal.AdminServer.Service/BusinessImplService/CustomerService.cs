using LedgerLocal.AdminServer.Data.FullDomain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LedgerLocal.AdminServer.Api.Web.Models;
using System.Threading.Tasks;
using LedgerLocal.AdminServer.Service.LedgerLocalServiceContract;
using LedgerLocal.AdminServer.Model.FullDomain;
using LedgerLocal.Common.Core;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.Extensions.Logging;
using LedgerLocal.AdminServer.Data.FullDomain;

namespace LedgerLocal.AdminServer.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ILedgerLocalDbFullDomainRepository<User> _userRepository;
        private readonly ILedgerLocalDbFullDomainRepository<People> _peopleRepository;
        private readonly ILedgerLocalDbFullDomainRepository<Address> _addressRepository;
        private readonly ILedgerLocalDbFullDomainUnitOfWork _unitOfWork;

        private readonly ILogger<CustomerService> _logger;

        private IMapper _mapper;

        public CustomerService(ILogger<CustomerService> logger,
                ILedgerLocalDbFullDomainRepository<User> userRepository,
                ILedgerLocalDbFullDomainRepository<People> peopleRepository,
                ILedgerLocalDbFullDomainRepository<Address> addressRepository,
                ILedgerLocalDbFullDomainUnitOfWork unitOfWork,
                MapperConfiguration mapperConfiguration)
        {
            _logger = logger;

            _addressRepository = addressRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _peopleRepository = peopleRepository;

            _mapper = mapperConfiguration.CreateMapper();
        }

        public async Task<People> CreatePeople(CustomerCreateOrUpdate info)
        {
            Check.Require(info != null, "CustomerCreateOrUpdate must be valid.");

            var now = DateTime.UtcNow;

            var p = new People();
            p.Firstname = info.FirstName;
            p.Lastname = info.LastName;
            p.Email = info.Email;
            p.Createdon = now;
            p.Modifiedon = now;
            p.Createdby = "System";
            p.Modifiedby = "System";

            await _peopleRepository.AddAsync(p);

            var errors = await _unitOfWork.CommitHandledAsync();

            if (!errors)
            {
                _logger.LogError($"Can't create people ! {JsonConvert.SerializeObject(p, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
            }

            return p;
        }

        public async Task<Address> CreateAddress(People p, CustomerCreateOrUpdate info)
        {
            Check.Require(info != null, "CustomerCreateOrUpdate must be valid.");

            var now = DateTime.UtcNow;

            var add1 = new Address()
            {
                People = p,
                Street1 = info.Address1,
                Street2 = info.Address2,
                Country = info.Country,
                Modifiedon = now,
                Createdby = "System",
                Modifiedby = "System",
                Createdon = now
            };

            await _addressRepository.AddAsync(add1);

            var errors = await _unitOfWork.CommitHandledAsync();

            if (!errors)
            {
                _logger.LogError($"Can't create address ! {JsonConvert.SerializeObject(add1, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
            }

            return add1;
        }

        public async Task<User> CreateUser(CustomerCreateOrUpdate info)
        {
            Check.Require(info != null, "CustomerCreateOrUpdate must be valid.");

            var now = DateTime.UtcNow;

            var user = new User();
            user.Createdon = now;
            user.Modifiedon = now;
            user.Createdby = "System";
            user.Modifiedby = "System";

            var peEntity = await CreatePeople(info);
            user.People = peEntity;

            await CreateAddress(peEntity, info);

            user.Activate = true;

            await _userRepository.AddAsync(user);

            var errors = await _unitOfWork.CommitHandledAsync();

            if (!errors)
            {
                _logger.LogError($"Can't create user ! { JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
            }

            return user;
        }

        public async Task<CustomerProfile> CreateCustomerAsync(CustomerCreateOrUpdate customer)
        {
            var u = await CreateUser(customer);
            return _mapper.Map<User, CustomerProfile>(u);
        }

        public async Task<IList<CustomerProfile>> GetAllCustomersAsync()
        {
            IList<User> us = null;

            await Task.Factory.StartNew(() =>
            {
                us = _userRepository.DbSet
                    .Include("People")
                    .Include("People.Address")
                .ToList();
            });

            return _mapper.Map<IEnumerable<User>, IEnumerable<CustomerProfile>>(us).ToList();
        }

        public async Task<CustomerProfile> GetCustomerByIdAsync(string customerId)
        {
            IList<User> us = null;

            await Task.Factory.StartNew(() =>
            {
                us = _userRepository.DbSet
                    .Include("People")
                    .Include("People.Address")
                    .Where(x => x.Userid.ToString() == customerId)
                .ToList();
            });

            return _mapper.Map<User, CustomerProfile>(us.First());
        }

        public async Task<CustomerProfile> UpdateCustomerAsync(CustomerCreateOrUpdate customer)
        {
            var u1 = _userRepository.DbSet
                    .Include("People")
                    .Include("People.Address")
                    .Where(x => x.Userid.ToString() == customer.CustomerId).First();

            var dateNow = DateTime.UtcNow;

            var people = _mapper.Map<CustomerCreateOrUpdate, People>(customer, u1.People);
            people.Modifiedon = dateNow;

            var user = _mapper.Map<CustomerCreateOrUpdate, User>(customer, u1);
            user.Modifiedon = dateNow;

            CustomerProfile cp = null;

            await Task.Factory.StartNew(() =>
            {
                cp = _mapper.Map<User, CustomerProfile>(user);
            });

            return cp;
        }
    }
}
