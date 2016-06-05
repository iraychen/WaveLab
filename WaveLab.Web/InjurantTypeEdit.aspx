<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="InjurantTypeEdit.aspx.cs" Inherits="WaveLab.Web.InjurantTypeEdit" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var productDesc=$("#<%=tbxInjurantTypeDesc.ClientID %>");
    if(trim(productDesc.val()).length==0)
    {
      alert($("#<%=lblInjurantTypeDescMsg.ClientID %>").attr("title"));
      productDesc.focus();
      return false;
    }
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
  <table style=" text-align:left ;"  width="400px">
  <tr>
        <td align="center">
           <br />
           <asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" 
             meta:resourcekey="lblTitleResource" /><br />
           <br />
        </td>
    </tr>
   <tr>
   <td>
    <fieldset>
         <table  width="100%" class="form-table">
            <tr>
                <td><asp:Label ID="lblInjurantTypeDesc" runat="server"  ForeColor ="Red"
                        meta:resourcekey="lblInjurantTypeDescResource1"/></td>
                <td>
                     <asp:TextBox ID="tbxInjurantTypeDesc" runat="server" MaxLength="50" width="250px" 
                         meta:resourcekey="tbxInjurantTypeDescResource1" />
                      <asp:Label ID="lblInjurantTypeDescMsg" runat="server" 
                        meta:resourcekey="lblInjurantTypeDescMsgResource1"/>
                </td>
            </tr>
        </table>
      </fieldset>  
    </td>
   </tr>
   <tr>
        <td align ="center">
          <br />
          <asp:NewButton ID="btnSave" runat="server" Width ="80px"  Text ="<%$ Resources:globalResource,SaveText %>"
               OnClientClick="return verify()" onclick="btnSave_Click"/>
          &nbsp;
          <asp:NewButton ID="btnDelete" runat ="server"  Width ="80px" Text ="<%$ Resources:globalResource,DeleteText %>"
                onclick="btnDelete_Click"/>
          &nbsp;
          <asp:NewButton ID="btnCancel" runat ="server"   Width ="80" Text ="<%$ Resources:globalResource,CancelText %>"
            OnClientClick="return cancel()"/>
        </td>
   </tr>
  </table>
</center>
</asp:Content>
