<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCRxPowerItemSelector.aspx.cs" Inherits="WaveLab.Web.SPCRxPowerItemSelector" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script  type ="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
});
function verify() {
    var i = 0;
    $.each($("#<%=GVList.ClientID %> :checkbox"), function() {
        if ($(this).attr("checked") == true) {
            i++;
        }
    });
    if (i == 0) {
        alert($("#<%=lblMustSelectMsg.ClientID %>").attr("title"));
        return false;
    } else if (i != 1) {
        alert($("#<%=lblSelectCountMsg.ClientID %>").attr("title"));
        return false;
    }
    var SamplingLower = $("#<%=tbxSamplingLower.ClientID %>");
    if (SamplingLower.val().length == 0) {
        alert($("#<%=lblSamplingLowerMsg.ClientID %>").attr("title"));
        return false;
    }
    var SamplingUpper = $("#<%=tbxSamplingUpper.ClientID %>");
    if (SamplingUpper.val().length == 0) {
        alert($("#<%=lblSamplingUpperMsg.ClientID %>").attr("title"));
        return false;
    }  
    var LSL = $("#<%=tbxLSL.ClientID %>");
    if (LSL.val().length == 0) {
        alert($("#<%=lblLSLMsg.ClientID %>").attr("title"));
        return false;
    }
    var USL = $("#<%=tbxUSL.ClientID %>");
    if (USL.val().length == 0) {
        alert($("#<%=lblUSLMsg.ClientID %>").attr("title"));
        return false;
    }
    var LCL_X = $("#<%=tbxLCL_X.ClientID %>");
    var UCL_X = $("#<%=tbxUCL_X.ClientID %>");
    var LCL_R = $("#<%=tbxLCL_R.ClientID %>");
    var UCL_R = $("#<%=tbxUCL_R.ClientID %>");
    var reg = /^[+-]?[0-9]+.?[0-9]*$/;
    if (
       ($.trim($("#<%=tbxLSL.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLSL.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUSL.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUSL.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxLCL_X.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLCL_X.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUCL_X.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUCL_X.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxLCL_R.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLCL_R.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUCL_R.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUCL_R.ClientID %>").val())) == false)
    ) {
        alert($("#<%=lblNumberFormatErrorMsg.ClientID %>").attr("title"));
        return false;
    }
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
    <br/>
