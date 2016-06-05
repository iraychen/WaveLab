<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCFixtureReturnLossView.aspx.cs" Inherits="WaveLab.Web.SPCFixtureReturnLossView" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
});
function verify(exceptionMsg, confirmMsg) {
    var i = 0, j = 0;
    $.each($(":text"), function() {
        i++;
        if ($.trim($(this).val()).length > 0) {
            j++;
        }
    });
    if (i != j) {
        alert(exceptionMsg);
        return false;
    } else {
        return confirm(confirmMsg);
    }
}
function winClose() {
    self.close();
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<table width ="100%">
     <tr>
        <td>
             <asp:Panel ID="HeaderPanelItem" runat="server" style="cursor: pointer;" 
                 meta:resourcekey="HeaderPanelItemResource1">
                <div class="heading">
                    <asp:ImageButton ID="ToggleImageItem" runat="server" AlternateText="expand" 
                        meta:resourcekey="ToggleImageItemResource1"/>
                    <asp:Label ID ="lblTitle1" runat ="server" meta:resourcekey="lblTitle1Resource1"/>
                </div>
            </asp:Panel>
           <asp:Panel ID="ContentPanelItem" runat="server" BorderColor="ButtonFace" BorderStyle="Solid" BorderWidth="1"
                 meta:resourcekey="ContentPanelItemResource1">
             <table style =" width:100%;" class ="setup-table">
                 <tr>
                    <td ><asp:Label ID="lblFixture" runat="server" 
                            meta:resourcekey="lblFixtureResource1"/></td>
                    <td>
                        <asp:Literal ID="ltlFixture" runat="server" 
                            meta:resourcekey="ltlFixtureResource1" />
                    </td>
                    <td>
                        <asp:Label ID="lblFrequencyBand" runat="server" 
                            meta:resourcekey="lblFrequencyBandResource1" />
                    </td>
                    <td >
                        <asp:Literal ID="ltlFrequencyBand" runat="server" 
                            meta:resourcekey="ltlFrequencyBandResource1" />
                    </td>
                </tr>
                <tr>
                     <td>
                        <asp:Label ID="lblCH" runat="server" 
                            meta:resourcekey="lblCHResource1" />
                    </td>
                    <td>
                        <asp:Literal ID="ltlCH" runat="server" 
                            meta:resourcekey="ltlCHResource1" />
                    </td>
                     <td></td>
                     <td></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblDateFrom" runat="server"  meta:resourcekey="lblDateFromResource1" /></td>
                    <td><asp:Literal ID ="ltlDateFrom" runat ="server" 
                            meta:resourcekey="ltlDateFromResource1" /></td>
                    <td><asp:Label ID="lblDateTo" runat="server"  meta:resourcekey="lblDateToResource1" /></td>
                    <td><asp:Literal ID ="ltlDateTo" runat ="server" 
                            meta:resourcekey="ltlDateToResource1" /></td>
                </tr>  
            </table>

            </asp:Panel>
        </td>
    </tr>
     <tr>
        <td>
            <asp:Panel ID="HeaderPanelDetail" runat="server" style="cursor: pointer;" 
                meta:resourcekey="HeaderPanelDetailResource1">
                <div class="heading">
                    <asp:ImageButton ID="ToggleImageDetail" runat="server" AlternateText="expand" 
                        meta:resourcekey="ToggleImageDetailResource1" />
                    <asp:Label ID ="lblTitle2" runat ="server" meta:resourcekey="lblTitle2Resource1" />
                </div>
            </asp:Panel>
           <asp:Panel ID="ContentPanelDetail" runat="server" BorderColor="ButtonFace" BorderStyle="Solid" BorderWidth="1"
                meta:resourcekey="ContentPanelDetailResource1">
           
                <asp:GridView ID="GVDetailItems" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                    AutoGenerateColumns="False"  Width ="100%"
                     meta:resourcekey="GVDetailItemsResource1" >
                  <Columns>
                    <asp:BoundField  DataField="NoOfTimes"  meta:resourcekey="BoundFieldResource1"/>
                     <asp:BoundField  DataField="TestingDate"  meta:resourcekey="BoundFieldResource2" DataFormatString="{0:yyyy-MM-dd}"/>
                     <asp:BoundField  DataField="TestingValue"  meta:resourcekey="BoundFieldResource3" DataFormatString="{0:f2}"/>                   
                  </Columns>
                </asp:GridView>            
                <br />
                <table style ="width:100%;" class ="setup-table">
                    <tr>
                        <td style ="width:15%"><asp:Label ID="lblX" runat="server" meta:resourcekey="lblXResource1"/></td>
                        <td style ="width:20%"><asp:Literal ID ="ltlX" runat ="server" meta:resourcekey="ltlXResource1" /></td>
                        <td style ="width:15%"><asp:Label ID="lblR" runat="server" meta:resourcekey="lblRResource1"/></td>
                        <td style ="width:20%"><asp:Literal ID ="ltlR" runat ="server" meta:resourcekey="ltlRResource1" /></td>                      
                    </tr>
                   
                </table>
              
            </asp:Panel>
        </td>
     </tr>
	 <tr>
	    <td>
	        <asp:Panel ID="HeaderPanelChartX" runat="server" style="cursor: pointer;" 
                meta:resourcekey="HeaderPanelChartXResource1">
                <div class="heading">
                    <asp:ImageButton ID="ToggleImageChartX" runat="server" AlternateText="expand" 
                        meta:resourcekey="ToggleImageChartXResource1" />
                     <asp:Label ID ="lblTitle4" runat ="server" 
                        meta:resourcekey="lblTitle4Resource1" />
                </div>
            </asp:Panel>
           <asp:Panel ID="ContentPanelChartX" runat="server"  BorderColor="ButtonFace" BorderStyle="Solid" BorderWidth="1"
                meta:resourcekey="ContentPanelChartXResource1">
                   <table style ="width:100%">
	                <tr>
	                    <td>
	                        <table style ="width:100%"  class ="setup-table">
	                            <tr>
	                                 <td style ="width:200px" >
	                                    <asp:Label ID="lblCL_X" runat="server" meta:resourcekey="lblCL_XResource1"/>
	                                 </td>
                                     <td><asp:Literal ID ="ltlCL_X" runat ="server" 
                                             meta:resourcekey="ltlCL_XResource1" />
                                      </td>
	                            </tr>
	                            <tr>
	                                 <td><asp:Label ID="lblUCL_X" runat="server" 
                                             meta:resourcekey="lblUCL_XResource1"/></td>
                                     <td><asp:Literal ID ="ltlUCL_X" runat ="server" 
                                             meta:resourcekey="ltlUCL_Xesource1" /></td>
	                            </tr>
	                            <tr>
	                                 <td><asp:Label ID="lblLCL_X" runat="server" 
                                             meta:resourcekey="lblLCL_XResource1"/></td>
                                     <td><asp:Literal ID ="ltlLCL_X" runat ="server" 
                                             meta:resourcekey="ltlLCL_Xesource1" /></td>
	                            </tr>
	                        </table>
	                    </td>
	                </tr>
	                <tr>
	                    <td>
	                      <asp:Chart ID="chartX" runat="server" Width="950px" Height="250px"  
                            BackColor="211, 223, 240" BorderColor="#F3DFC1" BorderDashStyle="Solid" 
                            BackSecondaryColor="White"  BorderWidth="2px" 
                                meta:resourcekey="chartXResource1" oncustomize="chartX_Customize" >
                                <Titles >
                                    <asp:Title Text="X控制图"  Font="Microsoft Sans Serif, 10pt" Name="Title1" />
                                </Titles>
                                <Legends>
                                    <asp:Legend Name ="Legends1"  Alignment="Center" BorderColor="DimGray" >
                                    </asp:Legend>
                                </Legends>
                               <Series>
                                    <asp:Series Name ="LCL" ChartArea ="ChartArea1"  ChartType="Line"   Legend="Legends1" Color="Orange"/>
                                    <asp:Series Name ="LCL_CL_AB" ChartArea ="ChartArea1"   ChartType="Line" IsVisibleInLegend ="False"  Color ="Menu" Legend="Legends1"/>
                                    <asp:Series Name ="LCL_CL_BC" ChartArea ="ChartArea1"   ChartType="Line" IsVisibleInLegend ="False" Color="Menu" Legend="Legends1"/>
                                    <asp:Series Name ="CL" ChartArea ="ChartArea1" ChartType="Line"  Legend="Legends1" Color="Turquoise"/>
                                    <asp:Series Name ="CL_UCL_BC" ChartArea ="ChartArea1" ChartType="Line"   IsVisibleInLegend ="False" Color="Menu" Legend="Legends1"/>
                                    <asp:Series Name ="CL_UCL_AB" ChartArea ="ChartArea1" ChartType="Line"  IsVisibleInLegend ="False" Color="Menu" Legend="Legends1"/>
                                    <asp:Series Name ="UCL" ChartArea ="ChartArea1" ChartType="Line"   Legend="Legends1" Color="Red"/>
                                    
                                    <asp:Series Name ="X" ChartArea ="ChartArea1" ChartType="Line"  IsVisibleInLegend ="False" 
                                    MarkerStyle="Circle" MarkerSize="8" Color ="Black" Legend="Legends1"></asp:Series>
                               </Series>
                               <ChartAreas>
                                  <asp:chartarea Name="ChartArea1"> 
                                       <axisx Enabled ="False">
		                                    <majorgrid  Enabled="False" />
		                                    <MajorTickMark Enabled ="False" /> 
		                                    
	                                    </axisx>
			                            <axisy  Title ="均值" IsStartedFromZero="False">
			                                <MajorGrid Enabled ="False" />
			                                <MajorTickMark Enabled ="False" />                  
			                            </axisy>
	                                </asp:chartarea>
                               </ChartAreas>
                           </asp:Chart>
	                    </td>
	                </tr>
	                 <tr>
	                    <td>
	                     <asp:GridView ID="GVXException" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                            AutoGenerateColumns="False"  Width ="100%" DataKeyNames ="TestingDate"
                             meta:resourcekey="GVXExceptionResource1">
                          <Columns>
                          <asp:BoundField  DataField="NoOfTimes" meta:resourcekey="BoundFieldResource4">
                                  <ItemStyle Width="200px" />
                                  </asp:BoundField> 
                              <asp:BoundField  DataField="TestingDate" DataFormatString="{0:yyyy-MM-dd}"
                              meta:resourcekey="BoundFieldResource5" ><ItemStyle Width="200px" />
                              </asp:BoundField>
                              <asp:TemplateField  meta:resourcekey="TemplateFieldResource1" >
                                <ItemTemplate >
                                  <asp:TextBox ID="tbxXComment" runat="server" MaxLength="100" Width="300px" 
                                        meta:resourcekey="tbxXCommentResource1"/>
                                </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>
                        </asp:GridView>    
                      </td>   
	                </tr>
	            </table>
           </asp:Panel>
        </td>
     </tr>
     <tr>
        <td>
             <asp:Panel ID="HeaderPanelChartR" runat="server" style="cursor: pointer;" 
                meta:resourcekey="HeaderPanelChartRResource1">
                <div class="heading">
                    <asp:ImageButton ID="ToggleImageChartR" runat="server" AlternateText="expand" 
                        meta:resourcekey="ToggleImageChartRResource1" />
                      <asp:Label ID ="lblTitle5" runat ="server"  meta:resourcekey="lblTitle5Resource1" />
                </div>
            </asp:Panel>
           <asp:Panel ID="ContentPanelChartR" runat="server" BorderColor="ButtonFace" BorderStyle="Solid" BorderWidth="1"
                meta:resourcekey="ContentPanelChartRResource1">
                     <table style ="width:100%">
	                 <tr>
	                    <td>
	                        <table style ="width:100%" class ="setup-table">
	                            <tr>
	                                 <td style ="width:20%"><asp:Label ID="lblCL_R" runat="server" meta:resourcekey="lblCL_RResource1"/>
	                                 </td>
                                     <td><asp:Literal ID ="ltlCL_R" runat ="server" meta:resourcekey="ltlCL_RResource1" /></td>
	                            </tr>
	                            <tr>
	                                 <td><asp:Label ID="lblUCL_R" runat="server" meta:resourcekey="lblUCL_RResource1"/></td>
                                     <td><asp:Literal ID ="ltlUCL_R" runat ="server" 
                                             meta:resourcekey="ltlUCL_RResource1" /></td>
	                            </tr>
	                            <tr>
	                                 <td><asp:Label ID="lblLCL_R" runat="server" meta:resourcekey="lblLCL_RResource1"/></td>
                                     <td><asp:Literal ID ="ltlLCL_R" runat ="server" 
                                             meta:resourcekey="ltlLCL_RResource1" /></td>
	                            </tr>
	                        </table>
	                    </td>
	                 </tr>
	                 <tr>
	                    <td>
	                      <asp:Chart ID="chartR" runat="server" Width="950px" Height="250px"  
                            BackColor="211, 223, 240" BorderColor="#F3DFC1" BorderDashStyle="Solid" 
                            BackSecondaryColor="White"  BorderWidth="2px" 
                                meta:resourcekey="chartRResource1" oncustomize="chartR_Customize" >
                                <Titles >
                                    <asp:Title Text="MR控制图"  Font="Microsoft Sans Serif, 10pt" Name="Title1" />
                                </Titles>
                                <Legends>
                                    <asp:Legend Name ="Legends1"  Alignment="Center" BorderColor="DimGray" >
                                    </asp:Legend>
                                </Legends>
                               <Series>    
                                   <asp:Series Name ="LCL" ChartArea ="ChartArea1" ChartType="Line"  Legend="Legends1" Color="Orange"/>
                                   <asp:Series Name ="CL" ChartArea ="ChartArea1" ChartType="Line"  Legend="Legends1"  Color="Turquoise"/>
                                   <asp:Series Name ="UCL" ChartArea ="ChartArea1" ChartType="Line"  Legend="Legends1"  Color="Red"/>
                                   <asp:Series Name ="R" ChartArea ="ChartArea1" ChartType="Line"  
                                       IsVisibleInLegend ="False" MarkerStyle="Circle" MarkerSize="8" Color ="Black" 
                                       Legend="Legends1"></asp:Series>
                               </Series>
                               <ChartAreas>
                                  <asp:chartarea Name="ChartArea1"> 
                                    <axisx  Enabled ="False"   >
		                                    <majorgrid  Enabled="False"/>
	                                    </axisx>
			                             <axisy  Title ="极差"  IsStartedFromZero="False">
			                                <MajorGrid Enabled ="False" />
			                                <MajorTickMark Enabled ="False" />   
			                            </axisy>                           
	                                </asp:chartarea>
                               </ChartAreas>
                           </asp:Chart>
	                    </td>
	                </tr>
	                 <tr>
	                    <td>
	                     <asp:GridView ID="GVRException" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                            AutoGenerateColumns="False"  Width ="100%" DataKeyNames ="TestingDate"
                             meta:resourcekey="GVRExceptionResource1">
                          <Columns>
                             <asp:BoundField  DataField="NoOfTimes" meta:resourcekey="BoundFieldResource6">
                                  <ItemStyle Width="200px" />
                               </asp:BoundField>
                              <asp:BoundField  DataField="TestingDate" DataFormatString="{0:yyyy-MM-dd}"
                              meta:resourcekey="BoundFieldResource7">
                                  <ItemStyle Width="200px" />
                              </asp:BoundField>
                              <asp:TemplateField  meta:resourcekey="TemplateFieldResource2" >
                                <ItemTemplate >
                                  <asp:TextBox ID="tbxRComment" runat="server" MaxLength="100"  Width="300px" 
                                        meta:resourcekey="tbxRCommentResource1"/>
                                </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>
                        </asp:GridView>   
                        </td>    
	                </tr>
	            </table>
	         </asp:Panel>    
	    </td>
	 </tr>  
	 <tr>
	    <td align ="right">
	        <asp:Button ID="btnSave" runat ="server" Width ="80px" 
                meta:resourcekey="btnSaveResource1" onclick="btnSave_Click" />
            &nbsp;
	        <asp:Button ID="btnClose" runat ="server" Width ="80px" OnClientClick ="return winClose()"
                meta:resourcekey="btnCloseResource1" />
	    </td>
	</tr>  
</table>
<ajaxToolkit:CollapsiblePanelExtender ID="CPEItem" runat="Server"
        TargetControlID="ContentPanelItem"
        ExpandControlID="HeaderPanelItem"
        CollapseControlID="HeaderPanelItem"
         SuppressPostBack="True"
        ImageControlID="ToggleImageItem" 
        ExpandedImage="images/collapse.jpg"
        CollapsedImage="images/expand.jpg" Enabled="True"/> 
<ajaxToolkit:CollapsiblePanelExtender ID="CPEDetail" runat="Server"
        TargetControlID="ContentPanelDetail"
        ExpandControlID="HeaderPanelDetail"
        CollapseControlID="HeaderPanelDetail"
        SuppressPostBack="True" Collapsed="true"
        ImageControlID="ToggleImageDetail" 
        ExpandedImage="images/collapse.jpg"
        CollapsedImage="images/expand.jpg" Enabled="True"/> 
<ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelChartX" runat="Server"
        TargetControlID="ContentPanelChartX"
        ExpandControlID="HeaderPanelChartX"
        CollapseControlID="HeaderPanelChartX"
        SuppressPostBack="True"
        ImageControlID="ToggleImageChartX" 
        ExpandedImage="images/collapse.jpg"
        CollapsedImage="images/expand.jpg" Enabled="True"/> 
 <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelChartR" runat="Server"
        TargetControlID="ContentPanelChartR"
        ExpandControlID="HeaderPanelChartR"
        CollapseControlID="HeaderPanelChartR"
        SuppressPostBack="True"
        ImageControlID="ToggleImageChartR" 
        ExpandedImage="images/collapse.jpg"
        CollapsedImage="images/expand.jpg" Enabled="True"/> 
</asp:Content>