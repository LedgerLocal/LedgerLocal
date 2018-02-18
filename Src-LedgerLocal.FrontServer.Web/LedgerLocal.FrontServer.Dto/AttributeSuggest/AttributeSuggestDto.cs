using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Dto.AttributeSuggest
{
    public class AttributeSuggestDto
    {
        public AttributeSuggestAttributeTypeDto Type { get; set; }

        public IList<AttributeSuggestAttributeItemDto> Items { get; set; }

        public int LinkedProductScore { get; set; }

        public int PresenceAttributeScore { get; set; }

        public int LinkedCategoryScore { get; set; }
    }
}
