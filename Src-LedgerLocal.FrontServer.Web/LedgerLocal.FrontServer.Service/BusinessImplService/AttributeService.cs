using LedgerLocal.FrontServer.Data.FullDomain.Infrastructure;
using LedgerLocal.FrontServer.Enum;
using LedgerLocal.FrontServer.Model.FullDomain;
using LedgerLocal.FrontServer.Model.FullDomain.Model;
using LedgerLocal.FrontServer.Service.Contract;
using LedgerLocal.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using LedgerLocal.FrontServer.Service.Json;
using System.Threading.Tasks;
using LedgerLocal.FrontServer.Data.FullDomain.Bulk;
using Microsoft.Extensions.Logging;

namespace LedgerLocal.FrontServer.Service.PersistenceService
{
    public class AttributeService : IAttributeService
    {
        private readonly ILedgerLocalDbFullDomainRepository<GenericAttribute> _attributeRepository;
        private readonly ILedgerLocalDbFullDomainRepository<GenericAttributeValue> _attributeValueRepository;
        private readonly ILedgerLocalDbFullDomainRepository<GenericAttributeType> _attributeTypeRepository;
        private readonly ILedgerLocalDbFullDomainUnitOfWork _unitOfWork;
        private readonly ILedgerLocalBulkOperator _LedgerLocalBulkOperator;

        private readonly ILogger<AttributeService> _logger;

        public AttributeService(ILogger<AttributeService> logger, 
            ILedgerLocalDbFullDomainRepository<GenericAttribute> attributeRepository,
            ILedgerLocalDbFullDomainRepository<GenericAttributeValue> attributeValueRepository,
            ILedgerLocalDbFullDomainRepository<GenericAttributeType> attributeTypeRepository,
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

        public async Task<Tuple<string, IList<GenericAttribute>>> CreateAttributeBulk(IList<AttributeBulk> attributesCreates)
        {
            StringBuilder logger = new StringBuilder();

            Check.Require(attributesCreates != null, "attributesCreates must be supplied.");

            var utcNow = DateTime.UtcNow;

            var lstTuple = new List<Tuple<GenericAttributeType, GenericAttributeValue>>();

            var attributeTypeRepositoryLocal = (ILedgerLocalDbFullDomainRepository<GenericAttributeType>)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(ILedgerLocalDbFullDomainRepository<GenericAttributeType>));
            var maxGaType = attributeTypeRepositoryLocal.DbSet.Max(x => x.GenericAttributeTypeId);
            var attributeValueRepositoryLocal = (ILedgerLocalDbFullDomainRepository<GenericAttributeValue>)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(ILedgerLocalDbFullDomainRepository<GenericAttributeValue>));
            var maxGaValue = attributeValueRepositoryLocal.DbSet.Max(x => x.GenericAttributeValueId);

            foreach (var a1 in attributesCreates)
            {
                maxGaType = maxGaType + 1;
                maxGaValue = maxGaValue + 1;

                var t1 = CreateBulkTupleTypeValue(a1);

                t1.Item1.GenericAttributeTypeId = maxGaType;
                t1.Item2.GenericAttributeValueId = maxGaValue;

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
            await LedgerLocalBulkOperatorLocal1.BulkInsertBulkCopy<GenericAttributeType>(lstTypes, tuple1, "[System].[GenericAttributeType]", 1000);

            logger.AppendLine(string.Format("GenericAttributeType Bulked: {0} rows", lstTypes.Count));

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
            await LedgerLocalBulkOperatorLocal2.BulkInsertBulkCopy<GenericAttributeValue>(lstValues, tuple2, "[System].[GenericAttributeValue]", 1000);

            logger.AppendLine(string.Format("GenericAttributeValue Bulked: {0} rows", lstValues.Count));

            var lstAttributes = new List<GenericAttribute>();

            var ix1 = 0;
            var attributeRepositoryLocal = (ILedgerLocalDbFullDomainRepository<GenericAttribute>)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(ILedgerLocalDbFullDomainRepository<GenericAttribute>));
            var maxGAttribute = attributeRepositoryLocal.DbSet.Max(x => x.GenericAttributeId);

            foreach (var t1 in lstTuple)
            {
                maxGAttribute = maxGAttribute + 1;

                var attribute = new GenericAttribute();
                attribute.GenericAttributeId = maxGAttribute;
                attribute.GenericAttributeTypeId = t1.Item1.GenericAttributeTypeId;
                attribute.GenericAttributeValueId = t1.Item2.GenericAttributeValueId;

                attribute.TypeString = attributesCreates[ix1].Type;
                attribute.ValueString = attributesCreates[ix1].Value;

                attribute.CreatedOn = utcNow;
                attribute.ModifiedOn = utcNow;
                attribute.CreatedBy = "System";
                attribute.ModifiedBy = "System";

                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All,
                };

                settings.Converters.Insert(0, new PrimitiveJsonConverter());

