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
    public partial class RptSMTFileInduceList : CommonPage
    {
        string ModuleTypeId,materialCode, materialDesc, PCB;
        private ISMTFileInduceService SMTFileInduceService;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SMTFileInduceService = (ISMTFileInduceService)cxt.GetObject("SV.SMTFileInduceService");

            ModuleTypeId = Request.QueryString["ModuleTypeId"];
            materialCode = Request.QueryString["materialcode"];
            materialDesc = Request.QueryString["materialdesc"];
            PCB = Request.QueryString["pcb"];
          
            if (!Page.IsPostBack)
            {
                if (SMTFileInduceService.CheckExists(ModuleTypeId, materialCode, materialDesc, PCB) == false)
                {
                    this.lblRecCount.Visible = true;
                    this.tblResult.Visible = false;

                    this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString();
                }
                else
                {
                    SMTFileInduceInfo entity = SMTFileInduceService.QueryReport(ModuleTypeId, materialCode, materialDesc, PCB);
                    this.lblRecCount.Visible = false;
                    this.tblResult.Visible = true;

                    this.lblSYSModuleTypeInfo.Text = entity.ModuleTypeItem.ModuleTypeDesc;
                    this.lblMaterialCodeInfo.Text = entity.MaterialCode;
                    this.lblMaterialDescInfo.Text = entity.MaterialDesc;
                    this.lblPCBInfo.Text = entity.PCB;
                   
                    this.lblGenBoardInfo.Text = entity.GenBoard;
                    this.lblGenBoardDNInfo.Text = entity.GenBoardDN;
                    this.lblGenBoardDVSInfo.Text = entity.GenBoardDVS;
                    this.lblSpeBoardInfo.Text = entity.SpeBoard;
                    this.lblSpeBoardDNInfo.Text = entity.SpeBoardDN;
                    this.lblSpeBoardDVSInfo.Text = entity.SpeBoardDVS;
                    this.lblSMTFabricationDNInfo.Text = entity.SMTFabricationDN;
                    this.lblSMTFabricationDVSInfo.Text = entity.SMTFabricationDVS;

                    this.lblComponentPartInfo.Text = entity.ComponentPart;
                    this.lblComponentPartDNInfo.Text = entity.ComponentPartDN;
                    this.lblComponentPartDVSInfo.Text = entity.ComponentPartDVS;
                    this.lblGroupPartInfo.Text = entity.GroupPart;
                    this.lblGroupPartDNInfo.Text = entity.GroupPartDN;
                    this.lblGroupPartDVSInfo.Text = entity.GroupPartDVS;
                    this.lblBondingFabricationDNInfo.Text = entity.BondingFabricationDN;
                    this.lblBondingFabricationDVSInfo.Text = entity.BondingFabricationDVS;
                }
               
            }
        }


    }
}
