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

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class SPCParametersCtl : CommonPage
    {
        private Hashtable hashTable = new Hashtable();
        private ISPCParameterService SPCParameterService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCParameterService = (ISPCParameterService)cxt.GetObject("SV.SPCParameterService");

            if (!Page.IsPostBack)
            {
                BindResult();
            }
        }

      
        private void BindResult()
        {

            IList<SPCParameterInfo> items = SPCParameterService.Query();
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.GVList.Visible = false;
            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;

                this.GVList.DataSource = items;
                this.GVList.DataBind();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Redirect("SPCParametersImport.aspx");
        }
        
    }
}
