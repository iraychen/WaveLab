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
    public partial class IFBDataRangeEdit : CommonPage
    {
        private IIFBDataRangeService IFBDataRangeService;
        private IFrequencyService FrequencyService;

        private string data, description, unit;
        private IList<IFBDataRangeInfo> items;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            IFBDataRangeService = (IIFBDataRangeService)cxt.GetObject("SV.IFBDataRangeService");
            FrequencyService = (IFrequencyService)cxt.GetObject("SV.FrequencyService");

            data = Request.QueryString["key1"];
            description = Request.QueryString["key2"];
            unit = Request.QueryString["key3"];
            if (!Page.IsPostBack)
            {
                if (data != null)
                {
                    items = IFBDataRangeService.GetDetail(data);
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
                Literal ltlFrequency = (Literal)e.Row.FindControl("ltlFrequency");
                IList<IFBDataRangeInfo> targetItems = (from item in items
                                                       where item.Data == data && item.Frequency == ltlFrequency.Text
                                                       select item).ToList<IFBDataRangeInfo>();

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
            IList<IFBDataRangeInfo> newItems = new List<IFBDataRangeInfo>();
            IList<IFBDataRangeInfo> editItems = new List<IFBDataRangeInfo>();
            IList<IFBDataRangeInfo> deleteItems = new List<IFBDataRangeInfo>();

            int count = this.GVList.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                IFBDataRangeInfo item = new IFBDataRangeInfo();
                item.Data = data;

                Literal ltlFrequency = (Literal)this.GVList.Rows[i].FindControl("ltlFrequency");
                item.Frequency = WebUtitlity.InputText(ltlFrequency.Text, 50).Trim();

                CheckBox chx = (CheckBox)this.GVList.Rows[i].FindControl("check");
                if (chx.Checked == true)
                {
                    item.Description = this.tbxDescription.Text.Trim();
                    item.Unit = this.tbxUnit.Text.Trim();

                    TextBox tbxLowerBound = (TextBox)this.GVList.Rows[i].FindControl("tbxLowerBound");
                    item.LowerBound = WebUtitlity.InputText(tbxLowerBound.Text, 50).Trim();

                    TextBox tbxUpperBound = (TextBox)this.GVList.Rows[i].FindControl("tbxUpperBound");
                    item.UpperBound = WebUtitlity.InputText(tbxUpperBound.Text, 50).Trim();

                    TextBox tbxTarget = (TextBox)this.GVList.Rows[i].FindControl("tbxTarget");
                    item.Target = WebUtitlity.InputText(tbxTarget.Text, 50).Trim();

                    item.LastUpdateDate = DateTime.Now;
                    item.LastUpdatedBy = Page.User.Identity.Name;

                    if (IFBDataRangeService.CheckExists(item.Data, item.Frequency) == false)
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
                IFBDataRangeService.Update(newItems, editItems, deleteItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}
