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
    public partial class MCTDetail : CommonPage
    {
        private int MCTId;
        private MCTInfo entity;
        private IMCTService mctService;
        private string pastMaterialDesc, pastModel, pastPartNo, pastComponentDesc, pastHomoMaterialName;
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            mctService = (IMCTService)cxt.GetObject("SV.MCTService");

            if (!Page.IsPostBack)
            {
                MCTId = int.Parse(Request.QueryString["mctid"]);
                entity = mctService.GetDetail(MCTId);
                LoadDetail();
            }
        }

        private void LoadDetail()
        {
            this.lblSupplierNameVal.Text = entity.SupplierName;
            this.lblCompletedDateVal.Text = string.Format("{0:yyyy-MM-dd}", entity.CompletedDate);
            this.lblDeparmentVal.Text = entity.Department;
            this.lblCompleteByVal.Text=entity.CompletedBy ;
            this.lblEmailVal.Text=entity.Email;
            this.lblTelVal.Text = entity.Tel;
            this.lblFaxVal.Text = entity.Fax;

            this.GVList.DataSource = entity.MCTDtlItem;
            this.GVList.DataBind();

        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                if (string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "MaterialDesc").ToString(), pastMaterialDesc) == true)
                {
                    e.Row.Cells[0].Text = "";
                }

                if (string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "MaterialDesc").ToString(), pastMaterialDesc) == true &&
                    string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "Model").ToString(), pastModel) == true)
                {
                    e.Row.Cells[1].Text = "";
                }

                if (string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "MaterialDesc").ToString(), pastMaterialDesc) == true &&
                    string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "Model").ToString(), pastModel) == true &&
                    string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "PartNo").ToString(), pastPartNo) == true)
                {
                    e.Row.Cells[2].Text = "";
                }

                if (string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "MaterialDesc").ToString(), pastMaterialDesc) == true &&
                    string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "Model").ToString(), pastModel) == true &&
                    string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "PartNo").ToString(), pastPartNo) == true &&
                    string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "ComponentDesc").ToString(), pastComponentDesc) == true)
                {
                    e.Row.Cells[3].Text = "";
                }

                if (string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "MaterialDesc").ToString(), pastMaterialDesc) == true &&
                    string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "Model").ToString(), pastModel) == true &&
                    string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "PartNo").ToString(), pastPartNo) == true &&
                    string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "ComponentDesc").ToString(), pastComponentDesc) == true &&
                    string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "HomoMaterialName").ToString(), pastHomoMaterialName) == true)
                {
                    e.Row.Cells[4].Text = "";
                }

                pastMaterialDesc = DataBinder.GetPropertyValue(e.Row.DataItem, "MaterialDesc").ToString();
                pastModel = DataBinder.GetPropertyValue(e.Row.DataItem, "Model").ToString();
                pastPartNo = DataBinder.GetPropertyValue(e.Row.DataItem, "PartNo").ToString();
                pastComponentDesc = DataBinder.GetPropertyValue(e.Row.DataItem, "ComponentDesc").ToString();
                pastHomoMaterialName = DataBinder.GetPropertyValue(e.Row.DataItem, "HomoMaterialName").ToString();
            }
        }
    }
}
