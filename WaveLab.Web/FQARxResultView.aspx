<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="FQARxResultView.aspx.cs" Inherits="WaveLab.Web.FQARxResultView" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
      <table style ="width:100%;text-align:left" cellspacing="0" cellpadding="0">
       <tr>
            <td>
                <asp:Image ID="imgBasicInfo" runat ="server" SkinID ="imgBlueArrow" />
                <asp:Label ID="lblBasicInfo" runat ="server"  Font-Bold ="true" Font-Size="12px"
                    meta:resourcekey="lblBasicInfoResource1" />
            </td>
        </tr>
        <tr>
            <td>
              <table  width="100%" cellpadding="2" cellspacing="0" style="text-align:left;" class="setup-table">

                 <tr style ="width:200px">
                     <td><asp:Label id ="lblModel" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblModelResource1" /></td>
                     <td ><asp:Literal id ="ltlModel" runat ="server" 
                              meta:resourcekey="ltlModelResource1" /></td>
                 </tr>
                 <tr>
                
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
                    <td><asp:Label ID="lblCH" runat ="server"  Font-Bold ="True" 
                            meta:resourcekey="lblCHResource1" /></td>
                    <td><asp:Literal ID="ltlCH" runat ="server" 
                            meta:resourcekey="ltlCHResource1" /></td>
                  </tr>
                  <tr>
                    <td><asp:Label id ="lblEndTime" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblEndTimeResource1" /></td>
                    <td><asp:Literal id ="ltlEndTime" runat ="server" 
                              meta:resourcekey="ltlEndTimeResource1" /></td>
                 </tr> 
                 <tr>
                    <td><asp:Label id ="lblRXAGC" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblRXAGCResource1" /></td>
                    <td><asp:Literal id ="ltlRXAGC" runat ="server" 
                              meta:resourcekey="ltlRXAGCResource1" /></td>
                 </tr> 
                 <tr>
                    <td><asp:Label id ="lblRssiOffSet" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblRssiOffSetResource1" /></td>
                    <td><asp:Literal id ="ltlRssiOffSet" runat ="server" 
                              meta:resourcekey="ltlRssiOffSetResource1" /></td>
                 </tr> 
                 <tr>
                    <td><asp:Label id ="lblNF" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblNFResource1" /></td>
                    <td><asp:Literal id ="ltlNF" runat ="server" 
                              meta:resourcekey="ltlNFResource1" /></td>
                 </tr> 
                 <tr>
                    <td><asp:Label id ="lblBWLowHigh" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblBWLowHighResource1" /></td>
                    <td><asp:Literal id ="ltlBWLowHigh" runat ="server" 
                              meta:resourcekey="ltlBWLowHighResource1" /></td>
                 </tr> 
                  <tr>
                    <td><asp:Label id ="lblFreq140M" runat ="server"  Font-Bold ="True"
                           meta:resourcekey="lblFreq140MResource1" /></td>
                    <td><asp:Literal id ="ltlFreq140M" runat ="server" 
                              meta:resourcekey="ltlFreq140MResource1" /></td>
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
                <asp:Image ID="imgFQARxResult" runat ="server" SkinID ="imgBlueArrow" />
                <asp:Label ID="lblFQARxResult" runat ="server"  Font-Bold ="true" Font-Size="12px"
                    meta:resourcekey="lblFQARxResultResource1" />
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" width="100%">
                    <tr>
                        <td>
                           <asp:GridView ID="GVResult" runat="server"  SkinId="skinGridView"
                                AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"
                                 meta:resourcekey="GVResultResource1"  >
                              <Columns>
                                  <asp:BoundField  DataField="PWLV" meta:resourcekey="BoundFieldResource1">
                                  </asp:BoundField>
                                  <asp:BoundField  DataField="BNCVoltage"
                                      meta:resourcekey="BoundFieldResource2">
                                  </asp:BoundField>
                                  <asp:BoundField  DataField="DetectRxPowerHigh" 
                                      meta:resourcekey="BoundFieldResource3" >
                                  </asp:BoundField>
                                  <asp:BoundField  DataField="DetectRxPowerLow" 
                                      meta:resourcekey="BoundFieldResource4" >
                                  </asp:BoundField>
                                  <asp:BoundField  DataField="Level140MHz" 
                                      meta:resourcekey="BoundFieldResource5" >
                                  </asp:BoundField>
                                   <asp:BoundField  DataField="Freq140MHz" 
                                      meta:resourcekey="BoundFieldResource6" >
                                  </asp:BoundField>
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
