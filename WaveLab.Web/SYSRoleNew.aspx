<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSRoleNew.aspx.cs" Inherits="WaveLab.Web.SYSRoleNew" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var roledesc=$("#<%=tbxRoleDesc.ClientID %>");
    if(trim(roledesc.val()).length==0)
    {
      alert($("#<%=lblRoleDescMsg.ClientID %>").attr("title"));
      roledesc.focus();
      return false;
    }
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
  <table style=" text-align:left;"  width="100%">
   <tr>
      <td>
        <fieldset>
          <table  width="100%" class="form-table">
            <tr>
                <td><asp:Label ID="lblRoleDesc" runat="server"  ForeColor ="Red"
                        meta:resourcekey="lblRoleDescResource1"/></td>
                <td>
                     <asp:TextBox ID="tbxRoleDesc" runat="server" MaxLength="50" width="300px" 
                         meta:resourcekey="tbxRoleDescResource1" />
                     <asp:Label ID="lblRoleDescMsg" runat="server" 
                        meta:resourcekey="lblRoleDescMsgResource1"/>
                </td>
            </tr>
          </table>
        </fieldset>
    </td>
   </tr>
   <tr>
     <td  align ="right">
         <br />
         <asp:NewButton  ID="btnSave" runat="server"    Width ="80" Text ="<%$ Resources:globalResource,SaveText %>"
            Action ="RoleNew" OnClientClick="return verify()" onclick="btnSave_Click"/>
          &nbsp;
         <asp:NewButton ID="btnCancel" runat ="server"   Width ="80" Text ="<%$ Resources:globalResource,CancelText %>"
            OnClientClick="return cancel()"/>
    </td>
   </tr>
  </table>
</center>
</asp:Content>
