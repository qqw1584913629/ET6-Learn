using System.Collections.Generic;

namespace ET
{
	public  class DlgRoles :Entity,IAwake
	{

		public DlgRolesViewComponent View { get => this.Parent.GetComponent<DlgRolesViewComponent>();}

		public Dictionary<int, Scroll_Item_role> ScrollItemRoles;


	}
}
