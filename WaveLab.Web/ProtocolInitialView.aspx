<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ProtocolInitialView.aspx.cs" Inherits="WaveLab.Web.ProtocolInitialView" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
      <table width="100%" cellpadding="2" cellspacing="0" style="text-align:left;" class="setup-table">
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
            <td><asp:Label id ="lblTypeHigh" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTypeHighResource1" /></td>
            <td><asp:Literal id ="ltlTypeHigh" runat ="server" 
                      meta:resourcekey="ltlTypeHighResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblPowerRange" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblPowerRangeResource1" /></td>
            <td><asp:Literal id ="ltlPowerRange" runat ="server" 
                      meta:resourcekey="ltlPowerRangeResource1" /></td>
         </tr>   
         <tr>
           <td><asp:Label id ="lblFreqRangeLow" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblFreqRangeLowResource1" /></td>
           <td><asp:Literal id ="ltlFreqRangeLow" runat ="server" 
                      meta:resourcekey="ltlFreqRangeLowResource1" /></td>
         </tr>   
         <tr>
           <td><asp:Label id ="lblFreqRangeHigh" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblFreqRangeHighResource1" /></td>
           <td><asp:Literal id ="ltlFreqRangeHigh" runat ="server" 
                      meta:resourcekey="ltlFreqRangeHighResource1" /></td>
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
            <td><asp:Label id ="lblAlarmLow" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblRxPllLowResource1" /></td>
            <td><asp:Literal id ="ltlAlarmLow" runat ="server" 
                      meta:resourcekey="ltlAlarmLowResource1" /></td>
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
            <td><asp:Label id ="lblMCUVersion" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblMCUVersionResource1" /></td>
            <td><asp:Literal id ="ltlMCUVersion" runat ="server" 
                      meta:resourcekey="ltlMCUVersionResource1" /></td>
         </tr> 
         <tr>
            <td><asp:Label id ="lblPartNum" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblPartNumResource1" /></td>
            <td><asp:Literal id ="ltlPartNum" runat ="server" 
                      meta:resourcekey="ltlPartNumResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblIDNum" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblIDNumResource1" /></td>
            <td><asp:Literal id ="ltlIDNum" runat ="server" 
                      meta:resourcekey="ltlIDNumResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblTxPllLow" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxPllLowResource1" /></td>
            <td><asp:Literal id ="ltlTxPllLow" runat ="server" 
                      meta:resourcekey="ltlTxPllLowResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblRxPllLow" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblRxPllLowResource1" /></td>
            <td><asp:Literal id ="ltlRxPllLow" runat ="server" 
                      meta:resourcekey="ltlRxPllLowResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblPaILow" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblPaILowResource1" /></td>
            <td><asp:Literal id ="ltlPaILow" runat ="server" 
                      meta:resourcekey="ltlPaILowResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblTxPowLow" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxPowLowResource1" /></td>
            <td><asp:Literal id ="ltlTxPowLow" runat ="server" 
                      meta:resourcekey="ltlTxPowLowResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblNegative5VLow" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblNegative5VLowResource1" /></td>
            <td><asp:Literal id ="ltlNegative5VLow" runat ="server" 
                      meta:resourcekey="ltlNegative5VLowResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblTxIFLow" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxIFLowResource1" /></td>
            <td><asp:Literal id ="ltlTxIFLow" runat ="server" 
                      meta:resourcekey="ltlTxIFLowResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblTxPllHigh" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxPllHighResource1" /></td>
            <td><asp:Literal id ="ltlTxPllHigh" runat ="server" 
                      meta:resourcekey="ltlTxPllHighResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblRxPllHigh" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblRxPllHighResource1" /></td>
            <td><asp:Literal id ="ltlRxPllHigh" runat ="server" 
                      meta:resourcekey="ltlRxPllHighResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblPaIHigh" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblPaIHighResource1" /></td>
            <td><asp:Literal id ="ltlPaIHigh" runat ="server" 
                      meta:resourcekey="ltlPaIHighResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblTxPowHigh" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxPowHighResource1" /></td>
            <td><asp:Literal id ="ltlTxPowHigh" runat ="server" 
                      meta:resourcekey="ltlTxPowHighResource1" /></td>
         </tr>   
        <tr>
            <td><asp:Label id ="lblNegative5VHigh" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblNegative5VHighResource1" /></td>
            <td><asp:Literal id ="ltlNegative5VHigh" runat ="server" 
                      meta:resourcekey="ltlNegative5VHighResource1" /></td>
         </tr> 
         <tr>
            <td><asp:Label id ="lblTxIFHigh" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxIFHighResource1" /></td>
            <td><asp:Literal id ="ltlTxIFHigh" runat ="server" 
                      meta:resourcekey="ltlTxIFHighResource1" /></td>
                      
         </tr>
         <%--<tr>
            <td><asp:Label id ="lblAtpcRange" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblAtpcRangeResource1" /></td>
            <td><asp:Literal id ="ltlAtpcRange" runat ="server" 
                      meta:resourcekey="ltlAtpcRangeResource1" /></td>
         </tr> --%>
         <tr>
            <td><asp:Label id ="lblRSSIAlarm" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblRSSIAlarmResource1" /></td>
            <td><asp:Literal id ="ltlRSSIAlarm" runat ="server" 
                      meta:resourcekey="ltlRSSIAlarmResource1" /></td>
         </tr>  
          <tr>
           <td><asp:Label id ="lblFactoryInfo" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblFactoryInfoResource1" /></td>
           <td><asp:Literal id ="ltlFactoryInfo" runat ="server" 
                      meta:resourcekey="ltlFactoryInfoResource1" /></td>
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
