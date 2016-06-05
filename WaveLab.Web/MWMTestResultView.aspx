<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MWMTestResultView.aspx.cs" Inherits="WaveLab.Web.MWMTestResultView" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
    $(document).ready(function()
    {
        $( "#tabs" ).tabs();
    });
</script>
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
     <asp:Label ID ="lblTitle" runat="server" meta:resourcekey="lblTitleResource1" />
    </HeaderTemplate>
    <ContentTemplate>
         <table width="100%" style="text-align:left;" cellspacing ="5">
            <tr>
                <td>
                    <table width="100%" class ="setup-table">
                     <tr>
                         <td style ="width:20%"><asp:Label id ="lblType" runat ="server"  Font-Bold ="True"
                               meta:resourcekey="lblTypeResource1" /></td>
                         <td  style ="width:30%"><asp:Literal id ="ltlType" runat ="server" 
                                  meta:resourcekey="ltlTypeResource1" /></td>
                        <td style ="width:20%"><asp:Label ID="lblSerialNo" runat ="server" 
                                                meta:resourcekey="lblSerialNo"  
                                Font-Bold ="True"/></td>
                         <td style ="width:30%"><asp:Literal ID="ltlSerialNo" runat ="server" meta:resourcekey="ltlSerialNoResource1" /></td>
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
                     <tr>
                   
                        <td><asp:Label id ="lblAppVersion" runat ="server"  Font-Bold ="True"
                               meta:resourcekey="lblAppVersionResource1" /></td>
                        <td><asp:Literal id ="ltlAppVersion" runat ="server" 
                                  meta:resourcekey="ltlAppVersionResource1" /></td>
     
                        <td><asp:Label id ="lblOperator" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblOperatorResource1" /></td>
                        <td><asp:Literal id ="ltlOperator" runat ="server" 
                                  meta:resourcekey="ltlOperatorResource1" /></td>
                     </tr>  
                     <tr>
                        <td><asp:Label id ="lblFinalFlag" runat ="server"  Font-Bold ="True"
                                meta:resourcekey="lblFinalFlagResource1" /></td>
                        <td><asp:Literal id ="ltlFinalFlag" runat ="server" 
                                  meta:resourcekey="ltlFinalFlagResource1" /></td>
                        <td></td>
                        <td></td>
                     </tr>
                 </table>
                </td>
            </tr>
            <tr>
                <td>
                 <fieldset>
                    <table width="100%">
                       <tr>
                            <td>
                                 <asp:GridView ID="GVDtl" runat="server"  AutoGenerateColumns="False" EnableViewState ="False" 
                                    SkinID="skinGridView" Width ="100%"  meta:resourcekey="GVDtlResource1" >
                                  <Columns>
                                      <asp:BoundField  DataField="TxIndex"   meta:resourcekey="BoundFieldResource1"/>
                                      <asp:BoundField  DataField="TxFreq"  meta:resourcekey="BoundFieldResource2"/>
                                      <asp:BoundField  DataField="TxPow"  meta:resourcekey="BoundFieldResource3"/>
                                      <asp:BoundField  DataField="TxSpurFreq"  meta:resourcekey="BoundFieldResource4"/>
                                      <asp:BoundField  DataField="TxSpurPow"  meta:resourcekey="BoundFieldResource5"/>
                                      <asp:BoundField  DataField="TxGain"  meta:resourcekey="BoundFieldResource6"/>
                                      
                                      <asp:BoundField  DataField="RxIFFreq"  meta:resourcekey="BoundFieldResource7"/>
                                      <asp:BoundField  DataField="RxIFPow"  meta:resourcekey="BoundFieldResource8"/>
                                      <asp:BoundField  DataField="RxSpurFreq"  meta:resourcekey="BoundFieldResource9"/>
                                      <asp:BoundField  DataField="RxSpurPow"  meta:resourcekey="BoundFieldResource10"/>
                                      <asp:BoundField  DataField="RxIFGain"  meta:resourcekey="BoundFieldResource11"/>
                                      
                                    <%--  <asp:BoundField  DataField="NoiseFigure"  meta:resourcekey="BoundFieldResource12"/>--%>
                                  </Columns>
                                </asp:GridView>
                            </td>
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
                            <td valign="top">
                                <table  class ="setup-table" cellpadding="5" width ="350px">
                                      <tr>
                                        <td style =" width:200px"><asp:Label id ="lblTxP1dB" runat ="server"  Font-Bold ="True"
                                                meta:resourcekey="lblTxP1dBResource1" /></td>
                                        <td style =" width:100px"><asp:Literal id ="ltlTxP1dB" runat ="server" 
                                                  meta:resourcekey="ltlTxP1dBResource1" /></td>
                                      </tr>
                                      <tr>
                                        <td><asp:Label id ="lblTxGainFlatness" runat ="server"  Font-Bold ="True"
                                                meta:resourcekey="lblTxGainFlatnessResource1" /></td>
                                        <td ><asp:Literal id ="ltlTxGainFlatness" runat ="server" 
                                                  meta:resourcekey="ltlTxGainFlatnessResource1" /></td>
                                     </tr> 
                                     <tr>
                                        <td><asp:Label id ="lblTxLoRejectMin" runat ="server"  Font-Bold ="True"
                                                meta:resourcekey="lblTxLoRejectMinResource1" /></td>
                                        <td ><asp:Literal id ="ltlTxLoRejectMin" runat ="server" 
                                                  meta:resourcekey="ltlTxLoRejectMinResource1" /></td>
                                     </tr>   
                                      <tr>
                                        <td><asp:Label id ="lblTxLoRejectMax" runat ="server"  Font-Bold ="True"
                                                meta:resourcekey="lblTxLoRejectMaxResource1" /></td>
                                        <td ><asp:Literal id ="ltlTxLoRejectMax" runat ="server" 
                                                  meta:resourcekey="ltlTxLoRejectMaxResource1" /></td>
                                     </tr>     
                                     <tr>
                                       <td><asp:Label id ="lblTxAttnDiff" runat ="server"  Font-Bold ="True"
                                               meta:resourcekey="lblTxAttnDiffResource1" /></td>
                                       <td><asp:Literal id ="ltlTxAttnDiff" runat ="server" 
                                                  meta:resourcekey="ltlTxAttnDiffResource1" /></td>
                                      </tr>
                                      <tr>
                                        <td><asp:Label id ="lblRxGainFlatness" runat ="server"  Font-Bold ="True"
                                                meta:resourcekey="lblRxGainFlatnessResource1" /></td>
                                        <td><asp:Literal id ="ltlRxGainFlatness" runat ="server" 
                                                  meta:resourcekey="ltlRxGainFlatnessResource1" /></td>
                                     </tr>   
                                     <tr>
                                        <td><asp:Label id ="lblCurrentOn5V1" runat ="server"  Font-Bold ="True"
                                               meta:resourcekey="lblCurrentOn5V1Resource1" /></td>
                                       <td><asp:Literal id ="ltlCurrentOn5V1" runat ="server" 
                                                  meta:resourcekey="ltlCurrentOn5V1Resource1" /></td>
                                      </tr>
                                      <tr>
                                        <td><asp:Label id ="lblCurrentOn5V2" runat ="server"  Font-Bold ="True"
                                               meta:resourcekey="lblCurrentOn5V2Resource1" /></td>
                                       <td><asp:Literal id ="ltlCurrentOn5V2" runat ="server" 
                                                  meta:resourcekey="ltlCurrentOn5V2Resource1" /></td>
                                     </tr>
                                     <tr>
                                       <td><asp:Label id ="lblCurrentOn5V3" runat ="server"  Font-Bold ="True"
                                               meta:resourcekey="lblCurrentOn5V3Resource1" /></td>
                                       <td><asp:Literal id ="ltlCurrentOn5V3" runat ="server" 
                                                  meta:resourcekey="ltlCurrentOn5V3Resource1" /></td>
                                     </tr>
                                     <tr>
                                       <td><asp:Label id ="lblCurrentOnHPA" runat ="server"  Font-Bold ="True"
                                               meta:resourcekey="lblCurrentOnHPAResource1" /></td>
                                       <td><asp:Literal id ="ltlCurrentOnHPA" runat ="server" 
                                                  meta:resourcekey="ltlCurrentOnHPAResource1" /></td>
                                      </tr> 
                                      <tr>
                                        <td><asp:Label id ="lblPwrDVoltage" runat ="server"  Font-Bold ="True"
                                                meta:resourcekey="lblPwrDVoltageResource1" /></td>
                                        <td><asp:Literal id ="ltlPwrDVoltage" runat ="server" 
                                                  meta:resourcekey="ltlPwrDVoltageResource1" /></td>
                                       </tr>
                                       <tr>
                                        <td><asp:Label id ="lblPwrRVoltage" runat ="server"  Font-Bold ="True"
                                                meta:resourcekey="lblPwrRVoltageResource1" /></td>
                                        <td><asp:Literal id ="ltlPwrRVoltage" runat ="server" 
                                                  meta:resourcekey="ltlPwrRVoltageResource1" /></td>
                                       </tr>
                                       <tr>
                                         <td><asp:Label id ="lblRefDVoltage" runat ="server"  Font-Bold ="True"
                                               meta:resourcekey="lblRefDVoltageResource1" /></td>
                                         <td><asp:Literal id ="ltlRefDVoltage" runat ="server" 
                                                  meta:resourcekey="ltlRefDVoltageResource1" /></td>
                                      </tr> 
                                      <tr>
                                        <td><asp:Label id ="lblAbsVerfVpwrDOffset" runat ="server"  Font-Bold ="True"
                                                meta:resourcekey="lblAbsVerfVpwrDOffsetResource1" /></td>
                                        <td><asp:Literal id ="ltlAbsVerfVpwrDOffset" runat ="server" 
                                                  meta:resourcekey="ltlAbsVerfVpwrDOffsetResource1" /></td>
                                     </tr>   
                     
                                </table>
                            </td>
                            <td align ="center">
                                 <asp:Chart ID="chartResult" runat="server" Width="700px" Height="400px" 
                                    BackColor="211, 223, 240" BorderColor="#404040" BorderDashStyle="Solid" 
                                    BackSecondaryColor="White"  BorderWidth="2px" 
                                    meta:resourcekey="chartResultResource1" >
                                        <Titles >
                                            <asp:Title Text="Test Result"  Font="Microsoft Sans Serif, 10pt" />
                                        </Titles>
                                        <Legends>
                                            <asp:Legend Name ="Legends1"  Alignment="Center" BorderColor="DimGray" > </asp:Legend>
                                        </Legends>
                                       <Series>
                                           <asp:Series Name="Series1" ChartArea="ChartArea1"  ChartType="Line"  LegendText="Tx Gain"   MarkerStyle="Diamond"  MarkerSize="8" Color="0,0,128" />
                                           <asp:Series Name="Series2" ChartArea="ChartArea1"  ChartType="Line"  LegendText="Rx IF Gain"   MarkerStyle="Square"  MarkerSize="8" Color="255,0,255" />
                                       </Series>
                                       <ChartAreas>
                                          <asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64"  >
		                                        <axisx Title="Freq Point">
		                                            <MajorGrid Enabled="false" />
			                                        <labelstyle font="Trebuchet MS, 8.25pt"   />
		                                        </axisx>
		                                        <axisy  Title ="(dB)" IsStartedFromZero="false" >
		                                        </axisy>
                                            </asp:chartarea>
                                       </ChartAreas>
                                   </asp:Chart>
                            </td>
                        </tr>
                    </table>
                   </fieldset>
                </td>
            </tr>
          </table>
    </ContentTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>    
</asp:Content>
