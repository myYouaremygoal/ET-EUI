namespace ET
{
    public class AccountSessionsComponentSystem : DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.AccountSessionsDictionary.Clear();
        }
    }
    
    [FriendClass(typeof(AccountSessionsComponent))]
    public static class AccountSessionComponentSystem
    {
        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            if (!self.AccountSessionsDictionary.TryGetValue(accountId,out long instanceId))
            {
                return 0;
            }
            return instanceId;
        }

        public static void Add(this AccountSessionsComponent self, long accountId, long sessionIntanceId)
        {
            if (self.AccountSessionsDictionary.ContainsKey(accountId))
            {
                self.AccountSessionsDictionary[accountId] = sessionIntanceId;
                return;
            }
            self.AccountSessionsDictionary.Add(accountId, sessionIntanceId);

        }

        public static void Remove(this AccountSessionsComponent self, long accountId)
        {
            if (self.AccountSessionsDictionary.ContainsKey(accountId))
            {
                self.AccountSessionsDictionary.Remove(accountId);   
            }
        }
    }
}