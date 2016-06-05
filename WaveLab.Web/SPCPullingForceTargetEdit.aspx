<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCPullingForceTargetEdit.aspx.cs" Inherits="WaveLab.Web.SPCPullingForceTargetEdit" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
$(document).ready(function(){
    $("input:submit").button();
    $(".mask_pnum").keyfilter(/[\d\-\.]/);
});

function verify() {
    if ($.trim($("#<%=tbxUCL_X.ClientID %>").val()).length == 0 ||
        $.trim($("#<%=tbxLCL_X.ClientID %>").val()).length == 0 ||
        $.trim($("#<%=tbxCL_X.ClientID %>").val()).length == 0 ||
        $.trim($("#<%=tbxUCL_R.ClientID %>").val()).length == 0 ||
        $.trim($("#<%=tbxLCL_R.ClientID %>").val()).length == 0 ||
        $.trim($("#<%=tbxCL_R.ClientID %>").val()).length == 0) {
        alert($("#<%=lblNumberRequiredMsg.ClientID %>").attr("title"));
        return false;
    }

    var reg = /^[+-]?[0-9]+.?[0-9]*$/;

    if (reg.test($.trim($("#<%=tbxUCL_X.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxLCL_X.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxCL_X.ClientID %>").val())) == false  ||
    reg.test($.trim($("#<%=tbxUCL_R.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxLCL_R.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxCL_R.ClientID %>").val())) == false)
    ) {
        alert($("#<%=lblNumberFormatErrorMsg.ClientID %>").attr("title"));
        return false;
    }
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
  <table style=" text-align:left ;"   width="600" cellpadding="5">
   <tr>
   <td colspan="2">
      <fieldset>
             <table width="150%" class="form-table">
                <tr>
                    <td  style=" width:120px"><asp:Label ID="lblMachineNo" runat="server" 
                            meta:resourcekey="lblMachineNoResource1"/></td>
                    <td >
                       <asp:Literal ID="ltlMachineNo" runat="server" 
                            meta:resourcekey="ltlMachineNoResource1" />
                    </td>
                </tr>
                <tr>
                    <td ><asp:Label ID="lblEffectiveDate" runat="server"  
                            meta:resourcekey="lblEffectiveDateResource1"/>
                    </td>
                    <td>
                         <asp:Literal ID="ltlEffectiveDate" runat="server" 
                             meta:resourcekey="ltlEffectiveDateResource1" />
                    </td>
		        </tr>
		        <tr>
                    <td >
                        <asp:Label ID ="lblUCL_X" runat ="server"
                            meta:resourcekey="lblUCL_XResource1" />
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxUCL_X" runat ="server"  Width="150px" CssClass="mask_pnum" MaxLength="10"
                        meta:resourcekey="tbxUCL_XResource1"/> 
                    </td>
                 </tr>
                 <tr>
                    <td ><asp:Label ID="lblLCL_X" runat="server" 
                            meta:resourcekey="lblLCL_XResource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxLCL_X" runat="server" Width="150px" CssClass="mask_pnum" MaxLength="10"
                             meta:resourcekey="tbxLCL_XResource1" />
                    </td>
                 </tr>
                <tr>
                    <td ><asp:Label ID="lblCL_X" runat="server" 
                            meta:resourcekey="lblCL_XResource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxCL_X" runat="server" Width="150px" CssClass="mask_pnum" MaxLength="10"
                             meta:resourcekey="tbxCL_XResource1" />
                    </td>
                 </tr>
                  <tr>
                    <td >
                        <asp:Label ID ="lblUCL_R" runat ="server"
                            meta:resourcekey="lblUCL_RResource1" />
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxUCL_R" runat ="server" Width="150px" CssClass="mask_pnum" MaxLength="10"
                        meta:resourcekey="tbxUCL_RResource1"/> 
                    </td>
                 </tr>
                 <tr>
                    <td ><asp:Label ID="lblLCL_R" runat="server" 
                            meta:resourcekey="lblLCL_RResource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxLCL_R" runat="server" Width="150px" CssClass="mask_pnum" MaxLength="10"
                             meta:resourcekey="tbxLCL_RResource1" />
                    </td>
                 </tr>
                <tr>
                    <td ><asp:Label ID="lblCL_R" runat="server" 
                            meta:resourcekey="lblCL_RResource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxCL_R" runat="server" Width="150px" CssClass="mask_pnum" MaxLength="10"
                             meta:resourcekey="tbxCL_RResource1" />
                    </td>
                 </tr>
          </table>
       </fieldset>       
    </td>
   </tr>
    <tr>
    <td>
            <asp:Label ID="lblNumberFormatTip" ForeColor="Red" runat="server"  meta:resourcekey="lblNumberFormatTipResource1"/>
        </td>
        <td align="right">
               <asp:Label ID="lblNumberRequiredMsg" runat ="server"   
                                                   meta:resourcekey="lblNumberRequiredMsgResource1"  />
              <asp:Label ID="lblNumberFormatErrorMsg" runat ="server"   
                                                    ToolTip ="<%$ Resources:globalResource,NumberFormatErrorMsg %>" />
            <asp:NewButton  ID="btnSave" runat="server"  Width ="80px" Text ="<%$ Resources:globalResource,SaveText %>"
                OnClientClick="return verify()" onclick="btnSave_Click" 
                 meta:resourcekey="btnSaveResource1"/>
            &nbsp;
            <asp:NewButton ID="btnCancel" runat ="server"  Width ="80px" Text ="<%$ Resources:globalResource,CancelText %>"
                OnClientClick="return cancel()" meta:resourcekey="btnCancelResource1" />
        </td>
    </tr>
  </table>
</center>
</asp:Content>
