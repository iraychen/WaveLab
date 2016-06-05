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
    public partial class SPCStationLineLossItemEdit : CommonPage
    {
        private ISPCStationLineLossItemService SPCStationLineLossItemService;
        private int LineLossItemPK;
        private SPCStationLineLossItemInfo entity;
        private ISYSSecurityMasterService SYSSecurityMasterService;
        private bool AllowManage;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCStationLineLossItemService = (ISPCStationLineLossItemService)cxt.GetObject("SV.SPCStationLineLossItemService");
            SYSSecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");

            LineLossItemPK = int.Parse(Request.QueryString["LineLossItemPK"]);
            entity = SPCStationLineLossItemService.Get(LineLossItemPK);
            AllowManage = SYSSecurityMasterService.CheckPerm(Page.User.Identity.Name, "ManageSPC");
            if (!Page.IsPostBack)
            {
                this.btnViewLog.Visible = AllowManage;
                LoadData();
            }
        }

        private void LoadData()
        {
            this.tbxStationNo.Text = entity.StationNo;
            this.tbxCHNo.Text = entity.CHNo;
            this.tbxFrequencyBand.Text = entity.FrequencyBand;
            this.tbxItem.Text = entity.Item;
            this.tbxMachineInfo.Text = entity.MachineInfo;
            this.tbxModifiedLog.Text = entity.ModifiedLog;
            if (AllowManage == false)
            {
                this.LCL_XRow.Visible = false;
                this.UCL_XRow.Visible = false;
                this.LCL_MRRow.Visible = false;
                this.UCL_MRRow.Visible = false;
            }
            else
            {
                if (entity.LCL_X != null)
                {
                    this.tbxLCL_X.Text = String.Format("{0:f2}", entity.LCL_X);
                }
                if (entity.UCL_X != null)
                {
                    this.tbxUCL_X.Text = String.Format("{0:f2}", entity.UCL_X);
                }
                if (entity.LCL_MR != null)
                {
                    this.tbxLCL_MR.Text = String.Format("{0:f2}", entity.LCL_MR);
                }
                if (entity.UCL_MR != null)
                {
                    this.tbxUCL_MR.Text = String.Format("{0:f2}", entity.UCL_MR);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SPCStationLineLossItemService.CheckExists(this.tbxStationNo.Text.Trim().ToUpper(),this.tbxCHNo.Text.Trim(),
                this.tbxFrequencyBand.Text.Trim().ToUpper(), this.tbxItem.Text.Trim().ToUpper(), LineLossItemPK) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("ExistsMsg") + "');</script>");
                return;
            }

            entity.StationNo = this.tbxStationNo.Text.Trim().ToUpper();
            entity.CHNo = this.tbxCHNo.Text.Trim();
            entity.FrequencyBand = this.tbxFrequencyBand.Text.Trim().ToUpper();
            entity.Item = this.tbxItem.Text.Trim().ToUpper();
            entity.MachineInfo = this.tbxMachineInfo.Text.Trim();
            entity.ModifiedLog = this.tbxModifiedLog.Text.Trim();

            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();

            if (AllowManage == true)
            {
                if (this.tbxLCL_X.Text.Trim().Length == 0)
                {
                    entity.LCL_X = null;
                }
                else
                {
                    entity.LCL_X = Convert.ToDouble(this.tbxLCL_X.Text.Trim());
                }
                if (this.tbxUCL_X.Text.Trim().Length == 0)
                {
                    entity.UCL_X = null;
                }
                else
                {
                    entity.UCL_X = Convert.ToDouble(this.tbxUCL_X.Text.Trim());
                }
                if (this.tbxLCL_MR.Text.Trim().Length == 0)
                {
                    entity.LCL_MR = null;
                }
                else
                {
                    entity.LCL_MR = Convert.ToDouble(this.tbxLCL_MR.Text.Trim());
                }
                if (this.tbxUCL_MR.Text.Trim().Length == 0)
                {
                    entity.UCL_MR = null;
                }
                else
                {
                    entity.UCL_MR = Convert.ToDouble(this.tbxUCL_MR.Text.Trim());
                }
            }
            try
            {
                SPCStationLineLossItemService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "updateSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }

        protected void btnViewLog_Click(object sender, EventArgs e)
        {
            Response.Redirect("SPCStationLineLossItemLog.aspx?LineLossItemPK=" + LineLossItemPK);
        }
    }
}
