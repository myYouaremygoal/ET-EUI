
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgTestViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EGBackGroundRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGBackGroundRectTransform == null )
     			{
		    		this.m_EGBackGroundRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround");
     			}
     			return this.m_EGBackGroundRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_EnterMapButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapButton == null )
     			{
		    		this.m_E_EnterMapButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_EnterMap");
     			}
     			return this.m_E_EnterMapButton;
     		}
     	}

		public UnityEngine.UI.Image E_EnterMapImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapImage == null )
     			{
		    		this.m_E_EnterMapImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_EnterMap");
     			}
     			return this.m_E_EnterMapImage;
     		}
     	}

		public UnityEngine.UI.Button E_TestButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TestButton == null )
     			{
		    		this.m_E_TestButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Test");
     			}
     			return this.m_E_TestButton;
     		}
     	}

		public UnityEngine.UI.Image E_TestImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TestImage == null )
     			{
		    		this.m_E_TestImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Test");
     			}
     			return this.m_E_TestImage;
     		}
     	}

		public UnityEngine.UI.Text E_TestTxtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TestTxtText == null )
     			{
		    		this.m_E_TestTxtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/E_TestTxt");
     			}
     			return this.m_E_TestTxtText;
     		}
     	}

		public ESCommonUItest ESCommonUItest
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_escommonuitest == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EGBackGround/ESCommonUItest");
		    	   this.m_escommonuitest = this.AddChild<ESCommonUItest,Transform>(subTrans);
     			}
     			return this.m_escommonuitest;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_E_EnterMapButton = null;
			this.m_E_EnterMapImage = null;
			this.m_E_TestButton = null;
			this.m_E_TestImage = null;
			this.m_E_TestTxtText = null;
			this.m_escommonuitest?.Dispose();
			this.m_escommonuitest = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Button m_E_EnterMapButton = null;
		private UnityEngine.UI.Image m_E_EnterMapImage = null;
		private UnityEngine.UI.Button m_E_TestButton = null;
		private UnityEngine.UI.Image m_E_TestImage = null;
		private UnityEngine.UI.Text m_E_TestTxtText = null;
		private ESCommonUItest m_escommonuitest = null;
		public Transform uiTransform = null;
	}
}
