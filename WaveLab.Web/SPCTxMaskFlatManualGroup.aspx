<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCTxMaskFlatManualGroup.aspx.cs" Inherits="WaveLab.Web.SPCTxMaskFlatManualGroup" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
 <script type ="text/javascript">
     $(document).ready(function() {
         $("input:submit").button();
         $(".date").datepicker({
             showOn: "button",
             buttonImageOnly: true,
             dateFormat: "yy-mm-dd",
             changeYear: true,
             changeMonth: true
         });
         $(".date").mask("9999-99-99", {});

         $("#<%=chxAutoInputTarget.ClientID%>").bind("click", function() {
             if ($(this).attr("checked") == true) {
                 $("#<%=tblUSL.ClientID%>").hide();
             } else {
                 $("#<%=tblUSL.ClientID%>").show();
             }
         });
     });

function formSearch() {
    var dateFrom = $("#<%=tbxDateFrom.ClientID %>");
    var dateTo = $("#<%=tbxDateTo.ClientID %>");
    if (dateFrom.val().length == 0 || dateTo.val().length == 0) {
        alert($("#<%=lblDateRequiredMsg.ClientID %>").attr("title"));
        return false;
    }
    if (checkDate(dateFrom.val()) == false) {
        alert($("#<%=lblDateFormatMsg.ClientID %>").attr("title"));
        dateFrom.focus();
        return false;
    }
    if (checkDate(dateTo.val()) == false) {
        alert($("#<%=lblDateFormatMsg.ClientID %>").attr("title"));
        dateTo.focus();
        return false;
    }
    return true;
}

function grouping() {
    var count = 0;
    $.each($("#<%=GVItems.ClientID %> :checkbox"), function() {
        if ($(this).attr("checked") == true) {
            count++;
        }
    });
    if (count == 0) {
        alert($("#<%=lblSelectCountMsg.ClientID %>").attr("title"));
        return false;
    } else {
    if (count < parseInt($("#<%=tbxGroupingNo.ClientID %>").val())) {
            alert($("#<%=lblGroupNoMsg.ClientID %>").attr("title"));
            return false;
        }
    }
    return true;
}

