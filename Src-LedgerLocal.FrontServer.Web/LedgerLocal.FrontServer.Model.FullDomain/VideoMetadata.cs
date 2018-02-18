using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.FrontServer.Model.FullDomain
{
    public class VideoMetadata
    {
        public string Filename { get; set; }

        public float Duration { get; set; }

        public long ContentLength { get; set; }

        public string MimeType { get; set; }
    }
}
