<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTCPReportCtl.aspx.cs" Inherits="WaveLab.Web.SMTCPReportCtl" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var rbtEnable=$("#<%=rbtEnable.ClientID %>");
    var confirmMsg;
    if(rbtEnable.attr("checked")==true)
    {
        confirmMsg =$("#<%=lblEnableMsg.ClientID %>").attr("title");
    }
    else
    {
        confirmMsg =$("#<%=lblProhibitMsg.ClientID %>").attr("title");
    }
    return confirm(confirmMsg);
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<br /><br /><br />
<center>
<asp:Label ID="lblTitle" runat="server" SkinID ="skinCTitle" 
            meta:resourcekey="lblTitleResource1"></asp:Label><br/><br/>
<table style="text-align:left; height :60px ;width:140px" border ="0" cellpadding="0" cellspacing ="0" >
    <tr>
        <td>
            <asp:Label ID="lblEnable" runat ="server" 
                meta:resourcekey="lblEnableResource1" />
        </td>
        <td>
            <asp:RadioButton ID ="rbtEnable" runat ="server"  GroupName ="RB"
                meta:resourcekey="rbtEnableResource1" />
        </td>
        <td>
            <asp:Label ID ="lblProhibit" runat ="server" 
                meta:resourcekey="lblProhibitResource1" />
        </td>
        <td>
            <asp:RadioButton ID="rbtProhibit" runat ="server" GroupName ="RB"
                meta:resourcekey="rbtProhibitResource1" />
        </td>
    </tr>
    <tr>
        <td colspan ="2">
            <asp:Label ID="lblEnableMsg" runat ="server" 
                meta:resourcekey="lblEnableMsgResource1" />
            <asp:Label ID="lblProhibitMsg" runat ="server" 
                meta:resourcekey="lblProhibitMsgResource1" />
        </td>
    </tr>
</table>
<br />
<asp:NewButton ID="btnSave" runat="server"  cl-table  OnClientClick ="return verify()"
         meta:resourcekey="btnSaveResource1"  
        Width ="80" onclick="btnSave_Click"/>
&nbsp;
<asp:NewButton ID="btnReset" runat ="server" cl-table  OnClientClick ="return formReset()"
        meta:resourcekey="btnResetResource1"  
        Width ="80"/>
    
</center>
</asp:Content>
