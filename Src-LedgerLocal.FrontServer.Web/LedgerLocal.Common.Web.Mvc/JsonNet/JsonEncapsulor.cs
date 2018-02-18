using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Web.Mvc.JsonNet
{
    public class JsonEncapsulor<T>
    {
        public T Data { get; set; }

        public IList<T> DataList { get; set; }
    }
}
