using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigCommon
{
    public class RequestConfig : ConfigBase
    {
        public string Url { get; set; }

        public int Timeout { get; set; }

        public string Browser { get; set; }

        public string Content { get; set; }

        public int ContentLength { get; set; }
    }
}
