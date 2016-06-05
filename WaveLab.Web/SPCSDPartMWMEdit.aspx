<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCSDPartMWMEdit.aspx.cs" Inherits="WaveLab.Web.SPCSDPartMWMEdit" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
});

function verify() {
    var LSL_TxGain = $("#<%=tbxLSL_TxGain.ClientID %>");
    if (LSL_TxGain.val().length == 0) {
        alert($("#<%=lblLSL_TxGainMsg.ClientID %>").attr("title"));
        return false;
    }
    var USL_TxGain = $("#<%=tbxUSL_TxGain.ClientID %>");
    if (USL_TxGain.val().length == 0) {
        alert($("#<%=lblUSL_TxGainMsg.ClientID %>").attr("title"));
        return false;
    }
    var LSL_RxIFGain = $("#<%=tbxLSL_RxIFGain.ClientID %>");
    if (LSL_RxIFGain.val().length == 0) {
        alert($("#<%=lblLSL_RxIFGainMsg.ClientID %>").attr("title"));
        return false;
    }
    var USL_RxIFGain = $("#<%=tbxUSL_RxIFGain.ClientID %>");
    if (USL_RxIFGain.val().length == 0) {
        alert($("#<%=lblUSL_RxIFGainMsg.ClientID %>").attr("title"));
        return false;
    }
    var reg = /^[+-]?[0-9]+.?[0-9]*$/;
    if (
       ($.trim($("#<%=tbxLSL_TxGain.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLSL_TxGain.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUSL_TxGain.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUSL_TxGain.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxLSL_RxIFGain.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLSL_RxIFGain.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUSL_RxIFGain.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUSL_RxIFGain.ClientID %>").val())) == false)
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
                    <asp:Label ID="lblTxIndex" runat="server"  meta:resourcekey="lblTxIndexResource1"/>
                </td>
                <td>
                    <asp:Literal ID="ltlTxIndex" runat="server" meta:resourcekey="ltlTxIndexResource1"></asp:Literal>
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
                    <asp:Label ID ="lblLSL_TxGain" runat ="server"
                        meta:resourcekey="lblLSL_TxGainResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxLSL_TxGain" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxLSL_TxGainResource1"/> 
                     <asp:Label ID ="lblLSL_TxGainMsg" runat ="server"
                        meta:resourcekey="lblLSL_TxGainMsgResource1" />
                </td>
             </tr>
              <tr>
                <td >
                    <asp:Label ID ="lblUSL_TxGain" runat ="server"
                        meta:resourcekey="lblUSL_TxGainResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxUSL_TxGain" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxUSL_TxGainResource1"/> 
                     <asp:Label ID ="lblUSL_TxGainMsg" runat ="server"
                        meta:resourcekey="lblUSL_TxGainMsgResource1" />
                </td>
             </tr>
              <tr>
                <td >
                    <asp:Label ID ="lblLSL_RxIFGain" runat ="server"
                        meta:resourcekey="lblLSL_RxIFGainResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxLSL_RxIFGain" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxLSL_RxIFGainResource1"/> 
                     <asp:Label ID ="lblLSL_RxIFGainMsg" runat ="server"
                        meta:resourcekey="lblLSL_RxIFGainMsgResource1" />
                </td>
             </tr>
              <tr>
                <td >
                    <asp:Label ID ="lblUSL_RxIFGain" runat ="server"
                        meta:resourcekey="lblUSL_RxIFGainResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxUSL_RxIFGain" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxUSL_RxIFGainResource1"/> 
                     <asp:Label ID ="lblUSL_RxIFGainMsg" runat ="server"
                        meta:resourcekey="lblUSL_RxIFGainMsgResource1" />
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