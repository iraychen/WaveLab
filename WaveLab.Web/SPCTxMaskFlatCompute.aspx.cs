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
    public partial class SPCTxMaskFlatCompute : CommonPage
    {
        private string type, mode, ch, datefrom, dateto, groupingno, lcl,ucl,usl;
        private ISPCParameterService SPCParameterService;
        private IList<SPCTxMaskFlatDetail> originalItems;
        private ISPCTxMaskFlatService SPCTxMaskFlatService;
        private ISPCEmailContainerService SPCEmailContainerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCTxMaskFlatService = (ISPCTxMaskFlatService)cxt.GetObject("SV.SPCTxMaskFlatService");
            SPCParameterService = (ISPCParameterService)cxt.GetObject("SV.SPCParameterService");
            SPCEmailContainerService = (ISPCEmailContainerService)cxt.GetObject("SV.SPCEmailContainerService");
         
            type = Request.QueryString["type"];
            mode = Request.QueryString["mode"];
            ch = Request.QueryString["ch"];
            datefrom = Request.QueryString["datefrom"];
            dateto = Request.QueryString["dateto"];
            groupingno = Request.QueryString["groupingno"];
            lcl = Request.QueryString["lcl"];
            ucl = Request.QueryString["ucl"];
            usl = Request.QueryString["usl"];
    
            if (Session["SPCTxMaskFlatOriginal"] != null)
            {
                originalItems = (IList<SPCTxMaskFlatDetail>)Session["SPCTxMaskFlatOriginal"];
            }
            else
            {
                return;
            }

            if (!Page.IsPostBack)
            {
                this.ltlType.Text = type;
                this.ltlMode.Text = mode;
                this.ltlCH.Text = ch;

                this.ltlDateFrom.Text = datefrom;
                this.ltlDateTo.Text = dateto;
                this.ltlGroupingNo.Text = groupingno;

                View(true,null);

                this.btnSave.Attributes.Add("onclick", "return verify('" + this.GetLocalResourceObject("ExceptionMsg").ToString() + "','" + this.GetLocalResourceObject("ConfirmMsg").ToString() + "')");
            }

        }

        private void View(bool all, IList<int> groupNoList)
        {
            #region Data
            //第一次均值和极差
            int digit = 2;
           
            var groupItems = from item in originalItems
                        group item by item.GroupNo into temp
                        select new
                        {
                            GroupNo = temp.Key,
                            X = Math.Round(temp.Average(item => double.Parse(item.Val)), digit),
                            R = Math.Round(temp.Max(item => double.Parse(item.Val)) - temp.Min(item => double.Parse(item.Val)), digit),
                            TakePartIn = (all == true) ? 'Y' : (groupNoList.Contains(temp.Key)==true ? 'Y' : 'N')
                        };

            this.GVItems.DataSource = groupItems;
            this.GVItems.DataBind();

            //第二次均值和极差
            var chartItems = from item in groupItems
                             where item.TakePartIn == 'Y'
                             select item;

            double X = Math.Round(chartItems.Average(item => item.X), digit);
            double R = Math.Round(chartItems.Average(item => item.R), digit);

            this.ltlX.Text = String.Format("{0:f2}", X);
            this.ltlR.Text = String.Format("{0:f2}", R);

            this.ltlUSL.Text = usl;

            //标准差
            double sum = 0;
            foreach (var item in originalItems)
            {
                sum += Math.Pow(double.Parse(item.Val) - X, 2);
            }
            int n = chartItems.Count() - 1;
            double S = Math.Round(Math.Sqrt(sum / n), digit);
            this.ltlS.Text = String.Format("{0:f2}", S);

            #region CPK
            System.Nullable<double> CPU = null, CPL = null, CPK = null;
           
            if (usl.Length > 0)
            {
                CPU = Math.Round((Double.Parse(usl) - X) / (3 * S), digit);
                this.ltlCPU.Text = String.Format("{0:f5}", CPU);
                CPK = CPU;             
            }
            this.ltlCPK.Text = String.Format("{0:f2}", CPK.Value);
            
            #endregion

            SPCParameterInfo entity = SPCParameterService.GetDetail(int.Parse(groupingno));

            #endregion
           
            #region XBar
            double UCL_X = double.MinValue;
            double CL_UCL_BC_X = double.MinValue;
            double CL_UCL_AB_X = double.MinValue;
            double CL_X = double.MinValue;
            double LCL_CL_BC_X = double.MinValue;
            double LCL_CL_AB_X = double.MinValue;
            double LCL_X = double.MinValue;

            UCL_X = (string.IsNullOrEmpty(ucl) == false && ucl.Length > 0) ? Double.Parse(ucl) : Math.Round(X + entity.A2.Value * R, digit);
            CL_X = X;
            LCL_X = (string.IsNullOrEmpty(lcl) == false && lcl.Length > 0) ? Double.Parse(lcl) : Math.Round(X - entity.A2.Value * R, digit);

            this.ltlCL_X.Text = String.Format("{0:f2}", CL_X);
            this.ltlUCL_X.Text = String.Format("{0:f2}", UCL_X);
            this.ltlLCL_X.Text = String.Format("{0:f2}", LCL_X);

            double LCL_CL_X_Interval = Math.Round((CL_X - LCL_X) / 3, digit);
            LCL_CL_AB_X = CL_X - LCL_CL_X_Interval * 2;
            LCL_CL_BC_X = CL_X - LCL_CL_X_Interval;

            double CL_UCL_X_Interval = Math.Round((UCL_X - CL_X) / 3, digit);
            CL_UCL_BC_X = CL_X + CL_UCL_X_Interval;
            CL_UCL_AB_X = CL_X + CL_UCL_X_Interval * 2;

            foreach (var item in chartItems)
            {
               this.chartX.Series["LCL"].Points.AddXY(item.GroupNo, LCL_X);
               this.chartX.Series["LCL_CL_AB"].Points.AddXY(item.GroupNo, LCL_CL_AB_X);
               this.chartX.Series["LCL_CL_BC"].Points.AddXY(item.GroupNo, LCL_CL_BC_X);
               this.chartX.Series["CL"].Points.AddXY(item.GroupNo, CL_X);
               this.chartX.Series["CL_UCL_BC"].Points.AddXY(item.GroupNo, CL_UCL_BC_X);
               this.chartX.Series["CL_UCL_AB"].Points.AddXY(item.GroupNo, CL_UCL_AB_X);
               this.chartX.Series["UCL"].Points.AddXY(item.GroupNo, UCL_X);
               this.chartX.Series["X"].Points.AddXY(item.GroupNo, item.X);

               this.chartX.Series["USL"].Points.AddXY(item.GroupNo, usl);
            }
            this.chartX.Series["X"].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F5}\n";

             IList<SPCTxMaskFlatException> X_Exception_List = new List<SPCTxMaskFlatException>();

             for (int i = 0; i < this.chartX.Series["X"].Points.Count; i++)
             {
                 int xVal = (int)this.chartX.Series["X"].Points[i].XValue;
                 double yVal = this.chartX.Series["X"].Points[i].YValues[0];

                 #region 准则1---1点落在A区以外点出界就判异
                 if (yVal < LCL_X || yVal > UCL_X)
                 {
                     this.chartX.Series["X"].Points[i].MarkerColor = System.Drawing.Color.Red;
                     this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F5}\n" + "异常:\t落在A区以外";

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
                         this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F5}\n" + "异常:\t连续9点落在中心线同一侧";
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
                         this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F5}\n" + "异常:\t连续6点递增或递减";
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
                         this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F5}\n" + "异常:\t连续14点相邻点上下交替";
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
                         this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F5}\n" + "异常:\t连续3点中有2点落在中心线同一侧的B区以外";
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
                         if (this.chartX.Series["X"].Points[j].YValues[0] <LCL_CL_BC_X)
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
                         this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F5}\n" + "异常:\t连续5点中有4点落在中心线同一侧的C区以外";
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
                         this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F5}\n" + "异常:\t连续5点中有4点落在中心线同一侧的C区以外";
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
                         if (this.chartX.Series["X"].Points[j].YValues[0] >LCL_CL_BC_X && this.chartX.Series["X"].Points[j].YValues[0] < CL_UCL_BC_X)
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
                         this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F5}\n" + "异常:\t连续15点C区中心线上下";
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
                         if (this.chartX.Series["X"].Points[j].YValues[0] <LCL_CL_BC_X || this.chartX.Series["X"].Points[j].YValues[0] > CL_UCL_BC_X)
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
                         this.chartX.Series["X"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F5}\n" + "异常:\t连续8点在中心线两侧，但无一在C区中";
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
            double CL_R = R;
            double UCL_R = double.MinValue;
            double LCL_R = double.MinValue;

            UCL_R = (string.IsNullOrEmpty(ucl) == false && ucl.Length > 0) ? Double.Parse(ucl) : Math.Round((entity.D4 == null ? 0 : entity.D4.Value) * R, digit);
            LCL_R = (string.IsNullOrEmpty(lcl) == false && lcl.Length > 0) ? Double.Parse(lcl) : Math.Round((entity.D3 == null ? 0 : entity.D3.Value) * R, digit);

            this.ltlCL_R.Text = String.Format("{0:f2}", CL_R);
            this.ltlUCL_R.Text = String.Format("{0:f2}", UCL_R);
            this.ltlLCL_R.Text = String.Format("{0:f2}", LCL_R);

            foreach (var item in chartItems)
            {
                this.chartR.Series["LCL"].Points.AddXY(item.GroupNo, LCL_R);
                this.chartR.Series["CL"].Points.AddXY(item.GroupNo, CL_R);
                this.chartR.Series["UCL"].Points.AddXY(item.GroupNo, UCL_R);
                this.chartR.Series["R"].Points.AddXY(item.GroupNo, item.R);
            }

            this.chartR.Series["R"].ToolTip = "组别:\t#VALX{d}\n极差:\t#VALY{F5}\n";

            IList<SPCTxMaskFlatException> R_Exception_List = new List<SPCTxMaskFlatException>();

            for (int i = 0; i < this.chartR.Series["R"].Points.Count; i++)
            {
                int xVal = (int)this.chartR.Series["R"].Points[i].XValue;
                double yVal = this.chartR.Series["R"].Points[i].YValues[0];

                if (yVal < LCL_R || yVal > UCL_R)
                {
                    this.chartR.Series["R"].Points[i].MarkerColor = System.Drawing.Color.Red;
                    this.chartR.Series["R"].Points[i].ToolTip = "组别:\t#VALX{d}\n均值:\t#VALY{F5}\n" + "异常:\t落在管制上下限以外";

                    SPCTxMaskFlatException item = new SPCTxMaskFlatException();
                    item.GroupNo = xVal;
                    R_Exception_List.Add(item);
                    continue;
                }
            }
            this.GVRException.DataSource = R_Exception_List;
            this.GVRException.DataBind();
            #endregion
        }

        protected void chxTakePartIn_OnCheckedChanged(object sender, EventArgs e)
        {
            IList<int> groupNoList = new List<int>();
            for (int i = 0; i < this.GVItems.Rows.Count; i++)
            {
                CheckBox chxTakePartIn = (CheckBox)this.GVItems.Rows[i].FindControl("chxTakePartIn");
                if (chxTakePartIn.Checked == true)
                {
                    groupNoList.Add(int.Parse(this.GVItems.DataKeys[i].Values["GroupNo"].ToString()));
                }
            }
            View(false, groupNoList);
        }

        protected void GVItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                CheckBox chxTakePartIn = (CheckBox)e.Row.FindControl("chxTakePartIn");
                if (Convert.ToChar(DataBinder.Eval(e.Row.DataItem, "TakePartIn")) == 'Y')
                {
                    chxTakePartIn.Checked = true;
                }
                else
                {
                    chxTakePartIn.Checked = false;
                }
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
                yAxisLabels[labelIndex].Text ="";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                #region Chart
                SPCTxMaskFlatInfo entity = new SPCTxMaskFlatInfo();
                entity.Type = type;
                entity.Mode = mode;
                entity.CH = ch;
                entity.DateFrom = DateTime.ParseExact(datefrom, "yyyy-MM-dd", null);
                entity.DateTo = DateTime.ParseExact(dateto, "yyyy-MM-dd", null);
                entity.GroupingNo = int.Parse(groupingno);
                entity.X = double.Parse(this.ltlX.Text);
                entity.R = double.Parse(this.ltlR.Text);
                entity.S = double.Parse(this.ltlS.Text);
                entity.USL = double.Parse(this.ltlUSL.Text);
                entity.CPU = double.Parse(this.ltlCPU.Text);

                entity.CPL = null;
                entity.CPK = double.Parse(this.ltlCPK.Text);

                entity.LCL_X = double.Parse(this.ltlLCL_X.Text);
                entity.CL_X = double.Parse(this.ltlCL_X.Text);
                entity.UCL_X = double.Parse(this.ltlUCL_X.Text);

                entity.LCL_R = double.Parse(this.ltlLCL_R.Text);
                entity.CL_R = double.Parse(this.ltlCL_R.Text);
                entity.UCL_R = double.Parse(this.ltlUCL_R.Text);

                entity.OriginalItems = originalItems;

                IList<SPCTxMaskFlatGroup> groupItems = new List<SPCTxMaskFlatGroup>();
                for (int i = 0; i < this.GVItems.Rows.Count; i++)
                {
                    SPCTxMaskFlatGroup groupItem = new SPCTxMaskFlatGroup();
                    groupItem.GroupNo = Convert.ToInt32(this.GVItems.Rows[i].Cells[0].Text);
                    groupItem.X = Convert.ToDouble(this.GVItems.Rows[i].Cells[1].Text);
                    groupItem.R = Convert.ToDouble(this.GVItems.Rows[i].Cells[2].Text);
                    CheckBox chxTakePartIn = (CheckBox)this.GVItems.Rows[i].FindControl("chxTakePartIn");
                    if (chxTakePartIn.Checked == true)
                    {
                        groupItem.TakePartIn = 'Y';
                    }
                    else
                    {
                        groupItem.TakePartIn = 'N';
                    }
                    groupItems.Add(groupItem);
                }
                entity.GroupItems = groupItems;

                IList<SPCTxMaskFlatException> exceptionItems = new List<SPCTxMaskFlatException>();
                for (int i = 0; i < this.GVXException.Rows.Count; i++)
                {
                    SPCTxMaskFlatException exceptionItem = new SPCTxMaskFlatException();
                    exceptionItem.GroupNo = Convert.ToInt32(this.GVXException.Rows[i].Cells[0].Text);
                    exceptionItem.ChartType = 'X';
                    TextBox tbxXComment = (TextBox)this.GVXException.Rows[i].FindControl("tbxXComment");
                    exceptionItem.Comment = tbxXComment.Text;
                    exceptionItems.Add(exceptionItem);
                }
                for (int i = 0; i < this.GVRException.Rows.Count; i++)
                {
                    SPCTxMaskFlatException exceptionItem = new SPCTxMaskFlatException();
                    exceptionItem.GroupNo = Convert.ToInt32(this.GVRException.Rows[i].Cells[0].Text);
                    exceptionItem.ChartType = 'R';
                    TextBox tbxRComment = (TextBox)this.GVRException.Rows[i].FindControl("tbxRComment");
                    exceptionItem.Comment = tbxRComment.Text;
                    exceptionItems.Add(exceptionItem);
                }
                entity.ExceptionItems = exceptionItems;

                int ReturnPK=SPCTxMaskFlatService.Save(entity);
                #endregion

                #region Email To Container
                if (entity.ExceptionItems.Count > 0)
                {
                    SPCEmailContainerInfo log = new SPCEmailContainerInfo();
                    log.ProjectCode = "03";
                    log.ErrorPK = ReturnPK;
                    log.Subject = "SPC统计异常 - 发射平坦度";

                    System.Text.StringBuilder builder = new System.Text.StringBuilder();
                    builder.Append("<table cellpadding='5'><tr><td>各位,好:</td><td></td></tr>");
                    builder.Append("<tr><td></td></tr>");
                    builder.Append("<tr><td></td><td>经过SPC统计，发射平坦度发生了异常，详细信息如下：</td></tr>");
                    builder.Append("<tr><td></td><td>型号：" + entity.Type + "</td></tr>");
                    builder.Append("<tr><td></td><td>业务：" + entity.Mode + "</td></tr>");
                    builder.Append("<tr><td></td><td>频点：" + entity.CH + "</td></tr>");
                    builder.Append("<tr><td></td><td>开始日期：" + entity.DateFrom.ToString("yyyy-MM-dd") + "</td></tr>");
                    builder.Append("<tr><td></td><td>结束日期：" + entity.DateTo.ToString("yyyy-MM-dd") + "</td></tr>");
                    builder.Append("<tr><td></td><td></td></tr>");

                    builder.Append("<tr><td></td><td></td></tr>");
                    builder.Append("<tr><td></td><td><i>请点击<a href='" + System.Configuration.ConfigurationManager.AppSettings["WebUrl"] +
                        "/SPCViewFromEmail.ashx?userId=SPCViewer&ProjectCode=" + log.ProjectCode + "&errorPK=" +
                        ReturnPK + "' target='_blank'><font color='blue'>这里</font></a>,即可查看异常原因.</i></td></tr>");
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
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');self.close();</script>");
        }
    }
}
