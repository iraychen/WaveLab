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

namespace WaveLab.Web
{
    public partial class SPCPullingForceTargets : CommonPage
    {
        private ISPCPullingForceTargetService SPCPullingForceTargetService;
        private Hashtable hashTable = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCPullingForceTargetService = (ISPCPullingForceTargetService)cxt.GetObject("SV.SPCPullingForceTargetService");

            if (!Page.IsPostBack)
            {
                ViewState["sortby"] = "Machine_No asc, Effective_Date";
                ViewState["orderby"] = "Desc";
                BindResult();
            }
        }

        private void BindResult()
        {
            IList<SPCPullingForceTargetInfo> items = SPCPullingForceTargetService.Query(ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString();
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

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtEdit = (LinkButton)e.Row.FindControl("lbtEdit");
                lbtEdit.Attributes.Add("onclick", "return makeWindow('EDIT','" +
                    Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "PullingForceTargetPK")) + "')");

                LinkButton lbtDelete = (LinkButton)e.Row.FindControl("lbtDelete");
                lbtDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
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

        protected void GVList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int PullingForceTargetPK = int.Parse(this.GVList.DataKeys[e.RowIndex].Values["PullingForceTargetPK"].ToString());
            try
            {
                SPCPullingForceTargetService.Delete(PullingForceTargetPK);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');</script>");
            this.BindResult();
        }
    }
}
