<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GeneralInitialView.aspx.cs" Inherits="WaveLab.Web.GeneralInitialView" Title="无标题页"  meta:resourcekey="PageResource1" culture="auto" uiculture="auto" %>
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
     <asp:Label ID ="lblTitle" runat="server" meta:resourcekey="lblTitleResource1" />
    </HeaderTemplate>
    <ContentTemplate>
      <table width="100%" cellpadding="2" cellspacing="0" style="text-align:left;" class="setup-table">
       <%--  <tr>
             <td style ="width:200px"><asp:Label id ="lblOrderNo" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblOrderNoResource1" /></td>
             <td ><asp:Literal id ="ltlOrderNo" runat ="server" 
                      meta:resourcekey="ltlOrderNoResource1" /></td>
         </tr>--%>
         <tr>
             <td><asp:Label id ="lblModel" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblModelResource1" /></td>
             <td ><asp:Literal id ="ltlModel" runat ="server" 
                      meta:resourcekey="ltlModelResource1" /></td>
         </tr>
         <%--<tr>
            <td ><asp:Label ID="lblCode" runat ="server" 
                                    meta:resourcekey="lblCodeResource1"  
                    Font-Bold ="True"/></td>
             <td><asp:Literal ID="ltlCode" runat ="server" meta:resourcekey="ltlCodeResource1" /></td>
         </tr>  --%>
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
            <td><asp:Label id ="lblEndTime" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblEndTimeResource1" /></td>
            <td><asp:Literal id ="ltlEndTime" runat ="server" 
                      meta:resourcekey="ltlEndTimeResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblTypeLow" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTypeLowResource1" /></td>
            <td><asp:Literal id ="ltlTypeLow" runat ="server" 
                      meta:resourcekey="ltlTypeLowResource1" /></td>
         </tr>   
         <tr>
           <td><asp:Label id ="lblFreqRangeLow" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblFreqRangeLowResource1" /></td>
           <td><asp:Literal id ="ltlFreqRangeLow" runat ="server" 
                      meta:resourcekey="ltlFreqRangeLowResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblAlarmLow" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblRxPllLowResource1" /></td>
            <td><asp:Literal id ="ltlAlarmLow" runat ="server" 
                      meta:resourcekey="ltlAlarmLowResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblTypeHigh" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTypeHighResource1" /></td>
            <td><asp:Literal id ="ltlTypeHigh" runat ="server" 
                      meta:resourcekey="ltlTypeHighResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblFreqRangeHigh" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblFreqRangeHighResource1" /></td>
            <td><asp:Literal id ="ltlFreqRangeHigh" runat ="server" 
                      meta:resourcekey="ltlFreqRangeHighResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblAlarmHigh" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblAlarmHighResource1" /></td>
            <td><asp:Literal id ="ltlAlarmHigh" runat ="server" 
                      meta:resourcekey="ltlAlarmHighResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblPowerRange" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblPowerRangeResource1" /></td>
            <td><asp:Literal id ="ltlPowerRange" runat ="server" 
                      meta:resourcekey="ltlPowerRangeResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblModeMaxPower" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblModeMaxPowerResource1" /></td>
            <td><asp:Literal id ="ltlModeMaxPower" runat ="server" 
                      meta:resourcekey="ltlModeMaxPowerResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblRSSIOffSet" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblRSSIOffSetResource1" /></td>
            <td><asp:Literal id ="ltlRSSIOffSet" runat ="server" 
                      meta:resourcekey="ltlRSSIOffSetResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblPowerOffSet" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblPowerOffSetResource1" /></td>
            <td><asp:Literal id ="ltlPowerOffSet" runat ="server" 
                      meta:resourcekey="ltlPowerOffSetResource1" /></td>
         </tr>   
         <tr>
             <td><asp:Label id ="lblAging" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblAgingResource1" /></td>
             <td><asp:Literal id ="ltlAging" runat ="server" 
                      meta:resourcekey="ltlAgingResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblFilterSwitch" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblFilterSwitchResource1" /></td>
            <td><asp:Literal id ="ltlFilterSwitch" runat ="server" 
                      meta:resourcekey="ltlFilterSwitchResource1" /></td>
         </tr>  
         <tr>
            <td><asp:Label id ="lblNoiseFigure" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblNoiseFigureResource1" /></td>
            <td><asp:Literal id ="ltlNoiseFigure" runat ="server" 
                      meta:resourcekey="ltlNoiseFigureResource1" /></td>
         </tr>  
         <tr>
            <td><asp:Label id ="lblMaxSupportedBandWidth" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblMaxSupportedBandWidthResource1" /></td>
            <td><asp:Literal id ="ltlMaxSupportedBandWidth" runat ="server" 
                      meta:resourcekey="ltlMaxSupportedBandWidthResource1" /></td>
         </tr>  
         <tr>
            <td><asp:Label id ="lblControledVoltageExt" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblControledVoltageExtResource1" /></td>
            <td><asp:Literal id ="ltlControledVoltageExt" runat ="server" 
                      meta:resourcekey="ltlControledVoltageExtResource1" /></td>
         </tr>  
         <tr>
            <td><asp:Label id ="lblTxTempOffSet" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxTempOffSetResource1" /></td>
            <td><asp:Literal id ="ltlTxTempOffSet" runat ="server" 
                      meta:resourcekey="ltlTxTempOffSetResource1" /></td>
         </tr>  
         <tr>
            <td><asp:Label id ="lblCleiNo" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblCleiNoResource1" /></td>
            <td><asp:Literal id ="ltlCleiNo" runat ="server" 
                      meta:resourcekey="ltlCleiNoResource1" /></td>
         </tr>  
         <tr>
            <td><asp:Label id ="lblHardVersion" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblHardVersionResource1" /></td>
            <td><asp:Literal id ="ltlHardVersion" runat ="server" 
                      meta:resourcekey="ltlHardVersionResource1" /></td>
         </tr>  
         <tr>
            <td><asp:Label id ="lblModelNo" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblModelNoResource1" /></td>
            <td><asp:Literal id ="ltlModelNo" runat ="server" 
                      meta:resourcekey="ltlModelNoResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblMCUVersion" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblMCUVersionResource1" /></td>
            <td><asp:Literal id ="ltlMCUVersion" runat ="server" 
                      meta:resourcekey="ltlMCUVersionResource1" /></td>
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
    </ContentTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer> 
</asp:Content>