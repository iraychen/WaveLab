<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSRoleCtl.aspx.cs" Inherits="WaveLab.Web.SYSRoleCtl" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready(function(){
   $("input:submit").button();
   $("#result tr:even").css("background-color","#FFFFFF");
   $("#result tr:odd").css("background-color","#E6E6E6");
});
function makeWindow(mode,value)
{
    var url;
    switch(mode)
    {
        case "NEW":
            url = "SYSRoleNew.aspx?backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url = "SYSRoleEdit.aspx?roleid=" + value + "&backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break ;
        case "AC":
            url = "SYSRoleAC.aspx?roleid=" + value;
            break;
        case "ACTION":
            url = "SYSRoleActionAC.aspx?roleid=" + value;
            break;
        default:
            break;
    }
    var winparas="toolbar=0,status=0,scrollbars=1,resizable=0,width=700px,Height=500px";
    var win=window.open(url,"secwin",winparas);
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<table >
	<tr>
		<td><asp:Image ID ="imgTitle" runat="server" SkinID ="ImgskinTitle" 
			meta:resourcekey="imgTitleResource1" /></td>
		<td valign="bottom"><asp:Label ID ="lblTitle" runat="server"  SkinID ="skinTitle" 
			meta:resourcekey="lblTitleResource1" /></td>
	</tr>
</table>
<center>
<table width ="800" style="text-align:left" border ="0" cellpadding="0" cellspacing ="0">
        <tr>
            <td align="right">
                <asp:NewButton ID="btnNew" runat="server"  Width ="60px"   Action ="RoleNew"
                                meta:resourcekey="btnNewResource1" OnClientClick ="return makeWindow('NEW','')" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblRecCount" runat="server" meta:resourcekey="lblRecCountResource1" /></td>
        </tr>
        <tr>
            <td>
               <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                            AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"    
                            meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" onrowdatabound="GVList_RowDataBound"   >
                  <Columns>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="role_desc">
                        <ItemTemplate>
                           <asp:LinkButton ID="lbtRole" runat ="server"  Text ='<%#Eval("RoleDesc") %>'/>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource2" >
                        <ItemTemplate>
                           <asp:LinkButton ID="lbtAC" runat ="server" meta:resourcekey="lbtACResource1" />
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource3" >
                        <ItemTemplate>
                           <asp:LinkButton ID="lbtActionAC" runat ="server" meta:resourcekey="lbtActionACResource1" />
                        </ItemTemplate>
                     </asp:TemplateField>
                  </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style ="padding-top:10px">
                <webdiyer:AspNetPager ID="PagerNavigator" runat="server" 
                    onpagechanged="PagerNavigator_PageChanged"/>
            </td>
        </tr>
         <tr>
            <td>
                <asp:HiddenField ID="hfdCurLink" runat="server" /> 
            </td>
        </tr>
    </table>
</center>
</asp:Content>
