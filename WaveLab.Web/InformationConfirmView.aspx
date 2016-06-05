<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="InformationConfirmView.aspx.cs" Inherits="WaveLab.Web.InformationConfirmView" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
         <tr  style ="width:200px">
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
           <td><asp:Label id ="lblFreqRange" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblFreqRangeResource1" /></td>
           <td><asp:Literal id ="ltlFreqRange" runat ="server" 
                      meta:resourcekey="ltlFreqRangeResource1" /></td>
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
           <td><asp:Label id ="lblRSSICHOffSet" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblRSSICHOffSetResource1" /></td>
           <td><asp:Literal id ="ltlRSSICHOffSet" runat ="server" 
                      meta:resourcekey="ltlRSSICHOffSetResource1" /></td>
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
            <td><asp:Label id ="lblControledVoltage" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblControledVoltageResource1" /></td>
            <td><asp:Literal id ="ltlControledVoltage" runat ="server" 
                      meta:resourcekey="ltlControledVoltageResource1" /></td>
         </tr> 
         <tr>
            <td><asp:Label id ="lblControledVoltageExt" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblControledVoltageExtResource1" /></td>
            <td><asp:Literal id ="ltlControledVoltageExt" runat ="server" 
                      meta:resourcekey="ltlControledVoltageExtResource1" /></td>
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
            <td><asp:Label id ="lblTxPll" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxPllResource1" /></td>
            <td><asp:Literal id ="ltlTxPll" runat ="server" 
                      meta:resourcekey="ltlTxPllResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblRxPll" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblRxPllResource1" /></td>
            <td><asp:Literal id ="ltlRxPll" runat ="server" 
                      meta:resourcekey="ltlRxPllResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblPaI" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblPaIResource1" /></td>
            <td><asp:Literal id ="ltlPaI" runat ="server" 
                      meta:resourcekey="ltlPaIResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblTxPow" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxPowResource1" /></td>
            <td><asp:Literal id ="ltlTxPow" runat ="server" 
                      meta:resourcekey="ltlTxPowResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblTxPowRange" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxPowRangeResource1" /></td>
            <td><asp:Literal id ="ltlTxPowRange" runat ="server" 
                      meta:resourcekey="ltlTxPowRangeResource1" /></td>
         </tr> 
         <tr>
            <td><asp:Label id ="lblTxTempOffSet" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxTempOffSetResource1" /></td>
            <td><asp:Literal id ="ltlTxTempOffSet" runat ="server" 
                      meta:resourcekey="ltlTxTempOffSetResource1" /></td>
         </tr>
         <tr>
            <td><asp:Label id ="lblNegative5V" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblNegative5VResource1" /></td>
            <td><asp:Literal id ="ltlNegative5V" runat ="server" 
                      meta:resourcekey="ltlNegative5VResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblTxIF" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxIFResource1" /></td>
            <td><asp:Literal id ="ltlTxIF" runat ="server" 
                      meta:resourcekey="ltlTxIFResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblAtpcRange" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblAtpcRangeResource1" /></td>
            <td><asp:Literal id ="ltlAtpcRange" runat ="server" 
                      meta:resourcekey="ltlAtpcRangeResource1" /></td>
         </tr> 
         <tr>
            <td><asp:Label id ="lblRSSIAlarm" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblRSSIAlarmResource1" /></td>
            <td><asp:Literal id ="ltlRSSIAlarm" runat ="server" 
                      meta:resourcekey="ltlRSSIAlarmResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblRemodlo" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblRemodloResource1" /></td>
            <td><asp:Literal id ="ltlRemodlo" runat ="server" 
                      meta:resourcekey="ltlRemodloResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblTemperature" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTemperatureResource1" /></td>
            <td><asp:Literal id ="ltlTemperature" runat ="server" 
                      meta:resourcekey="ltlTemperatureResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblModelNo" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblModelNoResource1" /></td>
            <td><asp:Literal id ="ltlModelNo" runat ="server" 
                      meta:resourcekey="ltlModelNoResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblCleiNo" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblCleiNoResource1" /></td>
            <td><asp:Literal id ="ltlCleiNo" runat ="server" 
                      meta:resourcekey="ltlCleiNoResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblIQCIVolt" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblIQCIVoltResource1" /></td>
            <td><asp:Literal id ="ltlIQCIVolt" runat ="server" 
                      meta:resourcekey="ltlIQCIVoltResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblIQCQVolt" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblIQCQVoltResource1" /></td>
            <td><asp:Literal id ="ltlIQCQVolt" runat ="server" 
                      meta:resourcekey="ltlIQCQVoltResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblMaufactDate" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblMaufactDateResource1" /></td>
            <td><asp:Literal id ="ltlMaufactDate" runat ="server" 
                      meta:resourcekey="ltlMaufactDateResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblTheHighestMode" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTheHighestModeResource1" /></td>
            <td><asp:Literal id ="ltlTheHighestMode" runat ="server" 
                      meta:resourcekey="ltlTheHighestModeResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblTheHighestCapacity" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTheHighestCapacityResource1" /></td>
            <td><asp:Literal id ="ltlTheHighestCapacity" runat ="server" 
                      meta:resourcekey="ltlTheHighestCapacityResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblOrderingNo" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblOrderingNoResource1" /></td>
            <td><asp:Literal id ="ltlOrderingNo" runat ="server" 
                      meta:resourcekey="ltlOrderingNoResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblAssociatedEclipseVersion" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblAssociatedEclipseVersionResource1" /></td>
            <td><asp:Literal id ="ltlAssociatedEclipseVersion" runat ="server" 
                      meta:resourcekey="ltlAssociatedEclipseVersionResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblMaxSuppurtedBandWidth" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblMaxSuppurtedBandWidthResource1" /></td>
            <td><asp:Literal id ="ltlMaxSuppurtedBandWidth" runat ="server" 
                      meta:resourcekey="ltlMaxSuppurtedBandWidthResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblBootLoadVersion" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblBootLoadVersionResource1" /></td>
            <td><asp:Literal id ="ltlBootLoadVersion" runat ="server" 
                      meta:resourcekey="ltlBootLoadVersionResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblNoiseFigure" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblNoiseFigureResource1" /></td>
            <td><asp:Literal id ="ltlNoiseFigure" runat ="server" 
                      meta:resourcekey="ltlNoiseFigureResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblHardWareVersion" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblHardWareVersionResource1" /></td>
            <td><asp:Literal id ="ltlHardWareVersion" runat ="server" 
                      meta:resourcekey="ltlHardWareVersionResource1" /></td>
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
            <td><asp:Label id ="lblFinalFlag" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblFinalFlagResource1" /></td>
            <td><asp:Literal id ="ltlFinalFlag" runat ="server" 
                      meta:resourcekey="ltlFinalFlagResource1" /></td>
         </tr>   
          <tr>
            <td><asp:Label id ="lblReason" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblReasonResource1" /></td>
            <td><asp:Literal id ="ltlReason" runat ="server" 
                      meta:resourcekey="ltlReasonResource1" /></td>
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