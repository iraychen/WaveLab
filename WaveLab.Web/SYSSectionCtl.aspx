<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSSectionCtl.aspx.cs" Inherits="WaveLab.Web.SYSSectionCtl" Title="无标题页"  meta:resourcekey="PageResource1"  %>
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
            url = "SYSsectionNew.aspx?backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url = "SYSsectionEdit.aspx?sectionid=" + value + "&backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
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
            <td >
               <table width="100%" cellpadding ="0" cellspacing ="0" >
                <tr>
                    <td>
                        <table  width ="100%" border ="0" >
                            <tr>
                                <td>
                                   <asp:Label ID="lblSectionId" runat="server" meta:resourcekey="lblSectionIdResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxSectionId" runat="server" MaxLength="50" 
                                        meta:resourcekey="tbxSectionIdResource1" />
                                </td>
                                <td>
                                   <asp:Label ID="lblSectionDesc" runat="server" 
                                        meta:resourcekey="lblSectionDescResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxSectionDesc" runat="server" MaxLength="50" 
                                        meta:resourcekey="tbxSectionDescResource1" />
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
                    AutoGenerateColumns="False"  Width ="600px" EnableViewState ="false"
                    meta:resourcekey="GVListResource1" 
                     onsorting="GVList_Sorting"  onrowdatabound="GVList_RowDataBound" >
                      <Columns>
                         <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="section_id">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtEdit" runat ="server" Text ='<%#Eval("SectionId")%>'/>
                            </ItemTemplate>
                         </asp:TemplateField>
                         <asp:BoundField   DataField="sectionDesc" SortExpression ="section_desc"
                              meta:resourcekey="BoundFieldResource2"/>
                         
                      </Columns>
                   </asp:GridView>
            </td>
        </tr>
        <tr>
            <td  style ="padding-top:10px">
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
