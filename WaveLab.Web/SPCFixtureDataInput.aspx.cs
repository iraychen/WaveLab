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
    public partial class SPCFixtureDataInput :  CommonPage
    {
        private int FixtureItemPK;
        private SPCFixtureItemInfo FixtureItem;
        private ISPCFixtureItemService SPCFixtureItemService;
        private ISPCFixtureDataInputService SPCFixtureDataInputService;
        private ISPCFixtureReturnLossService SPCFixtureReturnLossService;
        private ISPCFixtureInsertionLossService SPCFixtureInsertionLossService;
        private ISPCEmailContainerService SPCEmailContainerService;
        private ISPCProjectService SPCProjectService;
        private SPCProjectInfo SPCProject;
        private int maxInput;
        private const string ACTION = "SPCFixtureInputEdit";
        private ISYSRoleService RoleService;


        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCFixtureItemService = (ISPCFixtureItemService)cxt.GetObject("SV.SPCFixtureItemService");
            SPCFixtureDataInputService = (ISPCFixtureDataInputService)cxt.GetObject("SV.SPCFixtureDataInputService"); 
            SPCFixtureReturnLossService = (ISPCFixtureReturnLossService)cxt.GetObject("SV.SPCFixtureReturnLossService");
            SPCFixtureInsertionLossService = (ISPCFixtureInsertionLossService)cxt.GetObject("SV.SPCFixtureInsertionLossService");
            SPCEmailContainerService = (ISPCEmailContainerService)cxt.GetObject("SV.SPCEmailContainerService");
            SPCProjectService = (ISPCProjectService)cxt.GetObject("SV.SPCProjectService");
            RoleService = (ISYSRoleService)cxt.GetObject("SV.SYSRoleService");


            FixtureItemPK = int.Parse(Request.QueryString["FixtureItemPK"]);
            FixtureItem = SPCFixtureItemService.Get(FixtureItemPK);
            maxInput = SPCFixtureDataInputService.GetMaxNoOfTimes(FixtureItemPK);
            SPCProject = SPCProjectService.Get("06");
            if (!Page.IsPostBack)
            {
                this.ltlFixture.Text = FixtureItem.Fixture;
                this.ltlFrequencyBand.Text = FixtureItem.FrequencyBand;
                this.ltlCH.Text = FixtureItem.CH;
                Hashtable hashtable=new Hashtable();
                hashtable.Add("Fixture_Item_PK",FixtureItemPK);


                IList<WaveLab.Model.SPCFixtureDataInputInfo> items = SPCFixtureDataInputService.Query(hashtable, "No_Of_Times", "Asc");
                this.GVList.DataSource = items;
                this.GVList.DataBind();
                this.GVList.Columns[4].Visible = RoleService.GetActionACRight(User.Identity.Name, ACTION);
                this.tbxTestingDate.Text = DateTime.Now.ToString("yyyy-MM-dd");


                this.btnCancel.Attributes.Add("onclick", "javascript:self.close()");
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtEdit = (LinkButton)e.Row.FindControl("lbtEdit");
                if(maxInput!=int.Parse(this.GVList.DataKeys[e.Row.RowIndex].Values["NoOfTimes"].ToString()))
                {
                    lbtEdit.Visible = false;
                } 
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region Input Data
                if (this.Mode.Value.Length == 0)
                {
                    if (SPCFixtureDataInputService.CheckExists(this.FixtureItemPK, this.tbxTestingDate.Text.Trim()) == true)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("ExistsMsg") + "');</script>");
                        return;
                    }
                    WaveLab.Model.SPCFixtureDataInputInfo input = new WaveLab.Model.SPCFixtureDataInputInfo();
                    input.FixtureItemPK = FixtureItem.FixtureItemPK;
                    input.TestingDate = DateTime.ParseExact(this.tbxTestingDate.Text.Trim().ToUpper(), "yyyy-MM-dd", null);
                    input.ReturnLossValue = Convert.ToDouble(this.tbxReturnLossValue.Text.Trim());
                    input.InsertionLossValue = Convert.ToDouble(this.tbxInsertionLossValue.Text.Trim());
                    input.LastUpdateDate = DateTime.Now;
                    input.LastUpdatedBy = Page.User.Identity.Name.ToUpper();
                    SPCFixtureDataInputService.SaveInput(input);
                }
                else if (this.Mode.Value == "EditInput")
                {
                    WaveLab.Model.SPCFixtureDataInputInfo input = SPCFixtureDataInputService.Get(FixtureItem.FixtureItemPK, int.Parse(this.NoOfTimes_Input.Value));
                    input.TestingDate = DateTime.ParseExact(this.tbxTestingDate.Text.Trim().ToUpper(), "yyyy-MM-dd", null);
                    input.ReturnLossValue = Convert.ToDouble(this.tbxReturnLossValue.Text.Trim());
                    input.InsertionLossValue = Convert.ToDouble(this.tbxInsertionLossValue.Text.Trim());
                    input.LastUpdateDate = DateTime.Now;
                    input.LastUpdatedBy = Page.User.Identity.Name.ToUpper();
                    SPCFixtureDataInputService.UpdateInput(input);                    
                }
                #endregion

                if (SPCFixtureDataInputService.GetMaxNoOfTimes(FixtureItemPK) >= SPCProject.MinTimes)
                {
                    Hashtable hashtable = new Hashtable();
                    hashtable.Add("Fixture_Item_PK", FixtureItemPK);
                    IList<WaveLab.Model.SPCFixtureDataInputInfo> inputItems = SPCFixtureDataInputService.Query(hashtable, "No_Of_Times", "Asc");

                    if (this.Mode.Value == "EditInput")
                    {
                        SPCFixtureReturnLossService.DeleteSPC(FixtureItemPK);
                        SPCFixtureInsertionLossService.DeleteSPC(FixtureItemPK);
                    }

                    #region Return Loss
                    {
                        SPCFixtureReturnLossInfo entity = new SPCFixtureReturnLossInfo();
                        entity.FixtureItemPK = FixtureItem.FixtureItemPK;

                        IList<SPCFixtureReturnLossDetail> detailItems = new List<SPCFixtureReturnLossDetail>();
                        for (int i = 0; i < inputItems.Count; i++)
                        {
                            if (i == 0)
                            {
                                entity.DateFrom = inputItems[i].TestingDate;
                            }
                            if (i == inputItems.Count - 1)
                            {
                                entity.DateTo = inputItems[i].TestingDate;
                            }
                            SPCFixtureReturnLossDetail detailItem = new SPCFixtureReturnLossDetail();
                            detailItem.NoOfTimes = inputItems[i].NoOfTimes;
                            detailItem.TestingDate = inputItems[i].TestingDate;
                            detailItem.TestingValue = inputItems[i].ReturnLossValue;
                            if (i == 0)
                            {
                                detailItem.MR = null;
                            }
                            else
                            {
                                detailItem.MR = Math.Abs(inputItems[i].ReturnLossValue - inputItems[i - 1].ReturnLossValue);
                            }
                            detailItems.Add(detailItem);
                        }

                        int digit = 2;
                        entity.X = Math.Round(detailItems.AsEnumerable().Average(item => Convert.ToDouble(item.TestingValue)), digit);

                        entity.R = Math.Round(detailItems.AsEnumerable().Average(item => Convert.ToDouble(item.MR)), digit);

                        entity.UCL_X = Math.Round(entity.X + 2.66 * entity.R, digit);
                        entity.LCL_X = Math.Round(entity.X - 2.66 * entity.R, digit);
                        entity.CL_X = entity.X;
                        entity.UCL_R = Math.Round(3.267 * entity.R, digit);
                        entity.LCL_R = 0;
                        entity.CL_R = entity.R;

                        entity.DetailItems = detailItems;
                        entity.LastUpdateDate = DateTime.Now;
                        entity.LastUpdatedBy = Page.User.Identity.Name;
                        SPCFixtureReturnLossService.SaveSPC(entity);

                        #region Error Exists
                        int ReturnLossPK = SPCFixtureReturnLossService.GetLastestReturnLoss(FixtureItemPK).ReturnLossPK;
                        SPCFixtureReturnLossInfo data = SPCFixtureReturnLossService.Get(ReturnLossPK);

                        double UCL_X = data.UCL_X;
                        double CL_UCL_BC_X = double.MinValue;
                        double CL_UCL_AB_X = double.MinValue;
                        double CL_X = entity.X;
                        double LCL_CL_BC_X = double.MinValue;
                        double LCL_CL_AB_X = double.MinValue;
                        double LCL_X = data.LCL_X;

                        double LCL_CL_X_Interval = Math.Round((CL_X - LCL_X) / 3, digit);
                        LCL_CL_AB_X = CL_X - LCL_CL_X_Interval * 2;
                        LCL_CL_BC_X = CL_X - LCL_CL_X_Interval;

                        double CL_UCL_X_Interval = Math.Round((UCL_X - CL_X) / 3, digit);
                        CL_UCL_BC_X = CL_X + CL_UCL_X_Interval;
                        CL_UCL_AB_X = CL_X + CL_UCL_X_Interval * 2;


                        bool errorExists = false;
                        for (int i = 0; i < data.DetailItems.Count; i++)
                        {
                            double xVal = data.DetailItems[i].NoOfTimes;
                            double yVal = data.DetailItems[i].TestingValue;
                            #region 准则1---1点落在A区以外点出界就判异
                            if (yVal < LCL_X || yVal > UCL_X)
                            {
                                errorExists = true;
                                continue;
                            }
                            #endregion

                            #region 准则2---连续9点落在中心线同一侧
                            if (i >= 8)
                            {
                                double minval = CL_X;
                                double maxval = CL_X;
                                for (int j = i - 8; j <= i; j++)
                                {
                                    if (data.DetailItems[j].TestingValue > CL_X)
                                    {
                                        maxval = data.DetailItems[j].TestingValue;
                                    }
                                    if (data.DetailItems[j].TestingValue < CL_X)
                                    {
                                        minval = data.DetailItems[j].TestingValue;
                                    }
                                }
                                if (minval == CL_X || maxval == CL_X)
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }
                            #endregion

                            #region 准则3---连续6点递增或递减
                            if (i >= 5)
                            {
                                if ((data.DetailItems[i].TestingValue > data.DetailItems[i - 1].TestingValue &&
                                    data.DetailItems[i - 1].TestingValue > data.DetailItems[i - 2].TestingValue &&
                                    data.DetailItems[i - 2].TestingValue > data.DetailItems[i - 3].TestingValue &&
                                    data.DetailItems[i - 3].TestingValue > data.DetailItems[i - 4].TestingValue &&
                                    data.DetailItems[i - 4].TestingValue > data.DetailItems[i - 5].TestingValue) ||
                                    (data.DetailItems[i].TestingValue < data.DetailItems[i - 1].TestingValue &&
                                    data.DetailItems[i - 1].TestingValue < data.DetailItems[i - 2].TestingValue &&
                                    data.DetailItems[i - 2].TestingValue < data.DetailItems[i - 3].TestingValue &&
                                    data.DetailItems[i - 3].TestingValue < data.DetailItems[i - 4].TestingValue &&
                                    data.DetailItems[i - 4].TestingValue < data.DetailItems[i - 5].TestingValue))
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }
                            #endregion

                            #region 准则4---连续14点相邻点上下交替
                            if (i >= 13)
                            {
                                if ((data.DetailItems[i].TestingValue > data.DetailItems[i - 1].TestingValue &&
                                        data.DetailItems[i - 1].TestingValue < data.DetailItems[i - 2].TestingValue &&
                                        data.DetailItems[i - 2].TestingValue > data.DetailItems[i - 3].TestingValue &&
                                        data.DetailItems[i - 3].TestingValue < data.DetailItems[i - 4].TestingValue &&
                                        data.DetailItems[i - 4].TestingValue > data.DetailItems[i - 5].TestingValue &&
                                        data.DetailItems[i - 5].TestingValue < data.DetailItems[i - 6].TestingValue &&
                                        data.DetailItems[i - 6].TestingValue > data.DetailItems[i - 7].TestingValue &&
                                        data.DetailItems[i - 7].TestingValue < data.DetailItems[i - 8].TestingValue &&
                                        data.DetailItems[i - 8].TestingValue > data.DetailItems[i - 9].TestingValue &&
                                        data.DetailItems[i - 9].TestingValue < data.DetailItems[i - 10].TestingValue &&
                                        data.DetailItems[i - 10].TestingValue > data.DetailItems[i - 11].TestingValue &&
                                        data.DetailItems[i - 11].TestingValue < data.DetailItems[i - 12].TestingValue &&
                                        data.DetailItems[i - 12].TestingValue > data.DetailItems[i - 13].TestingValue)
                                    ||
                                    (data.DetailItems[i].TestingValue < data.DetailItems[i - 1].TestingValue &&
                                        data.DetailItems[i - 1].TestingValue > data.DetailItems[i - 2].TestingValue &&
                                        data.DetailItems[i - 2].TestingValue < data.DetailItems[i - 3].TestingValue &&
                                        data.DetailItems[i - 3].TestingValue > data.DetailItems[i - 4].TestingValue &&
                                        data.DetailItems[i - 4].TestingValue < data.DetailItems[i - 5].TestingValue &&
                                        data.DetailItems[i - 5].TestingValue > data.DetailItems[i - 6].TestingValue &&
                                        data.DetailItems[i - 6].TestingValue < data.DetailItems[i - 7].TestingValue &&
                                        data.DetailItems[i - 7].TestingValue > data.DetailItems[i - 8].TestingValue &&
                                        data.DetailItems[i - 8].TestingValue < data.DetailItems[i - 9].TestingValue &&
                                        data.DetailItems[i - 9].TestingValue > data.DetailItems[i - 10].TestingValue &&
                                        data.DetailItems[i - 10].TestingValue < data.DetailItems[i - 11].TestingValue &&
                                        data.DetailItems[i - 11].TestingValue > data.DetailItems[i - 12].TestingValue &&
                                        data.DetailItems[i - 12].TestingValue < data.DetailItems[i - 13].TestingValue))
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }

                            #endregion

                            #region  准则5---连续3点中有2点落在中心线同一侧的B区以外
                            if (i >= 2)
                            {

                                if (
                                    ((data.DetailItems[i - 2].TestingValue < LCL_CL_AB_X && data.DetailItems[i - 1].TestingValue < LCL_CL_AB_X) ||
                                    (data.DetailItems[i - 2].TestingValue < LCL_CL_AB_X && data.DetailItems[i].TestingValue < LCL_CL_AB_X) ||
                                    (data.DetailItems[i - 1].TestingValue < LCL_CL_AB_X && data.DetailItems[i].TestingValue < LCL_CL_AB_X)) ||
                                    ((data.DetailItems[i - 2].TestingValue > CL_UCL_AB_X && data.DetailItems[i - 1].TestingValue > CL_UCL_AB_X) ||
                                    (data.DetailItems[i - 2].TestingValue > CL_UCL_AB_X && data.DetailItems[i].TestingValue > CL_UCL_AB_X) ||
                                    (data.DetailItems[i - 1].TestingValue > CL_UCL_AB_X && data.DetailItems[i].TestingValue > CL_UCL_AB_X))
                                   )
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }

                            #endregion

                            #region  准则6---连续5点中有4点落在中心线同一侧的C区以外
                            if (i >= 4)
                            {
                                IList<int> items = new List<int>();
                                int itemcount = 0;
                                for (int j = i - 4; j <= i; j++)
                                {
                                    if (data.DetailItems[j].TestingValue < LCL_CL_BC_X)
                                    {
                                        items.Add(1);
                                    }
                                    else
                                    {
                                        items.Add(0);
                                    }
                                }
                                foreach (int item in items)
                                {
                                    if (item == 1)
                                    {
                                        itemcount++;
                                    }
                                }
                                if (itemcount >= 4)
                                {
                                    errorExists = true;
                                    continue;
                                }

                                items.Clear();
                                itemcount = 0;

                                for (int j = i - 4; j <= i; j++)
                                {
                                    if (data.DetailItems[j].TestingValue > CL_UCL_BC_X)
                                    {
                                        items.Add(1);
                                    }
                                    else
                                    {
                                        items.Add(0);
                                    }
                                }
                                foreach (int item in items)
                                {
                                    if (item == 1)
                                    {
                                        itemcount++;
                                    }
                                }
                                if (itemcount >= 4)
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }
                            #endregion

                            #region  准则7---连续15点C区中心线上下
                            if (i >= 14)
                            {
                                IList<int> items = new List<int>();
                                int itemcount = 0;
                                for (int j = i - 14; j <= i; j++)
                                {
                                    if (data.DetailItems[j].TestingValue > LCL_CL_BC_X && data.DetailItems[j].TestingValue < CL_UCL_BC_X)
                                    {
                                        items.Add(1);
                                    }
                                    else
                                    {
                                        items.Add(0);
                                    }
                                }
                                foreach (int item in items)
                                {
                                    if (item == 1)
                                    {
                                        itemcount++;
                                    }
                                }
                                if (itemcount >= 15)
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }
                            #endregion

                            #region  准则8---连续8点在中心线两侧，但无一在C区中
                            if (i >= 7)
                            {
                                IList<int> items = new List<int>();
                                int itemcount = 0;
                                for (int j = i - 7; j <= i; j++)
                                {
                                    if (data.DetailItems[j].TestingValue < LCL_CL_BC_X || data.DetailItems[j].TestingValue > CL_UCL_BC_X)
                                    {
                                        items.Add(1);
                                    }
                                    else
                                    {
                                        items.Add(0);
                                    }
                                }
                                foreach (int item in items)
                                {
                                    if (item == 1)
                                    {
                                        itemcount++;
                                    }
                                }
                                if (itemcount >= 8)
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }
                            #endregion
                        }

                        for (int i = 0; i < data.DetailItems.Count; i++)
                        {
                            int xVal = data.DetailItems[i].NoOfTimes;
                            double yVal = data.DetailItems[i].TestingValue;

                            if (yVal < data.LCL_R || yVal > data.UCL_R)
                            {
                                errorExists = true;
                                continue;
                            }
                        }
                        #endregion

                        #region Email To Container
                        if (errorExists == true)
                        {
                            SPCEmailContainerInfo log = new SPCEmailContainerInfo();
                            log.ProjectCode = "07";
                            log.ErrorPK = ReturnLossPK;
                            log.Subject = "SPC统计异常 - 夹具回损";

                            System.Text.StringBuilder builder = new System.Text.StringBuilder();
                            builder.Append("<table cellpadding='5'><tr><td>各位,好:</td><td></td></tr>");
                            builder.Append("<tr><td></td></tr>");
                            builder.Append("<tr><td></td><td>经过SPC统计，夹具回损发生了异常，详细信息如下：</td></tr>");
                            builder.Append("<tr><td></td><td>夹具：" + FixtureItem.Fixture + "</td></tr>");
                            builder.Append("<tr><td></td><td>频段：" + FixtureItem.FrequencyBand + "</td></tr>");
                            builder.Append("<tr><td></td><td>测试频率：" + FixtureItem.CH + "</td></tr>");
                            builder.Append("<tr><td></td><td>开始日期：" + entity.DateFrom.ToString("yyyy-MM-dd") + "</td></tr>");
                            builder.Append("<tr><td></td><td>结束日期：" + entity.DateTo.ToString("yyyy-MM-dd") + "</td></tr>");
                            builder.Append("<tr><td></td><td></td></tr>");

                            builder.Append("<tr><td></td><td></td></tr>");
                            builder.Append("<tr><td></td><td><i>请点击<a href='" + System.Configuration.ConfigurationManager.AppSettings["WebUrl"] +
                                "/SPCViewFromEmail.ashx?userId=SPCViewer&ProjectCode=" + log.ProjectCode + "&errorPK=" +
                                ReturnLossPK + "' target='_blank'><font color='blue'>这里</font></a>,即可查看异常原因.</i></td></tr>");
                            builder.Append("<tr><td></td><td></td></tr>");
                            builder.Append("<tr><td></td><td>如有任何问题，可联系质量管理部，谢谢！</td></tr>");
                            builder.Append("</table>");
                            log.Body = builder.ToString();

                            log.LastUpdateDate = DateTime.Now;
                            log.LastUpdatedBy = Page.User.Identity.Name;
                            SPCEmailContainerService.Save(log);
                        }
                        #endregion
                    }
                    #endregion

                    #region Insertion Loss
                    {
                        SPCFixtureInsertionLossInfo entity = new SPCFixtureInsertionLossInfo();
                        entity.FixtureItemPK = FixtureItem.FixtureItemPK;

                        IList<SPCFixtureInsertionLossDetail> detailItems = new List<SPCFixtureInsertionLossDetail>();
                        for (int i = 0; i < inputItems.Count; i++)
                        {
                            if (i == 0)
                            {
                                entity.DateFrom = inputItems[i].TestingDate;
                            }
                            if (i == inputItems.Count - 1)
                            {
                                entity.DateTo = inputItems[i].TestingDate;
                            }
                            SPCFixtureInsertionLossDetail detailItem = new SPCFixtureInsertionLossDetail();
                            detailItem.NoOfTimes = inputItems[i].NoOfTimes;
                            detailItem.TestingDate = inputItems[i].TestingDate;
                            detailItem.TestingValue = inputItems[i].InsertionLossValue;
                            if (i > 0)
                            {
                                detailItem.MR = Math.Abs(inputItems[i].InsertionLossValue - inputItems[i - 1].InsertionLossValue);
                            }
                            detailItems.Add(detailItem);
                        }

                        int digit = 2;
                        entity.X = Math.Round(detailItems.AsEnumerable().Average(item => Convert.ToDouble(item.TestingValue)), digit);

                        entity.R = Math.Round(detailItems.AsEnumerable().Average(item => Convert.ToDouble(item.MR)), digit);

                        entity.UCL_X = Math.Round(entity.X + 2.66 * entity.R, digit);
                        entity.LCL_X = Math.Round(entity.X - 2.66 * entity.R, digit);
                        entity.CL_X = entity.X;
                        entity.UCL_R = Math.Round(3.267 * entity.R, digit);
                        entity.LCL_R = 0;
                        entity.CL_R = entity.R;

                        entity.DetailItems = detailItems;
                        entity.LastUpdateDate = DateTime.Now;
                        entity.LastUpdatedBy = Page.User.Identity.Name;
                        SPCFixtureInsertionLossService.SaveSPC(entity);                      

                        #region Error Exists
                        int InsertionLossPK = SPCFixtureInsertionLossService.GetLastestInsertionLoss(FixtureItemPK).InsertionLossPK;
                        SPCFixtureInsertionLossInfo data = SPCFixtureInsertionLossService.Get(InsertionLossPK);

                        double UCL_X = data.UCL_X;
                        double CL_UCL_BC_X = double.MinValue;
                        double CL_UCL_AB_X = double.MinValue;
                        double CL_X = entity.X;
                        double LCL_CL_BC_X = double.MinValue;
                        double LCL_CL_AB_X = double.MinValue;
                        double LCL_X = data.LCL_X;

                        double LCL_CL_X_Interval = Math.Round((CL_X - LCL_X) / 3, digit);
                        LCL_CL_AB_X = CL_X - LCL_CL_X_Interval * 2;
                        LCL_CL_BC_X = CL_X - LCL_CL_X_Interval;

                        double CL_UCL_X_Interval = Math.Round((UCL_X - CL_X) / 3, digit);
                        CL_UCL_BC_X = CL_X + CL_UCL_X_Interval;
                        CL_UCL_AB_X = CL_X + CL_UCL_X_Interval * 2;


                        bool errorExists = false;
                        for (int i = 0; i < data.DetailItems.Count; i++)
                        {
                            double xVal = data.DetailItems[i].NoOfTimes;
                            double yVal = data.DetailItems[i].TestingValue;
                            #region 准则1---1点落在A区以外点出界就判异
                            if (yVal < LCL_X || yVal > UCL_X)
                            {
                                errorExists = true;
                                continue;
                            }
                            #endregion

                            #region 准则2---连续9点落在中心线同一侧
                            if (i >= 8)
                            {
                                double minval = CL_X;
                                double maxval = CL_X;
                                for (int j = i - 8; j <= i; j++)
                                {
                                    if (data.DetailItems[j].TestingValue > CL_X)
                                    {
                                        maxval = data.DetailItems[j].TestingValue;
                                    }
                                    if (data.DetailItems[j].TestingValue < CL_X)
                                    {
                                        minval = data.DetailItems[j].TestingValue;
                                    }
                                }
                                if (minval == CL_X || maxval == CL_X)
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }
                            #endregion

                            #region 准则3---连续6点递增或递减
                            if (i >= 5)
                            {
                                if ((data.DetailItems[i].TestingValue > data.DetailItems[i - 1].TestingValue &&
                                    data.DetailItems[i - 1].TestingValue > data.DetailItems[i - 2].TestingValue &&
                                    data.DetailItems[i - 2].TestingValue > data.DetailItems[i - 3].TestingValue &&
                                    data.DetailItems[i - 3].TestingValue > data.DetailItems[i - 4].TestingValue &&
                                    data.DetailItems[i - 4].TestingValue > data.DetailItems[i - 5].TestingValue) ||
                                    (data.DetailItems[i].TestingValue < data.DetailItems[i - 1].TestingValue &&
                                    data.DetailItems[i - 1].TestingValue < data.DetailItems[i - 2].TestingValue &&
                                    data.DetailItems[i - 2].TestingValue < data.DetailItems[i - 3].TestingValue &&
                                    data.DetailItems[i - 3].TestingValue < data.DetailItems[i - 4].TestingValue &&
                                    data.DetailItems[i - 4].TestingValue < data.DetailItems[i - 5].TestingValue))
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }
                            #endregion

                            #region 准则4---连续14点相邻点上下交替
                            if (i >= 13)
                            {
                                if ((data.DetailItems[i].TestingValue > data.DetailItems[i - 1].TestingValue &&
                                        data.DetailItems[i - 1].TestingValue < data.DetailItems[i - 2].TestingValue &&
                                        data.DetailItems[i - 2].TestingValue > data.DetailItems[i - 3].TestingValue &&
                                        data.DetailItems[i - 3].TestingValue < data.DetailItems[i - 4].TestingValue &&
                                        data.DetailItems[i - 4].TestingValue > data.DetailItems[i - 5].TestingValue &&
                                        data.DetailItems[i - 5].TestingValue < data.DetailItems[i - 6].TestingValue &&
                                        data.DetailItems[i - 6].TestingValue > data.DetailItems[i - 7].TestingValue &&
                                        data.DetailItems[i - 7].TestingValue < data.DetailItems[i - 8].TestingValue &&
                                        data.DetailItems[i - 8].TestingValue > data.DetailItems[i - 9].TestingValue &&
                                        data.DetailItems[i - 9].TestingValue < data.DetailItems[i - 10].TestingValue &&
                                        data.DetailItems[i - 10].TestingValue > data.DetailItems[i - 11].TestingValue &&
                                        data.DetailItems[i - 11].TestingValue < data.DetailItems[i - 12].TestingValue &&
                                        data.DetailItems[i - 12].TestingValue > data.DetailItems[i - 13].TestingValue)
                                    ||
                                    (data.DetailItems[i].TestingValue < data.DetailItems[i - 1].TestingValue &&
                                        data.DetailItems[i - 1].TestingValue > data.DetailItems[i - 2].TestingValue &&
                                        data.DetailItems[i - 2].TestingValue < data.DetailItems[i - 3].TestingValue &&
                                        data.DetailItems[i - 3].TestingValue > data.DetailItems[i - 4].TestingValue &&
                                        data.DetailItems[i - 4].TestingValue < data.DetailItems[i - 5].TestingValue &&
                                        data.DetailItems[i - 5].TestingValue > data.DetailItems[i - 6].TestingValue &&
                                        data.DetailItems[i - 6].TestingValue < data.DetailItems[i - 7].TestingValue &&
                                        data.DetailItems[i - 7].TestingValue > data.DetailItems[i - 8].TestingValue &&
                                        data.DetailItems[i - 8].TestingValue < data.DetailItems[i - 9].TestingValue &&
                                        data.DetailItems[i - 9].TestingValue > data.DetailItems[i - 10].TestingValue &&
                                        data.DetailItems[i - 10].TestingValue < data.DetailItems[i - 11].TestingValue &&
                                        data.DetailItems[i - 11].TestingValue > data.DetailItems[i - 12].TestingValue &&
                                        data.DetailItems[i - 12].TestingValue < data.DetailItems[i - 13].TestingValue))
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }

                            #endregion

                            #region  准则5---连续3点中有2点落在中心线同一侧的B区以外
                            if (i >= 2)
                            {

                                if (
                                    ((data.DetailItems[i - 2].TestingValue < LCL_CL_AB_X && data.DetailItems[i - 1].TestingValue < LCL_CL_AB_X) ||
                                    (data.DetailItems[i - 2].TestingValue < LCL_CL_AB_X && data.DetailItems[i].TestingValue < LCL_CL_AB_X) ||
                                    (data.DetailItems[i - 1].TestingValue < LCL_CL_AB_X && data.DetailItems[i].TestingValue < LCL_CL_AB_X)) ||
                                    ((data.DetailItems[i - 2].TestingValue > CL_UCL_AB_X && data.DetailItems[i - 1].TestingValue > CL_UCL_AB_X) ||
                                    (data.DetailItems[i - 2].TestingValue > CL_UCL_AB_X && data.DetailItems[i].TestingValue > CL_UCL_AB_X) ||
                                    (data.DetailItems[i - 1].TestingValue > CL_UCL_AB_X && data.DetailItems[i].TestingValue > CL_UCL_AB_X))
                                   )
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }

                            #endregion

                            #region  准则6---连续5点中有4点落在中心线同一侧的C区以外
                            if (i >= 4)
                            {
                                IList<int> items = new List<int>();
                                int itemcount = 0;
                                for (int j = i - 4; j <= i; j++)
                                {
                                    if (data.DetailItems[j].TestingValue < LCL_CL_BC_X)
                                    {
                                        items.Add(1);
                                    }
                                    else
                                    {
                                        items.Add(0);
                                    }
                                }
                                foreach (int item in items)
                                {
                                    if (item == 1)
                                    {
                                        itemcount++;
                                    }
                                }
                                if (itemcount >= 4)
                                {
                                    errorExists = true;
                                    continue;
                                }

                                items.Clear();
                                itemcount = 0;

                                for (int j = i - 4; j <= i; j++)
                                {
                                    if (data.DetailItems[j].TestingValue > CL_UCL_BC_X)
                                    {
                                        items.Add(1);
                                    }
                                    else
                                    {
                                        items.Add(0);
                                    }
                                }
                                foreach (int item in items)
                                {
                                    if (item == 1)
                                    {
                                        itemcount++;
                                    }
                                }
                                if (itemcount >= 4)
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }
                            #endregion

                            #region  准则7---连续15点C区中心线上下
                            if (i >= 14)
                            {
                                IList<int> items = new List<int>();
                                int itemcount = 0;
                                for (int j = i - 14; j <= i; j++)
                                {
                                    if (data.DetailItems[j].TestingValue > LCL_CL_BC_X && data.DetailItems[j].TestingValue < CL_UCL_BC_X)
                                    {
                                        items.Add(1);
                                    }
                                    else
                                    {
                                        items.Add(0);
                                    }
                                }
                                foreach (int item in items)
                                {
                                    if (item == 1)
                                    {
                                        itemcount++;
                                    }
                                }
                                if (itemcount >= 15)
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }
                            #endregion

                            #region  准则8---连续8点在中心线两侧，但无一在C区中
                            if (i >= 7)
                            {
                                IList<int> items = new List<int>();
                                int itemcount = 0;
                                for (int j = i - 7; j <= i; j++)
                                {
                                    if (data.DetailItems[j].TestingValue < LCL_CL_BC_X || data.DetailItems[j].TestingValue > CL_UCL_BC_X)
                                    {
                                        items.Add(1);
                                    }
                                    else
                                    {
                                        items.Add(0);
                                    }
                                }
                                foreach (int item in items)
                                {
                                    if (item == 1)
                                    {
                                        itemcount++;
                                    }
                                }
                                if (itemcount >= 8)
                                {
                                    errorExists = true;
                                    continue;
                                }
                            }
                            #endregion
                        }

                        for (int i = 0; i < data.DetailItems.Count; i++)
                        {
                            int xVal = data.DetailItems[i].NoOfTimes;
                            double yVal = data.DetailItems[i].TestingValue;

                            if (yVal < data.LCL_R || yVal > data.UCL_R)
                            {
                                errorExists = true;
                                continue;
                            }
                        }
                        #endregion

                        #region Email To Container
                        if (errorExists == true)
                        {
                            SPCEmailContainerInfo log = new SPCEmailContainerInfo();
                            log.ProjectCode = "08";
                            log.ErrorPK = InsertionLossPK;
                            log.Subject = "SPC统计异常 - 夹具插损";

                            System.Text.StringBuilder builder = new System.Text.StringBuilder();
                            builder.Append("<table cellpadding='5'><tr><td>各位,好:</td><td></td></tr>");
                            builder.Append("<tr><td></td></tr>");
                            builder.Append("<tr><td></td><td>经过SPC统计，夹具插损发生了异常，详细信息如下：</td></tr>");
                            builder.Append("<tr><td></td><td>夹具：" + FixtureItem.Fixture + "</td></tr>");
                            builder.Append("<tr><td></td><td>频段：" + FixtureItem.FrequencyBand + "</td></tr>");
                            builder.Append("<tr><td></td><td>测试频率：" + FixtureItem.CH + "</td></tr>");
                            builder.Append("<tr><td></td><td>开始日期：" + entity.DateFrom.ToString("yyyy-MM-dd") + "</td></tr>");
                            builder.Append("<tr><td></td><td>结束日期：" + entity.DateTo.ToString("yyyy-MM-dd") + "</td></tr>");
                            builder.Append("<tr><td></td><td></td></tr>");

                            builder.Append("<tr><td></td><td></td></tr>");
                            builder.Append("<tr><td></td><td></td></tr>");
                            builder.Append("<tr><td></td><td><i>请点击<a href='" + System.Configuration.ConfigurationManager.AppSettings["WebUrl"] +
                                "/SPCViewFromEmail.ashx?userId=SPCViewer&ProjectCode=" + log.ProjectCode + "&errorPK=" +
                                InsertionLossPK + "' target='_blank'><font color='blue'>这里</font></a>,即可查看异常原因.</i></td></tr>");
                            builder.Append("<tr><td></td><td></td></tr>");
                            builder.Append("<tr><td></td><td>如有任何问题，可联系质量管理部，谢谢！</td></tr>");
                            builder.Append("</table>");
                            log.Body = builder.ToString();

                            log.LastUpdateDate = DateTime.Now;
                            log.LastUpdatedBy = Page.User.Identity.Name;
                            SPCEmailContainerService.Save(log);
                        }
                        #endregion
                    }
                    #endregion

                    SPCFixtureDataInputService.DeleteInput(FixtureItemPK, SPCProject.MaxTimes);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" +
               this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');self.location.href=self.location.toString();</script>");
        }

        protected void GVList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int NoOfTimes = int.Parse(this.GVList.DataKeys[e.NewEditIndex].Values["NoOfTimes"].ToString());
            WaveLab.Model.SPCFixtureDataInputInfo input = SPCFixtureDataInputService.Get(FixtureItemPK, NoOfTimes);
            this.Mode.Value = "EditInput";
            this.NoOfTimes_Input.Value = input.NoOfTimes.ToString();
            this.tbxTestingDate.Text = input.TestingDate.ToString("yyyy-MM-dd");
            this.tbxReturnLossValue.Text = string.Format("{0:f2}", input.ReturnLossValue);
            this.tbxInsertionLossValue.Text = string.Format("{0:f2}", input.InsertionLossValue);
            this.btnCancel.Attributes.Add("onclick", "javascript:self.location.href=sefl.location.toString()");
        }
    }
}
