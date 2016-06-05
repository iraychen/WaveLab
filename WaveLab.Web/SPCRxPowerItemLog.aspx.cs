using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Text;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class SPCRxPowerItemLog : CommonPage
    {
        private int RxPowerItemPK;

        private ISPCRxPowerItemService SPCRxPowerItemService;


        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCRxPowerItemService = (ISPCRxPowerItemService)cxt.GetObject("SV.SPCRxPowerItemService");
            RxPowerItemPK = int.Parse(Request.QueryString["RxPowerItemPK"]);

            if (!Page.IsPostBack)
            {
                SPCRxPowerItemInfo entity = SPCRxPowerItemService.Get(RxPowerItemPK);


                this.ltlType.Text = entity.Type;
                this.ltlMode.Text = entity.Mode;
                this.ltlCH.Text = entity.CH;
                this.ltlPW.Text = entity.PW;

                IList<SPCRxPowerItemLogInfo> logs = SPCRxPowerItemService.GetLogs(RxPowerItemPK);
                if (logs.Count == 0)
                {
                    this.lblRecCount.Visible = true;
                    this.GVList.Visible = false;

                    this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString();
                }
                else
                {
                    this.lblRecCount.Visible = false;
                    this.GVList.Visible = true;

                    this.GVList.DataSource = logs;
                    this.GVList.DataBind();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SPCRxPowerItemEdit.aspx?RxPowerItemPK=" + RxPowerItemPK);
        }

    }
}
