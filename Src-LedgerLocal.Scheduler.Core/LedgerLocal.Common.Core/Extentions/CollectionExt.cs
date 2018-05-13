using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.Common.Core.Extentions
{
    public static class CollectionExt
    {
        public static TSource RiaFirst<TSource>(this ICollection<TSource> source)
        {
            return source.First();
        }
    }
}
