using LedgerLocal.FrontServer.Data.FullDomain.Infrastructure;
using LedgerLocal.FrontServer.Model.FullDomain;
using LedgerLocal.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using LedgerLocal.FrontServer.Data.FullDomain.Bulk;
using Microsoft.Extensions.Logging;
using LedgerLocal.FrontServer.Data.FullDomain;
using Microsoft.EntityFrameworkCore;
using LedgerLocal.FrontServer.Service.Json;

namespace LedgerLocal.FrontServer.Service.PersistenceService
{
    public class AttributeService : IAttributeService
    {
        private readonly ILedgerLocalDbFullDomainRepository<Genericattribute> _attributeRepository;
        private readonly ILedgerLocalDbFullDomainRepository<Genericattributevalue> _attributeValueRepository;
        private readonly ILedgerLocalDbFullDomainRepository<Genericattributetype> _attributeTypeRepository;
        private readonly ILedgerLocalDbFullDomainUnitOfWork _unitOfWork;
        private readonly ILedgerLocalBulkOperator _LedgerLocalBulkOperator;

        private readonly ILogger<AttributeService> _logger;

        public AttributeService(ILogger<AttributeService> logger, 
            ILedgerLocalDbFullDomainRepository<Genericattribute> attributeRepository,
            ILedgerLocalDbFullDomainRepository<Genericattributevalue> attributeValueRepository,
            ILedgerLocalDbFullDomainRepository<Genericattributetype> attributeTypeRepository,
            ILedgerLocalDbFullDomainUnitOfWork unitOfWork,
            ILedgerLocalBulkOperator LedgerLocalBulkOperator)
        {
            _logger = logger;
            _attributeRepository = attributeRepository;
            _attributeValueRepository = attributeValueRepository;
            _attributeTypeRepository = attributeTypeRepository;
            _unitOfWork = unitOfWork;
            _LedgerLocalBulkOperator = LedgerLocalBulkOperator;
        }

        public async Task<Tuple<string, IList<Genericattribute>>> CreateAttributeBulk(IList<AttributeBulk> attributesCreates)
        {
            StringBuilder logger = new StringBuilder();

            Check.Require(attributesCreates != null, "attributesCreates must be supplied.");

            var utcNow = DateTime.UtcNow;

            var lstTuple = new List<Tuple<Genericattributetype, Genericattributevalue>>();

            var attributeTypeRepositoryLocal = (ILedgerLocalDbFullDomainRepository<Genericattributetype>)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(ILedgerLocalDbFullDomainRepository<Genericattributetype>));
            var maxGaType = attributeTypeRepositoryLocal.DbSet.Max(x => x.Genericattributetypeid);
            var attributeValueRepositoryLocal = (ILedgerLocalDbFullDomainRepository<Genericattributevalue>)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(ILedgerLocalDbFullDomainRepository<Genericattributevalue>));
            var maxGaValue = attributeValueRepositoryLocal.DbSet.Max(x => x.Genericattributevalueid);

            foreach (var a1 in attributesCreates)
            {
                maxGaType = maxGaType + 1;
                maxGaValue = maxGaValue + 1;

                var t1 = CreateBulkTupleTypeValue(a1);

                t1.Item1.Genericattributetypeid = maxGaType;
                t1.Item2.Genericattributevalueid = maxGaValue;

                lstTuple.Add(t1);
            }

