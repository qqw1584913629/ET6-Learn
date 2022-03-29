using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class O2U_AddOrUpdateUnitHandler : AMActorRpcHandler<Scene, O2U_AddOrUpdateUnit, U2O_AddOrUpdateUnit>
    {
        protected override async ETTask Run(Scene scene, O2U_AddOrUpdateUnit request, U2O_AddOrUpdateUnit response, Action reply)
        {
            //UpdateUnitCacheAsync(scene, request, response).Coroutine();
            reply();
            await ETTask.CompletedTask;
        }
        //public async ETTask UpdateUnitCacheAsync(Scene scene, O2U_AddOrUpdateUnit request, U2O_AddOrUpdateUnit response)
        //{
        //    UnitCacheComponent unitCacheComponent = scene.GetComponent<UnitCacheComponent>();
        //    using (ListComponent<Entity> entityList = ListComponent<Entity>.Create())
        //    {
        //        for (int index = 0; index < request.EntityTypes.Count; index++)
        //        {
        //            Type type = Game.EventSystem.GetType(request.EntityTypes[index]);
        //            Entity entity = (Entity)MongoHelper.FromBson(type, request.EntityBytes[index]);
        //            entityList.Add(entity);
        //        }
        //        //await unitCacheComponent.AddOrUpdate();
        //    }
        //}
    }
}
