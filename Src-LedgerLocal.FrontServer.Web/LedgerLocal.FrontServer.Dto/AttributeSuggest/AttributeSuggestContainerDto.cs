using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Dto.AttributeSuggest
{
    public class AttributeSuggestContainerDto
    {
        public IList<AttributeSuggestDto> Results { get; set; }

        public int Skip { get; set; }

        public int Count { get; set; }
    }
}
