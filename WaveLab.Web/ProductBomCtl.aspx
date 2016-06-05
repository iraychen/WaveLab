<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ProductBomCtl.aspx.cs" Inherits="WaveLab.Web.ProductBomCtl" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
            url="ProductBomNew.aspx?backlink="+$("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url="ProductBomEdit.aspx?productbomtid="+value+"&backlink="+$("#<%=hfdCurLink.ClientID %>").val();
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
<table width ="99%" style="text-align:left" border ="0" cellpadding="0" cellspacing ="0">
        <tr>
           <td colspan ="2">
                <fieldset>
                <table width="100%">
                    <tr>
                        <td>
                            <table border ="0" cellpadding ="0" cellspacing ="2"  width ="100%">
                                <tr>
                                    <td>
                                        <asp:Label ID ="lblProduct" runat ="server" 
                                            meta:resourcekey="lblProductResource1" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProduct" runat ="server" 
                                            meta:resourcekey="ddlProductResource1" />
                                    </td>
                                    <td>
                                       <asp:Label ID="lblMaterialType" runat="server" 
                                            meta:resourcekey="lblMaterialTypeResource1" />
                                    </td>
                                    <td>
                                          <asp:DropDownList ID="ddlMaterialType" runat ="server" 
                                            meta:resourcekey="ddlMaterialTypeResource1" />
                                    </td>
                                  
                                 </tr>
                                <tr>
                                    <td>
                                       <asp:Label ID="lblMaterialCode" runat="server" 
                                            meta:resourcekey="lblMaterialCodeResource1" />
                                    </td>
                                    <td>
                                       <asp:TextBox ID="tbxMaterialCode" runat ="server" MaxLength ="50" 
                                            meta:resourcekey="tbxMaterialCodeResource1" />
                                    </td>
                                     <td>
                                       <asp:Label ID="lblMaterialDesc" runat="server" 
                                            meta:resourcekey="lblMaterialDescResource1" />
                                    </td>
                                   
                                    <td>
                                        <asp:TextBox ID="tbxMaterialDesc" runat="server" MaxLength="50" 
                                            meta:resourcekey="tbxMaterialDescResource1" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        <asp:Label ID="lblSYSModuleType" runat="server" 
                                            meta:resourcekey="lblSYSModuleTypeResource1" />
                                    </td>
                                    <td colspan ="3">
                                          <asp:DropDownList ID="ddlSYSModuleType" runat ="server" 
                                            meta:resourcekey="ddlSYSModuleTypeResource1" />
                                    </td>
                                 </tr>
                            </table>
                        </td>
                        <td  align ="right">
                             <asp:NewButton ID="btnSearch" runat="server"  Width ="60px" Text ="<%$ Resources:globalResource,SearchText %>" 
                                        onclick="btnSearch_Click"/>&nbsp;
                                 
                             <asp:NewButton ID="btnNew" runat="server"  Width ="60px"  Text ="<%$ Resources:globalResource,NewText %>" 
                                OnClientClick ="return makeWindow('NEW','')" />
                        </td>
                    </tr>
                </table>
                </fieldset>
           </td>
        </tr>
        <tr>
            <td align ="center" colspan ="2"><asp:Label ID="lblRecCount" runat="server" 
                    meta:resourcekey="lblRecCountResource1" /></td>
        </tr>
        <tr>
            <td colspan ="2">
                <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                    AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"
                    meta:resourcekey="GVListResource1" onsorting="GVList_Sorting">
                  <Columns>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  ItemStyle-Width ="30">
                        <ItemTemplate>
                            <a href="javascipt:void(0)" 
                                onclick='return makeWindow("EDIT","<%# Eval("ProductBomId") %>")'>
                                <asp:Label ID ="lblEdit" runat ="server" 
                                meta:resourcekey="lblEditResource1" />
                            </a>
                        </ItemTemplate>
                     </asp:TemplateField>
                      <asp:TemplateField  meta:resourcekey="TemplateFieldResource2" SortExpression ="product_desc">
                        <ItemTemplate >
                           <%# Eval("ProductItem.ProductDesc") %>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField  DataField ="MaterialCode"  SortExpression ="material_code"
                          meta:resourcekey="BoundFieldResource1" >
                      </asp:BoundField>
                     <asp:TemplateField  meta:resourcekey="TemplateFieldResource3" ItemStyle-Width ="50" SortExpression ="material_type_desc">
                        <ItemTemplate >
                           <%# Eval("MaterialTypeItem.MaterialTypeDesc") %>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField  DataField ="MaterialDesc" SortExpression ="material_code"   HtmlEncode="false"
                          meta:resourcekey="BoundFieldResource2" />
                     <asp:BoundField  DataField ="SupplierName" meta:resourcekey="BoundFieldResource3" SortExpression ="supplier_name" />
                     <asp:BoundField  DataField ="Amount" SortExpression ="amount" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign ="Right"
                          meta:resourcekey="BoundFieldResource4" />
                     <asp:TemplateField  meta:resourcekey="TemplateFieldResource4" ItemStyle-Width ="50" SortExpression ="module_type_desc">
                        <ItemTemplate>
                           <%# Eval("ModuleTypeItem.ModuleTypeDesc") %>
                        </ItemTemplate>
                      </asp:TemplateField>
                     <asp:BoundField  DataField ="Comment" SortExpression ="comment"
                          meta:resourcekey="BoundFieldResource5" />
                  </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan ="2" style ="padding-top:10px">
                <webdiyer:AspNetPager ID="PagerNavigator" runat="server" 
                    onpagechanged="PagerNavigator_PageChanged" />
            </td>
        </tr>
         <tr>
            <td colspan ="2">
                <asp:HiddenField ID="hfdCurLink" runat="server" /> 
            </td>
        </tr>
    </table>
</center>
</asp:Content>