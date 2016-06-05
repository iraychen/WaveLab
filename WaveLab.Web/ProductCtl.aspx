<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ProductCtl.aspx.cs" Inherits="WaveLab.Web.ProductCtl" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function redirect(mode,value)
{
    var url;
    switch(mode)
    {
        case "NEW":
            url="ProductNew.aspx";
            break;
        case "EDIT":
            url="ProductEdit.aspx?productid="+value;
            break ;
        case "AUDIT":
            url="ProductAudit.aspx?productid="+value;
            break ;
        default:
            break;
    }
    self.location.href=url;
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
                   <td align ="right">
                      <asp:NewButton ID="btnNew" runat="server"  Width ="60px"  ButtonType ="new"
                                    meta:resourcekey="btnNewResource1" OnClientClick ="return redirect('NEW','')" />
                     
                   </td>
                </tr>
                <tr>
                    <td align ="center" ><asp:Label ID="lblRecCount" runat="server" 
                            meta:resourcekey="lblRecCountResource1" /></td>
                </tr>
                <tr>
                    <td >
                        <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                            AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"    
                            meta:resourcekey="GVListResource1" onsorting="GVList_Sorting"   onrowdatabound="GVList_RowDataBound">
                          <Columns>
                             <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="product_desc" HeaderStyle-Width ="400">
                                <ItemTemplate>
                                    <a href="javascipt:void(0)" 
                                        onclick='return redirect("EDIT","<%# Eval("ProductId")%>")'>
                                      <%# Eval("ProductDesc") %>
                                    </a>
                                </ItemTemplate>
                             </asp:TemplateField>
                             
                             <asp:BoundField  SortExpression ="audited" DataField="Audited" 
                                  meta:resourcekey="BoundFieldResource1"/>
                             <asp:TemplateField meta:resourcekey="TemplateFieldResource2"  ItemStyle-Width ="50">
                                <ItemTemplate>
                                    <asp:LinkButton ID ="lbtAudit" runat ="server"   meta:resourcekey="lbtAuditResource1" />
                                </ItemTemplate>
                              </asp:TemplateField>
                           </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
