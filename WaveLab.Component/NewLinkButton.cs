using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web;

using WaveLab.Model;
using WaveLab.IService;

using Spring.Context;
using Spring.Context.Support;

namespace WaveLab.Component
{
    public class NewLinkButton: LinkButton
    {
        private string _Action;

        public string Action
        {
            get
            {
                return this._Action;
            }
            set
            {
                _Action = value;
            }
        }

        override protected void OnLoad(EventArgs e)
        {
            if (string.IsNullOrEmpty(Action) == false)
            {
                IApplicationContext cxt = ContextRegistry.GetContext();
                ISYSRoleService roleService = (ISYSRoleService)cxt.GetObject("SV.SYSRoleService");
                if (roleService.GetActionACRight(HttpContext.Current.User.Identity.Name, Action) == false)
                {
                    base.Visible = false;
                }
            }
        }
    }
}
