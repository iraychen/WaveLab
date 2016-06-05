using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class Report : CommonPage
    {
        private ReportGroupInfo entity;
        private IReportGroupService ReportGroupService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            ReportGroupService = (IReportGroupService)cxt.GetObject("SV.ReportGroupService");
            if (!Page.IsPostBack)
            {
                entity = ReportGroupService.GetDetail(Request.QueryString["GroupCode"]);
                this.lblTitle.Text = entity.Descript;
                foreach( ReportInfo item in entity.ReportItems)
                {
                    this.selectable.InnerHtml += "<li><a href='"+item.Url+"' target='_blank'>"+item.Title+"</a></li>";
                }
            }
        }
    }
}
