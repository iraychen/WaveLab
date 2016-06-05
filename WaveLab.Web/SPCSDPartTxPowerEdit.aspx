<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCSDPartTxPowerEdit.aspx.cs" Inherits="WaveLab.Web.SPCSDPartTxPowerEdit" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
});

function verify() {
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
    var reg = /^[+-]?[0-9]+.?[0-9]*$/;
    if (
       ($.trim($("#<%=tbxLSL.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLSL.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUSL.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUSL.ClientID %>").val())) == false)
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
  <table style=" text-align:left ;"   width="700" cellpadding="2">
   <tr>
   <td colspan="2">
      <fieldset>
         <table width="100%" class="form-table">
           <tr>
                <td style="width:100px">
                    <asp:Label ID="lblStationNo" runat="server"  meta:resourcekey="lblStationNoResource1"/>
                </td>
                <td>
                    <asp:Literal ID="ltlStationNo" runat="server" 
                        meta:resourcekey="ltlStationNoResource1"></asp:Literal>
                </td>
            </tr>
            <tr id="CHNoRow" runat="server">
                <td >
                    <asp:Label ID="lblCHNo" runat="server"  meta:resourcekey="lblCHNoResource1"/>
                </td>
                <td>
                    <asp:Literal ID="ltlCHNo" runat="server" meta:resourcekey="ltlCHNoResource1"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblMode" runat="server"  meta:resourcekey="lblModeResource1"/>
                </td>
                <td>
                    <asp:Literal ID="ltlMode" runat="server" meta:resourcekey="ltlModeResource1"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblCH" runat="server"  meta:resourcekey="lblCHResource1"/>
                </td>
                <td>
                    <asp:Literal ID="ltlCH" runat="server" meta:resourcekey="ltlCHResource1"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblPW" runat="server"  meta:resourcekey="lblPWResource1"/>
                </td>
                <td>
                    <asp:Literal ID="ltlPW" runat="server" meta:resourcekey="ltlPWResource1"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblSerialNo" runat="server"  meta:resourcekey="lblSerialNoResource1"/>
                </td>
                <td>
                    <asp:Literal ID="ltlSerialNo" runat="server" 
                        meta:resourcekey="ltlSerialNoResource1"></asp:Literal>
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
                <td>
                    <asp:Label ID="lblEnable" runat="server"  meta:resourcekey="lblEnableResource1"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chxEnable" runat="server" />                   
                </td>
             </tr>
          </table>
       </fieldset>       
    </td>
   </tr>
   <tr>
        <td>
             <asp:Label ID="lblNumberFormatErrorMsg" runat ="server"  ToolTip ="<%$ Resources:globalResource,NumberFormatErrorMsg %>" 
                            meta:resourcekey="lblNumberFormatErrorMsgResource1" />
                           
        </td>
        <td align="right">                
            <asp:Button  ID="btnSave" runat="server"  Width ="80px" Text ="<%$ Resources:globalResource,SaveText %>"
                OnClientClick="return verify()" onclick="btnSave_Click" 
                 meta:resourcekey="btnSaveResource1"/>
            &nbsp;
            <asp:Button ID="btnCancel" runat ="server"  Width ="80px" Text ="<%$ Resources:globalResource,CancelText %>"
                OnClientClick="return cancel()" meta:resourcekey="btnCancelResource1" />
        </td>
    </tr>
  </table>
</center>
</asp:Content>