<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="TxCalView.aspx.cs" Inherits="WaveLab.Web.TxCalView" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
     <asp:Label ID ="lblBasicInfo" runat="server" meta:resourcekey="lblBasicInfoResource1" />
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
             <td><asp:Label ID="lblTuningPot" runat ="server"  Font-Bold ="True" 
                    meta:resourcekey="lblTuningPotResource1" /></td>
             <td><asp:Literal ID="ltlTuningPot" runat ="server" 
                    meta:resourcekey="ltlTuningPotResource1" /></td>
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
       <asp:Label ID ="lblFlashDataTitle" runat="server"  meta:resourcekey="lblFlashDataTitleResource1" />
    </HeaderTemplate>
    <ContentTemplate>
       <center>
     <table style ="text-align:left; width:100%" cellpadding="3" >
        <tr>
            <td>
                <asp:ListView ID="LVResult"  runat="server" 
                    ItemPlaceholderID="layoutTableTemplate"   EnableViewState="False">
                    <LayoutTemplate>
                        <table  class="common-table" cellpadding="1" cellspacing="1" width="100%">
                            <tr >
                                <th colspan="4" style ="text-align:center"><asp:Label ID="lblTxPowerSetTable" runat ="server" 
                                        meta:resourcekey="lblTxPowerSetTableResource1" /></th>
                                <th colspan="4" style ="text-align:center"><asp:Label ID="lblTxPowerDetectTable" runat ="server" 
                                        meta:resourcekey="lblTxPowerDetectTableResource1" /></th>
                                <th colspan="4" style ="text-align:center"><asp:Label ID="lblChannelPowerSetTable" runat ="server" 
                                        meta:resourcekey="lblChannelPowerSetTableResource1" /></th>
                            </tr>
                            <tr >
                                  <!--Tx Power Set Table--> 
                                <th style ="text-align:center"><asp:Label ID="lblTPSTDbm" runat ="server" 
                                        meta:resourcekey="lblTPSTDbmResource1" /></th>
                                <th style ="text-align:center"><asp:Label ID="lblTPSTTxPowSetData" runat ="server" 
                                        meta:resourcekey="lblTPSTTxPowSetDataResource1" /></th>
                                <th style ="text-align:center"><asp:Label ID="lblTPSTAddress" runat ="server" 
                                        meta:resourcekey="lblTPSTAddressResource1" /></th>  
                                <th style ="text-align:center"><asp:Label ID="lblContoledVoltage" runat ="server" 
                                        meta:resourcekey="lblTPSTContoledVoltageResource1" /></th>     
                                       
                                <!--Tx Power Detect Table--> 
                                <th style ="text-align:center"><asp:Label ID="lblTPDTVref" runat ="server" 
                                        meta:resourcekey="lblTPDTVrefResource1" /></th>
                                <th style ="text-align:center"><asp:Label ID="lblTPDTTxPow" runat ="server" 
                                        meta:resourcekey="lblTPDTTxPowResource1" /></th>
                                <th style ="text-align:center"><asp:Label ID="lblTPDTVoltage" runat ="server" 
                                        meta:resourcekey="lblTPDTVoltageResource1" /></th> 
                                <th style ="text-align:center"><asp:Label ID="lblTPDTAddress" runat ="server" 
                                        meta:resourcekey="lblTPDTAddressResource1" /></th>  
                                          
                                <!--Channel Power Set Table-->    
                                <th style ="text-align:center"><asp:Label ID="lblChannelNo" runat ="server" 
                                        meta:resourcekey="lblChannelNoResource1" /></th>
                                <th style ="text-align:center"><asp:Label ID="lblChannelOutData" runat ="server" 
                                        meta:resourcekey="lblChannelOutDataResource1" /></th>
                                <th style ="text-align:center"><asp:Label ID="lblChannelPower" runat ="server" 
                                        meta:resourcekey="lblChannelPowerResource1" /></th>
                                <th style ="text-align:center"><asp:Label ID="lblChannelAddress" runat ="server" 
                                        meta:resourcekey="lblChannelAddressResource1" /></th>
                            </tr>
                            <asp:PlaceHolder ID="layoutTableTemplate" runat="server" />
                        </table>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                       <tr style ="background-color:White">
                           <td style="text-align:center"><%# Eval("TPSTDbm") %> </td>
                           <td style="text-align:center"><%# Eval("TPSTTxPowSetData")%></td>
                           <td style="text-align:center"><%# Eval("TPSTAddress")%> </td>
                           <td style="text-align:center"><%#String.Format("{0:f2}",Eval("TPSTControledVoltage"))%></td>
                           
                           <td style="text-align:center"><%# Eval("TPDTVref")%> </td>
                           <td style="text-align:center"><%# Eval("TPDTTxPow")%></td>
                           <td style="text-align:center"><%# String.Format("{0:f2}",Eval("TPDTVoltage"))%></td>
                           <td style="text-align:center"><%# Eval("TPDTAddress")%></td>

                           <td style="text-align:center"><%# Eval("ChannelNo")%> </td>
                           <td style="text-align:center"><%# Eval("ChannelOutData")%></td>
                           <td style="text-align:center"><%# Eval("ChannelPower")%></td>
                           <td style="text-align:center"><%# Eval("ChannelAddress")%></td>
                       </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style ="background-color:#e6e6e6">
                           <td style="text-align:center"><%# Eval("TPSTDbm") %> </td>
                           <td style="text-align:center"><%# Eval("TPSTTxPowSetData")%></td>
                           <td style="text-align:center"><%# Eval("TPSTAddress")%> </td>
                           <td style="text-align:center"><%# String.Format("{0:f2}",Eval("TPSTControledVoltage"))%></td>
                           
                           <td style="text-align:center"><%# Eval("TPDTVref")%> </td>
                           <td style="text-align:center"><%# Eval("TPDTTxPow")%></td>
                           <td style="text-align:center"><%# String.Format("{0:f2}",Eval("TPDTVoltage"))%></td>
                           <td style="text-align:center"><%# Eval("TPDTAddress")%></td>

                           <td style="text-align:center"><%# Eval("ChannelNo")%> </td>
                           <td style="text-align:center"><%# Eval("ChannelOutData")%></td>
                           <td style="text-align:center"><%# Eval("ChannelPower")%></td>
                           <td style="text-align:center"><%# Eval("ChannelAddress")%></td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:ListView>
            </td>
        </tr>
    </table>
    </center>
     </ContentTemplate>
