namespace ET
{
    public enum RoleInfoState
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 冻结
        /// </summary>
        Freeze,
    }

    public class RoleInfo : Entity,IAwake
    {
        public string Name;
        public int ServerId;
        public int State;
        public long AccountId;
        
        public long LastLoginTime;
        
        public long CreateTime;

    }
}