﻿<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="TxPowerView.aspx.cs" Inherits="WaveLab.Web.TxPowerView" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
     <center>
        <table width="100%" style ="text-align:left" >
           <tr>
                <td>
                    <asp:Image ID="imgBasicInfo" runat ="server" SkinID ="imgBlueArrow" />
                    <asp:Label ID="lblBasicInfo" runat ="server"  Font-Bold ="true" Font-Size="12px"
                        meta:resourcekey="lblBasicInfoResource1" />
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="3" cellspacing="0"   style="text-align:left; width:100%" class="setup-table">
      
                         <tr style ="width:200px">
                             <td><asp:Label id ="lblModel" runat ="server"  Font-Bold ="True"
                                   meta:resourcekey="lblModelResource1" /></td>
                             <td ><asp:Literal id ="ltlModel" runat ="server" 
                                      meta:resourcekey="ltlModelResource1" /></td>
                         </tr>
                        
                          <tr>
                             <td style ="width:150px">
                                <asp:Label ID="lblSerialNo" runat ="server" 
                                                    meta:resourcekey="lblSerialNoResource1"  Font-Bold ="True"/></td>
                             <td style ="width:350px">
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
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Image ID="imgTxPowerResult" runat ="server" SkinID ="imgBlueArrow" />
                    <asp:Label ID="lblTxPowerResult" runat ="server"  Font-Bold ="true" Font-Size="12px"
                        meta:resourcekey="lblTxPowerResultResource1" />
                </td>
            </tr>
            <tr>
                <td>
                    <table style ="width:100%; text-align:left" cellspacing="0">
                    <tr>
                        <td>
                            <asp:ListView ID="LVResult"  runat="server"  
                                ItemPlaceholderID="layoutTableTemplate"   EnableViewState="False">
                                <LayoutTemplate>
                                    <table  class="common-table" cellpadding="0" cellspacing="0" width="100%" style="text-align:left">
                                        <tr >
                                            <th><asp:Label ID="lblMode" runat ="server" 
                                                    meta:resourcekey="lblModeResource1" /></th>
                                            <th><asp:Label ID="lblCH" runat ="server" 
                                                    meta:resourcekey="lblCHResource1" /></th>
                                            <th><asp:Label ID="lblPW" runat ="server" 
                                                    meta:resourcekey="lblPWResource1" /></th>  
                                            <th><asp:Label ID="lblOutPutPower" runat ="server" 
                                                    meta:resourcekey="lblOutPutPowerResource1" /></th>   
                                            <th><asp:Label ID="lblTxDetPower" runat ="server" 
                                                    meta:resourcekey="lblTxDetPowerResource1" /></th>  
                                            <th><asp:Label ID="lblTxRSSIPower" runat ="server" 
                                                    meta:resourcekey="lblTxRSSIPowerResource1" /></th>    
                                        </tr>
                                        <asp:PlaceHolder ID="layoutTableTemplate" runat="server" />
                                    </table>
                                    </div>
                                </LayoutTemplate>
                                <ItemTemplate>
                                   <tr style ="background-color:White">
                                       <td><%# Eval("Mode") %> </td>
                                       <td><%# Eval("CH")%></td>
                                       <td><%# Eval("PW")%> </td>
                                       <td><%# Eval("OutPutPower")%></td>
                                       <td><%# Eval("TxDetPower")%> </td>
                                       <td><%# Eval("TxRSSIPower")%></td>
                                   </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr style ="background-color:#e6e6e6">
                                       <td><%# Eval("Mode") %> </td>
                                       <td><%# Eval("CH")%></td>
                                       <td><%# Eval("PW")%> </td>
                                       <td><%# Eval("OutPutPower")%></td>
                                       <td><%# Eval("TxDetPower")%> </td>
                                       <td><%# Eval("TxRSSIPower")%></td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:ListView>
                        </td>
                    </tr>
                </table>
                </td>
            </tr>
        </table>
     </ContentTemplate>
</ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>  
</asp:Content>

