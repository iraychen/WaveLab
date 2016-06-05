<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MAMTestResultView.aspx.cs" Inherits="WaveLab.Web.MAMTestResultView" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
     <asp:Label ID ="lblTitle" runat="server"  meta:resourcekey="lblTitleResource1" />
    </HeaderTemplate>
    <ContentTemplate>
      <table width="100%" style="text-align:left;" cellspacing ="5">
        <tr>
            <td>
                <fieldset>
                    <table width="100%" cellspacing ="5">
                     <tr>
                         <td style ="width:20%"><asp:Label id ="lblType" runat ="server"  Font-Bold ="True"
                               meta:resourcekey="lblTypeResource1" /></td>
                         <td  style ="width:30%"><asp:Literal id ="ltlType" runat ="server" 
                                  meta:resourcekey="ltlTypeResource1" /></td>
                        <td style ="width:20%"><asp:Label ID="lblMBSerialNo" runat ="server" 
                                                meta:resourcekey="lblMBSerialNo"  
                                Font-Bold ="True"/></td>
                         <td style ="width:30%"><asp:Literal ID="ltlMBSerialNo" runat ="server" meta:resourcekey="ltlMBSerialNoResource1" /></td>
                     </tr>  
                      <tr>
                         <td >
                            <asp:Label ID="lblPllSerialNo" runat ="server" 
                                                meta:resourcekey="lblPllSerialNoResource1"  Font-Bold ="True"/></td>
                         <td>
                            <asp:Literal ID="ltlPllSerialNo" runat ="server"  meta:resourcekey="ltlPllSerialNoResource1" />
                         </td>
                        <td><asp:Label id ="lblIFFrequency" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblIFFrequencyResource1" /></td>
                        <td><asp:Literal id ="ltlIFFrequency" runat ="server" 
                                  meta:resourcekey="ltlIFFrequencyResource1" /></td>
                     </tr> 
                     <tr>
                        <td><asp:Label id ="lblREVMainBoard" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblREVMainBoardResource1" /></td>
                        <td><asp:Literal id ="ltlREVMainBoard" runat ="server" 
                                  meta:resourcekey="ltlREVMainBoardResource1" /></td>
                        <td><asp:Label id ="lblREVPllBoard" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblREVPllBoardResource1" /></td>
                        <td><asp:Literal id ="ltlREVPllBoard" runat ="server" 
                                  meta:resourcekey="ltlREVPllBoardResource1" /></td>
                     </tr>  
                     <tr>
                        <td><asp:Label id ="lblStationNo" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblStationNoResource1" /></td>
                        <td><asp:Literal id ="ltlStationNo" runat ="server" 
                                  meta:resourcekey="ltlStationNoResource1" /></td>
                        <td><asp:Label id ="lblEndTime" runat ="server"  Font-Bold ="True"
                               meta:resourcekey="lblEndTimeResource1" /></td>
                        <td><asp:Literal id ="ltlEndTime" runat ="server" 
                                  meta:resourcekey="ltlEndTimeResource1" /></td>
                     </tr>   
                 </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
             <fieldset>
                <table width="100%" cellspacing ="5">
                 <tr>
                    <td style ="width:20%"><asp:Label id ="lblTxLoPower" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblTxLoPowerResource1" /></td>
                    <td style ="width:30%"><asp:Literal id ="ltlTxLoPower" runat ="server" 
                              meta:resourcekey="ltlTxLoPowerResource1" /></td>
                    <td style ="width:20%"><asp:Label id ="lblRxLoPower" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblRxLoPowerResource1" /></td>
                    <td style ="width:30%"><asp:Literal id ="ltlRxLoPower" runat ="server" 
                              meta:resourcekey="ltlRxLoPowerResource1" /></td>
                 </tr>   
                 <tr>
                   <td><asp:Label id ="lblRxIF10" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblRxIF10Resource1" /></td>
                   <td><asp:Literal id ="ltlRxIF10" runat ="server" 
                              meta:resourcekey="ltlRxIF10Resource1" /></td>
                   <td><asp:Label id ="lblRxIFNegative67" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblRxIFNegative67Resource1" /></td>
                   <td><asp:Literal id ="ltlRxIFNegative67" runat ="server" 
                              meta:resourcekey="ltlRxIFNegative67Resource1" /></td>
                 </tr>   
                 <tr>
                   <td><asp:Label id ="lblAbsPrxIFOffSet" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblAbsPrxIFOffSetResource1" /></td>
                   <td><asp:Literal id ="ltlAbsPrxIFOffSet" runat ="server" 
                              meta:resourcekey="ltlAbsPrxIFOffSetResource1" /></td>
                   <td><asp:Label id ="lblTxIF" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblTxIFResource1" /></td>
                   <td><asp:Literal id ="ltlTxIF" runat ="server" 
                              meta:resourcekey="ltlTxIFResource1" /></td>
                 </tr> 
                  <tr>
                   <td><asp:Label id ="lblTxIFRange" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblTxIFRangeResource1" /></td>
                   <td><asp:Literal id ="ltlTxIFRange" runat ="server" 
                              meta:resourcekey="ltlTxIFRangeResource1" /></td>
                    <td><asp:Label id ="lblLoOffset" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblLoOffsetResource1" /></td>
                    <td><asp:Literal id ="ltlLoOffset" runat ="server" 
                              meta:resourcekey="ltlLoOffsetResource1" /></td>
                 </tr>  
                 <tr>
                     <td><asp:Label id ="lblRSSIHighLow" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblRSSIHighLowResource1" /></td>
                     <td><asp:Literal id ="ltlRSSIHighLow" runat ="server" 
                              meta:resourcekey="ltlRSSIHighLowResource1" /></td>
                    <td><asp:Label id ="lblCtrlVoltage" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblCtrlVoltageResource1" /></td>
                    <td><asp:Literal id ="ltlCtrlVoltage" runat ="server" 
                              meta:resourcekey="ltlCtrlVoltageResource1" /></td>
                 </tr>   
                 <tr>
                    <td><asp:Label id ="lblHeater" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblHeaterResource1" /></td>
                    <td><asp:Literal id ="ltlHeater" runat ="server" 
                              meta:resourcekey="ltlHeaterResource1" /></td>
                    <td><asp:Label id ="lblAging" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblAgingResource1" /></td>
                    <td><asp:Literal id ="ltlAging" runat ="server" 
                              meta:resourcekey="ltlAgingResource1" /></td>
                 </tr>    
                </table>
              </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                <table style ="width:100%; text-align:left" cellspacing ="5">
                    <tr>
                        <td colspan ="6">
                             <asp:GridView ID="GVDtl" runat="server"  AutoGenerateColumns="False" EnableViewState ="False" 
                                SkinID="skinGridView" Width ="100%"  meta:resourcekey="GVDtlResource1" >
                              <Columns>
                                  <asp:BoundField  DataField="TxIFSweep"   meta:resourcekey="BoundFieldResource1"/>
                                  <asp:BoundField  DataField="TxLoSweep"  meta:resourcekey="BoundFieldResource2"/>
                                  <asp:BoundField  DataField="RxIFSweep"  meta:resourcekey="BoundFieldResource3"/>
                              </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style ="width:10%"><asp:Label id ="lblFlatTxIF" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblFlatTxIFResource1" /></td>
                        <td style ="width:20%"><asp:Literal id ="ltlFlatTxIF" runat ="server" 
                                  meta:resourcekey="ltlFlatTxIFResource1" /></td>
                        <td style ="width:10%"><asp:Label id ="lblFlatTxLo" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblFlatTxLoResource1" /></td>
                        <td style ="width:20%"><asp:Literal id ="ltlFlatTxLo" runat ="server" 
                                  meta:resourcekey="ltlFlatTxLoResource1" /></td>
                        <td style ="width:10%"><asp:Label id ="lblFlatRxIF" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblFlatRxIFResource1" /></td>
                        <td style ="width:30%"><asp:Literal id ="ltlFlatRxIF" runat ="server" 
                                  meta:resourcekey="ltlFlatRxIFResource1" /></td>
 
                     </tr>  
                    
                </table>
               </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                   <table style ="width:100%;" cellspacing ="5">
                      <tr>
                        <td style ="width:20%"><asp:Label id ="lblTxPll" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblTxPllResource1" /></td>
                        <td style ="width:30%"><asp:Literal id ="ltlTxPll" runat ="server" 
                                  meta:resourcekey="ltlTxPllResource1" /></td>
                        <td style ="width:20%"><asp:Label id ="lblPAI" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblPAIResource1" /></td>
                        <td style ="width:30%"><asp:Literal id ="ltlPAI" runat ="server" 
                                  meta:resourcekey="ltlPAIResource1" /></td>
                     </tr>   
                     <tr>
                        <td><asp:Label id ="lblRxPll" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblRxPllResource1" /></td>
                        <td><asp:Literal id ="ltlRxPll" runat ="server" 
                                  meta:resourcekey="ltlRxPllResource1" /></td>
                        <td><asp:Label id ="lblTxPow" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblTxPowResource1" /></td>
                        <td><asp:Literal id ="ltlTxPow" runat ="server" 
                                  meta:resourcekey="ltlTxPowResource1" /></td>
                     </tr>   
                     <tr>
                        <td><asp:Label id ="lblNegative5V" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblNegative5VResource1" /></td>
                        <td><asp:Literal id ="ltlNegative5V" runat ="server" 
                                  meta:resourcekey="ltlNegative5VResource1" /></td>
                        <td><asp:Label id ="lblTxIFResult" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblTxIFResultResource1" /></td>
                        <td><asp:Literal id ="ltlTxIFResult" runat ="server" 
                                  meta:resourcekey="ltlTxIFResultResource1" /></td>
                     </tr>   
                     <tr>
                        <td><asp:Label id ="lblFirmWareVersion" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblFirmWareVersionResource1" /></td>
                        <td><asp:Literal id ="ltlFirmWareVersion" runat ="server" 
                                  meta:resourcekey="ltlFirmWareVersionResource1" /></td>
                        <td><asp:Label id ="lblBwLowHigh" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblBwLowHighResource1" /></td>
                        <td><asp:Literal id ="ltlBwLowHigh" runat ="server" 
                                  meta:resourcekey="ltlBwLowHighResource1" /></td>
                     </tr>  
                     <tr>
                        <td><asp:Label id ="lblFSKFreq" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblFSKFreqResource1" /></td>
                        <td><asp:Literal id ="ltlFSKFreq" runat ="server" 
                                  meta:resourcekey="ltlFSKFreqResource1" /></td>
                        <td><asp:Label id ="lblLoLeakage" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblLoLeakageResource1" /></td>
                        <td><asp:Literal id ="ltlLoLeakage" runat ="server" 
                                  meta:resourcekey="ltlLoLeakageResource1" /></td>
                     </tr>   
                     <tr>
                        <td><asp:Label id ="lblTemperature" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblTemperatureResource1" /></td>
                        <td><asp:Literal id ="ltlTemperature" runat ="server" 
                                  meta:resourcekey="ltlTemperatureVResource1" /></td>
                        <td><asp:Label id ="lblRemodlo" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblRemodloResource1" /></td>
                        <td><asp:Literal id ="ltlRemodlo" runat ="server" 
                                  meta:resourcekey="ltlRemodloResource1" /></td>
                     </tr>    
                     <tr>
                        <td><asp:Label id ="lblFinalFlag" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblFinalFlagResource1" /></td>
                        <td><asp:Literal id ="ltlFinalFlag" runat ="server" 
                                  meta:resourcekey="ltlFinalFlagResource1" /></td>
                     </tr>   
                     <tr>
                        <td><asp:Label id ="lblAppVersion" runat ="server"  Font-Bold ="True"
                               meta:resourcekey="lblAppVersionResource1" /></td>
                        <td><asp:Literal id ="ltlAppVersion" runat ="server" 
                                  meta:resourcekey="ltlAppVersionResource1" /></td>
                     </tr>   
                     <tr>
                        <td><asp:Label id ="lblOperator" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblOperatorResource1" /></td>
                        <td><asp:Literal id ="ltlOperator" runat ="server" 
                                  meta:resourcekey="ltlOperatorResource1" /></td>
                     </tr>  
                    </table>
                </fieldset>
            </td>
        </tr>
         <tr>
            <td >
                <fieldset>
                <asp:Chart ID="chartResult" runat="server" Width="700px" Height="400px" 
                    BackColor="211, 223, 240" BorderColor="#404040" BorderDashStyle="Solid" 
                    BackSecondaryColor="White"  BorderWidth="2px" 
                           oncustomizelegend="chartResult_CustomizeLegend"
                    meta:resourcekey="chartResultResource1" >
                        <Titles >
                            <asp:Title Text="Test Result"  Font="Microsoft Sans Serif, 10pt" />
                        </Titles>
                        <Legends>
                            <asp:Legend Name ="Legends1"  Alignment="Center" BorderColor="DimGray"  TableStyle="Tall"> </asp:Legend>
                        </Legends>
                       <Series>
                           <asp:Series Name="Series1" ChartArea="ChartArea1"  ChartType="Line"  LegendText="Tx IF Filter"   MarkerStyle="Diamond"  MarkerSize="8" Color="0,0,128" />
                           <asp:Series Name="Series2" ChartArea="ChartArea1"  ChartType="Line"  LegendText="Tx LO Filter"   MarkerStyle="Square"  MarkerSize="8" Color="255,0,255" />
                           <asp:Series Name="Series3" ChartArea="ChartArea1"  ChartType="Line"  LegendText="Tx IF Filter"   MarkerStyle="Triangle" MarkerSize="8" Color="255,255,0"/>                     
                       </Series>
                       <ChartAreas>
                          <asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64"  >
                                <axisx Title="Freq Point"  IsLabelAutoFit="False"     >
                                    <MajorGrid Enabled="false" />
                                    
	                                <labelstyle font="Trebuchet MS, 8.25pt"   />
                                </axisx>
                                <axisy  Title ="(dB)" IsLabelAutoFit="False" >
	                                <labelstyle font="Trebuchet MS, 8.25pt" />
	                                
                                </axisy>
                            </asp:chartarea>
                       </ChartAreas>
                   </asp:Chart>
                </fieldset>
            </td>
         </tr>
      </table>
   </ContentTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer> 
</asp:Content>