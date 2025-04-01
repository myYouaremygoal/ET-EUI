namespace ET
{
    public class SeverInfoManagerComponentAwakeSystem: AwakeSystem<SeverInfoManagerComponent>
    {
        public override void Awake(SeverInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }

    public class SeverInfoManagerComponentDestroySystem: DestroySystem<SeverInfoManagerComponent>
    {
        public override void Destroy(SeverInfoManagerComponent self)
        {
            foreach (var serverInfo in self.ServerInfos)
            {
                serverInfo?.Dispose();
            }
            self.ServerInfos.Clear();
        }
    }

    public class SeverInfoManagerComponentLoadSystem: LoadSystem<SeverInfoManagerComponent>
    {
        public override void Load(SeverInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }


    [FriendClass(typeof(SeverInfoManagerComponent))]
    public static class SeverInfoManagerComponentSystem
    {
        public static async ETTask Awake(this  SeverInfoManagerComponent self)
        {
            var serverInfoList = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query<ServerInfo>(d => true);

            if (serverInfoList ==null || serverInfoList.Count <=0)
            {
                Log.Error("serverInfo count is zero");
                return;
            }
            self.ServerInfos.Clear();

            foreach (var serverInfo in serverInfoList)
            {
                self.AddChild(serverInfo);
                self.ServerInfos.Add(serverInfo);
                
            }
            
            await ETTask.CompletedTask;
        }
    }
}