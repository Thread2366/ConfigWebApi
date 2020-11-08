using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ConfigWebApi
{
    public class ConfigException : Exception
    {
        public ConfigException()
        {
        }

        public ConfigException(string message) : base(message)
        {
        }

        public ConfigException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConfigException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
