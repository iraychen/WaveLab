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
    public partial class IFBDataRangeNew : CommonPage
    {
        private IIFBDataRangeService IFBDataRangeService;
        private IFrequencyService FrequencyService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            IFBDataRangeService = (IIFBDataRangeService)cxt.GetObject("SV.IFBDataRangeService");
            FrequencyService = (IFrequencyService)cxt.GetObject("SV.FrequencyService");

            if (!Page.IsPostBack)
            {
                this.GVList.DataSource = FrequencyService.GetItems();
                this.GVList.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IFBDataRangeService.CheckExists(this.tbxData.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }
            IList<IFBDataRangeInfo> items = new List<IFBDataRangeInfo>();

            int count = this.GVList.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                CheckBox chx = (CheckBox)this.GVList.Rows[i].FindControl("check");
                if (chx.Checked == true)
                {
                    IFBDataRangeInfo item = new IFBDataRangeInfo();
                    item.Data = this.tbxData.Text.Trim().ToUpper();
                    item.Description = this.tbxDescription.Text.Trim();
                    item.Unit = this.tbxUnit.Text.Trim();

                    Literal ltlFrequency = (Literal)this.GVList.Rows[i].FindControl("ltlFrequency");
                    item.Frequency = WebUtitlity.InputText(ltlFrequency.Text, 50).Trim();

                    TextBox tbxLowerBound = (TextBox)this.GVList.Rows[i].FindControl("tbxLowerBound");
                    item.LowerBound = WebUtitlity.InputText(tbxLowerBound.Text, 50).Trim();

                    TextBox tbxUpperBound = (TextBox)this.GVList.Rows[i].FindControl("tbxUpperBound");
                    item.UpperBound = WebUtitlity.InputText(tbxUpperBound.Text, 50).Trim();

                    TextBox tbxTarget = (TextBox)this.GVList.Rows[i].FindControl("tbxTarget");
                    item.Target = WebUtitlity.InputText(tbxTarget.Text, 50).Trim();

                    item.LastUpdateDate = DateTime.Now;
                    item.LastUpdatedBy = Page.User.Identity.Name;

                    items.Add(item);
                }
            }

            try
            {
                IFBDataRangeService.Save(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}
