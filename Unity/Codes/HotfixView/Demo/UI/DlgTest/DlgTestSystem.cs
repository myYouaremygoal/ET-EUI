using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgTest))]
	public static  class DlgTestSystem
	{

		public static void RegisterUIEvent(this DlgTest self)
		{
			self.View.E_EnterMapButton.AddListener(self.OnEnterMapClickHandler);
			self.View.E_TestButton.AddListener(self.OnTestClickHandler);
		}

		public static void ShowWindow(this DlgTest self, Entity contextData = null)
		{
			self.View.E_TestTxtText.text = "test label";
		}

		public static void OnEnterMapClickHandler(this DlgTest self)
		{
			Log.Debug("Enter map");
	    }

		public static void OnTestClickHandler(this DlgTest self)
		{
			Log.Debug("Click  test");
			self.View.E_TestTxtText.text = "Click  test";
		}

	}
}
