using System;
using System.Collections.Generic;
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
using WaveLab.Service.Utility;

namespace WaveLab.Web
{
    public partial class UpdateCPDVS : CommonPage
    {
        private ISMTFileInduceService SMTFileInduceService;
  
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SMTFileInduceService = (ISMTFileInduceService)cxt.GetObject("SV.SMTFileInduceService");

            if (!Page.IsPostBack)
            {
                this.btnUpdate.Attributes.Add("onclick", "return confirm('"+this.GetLocalResourceObject("confirmUpdateMsg").ToString()+"')");
                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "a.material_code,a.material_desc,a.pcb";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "asc";
                }
                BindResult();
            }
        }

        private void BindResult()
        {
            IList<SMTFileInduceNewDVSInfo> items = SMTFileInduceService.GetNewDVSItems(ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.btnUpdate.Visible = false;
                this.GVList.Visible = false;
                this.lblRecCount.Text = this.GetLocalResourceObject("noRecordsMsg").ToString();
               
            }
            else
            {
                this.btnUpdate.Visible = true;
                this.GVList.Visible = true;
                this.GVList.DataSource = items;
                this.GVList.DataBind();
                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "total").ToString() + this.GVList.Rows.Count + " " + this.GetGlobalResourceObject("globalResource", "records").ToString();
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                if (string.Equals(DataBinder.Eval(e.Row.DataItem, "NewGenBoardDVS"), DataBinder.Eval(e.Row.DataItem, "GenBoardDVS")) == false)
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Blue;
                }
                if (string.Equals(DataBinder.Eval(e.Row.DataItem, "NewSpeBoardDVS"), DataBinder.Eval(e.Row.DataItem, "SpeBoardDVS")) == false)
                {
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.Blue;
                }

                if (string.Equals(DataBinder.Eval(e.Row.DataItem, "NewSMTFabricationDVS"), DataBinder.Eval(e.Row.DataItem, "SMTFabricationDVS")) == false)
                {
                    e.Row.Cells[14].ForeColor = System.Drawing.Color.Blue;
                }

                if (string.Equals(DataBinder.Eval(e.Row.DataItem, "NewComponentPartDVS"), DataBinder.Eval(e.Row.DataItem, "ComponentPartDVS")) == false)
                {
                    e.Row.Cells[18].ForeColor = System.Drawing.Color.Blue;
                }

                if (string.Equals(DataBinder.Eval(e.Row.DataItem, "NewGroupPartDVS"), DataBinder.Eval(e.Row.DataItem, "GroupPartDVS")) == false)
                {
                    e.Row.Cells[22].ForeColor = System.Drawing.Color.Blue;
                }

                if (string.Equals(DataBinder.Eval(e.Row.DataItem, "NewBondingFabricationDVS"), DataBinder.Eval(e.Row.DataItem, "BondingFabricationDVS")) == false)
                {
                    e.Row.Cells[25].ForeColor = System.Drawing.Color.Blue;
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int count = this.GVList.Rows.Count;
            IList<SMTFileInduceInfo> items = new List<SMTFileInduceInfo>();

            string genBoardDVS, newGenBoardDVS, speBoardDVS, newSpeBoardDVS, smtFabricationDVS, newSMTFabricationDVS;
            string componentPartDVS, newComponentPartDVS, groupPartDVS, newGroupPartDVS, bondingFabricationDVS, newBondingFabricationDVS;

            for (int i = 0; i < count; i++)
            {
                SMTFileInduceInfo item = new SMTFileInduceInfo();
                item.MaterialCode = this.GVList.DataKeys[i].Values["materialcode"].ToString();
                item.MaterialDesc = this.GVList.DataKeys[i].Values["materialdesc"].ToString();
                item.PCB = this.GVList.DataKeys[i].Values["pcb"].ToString();

                item.LastUpdateDate = DateTime.Now;
                item.LastUpdatedBy = Page.User.Identity.Name;

                genBoardDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[6].Text.Trim(), 50);
                newGenBoardDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[7].Text.Trim(), 50);

                speBoardDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[10].Text.Trim(), 50);
                newSpeBoardDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[11].Text.Trim(), 50);

                smtFabricationDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[13].Text.Trim(), 50);
                newSMTFabricationDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[14].Text.Trim(), 50);

                componentPartDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[17].Text.Trim(), 50);
                newComponentPartDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[18].Text.Trim(), 50);

                groupPartDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[21].Text.Trim(), 50);
                newGroupPartDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[22].Text.Trim(), 50);

                bondingFabricationDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[24].Text.Trim(), 50);
                newBondingFabricationDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[25].Text.Trim(), 50);

                if (string.Equals(genBoardDVS, newGenBoardDVS) == true)
                {
                    item.GenBoardDVS = genBoardDVS;
                }
                else
                {
                    item.GenBoardDVS = newGenBoardDVS;
                }

                if (string.Equals(speBoardDVS, newSpeBoardDVS) == true)
                {
                    item.SpeBoardDVS = speBoardDVS;
                }
                else
                {
                    item.SpeBoardDVS = newSpeBoardDVS;
                }

                if (string.Equals(smtFabricationDVS, newSMTFabricationDVS) == true)
                {
                    item.SMTFabricationDVS = smtFabricationDVS;
                }
                else
                {
                    item.SMTFabricationDVS = newSMTFabricationDVS;
                }


                if (string.Equals(componentPartDVS, newComponentPartDVS) == true)
                {
                    item.ComponentPartDVS = componentPartDVS;
                }
                else
                {
                    item.ComponentPartDVS = newComponentPartDVS;
                }

                if (string.Equals(groupPartDVS, newGroupPartDVS) == true)
                {
                    item.GroupPartDVS = groupPartDVS;
                }
                else
                {
                    item.GroupPartDVS = newGroupPartDVS;
                }

                if (string.Equals(bondingFabricationDVS, newBondingFabricationDVS) == true)
                {
                    item.BondingFabricationDVS = bondingFabricationDVS;
                }
                else
                {
                    item.BondingFabricationDVS = newBondingFabricationDVS;
                }

                items.Add(item);
            }
            try
            {
                SMTFileInduceService.UpdateNewDVS(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.btnUpdate.Visible = false;
            this.btnView.Visible = true;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("updateSuccessMsg").ToString() + "');</script>");
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMTFileInduceCtl.aspx");
        }

 
    }
}
