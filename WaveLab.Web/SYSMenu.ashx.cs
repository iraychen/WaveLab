using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Text;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "tempuri.org")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SYSMenu : IHttpHandler
    {
        private IList<int> arItems;
        private IList<SYSMenuInfo> menuItems;
        private ISYSSecurityMasterService SecurityMasterService;
        private ISYSMenuService menuService;

        public void ProcessRequest(HttpContext context)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");
            menuService = (ISYSMenuService)cxt.GetObject("SV.SYSMenuService");

            arItems = SecurityMasterService.GetACMenu(context.User.Identity.Name);
            menuItems = menuService.GetItems();

            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            this.BuildMenu(ref builder, 0);
            builder.Append("]");

            context.Response.ContentType = "application/json";
            context.Response.Write(builder.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void BuildMenu(ref StringBuilder builder, int parentId)
        {
            var subMenuItem = from item in menuItems
                              where item.ParentId == parentId
                              orderby item.Sequence
                              select item;

            var atFirst = true;
            IEnumerator ienum = subMenuItem.GetEnumerator();
            while (ienum.MoveNext())
            {
                SYSMenuInfo item = (SYSMenuInfo)ienum.Current;
                if (arItems.Contains(item.MenuId))
                {
                    if (atFirst == true)
                    {
                        atFirst = false;
                    }
                    else
                    {
                        builder.Append(",");
                    }
                    builder.Append("{");
                    builder.Append("\"id\":" + item.MenuId + ",\"pId\":" + item.ParentId + ",\"name\":\"" + item.MenuDesc + "\"");
                    if (item.MenuItem == 'N')
                    {
                        builder.Append(",\"iconOpen\":\"./images/menu-folder-open.png\",\"iconClose\":\"./images/menu-folder.png\"");
                        IList<SYSMenuInfo> childItems = (from childitem in menuItems
                                                      where childitem.ParentId == item.MenuId
                                                      select childitem).ToList<SYSMenuInfo>();

                        if (childItems.Count > 0)
                        {
                            builder.Append(",\"children\":");
                            builder.Append("[");
                            this.BuildMenu(ref builder, item.MenuId);
                            builder.Append("]");
                        }
                    }
                    else
                    {
                        builder.Append(",\"icon\":\"" + item.ImageUrl + "\",\"url\":\"" + item.Url + "\",\"target\":\"main\"");
                    }
                    builder.Append("}");
                }
            }
        }
    }
}
