<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RxCalView.aspx.cs" Inherits="WaveLab.Web.RxCalView" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<ajaxToolkit:TabContainer ID="TabContainer1" runat="server" 
            ActiveTabIndex="0"         
        OnDemand="true"
        TabStripPlacement="Top"
        UseVerticalStripPlacement="true"
        VerticalStripWidth="120px" >
<ajaxToolkit:TabPanel ID="TabPanel1" runat="server">
    <HeaderTemplate>
    <asp:Label ID ="lblBasicInfo" runat="server"    meta:resourcekey="lblBasicInfoResource1" />
    </HeaderTemplate>
    <ContentTemplate>
    <center>
      <table  width="100%" cellpadding="3" cellspacing="0" style="text-align:left;" class="setup-table">
         <tr style ="width:200px">
             <td><asp:Label id ="lblModel" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblModelResource1" /></td>
             <td ><asp:Literal id ="ltlModel" runat ="server" 
                      meta:resourcekey="ltlModelResource1" /></td>
         </tr>
         
          <tr>
             <td >
                <asp:Label ID="lblSerialNo" runat ="server" 
                                    meta:resourcekey="lblSerialNoResource1"  Font-Bold ="True"/></td>
             <td>
                <asp:Literal ID="ltlSerialNo" runat ="server"  meta:resourcekey="ltlSerialNoResource1" />
             </td>
         </tr>  
         <tr>
             <td><asp:Label ID="lblStationNo" runat ="server"  Font-Bold ="True" 
                    meta:resourcekey="lblStationNoResource1" /></td>
             <td><asp:Literal ID="ltlStationNo" runat ="server" 
                    meta:resourcekey="ltlStationNoResource1" /></td>
         </tr>
         <tr>
            <td><asp:Label ID="lblChNo" runat ="server"  Font-Bold ="True" 
                    meta:resourcekey="lblChNoResource1" /></td>
            <td><asp:Literal ID="ltlChNo" runat ="server" 
                    meta:resourcekey="ltlChNoResource1" /></td>
          </tr>
          <tr>
            <td><asp:Label ID="lblWGNo" runat ="server"  Font-Bold ="True" 
                    meta:resourcekey="lblWGNoResource1" /></td>
            <td><asp:Literal ID="ltlWGNo" runat ="server" 
                    meta:resourcekey="ltlWGNoResource1" /></td>
          </tr>
         <tr>
            <td><asp:Label id ="lblEndTime" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblEndTimeResource1" /></td>
            <td><asp:Literal id ="ltlEndTime" runat ="server" 
                      meta:resourcekey="ltlEndTimeResource1" /></td>
         </tr> 
         <tr>
             <td><asp:Label id ="lblRunningTime" runat ="server"  Font-Bold ="True"
                     meta:resourcekey="lblRunningTimeResource1" /></td>
              <td><asp:Literal id ="ltlRunningTime" runat ="server" 
                      meta:resourcekey="ltlRunningTimeResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblAppVersion" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblAppVersionResource1" /></td>
            <td><asp:Literal id ="ltlAppVersion" runat ="server" 
                      meta:resourcekey="ltlAppVersionResource1" /></td>
         </tr>   
          <tr>
            <td><asp:Label id ="lblReason" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblReasonResource1" /></td>
            <td><asp:Literal id ="ltlReason" runat ="server" 
                      meta:resourcekey="ltlReasonResource1" /></td>
         </tr> 
         <tr>
            <td><asp:Label id ="lblFinalFlag" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblFinalFlagResource1" /></td>
            <td><asp:Literal id ="ltlFinalFlag" runat ="server" 
                      meta:resourcekey="ltlFinalFlagResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblOperator" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblOperatorResource1" /></td>
            <td><asp:Literal id ="ltlOperator" runat ="server" 
                      meta:resourcekey="ltlOperatorResource1" /></td>
         </tr>    
       </table>
     </center>
    </ContentTemplate>
 </ajaxToolkit:TabPanel>
 
<ajaxToolkit:TabPanel ID="TabPanel2" runat="server">
    <HeaderTemplate>
      <asp:Label ID ="lblFlashDataTitle" runat="server"   meta:resourcekey="lblFlashDataTitleResource1" />
    </HeaderTemplate>
    <ContentTemplate>
    <center>
     <table style ="text-align:center" cellpadding="3" width="100%">
        <tr>
            <td>
               <asp:GridView ID="GVResult" runat="server"  SkinId="skinGridView"
                    AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"
                     meta:resourcekey="GVResultResource1"  >
                  <Columns>
                      <asp:BoundField  DataField="Data" meta:resourcekey="BoundFieldResource1" HeaderStyle-HorizontalAlign="Center"/>
                      <asp:BoundField  DataField="RSSI" meta:resourcekey="BoundFieldResource2" HeaderStyle-HorizontalAlign="Center"/>
                      <asp:BoundField  DataField="Voltage" DataFormatString="{0:f3}"  HeaderStyle-HorizontalAlign="Center"
                          meta:resourcekey="BoundFieldResource3"/>
                      <asp:BoundField  DataField="Address" meta:resourcekey="BoundFieldResource4" HeaderStyle-HorizontalAlign="Center"/>
                  </Columns>
                </asp:GridView>  
            </td>
        </tr>
    </table>
    </center>
    </ContentTemplate>
</ajaxToolkit:TabPanel>
 
<ajaxToolkit:TabPanel ID="TabPanel3" runat="server">
    <HeaderTemplate>
      <asp:Label ID ="lblRxCalPicture" runat="server"   meta:resourcekey="lblRxCalPictureResource1" />
    </HeaderTemplate>
    <ContentTemplate>
     <center>
        <asp:Chart ID="chartRxCalResult" runat="server" Width="600px" Height="400px" 
        BackColor="211, 223, 240" BorderColor="#1A3B69" BorderDashStyle="Solid" 
        BackSecondaryColor="White"  BorderWidth="2px" 
                oncustomizelegend="chartRxCalResult_CustomizeLegend" 
            meta:resourcekey="chartRxCalResultResource1">
            <Titles >
                <asp:Title Text="RX Calibrate Result"  Font="Microsoft Sans Serif, 10pt" />
            </Titles>
            <Legends>
                <asp:Legend Name ="Legends1"  Alignment="Center" BorderColor="DimGray">
                </asp:Legend>
            </Legends>
           <Series>
               <asp:Series Name="Series1" ChartArea="ChartArea1"  Legend="Legends1"     ChartType="Point"  LegendText="RSSI" MarkerStyle="Diamond"  MarkerSize ="7">
               </asp:Series>
           </Series>
           <ChartAreas>
              <asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent">
				  
			    <area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False" ></area3dstyle>
				<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" Title ="Rx - Pow Set Data" Interval="10">
					<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
					<majorgrid linecolor="64, 64, 64, 64" />
				</axisy>
				<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False"  Minimum="0" Title="Power (dBm)" >
					<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"     ForeColor="#D3DFF0"/>
					<majorgrid linecolor="64, 64, 64, 64" />
				</axisx>
				<axisx2 linecolor="64, 64, 64, 64" IsLabelAutoFit="False"  Minimum="0"  Enabled ="True" >
					<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
					<majorgrid linecolor="64, 64, 64, 64" />
				</axisx2>
		    </asp:chartarea>
           </ChartAreas>
       </asp:Chart>
    </center>
    </ContentTemplate>
 </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>   
</asp:Content>