using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic
{
    public class Numeric
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        static public string SerialisedDecimal(decimal d)
        {
            return d.ToString("0.##########");
        }
    }
}
