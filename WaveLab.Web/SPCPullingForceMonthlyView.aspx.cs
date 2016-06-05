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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI.DataVisualization.Charting;
using Spring.Context;
using Spring.Context.Support;
using WaveLab.Model;
using WaveLab.IService;


namespace WaveLab.Web
{
    public partial class SPCPullingForceMonthlyView : CommonPage
    {
       private ISPCPullingForceMonthlyService SPCPullingForceMonthlyService;

        private int PullingForceMonthlyPK;

        private SPCPullingForceMonthlyInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCPullingForceMonthlyService = (ISPCPullingForceMonthlyService)cxt.GetObject("SV.SPCPullingForceMonthlyService");
         
            PullingForceMonthlyPK = int.Parse(Request.QueryString["key"]);
            entity = SPCPullingForceMonthlyService.GetDetail(PullingForceMonthlyPK);
            if (!Page.IsPostBack)
            {
                int digit = 5;

                this.ltlMachineNo.Text = entity.MachineNo;

                this.ltlYearMonth.Text = entity.YearMonth;
            
                this.ltlGroupingNo.Text = entity.GroupingNo.ToString();
                this.ltlLastUpdateDate.Text = entity.LastUpdateDate.ToString("yyyy-MM-dd");

                this.GVDetailItems.DataSource = entity.DetailItems;
                this.GVDetailItems.DataBind();

                this.ltlX.Text = String.Format("{0:f2}", entity.X);
                this.ltlR.Text = String.Format("{0:f2}", entity.R);
                this.ltlS.Text = String.Format("{0:f2}", entity.S);

                this.ltlLSL.Text = entity.LSL.ToString();

                this.ltlCPK.Text = String.Format("{0:f2}", entity.CPK);

                #region XBar
                double UCL_X = entity.UCL_X;
                double CL_UCL_BC_X = double.MinValue;
                double CL_UCL_AB_X = double.MinValue;
                double CL_X = entity.X;
                double LCL_CL_BC_X = double.MinValue;
                double LCL_CL_AB_X = double.MinValue;
                double LCL_X = entity.LCL_X;

                this.ltlCL_X.Text = String.Format("{0:f2}", CL_X);
                this.ltlUCL_X.Text = String.Format("{0:f2}", UCL_X);
                this.ltlLCL_X.Text = String.Format("{0:f2}", LCL_X);

                double LCL_CL_X_Interval = Math.Round((CL_X - LCL_X) / 3, digit);
                LCL_CL_AB_X = CL_X - LCL_CL_X_Interval * 2;
                LCL_CL_BC_X = CL_X - LCL_CL_X_Interval;

                double CL_UCL_X_Interval = Math.Round((UCL_X - CL_X) / 3, digit);
                CL_UCL_BC_X = CL_X + CL_UCL_X_Interval;
                CL_UCL_AB_X = CL_X + CL_UCL_X_Interval * 2;



                foreach (var item in entity.DetailItems)
                {
                    this.chartX.Series["LCL"].Points.AddXY(item.GroupNo, LCL_X);
                    this.chartX.Series["LCL_CL_AB"].Points.AddXY(item.GroupNo, LCL_CL_AB_X);
                    this.chartX.Series["LCL_CL_BC"].Points.AddXY(item.GroupNo, LCL_CL_BC_X);
                    this.chartX.Series["CL"].Points.AddXY(item.GroupNo, CL_X);
                    this.chartX.Series["CL_UCL_BC"].Points.AddXY(item.GroupNo, CL_UCL_BC_X);
                    this.chartX.Series["CL_UCL_AB"].Points.AddXY(item.GroupNo, CL_UCL_AB_X);
                    this.chartX.Series["UCL"].Points.AddXY(item.GroupNo, UCL_X);
                    this.chartX.Series["X"].Points.AddXY(item.GroupNo, item.X);

                    // this.chartX.Series["LSL"].Points.AddXY(item.GroupNo, entity.LSL);
                }
                this.chartX.Series["X"].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F2}\n";

                #endregion

                #region R
                double CL_R = entity.R;
                double UCL_R = entity.UCL_R;
                double LCL_R = entity.LCL_R;

                this.ltlCL_R.Text = String.Format("{0:f2}", CL_R);
                this.ltlUCL_R.Text = String.Format("{0:f2}", UCL_R);
                this.ltlLCL_R.Text = String.Format("{0:f2}", LCL_R);

