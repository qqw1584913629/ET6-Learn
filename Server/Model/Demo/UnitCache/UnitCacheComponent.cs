using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class UnitCacheComponent:Entity, IAwake, IDestroy
    {
        public Dictionary<string, UnitCache> UnitCaches =  new Dictionary<string, UnitCache>();
        public List<string> UnitCacheNames = new List<string>();
    }
}
