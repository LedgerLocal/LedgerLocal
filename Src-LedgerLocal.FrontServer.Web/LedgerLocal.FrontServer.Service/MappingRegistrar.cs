using AutoMapper;
using LedgerLocal.FrontServer.Api.Web.Models;
using LedgerLocal.FrontServer.Model.FullDomain.Model;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using LedgerLocal.FrontServer.Service.Json;

namespace LedgerLocal.FrontServer.Service
{
    public class MappingRegistrar
    {
        public static MapperConfiguration CreateMapperConfig()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            settings.Converters.Insert(0, new PrimitiveJsonConverter());

            var config = new MapperConfiguration(
                cfg => {

                    //!!!!!! People

                    cfg.CreateMap<People, CustomerCreateOrUpdate>()
                        .ForMember(d => d.FirstName, opt => opt.MapFrom(f => f.FirstName))
                        .ForMember(d => d.LastName, opt => opt.MapFrom(f => f.LastName))
                        .ForMember(d => d.Email, opt => opt.MapFrom(f => f.Email));

                    cfg.CreateMap<CustomerCreateOrUpdate, People>()
                        .ForMember(d => d.FirstName, opt => opt.MapFrom(f => f.FirstName))
                        .ForMember(d => d.LastName, opt => opt.MapFrom(f => f.LastName))
                        .ForMember(d => d.Email, opt => opt.MapFrom(f => f.Email));

                    //!!!!!! User
                    cfg.CreateMap<User, CustomerCreateOrUpdate>()
                        .ForMember(d => d.CustomerId, opt => opt.MapFrom(f => f.UserId))
                        .ForMember(d => d.Email, opt => opt.MapFrom(f => f.Email));

                    cfg.CreateMap<CustomerCreateOrUpdate, User>()
                        .ForMember(d => d.UserId, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.CustomerId) ? 0 : Convert.ToInt32(f.CustomerId)))
                        .ForMember(d => d.UserName, opt => opt.MapFrom(f => f.Email))
                        .ForMember(d => d.Email, opt => opt.MapFrom(f => f.Email))
                        .ForMember(d => d.Password, opt => opt.MapFrom(f => string.Empty));

                    //!!!!! CustomerProfile

                    cfg.CreateMap<User, CustomerProfile>()
                        .ForMember(d => d.CustomerId, opt => opt.MapFrom(f => f.UserId))
                        .ForMember(d => d.FirstName, opt => opt.MapFrom(f => f.People.FirstName))
                        .ForMember(d => d.LastName, opt => opt.MapFrom(f => f.People.LastName))
                        .ForMember(d => d.Email, opt => opt.MapFrom(f => f.Email));

                    //!!!!! Voucher
                    cfg.CreateMap<VoucherLedger, VoucherCreateOrUpdate>()
                        .ForMember(d => d.VoucherId, opt => opt.MapFrom(f => f.VoucherLedgerId.ToString()))
                        .ForMember(d => d.VoucherTypeId, opt => opt.MapFrom(f => f.VoucherTypeId.HasValue ? f.VoucherTypeId.ToString() : null))
                        .ForMember(d => d.CoinId, opt => opt.MapFrom(f => f.CoinId.ToString()))
                        .ForMember(d => d.CustomerId, opt => opt.MapFrom(f => f.UserId.ToString()))
                        .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                        .ForMember(d => d.Label, opt => opt.MapFrom(f => f.Label))
                        .ForMember(d => d.StringValue, opt => opt.MapFrom(f => f.StringValue))
                        .ForMember(d => d.Activate, opt => opt.MapFrom(f => f.Activate))
                        .ForMember(d => d.ValidFrom, opt => opt.MapFrom(f => f.ValidFrom))
                        .ForMember(d => d.ValidTo, opt => opt.MapFrom(f => f.ValidTo))
                        .ForMember(d => d.Timestamp, opt => opt.MapFrom(f => f.ModifiedOn));

