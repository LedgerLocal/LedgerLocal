using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service.KafkaMessager
{
    public class SerializationHelper
    {
        //public static object Deserialize<T>(string value)
        //{
        //    if (typeof(T) == typeof(byte[]))
        //    {
        //        return Convert.FromBase64String(value);
        //    }

        //    return JsonConvert.DeserializeObject<T>(value);
        //}

        //public static string Serialize<T>(object value)
        //{
        //    if (typeof(T) == typeof(byte[]))
        //    {
        //        return Convert.ToBase64String((byte[])value);
        //    }

        //    return JsonConvert.SerializeObject(value);
        //}
    }
}
