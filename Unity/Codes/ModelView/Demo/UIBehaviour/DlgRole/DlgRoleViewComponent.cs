
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRoleViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.LoopHorizontalScrollRect E_LoopRoleLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LoopRoleLoopHorizontalScrollRect == null )
     			{
		    		this.m_E_LoopRoleLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"EGBackGround/E_LoopRole");
     			}
     			return this.m_E_LoopRoleLoopHorizontalScrollRect;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_RoleGroupToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleGroupToggleGroup == null )
     			{
		    		this.m_E_RoleGroupToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"EGBackGround/E_LoopRole/E_RoleGroup");
     			}
     			return this.m_E_RoleGroupToggleGroup;
     		}
     	}

		public UnityEngine.UI.InputField E_InputNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputNameInputField == null )
     			{
		    		this.m_E_InputNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EGBackGround/E_InputName");
     			}
     			return this.m_E_InputNameInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputNameImage == null )
     			{
		    		this.m_E_InputNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_InputName");
     			}
     			return this.m_E_InputNameImage;
     		}
     	}

		public UnityEngine.UI.Button E_DeleteRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DeleteRoleButton == null )
     			{
		    		this.m_E_DeleteRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_DeleteRole");
     			}
     			return this.m_E_DeleteRoleButton;
     		}
     	}

		public UnityEngine.UI.Image E_DeleteRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DeleteRoleImage == null )
     			{
		    		this.m_E_DeleteRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_DeleteRole");
     			}
     			return this.m_E_DeleteRoleImage;
     		}
     	}

		public UnityEngine.UI.Button E_CreateRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleButton == null )
     			{
		    		this.m_E_CreateRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_CreateRole");
     			}
     			return this.m_E_CreateRoleButton;
     		}
     	}

		public UnityEngine.UI.Image E_CreateRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleImage == null )
     			{
		    		this.m_E_CreateRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_CreateRole");
     			}
     			return this.m_E_CreateRoleImage;
     		}
     	}

		public UnityEngine.UI.Button E_GameStartButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GameStartButton == null )
     			{
		    		this.m_E_GameStartButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_GameStart");
     			}
     			return this.m_E_GameStartButton;
     		}
     	}

		public UnityEngine.UI.Image E_GameStartImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GameStartImage == null )
     			{
		    		this.m_E_GameStartImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_GameStart");
     			}
     			return this.m_E_GameStartImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_E_LoopRoleLoopHorizontalScrollRect = null;
			this.m_E_RoleGroupToggleGroup = null;
			this.m_E_InputNameInputField = null;
			this.m_E_InputNameImage = null;
			this.m_E_DeleteRoleButton = null;
			this.m_E_DeleteRoleImage = null;
			this.m_E_CreateRoleButton = null;
			this.m_E_CreateRoleImage = null;
			this.m_E_GameStartButton = null;
			this.m_E_GameStartImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_E_LoopRoleLoopHorizontalScrollRect = null;
		private UnityEngine.UI.ToggleGroup m_E_RoleGroupToggleGroup = null;
		private UnityEngine.UI.InputField m_E_InputNameInputField = null;
		private UnityEngine.UI.Image m_E_InputNameImage = null;
		private UnityEngine.UI.Button m_E_DeleteRoleButton = null;
		private UnityEngine.UI.Image m_E_DeleteRoleImage = null;
		private UnityEngine.UI.Button m_E_CreateRoleButton = null;
		private UnityEngine.UI.Image m_E_CreateRoleImage = null;
		private UnityEngine.UI.Button m_E_GameStartButton = null;
		private UnityEngine.UI.Image m_E_GameStartImage = null;
		public Transform uiTransform = null;
	}
}
