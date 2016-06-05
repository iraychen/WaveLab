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
using System.Web.UI.DataVisualization.Charting;
using Spring.Context;
using Spring.Context.Support;
using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class NTTxMaskView : CommonPage
    {
        private INTTxMaskService NTTxMaskService;
        private NTTxMaskInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
              IApplicationContext cxt = ContextRegistry.GetContext();
            NTTxMaskService = (INTTxMaskService)cxt.GetObject("SV.NTTxMaskService");

            int NTTxMaskId = int.Parse(Request.QueryString["NTTxMaskId"]);
            entity = NTTxMaskService.GetDetail(NTTxMaskId);
            if (!Page.IsPostBack)
            {
                LoadDtl();
            }
        }

        private void LoadDtl()
        {
       
            this.ltlModel.Text = entity.Model;
        
            this.ltlSerialNo.Text = entity.SerialNo;
            if (entity.EndTime != null)
            {
                this.ltlEndTime.Text = entity.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            this.ltlStationNo.Text = entity.StationNo;
            this.ltlChNo.Text = entity.CHNo;
            this.ltlWGNo.Text = entity.WGNo;
            this.ltlRunningTime.Text = entity.RunningTime;
           
            this.ltlAppVersion.Text = entity.AppVersion;
            this.ltlReason.Text = entity.Reason;
            if (entity.FinalFlag == 'P')
            {
                this.ltlFinalFlag.Text = "<font color='green'>PASS</font>";
            }
            else if (entity.FinalFlag == 'F')
            {
                this.ltlFinalFlag.Text = "<font color='red'>FAIL</font>";
            }
            this.ltlOperator.Text = entity.Operator;

            this.GVNTTxMask.DataSource = entity.NTTxMaskDetailItems;
            this.GVNTTxMask.DataBind();
        }
        protected void GVNTTxMask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                if (string.Equals(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MaskCheck")).ToUpper(), "FAIL") == true)
                {
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }

                Image imgBtnMaskImage = (ImageButton)e.Row.FindControl("imgbtnMaskImage");
                if (((byte[])DataBinder.Eval(e.Row.DataItem, "MaskImage")) == null)
                {
                    imgBtnMaskImage.Visible = false;
                }
            }
        }

        protected void GVNTTxMask_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (string.Equals(e.CommandName.ToString(), "Image") == true)
            {
                int rowNum = Convert.ToInt32(e.CommandArgument);
                int NTTxMaskId = Convert.ToInt32(this.GVNTTxMask.DataKeys[rowNum].Values["NTTxMaskId"]);
                string mode = Convert.ToString(this.GVNTTxMask.DataKeys[rowNum].Values["Mode"]);
                string ch = Convert.ToString(this.GVNTTxMask.DataKeys[rowNum].Values["CH"]);

                var image = (
                           from item in entity.NTTxMaskDetailItems
                           where item.NTTxMaskId == NTTxMaskId
                           && item.Mode == mode
                           && item.CH == ch
                           select item
                           ).First<NTTxMaskDetailInfo>().MaskImage;
                if (image != null)
                {
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".jpg");
                    Response.ContentType = "image/JPG";
                    Response.Flush();
                    Response.BinaryWrite((byte[])image);
                    Response.End();
                }
            }
        }
    }
}
