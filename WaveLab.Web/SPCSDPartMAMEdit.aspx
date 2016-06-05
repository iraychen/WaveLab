<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCSDPartMAMEdit.aspx.cs" Inherits="WaveLab.Web.SPCSDPartMAMEdit" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
});

function verify() {
    var LSL_TxLoPower = $("#<%=tbxLSL_TxLoPower.ClientID %>");
    if (LSL_TxLoPower.val().length == 0) {
        alert($("#<%=lblLSL_TxLoPowerMsg.ClientID %>").attr("title"));
        return false;
    }
    var USL_TxLoPower = $("#<%=tbxUSL_TxLoPower.ClientID %>");
    if (USL_TxLoPower.val().length == 0) {
        alert($("#<%=lblUSL_TxLoPowerMsg.ClientID %>").attr("title"));
        return false;
    }
    var LSL_RxAGC = $("#<%=tbxLSL_RxAGC.ClientID %>");
    if (LSL_RxAGC.val().length == 0) {
        alert($("#<%=lblLSL_RxAGCMsg.ClientID %>").attr("title"));
        return false;
    }
    var USL_RxAGC = $("#<%=tbxUSL_RxAGC.ClientID %>");
    if (USL_RxAGC.val().length == 0) {
        alert($("#<%=lblUSL_RxAGCMsg.ClientID %>").attr("title"));
        return false;
    }
    var reg = /^[+-]?[0-9]+.?[0-9]*$/;
    if (
       ($.trim($("#<%=tbxLSL_TxLoPower.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLSL_TxLoPower.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUSL_TxLoPower.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUSL_TxLoPower.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxLSL_RxAGC.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLSL_RxAGC.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUSL_RxAGC.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUSL_RxAGC.ClientID %>").val())) == false)
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
                <td style="width:150px">
                    <asp:Label ID="lblStationNo" runat="server"  meta:resourcekey="lblStationNoResource1"/>
                </td>
                <td>
                    <asp:Literal ID="ltlStationNo" runat="server" 
                        meta:resourcekey="ltlStationNoResource1"></asp:Literal>
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
                    <asp:Label ID ="lblLSL_TxLoPower" runat ="server"
                        meta:resourcekey="lblLSL_TxLoPowerResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxLSL_TxLoPower" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxLSL_TxLoPowerResource1"/> 
                     <asp:Label ID ="lblLSL_TxLoPowerMsg" runat ="server"
                        meta:resourcekey="lblLSL_TxLoPowerMsgResource1" />
                </td>
             </tr>
              <tr>
                <td >
                    <asp:Label ID ="lblUSL_TxLoPower" runat ="server"
                        meta:resourcekey="lblUSL_TxLoPowerResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxUSL_TxLoPower" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxUSL_TxLoPowerResource1"/> 
                     <asp:Label ID ="lblUSL_TxLoPowerMsg" runat ="server"
                        meta:resourcekey="lblUSL_TxLoPowerMsgResource1" />
                </td>
             </tr>
              <tr>
                <td >
                    <asp:Label ID ="lblLSL_RxAGC" runat ="server"
                        meta:resourcekey="lblLSL_RxAGCResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxLSL_RxAGC" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxLSL_RxAGCResource1"/> 
                     <asp:Label ID ="lblLSL_RxAGCMsg" runat ="server"
                        meta:resourcekey="lblLSL_RxAGCMsgResource1" />
                </td>
             </tr>
              <tr>
                <td >
                    <asp:Label ID ="lblUSL_RxAGC" runat ="server"
                        meta:resourcekey="lblUSL_RxAGCResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxUSL_RxAGC" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxUSL_RxAGCResource1"/> 
                     <asp:Label ID ="lblUSL_RxAGCMsg" runat ="server"
                        meta:resourcekey="lblUSL_RxAGCMsgResource1" />
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