using LedgerLocal.FrontServer.Dto.AttributeAutocomplete;
using LedgerLocal.FrontServer.Dto.AttributeSuggest;
using LedgerLocal.FrontServer.Enum;
using LedgerLocal.FrontServer.Model.FullDomain;
using LedgerLocal.FrontServer.Model.FullDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Service
{
    public interface IAttributeService
    {
        Task<GenericAttribute> CreateOrGetAttribute(
                    string type,
                    string value,
                    object typeObject = null,
                    object valueObject = null,
                    int typeSort = 0,
                    int valueSort = 0,
                    int? categoryId = null);

        GenericAttributeType GetAttributeType(string type, object typeObject = null, int? categoryId = null);
        
        GenericAttributeValue GetValue(string value, object valueObject = null);

        Task<Tuple<string, IList<GenericAttribute>>> CreateAttributeBulk(IList<AttributeBulk> attributesCreates);
    }
}
