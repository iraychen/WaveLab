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
    public partial class SPCTxPowerItemLog : CommonPage
    {
        private int TxPowerItemPK;
        
        private ISPCTxPowerItemService SPCTxPowerItemService;
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCTxPowerItemService = (ISPCTxPowerItemService)cxt.GetObject("SV.SPCTxPowerItemService");
            TxPowerItemPK=int.Parse(Request.QueryString["TxPowerItemPK"]);
             
            if (!Page.IsPostBack)
            {
                SPCTxPowerItemInfo entity = SPCTxPowerItemService.Get(TxPowerItemPK);
              

                this.ltlType.Text = entity.Type;
                this.ltlMode.Text = entity.Mode;
                this.ltlCH.Text = entity.CH;
                this.ltlPW.Text = entity.PW;

                IList<SPCTxPowerItemLogInfo> logs = SPCTxPowerItemService.GetLogs(TxPowerItemPK);
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
            Response.Redirect("SPCTxPowerItemEdit.aspx?TxPowerItemPK=" + TxPowerItemPK);
        }
                
    }
}
