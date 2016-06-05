<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTDocumentCtl.aspx.cs" Inherits="WaveLab.Web.SMTDocumentCtl" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function redirect(mode,value)
{
    var url;
    switch (mode)
    {
        case "EXPORT":
             url="SMTDocumentImport.aspx";
            break;
        default:
            break;
    }
   self.location.href=url;
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
            <table width ="100%">
                <tr>
                    <td>
                       <asp:Label ID="lblDocumentNo" runat="server" meta:resourcekey="lblDocumentNoResource1" />
                    </td>
                    <td>
                        <asp:TextBox ID="tbxDocumentNo" runat="server" MaxLength="50" 
                            meta:resourcekey="tbxDocumentNoResource1" />
                    </td>
                    <td>
                       <asp:Label ID="lblVersion" runat="server" meta:resourcekey="lblVersionResource1" />
                    </td>
                    <td>
                        <asp:TextBox ID="tbxVersion" runat="server" MaxLength="2" 
                            meta:resourcekey="tbxVersionResource1" Width="61px" />
                    </td>
                </tr>
            </table>
           </td>
           <td align ="right">
                <asp:NewButton ID="btnSearch" runat="server"    Width ="60px" 
                    meta:resourcekey="btnSearchResource1" onclick="btnSearch_Click"/>&nbsp;
                <asp:NewButton ID="btnExport" runat="server"  Width ="60px"  
                    meta:resourcekey="btnExportResource1"  OnClientClick ="return redirect('EXPORT')"/>&nbsp;
             <%--   <asp:NewButton ID="btnUpdateCPDVS" runat="server" cl-table  Width ="120"
                      meta:resourcekey="btnUpdateCPDVSResource1" 
                    onclick="btnUpdateCPDVS_Click"/>--%>
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
                     meta:resourcekey="GVListResource1" onrowdatabound="GVList_RowDataBound"
                     onsorting="GVList_Sorting"  >
                  <Columns>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="documentno">
                        <ItemTemplate>
                             <%#Eval("documentno")%>
                        </ItemTemplate>
                     </asp:TemplateField>
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource2" ItemStyle-Width ="300">
                            <ItemTemplate>
                                 <asp:Label ID="lblVersion" runat="server" />
                        </ItemTemplate>
                     </asp:TemplateField>
                     
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
    </table>
</center>
</asp:Content>
