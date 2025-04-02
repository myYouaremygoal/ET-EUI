
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_SeverInfoDestroySystem : DestroySystem<Scroll_Item_SeverInfo> 
	{
		public override void Destroy( Scroll_Item_SeverInfo self )
		{
			self.DestroyWidget();
		}
	}
}
