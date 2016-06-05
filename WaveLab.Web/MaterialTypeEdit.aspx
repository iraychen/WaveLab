<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MaterialTypeEdit.aspx.cs" Inherits="WaveLab.Web.MaterialTypeEdit" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var materialTypeDesc=$("#<%=tbxMaterialTypeDesc.ClientID %>");
    if(trim(materialTypeDesc.val()).length==0)
    {
      alert($("#<%=lblMaterialTypeDescMsg.ClientID %>").attr("title"));
      materialTypeDesc.focus();
      return false;
    }
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
  <table style="text-align:left;" width="400px">
    <tr>
        <td align ="center" >
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
                <td><asp:Label ID="lblMaterialTypeDesc" runat="server"  ForeColor ="Red"
                        meta:resourcekey="lblMaterialTypeDescResource1"/></td>
                <td>
                     <asp:TextBox ID="tbxMaterialTypeDesc" runat="server" MaxLength="50" width="200px" 
                         meta:resourcekey="tbxMaterialTypeDescResource1" />
                      <asp:Label ID="lblMaterialTypeDescMsg" runat="server" 
                        meta:resourcekey="lblMaterialTypeDescMsgResource1"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCalByQuantity" runat ="server" 
                        meta:resourcekey="lblCalByQuantityResource1" />
                </td>
                <td>
                    <asp:RadioButtonList ID="rblCalByQuantity" runat ="server" 
                        CssClass ="cl-table"   RepeatDirection="Horizontal" Width ="80px"
                        meta:resourcekey="rblCalByQuantityResource1">
                        <asp:ListItem meta:resourcekey="ListItemResource1"  Selected ="True"></asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource2" ></asp:ListItem>
                    </asp:RadioButtonList>
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