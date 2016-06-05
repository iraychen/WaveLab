<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="TempretureCirculationView.aspx.cs" Inherits="WaveLab.Web.TempretureCirculationView" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
      <table width="100%" cellpadding="0" cellspacing="0" style="text-align:left;" >
        <tr>
            <td>
                <asp:Image ID="imgBasicInfo" runat ="server" SkinID ="imgBlueArrow" 
                    meta:resourcekey="imgBasicInfoResource1" />
                <asp:Label ID="lblBasicInfo" runat ="server"  Font-Bold ="True" Font-Size="12px"
                    meta:resourcekey="lblBasicInfoResource1" />
            </td>
        </tr>
        <tr>
            <td>
               <table width="100%" cellpadding="2" cellspacing="0"  class="setup-table">
                 <tr >
                     <td style ="width:30%"><asp:Label id ="lblModel" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblModelResource1" /></td>
                     <td ><asp:Literal id ="ltlModel" runat ="server" 
                              meta:resourcekey="ltlModelResource1" /></td>
                 </tr>
                
                 <tr>
                     <td>
                        <asp:Label ID="lblSerialNo" runat ="server" 
                                            meta:resourcekey="lblSerialNoResource1"  Font-Bold ="True"/></td>
                     <td>
                        <asp:Literal ID="ltlSerialNo" runat ="server"  meta:resourcekey="ltlSerialNoResource1" />
                     </td>
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
                    <td><asp:Label id ="lblIDUType" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblIDUTypeResource1" /></td>
                    <td><asp:Literal id ="ltlIDUType" runat ="server" 
                              meta:resourcekey="ltlIDUTypeResource1" /></td>
                 </tr>    
                 <tr>
                    <td><asp:Label id ="lblFinalFlag" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblFinalFlagResource1" /></td>
                    <td><asp:Literal id ="ltlFinalFlag" runat ="server" 
                              meta:resourcekey="ltlFinalFlagResource1" /></td>
                 </tr> 
                 <tr>
                    <td><asp:Label id ="lblBusinese" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblBusineseResource1" /></td>
                    <td><asp:Literal id ="ltlBusinese" runat ="server" 
                              meta:resourcekey="ltlBusineseResource1" /></td>
                 </tr>    
                 <tr>
                    <td><asp:Label id ="lblOperator" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblOperatorResource1" /></td>
                    <td><asp:Literal id ="ltlOperator" runat ="server" 
                              meta:resourcekey="ltlOperatorResource1" /></td>
                 </tr>  
             </table>
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:Image ID="imgAlarmItems" runat ="server" SkinID ="imgBlueArrow" 
                    meta:resourcekey="imgAlarmItemsResource1" />
                <asp:Label ID="lblAlarmItems" runat ="server"  Font-Bold ="True" Font-Size="12px"
                    meta:resourcekey="lblAlarmItemsResource1" />
            </td>
        </tr>
        <tr>
            <td>
               <table width="100%" cellpadding="2" cellspacing="0"  class="setup-table">
                 <tr>
                     <td style ="width:30%"><asp:Label id ="lblFecCorByteCnt" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblFecCorByteCntResource1" /></td>
                     <td ><asp:Literal id ="ltlFecCorByteCnt" runat ="server" 
                              meta:resourcekey="ltlFecCorByteCntResource1" /></td>
                 </tr>
                 <tr>
                    <td ><asp:Label ID="lblFecUncorBlockCnt" runat ="server" 
                                            meta:resourcekey="lblFecUncorBlockCntResource1"  
                            Font-Bold ="True"/></td>
                     <td><asp:Literal ID="ltlFecUncorBlockCnt" runat ="server" meta:resourcekey="ltlCodeResource1" /></td>
                 </tr>  
                 <tr>
                     <td>
                        <asp:Label ID="lblMSRDI" runat ="server" 
                                            meta:resourcekey="lblMSRDIResource1"  Font-Bold ="True"/></td>
                     <td>
                        <asp:Literal ID="ltlMSRDI" runat ="server"  meta:resourcekey="ltlMSRDIResource1" />
                     </td>
                 </tr>   
                 <tr>
                    <td><asp:Label id ="lblRLOS" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblRLOSResource1" /></td>
                    <td><asp:Literal id ="ltlRLOS" runat ="server" 
                              meta:resourcekey="ltlRLOSResource1" /></td>
                 </tr>   
                 <tr>
                     <td><asp:Label id ="lblAUAIS" runat ="server"  Font-Bold ="True"
                             meta:resourcekey="lblAUAISResource1" /></td>
                      <td><asp:Literal id ="ltlAUAIS" runat ="server" 
                              meta:resourcekey="ltlAUAISResource1" /></td>
                 </tr>    
                 <tr>
                    <td><asp:Label id ="lblTUAIS" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblTUAISResource1" /></td>
                    <td><asp:Literal id ="ltlTUAIS" runat ="server" 
                              meta:resourcekey="ltlTUAISResource1" /></td>
                 </tr>   
                 <tr>
                    <td><asp:Label id ="lblRadioRslLow" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblRadioRslLowResource1" /></td>
                    <td><asp:Literal id ="ltlRadioRslLow" runat ="server" 
                              meta:resourcekey="ltlRadioRslLowResource1" /></td>
                 </tr>   
                 <tr>
                    <td><asp:Label id ="lblRadioRslHigh" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblRadioRslHighResource1" /></td>
                    <td><asp:Literal id ="ltlRadioRslHigh" runat ="server" 
                              meta:resourcekey="ltlRadioRslHighResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblRadioTslLow" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblRadioTslLowResource1" /></td>
                    <td><asp:Literal id ="ltlRadioTslLow" runat ="server" 
                              meta:resourcekey="ltlRadioTslLowResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblRadioTslHigh" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblRadioTslHighResource1" /></td>
                    <td><asp:Literal id ="ltlRadioTslHigh" runat ="server" 
                              meta:resourcekey="ltlRadioTslHighResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblRadioMute" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblRadioMuteResource1" /></td>
                    <td><asp:Literal id ="ltlRadioMute" runat ="server" 
                              meta:resourcekey="ltlRadioMuteResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblPowerAlm" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblPowerAlmResource1" /></td>
                    <td><asp:Literal id ="ltlPowerAlm" runat ="server" 
                              meta:resourcekey="ltlPowerAlmResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblHardBad" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblHardBadResource1" /></td>
                    <td><asp:Literal id ="ltlHardBad" runat ="server" 
                              meta:resourcekey="ltlHardBadResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblTempAlarm" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblTempAlarmResource1" /></td>
                    <td><asp:Literal id ="ltlTempAlarm" runat ="server" 
                              meta:resourcekey="ltlTempAlarmResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblIFInpwrAbn" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblIFInpwrAbnResource1" /></td>
                    <td><asp:Literal id ="ltlIFInpwrAbn" runat ="server" 
                              meta:resourcekey="ltlIFInpwrAbnResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblBdStatus" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblBdStatusResource1" /></td>
                    <td><asp:Literal id ="ltlBdStatus" runat ="server" 
                              meta:resourcekey="ltlBdStatusResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblHpRdi" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblHpRdiResource1" /></td>
                    <td><asp:Literal id ="ltlHpRdi" runat ="server" 
                              meta:resourcekey="ltlHpRdiResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblRloc" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblRlocResource1" /></td>
                    <td><asp:Literal id ="ltlRloc" runat ="server" 
                              meta:resourcekey="ltlRlocResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblRoof" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblRoofResource1" /></td>
                    <td><asp:Literal id ="ltlRoof" runat ="server" 
                              meta:resourcekey="ltlRoofResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblRlof" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblRlofResource1" /></td>
                    <td><asp:Literal id ="ltlRlof" runat ="server" 
                              meta:resourcekey="ltlRlofResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblMwFecUncor" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblMwFecUncorResource1" /></td>
                    <td><asp:Literal id ="ltlMwFecUncor" runat ="server" 
                              meta:resourcekey="ltlMwFecUncorResource1" /></td>
                 </tr>  
                  <tr>
                    <td><asp:Label id ="lblMwLof" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblMwLofResource1" /></td>
                    <td><asp:Literal id ="ltlMwLof" runat ="server" 
                              meta:resourcekey="ltlMwLofResource1" /></td>
                 </tr>  
             </table>
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:Image ID="imgItems" runat ="server" SkinID ="imgBlueArrow" 
                    meta:resourcekey="imgItemsResource1" />
                <asp:Label ID="lblItems" runat ="server"  Font-Bold ="True" Font-Size="12px"
                    meta:resourcekey="lblItemsResource1" />
            </td>
        </tr>
        <tr>
            <td>
               <table width="100%" cellpadding="2" cellspacing="0"  class="setup-table">
                 <tr>
                    <td><asp:Label id ="lblMode" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblModeResource1" /></td>
                    <td><asp:Literal id ="ltlMode" runat ="server" 
                              meta:resourcekey="ltlModeResource1" /></td>
                 </tr>  
                 <tr>
                     <td style ="width:30%"><asp:Label id ="lblCurTxPower" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblCurTxPowerResource1" /></td>
                     <td ><asp:Literal id ="ltlCurTxPower" runat ="server" 
                              meta:resourcekey="ltlCurTxPowerResource1" /></td>
                 </tr>
                 <tr>
                    <td ><asp:Label ID="lblMaxCurTxPower" runat ="server" 
                                            meta:resourcekey="lblMaxCurTxPowerResource1"  
                            Font-Bold ="True"/></td>
                     <td><asp:Literal ID="ltlMaxCurTxPower" runat ="server" meta:resourcekey="ltlMaxCurTxPowerResource1" /></td>
                 </tr>  
                 <tr>
                     <td>
                        <asp:Label ID="lblMinCurTxPower" runat ="server" 
                                            meta:resourcekey="lblMinCurTxPowerResource1"  Font-Bold ="True"/></td>
                     <td>
                        <asp:Literal ID="ltlMinCurTxPower" runat ="server"  meta:resourcekey="ltlMinCurTxPowerResource1" />
                     </td>
                 </tr>   
                 <tr>
                    <td><asp:Label id ="lblMaxTxPower" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblMaxTxPowerResource1" /></td>
                    <td><asp:Literal id ="ltlMaxTxPower" runat ="server" 
                              meta:resourcekey="ltMaxTxPowerResource1" /></td>
                 </tr>   
                 <tr>
                     <td><asp:Label id ="lblMinTxPower" runat ="server"  Font-Bold ="True"
                             meta:resourcekey="lblMinTxPowerResource1" /></td>
                      <td><asp:Literal id ="ltlMinTxPower" runat ="server" 
                              meta:resourcekey="ltlMinTxPowerResource1" /></td>
                 </tr>    
                 <tr>
                    <td><asp:Label id ="lblQPSKSetPower" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblQPSKSetPowerResource1" /></td>
                    <td><asp:Literal id ="ltlQPSKSetPower" runat ="server" 
                              meta:resourcekey="ltlQPSKSetPowerResource1" /></td>
                 </tr>   
                 <tr>
                    <td><asp:Label id ="lblQPSKPower" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblQPSKPowerResource1" /></td>
                    <td><asp:Literal id ="ltlQPSKPower" runat ="server" 
                              meta:resourcekey="ltlQPSKPowerResource1" /></td>
                 </tr>   
                 <tr>
                    <td><asp:Label id ="lblCurRxPower" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblCurRxPowerResource1" /></td>
                    <td><asp:Literal id ="ltlCurRxPower" runat ="server" 
                              meta:resourcekey="ltlCurRxPowerResource1" /></td>
                 </tr>  
                 <tr>
                    <td><asp:Label id ="lblMaxCurRxPower" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblMaxCurRxPowerResource1" /></td>
                    <td><asp:Literal id ="ltlMaxCurRxPower" runat ="server" 
                              meta:resourcekey="ltlMaxCurRxPowerResource1" /></td>
                 </tr>   
                 <tr>
                    <td><asp:Label id ="lblMinCurRxPower" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblMinCurRxPowerResource1" /></td>
                    <td><asp:Literal id ="ltlMinCurRxPower" runat ="server" 
                              meta:resourcekey="ltlMinCurRxPowerResource1" /></td>
                 </tr>  
                 <tr>
                    <td><asp:Label id ="lblMaxRxPower" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblMaxRxPowerResource1" /></td>
                    <td><asp:Literal id ="ltlMaxRxPower" runat ="server" 
                              meta:resourcekey="ltlMaxRxPowerResource1" /></td>
                 </tr>   
                 <tr>
                    <td><asp:Label id ="lblMinRxPower" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblMinRxPowerResource1" /></td>
                    <td><asp:Literal id ="ltlMinRxPower" runat ="server" 
                              meta:resourcekey="ltlMinRxPowerResource1" /></td>
                 </tr>  
                 <tr>
                    <td><asp:Label id ="lblES" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblESResource1" /></td>
                    <td><asp:Literal id ="ltlES" runat ="server" 
                              meta:resourcekey="ltlESResource1" /></td>
                 </tr> 
                  <tr>
                    <td><asp:Label id ="lblSES" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblSESResource1" /></td>
                    <td><asp:Literal id ="ltlSES" runat ="server" 
                              meta:resourcekey="ltlSESResource1" /></td>
                 </tr> 
                  <tr>
                    <td><asp:Label id ="lblAIS" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblAISResource1" /></td>
                    <td><asp:Literal id ="ltlAIS" runat ="server" 
                              meta:resourcekey="ltlAISResource1" /></td>
                 </tr> 
             </table>
            </td>
        </tr>
      </table>
 </ContentTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>  
</asp:Content>