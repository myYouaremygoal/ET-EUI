using System.Collections.Generic;

namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSeverInfo :Entity,IAwake,IUILogic
	{

		public DlgSeverInfoViewComponent View { get => this.Parent.GetComponent<DlgSeverInfoViewComponent>();} 

		public Dictionary<int,Scroll_Item_SeverInfo>  ScrollItemSeverInfos  = new Dictionary<int, Scroll_Item_SeverInfo>();
		
	}
}
