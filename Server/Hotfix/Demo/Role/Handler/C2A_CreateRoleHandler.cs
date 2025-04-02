using System;

namespace ET
{
    [FriendClass(typeof(RoleInfo))]
    public class C2A_CreateRoleHandler : AMRpcHandler<C2A_CreateRole, A2C_CreateRole>
    {
        protected override async ETTask Run(Session session, C2A_CreateRole request, A2C_CreateRole response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求错误Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            //请求过于频繁判断
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                session.Disconnect().Coroutine();
                return;
            }
            
            
            string token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccontId);

            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                response.Error = ErrorCode.ERR_RoleNameIsNull;
                reply();
                return;
            }

            //添加过于频繁锁
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRole,request.AccontId))
                {
                    var roleInfo = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Query<RoleInfo>(d => d.Name==request.Name && d.ServerId == request.ServerId);

                    if (roleInfo !=null && roleInfo.Count>0)
                    {
                        response.Error = ErrorCode.ERR_RoleNameSame;
                        reply();
                        return;
                    }

                    RoleInfo newRoleInfo = session.AddChildWithId<RoleInfo>(IdGenerater.Instance.GenerateUnitId(request.ServerId));
                    newRoleInfo.Name = request.Name;
                    newRoleInfo.ServerId = request.ServerId;
                    newRoleInfo.State = (int)RoleInfoState.Normal;
                    newRoleInfo.AccountId = request.AccontId;
                    newRoleInfo.CreateTime = TimeHelper.ServerNow();
                    newRoleInfo.LastLoginTime = 0;

                    await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<RoleInfo>(newRoleInfo);
                
                    response.RoleInfo = newRoleInfo.ToMessage();
                
                    reply();
                
                    newRoleInfo.Dispose(); 
                
                }
            }
            
           
            
            await ETTask.CompletedTask;
        }
    }
    
}