using AutoMapper;
using Newtonsoft.Json;
using LedgerLocal.AdminServer.Service.Json;
using LedgerLocal.AdminServer.Data.FullDomain;
using LedgerLocal.AdminServer.Dto;
using LedgerLocal.AdminServer.Api.Web.Models;
using System.Linq;

namespace LedgerLocal.AdminServer.Service
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

                    //!!!!!! User

                    cfg.CreateMap<User, CustomerProfile>()
                        .ForMember(d => d.CustomerId, opt => opt.MapFrom(f => f.Userid))
                        .ForMember(d => d.FirstName, opt => opt.MapFrom(f => f.People.Firstname))
                        .ForMember(d => d.LastName, opt => opt.MapFrom(f => f.People.Lastname))
                        .ForMember(d => d.Address1, src => src.ResolveUsing((user, customerProfile, i, context) => {
                            return user?.People?.Address?.Count > 0
                            ?
                            user.People.Address.First().Street1
                            : null;
                        }))
                        .ForMember(d => d.Address2, src => src.ResolveUsing((user, customerProfile, i, context) => {
                            return user?.People?.Address?.Count > 0
                            ?
                            user.People.Address.First().Street2
                            : null;
                        }))
                        .ForMember(d => d.Country, src => src.ResolveUsing((user, customerProfile, i, context) => {
                            return user?.People?.Address?.Count > 0
                            ?
                            user.People.Address.First().Country
                            : null;
                        }))
                        .ForMember(d => d.Email, opt => opt.MapFrom(f => f.Email));

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
