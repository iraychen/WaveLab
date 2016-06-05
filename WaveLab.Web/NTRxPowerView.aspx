<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="NTRxPowerView.aspx.cs" Inherits="WaveLab.Web.NTRxPowerView" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
        <table  style="text-align:left; width:100%" >
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
                    <table cellpadding="3" cellspacing="0"  style="text-align:left; width:100%"  class="setup-table">
      
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
                  <table width="100%" style ="text-align:left" >
            <tr>
                <td>
                    <asp:Image ID="imgResultTitle" runat ="server" SkinID ="imgBlueArrow" 
                        meta:resourcekey="imgResultTitleResource1" />
                    <asp:Label ID="lblResultTitle" runat ="server"  Font-Bold ="True" Font-Size="12px"
                        meta:resourcekey="lblResultTitleResource1" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GVResult" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                        AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False" 
                        meta:resourcekey="GVResultResource1">
                      <Columns>
                          <asp:BoundField  DataField="Mode"  meta:resourcekey="BoundFieldResource1"/>
                          <asp:BoundField  DataField="CH" meta:resourcekey="BoundFieldResource2"/>
                          <asp:BoundField  DataField="RxPower" meta:resourcekey="BoundFieldResource3"/>
                          <asp:BoundField  DataField="ReceiveResult" meta:resourcekey="BoundFieldResource4"/>
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
