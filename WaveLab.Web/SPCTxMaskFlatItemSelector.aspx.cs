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
    public partial class SPCTxMaskFlatItemSelector : CommonPage
    {
        private ILabelCodeService LabelCodeService;
        private ISPCTxMaskFlatService SPCTxMaskFlatService;
        private ISPCTxMaskFlatItemService SPCTxMaskFlatItemService;

        private Hashtable hashTable=new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCTxMaskFlatItemService = (ISPCTxMaskFlatItemService)cxt.GetObject("SV.SPCTxMaskFlatItemService");
            SPCTxMaskFlatService = (ISPCTxMaskFlatService)cxt.GetObject("SV.SPCTxMaskFlatService");
            LabelCodeService = (ILabelCodeService)cxt.GetObject("SV.LabelCodeService");

            if (!Page.IsPostBack)
            {
                IList<LabelCodeInfo> items = LabelCodeService.GetItems("a.model", "asc");
                this.ddlModel.DataSource = items;
                this.ddlModel.DataValueField = "Model";
                this.ddlModel.DataTextField = "Model";
                this.ddlModel.DataBind();

                this.ddlModel.Items[0].Selected = true;

                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "mode";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "asc";
                }
                BindResult();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BindResult();
        }

        private void GetParas()
        {
            if (this.ddlModel.SelectedValue.Trim().Length > 0)
            {
                hashTable.Add("type", this.ddlModel.SelectedValue.Trim());
            };
        }

        private void BindResult()
        {
            GetParas();
            IList<SPCTxMaskFlatItemInfo> items = SPCTxMaskFlatService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.GVList.Visible = false;
                this.TabContainerTarget.Visible = false;
                this.btnSave.Visible = false;
                this.btnCancel.Visible = false;

                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString();
            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;
                this.TabContainerTarget.Visible = true;
                this.btnSave.Visible = true;
                this.btnCancel.Visible = true;

                this.GVList.DataSource = items;
                this.GVList.DataBind();
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                CheckBox chxTakePartIn = (CheckBox)e.Row.FindControl("chxTakePartIn");

                if (Convert.ToChar(DataBinder.GetPropertyValue(e.Row.DataItem, "TakePartIn")) == 'Y')
                {
                    chxTakePartIn.Checked = true;
                }
                else
                {
                    chxTakePartIn.Checked = false;
                }
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SPCTxMaskFlatItemInfo item = new SPCTxMaskFlatItemInfo();
            for (int i = 0; i < this.GVList.Rows.Count; i++)
            {
                CheckBox chxTakePartIn = (CheckBox)this.GVList.Rows[i].FindControl("chxTakePartIn");
                if (chxTakePartIn.Checked == true)
                {
                    item.Type = this.ddlModel.SelectedValue.Trim();
                    item.Mode = Convert.ToString(this.GVList.Rows[i].Cells[0].Text).Trim();
                    item.CH = Convert.ToString(this.GVList.Rows[i].Cells[1].Text).Trim();
                    item.SamplingLower = Convert.ToDouble(this.tbxSamplingLower.Text.Trim());
                    item.SamplingUpper = Convert.ToDouble(this.tbxSamplingUpper.Text.Trim());
                    item.USL = Convert.ToDouble(this.tbxUSL.Text.Trim());
                    if (this.tbxLCL_X.Text.Trim().Length == 0)
                    {
                        item.LCL_X = null;
                    }
                    else
                    {
                        item.LCL_X = Convert.ToDouble(this.tbxLCL_X.Text.Trim());
                    }
                    if (this.tbxUCL_X.Text.Trim().Length == 0)
                    {
                        item.UCL_X = null;
                    }
                    else
                    {
                        item.UCL_X = Convert.ToDouble(this.tbxUCL_X.Text.Trim());
                    }
                    if (this.tbxLCL_R.Text.Trim().Length == 0)
                    {
                        item.LCL_R = null;
                    }
                    else
                    {
                        item.LCL_R = Convert.ToDouble(this.tbxLCL_R.Text.Trim());
                    }
                    if (this.tbxUCL_R.Text.Trim().Length == 0)
                    {
                        item.UCL_R = null;
                    }
                    else
                    {
                        item.UCL_R = Convert.ToDouble(this.tbxUCL_R.Text.Trim());
                    }
                    item.Enable = 'Y';
                    item.LastUpdateDate = DateTime.Now;
                    item.LastUpdatedBy = Page.User.Identity.Name;
                }
            }
            if (SPCTxMaskFlatItemService.CheckExists(item) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("ExistsMsg") + "');</script>");
                return;
            }

            try
            {
                SPCTxMaskFlatItemService.Save(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');opener.location.herf='" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "';</script>");
        }
    }
}
