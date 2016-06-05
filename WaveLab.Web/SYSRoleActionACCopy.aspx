<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSRoleActionACCopy.aspx.cs" Inherits="WaveLab.Web.SYSRoleActionACCopy" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript" >
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var roleId=$("#<%=ddlOtherRole.ClientID%>");
    if(roleId.val().length==0)
    {
      alert($("#<%=lblOtherRole.ClientID%>").attr("title"));
      return false;
    }
    return true;
}
function goBack()
{
    self.location.href = 'SYSRoleactionac.aspx?roleid=<%=Request.QueryString["roleid"] %>';
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
 <center>
 <table  cellpadding="5" cellspacing="0" style="text-align:left;">
    <tr>
        <td align ="center" >
            <fieldset>
              <table  width="300" style="text-align:left;" class ="form-table" >
                  <tr>
                    <td>
                      
                        <asp:Label ID ="lblRole" runat="server" meta:resourcekey="lblRoleResource1" />
                      
                    </td>
                    <td>
                      <asp:Label ID="lblRoldeDesc" runat="server" ForeColor="Blue" 
                            meta:resourcekey="lblRoleDescResource1"/>
                    </td>
                 </tr>
                 <tr>
                     <td><asp:Label ID ="lblOtherRole" runat ="server" 
                             meta:resourcekey="lblOtherRoleResource1" /></td>
                     <td>
                         <asp:DropDownList ID="ddlOtherRole" runat="server" 
                             meta:resourcekey="ddlOtherRoleResource1"/>
                     </td>
                 </tr>
              </table>
           </fieldset>
        </td>
    </tr>
 </table>
  <br /><br />
  <asp:NewButton ID="btnEnsure" runat="server" Width="80px"    Text ="<%$ Resources:globalResource,EnsureText %>"
         Action ="RoleActionMappingCopy" OnClientClick="return verify()"  onclick="btnEnsure_Click"/>
  &nbsp;&nbsp;
  <asp:NewButton ID="btnCancel" runat="server"  Width="80px" Text ="<%$ Resources:globalResource,CancelText %>"
         OnClientClick ="return goBack()" />
</center>
</asp:Content>