            var tuple1 = new List<Tuple<string, string>>();
            tuple1.Add(new Tuple<string, string>("GenericAttributeTypeId", "GenericAttributeTypeId"));
            tuple1.Add(new Tuple<string, string>("CategoryId", "CategoryID"));
            tuple1.Add(new Tuple<string, string>("Name", "Name"));
            tuple1.Add(new Tuple<string, string>("Sort", "Sort"));
            tuple1.Add(new Tuple<string, string>("MetaTypeString", "MetaTypeString"));
            tuple1.Add(new Tuple<string, string>("MetaTypeLabel", "MetaTypeLabel"));
            tuple1.Add(new Tuple<string, string>("ValueString", "ValueString"));
            tuple1.Add(new Tuple<string, string>("ValueNumber", "ValueNumber"));
            tuple1.Add(new Tuple<string, string>("ValueBool", "ValueBool"));
            tuple1.Add(new Tuple<string, string>("ValueDate", "ValueDate"));
            tuple1.Add(new Tuple<string, string>("ValueLabelString", "ValueLabelString"));
            tuple1.Add(new Tuple<string, string>("ValueLabelNumber", "ValueLabelNumber"));
            tuple1.Add(new Tuple<string, string>("ValueLabelBool", "ValueLabelBool"));
            tuple1.Add(new Tuple<string, string>("ValueLabelDate", "ValueLabelDate"));
            tuple1.Add(new Tuple<string, string>("CreatedOn", "CreatedOn"));
            tuple1.Add(new Tuple<string, string>("ModifiedOn", "ModifiedOn"));
            tuple1.Add(new Tuple<string, string>("CreatedBy", "CreatedBy"));
            tuple1.Add(new Tuple<string, string>("ModifiedBy", "ModifiedBy"));