                if (attributesCreates[ix1].TypeObject != null)
                {
                    attribute.TypeLabelString = JsonConvert.SerializeObject(attributesCreates[ix1].TypeObject, settings);
                }
                else
                {
                    attribute.TypeLabelString = EncodeLabel(attributesCreates[ix1].Type);
                }

                if (attributesCreates[ix1].ValueObject != null)
                {
                    attribute.ValueLabelString = JsonConvert.SerializeObject(attributesCreates[ix1].ValueObject, settings);
                }
                else
                {
                    attribute.ValueLabelString = EncodeLabel(attributesCreates[ix1].Value);
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
            await LedgerLocalBulkOperatorLocal3.BulkInsertBulkCopy<GenericAttribute>(lstAttributes, tuple3, "[System].[GenericAttribute]", 1000);

            logger.AppendLine(string.Format("GenericAttribute Bulked: {0} rows", lstAttributes.Count));

            return new Tuple<string, IList<GenericAttribute>>(logger.ToString(), lstAttributes);
        }

        public async Task<GenericAttribute> CreateOrGetAttribute(
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

            var findAttribute = _attributeRepository.DbSet.FirstOrDefault(x => x.GenericAttributeTypeId == tupleTypeValue.Item1.GenericAttributeTypeId
                && x.GenericAttributeValueId == tupleTypeValue.Item2.GenericAttributeValueId);

            if (findAttribute != null)
            {
                return findAttribute;
            }

            var attribute = new GenericAttribute();
            attribute.GenericAttributeTypeId = tupleTypeValue.Item1.GenericAttributeTypeId;
            attribute.GenericAttributeValueId = tupleTypeValue.Item2.GenericAttributeValueId;

            attribute.TypeString = type;
            attribute.ValueString = value;

            attribute.CreatedOn = utcNow;
            attribute.ModifiedOn = utcNow;
            attribute.CreatedBy = "System";
            attribute.ModifiedBy = "System";

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            settings.Converters.Insert(0, new PrimitiveJsonConverter());

            if (typeObject != null)
            {
                attribute.TypeLabelString = JsonConvert.SerializeObject(typeObject, settings);
            }
            else
            {
                attribute.TypeLabelString = EncodeLabel(type);
            }

            if (valueObject != null)
            {
                attribute.ValueLabelString = JsonConvert.SerializeObject(valueObject, settings);
            }
            else
            {
                attribute.ValueLabelString = EncodeLabel(value);
            }

            await _attributeRepository.AddAsync(attribute);
            var error1 = _unitOfWork.CommitHandled();
            if (!error1)
            {
                _logger.LogError($"Can't Attribute ! {JsonConvert.SerializeObject(attribute, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
            }

            return attribute;
        }

        public GenericAttributeType GetAttributeType(string type, object typeObject = null, int? categoryId = null)
        {
            Check.Require(!string.IsNullOrWhiteSpace(type), "type must be valid.");

            var encodedLabel = EncodeLabel(type);

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            settings.Converters.Insert(0, new PrimitiveJsonConverter());

            GenericAttributeType foundEntity = null;

            if (typeObject != null)
            {
                var jsonObj = JsonConvert.SerializeObject(typeObject, settings);
                var found = _attributeTypeRepository.DbSet.FirstOrDefault(x =>
                    string.Compare(x.Name, type, true) == 0
                    && string.Compare(x.ValueString, jsonObj, true) == 0
                    && x.CategoryId == categoryId);
                foundEntity = found;
            }
            else
            {
                var found2 = _attributeTypeRepository.DbSet.FirstOrDefault(x =>
                    string.Compare(x.Name, type, true) == 0
                    && x.CategoryId == categoryId);
                foundEntity = found2;
            }

            return foundEntity;
        }

        public GenericAttributeValue GetValue(string value, object valueObject = null)
        {
            Check.Require(!string.IsNullOrWhiteSpace(value), "value must be valid.");

            var encodedLabel = EncodeLabel(value);

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            settings.Converters.Insert(0, new PrimitiveJsonConverter());

            GenericAttributeValue foundEntity = null;

            if (valueObject != null)
            {
                var jsonObj = JsonConvert.SerializeObject(valueObject, settings);
                var found = _attributeValueRepository.DbSet.FirstOrDefault(x =>
                    string.Compare(x.Name, value, true) == 0
                    && string.Compare(x.ValueString, jsonObj, true) == 0);
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

        private Tuple<GenericAttributeType, GenericAttributeValue> CreateBulkTupleTypeValue(
            AttributeBulk bulkInfo)
        {
            var utcNow = DateTime.UtcNow;

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            settings.Converters.Insert(0, new PrimitiveJsonConverter());


            var typeEntity = new GenericAttributeType();
            var valueEntity = new GenericAttributeValue();

            typeEntity.CreatedOn = utcNow;
            typeEntity.ModifiedOn = utcNow;
            typeEntity.CreatedBy = "System";
            typeEntity.ModifiedBy = "System";

            valueEntity.CreatedOn = utcNow;
            valueEntity.ModifiedOn = utcNow;
            valueEntity.CreatedBy = "System";
            valueEntity.ModifiedBy = "System";

            typeEntity.Sort = bulkInfo.TypeSort;
            valueEntity.Sort = bulkInfo.ValueSort;

            typeEntity.Name = bulkInfo.Type;

            if (bulkInfo.CategoryId.HasValue)
            {
                typeEntity.CategoryId = bulkInfo.CategoryId.Value;
            }

            if (bulkInfo.TypeObject != null)
            {
                var typeObjectJson = JsonConvert.SerializeObject(bulkInfo.TypeObject, settings);
                typeEntity.ValueString = typeObjectJson;

                typeEntity.MetaTypeString = bulkInfo.TypeObject.GetType().Name;
                typeEntity.MetaTypeLabel = bulkInfo.TypeObject.GetType().AssemblyQualifiedName;
            }

            valueEntity.Name = bulkInfo.Value;

            if (bulkInfo.ValueObject != null)
            {
                var valueObjectJson = JsonConvert.SerializeObject(bulkInfo.ValueObject, settings);
                valueEntity.ValueString = valueObjectJson;

                valueEntity.MetaTypeString = bulkInfo.ValueObject.GetType().Name;
                valueEntity.MetaTypeLabel = bulkInfo.ValueObject.GetType().AssemblyQualifiedName;
            }

            GenericAttributeType finalType;
            GenericAttributeValue finalValue;
            
            finalType = typeEntity;

            finalValue = valueEntity;

            var resTuple = new Tuple<GenericAttributeType, GenericAttributeValue>(finalType, finalValue);

            return resTuple;
        }

        private async Task<Tuple<GenericAttributeType, GenericAttributeValue>> CreateOrGetTupleTypeValue (
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


            var typeEntity = new GenericAttributeType();
            var valueEntity = new GenericAttributeValue();

            typeEntity.CreatedOn = utcNow;
            typeEntity.ModifiedOn = utcNow;
            typeEntity.CreatedBy = "System";
            typeEntity.ModifiedBy = "System";

            valueEntity.CreatedOn = utcNow;
            valueEntity.ModifiedOn = utcNow;
            valueEntity.CreatedBy = "System";
            valueEntity.ModifiedBy = "System";

            typeEntity.Sort = typeSort;
            valueEntity.Sort = valueSort;

            typeEntity.Name = type;

            if (categoryId.HasValue)
            {
                typeEntity.CategoryId = categoryId.Value;
            }

            if (typeObject != null)
            {
                var typeObjectJson = JsonConvert.SerializeObject(typeObject, settings);
                typeEntity.ValueString = typeObjectJson;

                typeEntity.MetaTypeString = typeObject.GetType().Name;
                typeEntity.MetaTypeLabel = typeObject.GetType().AssemblyQualifiedName;
            }

            valueEntity.Name = value;

            if (valueObject != null)
            {
                var valueObjectJson = JsonConvert.SerializeObject(valueObject, settings);
                valueEntity.ValueString = valueObjectJson;

                valueEntity.MetaTypeString = valueObject.GetType().Name;
                valueEntity.MetaTypeLabel = valueObject.GetType().AssemblyQualifiedName;
            }

            GenericAttributeType finalType;
            GenericAttributeValue finalValue;

            var findType = _attributeTypeRepository.DbSet.FirstOrDefault(
                x => x.CategoryId == typeEntity.CategoryId
                    && x.Name == typeEntity.Name
                    && x.ValueString == typeEntity.ValueString
                    && x.MetaTypeString == typeEntity.MetaTypeString
                    && x.MetaTypeLabel == typeEntity.MetaTypeLabel);

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
                    && x.ValueString == valueEntity.ValueString
                    && x.MetaTypeString == valueEntity.MetaTypeString
                    && x.MetaTypeLabel == valueEntity.MetaTypeLabel);

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

            var resTuple = new Tuple<GenericAttributeType, GenericAttributeValue>(finalType, finalValue);

            return resTuple;
        }

        private AttributeEntityObject DeserializeFromTuple(Tuple<GenericAttributeType, GenericAttributeValue> entry)
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

            if (!string.IsNullOrWhiteSpace(entry.Item1.ValueString))
            {
                res.TypeObject = JsonConvert.DeserializeObject(entry.Item1.ValueString, settings);
            }

            res.TypeMetaTypeString = entry.Item1.MetaTypeString;
            res.TypeMetaTypeFullString = entry.Item1.MetaTypeLabel;

            res.Value = entry.Item2.Name;
            res.ValueSort = entry.Item2.Sort;

            if (!string.IsNullOrWhiteSpace(entry.Item2.ValueString))
            {
                res.ValueObject = JsonConvert.DeserializeObject(entry.Item2.ValueString, settings);
            }

            res.ValueMetaTypeString = entry.Item2.MetaTypeString;
            res.ValueMetaTypeFullString = entry.Item2.MetaTypeLabel;

            if (entry.Item1.CategoryId.HasValue)
            {
                res.CategoryId = entry.Item1.CategoryId.Value;
            }

            return res;
        }
    }
}