function formSubmit() {
    if ($("#<%=chxAutoInputTarget.ClientID%>").attr("checked") == false) {
        var usl = $("#<%=tbxUSL.ClientID %>");
        if ($.trim(usl.val()).length == 0) {
            alert($("#<%=lblDataRangeMsg.ClientID %>").attr("title"));
            return false;
        } else {
            var reg = /^[+-]?[0-9]+.?[0-9]*$/; ;
            if ($.trim(usl.val()).length > 0 && reg.test($.trim(usl.val())) == false) {
                alert($("#<%=lblNumberFormatErrorMsg.ClientID %>").attr("title"));
                return false;
            }
        }
    }
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">

<ajaxToolkit:TabContainer ID="TabContainer1" runat="server" 
        ActiveTabIndex="0"        
        OnDemand="true"        
        TabStripPlacement="Top"
        ScrollBars="None"
        UseVerticalStripPlacement="true"
        VerticalStripWidth="120px"  
        AutoPostBack="false">
    <ajaxToolkit:TabPanel ID="TabPanelManual" runat="server" >
        <HeaderTemplate>
            <asp:Label ID="lblManualTitle" runat ="server"   meta:resourcekey="lblManualTitleResource1"></asp:Label>
        </HeaderTemplate>
        <ContentTemplate>
            <table width ="100%">
                <tr>
                    <td>
                        <fieldset>
                        <table style =" width:100%">
                            <tr>
                                <td>
                                     <table style =" width:100%">
                                        <tr>
                                            <td><asp:Label ID="lblType" runat ="server" meta:resourcekey="lblTypeResource1" /></td>
                                            <td><asp:Literal ID="ltlType" runat ="server" meta:resourcekey="ltlTypeResource1" /></td>
                                            <td><asp:Label ID="lblMode" runat ="server" meta:resourcekey="lblModeResource1" /></td>
                                            <td ><asp:Literal ID="ltlMode" runat ="server" 
                                                    meta:resourcekey="ltlModeResource1" /></td>
                                        </tr>
                                        <tr>
                                            <td><asp:Label ID="lblCH" runat ="server" meta:resourcekey="lblCHResource1" /></td>
                                            <td><asp:Literal ID="ltlCH" runat ="server" meta:resourcekey="ltlCHResource1" /></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                             <td >
                                               <asp:Label ID="lblDateFrom" runat="server" 
                                                    meta:resourcekey="lblDateFromResource1" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID ="tbxDateFrom" runat ="server"  MaxLength ="10"  CssClass ="date"
                                                    Width ="80px" meta:resourcekey="tbxDateFromResource1"/>
                                                <asp:Label ID="lblDateFormFormat" runat ="server" 
                                                   Text ="<%$ Resources:globalResource,DateFormat %>" 
                                                   meta:resourcekey="lblDateFromFormatResource1"  /> 
                                            </td>
                                             
                                            <td>
                                                <asp:Label ID="lblDateTo" runat="server" meta:resourcekey="lblDateToResource1" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID ="tbxDateTo" runat ="server"  MaxLength ="10"  CssClass ="date"
                                                    Width ="80px" meta:resourcekey="tbxDateToResource1"/>
                                                <asp:Label ID="lblDateToFormat" runat ="server" 
                                                   Text ="<%$ Resources:globalResource,DateFormat %>" 
                                                   meta:resourcekey="lblDateToFormatResource1"  /> 
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align ="right">
                                     <asp:Label ID="lblDateRequiredMsg" runat ="server" 
                                                   ToolTip ="<%$ Resources:globalResource,DateRequiredMsg %>" /> 
                                     <asp:Label ID="lblDateFormatMsg" runat ="server"   
                                                    ToolTip ="<%$ Resources:globalResource,DateFormatMsg %>" />
                                    <asp:NewButton id="btnSearch" Runat="server" Width="80px"  
                                            OnClientClick ="return formSearch()" meta:resourcekey="btnSearchResource1" 
                                            onclick="btnSearch_Click" style="height: 26px"/>&nbsp;
                                </td>
                            </tr>
                        </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
	                <td><asp:Label ID="lblRecCount" runat="server" 
                            meta:resourcekey="lblRecCountResource1"></asp:Label></td>
	            </tr>
	            <tr>
		            <td>
                        <asp:Panel ID="HeaderPanelItems" runat="server" style="cursor: pointer;">
                            <div class="heading">
                                <asp:ImageButton ID="ToggleImageItems" runat="server" AlternateText="expand"/>
                                <asp:Label ID ="lblItemsTitle" runat ="server" meta:resourcekey="lblItemsTitleResource1"/>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelItems" runat="server">
                            <div style ="height:300px; overflow-x:hidden;overflow-y:auto; border:solid 1px #aaaaaa; text-align:left;">
                                <asp:GridView ID="GVItems" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                                    AutoGenerateColumns="False"  Width ="100%"
                                     meta:resourcekey="GVItemsResource1"  onsorting="GVItems_Sorting"  >
                                  <Columns>
                                      <asp:BoundField  DataField="SerialNo" SortExpression ="a.serial_no"
                                            meta:resourcekey="BoundFieldResource1">
                                          <HeaderStyle Width="30%" />
                                      </asp:BoundField>
                                      <asp:BoundField  DataField="EndTime" SortExpression ="a.end_time"
                                            DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" 
                                          meta:resourcekey="BoundFieldResource2">
                                          <HeaderStyle Width="30%" />
                                      </asp:BoundField>
                                      <asp:BoundField  DataField="Val" SortExpression ="b.mask_flat"
                                            meta:resourcekey="BoundFieldResource3">
                                          <HeaderStyle Width="30%" />
                                      </asp:BoundField>
                                      <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chxSelect" runat ="server"  Checked ="True" 
                                                meta:resourcekey="chxSelectResource1"/>
                                        </ItemTemplate>
                                          <HeaderStyle Width="10%" />
                                      </asp:TemplateField>
                                  </Columns>
                                </asp:GridView>  
                            </div>   
                        </asp:Panel>
		            </td>
	            </tr>
	            <tr>
	                <td>
	                  <table id="tblGrouping" runat ="server" visible ="False" style ="width:100%">
	                    <tr>
	                        <td><asp:Label ID ="lblItemsCount" runat ="server" 
                                    meta:resourcekey="lblItemsCountResource1" /></td>
	                        <td align="right">
	                            <table>
	                                <tr>
                                        <td><asp:Label ID ="lblGroupingNo" runat ="server" 
                                                meta:resourcekey="lblGroupingNoResource1" /></td>
                                        <td>
                                            <asp:TextBox ID="tbxGroupingNo" runat ="server"  Text="5"
                                                meta:resourcekey="tbxGroupingNoResource1" />
                                             <ajaxToolkit:NumericUpDownExtender ID="NumericUpDownExtender1" runat="server"
                                                TargetControlID="tbxGroupingNo"
                                                Width="100"
                                                Minimum = "2"
                                                Maximum = "10" Enabled="True" />
                                        </td>
                                        <td>
                                              <asp:Label ID ="lblSelectCountMsg" runat ="server" 
                                                  meta:resourcekey="lblSelectCountMsgResource1" />
                                              <asp:Label ID="lblGroupNoMsg" runat ="server" 
                                                  meta:resourcekey="lblGroupNoMsgResource1" />
                                        </td>
                                        <td>
                                            <asp:Button ID ="btnRanGroup" runat ="server"  Width ="80px"  OnClientClick ="return grouping()"
                                                onclick="btnRanGroup_Click" meta:resourcekey="btnRanGroupResource1"/>
                                        </td>
                                        <td>
                                            <asp:Button ID ="btnSequenceGroup" runat ="server"  Width ="80px" OnClientClick ="return grouping()"
                                                onclick="btnSequenceGroup_Click" 
                                                meta:resourcekey="btnSequenceGroupResource1"/>
                                        </td>
                                    </tr>
	                            </table>
	                        </td>
	                    </tr>

                    </table>         
	                </td>
	            </tr>
	            <tr>
		            <td>
		                <asp:Panel ID="HeaderPanelGroupItems" runat="server" style="cursor: pointer;">
                            <div class="heading">
                                <asp:ImageButton ID="ToggleImageGroupItems" runat="server" AlternateText="expand"/>
                                <asp:Label ID ="lblGroupItems" runat ="server" meta:resourcekey="lblGroupsTitleResource1"/>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="ContentPanelGroupItems" runat="server">
		                    <div style ="height:300px; overflow-x:hidden;overflow-y:auto; border:solid 1px #aaaaaa; text-align:left;">
		                        <asp:GridView ID="GVGroupItems" runat="server" SkinId="skinGridView"
                                    AutoGenerateColumns="False"  Width ="100%" meta:resourcekey="GVGroupItemsResource1">
                                  <Columns>
                                      <asp:BoundField  DataField="SerialNo"
                                            meta:resourcekey="BoundFieldResource1">
                                          <HeaderStyle Width="30%" />
                                      </asp:BoundField>
                                      <asp:BoundField  DataField="EndTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" 
                                            meta:resourcekey="BoundFieldResource2">
                                          <HeaderStyle Width="30%" />
                                      </asp:BoundField>
                                      <asp:BoundField  DataField="Val"
                                            meta:resourcekey="BoundFieldResource3">
                                          <HeaderStyle Width="30%" />
                                      </asp:BoundField>
                                      <asp:BoundField  DataField="GroupNo"
                                            meta:resourcekey="BoundFieldResource4">
                                          <HeaderStyle Width="10%" />
                                      </asp:BoundField>
                                  </Columns>
                                </asp:GridView>    
                           </div>
                        </asp:Panel>
		            </td>
	            </tr>
	            <tr>
	                <td>
	                    <table id ="tblSubmit"  runat ="server" visible ="False" style ="width:100%">
	                        <tr>
	                            <td >
                                    <asp:Label ID="lblGroupCount" runat ="server"  meta:resourcekey="lblGroupCountResource1"/>
                                    &nbsp;
                                    <asp:Label ID ="lblGroupItemsCount" runat ="server" 
                                        meta:resourcekey="lblGroupItemsCountResource1" />
	                            </td>
	                             <td id="tblLCL_UCL" runat ="server" align="center">
	                                <fieldset>
	                                <table>
	                                    <tr>
	                                         <td><asp:Label ID="lblLCL_X" runat ="server" meta:resourcekey="lblLCL_XResource1" /></td>
	                                        <td>
		                                        <asp:TextBox ID ="tbxLCL_X" runat ="server" Width ="60px" 
			                                        meta:resourcekey="tbxLCL_XResource1"/>
		                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilterExtLCL_X" ValidChars=".-" 
			                                        runat="server" FilterType ="Custom, Numbers" TargetControlID ="tbxLCL_X" 
			                                        Enabled="True" />	                               
	                                         </td>	                          
	                                        <td><asp:Label ID="lblUCL_X" runat ="server" meta:resourcekey="lblUCL_XResource1" /></td>
	                                        <td>
		                                        <asp:TextBox ID ="tbxUCL_X" runat ="server" Width ="60px" 
			                                        meta:resourcekey="tbxUCL_X_Resource1"/>
		                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilterExtUCL_X" ValidChars=".-" 
			                                        runat="server" FilterType ="Custom, Numbers" TargetControlID ="tbxUCL_X" 
			                                        Enabled="True" />	                               
	                                        </td>
	                                     </tr>
	                                     <tr>
                                            <td><asp:Label ID="lblLCL_R" runat ="server" meta:resourcekey="lblLCL_RResource1" /></td>
                                            <td>
	                                            <asp:TextBox ID ="tbxLCL_R" runat ="server" Width ="60px" 
		                                            meta:resourcekey="tbxLCL_RResource1"/>
	                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilterExtLCL_R" ValidChars=".-" 
		                                            runat="server" FilterType ="Custom, Numbers" TargetControlID ="tbxLCL_R" 
		                                            Enabled="True" />	                               
                                             </td>	                          
                                            <td><asp:Label ID="lblUCL_R" runat ="server" meta:resourcekey="lblUCL_RResource1" /></td>
                                            <td>
	                                            <asp:TextBox ID ="tbxUCL_R" runat ="server" Width ="60px" 
		                                            meta:resourcekey="tbxUCL_RResource1"/>
	                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilterExtUCL_R" ValidChars=".-" 
		                                            runat="server" FilterType ="Custom, Numbers" TargetControlID ="tbxUCL_R" 
		                                            Enabled="True" />	                               
                                            </td>	
                                        </tr>
	                                </table>
	                                </fieldset>
	                            </td>
	                            <td id="tblUSL"  runat="server"  align="center">
	                                <fieldset>
	                                   <table>
	                                    <tr>
	                                        <td><asp:Label ID="lblUSL" runat ="server" meta:resourcekey="lblUSLResource1" /></td>
	                                        <td>
	                                            <asp:TextBox ID ="tbxUSL" runat ="server" Width ="60px" 
                                                    meta:resourcekey="tbxUSLResource1"/>
	                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilterExtUSL" ValidChars=".-" 
                                                    runat="server" FilterType ="Custom, Numbers" TargetControlID ="tbxUSL" 
                                                    Enabled="True" />	                               
	                                        </td>	                                                                                                
	                                    </tr>
	                                </table>
	                                </fieldset>
	                            </td>
	                            <td align="right" style="white-space:nowrap">
	                               <asp:CheckBox ID="chxAutoInputTarget" runat ="server"  meta:resourcekey="chxAutoInputTargetResource1" ForeColor="Blue" />
                                   
                                   <asp:Label ID="lblDataRangeMsg" runat ="server" 
                                        meta:resourcekey="lblDataRangeMsgResource1" />
                                   <asp:Label ID="lblNumberFormatErrorMsg" runat ="server"   
                                                    ToolTip ="<%$ Resources:globalResource,NumberFormatErrorMsg %>" />
                                    <asp:NewButton ID="btnSubmit" runat ="server"  Width ="100px" 
                                        OnClientClick ="return formSubmit()" onclick="btnSubmit_Click" 
                                        meta:resourcekey="btnSubmitResource1"/></td>
	                        </tr>
	                    </table>
	                </td>
	            </tr>    
            </table>
            <ajaxToolkit:CollapsiblePanelExtender ID="CPEItems" runat="Server"
                TargetControlID="ContentPanelItems"
                ExpandControlID="HeaderPanelItems"
                CollapseControlID="HeaderPanelItems"
                Collapsed="False"
                 SuppressPostBack="true"
                ImageControlID="ToggleImageItems" 
                ExpandedImage="images/collapse.jpg"
                CollapsedImage="images/expand.jpg"/> 
             <ajaxToolkit:CollapsiblePanelExtender ID="CPEGroupItems" runat="Server"
                TargetControlID="ContentPanelGroupItems"
                ExpandControlID="HeaderPanelGroupItems"
                CollapseControlID="HeaderPanelGroupItems"
                Collapsed="False"
                 SuppressPostBack="true"
                ImageControlID="ToggleImageGroupItems" 
                ExpandedImage="images/collapse.jpg"
                CollapsedImage="images/expand.jpg"/> 
       </ContentTemplate>
    </ajaxToolkit:TabPanel>
    
    <ajaxToolkit:TabPanel ID="TabPanelAuto" runat="server" >
        <HeaderTemplate>
           <asp:LinkButton ID="lbtAutoTitle" runat ="server"   
        meta:resourcekey="lbtAutoTitleResource1" onclick="lbtAutoTitle_Click" />
        </HeaderTemplate>
        <ContentTemplate>
        
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    
</ajaxToolkit:TabContainer>
  
  
  
</asp:Content>
