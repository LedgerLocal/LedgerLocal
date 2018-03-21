using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.FrontServer.Dto
{
    public class ImageDto : GenericDto
    {


        public int Imageid { get; set; }
        public int? Imagetypeid { get; set; }
        public string Thumburl { get; set; }
        public string Fullimageurl { get; set; }
        public bool Active { get; set; }


    }
}
