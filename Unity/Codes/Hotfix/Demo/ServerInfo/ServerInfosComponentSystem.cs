namespace ET
{
    
    public class ServerInfosComponentDestroySystem : DestroySystem<ServerInfosComponent>
    {
        public override void Destroy(ServerInfosComponent self)
        {
            foreach (var serverInfo in self.ServerInfoList)
            {
                serverInfo?.Dispose();
            }
            self.ServerInfoList.Clear();

            self.CurrentServerId = 0;
        }
    }

    public static class ServerInfosComponentSystem
    {
        public static void Add(this ServerInfosComponent self, ServerInfo serverInfo)
        {
            self.ServerInfoList.Add(serverInfo);
        }
    }
}