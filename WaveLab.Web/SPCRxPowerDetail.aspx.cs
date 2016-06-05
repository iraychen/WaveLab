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
using System.Collections.Generic;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;
using WaveLab.Service.Utility;

namespace WaveLab.Web
{
    public partial class SPCRxPowerOriginal :CommonPage
    {
        private ISPCRxPowerService SPCRxPowerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCRxPowerService = (ISPCRxPowerService)cxt.GetObject("SV.SPCRxPowerService");

            if (!Page.IsPostBack)
            {
                int RxPowerPK = int.Parse(Request.QueryString["PK"]);
                int groupNo = int.Parse(Request.QueryString["groupno"]);

                IList<SPCRxPowerDetail> GroupedItems = SPCRxPowerService.GetOrignalData(RxPowerPK,groupNo);

                this.GVGroupItems.DataSource = GroupedItems;
                this.GVGroupItems.DataBind();
            }
        }
    }
}
