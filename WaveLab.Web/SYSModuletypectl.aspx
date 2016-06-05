<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSModuletypectl.aspx.cs" Inherits="WaveLab.Web.SYSModuleTypectl" Title="无标题页"  meta:resourcekey="PageResource1"  %>
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
            url="SYSModuleTypeNew.aspx?backlink="+$("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url="SYSModuleTypeEdit.aspx?ModuleTypeId="+value+"&backlink="+$("#<%=hfdCurLink.ClientID %>").val();;
            break ;
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
       <td >
        <table width="100%"  cellpadding ="0" cellspacing ="0" >
            <tr>
                <td>
                    <table  width ="100%" border ="0">
                        <tr>
                            <td>
                               <asp:Label ID="lblSYSModuleType" runat="server" meta:resourcekey="lblSYSModuleTypeResource1" />
                            </td>
                            <td>
                                <asp:TextBox ID="tbxSYSModuleType" runat="server" MaxLength="50" 
                                    meta:resourcekey="tbxSYSModuleTypeResource1" />
                            </td>
                            <td>
                               <asp:Label ID="lblModuleTypeDesc" runat="server" 
                                    meta:resourcekey="lblModuleTypeDescResource1" />
                            </td>
                            <td>
                                <asp:TextBox ID="tbxModuleTypeDesc" runat="server" MaxLength="50" 
                                    meta:resourcekey="tbxModuleTypeDescResource1" />
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
                meta:resourcekey="GVListResource1" onrowdatabound="GVList_RowDataBound"
                 onsorting="GVList_Sorting"  >
              <Columns>
                 <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="module_type_id">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtEdit" runat ="server"  />
                    </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField   DataField="ModuleTypeDesc" SortExpression ="module_type_desc"
                      meta:resourcekey="BoundFieldResource1"/>
                 <asp:BoundField   DataField="HasGenBoard" SortExpression ="hasgenboard"
                      meta:resourcekey="BoundFieldResource2"/>
                 <asp:BoundField  DataField="hasSpeBoard"  SortExpression ="hasspeboard"
                      meta:resourcekey="BoundFieldResource3"/>
                 <asp:BoundField   DataField="HasSMTFabrication" SortExpression ="hassmtfabrication"
                      meta:resourcekey="BoundFieldResource4"/>
                 <asp:BoundField  DataField="HasComponentPart"  SortExpression ="hascomponentpart"
                      meta:resourcekey="BoundFieldResource5"/>
                 <asp:BoundField   DataField="HasGroupPart" SortExpression ="hasgrouppart"
                      meta:resourcekey="BoundFieldResource6"/>
                 <asp:BoundField  DataField="HasBondingFabrication"  SortExpression ="hasbondingfabrication"
                      meta:resourcekey="BoundFieldResource7"/>
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
