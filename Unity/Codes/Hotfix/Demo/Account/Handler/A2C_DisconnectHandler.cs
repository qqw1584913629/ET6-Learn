namespace ET
{
    public class A2C_DisconnectHandler : AMHandler<A2C_Disconnect>
    {
        protected override async ETTask Run(Session session, A2C_Disconnect message)
        {
            Log.Debug($"当前与服务器断开连接，连接错误码为: {message.Error}");
            await ETTask.CompletedTask;
        }
    }
}