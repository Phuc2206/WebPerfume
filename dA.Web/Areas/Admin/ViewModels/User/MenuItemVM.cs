using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Areas.ViewModels
{
	public class MenuItemVM
	{
		public MenuItemVM()
		{
			Childs = new List<MenuItemVM>();
		}
		public MenuItemVM(string displayText, string icon = "", string idAttr = "", string action = "",
			string controller = "", string role = "", List<MenuItemVM> childs = null)
		{
			Text = displayText;
			ActionName = action;
			IdAttr = idAttr;
			ControllerName = controller;
			Icon = icon;
			Role = role;
			Childs = childs;
		}
		public string Text { get; set; }
		public string IdAttr { get; set; }
		public string ActionName { get; set; }
		public string ControllerName { get; set; }
		public string Icon { get; set; }
		public string Role { get; set; }
		public List<MenuItemVM> Childs { get; set; }
	}
}
