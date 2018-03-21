using AutoMapper;
using LedgerLocal.FrontServer.Api.Web.Models;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using LedgerLocal.FrontServer.Service.Json;
using LedgerLocal.FrontServer.Data.FullDomain;
using LedgerLocal.FrontServer.Dto;

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

                    //!!!!!! User
                    cfg.CreateMap<User, CustomerCreateOrUpdate>()
                        .ForMember(d => d.CustomerId, opt => opt.MapFrom(f => f.Userid))
                        .ForMember(d => d.Email, opt => opt.MapFrom(f => f.Email));

                    cfg.CreateMap<CustomerCreateOrUpdate, User>()
                        .ForMember(d => d.Userid, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.CustomerId) ? 0 : Convert.ToInt32(f.CustomerId)))
                        .ForMember(d => d.Username, opt => opt.MapFrom(f => f.Email))
                        .ForMember(d => d.Email, opt => opt.MapFrom(f => f.Email))
                        .ForMember(d => d.Password, opt => opt.MapFrom(f => string.Empty));

                    //!!!!! CustomerProfile

                                        
                    //!!!!! Workflow
                    cfg.CreateMap<Workflowcontainer, WorkflowCreateOrUpdate>()
                        .ForMember(d => d.WorkflowId, opt => opt.MapFrom(f => f.Workflowcontainerid.ToString()))
                        .ForMember(d => d.WorkflowTypeId, opt => opt.MapFrom(f => f.Workflowtypeid.ToString()))
                        .ForMember(d => d.CategoryId, opt => opt.MapFrom(f => f.Categoryid.HasValue ? f.Categoryid.Value.ToString() : null))
                        .ForMember(d => d.CultureId, opt => opt.MapFrom(f => f.Cultureid.ToString()))
                        .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                        .ForMember(d => d.Description, opt => opt.MapFrom(f => f.Description))
                        .ForMember(d => d.Body, opt => opt.MapFrom(f => f.Body))
                        .ForMember(d => d.IsComponent, opt => opt.MapFrom(f => f.Iscomponent))
                        .ForMember(d => d.HasArguments, opt => opt.MapFrom(f => f.Hasarguments))
                        .ForMember(d => d.IsEntryPoint, opt => opt.MapFrom(f => f.Isentrypoint))
                        .ForMember(d => d.Timestamp, opt => opt.MapFrom(f => f.Createdon));

                    cfg.CreateMap<WorkflowCreateOrUpdate, Workflowcontainer>()
                        .ForMember(d => d.Workflowcontainerid, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.WorkflowId) ? 0 : Convert.ToInt32(f.WorkflowId)))
                        .ForMember(d => d.Workflowtypeid, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.WorkflowTypeId) ? 0 : Convert.ToInt32(f.WorkflowTypeId)))
                        .ForMember(d => d.Categoryid, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.CategoryId) ? null : (int?)Convert.ToInt32(f.CategoryId)))
                        .ForMember(d => d.Cultureid, opt => opt.MapFrom(f => string.IsNullOrWhiteSpace(f.CultureId) ? 0 : Convert.ToInt32(f.CategoryId)))
                        .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                        .ForMember(d => d.Description, opt => opt.MapFrom(f => f.Description))
                        .ForMember(d => d.Body, opt => opt.MapFrom(f => f.Body))
                        .ForMember(d => d.Iscomponent, opt => opt.MapFrom(f => f.IsComponent))
                        .ForMember(d => d.Hasarguments, opt => opt.MapFrom(f => f.HasArguments))
                        .ForMember(d => d.Isentrypoint, opt => opt.MapFrom(f => f.IsEntryPoint))
                        .ForMember(d => d.Createdon, opt => opt.MapFrom(f => f.Timestamp));

                    cfg.CreateMap<Workflowcontainer, WorkflowDescription>()
                        .ForMember(d => d.WorkflowId, opt => opt.MapFrom(f => f.Workflowcontainerid.ToString()))
                        .ForMember(d => d.WorkflowTypeId, opt => opt.MapFrom(f => f.Workflowtypeid.ToString()))
                        .ForMember(d => d.CategoryId, opt => opt.MapFrom(f => f.Categoryid.HasValue ? f.Categoryid.Value.ToString() : null))
                        .ForMember(d => d.CultureId, opt => opt.MapFrom(f => f.Cultureid.ToString()))
                        .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                        .ForMember(d => d.Description, opt => opt.MapFrom(f => f.Description))
                        .ForMember(d => d.Body, opt => opt.MapFrom(f => f.Body))
                        .ForMember(d => d.IsComponent, opt => opt.MapFrom(f => f.Iscomponent))
                        .ForMember(d => d.HasArguments, opt => opt.MapFrom(f => f.Hasarguments))
                        .ForMember(d => d.IsEntryPoint, opt => opt.MapFrom(f => f.Isentrypoint))
                        .ForMember(d => d.Timestamp, opt => opt.MapFrom(f => f.Createdon))
                        .ForMember(d => d.Arguments, opt => opt.ResolveUsing((vl, vd, i, context) =>
                        {
                            return vl.Workflowgenericattributemap
                            .ToDictionary(
                                t => t.Genericattribute.Genericattributetype.Name,
                                t => JsonConvert.DeserializeObject(t.Genericattribute.Genericattributevalue.Valuestring, settings)
                            );
                        }));

                    //cfg.CreateMap<Order, OrderDto>()
                    //     .ForMember(dst => dst.Customer, src => src.ResolveUsing((order, orderDto, i, context) => {
                    //         return order.Type == 1
                    //         ? context.Mapper.Map<Customer, CustomerDto>(order.Customer)
                    //         : context.Mapper.Map<Customer, DetailedCustomerDto>(order.Customer);
                    //     }));

                    //

                    cfg.CreateMap<CultureDto, Culture>();

                    cfg.CreateMap<Culture, CultureDto>();

                    //

                    cfg.CreateMap<PageDto, Page>();

                    cfg.CreateMap<Page, PageDto>();

                    //

                    cfg.CreateMap<ArticleDto, Article>();

                    cfg.CreateMap<Article, ArticleDto>();

                    //

                    cfg.CreateMap<ContentblockDto, Contentblock>();

                    cfg.CreateMap<Contentblock, ContentblockDto>()
                                             .ForMember(dst => dst.Images, src => src.ResolveUsing((c, cDto, i, context) =>
                                             {
                                                 return c.Contentblockimagemap.Count > 0
                                                 ? context.Mapper.Map<List<Image>, List<ImageDto>>(c.Contentblockimagemap
                                                 .OrderBy(d => d.Image.Fullimageurl)
                                                 .Select(d => d.Image).ToList())
                                                 : Enumerable.Empty<ImageDto>().ToList();
                                             }));

                    //

                    cfg.CreateMap<ImageDto, Image>();

                    cfg.CreateMap<Image, ImageDto>();

                    //

                    cfg.CreateMap<ContentBlockImageMapDto, Contentblockimagemap>();

                    cfg.CreateMap<Contentblockimagemap, ContentBlockImageMapDto>();

                });

            return config;
        }
    }
}
