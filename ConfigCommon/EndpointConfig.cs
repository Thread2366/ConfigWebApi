using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigCommon
{
    public class EndpointConfig : ConfigBase
    {
        public string Endpoint { get; set; }

        public int Timeout { get; set; }

        public bool IsRetry { get; set; }

        public int Attempts { get; set; }
    }
}
