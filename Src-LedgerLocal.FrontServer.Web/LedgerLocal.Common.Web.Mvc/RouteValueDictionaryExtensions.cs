//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web.Routing;
//using Common.Core;

//namespace Common.Web.Mvc
//{
//    public static class RouteValueDictionaryExtensions
//    {
//        /// <summary>
//        /// Fixes a RouteValueDictionary when there's a string array in its parameters.
//        /// When encountering this, fixes the dictionary in order to have
//        /// entry[0] = ..
//        /// entry[1] = ..
//        /// 
//        /// instead of String[]
//        /// </summary>
//        /// <param name="routes"></param>
//        /// <returns></returns>
//        public static RouteValueDictionary FixListRouteDataValues(this RouteValueDictionary routes)
//        {
//            var newRv = new RouteValueDictionary();
//            foreach (var key in routes.Keys)
//            {
//                object value = routes[key];

//                var str_array = value as IEnumerable<string>;

//                if (str_array != null)
//                {

//                    var nonNullElements =
//                    (
//                        from str in str_array
//                        where !String.IsNullOrEmpty(str)
//                        select str
//                    );

//                    nonNullElements.ForEachIndexed
//                    (
//                        (val, index) =>
//                        {
//                            newRv.Add(string.Format("{0}[{1}]", key, index), val);
//                        }
//                    );
//                }
//                else
//                {
//                    newRv.Add(key, value);
//                }
//            }

//            return newRv;
//        }
//    }
//}
