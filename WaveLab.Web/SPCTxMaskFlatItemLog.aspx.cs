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
    public partial class SPCTxMaskFlatItemLog : CommonPage
    {
        private int TxMaskFlatItemPK;

        private ISPCTxMaskFlatItemService SPCTxMaskFlatItemService;


        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCTxMaskFlatItemService = (ISPCTxMaskFlatItemService)cxt.GetObject("SV.SPCTxMaskFlatItemService");
            TxMaskFlatItemPK = int.Parse(Request.QueryString["TxMaskFlatItemPK"]);

            if (!Page.IsPostBack)
            {
                SPCTxMaskFlatItemInfo entity = SPCTxMaskFlatItemService.Get(TxMaskFlatItemPK);


                this.ltlType.Text = entity.Type;
                this.ltlMode.Text = entity.Mode;
                this.ltlCH.Text = entity.CH;
             ;

                IList<SPCTxMaskFlatItemLogInfo> logs = SPCTxMaskFlatItemService.GetLogs(TxMaskFlatItemPK);
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
            Response.Redirect("SPCTxMaskFlatItemEdit.aspx?TxMaskFlatItemPK=" + TxMaskFlatItemPK);
        }

    }
}
