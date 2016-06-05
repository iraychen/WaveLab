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
using WaveLab.Model;
using WaveLab.IService;
using System.Collections.Generic;
using System.IO;

using Spring.Context;
using Spring.Context.Support;

namespace WaveLab.Web
{
    public partial class SMTCPTemplateCtl : CommonPage
    {
        private ISMTCPTemplateService SMTCPTemplateService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SMTCPTemplateService = (ISMTCPTemplateService)cxt.GetObject("SV.SMTCPTemplateService");

            if (!Page.IsPostBack)
            {
                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "effective_date";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "desc";
                }
                BindResult();
            }
        }
       
        private void BindResult()
        {
            IList<SMTCPTemplateInfo> items = SMTCPTemplateService.Query(ViewState["sortby"].ToString(), ViewState["orderby"].ToString());

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

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
              
                LinkButton lbtDelete = (LinkButton)e.Row.FindControl("lbtDelete");
              
                lbtDelete.Attributes.Add("onclick", "return confirm(\""+this.GetGlobalResourceObject("globalResource","confirmDeleteMsg").ToString()+"\")");
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

        protected void GVList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (string.Equals(e.CommandName.ToUpper(), "VIEW") == true)
            {
                string docPath = e.CommandArgument.ToString();
                FileStream outstream = new FileStream(WaveLab.Service.Setting.sampleExcelPath + docPath, FileMode.Open, FileAccess.Read);
                int count = Convert.ToInt32(outstream.Length);
                Byte[] bytes = new Byte[count];
                outstream.Read(bytes, 0, count);
                outstream.Close();
                Response.ClearHeaders();
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + docPath );
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.BinaryWrite(bytes);
                Response.End();
            }
        }

        protected void GVList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SMTCPTemplateInfo entity = new SMTCPTemplateInfo();
            entity.EffectiveDate = Convert.ToDateTime(this.GVList.DataKeys[e.RowIndex].Values["effectivedate"]);
            entity.DocumentPath = Convert.ToString(this.GVList.DataKeys[e.RowIndex].Values["documentpath"]);
            string docPath = WaveLab.Service.Setting.sampleExcelPath + "/" + entity.DocumentPath;

            try
            {
                SMTCPTemplateService.Delete(entity);
                if (File.Exists(docPath) == true)
                {
                    File.Delete(docPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');refresh();</script>");
        }
    }
}
