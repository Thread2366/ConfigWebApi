using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigCommon
{
    public interface IConfigRepository<TConfig> 
        where TConfig : ConfigBase
    {
        TConfig FindByName(string name);

        void Update(string name, TConfig config);
    }
}
