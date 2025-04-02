
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_RoleInfo : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_RoleInfo BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Toggle E_tglSelectToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_tglSelectToggle == null )
     				{
		    			this.m_E_tglSelectToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_tglSelect");
     				}
     				return this.m_E_tglSelectToggle;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_tglSelect");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_RoleNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_RoleNameText == null )
     				{
		    			this.m_E_RoleNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_tglSelect/E_RoleName");
     				}
     				return this.m_E_RoleNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_tglSelect/E_RoleName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_tglSelectToggle = null;
			this.m_E_RoleNameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Toggle m_E_tglSelectToggle = null;
		private UnityEngine.UI.Text m_E_RoleNameText = null;
		public Transform uiTransform = null;
	}
}
