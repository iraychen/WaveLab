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
using System.Net.Mail;
using Spring.Context;
using Spring.Context.Support;
using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class SPCStationLineLossInput :  CommonPage
    {
        private int LineLossItemPK;
        private int maxInput;
        private const string ACTION = "SPCStationInputEdit";
        private SPCStationLineLossItemInfo LineLossItem;
        private SPCProjectInfo SPCProject;
        private ISPCStationLineLossItemService SPCStationLineLossItemService;
        private ISPCStationLineLossService SPCStationLineLossService;
        private ISPCEmailContainerService SPCEmailContainerService;
        private ISPCProjectService SPCProjectService;
        private ISYSRoleService RoleService;

        protected void Page_Load(object sender, EventArgs e)
        {

            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCStationLineLossItemService = (ISPCStationLineLossItemService)cxt.GetObject("SV.SPCStationLineLossItemService");
            SPCStationLineLossService = (ISPCStationLineLossService)cxt.GetObject("SV.SPCStationLineLossService");
            SPCEmailContainerService = (ISPCEmailContainerService)cxt.GetObject("SV.SPCEmailContainerService");
            SPCProjectService = (ISPCProjectService)cxt.GetObject("SV.SPCProjectService");
            RoleService = (ISYSRoleService)cxt.GetObject("SV.SYSRoleService");

            LineLossItemPK = int.Parse(Request.QueryString["LineLossItemPK"]);
            LineLossItem = SPCStationLineLossItemService.Get(LineLossItemPK);
            maxInput = SPCStationLineLossService.GetMaxNoOfTimes(LineLossItemPK);
            SPCProject = SPCProjectService.Get("05");
            if (!Page.IsPostBack)
            {
                this.ltlStationNo.Text = LineLossItem.StationNo;
                this.ltlCHNo.Text = LineLossItem.CHNo;
                this.ltlFrequencyBand.Text = LineLossItem.FrequencyBand;
                this.ltlItem.Text = LineLossItem.Item;
                Hashtable hashtable=new Hashtable();
                hashtable.Add("Line_Loss_Item_PK",LineLossItemPK);
                           
              
                IList<WaveLab.Model.SPCStationLineLossInput> items = SPCStationLineLossService.Query(hashtable, "No_Of_Times", "Asc");
                this.GVList.DataSource = items;
                this.GVList.DataBind();
                this.GVList.Columns[3].Visible = RoleService.GetActionACRight(User.Identity.Name, ACTION);
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
                    if (SPCStationLineLossService.CheckExists(this.LineLossItemPK, this.tbxTestingDate.Text.Trim()) == true)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("ExistsMsg") + "');</script>");
                        return;
                    }
                    WaveLab.Model.SPCStationLineLossInput input = new WaveLab.Model.SPCStationLineLossInput();
                    input.LineLossItemPK = LineLossItem.LineLossItemPK;
                    input.TestingDate = DateTime.ParseExact(this.tbxTestingDate.Text.Trim().ToUpper(), "yyyy-MM-dd", null);
                    input.TestingValue = Convert.ToDouble(this.tbxTestingValue.Text.Trim());
                    input.LastUpdateDate = DateTime.Now;
                    input.LastUpdatedBy = Page.User.Identity.Name.ToUpper();
                    SPCStationLineLossService.SaveInput(input);
                }
                else if (this.Mode.Value == "EditInput")
                {
                    WaveLab.Model.SPCStationLineLossInput input = SPCStationLineLossService.Get(LineLossItem.LineLossItemPK, int.Parse(this.NoOfTimes_Input.Value));
                    input.TestingDate = DateTime.ParseExact(this.tbxTestingDate.Text.Trim().ToUpper(), "yyyy-MM-dd", null);
                    input.TestingValue = Convert.ToDouble(this.tbxTestingValue.Text.Trim());
                    input.LastUpdateDate = DateTime.Now;
                    input.LastUpdatedBy = Page.User.Identity.Name.ToUpper();
                    SPCStationLineLossService.UpdateInput(input); 
                }
                #endregion

                if (SPCStationLineLossService.GetMaxNoOfTimes(LineLossItemPK) >=SPCProject.MinTimes)
                {
                    if (this.Mode.Value == "EditInput")
                    {
                        SPCStationLineLossService.DeleteSPC(LineLossItemPK);
                    }

                    #region Chart
                    SPCStationLineLossInfo entity = new SPCStationLineLossInfo();
                    entity.LineLossItemPK = LineLossItem.LineLossItemPK;

                    Hashtable hashtable = new Hashtable();
                    hashtable.Add("Line_Loss_Item_PK", LineLossItemPK);
                    IList<WaveLab.Model.SPCStationLineLossInput> inputItems = SPCStationLineLossService.Query(hashtable, "No_Of_Times", "Asc");

                    IList<SPCStationLineLossDetail> detailItems = new List<SPCStationLineLossDetail>();
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
                        SPCStationLineLossDetail detailItem = new SPCStationLineLossDetail();
                        detailItem.NoOfTimes = inputItems[i].NoOfTimes;
                        detailItem.TestingDate = inputItems[i].TestingDate;
                        detailItem.TestingValue = inputItems[i].TestingValue;
                        if (i == 0)
                        {
                            detailItem.MR = null;
                        }
                        else
                        {
                            detailItem.MR = Math.Abs(inputItems[i].TestingValue - inputItems[i - 1].TestingValue);
                        }
                        detailItems.Add(detailItem);
                    }

                    int digit = 2;
                    entity.X = Math.Round(detailItems.AsEnumerable().Average(item => Convert.ToDouble(item.TestingValue)), digit);

                    entity.R = Math.Round(detailItems.AsEnumerable().Average(item => Convert.ToDouble(item.MR)), digit);

                    entity.LCL_X = (LineLossItem.LCL_X != null) ?LineLossItem.LCL_X.Value: Math.Round(entity.X - 2.66 * entity.R, digit) ;
                    entity.UCL_X = (LineLossItem.LCL_X != null) ?LineLossItem.UCL_X.Value: Math.Round(entity.X + 2.66 * entity.R, digit) ;
                   
                    entity.CL_X = entity.X;
                    entity.LCL_R = (LineLossItem.LCL_MR!= null) ?LineLossItem.LCL_MR.Value: 0 ;
                    entity.UCL_R = (LineLossItem.UCL_MR != null)? LineLossItem.UCL_MR.Value:Math.Round(3.267 * entity.R, digit) ;
                   
                    entity.CL_R = entity.R;

                    entity.DetailItems = detailItems;
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = Page.User.Identity.Name;
                    SPCStationLineLossService.SaveSPC(entity);

                    SPCStationLineLossService.DeleteInput(LineLossItemPK,SPCProject.MaxTimes);
                    #endregion

                    #region Error Exists
                    int LineLossPK = SPCStationLineLossService.GetLastestLineLoss(LineLossItemPK).LineLossPK;
                    SPCStationLineLossInfo data = SPCStationLineLossService.Get(LineLossPK);

                    double UCL_X= data.UCL_X;
                    double CL_UCL_X_X_BC_X = double.MinValue;
                    double CL_UCL_X_X_AB_X = double.MinValue;
                    double CL_X = entity.X;
                    double LCL_X_X_CL_BC_X = double.MinValue;
                    double LCL_X_X_CL_AB_X = double.MinValue;
                    double LCL_X= data.LCL_X;

                    double LCL_X_X_CL_X_Interval = Math.Round((CL_X - LCL_X) / 3, digit);
                    LCL_X_X_CL_AB_X = CL_X - LCL_X_X_CL_X_Interval * 2;
                    LCL_X_X_CL_BC_X = CL_X - LCL_X_X_CL_X_Interval;

                    double CL_UCL_X_Interval = Math.Round((UCL_X- CL_X) / 3, digit);
                    CL_UCL_X_X_BC_X = CL_X + CL_UCL_X_Interval;
                    CL_UCL_X_X_AB_X = CL_X + CL_UCL_X_Interval * 2;


                    bool errorExists=false;
                    for (int i = 0; i < data.DetailItems.Count; i++)
                    {
                        double xVal=data.DetailItems[i].NoOfTimes;
                        double yVal = data.DetailItems[i].TestingValue;
                        #region 准则1---1点落在A区以外点出界就判异
                        if (yVal < LCL_X|| yVal > UCL_X)
                        {
                            errorExists=true;
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
                                ((data.DetailItems[i - 2].TestingValue < LCL_X_X_CL_AB_X && data.DetailItems[i - 1].TestingValue < LCL_X_X_CL_AB_X) ||
                                (data.DetailItems[i - 2].TestingValue < LCL_X_X_CL_AB_X && data.DetailItems[i].TestingValue < LCL_X_X_CL_AB_X) ||
                                (data.DetailItems[i - 1].TestingValue < LCL_X_X_CL_AB_X && data.DetailItems[i].TestingValue < LCL_X_X_CL_AB_X)) ||
                                ((data.DetailItems[i - 2].TestingValue > CL_UCL_X_X_AB_X && data.DetailItems[i - 1].TestingValue > CL_UCL_X_X_AB_X) ||
                                (data.DetailItems[i - 2].TestingValue > CL_UCL_X_X_AB_X && data.DetailItems[i].TestingValue > CL_UCL_X_X_AB_X) ||
                                (data.DetailItems[i - 1].TestingValue > CL_UCL_X_X_AB_X && data.DetailItems[i].TestingValue > CL_UCL_X_X_AB_X))
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
                                if (data.DetailItems[j].TestingValue < LCL_X_X_CL_BC_X)
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
                                if (data.DetailItems[j].TestingValue > CL_UCL_X_X_BC_X)
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
                                if (data.DetailItems[j].TestingValue > LCL_X_X_CL_BC_X && data.DetailItems[j].TestingValue < CL_UCL_X_X_BC_X)
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
                                if (data.DetailItems[j].TestingValue < LCL_X_X_CL_BC_X || data.DetailItems[j].TestingValue > CL_UCL_X_X_BC_X)
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
                        log.ProjectCode = "06";
                        log.ErrorPK = LineLossPK;
                        log.Subject = "SPC统计异常 - 平台线损";

                        System.Text.StringBuilder builder = new System.Text.StringBuilder();
                        builder.Append("<table cellpadding='5'><tr><td>各位，好:</td><td></td></tr>");
                        builder.Append("<tr><td></td></tr>");
                        builder.Append("<tr><td></td><td>经过SPC统计，平台线损发生了异常，详细信息如下：</td></tr>");
                        builder.Append("<tr><td></td><td>平台号：" + LineLossItem.StationNo + "</td></tr>");
                        builder.Append("<tr><td></td><td>通道：" + LineLossItem.CHNo + "</td></tr>");
                        builder.Append("<tr><td></td><td>频段：" + LineLossItem.FrequencyBand + "</td></tr>");
                        builder.Append("<tr><td></td><td>项目：" + LineLossItem.Item + "</td></tr>");
                        builder.Append("<tr><td></td><td>开始日期：" + entity.DateFrom.ToString("yyyy-MM-dd") + "</td></tr>");
                        builder.Append("<tr><td></td><td>结束日期："+ entity.DateTo.ToString("yyyy-MM-dd") + "</td></tr>");
                        builder.Append("<tr><td></td><td></td></tr>");
                       // builder.Append("<tr><td></td><td>");
                        //builder.Append("<table cellpadding='3' border='1' cellspace='3' width='600' style='text-align:left;'>");
                        //builder.Append("<tr backgroud-color='#48bfe9'><th>次数</th><th>日期</th><th>测量值</th></tr>");
                        //for (int i = 0; i < entity.DetailItems.Count; i++)
                        //{
                        //    builder.Append("<tr><td>" + entity.DetailItems[i].NoOfTimes + "</td><td>" + entity.DetailItems[i].TestingDate.ToString("yyyy-MM-dd") + "</td><td>"+String.Format("{0:f1}",entity.DetailItems[i].TestingValue)+"</td></tr>");
                        //}
                        //builder.Append("</table>");
                        //builder.Append("</td></tr>");
                        builder.Append("<tr><td></td><td></td></tr>");
                        builder.Append("<tr><td></td><td><i>请点击<a href='" + System.Configuration.ConfigurationManager.AppSettings["WebUrl"] + 
                            "/SPCViewFromEmail.ashx?userId=SPCViewer&ProjectCode="+log.ProjectCode+"&errorPK="+
                            LineLossPK+"' target='_blank'><font color='blue'>这里</font></a>,即可查看异常原因.</i></td></tr>");
                        builder.Append("<tr><td></td><td></td></tr>");
                        builder.Append("<tr><td></td><td>如有任何问题，可联系质量管理部，谢谢！</td></tr>");                   
                        builder.Append("</table>");
                        log.Body=builder.ToString();
                    
                        log.LastUpdateDate = DateTime.Now;
                        log.LastUpdatedBy = Page.User.Identity.Name;
                        SPCEmailContainerService.Save(log);
                    }
                    #endregion
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
            WaveLab.Model.SPCStationLineLossInput input = SPCStationLineLossService.Get(LineLossItemPK, NoOfTimes);
            this.Mode.Value = "EditInput";
            this.NoOfTimes_Input.Value = input.NoOfTimes.ToString();
            this.tbxTestingDate.Text = input.TestingDate.ToString("yyyy-MM-dd");
            this.tbxTestingValue.Text = string.Format("{0:f2}", input.TestingValue);
            this.btnCancel.Attributes.Add("onclick", "javascript:self.location.href=sefl.location.toString()");
        }
    }
}
