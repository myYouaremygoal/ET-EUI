
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ESCommonUItAwakeSystem : AwakeSystem<ESCommonUIt,Transform> 
	{
		public override void Awake(ESCommonUIt self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ESCommonUItDestroySystem : DestroySystem<ESCommonUIt> 
	{
		public override void Destroy(ESCommonUIt self)
		{
			self.DestroyWidget();
		}
	}
}
