<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="NTTxSpurView.aspx.cs" Inherits="WaveLab.Web.NTTxSpurView" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
         <table style="text-align:left;width:100%">
            <tr>
                <td>
                    <asp:Image ID="imgBasicInfo" runat ="server" SkinID ="imgBlueArrow" />
                    <asp:Label ID="lblBasicInfo" runat ="server"  Font-Bold ="True" Font-Size="12px"
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
                            <td><asp:Label id ="lblEndTime" runat ="server"  Font-Bold ="True"
                                   meta:resourcekey="lblEndTimeResource1" /></td>
                            <td><asp:Literal id ="ltlEndTime" runat ="server" 
                                      meta:resourcekey="ltlEndTimeResource1" /></td>
                         </tr>  
                         <tr>
                             <td><asp:Label ID="lblStationNo" runat ="server"  Font-Bold ="True" 
                                    meta:resourcekey="lblStationNoResource1" /></td>
                             <td><asp:Literal ID="ltlStationNo" runat ="server" 
                                    meta:resourcekey="ltlStationNoResource1" /></td>
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
                    <asp:Image ID="imgNTTxSpurResult" runat ="server" SkinID ="imgBlueArrow" />
                    <asp:Label ID="lblNTTxSpurResult" runat ="server"  Font-Bold ="True" Font-Size="12px"
                        meta:resourcekey="lblNTTxSpurResultResource1" />
                </td>
            </tr>
            <tr>
                <td>
                  <table width="100%" style ="text-align:left" >
                    <tr>
                        <td>
                             <asp:GridView ID="GVNTTxSpur" runat="server"  SkinId="skinGridView"
                                AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"
                                 meta:resourcekey="GVNTTxSpurResource1"  >
                              <Columns>
                                  <asp:BoundField  DataField="Mode"  meta:resourcekey="NTTxSpurBoundFieldResource1"/>
                                  <asp:BoundField  DataField="CH"  meta:resourcekey="NTTxSpurBoundFieldResource2"/>
                                  <asp:BoundField  DataField="FreqRange" meta:resourcekey="NTTxSpurBoundFieldResource3"/>
                                  <asp:BoundField  DataField="FreqPoint"  meta:resourcekey="NTTxSpurBoundFieldResource4"/>
                                  <asp:BoundField  DataField="SpurCheck"  meta:resourcekey="NTTxSpurBoundFieldResource5"/>
                              </Columns>
                             </asp:GridView>
                        </td>
                    </tr>
                </table>
                </td>
            </tr>
        </table>
      
    </center>
 </ContentTemplate>
 </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>   
</asp:Content>

