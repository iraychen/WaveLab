<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="InjurantTypeCtl.aspx.cs" Inherits="WaveLab.Web.InjurantTypeCtl" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
            url="InjurantTypeNew.aspx?backlink="+$("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url="InjurantTypeEdit.aspx?injuranttypeid="+value+"&backlink="+$("#<%=hfdCurLink.ClientID %>").val();;
            break ;
        default:
            break;
    }
    var winparas="toolbar=0,status=0,scrollbars=1,resizable=0,width=600px,Height=400px";
    var win=window.open(url,"secwin",winparas);
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<table style ="width:100%">
    <tr>
        <td>
            <table>
                <tr>
	                <td><asp:Image ID ="imgTitle" runat="server" SkinID ="ImgskinTitle" 
		                meta:resourcekey="imgTitleResource1" /></td>
	                <td valign="bottom"><asp:Label ID ="lblTitle" runat="server"  SkinID ="skinTitle" 
		                meta:resourcekey="lblTitleResource1" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align ="center">
            <table width ="600" style="text-align:left" border ="0" cellpadding="0" cellspacing ="0">
                <tr>
                    <td>
                      <table width="100%">
                        <tr>
                            <td>
                                <table border ="0" cellpadding ="0" cellspacing ="0"  width ="100%">
                                    <tr>
                                        <td>
                                           <asp:Label ID="lblInjurantTypeDesc" runat="server" 
                                                meta:resourcekey="lblInjurantTypeDescResource1" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxInjurantTypeDesc" runat="server" MaxLength="50" 
                                                meta:resourcekey="tbxInjurantTypeDescResource1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign ="bottom" align ="right">
                                <asp:NewButton ID="btnSearch" runat="server"  Width ="60px" Text ="<%$ Resources:globalResource,SearchText %>" 
                                    onclick="btnSearch_Click"/>&nbsp;
                             
                                <asp:NewButton ID="btnNew" runat="server"  Width ="60px"  Text ="<%$ Resources:globalResource,NewText %>" 
                                    OnClientClick ="return makeWindow('NEW','')" />
                            </td>
                           </tr>
                       </table>
                   </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblRecCount" runat="server" 
                            meta:resourcekey="lblRecCountResource1" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                            AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"    
                            meta:resourcekey="GVListResource1" onsorting="GVList_Sorting"  >
                          <Columns>
                             <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="injurant_type_desc">
                                <ItemTemplate>
                                    <a href="javascipt:void(0)" 
                                        onclick='return makeWindow("EDIT","<%# Eval("InjurantTypeId") %>")'>
                                      <%# Eval("InjurantTypeDesc") %>
                                    </a>
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
        </td>
    </tr>
    
</table>
</asp:Content>
