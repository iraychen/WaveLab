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
    public partial class SPCStationLineLossItemLog : CommonPage
    {
        private int LineLossItemPK;

        private ISPCStationLineLossItemService SPCStationLineLossItemService;
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCStationLineLossItemService = (ISPCStationLineLossItemService)cxt.GetObject("SV.SPCStationLineLossItemService");
            LineLossItemPK = int.Parse(Request.QueryString["LineLossItemPK"]);
             
            if (!Page.IsPostBack)
            {
                SPCStationLineLossItemInfo entity = SPCStationLineLossItemService.Get(LineLossItemPK);
              

                this.ltlStationNo.Text= entity.StationNo;
                this.ltlCHNo.Text = entity.CHNo;
                this.ltlFrequencyBand.Text = entity.FrequencyBand;
                this.ltlItem.Text = entity.Item;

                IList<SPCStationLineLossItemLogInfo> logs = SPCStationLineLossItemService.GetLogs(LineLossItemPK);
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
            Response.Redirect("SPCStationLineLossItemEdit.aspx?LineLossItemPK=" + LineLossItemPK);
        }
                
    }
}
