<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="TxCableView.aspx.cs" Inherits="WaveLab.Web.TxCableView" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
     <asp:Label ID ="lblBasicInfo" runat="server"  meta:resourcekey="lblBasicInfoResource1" />
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
             <td>
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
             <td><asp:Label ID="lblTxIFRange" runat ="server"  Font-Bold ="True" 
                    meta:resourcekey="lblTxIFRangeResource1" /></td>
             <td><asp:Literal ID="ltlTxIFRange" runat ="server" 
                    meta:resourcekey="ltlTxIFRangeResource1" /></td>
         </tr>  
         <tr>
             <td><asp:Label id ="lblRunningTime" runat ="server"  Font-Bold ="True"
                     meta:resourcekey="lblRunningTimeResource1" /></td>
              <td><asp:Literal id ="ltlRunningTime" runat ="server" 
                      meta:resourcekey="ltlRunningTimeResource1" /></td>
         </tr>  
          <tr>
            <td><asp:Label id ="lblReason" runat ="server"  Font-Bold ="True"
                   meta:resourcekey="lblReasonResource1" /></td>
            <td><asp:Literal id ="ltlReason" runat ="server" 
                      meta:resourcekey="ltlReasonResource1" /></td>
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
     <table style ="text-align:left; width:100%" cellpadding="1">
        <tr>  
            <td>
                <asp:ListView ID="LVResult"  runat="server" 
                    ItemPlaceholderID="layoutTableTemplate"   EnableViewState="False">
                    <LayoutTemplate>
                        <table  class="common-table" cellpadding="1" cellspacing="1" width="100%">
                            <tr >
                                <th colspan="4" style ="text-align:center"><asp:Label ID="lblTxCableDetectTable" runat ="server" 
                                        meta:resourcekey="lblTxCableDetectTableResource1" /></th>
                            </tr>
                            <tr >
                                  <!--Tx CBL-detect Table--> 
                                <th style ="text-align:center"><asp:Label ID="lblCBLData" runat ="server" 
                                        meta:resourcekey="lblCBLDataResource1" /></th>
                                <th style ="text-align:center"><asp:Label ID="lblCBL" runat ="server" 
                                        meta:resourcekey="lblCBLResource1" /></th>
                                <th style ="text-align:center"><asp:Label ID="lblCBLVoltage" runat ="server" 
                                        meta:resourcekey="lblCBLVoltageResource1" /></th>
                                <th style ="text-align:center"><asp:Label ID="lblCBLAddress" runat ="server" 
                                        meta:resourcekey="lblCBLAddressResource1" /></th>       
                            </tr>
                            <asp:PlaceHolder ID="layoutTableTemplate" runat="server" />
                        </table>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                       <tr style ="background-color:White">
                           <td style=" text-align:center"><%# Eval("CBLData") %> </td>
                           <td style=" text-align:center"><%# Eval("CBL")%></td>
                           <td style=" text-align:center"><%#String.Format("{0:f3}", Eval("CBLVoltage"))%></td>
                           <td style=" text-align:center"><%# Eval("CBLAddress")%> </td>
                       </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style ="background-color:#e6e6e6">
                           <td style=" text-align:center"><%# Eval("CBLData") %> </td>
                           <td style=" text-align:center"><%# Eval("CBL")%></td>
                           <td style=" text-align:center"><%# String.Format("{0:f3}",Eval("CBLVoltage"))%></td>
                           <td style=" text-align:center"><%# Eval("CBLAddress")%> </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:ListView>
            </td>
        </tr>
    </table>
    </center>
    </ContentTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer> 
</asp:Content>

