//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EasyNetQ;
//using LedgerLocal.Common.Core;
//using LedgerLocal.FrontServer.Data.FullDomain.Infrastructure;
//using LedgerLocal.FrontServer.Dto;
//using LedgerLocal.FrontServer.Enum;
//using LedgerLocal.FrontServer.Model.FullDomain;
//using LedgerLocal.FrontServer.Service.Contract;
//using Microsoft.Practices.ServiceLocation;
//using Newtonsoft.Json;

//namespace LedgerLocal.FrontServer.Service
//{
//    public class PeopleOnlineService : IPeopleOnlineService
//    {
//        private readonly IMercuritusFullDomainRepository<PeopleOnline> _peopleOnlineRepository;
//        private readonly IMercuritusFullDomainUnitOfWork _unitOfWork;
//        private readonly IBus _bus;
//        private ISubscriptionResult _currentSubscription;

//        public PeopleOnlineService(IMercuritusFullDomainRepository<PeopleOnline> peopleOnlineRepository,
//            IMercuritusFullDomainUnitOfWork unitOfWork,
//            IBus bus)
//        {
//            _peopleOnlineRepository = peopleOnlineRepository;
//            _unitOfWork = unitOfWork;
//            _bus = bus;
//        }

//        public void SaveOrUpdatePeopleOnline(string ip, string userAgent)
//        {
//            var user =
//                _peopleOnlineRepository.DbSet.FirstOrDefault(x => string.Compare(x.Ip, ip, true, CultureInfo.InvariantCulture) == 0
//                                                                  && string.Compare(x.Browser, userAgent, true, CultureInfo.InvariantCulture) == 0);

//            var now = DateTime.UtcNow;

//            if (user == null)
//            {
//                user = new PeopleOnline()
//                {
//                    Ip = ip,
//                    Browser = userAgent,
//                    CreatedOn = now,
//                };
//            }

//            user.LastActivity = now;

//            if (user.PeopleOnlineID <= 0)
//            {
//                _peopleOnlineRepository.Add(user);
//            }
//            else
//            {
//                _peopleOnlineRepository.Update(user);
//            }

//            _unitOfWork.Commit();
//        }

//        public void EnqueuePeopleOnline(string ip, string userAgent)
//        {
//            var poDto = new PeopleOnlineDto()
//            {
//                Browser = userAgent.Length > 200 ? userAgent.Substring(0, 200) : userAgent,
//                Ip = ip
//            };

//            _bus.Publish(poDto);
//        }

//        public void ProcessQueuePeopleOnline(string subscriberId)
//        {
//            _currentSubscription = _bus.Subscribe<PeopleOnlineDto>(subscriberId, po =>
//            {
//                var _peopleOnlineRepositoryLocal =
//                    ServiceLocator.Current.GetInstance<IMercuritusFullDomainRepository<PeopleOnline>>();

//                var _unitWorkLocal =
//                    ServiceLocator.Current.GetInstance<IMercuritusFullDomainUnitOfWork>();

//                var user =
//                _peopleOnlineRepositoryLocal.DbSet.FirstOrDefault(x => string.Compare(x.Ip, po.Ip, true, CultureInfo.InvariantCulture) == 0
//                                                                  && string.Compare(x.Browser, po.Browser, true, CultureInfo.InvariantCulture) == 0);

//                var now = DateTime.UtcNow;

//                if (user == null)
//                {
//                    user = new PeopleOnline
//                    {
//                        Ip = po.Ip,
//                        Browser = po.Browser,
//                        CreatedOn = now,
//                    };
//                }

//                user.LastActivity = now;

//                if (user.PeopleOnlineID <= 0)
//                {
//                    _peopleOnlineRepositoryLocal.Add(user);
//                }
//                else
//                {
//                    _peopleOnlineRepositoryLocal.Update(user);
//                }

//                var tupleError = _unitWorkLocal.CommitHandled();

//                if (tupleError.Count > 0)
//                {
//                    string json = JsonConvert.SerializeObject(tupleError);
//                    throw new PostconditionException(string.Format("Error post commit: {0}", json));
//                }
//            });
//        }

//        public void DisposeQueuePeopleOnline()
//        {
//            _currentSubscription.Dispose();
//        }
//    }
//}
