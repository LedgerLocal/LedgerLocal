//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace LedgerLocal.Service.GrapheneLogic
//{
//    public class DictionaryTwoArrayConverter<T> : CustomCreationConverter<Dictionary<string, T>>
//        where T : class
//    {
//        public override Dictionary<string, T> Create(Type objectType)
//        {
//            return new Dictionary<string, T>();
//        }

//        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
//        {
//            var mappedObj = new Dictionary<string, T>();

//            var resultObject = serializer.Deserialize<object[]>(reader);

//            mappedObj.Add(resultObject[0].ToString(), resultObject[1] as T);

//            return mappedObj;
//        }
//    }
//}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic
{
    public class DictionaryTwoArrayConverter<T> : CustomCreationConverter<Dictionary<string, T>>
        where T : class
    {
        private IList<JsonConverter> _convertors;

        public DictionaryTwoArrayConverter(IList<JsonConverter> conv)
        {
            _convertors = conv;
        }

        public override Dictionary<string, T> Create(Type objectType)
        {
            return new Dictionary<string, T>();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var mappedObj = new Dictionary<string, T>();

            var resultObject = serializer.Deserialize<object[]>(reader);

            var jsonObj = JsonConvert.SerializeObject(resultObject[1]);

            mappedObj.Add(resultObject[0].ToString(), JsonConvert.DeserializeObject<T>(jsonObj, _convertors.ToArray()));

            return mappedObj;
        }
    }
}
