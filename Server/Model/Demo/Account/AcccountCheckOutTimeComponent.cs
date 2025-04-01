namespace ET
{
    [ComponentOf(typeof(Session))]
    public class AcccountCheckOutTimeComponent : Entity,IAwake<long>,IDestroy
    {
        public long Timer = 0;
        public long AccountId = 0;
    }
}