<table style ="width:100%">
    <tr>
        <td>
            <fieldset style="width:100%">
             <table style ="text-align:left; width:100%">
                 <tr>
                    <td>
                        <asp:Label ID ="lblModel" runat="server" meta:resourcekey="lblModelResource1"  />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlModel" runat="server"  Width="200"/>
                        <ajaxToolkit:ListSearchExtender ID="LSExtModel" runat="server" TargetControlID="ddlModel" />                     
                    </td>
                     <td align ="right">
                        <asp:NewButton id="btnSubmit" Runat="server" Width="80px"  meta:resourcekey="btnSubmitResource1" 
                                onclick="btnSubmit_Click"/>&nbsp;
               
                    </td>
                </tr>
                </table>
        </fieldset>
        </td>
        
    </tr>
    <tr>
        <td><asp:Label ID ="lblRecCount" runat ="server" 
                meta:resourcekey="lblRecCountResource1" /></td>
    </tr>
    <tr>
        <td>
        <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False"  
              SkinID="skinGridView"  Width ="100%" onrowdatabound="GVList_RowDataBound"
            meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" >
              <Columns>
                  <asp:BoundField  DataField="Mode" SortExpression ="mode"  
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource1">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField  DataField="CH" SortExpression ="CH"  
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource2">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                 <asp:BoundField  DataField="PW" SortExpression ="b.rx_power"  
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource3">
                  </asp:BoundField>
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource1" 
                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                   <ItemTemplate>
                       <asp:CheckBox ID="chxTakePartIn" runat="server" 
                           meta:resourcekey="chxTakePartInResource1" />
                    </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
        </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <ajaxToolkit:TabContainer ID="TabContainerTarget" runat="server"   Visible="false"
                ActiveTabIndex="0"         
                OnDemand="true"
                UseVerticalStripPlacement="true"
                VerticalStripWidth="120px" meta:resourcekey="TabContainerTargetResource1" >
            <ajaxToolkit:TabPanel ID="TabPanelCreate" runat="server" 
                    meta:resourcekey="TabPanelCreateResource1">
                <HeaderTemplate>
                  <asp:Label ID ="lblTitleCreate" runat ="server" 
                        meta:resourcekey="lblTitleCreateResource1" />
                </HeaderTemplate>
                <ContentTemplate>  
                    <asp:UpdatePanel ID="SaveUpdatePanel" runat="server">
                        <ContentTemplate>
                         <table style=" text-align:left ; margin-top:5px;"   cellpadding="2">
                        <tr>
                       <td>
                             <table  class="form-table">   
                              <tr>
                                    <td >
                                        <asp:Label ID ="lblSamplingLower" runat ="server"
                                            meta:resourcekey="lblSamplingLowerResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxSamplingLower" runat ="server" Width="200px" CssClass="mask_pnum" MaxLength="10"
                                        meta:resourcekey="tbxSamplingLowerResource1"/> 
                                         <asp:Label ID ="lblSamplingLowerMsg" runat ="server"
                                            meta:resourcekey="lblSamplingLowerMsgResource1" />
                                    </td>
                                 </tr>  
                                 <tr>
                                    <td >
                                        <asp:Label ID ="lblSamplingUpper" runat ="server"
                                            meta:resourcekey="lblSamplingUpperResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxSamplingUpper" runat ="server" Width="200px" CssClass="mask_pnum" MaxLength="10"
                                        meta:resourcekey="tbxSamplingUpperResource1"/> 
                                         <asp:Label ID ="lblSamplingUpperMsg" runat ="server"
                                            meta:resourcekey="lblSamplingUpperMsgResource1" />
                                    </td>
                                 </tr>                         	      
	                            <tr>
                                    <td >
                                        <asp:Label ID ="lblLSL" runat ="server"
                                            meta:resourcekey="lblLSLResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxLSL" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                                        meta:resourcekey="tbxLSLResource1"/> 
                                         <asp:Label ID ="lblLSLMsg" runat ="server"
                                            meta:resourcekey="lblLSLMsgResource1" />
                                    </td>
                                 </tr>
                                  <tr>
                                    <td >
                                        <asp:Label ID ="lblUSL" runat ="server"
                                            meta:resourcekey="lblUSLResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxUSL" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                                        meta:resourcekey="tbxUSLResource1"/> 
                                         <asp:Label ID ="lblUSLMsg" runat ="server"
                                            meta:resourcekey="lblUSLMsgResource1" />
                                    </td>
                                 </tr>
                                 <tr>
                                    <td >
                                        <asp:Label ID ="lblLCL_X" runat ="server"
                                            meta:resourcekey="lblLCL_XResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxLCL_X" runat ="server"     Width="200px" CssClass="mask_pnum" MaxLength="10"
                                        meta:resourcekey="tbxLCL_XResource1"/> 
                                    </td>
                                 </tr>
                                  <tr>
                                    <td >
                                        <asp:Label ID ="lblUCL_X" runat ="server"
                                            meta:resourcekey="lblUCL_XResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxUCL_X" runat ="server"     Width="200px" CssClass="mask_pnum" MaxLength="10"
                                        meta:resourcekey="tbxUCL_XResource1"/> 
                                    </td>
                                 </tr>
                                 <tr>
	                                <td >
		                                <asp:Label ID ="lblLCL_R" runat ="server"
			                                meta:resourcekey="lblLCL_RResource1" />
	                                </td>
	                                <td>
		                                <asp:TextBox ID ="tbxLCL_R" runat ="server"     Width="200px" CssClass="mask_pnum" MaxLength="10"
		                                meta:resourcekey="tbxLCL_RResource1"/> 
	                                </td>
	                                </tr>
	                                <tr>
	                                <td >
		                                <asp:Label ID ="lblUCL_R" runat ="server"
			                                meta:resourcekey="lblUCL_RResource1" />
	                                </td>
	                                <td>
		                                <asp:TextBox ID ="tbxUCL_R" runat ="server"     Width="200px" CssClass="mask_pnum" MaxLength="10"
		                                meta:resourcekey="tbxUCL_RResource1"/> 
	                                </td>
                                </tr>
                              </table>     
                        </td>
                       </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMustSelectMsg" runat="server" 
                                    meta:resourcekey="lblMustSelectMsgResource1"></asp:Label>
                                <asp:Label ID="lblSelectCountMsg" runat="server" 
                                    meta:resourcekey="lblSelectCountMsgResource1"></asp:Label>
                                <asp:Label ID="lblNumberFormatErrorMsg" runat ="server"  ToolTip ="<%$ Resources:globalResource,NumberFormatErrorMsg %>" 
                                    meta:resourcekey="lblNumberFormatErrorMsgResource1" />
                                   
                               <asp:Button  ID="btnSave" runat="server"  Width ="80px" Text ="<%$ Resources:globalResource,SaveText %>"
                                    OnClientClick="return verify()" onclick="btnSave_Click" />
                                &nbsp;
                               <asp:Button ID="btnCancel" runat ="server"  Width ="80px" Text ="<%$ Resources:globalResource,CancelText %>"
                                     OnClientClick="return cancel()"/>
                            </td>
                        </tr>
                      </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnSave"/>
                        </Triggers>
                    </asp:UpdatePanel>
                     
                </ContentTemplate>
               </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </td>
    </tr>
</table>
</asp:Content>
