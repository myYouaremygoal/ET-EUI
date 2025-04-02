using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(RoleInfoComponent))]
	[FriendClass(typeof(RoleInfo))]
	[FriendClass(typeof(DlgRole))]
	public static  class DlgRoleSystem
	{

		public static void RegisterUIEvent(this DlgRole self)
		{
			self.View.E_LoopRoleLoopHorizontalScrollRect.AddItemRefreshListener(((transform, Index) =>
			{
				self.OnLoopListRefreshHandler(transform, Index);
			   
			}));
			self.View.E_GameStartButton.AddListenerAsync(() =>
			{
				return  self.OnGameStartHandler();
			});
			
			self.View.E_CreateRoleButton.AddListenerAsync(() => { return self.OnCreateRoleButtonHandler();});
		}

		public static void ShowWindow(this DlgRole self, Entity contextData = null)
		{
			self.RefreshRoleItems();
		}

		public static void RefreshRoleItems(this DlgRole self)
		{
			int count =self.ZoneScene().GetComponent<RoleInfoComponent>().RoleInfos.Count;
			Log.Debug($"角色数量 ：{count}");
			self.AddUIScrollItems(ref self.ScrollItemRoleInfos,count);
			self.View.E_RoleGroupToggleGroup.allowSwitchOff = false;
			self.View.E_RoleGroupToggleGroup.EnsureValidState();
			self.View.E_LoopRoleLoopHorizontalScrollRect.SetVisible(true, count);
		}

		public static void OnLoopListRefreshHandler(this DlgRole self, Transform transform, int index)
		{
			Scroll_Item_RoleInfo scrollItemRoleInfo = self.ScrollItemRoleInfos[index];
			
			var roleInfo = self.ZoneScene().GetComponent<RoleInfoComponent>().RoleInfos[index];
			scrollItemRoleInfo.E_RoleNameText.text = roleInfo.Name;
			scrollItemRoleInfo.E_tglSelectToggle.onValueChanged.RemoveAllListeners();
			scrollItemRoleInfo.E_tglSelectToggle.onValueChanged.AddListener((isOn) =>
			{
				if (isOn)
				{
					self.OnSelectRoleInfosHandler( roleInfo.Id);
				}
			});
			
 
		}

		public static async ETTask OnCreateRoleButtonHandler(this DlgRole self)
		{
			string name = self.View.E_InputNameInputField.text;

			if (string.IsNullOrEmpty(name))
			{
				Log.Error("角色名称 为 null");
				return;
			}

			try
			{
				int errorCode = await LoginHelper.CreateRole(self.ZoneScene(), name);
				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;	
				}
				

			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
			
			self.RefreshRoleItems();
			await ETTask.CompletedTask;
		}

		public static void OnSelectRoleInfosHandler(this DlgRole self, long roleId)
		{
			self.ZoneScene().GetComponent<RoleInfoComponent>().CurrentRoleId =roleId;
			Log.Debug($"当前选择的角色 Id 是：{roleId}");
			self.View.E_LoopRoleLoopHorizontalScrollRect.RefillCells();
		}
		
		public static async ETTask OnGameStartHandler(this DlgRole self)
		{
			await ETTask.CompletedTask;
		}

		public static async ETTask OnDeleteRoleClickHandler(this DlgRole self)
		{
			if (self.ZoneScene().GetComponent<RoleInfoComponent>().CurrentRoleId ==0)
			{
				Log.Error("请选择需要删除的角色");
				return;
			}

			try
			{

				int errorCode = 0;
				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;	
				}
				self.RefreshRoleItems();
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
			
		}
	}
}