                    cfg.CreateMap<VoucherCreateOrUpdate, VoucherLedger>()
                        .ForMember(d => d.VoucherLedgerId, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.VoucherId) ? 0 : Convert.ToInt64(f.VoucherId)))
                        .ForMember(d => d.VoucherTypeId, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.VoucherTypeId) ? null : (long?)Convert.ToInt64(f.VoucherTypeId)))
                        .ForMember(d => d.CoinId, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.CoinId) ? 0 : Convert.ToInt32(f.CoinId)))
                        .ForMember(d => d.UserId, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.CustomerId) ? 0 : Convert.ToInt32(f.CustomerId)))
                        .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                        .ForMember(d => d.Label, opt => opt.MapFrom(f => f.Label))
                        .ForMember(d => d.StringValue, opt => opt.MapFrom(f => f.StringValue))
                        .ForMember(d => d.Activate, opt => opt.MapFrom(f => f.Activate))
                        .ForMember(d => d.ValidFrom, opt => opt.MapFrom(f => f.ValidFrom))
                        .ForMember(d => d.ValidTo, opt => opt.MapFrom(f => f.ValidTo))
                        .ForMember(d => d.ModifiedOn, opt => opt.MapFrom(f => f.Timestamp));

                    cfg.CreateMap<VoucherLedger, VoucherDescription>()
                        .ForMember(d => d.VoucherId, opt => opt.MapFrom(f => f.VoucherLedgerId.ToString()))
                        .ForMember(d => d.VoucherTypeId, opt => opt.MapFrom(f => f.VoucherTypeId.HasValue ? f.VoucherTypeId.ToString() : null))
                        .ForMember(d => d.CoinId, opt => opt.MapFrom(f => f.CoinId.ToString()))
                        .ForMember(d => d.CustomerId, opt => opt.MapFrom(f => f.UserId.ToString()))
                        .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                        .ForMember(d => d.Label, opt => opt.MapFrom(f => f.Label))
                        .ForMember(d => d.StringValue, opt => opt.MapFrom(f => f.StringValue))
                        .ForMember(d => d.Activate, opt => opt.MapFrom(f => f.Activate))
                        .ForMember(d => d.ValidFrom, opt => opt.MapFrom(f => f.ValidFrom))
                        .ForMember(d => d.ValidTo, opt => opt.MapFrom(f => f.ValidTo))
                        .ForMember(d => d.Timestamp, opt => opt.MapFrom(f => f.ModifiedOn))
                        .ForMember(d => d.Attributes, opt => opt.ResolveUsing((vl, vd, i, context) =>
                        {
                            return vl.VoucherLedgerGenericAttributeMap
                            .ToDictionary(
                                t => t.GenericAttribute.GenericAttributeType.Name,
                                t => JsonConvert.DeserializeObject(t.GenericAttribute.GenericAttributeValue.ValueString, settings)
                            );
                        }));

                    //!!!!! Policy

                    cfg.CreateMap<LedgerLocalPolicyGenericAttributeMap, PolicyDescription>()
                    .ForMember(d => d.PolicyGenericAttributeId, opt => opt.MapFrom(f => f.LedgerLocalPolicyGenericAttributeId.ToString()))
                    .ForMember(d => d.GenericAttributeId, opt => opt.MapFrom(f => f.GenericAttributeId.ToString()))
                    .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                    .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                    .ForMember(d => d.Timestamp, opt => opt.MapFrom(f => f.ModifiedOn))
                    .ForMember(d => d.KeyValue, opt => opt.ResolveUsing((pga, pd, i, context) =>
                    {
                        return pga.GenericAttribute.GenericAttributeType.Name;
                    }))
                    .ForMember(d => d.ItemValue, opt => opt.ResolveUsing((pga, pd, i, context) =>
                    {
                        return JsonConvert.DeserializeObject(pga.GenericAttribute.GenericAttributeValue.ValueString, settings);
                    }));
                    
                    //!!!!! Workflow
                    cfg.CreateMap<WorkflowContainer, WorkflowCreateOrUpdate>()
                        .ForMember(d => d.WorkflowId, opt => opt.MapFrom(f => f.WorkflowContainerId.ToString()))
                        .ForMember(d => d.WorkflowTypeId, opt => opt.MapFrom(f => f.WorkflowTypeId.ToString()))
                        .ForMember(d => d.CategoryId, opt => opt.MapFrom(f => f.CategoryId.HasValue ? f.CategoryId.Value.ToString() : null))
                        .ForMember(d => d.CultureId, opt => opt.MapFrom(f => f.CultureId.ToString()))
                        .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                        .ForMember(d => d.Description, opt => opt.MapFrom(f => f.Description))
                        .ForMember(d => d.Body, opt => opt.MapFrom(f => f.Body))
                        .ForMember(d => d.IsComponent, opt => opt.MapFrom(f => f.IsComponent))
                        .ForMember(d => d.HasArguments, opt => opt.MapFrom(f => f.HasArguments))
                        .ForMember(d => d.IsEntryPoint, opt => opt.MapFrom(f => f.IsEntryPoint))
                        .ForMember(d => d.Timestamp, opt => opt.MapFrom(f => f.CreatedOn));

                    cfg.CreateMap<WorkflowCreateOrUpdate, WorkflowContainer>()
                        .ForMember(d => d.WorkflowContainerId, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.WorkflowId) ? 0 : Convert.ToInt32(f.WorkflowId)))
                        .ForMember(d => d.WorkflowTypeId, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.WorkflowTypeId) ? 0 : Convert.ToInt32(f.WorkflowTypeId)))
                        .ForMember(d => d.CategoryId, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.CategoryId) ? null : (int?)Convert.ToInt32(f.CategoryId)))
                        .ForMember(d => d.CultureId, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.CultureId) ? 0 : Convert.ToInt32(f.CategoryId)))
                        .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                        .ForMember(d => d.Description, opt => opt.MapFrom(f => f.Description))
                        .ForMember(d => d.Body, opt => opt.MapFrom(f => f.Body))
                        .ForMember(d => d.IsComponent, opt => opt.MapFrom(f => f.IsComponent))
                        .ForMember(d => d.HasArguments, opt => opt.MapFrom(f => f.HasArguments))
                        .ForMember(d => d.IsEntryPoint, opt => opt.MapFrom(f => f.IsEntryPoint))
                        .ForMember(d => d.CreatedOn, opt => opt.MapFrom(f => f.Timestamp));

                    cfg.CreateMap<WorkflowContainer, WorkflowDescription>()
                        .ForMember(d => d.WorkflowId, opt => opt.MapFrom(f => f.WorkflowContainerId.ToString()))
                        .ForMember(d => d.WorkflowTypeId, opt => opt.MapFrom(f => f.WorkflowTypeId.ToString()))
                        .ForMember(d => d.CategoryId, opt => opt.MapFrom(f => f.CategoryId.HasValue ? f.CategoryId.Value.ToString() : null))
                        .ForMember(d => d.CultureId, opt => opt.MapFrom(f => f.CultureId.ToString()))
                        .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                        .ForMember(d => d.Description, opt => opt.MapFrom(f => f.Description))
                        .ForMember(d => d.Body, opt => opt.MapFrom(f => f.Body))
                        .ForMember(d => d.IsComponent, opt => opt.MapFrom(f => f.IsComponent))
                        .ForMember(d => d.HasArguments, opt => opt.MapFrom(f => f.HasArguments))
                        .ForMember(d => d.IsEntryPoint, opt => opt.MapFrom(f => f.IsEntryPoint))
                        .ForMember(d => d.Timestamp, opt => opt.MapFrom(f => f.CreatedOn))
                        .ForMember(d => d.Arguments, opt => opt.ResolveUsing((vl, vd, i, context) =>
                        {
                            return vl.WorkflowGenericAttributeMap
                            .ToDictionary(
                                t => t.GenericAttribute.GenericAttributeType.Name,
                                t => JsonConvert.DeserializeObject(t.GenericAttribute.GenericAttributeValue.ValueString, settings)
                            );
                        }));

                    //cfg.CreateMap<Order, OrderDto>()
                    //     .ForMember(dst => dst.Customer, src => src.ResolveUsing((order, orderDto, i, context) => {
                    //         return order.Type == 1
                    //         ? context.Mapper.Map<Customer, CustomerDto>(order.Customer)
                    //         : context.Mapper.Map<Customer, DetailedCustomerDto>(order.Customer);
                    //     }));


                });

            return config;
        }
    }
}