            var lstTypes = lstTuple.Select(x => x.Item1).ToList();
            var LedgerLocalBulkOperatorLocal1 = (ILedgerLocalBulkOperator)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(ILedgerLocalBulkOperator));
            await LedgerLocalBulkOperatorLocal1.BulkInsertBulkCopy<Genericattributetype>(lstTypes, tuple1, "[System].[Genericattributetype]", 1000);

            logger.AppendLine(string.Format("Genericattributetype Bulked: {0} rows", lstTypes.Count));

            var tuple2 = new List<Tuple<string, string>>();

            tuple2.Add(new Tuple<string, string>("GenericAttributeValueId", "GenericAttributeValueId"));
            tuple2.Add(new Tuple<string, string>("Name", "Name"));
            tuple2.Add(new Tuple<string, string>("Label", "Label"));
            tuple2.Add(new Tuple<string, string>("Sort", "Sort"));
            tuple2.Add(new Tuple<string, string>("MetaTypeString", "MetaTypeString"));
            tuple2.Add(new Tuple<string, string>("MetaTypeLabel", "MetaTypeLabel"));
            tuple2.Add(new Tuple<string, string>("ValueString", "ValueString"));
            tuple2.Add(new Tuple<string, string>("ValueNumber", "ValueNumber"));
            tuple2.Add(new Tuple<string, string>("ValueBool", "ValueBool"));
            tuple2.Add(new Tuple<string, string>("ValueDate", "ValueDate"));
            tuple2.Add(new Tuple<string, string>("ValueLabelString", "ValueLabelString"));
            tuple2.Add(new Tuple<string, string>("ValueLabelNumber", "ValueLabelNumber"));
            tuple2.Add(new Tuple<string, string>("ValueLabelBool", "ValueLabelBool"));
            tuple2.Add(new Tuple<string, string>("ValueLabelDate", "ValueLabelDate"));
            tuple2.Add(new Tuple<string, string>("CreatedOn", "CreatedOn"));
            tuple2.Add(new Tuple<string, string>("ModifiedOn", "ModifiedOn"));
            tuple2.Add(new Tuple<string, string>("CreatedBy", "CreatedBy"));
            tuple2.Add(new Tuple<string, string>("ModifiedBy", "ModifiedBy"));

            var lstValues = lstTuple.Select(x => x.Item2).ToList();
            var LedgerLocalBulkOperatorLocal2 = (ILedgerLocalBulkOperator)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(ILedgerLocalBulkOperator));
            await LedgerLocalBulkOperatorLocal2.BulkInsertBulkCopy<Genericattributevalue>(lstValues, tuple2, "[System].[Genericattributevalue]", 1000);

            logger.AppendLine(string.Format("Genericattributevalue Bulked: {0} rows", lstValues.Count));

            var lstAttributes = new List<Genericattribute>();

            var ix1 = 0;
            var attributeRepositoryLocal = (ILedgerLocalDbFullDomainRepository<Genericattribute>)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(ILedgerLocalDbFullDomainRepository<Genericattribute>));
            var maxGAttribute = attributeRepositoryLocal.DbSet.Max(x => x.Genericattributeid);

            foreach (var t1 in lstTuple)
            {
                maxGAttribute = maxGAttribute + 1;

                var attribute = new Genericattribute();
                attribute.Genericattributeid = maxGAttribute;
                attribute.Genericattributetypeid = t1.Item1.Genericattributetypeid;
                attribute.Genericattributevalueid = t1.Item2.Genericattributevalueid;

                attribute.Typestring = attributesCreates[ix1].Type;
                attribute.Valuestring = attributesCreates[ix1].Value;

                attribute.Createdon = utcNow;
                attribute.Modifiedon = utcNow;
                attribute.Createdby = "System";
                attribute.Modifiedby = "System";

                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All,
                };

                settings.Converters.Insert(0, new PrimitiveJsonConverter());

                if (attributesCreates[ix1].TypeObject != null)
                {
                    attribute.Typelabelstring = JsonConvert.SerializeObject(attributesCreates[ix1].TypeObject, settings);
                }
                else
                {
                    attribute.Typelabelstring = EncodeLabel(attributesCreates[ix1].Type);
                }

                if (attributesCreates[ix1].ValueObject != null)
                {
                    attribute.Valuelabelstring = JsonConvert.SerializeObject(attributesCreates[ix1].ValueObject, settings);
                }
                else
                {
                    attribute.Valuelabelstring = EncodeLabel(attributesCreates[ix1].Value);
                }

                lstAttributes.Add(attribute);
                ix1 = ix1 + 1;
            }

            var tuple3 = new List<Tuple<string, string>>();

            tuple3.Add(new Tuple<string, string>("GenericAttributeId", "GenericAttributeId"));
            tuple3.Add(new Tuple<string, string>("GenericAttributeTypeId", "GenericAttributeTypeId"));
            tuple3.Add(new Tuple<string, string>("GenericAttributeValueId", "GenericAttributeValueId"));
            tuple3.Add(new Tuple<string, string>("TypeString", "TypeString"));
            tuple3.Add(new Tuple<string, string>("TypeLabelString", "TypeLabelString"));
            tuple3.Add(new Tuple<string, string>("ValueString", "ValueString"));
            tuple3.Add(new Tuple<string, string>("ValueLabelString", "ValueLabelString"));
            tuple3.Add(new Tuple<string, string>("CreatedOn", "CreatedOn"));
            tuple3.Add(new Tuple<string, string>("ModifiedOn", "ModifiedOn"));
            tuple3.Add(new Tuple<string, string>("CreatedBy", "CreatedBy"));
            tuple3.Add(new Tuple<string, string>("ModifiedBy", "ModifiedBy"));

            var LedgerLocalBulkOperatorLocal3 = (ILedgerLocalBulkOperator)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(ILedgerLocalBulkOperator));
            await LedgerLocalBulkOperatorLocal3.BulkInsertBulkCopy<Genericattribute>(lstAttributes, tuple3, "[System].[Genericattribute]", 1000);

            logger.AppendLine(string.Format("Genericattribute Bulked: {0} rows", lstAttributes.Count));

            return new Tuple<string, IList<Genericattribute>>(logger.ToString(), lstAttributes);
        }

        public async Task<Genericattribute> CreateOrGetAttribute(
            string type,
            string value,
            object typeObject = null,
            object valueObject = null,
            int typeSort = 0,
            int valueSort = 0,
            int? categoryId = null)
        {
            Check.Require(!string.IsNullOrWhiteSpace(type), "type must be supplied.");
            Check.Require(!string.IsNullOrWhiteSpace(value), "value must be supplied.");

            var utcNow = DateTime.UtcNow;

            var tupleTypeValue = await CreateOrGetTupleTypeValue(type, value, typeObject, valueObject, typeSort, valueSort, categoryId);

            var findAttribute = _attributeRepository.DbSet.FirstOrDefault(x => x.Genericattributetypeid == tupleTypeValue.Item1.Genericattributetypeid
                && x.Genericattributevalueid == tupleTypeValue.Item2.Genericattributevalueid);

            if (findAttribute != null)
            {
                return findAttribute;
            }

            var attribute = new Genericattribute();
            attribute.Genericattributetypeid = tupleTypeValue.Item1.Genericattributetypeid;
            attribute.Genericattributevalueid = tupleTypeValue.Item2.Genericattributevalueid;

            attribute.Typestring = type;
            attribute.Valuestring = value;

            attribute.Createdon = utcNow;
            attribute.Modifiedon = utcNow;
            attribute.Createdby = "System";
            attribute.Modifiedby = "System";

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            settings.Converters.Insert(0, new PrimitiveJsonConverter());

            if (typeObject != null)
            {
                attribute.Typelabelstring = JsonConvert.SerializeObject(typeObject, settings);
            }
            else
            {
                attribute.Typelabelstring = EncodeLabel(type);
            }

            if (valueObject != null)
            {
                attribute.Valuelabelstring = JsonConvert.SerializeObject(valueObject, settings);
            }
            else
            {
                attribute.Valuelabelstring = EncodeLabel(value);
            }

            await _attributeRepository.AddAsync(attribute);
            var error1 = _unitOfWork.CommitHandled();
            if (!error1)
            {
                _logger.LogError($"Can't Attribute ! {JsonConvert.SerializeObject(attribute, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
            }

            return attribute;
        }

        public Genericattributetype GetAttributeType(string type, object typeObject = null, int? categoryId = null)
        {
            Check.Require(!string.IsNullOrWhiteSpace(type), "type must be valid.");

            var encodedLabel = EncodeLabel(type);

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            settings.Converters.Insert(0, new PrimitiveJsonConverter());

            Genericattributetype foundEntity = null;

            if (typeObject != null)
            {
                var jsonObj = JsonConvert.SerializeObject(typeObject, settings);
                var found = _attributeTypeRepository.DbSet.FirstOrDefault(x =>
                    string.Compare(x.Name, type, true) == 0
                    && string.Compare(x.Valuestring, jsonObj, true) == 0
                    && x.Categoryid == categoryId);
                foundEntity = found;
            }
            else
            {
                var found2 = _attributeTypeRepository.DbSet.FirstOrDefault(x =>
                    string.Compare(x.Name, type, true) == 0
                    && x.Categoryid == categoryId);
                foundEntity = found2;
            }

            return foundEntity;
        }

        public Genericattributevalue GetValue(string value, object valueObject = null)
        {
            Check.Require(!string.IsNullOrWhiteSpace(value), "value must be valid.");

            var encodedLabel = EncodeLabel(value);

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            settings.Converters.Insert(0, new PrimitiveJsonConverter());

            Genericattributevalue foundEntity = null;

            if (valueObject != null)
            {
                var jsonObj = JsonConvert.SerializeObject(valueObject, settings);
                var found = _attributeValueRepository.DbSet.FirstOrDefault(x =>
                    string.Compare(x.Name, value, true) == 0
                    && string.Compare(x.Valuestring, jsonObj, true) == 0);
                foundEntity = found;
            }
            else
            {
                var found2 = _attributeValueRepository.DbSet.FirstOrDefault(x =>
                    string.Compare(x.Name, value, true) == 0);
                foundEntity = found2;
            }

            return foundEntity;
        }

        private string EncodeLabel(string label)
        {
            return label.Replace(" ", "-");
        }

        private Tuple<Genericattributetype, Genericattributevalue> CreateBulkTupleTypeValue(
            AttributeBulk bulkInfo)
        {
            var utcNow = DateTime.UtcNow;

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            settings.Converters.Insert(0, new PrimitiveJsonConverter());


            var typeEntity = new Genericattributetype();
            var valueEntity = new Genericattributevalue();

            typeEntity.Createdon = utcNow;
            typeEntity.Modifiedon = utcNow;
            typeEntity.Createdby = "System";
            typeEntity.Modifiedby = "System";

            valueEntity.Createdon = utcNow;
            valueEntity.Modifiedon = utcNow;
            valueEntity.Createdby = "System";
            valueEntity.Modifiedby = "System";

            typeEntity.Sort = bulkInfo.TypeSort;
            valueEntity.Sort = bulkInfo.ValueSort;

            typeEntity.Name = bulkInfo.Type;

            if (bulkInfo.CategoryId.HasValue)
            {
                typeEntity.Categoryid = bulkInfo.CategoryId.Value;
            }

            if (bulkInfo.TypeObject != null)
            {
                var typeObjectJson = JsonConvert.SerializeObject(bulkInfo.TypeObject, settings);
                typeEntity.Valuestring = typeObjectJson;

                typeEntity.Metatypestring = bulkInfo.TypeObject.GetType().Name;
                typeEntity.Metatypelabel = bulkInfo.TypeObject.GetType().AssemblyQualifiedName;
            }

            valueEntity.Name = bulkInfo.Value;

            if (bulkInfo.ValueObject != null)
            {
                var valueObjectJson = JsonConvert.SerializeObject(bulkInfo.ValueObject, settings);
                valueEntity.Valuestring = valueObjectJson;

                valueEntity.Metatypestring = bulkInfo.ValueObject.GetType().Name;
                valueEntity.Metatypelabel = bulkInfo.ValueObject.GetType().AssemblyQualifiedName;
            }

            Genericattributetype finalType;
            Genericattributevalue finalValue;
            
            finalType = typeEntity;

            finalValue = valueEntity;

            var resTuple = new Tuple<Genericattributetype, Genericattributevalue>(finalType, finalValue);

            return resTuple;
        }

        private async Task<Tuple<Genericattributetype, Genericattributevalue>> CreateOrGetTupleTypeValue (
            string type,
            string value,
            object typeObject = null,
            object valueObject = null,
            int typeSort = 0,
            int valueSort = 0,
            int? categoryId = null)
        {
            //var res = "";

            //TypeSwitch.Do(
            //    value,
            //    TypeSwitch.Case<sbyte>(() => res = "It's a int"),
            //    TypeSwitch.Case<byte>(x => res = "It's a long"),
            //    TypeSwitch.Case<short>(x => res = "It's a long"),
            //    TypeSwitch.Case<ushort>(x => res = "It's a long"),
            //    TypeSwitch.Case<int>(x => res = "It's a long"),
            //    TypeSwitch.Case<uint>(x => res = "It's a long"),
            //    TypeSwitch.Case<long>(x => res = "It's a long"),
            //    TypeSwitch.Case<ulong>(x => res = "It's a long"),
            //    TypeSwitch.Case<char>(x => res = "It's a long"),
            //    TypeSwitch.Case<float>(x => res = "It's a long"),
            //    TypeSwitch.Case<double>(x => res = "It's a long"),
            //    TypeSwitch.Case<bool>(x => res = "It's a long"),
            //    TypeSwitch.Case<decimal>(x => res = "It's a long"),
            //    TypeSwitch.Case<string>(x => res = "It's a long"),
            //    TypeSwitch.Case<DateTime>(x => res = "It's a long"),
            //    TypeSwitch.Default(() => res = "It's default"));

            var utcNow = DateTime.UtcNow;

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            settings.Converters.Insert(0, new PrimitiveJsonConverter());


            var typeEntity = new Genericattributetype();
            var valueEntity = new Genericattributevalue();

            typeEntity.Createdon = utcNow;
            typeEntity.Modifiedon = utcNow;
            typeEntity.Createdby = "System";
            typeEntity.Modifiedby = "System";

            valueEntity.Createdon = utcNow;
            valueEntity.Modifiedon = utcNow;
            valueEntity.Createdby = "System";
            valueEntity.Modifiedby = "System";

            typeEntity.Sort = typeSort;
            valueEntity.Sort = valueSort;

            typeEntity.Name = type;

            if (categoryId.HasValue)
            {
                typeEntity.Categoryid = categoryId.Value;
            }

            if (typeObject != null)
            {
                var typeObjectJson = JsonConvert.SerializeObject(typeObject, settings);
                typeEntity.Valuestring = typeObjectJson;

                typeEntity.Metatypestring = typeObject.GetType().Name;
                typeEntity.Metatypelabel = typeObject.GetType().AssemblyQualifiedName;
            }

            valueEntity.Name = value;

            if (valueObject != null)
            {
                var valueObjectJson = JsonConvert.SerializeObject(valueObject, settings);
                valueEntity.Valuestring = valueObjectJson;

                valueEntity.Metatypestring = valueObject.GetType().Name;
                valueEntity.Metatypelabel = valueObject.GetType().AssemblyQualifiedName;
            }

            Genericattributetype finalType;
            Genericattributevalue finalValue;

            var findType = _attributeTypeRepository.DbSet.FirstOrDefault(
                x => x.Categoryid == typeEntity.Categoryid
                    && x.Name == typeEntity.Name
                    && x.Valuestring == typeEntity.Valuestring
                    && x.Metatypestring == typeEntity.Metatypestring
                    && x.Metatypelabel == typeEntity.Metatypelabel);

            if (findType != null)
            {
                finalType = findType;
            }
            else
            {
                await _attributeTypeRepository.AddAsync(typeEntity);

                var errors1 = await _unitOfWork.CommitHandledAsync();

                if (!errors1)
                {
                    _logger.LogError($"Can't Attribute Type ! {JsonConvert.SerializeObject(typeEntity, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
                }

                finalType = typeEntity;
            }

            var findValue = _attributeValueRepository.DbSet.FirstOrDefault(
                x => x.Name == valueEntity.Name
                    && x.Valuestring == valueEntity.Valuestring
                    && x.Metatypestring == valueEntity.Metatypestring
                    && x.Metatypelabel == valueEntity.Metatypelabel);

            if (findValue != null)
            {
                finalValue = findValue;
            } 
            else
            {
                await _attributeValueRepository.AddAsync(valueEntity);

                var errors2 = await _unitOfWork.CommitHandledAsync();

                if (!errors2)
                {
                    _logger.LogError($"Can't Attribute Value ! {JsonConvert.SerializeObject(valueEntity, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
                }

                finalValue = valueEntity;
            }

            var resTuple = new Tuple<Genericattributetype, Genericattributevalue>(finalType, finalValue);

            return resTuple;
        }

        private AttributeEntityObject DeserializeFromTuple(Tuple<Genericattributetype, Genericattributevalue> entry)
        {

            var utcNow = DateTime.UtcNow;

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            settings.Converters.Insert(0, new PrimitiveJsonConverter());

            var res = new AttributeEntityObject();

            res.Type = entry.Item1.Name;
            res.TypeSort = entry.Item1.Sort;

            if (!string.IsNullOrWhiteSpace(entry.Item1.Valuestring))
            {
                res.TypeObject = JsonConvert.DeserializeObject(entry.Item1.Valuestring, settings);
            }

            res.TypeMetaTypeString = entry.Item1.Metatypestring;
            res.TypeMetaTypeFullString = entry.Item1.Metatypelabel;

            res.Value = entry.Item2.Name;
            res.ValueSort = entry.Item2.Sort;

            if (!string.IsNullOrWhiteSpace(entry.Item2.Valuestring))
            {
                res.ValueObject = JsonConvert.DeserializeObject(entry.Item2.Valuestring, settings);
            }

            res.ValueMetaTypeString = entry.Item2.Metatypestring;
            res.ValueMetaTypeFullString = entry.Item2.Metatypelabel;

            if (entry.Item1.Categoryid.HasValue)
            {
                res.CategoryId = entry.Item1.Categoryid.Value;
            }

            return res;
        }

        public async Task<List<Genericattribute>> ListAttribute(int size = 10, int start = 0)
        {
            var utcNow = DateTime.UtcNow;

            var att1 = await _attributeRepository.DbSet
                .Include("Genericattributetype")
                .Include("Genericattributevalue")
                .Take(size)
                .Skip(start)
                .ToListAsync();

            return att1;
        }
    }
}
