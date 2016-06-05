<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCRxPowerItemEdit.aspx.cs" Inherits="WaveLab.Web.SPCRxPowerItemEdit" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script  type ="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
});
function verify() {
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
<table style ="width:100%">
    <tr>
        <td>
            <fieldset>
             <table style="width:580px">
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
                        <td><asp:Label ID="lblPW" runat ="server" meta:resourcekey="lblPWResource1" /></td>
                        <td><asp:Literal ID="ltlPW" runat ="server" 
                                meta:resourcekey="ltlPWResource1" /></td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    
     <tr>
        <td>
            <ajaxToolkit:TabContainer ID="TabContainerTarget" runat="server"  
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
                                 <tr>
                                    <td>
                                        <asp:Label ID="lblEnable" runat="server" meta:resourcekey="lblEnableResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chxEnable" runat="server" 
                                            meta:resourcekey="chxEnableResource1" />
                                    </td>
                                 </tr>
                              </table>      
                        </td>
                       </tr>
                        <tr>
                            <td>
                                
                                <asp:Label ID="lblNumberFormatErrorMsg" runat ="server"  ToolTip ="<%$ Resources:globalResource,NumberFormatErrorMsg %>" 
                                    meta:resourcekey="lblNumberFormatErrorMsgResource1" />
                                   
                               <asp:Button  ID="btnSave" runat="server"  Width ="80px" Text ="<%$ Resources:globalResource,SaveText %>"
                                    OnClientClick="return verify()" onclick="btnSave_Click" 
                                    meta:resourcekey="btnSaveResource1" />
                                &nbsp;
                               <asp:Button ID="btnCancel" runat ="server"  Width ="80px" Text ="<%$ Resources:globalResource,CancelText %>"
                                     OnClientClick="return cancel()" meta:resourcekey="btnCancelResource1"/>
                               &nbsp;
                               <asp:Button ID="btnViewLog" runat ="server"  Width ="80px" 
                                    meta:resourcekey="btnViewLogResource1" onclick="btnViewLog_Click"/>
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
