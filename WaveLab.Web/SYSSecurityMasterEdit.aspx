<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSSecurityMasterEdit.aspx.cs" Inherits="WaveLab.Web.SYSSecurityMasterEdit" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var admin=$("#<%=ddlAdmin.ClientID %>");
    if(admin.val().length==0)
    {
      alert($("#<%=lblAdminMsg.ClientID %>").attr("title"));
      admin.focus();
      return false;
    }
    
    var active=$("#<%=ddlActive.ClientID %>");
    if(active.val().length==0)
    {
      alert($("#<%=lblActiveMsg.ClientID %>").attr("title"));
      active.focus();
      return false;
    }
    
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
<table width="100%" style ="text-align:left" >
    <tr>
        <td>
            <fieldset>
                 <table width ="100%" class="form-table" cellpadding="5">
                    <tr>
                        <td>
                           <asp:Label ID="lblUser" runat="server" meta:resourcekey="lblUserIdResource1"  ForeColor="Red"/>
                        </td>
                        <td>
                            <asp:Label ID="lblUserId" runat="server" ForeColor ="Blue" 
                                meta:resourcekey="lblUserIdResource2" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <asp:Label ID="lblUserName" runat="server" 
                                meta:resourcekey="lblUserNameResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxUserName" runat="server" MaxLength="50"  Width ="300"
                                meta:resourcekey="tbxUserNameResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID ="lblAdmin" runat="server" meta:resourcekey="lblAdminResource1" ForeColor="Red"/>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAdmin" runat="server" Width ="80"
                                meta:resourcekey="ddlAdminResource1" />
                            <asp:Label ID="lblAdminMsg" runat="server" meta:resourcekey="lblAdminMsgResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID ="lblActive" runat="server" ForeColor="Red"
                                meta:resourcekey="lblActiveResource1" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlActive" runat="server" Width ="80"
                                meta:resourcekey="ddlActiveResource1" />
                             <asp:Label ID="lblActiveMsg" runat="server" meta:resourcekey="lblActiveMsgResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSection" runat="server" 
                                meta:resourcekey="lblSectionResource1" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSection" runat="server" 
                                meta:resourcekey="ddlSectionResource1" />
                        </td>
                    </tr>
                </table>
           </fieldset>
        </td>
    </tr>
    <tr>
        <td align ="right">
           <br />
           <asp:NewButton  ID="btnSave" runat="server"    Width ="80" Text ="<%$ Resources:globalResource,SaveText %>"
                Action ="SecurityMasterEdit" OnClientClick="return verify()" onclick="btnSave_Click"/>
            &nbsp;
            <asp:NewButton ID="btnResetPwd" runat="server"  Width ="80" 
                Action ="SecurityMasterResetPwd" meta:resourcekey="btnResetPwdResource1" onclick="btnResetPwd_Click" />
            &nbsp;
            <asp:NewButton ID="btnCancel" runat ="server"   Width ="80" Text ="<%$ Resources:globalResource,CancelText %>"
                OnClientClick="return cancel()" />
        </td>
    </tr>
  </table>
</center>
</asp:Content>
