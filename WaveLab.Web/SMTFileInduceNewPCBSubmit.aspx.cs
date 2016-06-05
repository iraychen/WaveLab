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
using WaveLab.Service.Utility;

namespace WaveLab.Web
{
    public partial class SMTFileInduceNewPCBSubmit : CommonPage
    {
        private string ModuleTypeId, pcb,newPCB,comments;
        private ISYSModuleTypeService SYSModuleTypeService;
        private ISMTFileInduceService SMTFileInduceService;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            SMTFileInduceService = (ISMTFileInduceService)cxt.GetObject("SV.SMTFileInduceService");

            ModuleTypeId = Request.QueryString["ModuleTypeId"];
            pcb = Request.QueryString["pcb"];
            newPCB = Request.QueryString["newpcb"];
            comments = Request.QueryString["comments"];
            if (!Page.IsPostBack)
            {
                this.lblSYSModuleTypeInfo.Text = SYSModuleTypeService.GetDetail(ModuleTypeId).ModuleTypeDesc;
                this.lblPCBInfo.Text = pcb;
                this.lblNewPCBInfo.Text = newPCB;
                this.lblCommentsInfo.Text = comments;
                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "material_code";
                }
                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "asc";
                }
                BindResult();
                this.btnSubmit.Attributes.Add("onclick", "return confirm(\""+this.GetLocalResourceObject("confirmSubmitMsg").ToString()+"\")");
            }
        }

        private void BindResult()
        {
            IList<SMTFileInduceInfo> items = SMTFileInduceService.GetNewPCBItems(ModuleTypeId, pcb, newPCB, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.GVList.Visible = false;
                this.btnSubmit.Visible = false;
                this.lblRecCount.Text = this.GetLocalResourceObject("noRecordsMsg").ToString();
            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;
                this.btnSubmit.Visible = true;
                this.GVList.DataSource = items;
                this.GVList.DataBind();
                SYSModuleTypeInfo SYSModuleTypeInfo = SYSModuleTypeService.GetDetail(ModuleTypeId);
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

        protected void btnbtnSubmit_Click(object sender, EventArgs e)
        {
            bool isExists = false;
            int i, count;
            count = this.GVList.Rows.Count;
            string materialCode, materialDesc;
          
            for (i = 0; i < count; i++)
            {
                materialCode = WebUtitlity.InputText(this.GVList.Rows[i].Cells[0].Text.Trim(), 13);
                materialDesc = WebUtitlity.InputText(this.GVList.Rows[i].Cells[1].Text.Trim(), 40);
                if (SMTFileInduceService.CheckExists(materialCode, materialDesc, newPCB) == true)
                {
                    isExists = true;
                    break;
                }
            }
            if (isExists == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg").ToString() + "');</script>");
                return;
            }

            SMTPCBPriorityItemInfo pcbPriorityItem = new SMTPCBPriorityItemInfo();
            pcbPriorityItem.PCB = pcb;
            pcbPriorityItem.PriorityItem = 'N';
            pcbPriorityItem.LastUpdateDate = DateTime.Now;
            pcbPriorityItem.LastUpdatedBy = Page.User.Identity.Name;

            SMTPCBPriorityItemInfo newPCBPriorityItem = new SMTPCBPriorityItemInfo();
            newPCBPriorityItem.PCB = newPCB;
            newPCBPriorityItem.PriorityItem = 'Y';
            newPCBPriorityItem.LastUpdateDate = DateTime.Now;
            newPCBPriorityItem.LastUpdatedBy = Page.User.Identity.Name;
            newPCBPriorityItem.CreationDate = DateTime.Now;
            newPCBPriorityItem.CreatedBy = Page.User.Identity.Name;

            SYSModuleTypeInfo ModuleTypeItem = SYSModuleTypeService.GetDetail(ModuleTypeId);
            IList<SMTFileInduceInfo> items = new List<SMTFileInduceInfo>();
            string PCBKey;

            for (i = 0; i < count; i++)
            {
                PCBKey = WebUtitlity.InputText(this.GVList.Rows[i].Cells[2].Text.Trim(), 40);
                if (string.Equals(PCBKey, newPCB) == true)
                {
                    SMTFileInduceInfo item = new SMTFileInduceInfo();
                    item.MaterialCode = WebUtitlity.InputText(this.GVList.Rows[i].Cells[0].Text.Trim(), 13);
                    item.MaterialDesc = WebUtitlity.InputText(this.GVList.Rows[i].Cells[1].Text.Trim(), 40);
                    item.PCB = newPCB;
                    item.LastUpdateDate = DateTime.Now;
                    item.LastUpdatedBy = Page.User.Identity.Name;
                    item.CreationDate = DateTime.Now;
                    item.CreatedBy = Page.User.Identity.Name;

                    item.ModuleTypeItem = ModuleTypeItem;
                    item.GenBoard = WebUtitlity.InputText(this.GVList.Rows[i].Cells[3].Text.Trim(), 50);
                    item.GenBoardDN = WebUtitlity.InputText(this.GVList.Rows[i].Cells[4].Text.Trim(), 50);
                    item.GenBoardDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[5].Text.Trim(), 2);
                    item.SpeBoard = WebUtitlity.InputText(this.GVList.Rows[i].Cells[6].Text.Trim(), 50);
                    item.SpeBoardDN = WebUtitlity.InputText(this.GVList.Rows[i].Cells[7].Text.Trim(), 50);
                    item.SpeBoardDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[8].Text.Trim(), 2);
                    item.SMTFabricationDN = WebUtitlity.InputText(this.GVList.Rows[i].Cells[9].Text.Trim(), 50);
                    item.SMTFabricationDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[10].Text.Trim(), 2);

                    item.ComponentPart = WebUtitlity.InputText(this.GVList.Rows[i].Cells[11].Text.Trim(), 50);
                    item.ComponentPartDN = WebUtitlity.InputText(this.GVList.Rows[i].Cells[12].Text.Trim(), 50);
                    item.ComponentPartDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[13].Text.Trim(), 2);
                    item.GroupPart = WebUtitlity.InputText(this.GVList.Rows[i].Cells[14].Text.Trim(), 50);
                    item.GroupPartDN = WebUtitlity.InputText(this.GVList.Rows[i].Cells[15].Text.Trim(), 50);
                    item.GroupPartDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[16].Text.Trim(),2);
                    item.BondingFabricationDN = WebUtitlity.InputText(this.GVList.Rows[i].Cells[17].Text.Trim(), 50);
                    item.BondingFabricationDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[18].Text.Trim(),2);

                    item.Comments = WebUtitlity.InputText(comments, 100);
                    items.Add(item);
                }
            }
            try
            {
                SMTFileInduceService.SaveNewPCB(pcbPriorityItem, newPCBPriorityItem, items);
            }
            catch (Exception ex)
            {
                throw ex;
            }         
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("submitSuccessMsg").ToString() + "');goToCtrPage();</script>");
        }

        protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SMTFileInduceNewPCB.aspx?1=1");
            builder.Append("&ModuleTypeId=" + ModuleTypeId);
            builder.Append("&pcb=" + pcb);
            builder.Append("&backlink=" + System.Web.HttpUtility.UrlEncode(Request.QueryString["backlink"].ToString()));
            Response.Redirect(builder.ToString());
        }

    }
}
