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
    public partial class SPCTxMaskFlatOriginal :CommonPage
    {
        private ISPCTxMaskFlatService SPCTxMaskFlatService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCTxMaskFlatService = (ISPCTxMaskFlatService)cxt.GetObject("SV.SPCTxMaskFlatService");

            if (!Page.IsPostBack)
            {
                int TxMaskFlatPK = int.Parse(Request.QueryString["PK"]);
                int groupNo = int.Parse(Request.QueryString["groupno"]);

                IList<SPCTxMaskFlatDetail> GroupedItems = SPCTxMaskFlatService.GetOrignalData(TxMaskFlatPK,groupNo);

                this.GVGroupItems.DataSource = GroupedItems;
                this.GVGroupItems.DataBind();
            }
        }
    }
}
