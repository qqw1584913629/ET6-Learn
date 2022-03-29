using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class UnitCacheComponentSystem
    {
        public static async ETTask AddOrUpdate(this UnitCacheComponent self, long unitId, ListComponent<Entity> entitys)
        {
            using (ListComponent<Entity> lists = ListComponent<Entity>.Create())
            {
                foreach (Entity entity in entitys)
                {
                    string key = entity.GetType().Name;
                    if (!self.UnitCaches.TryGetValue(key, out UnitCache unitCache))
                    {
                        unitCache = self.AddChild<UnitCache>();
                        unitCache.key = key;
                        self.UnitCaches.Add(key, unitCache);
                    }
                    unitCache.AddOrUpdate(entity);
                    lists.Add(entity);

                    if (lists.Count > 0)
                    {
                        await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(unitId, lists);
                    }
                }
            }
        }
    }
}