</ajaxToolkit:TabPanel>
 
<ajaxToolkit:TabPanel ID="TabPanel3" runat="server">
    <HeaderTemplate>
      <asp:Label ID ="lblTxCalPicture" runat="server" meta:resourcekey="lblTxCalPictureResource1" />
    </HeaderTemplate>
    <ContentTemplate>
      <center>
        <div>
            <asp:Chart ID="chartTxCalPowerResult" runat="server" Width="950px" Height="400px" 
            BackColor="#D3DFF0" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" Palette="BrightPastel" 
            BackSecondaryColor="White"  BorderWidth="2"  >
                <Titles >
                    <asp:Title Text="TX Calibrate Power Result"  Font="Microsoft Sans Serif, 10pt" />
                </Titles>
                <Legends>
                    <asp:Legend Name ="Legends1"  Alignment="Center" BorderColor="DimGray" >
                    </asp:Legend>
                </Legends>
               <Series>
                   <asp:Series Name="Series1" ChartArea="ChartArea1"  ChartType="Line" Legend="Legends1" LegendText="Tx-pow Set Data"   MarkerStyle="Diamond"  MarkerSize="8" ></asp:Series>
               </Series>
               <ChartAreas>
                  <asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64"  >
			            <axisx linecolor="64, 64, 64, 64" Title="Power(dBm)"  IsLabelAutoFit="False" IsStartedFromZero="false" Minimum="-15"  Interval="10"    Maximum ="40"   >
				            <labelstyle font="Trebuchet MS, 8.25pt"   />
			            </axisx>
    					
			            <axisy linecolor="64, 64, 64, 64" Title ="Rx-pow Set Data" IsLabelAutoFit="False" Minimum ="0" Interval="50" Maximum ="300">
				            <labelstyle font="Trebuchet MS, 8.25pt" />
			            </axisy>
	                </asp:chartarea>
               </ChartAreas>
           </asp:Chart>
       </div>
       <div>
        <asp:Chart ID="chartTxCalCHResult" runat="server" Width="950px" Height="400px" 
        BackColor="#D3DFF0" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" Palette="BrightPastel" 
        BackSecondaryColor="White"  BorderWidth="2"   >
            <Titles >
                <asp:Title Text="TX Calibrate CH. Result"  Font="Microsoft Sans Serif, 10pt" />
            </Titles>
            <Legends>
                <asp:Legend Name ="Legends1"  Alignment="Center" BorderColor="DimGray" >
                </asp:Legend>
            </Legends>
           <Series>
               <asp:Series Name="Series1" ChartArea="ChartArea1"  ChartType="Line" Legend="Legends1" LegendText="Tx-pow Set Data"   MarkerStyle="Diamond"  MarkerSize="8" ></asp:Series>
           </Series>
           <ChartAreas >
              <asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64"    > 
					<axisx linecolor="64, 64, 64, 64" Title="k_channel"  Interval="1"   >
						<labelstyle font="Trebuchet MS, 8.25pt"   />
					</axisx>
					<axisy  Title ="Rx-pow Set Data(CH)"  Interval="1" >
						<labelstyle font="Trebuchet MS, 8.25pt" />
					</axisy>
			    </asp:chartarea>
           </ChartAreas>
       </asp:Chart>     
       </div>
    </center>
    </ContentTemplate>
 </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>     
</asp:Content>
