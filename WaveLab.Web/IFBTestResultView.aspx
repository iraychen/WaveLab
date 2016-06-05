<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="IFBTestResultView.aspx.cs" Inherits="WaveLab.Web.IFBTestResultView" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
         <tr>
             <td style ="width:200px"><asp:Label id ="lblType" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblTypeResource1" /></td>
             <td><asp:Literal id ="ltlType" runat ="server" 
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
            <td><asp:Label id ="lblIFFrequency" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblIFFrequencyResource1" /></td>
            <td><asp:Literal id ="ltlIFFrequency" runat ="server" 
                      meta:resourcekey="ltlIFFrequencyResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblREV" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblREVResource1" /></td>
            <td><asp:Literal id ="ltlREV" runat ="server" 
                      meta:resourcekey="ltlREVResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblTxIF" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxIFResource1" /></td>
            <td><asp:Literal id ="ltlTxIF" runat ="server" 
                      meta:resourcekey="ltlTxIFResource1" /></td>
         </tr>   
         <tr>
           <td><asp:Label id ="lblLoIF" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblLoIFResource1" /></td>
           <td><asp:Literal id ="ltlLoIF" runat ="server" 
                      meta:resourcekey="ltlLoIFResource1" /></td>
         </tr>   
         <tr>
           <td><asp:Label id ="lblRxIF5" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblRxIF5Resource1" /></td>
           <td><asp:Literal id ="ltlRxIF5" runat ="server" 
                      meta:resourcekey="ltlRxIF5Resource1" /></td>
         </tr>   
         <tr>
           <td><asp:Label id ="lblRxIFNegative65" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblRxIFNegative65Resource1" /></td>
           <td><asp:Literal id ="ltlRxIFNegative65" runat ="server" 
                      meta:resourcekey="ltlRxIFNegative65Resource1" /></td>
         </tr> 
         <tr>
           <td><asp:Label id ="lblAbsRxIFAmpl" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblAbsRxIFAmplResource1" /></td>
           <td><asp:Literal id ="ltlAbsRxIFAmpl" runat ="server" 
                      meta:resourcekey="ltlAbsRxIFAmplResource1" /></td>
         </tr> 
          <tr>
           <td><asp:Label id ="lblRSSIVolt5" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblRSSIVolt5Resource1" /></td>
           <td><asp:Literal id ="ltlRSSIVolt5" runat ="server" 
                      meta:resourcekey="ltlRSSIVolt5Resource1" /></td>
         </tr> 
         <tr>
            <td><asp:Label id ="lblRSSIVoltNegative65" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblRSSIVoltNegative65Resource1" /></td>
            <td><asp:Literal id ="ltlRSSIVoltNegative65" runat ="server" 
                      meta:resourcekey="ltlRSSIVoltNegative65Resource1" /></td>
         </tr>  
         <tr>
             <td><asp:Label id ="lblTxIFRange" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblTxIFRangeResource1" /></td>
             <td><asp:Literal id ="ltlTxIFRange" runat ="server" 
                      meta:resourcekey="ltlTxIFRangeResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblLoFrequencyOffset" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblLoFrequencyOffsetResource1" /></td>
            <td><asp:Literal id ="ltlLoFrequencyOffset" runat ="server" 
                      meta:resourcekey="ltlLoFrequencyOffsetResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblTxPll" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxPllResource1" /></td>
            <td><asp:Literal id ="ltlTxPll" runat ="server" 
                      meta:resourcekey="ltlTxPllResource1" /></td>
         </tr> 
         <tr>
            <td><asp:Label id ="lblPAI" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblPAIResource1" /></td>
            <td><asp:Literal id ="ltlPAI" runat ="server" 
                      meta:resourcekey="ltlPAIResource1" /></td>
         </tr>   
         <tr>
            <td><asp:Label id ="lblRxPll" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblRxPllResource1" /></td>
            <td><asp:Literal id ="ltlRxPll" runat ="server" 
                      meta:resourcekey="ltlRxPllResource1" /></td>
         </tr>   
         <tr>
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
         </tr>   
         <tr>
            <td><asp:Label id ="lblTxIFResult" runat ="server"  Font-Bold ="True"
                    meta:resourcekey="lblTxIFResultResource1" /></td>
            <td><asp:Literal id ="ltlTxIFResult" runat ="server" 
                      meta:resourcekey="ltlTxIFResultResource1" /></td>
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
                      meta:resourcekey="ltlAppVersionwResource1" /></td>
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
