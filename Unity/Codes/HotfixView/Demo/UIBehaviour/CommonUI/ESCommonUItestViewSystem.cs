
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ESCommonUItestAwakeSystem : AwakeSystem<ESCommonUItest,Transform> 
	{
		public override void Awake(ESCommonUItest self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ESCommonUItestDestroySystem : DestroySystem<ESCommonUItest> 
	{
		public override void Destroy(ESCommonUItest self)
		{
			self.DestroyWidget();
		}
	}
}
