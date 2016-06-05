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
    public partial class SPCTxPowerOriginal :CommonPage
    {
        private ISPCTxPowerService SPCTxPowerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCTxPowerService = (ISPCTxPowerService)cxt.GetObject("SV.SPCTxPowerService");
            
            if (!Page.IsPostBack)
            {
                int TxPowerPK = int.Parse(Request.QueryString["PK"]);
                int groupNo = int.Parse(Request.QueryString["groupno"]);

                IList<SPCTxPowerDetail> GroupedItems = SPCTxPowerService.GetOrignalData(TxPowerPK,groupNo);

                this.GVGroupItems.DataSource = GroupedItems;
                this.GVGroupItems.DataBind();
            }
        }
    }
}
