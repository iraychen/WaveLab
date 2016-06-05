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
    public partial class SMTPCBPriorityItemCtl : CommonPage
    {
        private Hashtable hashTable = new Hashtable();
        private ISMTPCBPriorityItemService SMTPCBPriorityItemService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SMTPCBPriorityItemService = (ISMTPCBPriorityItemService)cxt.GetObject("SV.SMTPCBPriorityItemService");

            if (!Page.IsPostBack)
            {
                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "a.pcb";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "asc";
                }
                BindResult();
            }
        }

        private void GetSearchCriteria()
        {
            if (this.tbxPCB.Text.Trim().Length > 0)
            {
                hashTable.Add("pcb", this.tbxPCB.Text.Trim());
            }
        }

        private void BindResult()
        {
            GetSearchCriteria();
            IList<SMTPCBPriorityItemInfo> items = SMTPCBPriorityItemService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.GVList.Visible = false;

                this.btnSave.Visible = false;
                this.btnReset.Visible = false;
            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;
                this.btnSave.Visible = true;
                this.btnReset.Visible = true;
                this.GVList.DataSource = items;
                this.GVList.DataBind();
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                CheckBox cbxSelect = (CheckBox)e.Row.FindControl("cbxSelect");            
                Char  priorityItem = Convert.ToChar(DataBinder.Eval(e.Row.DataItem, "priorityitem"));
                if (priorityItem == 'Y')
                {
                    cbxSelect.Checked = true;
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindResult();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int count = this.GVList.Rows.Count;
            IList<SMTPCBPriorityItemInfo> newItems = new List<SMTPCBPriorityItemInfo>();
            IList<SMTPCBPriorityItemInfo> editItems = new List<SMTPCBPriorityItemInfo>();
            for (int i = 0; i < count; i++)
            {
                SMTPCBPriorityItemInfo item = new SMTPCBPriorityItemInfo();
                item.PCB = this.GVList.DataKeys[i].Values["pcb"].ToString();

                CheckBox chxSelect = (CheckBox)this.GVList.Rows[i].FindControl("cbxSelect");
                if (chxSelect.Checked == true)
                {
                    item.PriorityItem = 'Y';
                }
                else
                {
                    item.PriorityItem = 'N';
                }
                item.LastUpdateDate = DateTime.Now;
                item.LastUpdatedBy = Page.User.Identity.Name;
                if (SMTPCBPriorityItemService.CheckExists(item.PCB) == false)
                {
                    item.CreationDate = DateTime.Now;
                    item.CreatedBy = Page.User.Identity.Name;
                    newItems.Add(item);
                }
                else
                {
                    editItems.Add(item);
                }
               
            }
            try
            {
                SMTPCBPriorityItemService.SavePriorityItem(newItems, editItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource","saveSuccessMsg").ToString() + "');</script>");
            this.BindResult();
        }

       

       
    }
}
