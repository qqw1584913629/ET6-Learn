using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class UnitCacheHelper
    {
        /// <summary>
        /// Use in add or update player cache data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static async ETTask AddOrUpdateUnitCache<T>(this T self) where T : Entity, IUnitCache
        {
            O2U_AddOrUpdateUnit o2U_AddOrUpdateUnit = new O2U_AddOrUpdateUnit() { UnitId = self.Id};// request info
            o2U_AddOrUpdateUnit.EntityTypes.Add(typeof(T).FullName);
            o2U_AddOrUpdateUnit.EntityBytes.Add(MongoHelper.ToBson(self));
            //Actor message parameter need a address, so we need get cache scenetype address
            await MessageHelper.CallActor(StartSceneConfigCategory.Instance.GetUnitCacheConfig(self.Id).InstanceId, o2U_AddOrUpdateUnit);
        }

        //get player cache data
        //public static async ETTask<Unit> GetUnitCache(Scene scene, long unitId)
        //{
        //}

        /// <summary>
        /// Get belong in Player of Component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public static async ETTask<T> GetUnitComponentCache<T>(long unitId) where T : Entity, IUnitCache
        {
            O2U_GetUnit o2U_GetUnit = new O2U_GetUnit() { UnitId = unitId };
            o2U_GetUnit.ComponentNameList.Add(typeof(T).Name);
            long instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
            U2O_GetUnit u2O_GetUnit = (U2O_GetUnit)await MessageHelper.CallActor(instanceId, o2U_GetUnit);
            if (u2O_GetUnit.Error == ErrorCode.ERR_Success && u2O_GetUnit.EntityList.Count > 0)
            {
                return u2O_GetUnit.EntityList[0] as T;
            }
            return null;
        }

        /// <summary>
        /// Delete player cache data
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public static async ETTask DeleteUnitCache(long unitId)
        {
            O2U_DeleteUnit o2U_DeleteUnit = new O2U_DeleteUnit() { UnitId = unitId };
            long instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
            await MessageHelper.CallActor(instanceId, o2U_DeleteUnit);
        }
    }
}
