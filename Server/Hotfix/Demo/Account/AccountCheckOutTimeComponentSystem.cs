using System;

namespace ET
{
    [Timer(TimerType.AccountSessionCheckOutTime)]
    public class AcctountSessionCheckOutTimer: ATimer<AcccountCheckOutTimeComponent>
    {
        public override void Run(AcccountCheckOutTimeComponent self)
        {
            try
            {
                self.DeleteSession();
            }
            catch (Exception e)
            {
                 Log.Error(e.ToString());
            }
        }
    }
  
    public class AccountCheckOutTimeComponentAwakeSystem : AwakeSystem<AcccountCheckOutTimeComponent,long>
    {
        public override void Awake(AcccountCheckOutTimeComponent self, long accountId)
        {
            self.AccountId = accountId;
            TimerComponent.Instance.Remove(ref self.Timer);
            self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 60000, TimerType.AccountSessionCheckOutTime, self);
        }
    }

    public class AccountCheckOutTimeComponentDestroySystem: DestroySystem<AcccountCheckOutTimeComponent>
    {
        public override void Destroy(AcccountCheckOutTimeComponent self)
        {
            self.AccountId = 0;
            TimerComponent.Instance.Remove(ref self.Timer);
        }
    }

    [FriendClass(typeof(AcccountCheckOutTimeComponent))]
    public static class AccountCheckOutTimeComponentSystem
    {
        public static void DeleteSession(this AcccountCheckOutTimeComponent self)
        {
            Session session = self.GetParent<Session>();
            long sessionInstanceId = session.DomainScene().GetComponent<AccountSessionsComponent>().Get(self.AccountId);
            if (session.InstanceId == sessionInstanceId)
            {
                session.DomainScene().GetComponent<AccountSessionsComponent>().Remove(self.AccountId);
            }
            
            session?.Send(new A2C_Disconnect{Error = 1});
            session?.Disconnect().Coroutine();  
        }
    }
}