                foreach (var item in entity.DetailItems)
                {
                    this.chartR.Series["LCL"].Points.AddXY(item.GroupNo, LCL_R);
                    this.chartR.Series["CL"].Points.AddXY(item.GroupNo, CL_R);
                    this.chartR.Series["UCL"].Points.AddXY(item.GroupNo, UCL_R);
                    this.chartR.Series["R"].Points.AddXY(item.GroupNo, item.R);
                }

                this.chartR.Series["R"].ToolTip = "组别:\t#VALX{d}\n极差:\t#VALY{F2}\n";
                #endregion

                #region Exception
                if (entity.ExceptionItems.Count == 0)
                {
                    #region Xbar
                    IList<SPCPullingForceMonthlyException> X_Exception_List = new List<SPCPullingForceMonthlyException>();
                    for (int i = 0; i < this.chartX.Series["X"].Points.Count; i++)
                    {

                        int xVal = (int)this.chartX.Series["X"].Points[i].XValue;
                        double yVal = this.chartX.Series["X"].Points[i].YValues[0];

                        #region 准则1---1点落在A区以外点出界就判异
                        if (yVal < LCL_X || yVal > UCL_X)
                        {
                            this.chartX.Series["X"].Points[i].MarkerColor = System.Drawing.Color.Red;
                            this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F2}\n" + "异常:\t落在A区以外";

                            SPCPullingForceMonthlyException item = new SPCPullingForceMonthlyException();
                            item.GroupNo = xVal;
                            X_Exception_List.Add(item);
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
                                if (this.chartX.Series["X"].Points[j].YValues[0] > CL_X)
                                {
                                    maxval = this.chartX.Series["X"].Points[j].YValues[0];
                                }
                                if (this.chartX.Series["X"].Points[j].YValues[0] < CL_X)
                                {
                                    minval = this.chartX.Series["X"].Points[j].YValues[0];
                                }
                            }
                            if (minval == CL_X || maxval == CL_X)
                            {
                                this.chartX.Series["X"].Points[i].MarkerColor = System.Drawing.Color.Red;
                                this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F2}\n" + "异常:\t连续9点落在中心线同一侧";
                                SPCPullingForceMonthlyException item = new SPCPullingForceMonthlyException();
                                item.GroupNo = xVal;
                                X_Exception_List.Add(item);
                                continue;
                            }
                        }
                        #endregion

