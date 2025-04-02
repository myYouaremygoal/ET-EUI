
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_SeverInfo : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SeverInfo BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Toggle E_SeverSelectToggle
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
     				if( this.m_E_SeverSelectToggle == null )
     				{
		    			this.m_E_SeverSelectToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_SeverSelect");
     				}
     				return this.m_E_SeverSelectToggle;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_SeverSelect");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_SeverNameText
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
     				if( this.m_E_SeverNameText == null )
     				{
		    			this.m_E_SeverNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_SeverSelect/E_SeverName");
     				}
     				return this.m_E_SeverNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_SeverSelect/E_SeverName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_SeverSelectToggle = null;
			this.m_E_SeverNameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Toggle m_E_SeverSelectToggle = null;
		private UnityEngine.UI.Text m_E_SeverNameText = null;
		public Transform uiTransform = null;
	}
}
