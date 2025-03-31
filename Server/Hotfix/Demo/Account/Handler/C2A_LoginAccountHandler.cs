using System;
using System.Text.RegularExpressions;

namespace ET
{
    [FriendClass(typeof(Account))]
    public class C2A_LoginAccountHandler: AMRpcHandler<C2A_LoginAccount,A2C_LoginAccount>
    {
        protected override async ETTask Run(Session session, C2A_LoginAccount request, A2C_LoginAccount response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误，当前Scene 为：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }
            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            if (session.GetComponent<SessionLockingComponent>()!=null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                session.Disconnect().Coroutine();
                return;
            }
            
            // 判断账号密码不能为空
            if (string.IsNullOrEmpty(request.AccountName)|| string.IsNullOrEmpty(request.PassWord))
            {
                response.Error = ErrorCode.ERR_LoginInfoIsNull;
                reply();
                session.Disconnect().Coroutine();  
                return ;
            }
            //正则判断 账号至少有数字和大小字母组成长度6 -15
            if (Regex.IsMatch(request.AccountName.Trim(),@"^(?=.*[0-9.*])(?=.*[A-Z].*)(?=.*[a-z].*).{6,15}$"))
            {
                response.Error = ErrorCode.ERR_AccountNameFormError;
                reply();
                session.Disconnect().Coroutine();  
                return;
            }
            if (Regex.IsMatch(request.PassWord.Trim(),@"^(?=.*[0-9.*])(?=.*[A-Z].*)(?=.*[a-z].*).{6,15}$"))
            {
                response.Error = ErrorCode.ERR_PasswordFormError;
                reply();
                session.Disconnect().Coroutine();  
                return;
            }

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount,request.AccountName.Trim().GetHashCode()))
                {
                    var accountInfoList = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Query<Account>(d =>  d.AccountName.Equals((request.AccountName.Trim())));
     
                    Account account = null;
                    if (accountInfoList!=null && accountInfoList.Count > 0)
                    {
                        account = accountInfoList[0];
                        session.AddChild(account);
                        if (account.AccountType == (int)AccountType.BlackList)
                        {
                            response.Error = ErrorCode.ERR_AccountInBlackListError;
                            reply();
                            session.Disconnect().Coroutine();  
                            session?.Dispose();
                            return;
                        }

                        if (!account.Password.Equals(request.PassWord))
                        {
                            response.Error = ErrorCode.ERR_LoginPasswordError;
                            reply(); 
                            session.Disconnect().Coroutine();  
                            session?.Dispose();
                            return;
                        }
                    }
                    else
                    {
                        account = session.AddChild<Account>();
                        account.AccountName  =request.AccountName.Trim();
                        account.Password = request.PassWord;
                        account.CreateTime = TimeHelper.ServerNow();
                        account.AccountType = (int)AccountType.General;
                        await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<Account>(account);
                    }
                    string Token = TimeHelper.ServerNow().ToString()+ RandomHelper.RandomNumber(int.MaxValue,int.MaxValue).ToString();
                    session.DomainScene().GetComponent<TokenComponent>().Remove(account.Id);
                    session.DomainScene().GetComponent<TokenComponent>().Add(account.Id, Token);
                        
                    response.AccountId = account.Id;
                    response.Token = Token;
                
                    reply();
                    session?.Dispose();
                }
            }
            
            
            
        }
    }
}