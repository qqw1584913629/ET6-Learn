

namespace ET
{
	public static class SessionPlayerComponentSystem
	{
		public class SessionPlayerComponentDestroySystem: DestroySystem<SessionPlayerComponent>
		{
			public override void Destroy(SessionPlayerComponent self)
			{
                if (!self.isLoginAgain && self.PlayerInstanceId != 0)
                {
					// 发送断线消息
					ActorLocationSenderComponent.Instance.Send(self.PlayerId, new G2M_SessionDisconnect());
					self.Domain.GetComponent<PlayerComponent>()?.Remove(self.AccountId);
				}
				self.isLoginAgain = false;
				self.PlayerInstanceId = 0;
				self.PlayerId = 0;
				self.AccountId = 0;
			}
		}

		public static Player GetMyPlayer(this SessionPlayerComponent self)
		{
			return self.Domain.GetComponent<PlayerComponent>().Get(self.AccountId);
		}
	}
}
