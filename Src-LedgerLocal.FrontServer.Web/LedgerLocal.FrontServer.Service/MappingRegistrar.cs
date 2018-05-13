using AutoMapper;
using LedgerLocal.FrontServer.Api.Web.Models;
using System;
using Newtonsoft.Json;
using LedgerLocal.FrontServer.Data.FullDomain;
using LedgerLocal.FrontServer.Dto;
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

                    cfg.CreateMap<Genericattribute, GenericAttributeDto>();

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

                    cfg.CreateMap<Contentblock, ContentblockDto>();

                    //

                    cfg.CreateMap<ContentBlockImageMapDto, Contentblockimagemap>();

                    cfg.CreateMap<Contentblockimagemap, ContentBlockImageMapDto>();

                });

            return config;
        }
    }
}
