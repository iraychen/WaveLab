﻿using System;
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
    public partial class SPCTxMaskFlatView : CommonPage
    {
        private ISPCTxMaskFlatService SPCTxMaskFlatService;

        private int TxMaskFlatPK;
        private SPCTxMaskFlatInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCTxMaskFlatService = (ISPCTxMaskFlatService)cxt.GetObject("SV.SPCTxMaskFlatService");
            TxMaskFlatPK = int.Parse(Request.QueryString["TxMaskFlatPK"]);
            entity = SPCTxMaskFlatService.GetDetail(TxMaskFlatPK);
            if (!Page.IsPostBack)
            {
                int digit = 2;

                #region Item
                this.ltlType.Text = entity.Type;
                this.ltlMode.Text = entity.Mode;
                this.ltlCH.Text = entity.CH;
                this.ltlDateFrom.Text = entity.DateFrom.ToString("yyyy-MM-dd") ;
                this.ltlDateTo.Text = entity.DateTo.ToString("yyyy-MM-dd");
                this.ltlGroupingNo.Text = entity.GroupingNo.ToString();
                this.ltlLastUpdatedDate.Text = entity.LastUpdateDate.ToString("yyyy-MM-dd");

                this.GVGroupItems.DataSource = entity.GroupItems;
                this.GVGroupItems.DataBind();

                this.ltlX.Text = String.Format("{0:f2}", entity.X);
                this.ltlR.Text = String.Format("{0:f2}", entity.R);
                this.ltlS.Text = String.Format("{0:f2}", entity.S);

                this.ltlUSL.Text = entity.USL.ToString();
                this.ltlCPU.Text = String.Format("{0:f2}", entity.CPU);               
                this.ltlCPK.Text = String.Format("{0:f2}", entity.CPK);

                #endregion

                #region XBar
                double UCL_X = entity.UCL_X;
                double CL_UCL_BC_X= double.MinValue;
                double CL_UCL_AB_X = double.MinValue;
                double CL_X =  entity.CL_X;
                double LCL_CL_BC_X = double.MinValue;
                double LCL_CL_AB_X = double.MinValue;
                double LCL_X = entity.LCL_X;

                this.ltlCL_X.Text = String.Format("{0:f2}", CL_X);
                this.ltlUCL_X.Text = String.Format("{0:f2}", UCL_X);
                this.ltlLCL_X.Text = String.Format("{0:f2}", LCL_X);

                double LCL_X_CL_Interval = Math.Round((CL_X - LCL_X) / 3, digit);
                LCL_CL_AB_X = CL_X - LCL_X_CL_Interval * 2;
                LCL_CL_BC_X = CL_X - LCL_X_CL_Interval;

                double CL_X_UCL_Interval = Math.Round((UCL_X - CL_X) / 3, digit);
                CL_UCL_BC_X= CL_X + CL_X_UCL_Interval;
                CL_UCL_AB_X = CL_X + CL_X_UCL_Interval * 2;

                foreach (var item in entity.GroupItems)
                {
                    this.chartX.Series["LCL"].Points.AddXY(item.GroupNo, LCL_X);
                    this.chartX.Series["LCL_CL_AB"].Points.AddXY(item.GroupNo, LCL_CL_AB_X);
                    this.chartX.Series["LCL_CL_BC"].Points.AddXY(item.GroupNo, LCL_CL_BC_X);
                    this.chartX.Series["CL"].Points.AddXY(item.GroupNo, CL_X);
                    this.chartX.Series["CL_UCL_BC"].Points.AddXY(item.GroupNo, CL_UCL_BC_X);
                    this.chartX.Series["CL_UCL_AB"].Points.AddXY(item.GroupNo, CL_UCL_AB_X);
                    this.chartX.Series["UCL"].Points.AddXY(item.GroupNo, UCL_X);

                    this.chartX.Series["X"].Points.AddXY(item.GroupNo, item.X);

                    this.chartX.Series["USL"].Points.AddXY(item.GroupNo, entity.USL);              
                }

                this.chartX.Series["X"].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F5}\n";
                #endregion

                #region R
                double UCL_R = entity.UCL_R;
                double CL_R= entity.CL_R;
                double LCL_R = entity.LCL_R;

                this.ltlCL_R.Text = String.Format("{0:f2}", CL_R);
                this.ltlUCL_R.Text = String.Format("{0:f2}", UCL_R);
                this.ltlLCL_R.Text = String.Format("{0:f2}", LCL_R);

                foreach (var item in entity.GroupItems)
                {
                    this.chartR.Series["LCL"].Points.AddXY(item.GroupNo, LCL_R);
                    this.chartR.Series["CL"].Points.AddXY(item.GroupNo, CL_R);
                    this.chartR.Series["UCL"].Points.AddXY(item.GroupNo, UCL_R);
                    this.chartR.Series["R"].Points.AddXY(item.GroupNo, item.R);
                }

                this.chartR.Series["R"].ToolTip = "组别:\t#VALX{d}\n极差:\t#VALY{F5}\n";
                #endregion

                #region Exception
                if (entity.ExceptionItems.Count == 0)
                {
                    #region Xbar
                    IList<SPCTxMaskFlatException> X_Exception_List = new List<SPCTxMaskFlatException>();
                    for (int i = 0; i < this.chartX.Series["X"].Points.Count; i++)
                    {

                        int xVal = (int)this.chartX.Series["X"].Points[i].XValue;
                        double yVal = this.chartX.Series["X"].Points[i].YValues[0];

                        #region 准则1---1点落在A区以外点出界就判异
                        if (yVal < LCL_X || yVal > UCL_X)
                        {
                            this.chartX.Series["X"].Points[i].MarkerColor = System.Drawing.Color.Red;
                            this.chartX.Series["X"].Points[i].ToolTip = "次数:\t#VALX{d}\n测量值:\t#VALY{F2}\n" + "异常:\t落在A区以外";

                            SPCTxMaskFlatException item = new SPCTxMaskFlatException();
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
                                this.chartX.Series["X"].Points[i].ToolTip = "次数:\t#VALX{d}\n测量值:\t#VALY{F2}\n" + "异常:\t连续9点落在中心线同一侧";
                                SPCTxMaskFlatException item = new SPCTxMaskFlatException();
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
                                this.chartX.Series["X"].Points[i].ToolTip = "次数:\t#VALX{d}\n测量值:\t#VALY{F2}\n" + "异常:\t连续6点递增或递减";
                                SPCTxMaskFlatException item = new SPCTxMaskFlatException();
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
                                this.chartX.Series["X"].Points[i].ToolTip = "次数:\t#VALX{d}\n测量值:\t#VALY{F2}\n" + "异常:\t连续14点相邻点上下交替";
                                SPCTxMaskFlatException item = new SPCTxMaskFlatException();
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
                                this.chartX.Series["X"].Points[i].ToolTip = "次数:\t#VALX{d}\n测量值:\t#VALY{F2}\n" + "异常:\t连续3点中有2点落在中心线同一侧的B区以外";
                                SPCTxMaskFlatException item = new SPCTxMaskFlatException();
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
                                this.chartX.Series["X"].Points[i].ToolTip = "次数:\t#VALX{d}\n测量值:\t#VALY{F2}\n" + "异常:\t连续5点中有4点落在中心线同一侧的C区以外";
                                SPCTxMaskFlatException item = new SPCTxMaskFlatException();
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
                                this.chartX.Series["X"].Points[i].ToolTip = "次数:\t#VALX{d}\n测量值:\t#VALY{F2}\n" + "异常:\t连续5点中有4点落在中心线同一侧的C区以外";
                                SPCTxMaskFlatException item = new SPCTxMaskFlatException();
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
                                this.chartX.Series["X"].Points[i].ToolTip = "次数:\t#VALX{d}\n测量值:\t#VALY{F2}\n" + "异常:\t连续15点C区中心线上下";
                                SPCTxMaskFlatException item = new SPCTxMaskFlatException();
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
                                this.chartX.Series["X"].Points[i].ToolTip = "次数:\t#VALX{d}\n测量值:\t#VALY{F2}\n" + "异常:\t连续8点在中心线两侧，但无一在C区中";
                                SPCTxMaskFlatException item = new SPCTxMaskFlatException();
                                item.GroupNo = xVal;
                                X_Exception_List.Add(item);
                                continue;
                            }
                        }
                        #endregion
                    }

                    this.GVXException.DataSource = X_Exception_List;
                    this.GVXException.DataBind();
                    #endregion

                    #region R
                    IList<SPCTxMaskFlatException> R_Exception_List = new List<SPCTxMaskFlatException>();
                    for (int i = 0; i < this.chartR.Series["R"].Points.Count; i++)
                    {
                        int xVal = (int)this.chartR.Series["R"].Points[i].XValue;
                        double yVal = this.chartR.Series["R"].Points[i].YValues[0];

                        if (yVal < LCL_R || yVal > UCL_R)
                        {
                            this.chartR.Series["R"].Points[i].MarkerColor = System.Drawing.Color.Red;
                            this.chartR.Series["R"].Points[i].ToolTip = "次数:\t#VALX{d}\n测量值:\t#VALY{F2}\n" + "异常:\t落在管制上下限以外";

                            SPCTxMaskFlatException item = new SPCTxMaskFlatException();
                            item.GroupNo = xVal;
                            R_Exception_List.Add(item);
                            continue;
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
                            this.chartX.Series["X"].Points[i].ToolTip = "次数:\t#VALX{d}\n测量值:\t#VALY{F2}\n" + "备注:\t" + comment;
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
                            this.chartR.Series["R"].Points[i].ToolTip = "次数:\t#VALX{d}\nMR:\t#VALY{F2}\n" + "备注:\t" + comment;
                        }
                    }

                    this.btnSave.Visible = false;
                    this.btnClose.Visible = false;
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

        protected void GVGroupItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtGroupNo = (LinkButton)e.Row.FindControl("lbtGroupNo");
                lbtGroupNo.Text = (e.Row.RowIndex + 1).ToString();
                lbtGroupNo.Font.Underline = true;
                lbtGroupNo.Attributes.Add("onclick", "return makeWindow('ORIGINAL','"
                    + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TxMaskFlatPK")) + "','"
                    + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GroupNo")) + "')");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime LastUpdateDate = DateTime.Now;
            IList<SPCTxMaskFlatException> exceptionItems = new List<SPCTxMaskFlatException>();
            for (int i = 0; i < this.GVXException.Rows.Count; i++)
            {
                SPCTxMaskFlatException exceptionItem = new SPCTxMaskFlatException();
                exceptionItem.GroupNo = int.Parse(this.GVXException.Rows[i].Cells[0].Text);
                exceptionItem.ChartType = 'X';
                TextBox tbxXComment = (TextBox)this.GVXException.Rows[i].FindControl("tbxXComment");
                exceptionItem.Comment = tbxXComment.Text;
                exceptionItem.LastUpdateDate = LastUpdateDate;
                exceptionItem.LastUpdatedBy = Page.User.Identity.Name;
                exceptionItems.Add(exceptionItem);
            }
            for (int i = 0; i < this.GVRException.Rows.Count; i++)
            {
                SPCTxMaskFlatException exceptionItem = new SPCTxMaskFlatException();
                exceptionItem.GroupNo = int.Parse(this.GVRException.Rows[i].Cells[0].Text);
                exceptionItem.ChartType = 'R';
                TextBox tbxRComment = (TextBox)this.GVRException.Rows[i].FindControl("tbxRComment");
                exceptionItem.Comment = tbxRComment.Text;
                exceptionItem.LastUpdateDate = LastUpdateDate;
                exceptionItem.LastUpdatedBy = Page.User.Identity.Name;
                exceptionItems.Add(exceptionItem);
            }
            try
            {
                SPCTxMaskFlatService.SaveException(TxMaskFlatPK, exceptionItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');self.close();</script>");

        }

    }
}
