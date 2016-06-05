<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSSecurityMasterCtl.aspx.cs" Inherits="WaveLab.Web.SYSsecurityMasterCtl" Title="无标题页"  meta:resourcekey="PageResource1"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

    <script type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function makeWindow(mode,value)
{
    var url;
    switch(mode)
    {
        case "NEW":
            url = "SYSSecurityMasterNew.aspx?backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url = "SYSSecurityMasterEdit.aspx?userid=" + value + "&backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break ;
        case "RA":
            url = "SYSSecurityMasterRoleMapping.aspx?userid=" + value;
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
           <td>
            <fieldset>
            <table width="100%" cellpadding ="0" cellspacing ="0" >
                <tr>
                    <td>
                        <table border ="0"  width ="100%">
                            <tr>
                                <td>
                                   <asp:Label ID="lblUserId" runat="server" meta:resourcekey="lblUserIdResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxUserId" runat="server" MaxLength="50" 
                                        meta:resourcekey="tbxUserIdResource1" />
                                </td>
                                <td>
                                   <asp:Label ID="lblUserName" runat="server" 
                                        meta:resourcekey="lblUserNameResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxUserName" runat="server" MaxLength="50" 
                                        meta:resourcekey="tbxUserNameResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   
                                    <asp:Label ID ="lblAdmin" runat="server" meta:resourcekey="lblAdminResource1" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAdmin" runat="server" Width ="50"
                                        meta:resourcekey="ddlAdminResource1" />
                                </td>
                                <td>
                                    <asp:Label ID ="lblActive" runat="server" 
                                        meta:resourcekey="lblActiveResource1" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlActive" runat="server" Width ="50"
                                        meta:resourcekey="ddlActiveResource1" />
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
                    </td>
                    <td align ="right">
                       <asp:NewButton ID="btnSearch" runat="server"  Width ="60px" Text ="<%$ Resources:globalResource,SearchText %>"  
                           onclick="btnSearch_Click"/>&nbsp;
                       <asp:NewButton ID="btnNew" runat="server"  Width ="60px"  Text ="<%$ Resources:globalResource,NewText %>"  Action ="SecurityMasterNew" 
                           OnClientClick ="return makeWindow('NEW','')" />
                    </td>
                </tr>
            </table>
            </fieldset>
           </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblRecCount" runat="server"/></td>
        </tr>
        <tr>
            <td colspan ="2">
                <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                    AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"
                   DataKeyNames="userId" meta:resourcekey="GVListResource1"
                     onsorting="GVList_Sorting" onrowdatabound="GVList_RowDataBound"   >
                  <Columns>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="user_id">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtEdit" runat ="server" Text ='<%#Eval("UserId")%>'/>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField   DataField="userName" SortExpression ="user_name"
                          meta:resourcekey="BoundFieldResource2"/>
                     <asp:BoundField  SortExpression ="admin" DataField="admin" 
                      meta:resourcekey="BoundFieldResource3"/>
                      <asp:BoundField  SortExpression ="active" DataField="active" 
                      meta:resourcekey="BoundFieldResource4"/>
                      <asp:BoundField  SortExpression ="section_id"  
                      meta:resourcekey="BoundFieldResource5"/>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource2" >
                        <ItemTemplate>
                            <asp:LinkButton ID ="lbtRA" runat ="server" meta:resourcekey="lbtRAResource1" ></asp:LinkButton>
                        </ItemTemplate>
                     </asp:TemplateField>
                  </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style ="padding-top:10px">
                <webdiyer:AspNetPager ID="PagerNavigator" runat="server" 
                    onpagechanged="PagerNavigator_PageChanged" />
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
