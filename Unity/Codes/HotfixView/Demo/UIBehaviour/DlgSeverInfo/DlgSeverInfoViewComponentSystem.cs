
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgSeverInfoViewComponentAwakeSystem : AwakeSystem<DlgSeverInfoViewComponent> 
	{
		public override void Awake(DlgSeverInfoViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgSeverInfoViewComponentDestroySystem : DestroySystem<DlgSeverInfoViewComponent> 
	{
		public override void Destroy(DlgSeverInfoViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