                        #region 准则3---连续6点递增或递减
                        if (i >= 5)
                        {
                            if ((this.chartX.Series["X"].Points[i].YValues[0] > this.chartX.Series["X"].Points[i - 1].YValues[0] &&
                                this.chartX.Series["X"].Points[i - 1].YValues[0] > this.chartX.Series["X"].Points[i - 2].YValues[0] &&
                                this.chartX.Series["X"].Points[i - 2].YValues[0] > this.chartX.Series["X"].Points[i - 3].YValues[0] &&
                                this.chartX.Series["X"].Points[i - 3].YValues[0] > this.chartX.Series["X"].Points[i - 4].YValues[0] &&
                                this.chartX.Series["X"].Points[i - 4].YValues[0] > this.chartX.Series["X"].Points[i - 5].YValues[0]) ||
                                (this.chartX.Series["X"].Points[i].YValues[0] < this.chartX.Series["X"].Points[i - 1].YValues[0] &&
                                this.chartX.Series["X"].Points[i - 1].YValues[0] < this.chartX.Series["X"].Points[i - 2].YValues[0] &&
                                this.chartX.Series["X"].Points[i - 2].YValues[0] < this.chartX.Series["X"].Points[i - 3].YValues[0] &&
                                this.chartX.Series["X"].Points[i - 3].YValues[0] < this.chartX.Series["X"].Points[i - 4].YValues[0] &&
                                this.chartX.Series["X"].Points[i - 4].YValues[0] < this.chartX.Series["X"].Points[i - 5].YValues[0]))
                            {
                                this.chartX.Series["X"].Points[i].MarkerColor = System.Drawing.Color.Red;
                                this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F2}\n" + "异常:\t连续6点递增或递减";
                                SPCPullingForceMonthlyException item = new SPCPullingForceMonthlyException();
                                item.GroupNo = xVal;
                                X_Exception_List.Add(item);
                                continue;
                            }
                        }
                        #endregion

                        #region 准则4---连续14点相邻点上下交替
                        if (i >= 13)
                        {
                            if ((this.chartX.Series["X"].Points[i].YValues[0] > this.chartX.Series["X"].Points[i - 1].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 1].YValues[0] < this.chartX.Series["X"].Points[i - 2].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 2].YValues[0] > this.chartX.Series["X"].Points[i - 3].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 3].YValues[0] < this.chartX.Series["X"].Points[i - 4].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 4].YValues[0] > this.chartX.Series["X"].Points[i - 5].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 5].YValues[0] < this.chartX.Series["X"].Points[i - 6].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 6].YValues[0] > this.chartX.Series["X"].Points[i - 7].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 7].YValues[0] < this.chartX.Series["X"].Points[i - 8].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 8].YValues[0] > this.chartX.Series["X"].Points[i - 9].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 9].YValues[0] < this.chartX.Series["X"].Points[i - 10].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 10].YValues[0] > this.chartX.Series["X"].Points[i - 11].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 11].YValues[0] < this.chartX.Series["X"].Points[i - 12].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 12].YValues[0] > this.chartX.Series["X"].Points[i - 13].YValues[0])
                                ||
                                (this.chartX.Series["X"].Points[i].YValues[0] < this.chartX.Series["X"].Points[i - 1].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 1].YValues[0] > this.chartX.Series["X"].Points[i - 2].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 2].YValues[0] < this.chartX.Series["X"].Points[i - 3].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 3].YValues[0] > this.chartX.Series["X"].Points[i - 4].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 4].YValues[0] < this.chartX.Series["X"].Points[i - 5].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 5].YValues[0] > this.chartX.Series["X"].Points[i - 6].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 6].YValues[0] < this.chartX.Series["X"].Points[i - 7].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 7].YValues[0] > this.chartX.Series["X"].Points[i - 8].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 8].YValues[0] < this.chartX.Series["X"].Points[i - 9].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 9].YValues[0] > this.chartX.Series["X"].Points[i - 10].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 10].YValues[0] < this.chartX.Series["X"].Points[i - 11].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 11].YValues[0] > this.chartX.Series["X"].Points[i - 12].YValues[0] &&
                                    this.chartX.Series["X"].Points[i - 12].YValues[0] < this.chartX.Series["X"].Points[i - 13].YValues[0]))
                            {
                                this.chartX.Series["X"].Points[i].MarkerColor = System.Drawing.Color.Red;
                                this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F2}\n" + "异常:\t连续14点相邻点上下交替";
                                SPCPullingForceMonthlyException item = new SPCPullingForceMonthlyException();
                                item.GroupNo = xVal;
                                X_Exception_List.Add(item);
                                continue;
                            }
                        }

                        #endregion

                        #region  准则5---连续3点中有2点落在中心线同一侧的B区以外
                        if (i >= 2)
                        {

                            if (
                                ((this.chartX.Series["X"].Points[i - 2].YValues[0] < LCL_CL_AB_X && this.chartX.Series["X"].Points[i - 1].YValues[0] < LCL_CL_AB_X) ||
                                (this.chartX.Series["X"].Points[i - 2].YValues[0] < LCL_CL_AB_X && this.chartX.Series["X"].Points[i].YValues[0] < LCL_CL_AB_X) ||
                                (this.chartX.Series["X"].Points[i - 1].YValues[0] < LCL_CL_AB_X && this.chartX.Series["X"].Points[i].YValues[0] < LCL_CL_AB_X)) ||
                                ((this.chartX.Series["X"].Points[i - 2].YValues[0] > CL_UCL_AB_X && this.chartX.Series["X"].Points[i - 1].YValues[0] > CL_UCL_AB_X) ||
                                (this.chartX.Series["X"].Points[i - 2].YValues[0] > CL_UCL_AB_X && this.chartX.Series["X"].Points[i].YValues[0] > CL_UCL_AB_X) ||
                                (this.chartX.Series["X"].Points[i - 1].YValues[0] > CL_UCL_AB_X && this.chartX.Series["X"].Points[i].YValues[0] > CL_UCL_AB_X))
                               )
                            {
                                this.chartX.Series["X"].Points[i].MarkerColor = System.Drawing.Color.Red;
                                this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F2}\n" + "异常:\t连续3点中有2点落在中心线同一侧的B区以外";
                                SPCPullingForceMonthlyException item = new SPCPullingForceMonthlyException();
                                item.GroupNo = xVal;
                                X_Exception_List.Add(item);
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
                                if (this.chartX.Series["X"].Points[j].YValues[0] < LCL_CL_BC_X)
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
                                this.chartX.Series["X"].Points[i].MarkerColor = System.Drawing.Color.Red;
                                this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F2}\n" + "异常:\t连续5点中有4点落在中心线同一侧的C区以外";
                                SPCPullingForceMonthlyException item = new SPCPullingForceMonthlyException();
                                item.GroupNo = xVal;
                                X_Exception_List.Add(item);
                                continue;
                            }

                            items.Clear();
                            itemcount = 0;

                            for (int j = i - 4; j <= i; j++)
                            {
                                if (this.chartX.Series["X"].Points[j].YValues[0] > CL_UCL_BC_X)
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
                                this.chartX.Series["X"].Points[i].MarkerColor = System.Drawing.Color.Red;
                                this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F2}\n" + "异常:\t连续5点中有4点落在中心线同一侧的C区以外";
                                SPCPullingForceMonthlyException item = new SPCPullingForceMonthlyException();
                                item.GroupNo = xVal;
                                X_Exception_List.Add(item);
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
                                if (this.chartX.Series["X"].Points[j].YValues[0] > LCL_CL_BC_X && this.chartX.Series["X"].Points[j].YValues[0] < CL_UCL_BC_X)
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
                                this.chartX.Series["X"].Points[i].MarkerColor = System.Drawing.Color.Red;
                                this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F2}\n" + "异常:\t连续15点C区中心线上下";
                                SPCPullingForceMonthlyException item = new SPCPullingForceMonthlyException();
                                item.GroupNo = xVal;
                                X_Exception_List.Add(item);
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
                                if (this.chartX.Series["X"].Points[j].YValues[0] < LCL_CL_BC_X || this.chartX.Series["X"].Points[j].YValues[0] > CL_UCL_BC_X)
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
                                this.chartX.Series["X"].Points[i].MarkerColor = System.Drawing.Color.Red;
                                this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F2}\n" + "异常:\t连续8点在中心线两侧，但无一在C区中";
                                SPCPullingForceMonthlyException item = new SPCPullingForceMonthlyException();
                                item.GroupNo = xVal;
                                X_Exception_List.Add(item);
                                continue;
                            }
                        }
                        #endregion
                    }

                    foreach (SPCPullingForceMonthlyException item in X_Exception_List)
                    {
                        foreach (SPCPullingForceMonthlyDetail row in entity.DetailItems)
                        {
                            if (item.GroupNo == row.GroupNo)
                            {
                                item.WorkingDate = row.WorkingDate;
                                break;
                            }
                        }
                    }
                    this.GVXException.DataSource = X_Exception_List;
                    this.GVXException.DataBind();
                    #endregion

                    #region R
                    IList<SPCPullingForceMonthlyException> R_Exception_List = new List<SPCPullingForceMonthlyException>();
                    for (int i = 0; i < this.chartR.Series["R"].Points.Count; i++)
                    {
                        int xVal = (int)this.chartR.Series["R"].Points[i].XValue;
                        double yVal = this.chartR.Series["R"].Points[i].YValues[0];

                        if (yVal < LCL_R || yVal > UCL_R)
                        {
                            this.chartR.Series["R"].Points[i].MarkerColor = System.Drawing.Color.Red;
                            this.chartR.Series["R"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F2}\n" + "异常:\t落在管制上下限以外";

                            SPCPullingForceMonthlyException item = new SPCPullingForceMonthlyException();
                            item.GroupNo = xVal;
                            R_Exception_List.Add(item);
                            continue;
                        }
                    }

                    foreach (SPCPullingForceMonthlyException item in R_Exception_List)
                    {
                        foreach (SPCPullingForceMonthlyDetail row in entity.DetailItems)
                        {
                            if (item.GroupNo == row.GroupNo)
                            {
                                item.WorkingDate = row.WorkingDate;
                                break;
                            }
                        }
                    }
                    this.GVRException.DataSource = R_Exception_List;
                    this.GVRException.DataBind();
                    #endregion

                    if (X_Exception_List.Count == 0 && R_Exception_List.Count == 0)
                    {
                        this.btnSave.Visible = false;
                        this.btnClose.Visible = false;
                    }
                    else
                    {
                        this.btnSave.Attributes.Add("onclick", "return verify('" + this.GetLocalResourceObject("ExceptionMsg").ToString() + "','" + this.GetLocalResourceObject("ConfirmMsg").ToString() + "')");
                    }
                }
                else
                {
                    GVXException.Visible = false;
                    GVRException.Visible = false;

                    for (int i = 0; i < this.chartX.Series["X"].Points.Count; i++)
                    {
                        bool isExcept = false;
                        int GroupNo = (int)this.chartX.Series["X"].Points[i].XValue;
                        string comment = string.Empty;
                        for (int j = 0; j < entity.ExceptionItems.Count; j++)
                        {
                            if (entity.ExceptionItems[j].ChartType == 'X' && entity.ExceptionItems[j].GroupNo == GroupNo)
                            {
                                isExcept = true;
                                comment = entity.ExceptionItems[j].Comment;
                                break;
                            }
                        }
                        if (isExcept == true)
                        {
                            this.chartX.Series["X"].Points[i].MarkerColor = System.Drawing.Color.Red;
                            this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F2}\n" + "备注:\t" + comment;
                        }
                    }

                    for (int i = 0; i < this.chartR.Series["R"].Points.Count; i++)
                    {
                        bool isExcept = false;
                        int GroupNo = (int)this.chartR.Series["R"].Points[i].XValue;
                        string comment = string.Empty;
                        for (int j = 0; j < entity.ExceptionItems.Count; j++)
                        {
                            if (entity.ExceptionItems[j].ChartType == 'R' && entity.ExceptionItems[j].GroupNo == GroupNo)
                            {
                                isExcept = true;
                                comment = entity.ExceptionItems[j].Comment;
                                break;
                            }
                        }
                        if (isExcept == true)
                        {
                            this.chartR.Series["R"].Points[i].MarkerColor = System.Drawing.Color.Red;
                            this.chartR.Series["R"].Points[i].ToolTip = "组别:\t#VALX{d}\n极差:\t#VALY{F2}\n" + "备注:\t" + comment;
                        }
                    }
                }
                #endregion
            }
        }

        protected void chartX_Customize(object sender, EventArgs e)
        {
            Chart chart = (Chart)sender;
            CustomLabelsCollection yAxisLabels = chart.ChartAreas["ChartArea1"].AxisY.CustomLabels;
            for (int labelIndex = 0; labelIndex < yAxisLabels.Count; labelIndex++)
            {
                yAxisLabels[labelIndex].Text = "";
            }
        }

        protected void chartR_Customize(object sender, EventArgs e)
        {
            Chart chart = (Chart)sender;

            CustomLabelsCollection yAxisLabels = chart.ChartAreas["ChartArea1"].AxisY.CustomLabels;
            for (int labelIndex = 0; labelIndex < yAxisLabels.Count; labelIndex++)
            {
                yAxisLabels[labelIndex].Text = "";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IList<SPCPullingForceMonthlyException> exceptionItems = new List<SPCPullingForceMonthlyException>();
            for (int i = 0; i < this.GVXException.Rows.Count; i++)
            {
                SPCPullingForceMonthlyException exceptionItem = new SPCPullingForceMonthlyException();
                exceptionItem.GroupNo = int.Parse(this.GVXException.Rows[i].Cells[0].Text);
                exceptionItem.WorkingDate = DateTime.ParseExact(this.GVXException.Rows[i].Cells[1].Text, "yyyy-MM-dd", null);
                exceptionItem.ChartType = 'X';
                TextBox tbxXComment = (TextBox)this.GVXException.Rows[i].FindControl("tbxXComment");
                exceptionItem.Comment = tbxXComment.Text;
                exceptionItem.LastUpdateDate = DateTime.Now;
                exceptionItem.LastUpdatedBy = Page.User.Identity.Name;
                exceptionItems.Add(exceptionItem);
            }
            for (int i = 0; i < this.GVRException.Rows.Count; i++)
            {
                SPCPullingForceMonthlyException exceptionItem = new SPCPullingForceMonthlyException();
                exceptionItem.WorkingDate = DateTime.ParseExact(this.GVRException.Rows[i].Cells[1].Text, "yyyy-MM-dd", null);
                exceptionItem.GroupNo = int.Parse(this.GVRException.Rows[i].Cells[0].Text);
                exceptionItem.ChartType = 'R';
                TextBox tbxRComment = (TextBox)this.GVRException.Rows[i].FindControl("tbxRComment");
                exceptionItem.Comment = tbxRComment.Text;
                exceptionItem.LastUpdateDate = DateTime.Now;
                exceptionItem.LastUpdatedBy = Page.User.Identity.Name;
                exceptionItems.Add(exceptionItem);
            }
            try
            {
                SPCPullingForceMonthlyService.Save(PullingForceMonthlyPK, exceptionItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');self.close();</script>");

        }

    }
}
