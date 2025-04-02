using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(ServerInfo))]
	[FriendClass(typeof(ServerInfosComponent))]
	[FriendClass(typeof(DlgSeverInfo))]
	public static  class DlgSeverInfoSystem
	{

		public static void RegisterUIEvent(this DlgSeverInfo self)
		{
		    self.View.ELoopSeverInfoListLoopVerticalScrollRect.AddItemRefreshListener(((transform, Index) =>
		    {
			    self.OnLoopListRefreshHandler(transform, Index);
			   
		    }));
		    self.View.E_SelectSeverInfoButton.AddListenerAsync(() =>
		    {
			    return  self.OnSelectServerInfosHandler();
		    });
		}

		public static async void ShowWindow(this DlgSeverInfo self, Entity contextData = null)
		{
			
			int count =self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList.Count;
			Log.Debug($"服务器数量{count}");
			self.AddUIScrollItems(ref self.ScrollItemSeverInfos,count);
			self.View.E_SeverGroupToggleGroup.allowSwitchOff = false;
			self.View.E_SeverGroupToggleGroup.EnsureValidState();
			self.View.ELoopSeverInfoListLoopVerticalScrollRect.SetVisible(true, count);
		}

		public static void HideWindow(this DlgSeverInfo self)
		{
			self.RemoveUIScrollItems(ref self.ScrollItemSeverInfos);
		}

		public static void OnLoopListRefreshHandler(this DlgSeverInfo self,Transform transform, int index)
		{
			Scroll_Item_SeverInfo  scrollItemSeverInfo = self.ScrollItemSeverInfos[index].BindTrans(transform);
			scrollItemSeverInfo.E_SeverSelectToggle.group = self.View.E_SeverGroupToggleGroup;
			
			var serverInfo = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList[index];
			scrollItemSeverInfo.E_SeverNameText.text =serverInfo.ServerName;
			scrollItemSeverInfo.E_SeverSelectToggle.onValueChanged.RemoveAllListeners();
			scrollItemSeverInfo.E_SeverSelectToggle.onValueChanged.AddListener((isOn) =>
			{
				if (isOn)
				{
					self.OnSelectServerInfosHandler( serverInfo.Id);
				}
			});
		}

		public static void OnSelectServerInfosHandler(this DlgSeverInfo self, long serverId)
		{
			self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId =int.Parse(serverId.ToString());
			Log.Debug($"当前选择的服务器 Id 是：{serverId}");
			self.View.ELoopSeverInfoListLoopVerticalScrollRect.RefillCells();
		}

		public static async ETTask OnSelectServerInfosHandler(this DlgSeverInfo self)
		{
			bool isSelect = self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId != 0;
			if (isSelect)
			{
				Log.Error("请选择游戏区服");
				return;
			}

			try
			{
				int errorCode = await LoginHelper.GetRoles(self.ZoneScene());
				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
				self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_SeverInfo);
				self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_SeverInfo);
				
			}
			catch (Exception e)
			{
				 Log.Error(e.ToString());
			}
		}
	}
}
