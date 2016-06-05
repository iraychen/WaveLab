<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="FQATxMaskView.aspx.cs" Inherits="WaveLab.Web.FQATxMaskView" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
                    <asp:Image ID="imgBasicInfo" runat ="server" SkinID ="imgBlueArrow" 
                        meta:resourcekey="imgBasicInfoResource1" />
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
                  <table width="100%">
                     <tr>
                        <td>
                            <asp:Image ID="imgFQATxMaskResult" runat ="server" SkinID ="imgBlueArrow" 
                                meta:resourcekey="imgFQATxMaskResultResource1" />
                            <asp:Label ID="lblFQATxMaskResult" runat ="server"  Font-Bold ="True" Font-Size="12px"
                                meta:resourcekey="lblFQATxMaskResultResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:GridView ID="GVFQATxMask" runat="server"  SkinId="skinGridView"
                                AutoGenerateColumns="False"  Width ="100%" DataKeyNames="FQATxMaskId,Mode,CH"
                                 meta:resourcekey="GVFQATxMaskResource1" onrowcommand="GVFQATxMask_RowCommand" 
                                onrowdatabound="GVFQATxMask_RowDataBound"  >
                              <Columns>
                                  <asp:BoundField  DataField="Mode"  meta:resourcekey="FQATxMaskBoundFieldResource1"/>
                                  <asp:BoundField  DataField="CH"  meta:resourcekey="FQATxMaskBoundFieldResource2"/>
                                  <asp:BoundField  DataField="MaskCheck" meta:resourcekey="FQATxMaskBoundFieldResource3"/>
                                  <asp:TemplateField meta:resourcekey="FQATxMaskTemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:ImageButton ID ="imgbtnMaskImage" runat ="server"  SkinID="imgBtnSkinGallery" 
                                            CommandName="Image" CommandArgument='<%# Container.DataItemIndex %>' 
                                            meta:resourcekey="imgbtnMaskImageResource1"/>
                                    </ItemTemplate>
                                  </asp:TemplateField>
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
