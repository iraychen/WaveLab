<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RptSMTFileInduce.aspx.cs" Inherits="WaveLab.Web.RptSMTFileInduce" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var materialcode=$("#<%=tbxMaterialCode.ClientID %>");
    var pcb=$("#<%=tbxPCB.ClientID %>");
    if(trim(materialcode.val()).length==0)
    {
      alert($("#<%=lblMaterialCodeMsg.ClientID %>").attr("title"));
      materialcode.focus();
      return false;
    } 
    if(trim(pcb.val()).length==false)
    {
      alert($("#<%=lblPCBMsg.ClientID %>").attr("title"));
      pcb.focus();
      return false;
    }
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<br /><br />
<center>
    <asp:Label ID="lblTitle" runat="server" SkinId="skinRptTitle"
        meta:resourcekey="lblTitleResource1"></asp:Label><br/><br/>
    <table  style ="text-align:left" cellSpacing="0" cellPadding="20" border="1" width ="400">
        <tr>
            <td>
                <table class ="report-table" width="100%"  >
                    <tr>
                         <td>
                           <asp:Label ID="lblSYSModuleType" runat="server" 
                                meta:resourcekey="lblSYSModuleTypeResource1" />
                        </td>
                        <td>
                            <asp:DropDownList ID ="ddlSYSModuleType" runat="server" 
                                meta:resourcekey="ddlSYSModuleTypeResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <asp:Label ID="lblMaterialCode" runat="server" ForeColor ="Red"
                                meta:resourcekey="lblMaterialCodeResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxMaterialCode" runat="server" MaxLength="13" Width="200px"
                                meta:resourcekey="tbxMaterialCodeResource1" />
                             <asp:Label ID ="lblMaterialCodeMsg" runat ="server" 
                                meta:resourcekey="lblMaterialCodeMsgResource1" />
                        </td>
                    </tr>
                    <tr>
                         <td>
                           <asp:Label ID="lblMaterialDesc" runat="server" 
                                meta:resourcekey="lblMaterialDescResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxMaterialDesc" runat="server" MaxLength="40" 
                                meta:resourcekey="tbxMaterialDescResource1" Width="200px" />
                            <asp:Label ID ="lblMaterialDescMsg" runat ="server" 
                                meta:resourcekey="lblMaterialDescMsgResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <asp:Label ID="lblPCB" runat="server"  ForeColor ="Red"
                                meta:resourcekey="lblPCBResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxPCB" runat="server" MaxLength="40" 
                                meta:resourcekey="tbxPCBResource1" Width="200px"  />
                            <asp:Label ID ="lblPCBMsg" runat ="server" 
                                meta:resourcekey="lblPCBMsgResource1" />
                        </td>
                    </tr>
                  
                </table>
            </td>
        </tr>
    </table>
    <br/>
    <asp:NewButton id="btnSubmit" Runat="server" Width="100px"  
        OnClientClick ="return verify()" meta:resourcekey="btnSubmitResource1" 
        onclick="btnSubmit_Click"/>&nbsp;
    <asp:NewButton ID="btnReset" runat="server" Width ="100px" 
        OnClientClick ="return formReset()" meta:resourcekey="btnResetResource1"/>
</center>

</asp:Content>
