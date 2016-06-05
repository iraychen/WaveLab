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
    public partial class SerialNoList : CommonPage
    {
        private ISerialNoService SerialNoService;
        private Hashtable hashTable = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SerialNoService = (ISerialNoService)cxt.GetObject("SV.SerialNoService");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ViewState["sortby"] == null)
            {
                ViewState["sortby"] = "b.serial_no";
            }

            if (ViewState["orderby"] == null)
            {
                ViewState["orderby"] = "desc";
            }
            BindResult();

        }

        private void GetParas()
        {
            if (this.tbxOrderNo.Text.Trim().Length > 0)
            {
                hashTable.Add("order_no", this.tbxOrderNo.Text.Trim());
            }
            if (this.tbxModel.Text.Trim().Length > 0)
            {
                hashTable.Add("model", this.tbxModel.Text.Trim());
            }
            if (this.tbxCode.Text.Trim().Length > 0)
            {
                hashTable.Add("code", this.tbxCode.Text.Trim());
            }
            if (this.tbxSerialNo.Text.Trim().Length > 0)
            {
                hashTable.Add("serial_no", this.tbxSerialNo.Text.Trim());
            }
        }

        private void BindResult()
        {
            GetParas();
            IList<SerialNoInfo> items = SerialNoService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.GVList.Visible = false;

                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString();
                
            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;

                this.GVList.DataSource = items;
                this.GVList.DataBind();
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtSerialNo = (LinkButton)e.Row.FindControl("lbtSerialNo");
                lbtSerialNo.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SerialNo"));

                string url = "MIMeasureDataNew.aspx?key1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "OrderNo")) +
                    "&key2=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MeterialCode")) +
                    "&key3=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MeterialDesc")) +
                    "&key4=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SerialNo")) +
                    "&backlink=" + System.Web.HttpUtility.UrlEncode(Request.QueryString["backlink"].ToString());
                lbtSerialNo.Attributes.Add("onclick", "return Redirect('"+url+"')");
            }
        }

        protected void GVList_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["sortby"].ToString() == e.SortExpression)
            {
                if (ViewState["orderby"].ToString() == "asc")
                {
                    ViewState["orderby"] = "desc";
                }
                else
                {
                    ViewState["orderby"] = "asc";
                }
            }
            else
            {
                ViewState["sortby"] = e.SortExpression;
            }
            this.BindResult();
        }
    }
}
