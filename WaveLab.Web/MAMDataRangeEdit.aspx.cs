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
using System.IO;
using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;
using WaveLab.Service.Utility;

namespace WaveLab.Web
{
    public partial class MAMDataRangeEdit :  CommonPage
    {
        private IMAMDataRangeService MAMDataRangeService;
        private IMAMTypeService MAMTypeService;
        private IFrequencyService FrequencyService;

        private string MAMType, data,description,unit;
        private IList<MAMDataRangeInfo> items;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            MAMDataRangeService = (IMAMDataRangeService)cxt.GetObject("SV.MAMDataRangeService");
            MAMTypeService = (IMAMTypeService)cxt.GetObject("SV.MAMTypeService");
            FrequencyService = (IFrequencyService)cxt.GetObject("SV.FrequencyService");

            MAMType = Request.QueryString["key1"];
            data = Request.QueryString["key2"];
            description = Request.QueryString["key3"];
            unit = Request.QueryString["key4"];
            if (!Page.IsPostBack)
            {
                if(MAMType!=null && data!=null)
                {
                    items = MAMDataRangeService.GetDetail(MAMType, data);
                    this.ltlMAMType.Text =((MAMTypeInfo) MAMTypeService.GetDetail(MAMType)).MAMTypeDesc;
                    this.ltlData.Text = data;
                    this.tbxDescription.Text = description;
                    this.tbxUnit.Text = unit;
                }

                this.GVList.DataSource = FrequencyService.GetItems();
                this.GVList.DataBind();

            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                Literal ltlFrequency = (Literal) e.Row.FindControl("ltlFrequency");
               IList<MAMDataRangeInfo> targetItems = (from item in items
                            where item.MAMType == MAMType && item.Data == data && item.Frequency == ltlFrequency.Text
                            select item).ToList<MAMDataRangeInfo>();

               CheckBox chx = (CheckBox)e.Row.FindControl("check");
               TextBox tbxLowerBound = (TextBox)e.Row.FindControl("tbxLowerBound");
               TextBox tbxUpperBound = (TextBox)e.Row.FindControl("tbxUpperBound");
               TextBox tbxTarget = (TextBox)e.Row.FindControl("tbxTarget");

               if (targetItems.Count > 0)
               {
                   chx.Checked = true;

                   for (int i = 0; i < targetItems.Count; i++)
                   {
                       tbxLowerBound.Text = targetItems[i].LowerBound;
                       tbxUpperBound.Text = targetItems[i].UpperBound;
                       tbxTarget.Text = targetItems[i].Target;
                   }
               }
               else
               {
                   chx.Checked = false;

                   tbxLowerBound.Enabled = false;
                   tbxUpperBound.Enabled = false;
                   tbxTarget.Enabled = false;
               }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IList<MAMDataRangeInfo> newItems = new List<MAMDataRangeInfo>();
            IList<MAMDataRangeInfo> editItems = new List<MAMDataRangeInfo>();
            IList<MAMDataRangeInfo> deleteItems = new List<MAMDataRangeInfo>();

            int count = this.GVList.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                MAMDataRangeInfo item = new MAMDataRangeInfo();
                item.MAMType = MAMType;
                item.Data = data;

                Literal ltlFrequency = (Literal)this.GVList.Rows[i].FindControl("ltlFrequency");
                item.Frequency = WebUtitlity.InputText(ltlFrequency.Text, 50).Trim();

                CheckBox chx = (CheckBox)this.GVList.Rows[i].FindControl("check");
                if (chx.Checked == true)
                {
                    item.Description = this.tbxDescription.Text.Trim();
                    item.Unit = this.tbxUnit.Text.Trim();

                    TextBox tbxLowerBound=(TextBox)this.GVList.Rows[i].FindControl("tbxLowerBound");
                    item.LowerBound = WebUtitlity.InputText(tbxLowerBound.Text, 50).Trim();

                    TextBox tbxUpperBound = (TextBox)this.GVList.Rows[i].FindControl("tbxUpperBound");
                    item.UpperBound = WebUtitlity.InputText(tbxUpperBound.Text, 50).Trim();

                    TextBox tbxTarget = (TextBox)this.GVList.Rows[i].FindControl("tbxTarget");
                    item.Target = WebUtitlity.InputText(tbxTarget.Text, 50).Trim(); 

                    item.LastUpdateDate = DateTime.Now;
                    item.LastUpdatedBy = Page.User.Identity.Name;

                    if(MAMDataRangeService.CheckExists(item.MAMType,item.Data,item.Frequency)==false)
                    {
                        newItems.Add(item);
                    }
                    else
                    {
                        editItems.Add(item);
                    }
                }
                else
                {
                   deleteItems.Add(item);
                }
            }
           
            try
            {
                MAMDataRangeService.Update(newItems,editItems,deleteItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}
