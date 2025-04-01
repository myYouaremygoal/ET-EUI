using System.Collections.Generic;

namespace ET
{
    [ChildType(null)]
    [ComponentOf(typeof(Scene))]
    public class SeverInfoManagerComponent : Entity ,IAwake,IDestroy,ILoad
    {
         public List<ServerInfo> ServerInfos = new List<ServerInfo>();
     }
}