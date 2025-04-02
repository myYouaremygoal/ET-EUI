using System.Collections.Generic;

namespace ET
{
    [ChildType(null)]
    [ComponentOf(typeof(Scene))]
    public class ServerInfosComponent : Entity,IAwake,IDestroy
    {
        public List<ServerInfo> ServerInfoList = new List<ServerInfo>();

        public int CurrentServerId = 0;
    }
}