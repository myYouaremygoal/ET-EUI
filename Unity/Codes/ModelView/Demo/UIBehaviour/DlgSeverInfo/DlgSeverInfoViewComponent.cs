
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgSeverInfoViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.LoopVerticalScrollRect ELoopSeverInfoListLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopSeverInfoListLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopSeverInfoListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EGBackGround/ELoopSeverInfoList");
     			}
     			return this.m_ELoopSeverInfoListLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_SeverGroupToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeverGroupToggleGroup == null )
     			{
		    		this.m_E_SeverGroupToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"EGBackGround/ELoopSeverInfoList/E_SeverGroup");
     			}
     			return this.m_E_SeverGroupToggleGroup;
     		}
     	}

		public UnityEngine.UI.Button E_SelectSeverInfoButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectSeverInfoButton == null )
     			{
		    		this.m_E_SelectSeverInfoButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_SelectSeverInfo");
     			}
     			return this.m_E_SelectSeverInfoButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectSeverInfoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectSeverInfoImage == null )
     			{
		    		this.m_E_SelectSeverInfoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_SelectSeverInfo");
     			}
     			return this.m_E_SelectSeverInfoImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_ELoopSeverInfoListLoopVerticalScrollRect = null;
			this.m_E_SeverGroupToggleGroup = null;
			this.m_E_SelectSeverInfoButton = null;
			this.m_E_SelectSeverInfoImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopSeverInfoListLoopVerticalScrollRect = null;
		private UnityEngine.UI.ToggleGroup m_E_SeverGroupToggleGroup = null;
		private UnityEngine.UI.Button m_E_SelectSeverInfoButton = null;
		private UnityEngine.UI.Image m_E_SelectSeverInfoImage = null;
		public Transform uiTransform = null;
	}
}
