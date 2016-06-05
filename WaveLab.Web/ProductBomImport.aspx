<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ProductBomImport.aspx.cs" Inherits="WaveLab.Web.ProductBomImport" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script  type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function upload()
{
    var product=$("#<%=ddlProduct.ClientID %>");
    if(product.val()==null)
    {
        alert($("#<%=lblProductMsg.ClientID %>").attr("title"));;
        return false;
    }
    var uploader=$("#<%=fileUploader.ClientID%>");
    if(uploader.val().length==0)
    {
        alert($("#<%=lblUploadValueMsg.ClientID %>").attr("title"));;
        return false;
    }
    var fileString=uploader.val();
    var index=fileString.lastIndexOf(".")
    if(fileString.substr(index+1).toUpperCase()!="XLS")
    {
        alert($("#<%=lblFileTypeMsg.ClientID %>").attr("title"));;
        return false;
    }
    return true;
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
<table width ="98%" style="text-align:left" >
    <tr >
        <td align ="right" colspan="2">
            <table>
                <tr>
                    <td align ="left">
                        <asp:LinkButton ID="lbtTemplateDownLoad" runat ="server"  Font-Bold ="true" Font-Size ="13px"
                            meta:resourcekey="lbtTemplateDownLoadResource1" onclick="lbtTemplateDownLoad_Click"  />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align ="right"  style ="width :70%">
            <table style="text-align:left">
                <tr>
                    <td><asp:Label ID="lblProduct" runat="server" 
                            meta:resourcekey="lblProductResource1" /></td>
                    <td colspan ="2">
                        <asp:DropDownList ID="ddlProduct" runat="server"  
                            meta:resourcekey="ddlProductResource1" />
                       <asp:Label ID="lblProductMsg" runat="server" 
                            meta:resourcekey="lblProductMsgResource1" />  
                    </td>
                    
                </tr>
                <tr>
                    <td><asp:Label ID="lblDocument" runat="server" 
                            meta:resourcekey="lblDocumentResource1" /></td>
                    <td>
                        <asp:FileUpload ID="fileUploader" runat="server"  Width ="300px"
                            meta:resourcekey="fileUploaderResource1"   />
                    </td>
                    <td>
                        <asp:NewButton ID="btnUpload" runat="server"  Width ="80px"  OnClientClick ="return upload()"
                            meta:resourcekey="btnUploadResource1" onclick="btnUpload_Click" />
                        <asp:Label ID="lblUploadValueMsg" runat="server" 
                            ToolTip="<%$ Resources:globalResource,uploadValueMsg %>"  />
                        <asp:Label ID="lblFileTypeMsg" runat="server" 
                            ToolTip="<%$ Resources:globalResource,excelFileTypeMsg %>"/>
                    </td>
                    <td>
                        <asp:NewButton ID="btnImport" runat="server" Width ="80px"  Visible ="False"
                            meta:resourcekey="btnImportResource1" onclick="btnImport_Click"/>
                    </td>
                    
                </tr>
            </table>
        </td>
        <td rowspan ="2" align ="right">
            <table style="text-align:left">
               <%-- <tr><td><asp:Label ID ="lblExistsTip" runat="server" ForeColor ="DarkOrange"  meta:resourcekey="lblExistsTipResource1" /></td></tr>--%>
                <tr><td><asp:Label ID ="lblFormatTip" runat="server" ForeColor ="Gray"  meta:resourcekey="lblFormatTipResource1" /></td></tr>
                <tr><td><asp:Label ID ="lblTypeErrorTip" runat="server" ForeColor ="Red"  meta:resourcekey="lblTypeErrorTipResource1" /></td></tr>
            </table>
        </td>
    </tr>
    <tr>
        <td  colspan ="2">
            <asp:Label ID="lblRecCount" runat="server" 
                meta:resourcekey="lblRecCountResource1" />&nbsp;&nbsp;
           <%-- <asp:Label ID="lblExistsCount" runat="server"  ForeColor ="Orange" 
                meta:resourcekey="lblExistsCountResource1"/>&nbsp;&nbsp;--%>
            <asp:Label ID="lblErrorCount" runat="server"  ForeColor ="Red" 
                meta:resourcekey="lblErrorCountResource1"/>
        </td>
    </tr>
    <tr>
        <td  colspan ="2">
            <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   SkinID ="null" GridLines ="none" CssClass="import-gridview"
                    AutoGenerateColumns="False"  Width ="100%" CellPadding ="2" CellSpacing ="1"
                meta:resourcekey="GVListResource1" onrowdatabound="GVList_RowDataBound"  >
                  <Columns>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
                        <ItemTemplate>
                            <asp:Label ID="lblProductDesc" Text='<%#Eval("ProductDesc") %>'  runat ="server"/>
                            <asp:HiddenField ID="hfdIsPass" runat="server" />
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField  DataField ="MaterialCode"  meta:resourcekey="BoundFieldResource1" />
                     <asp:BoundField  DataField ="MaterialTypeDesc"   meta:resourcekey="BoundFieldResource2" />
                     <asp:BoundField  DataField ="MaterialDesc"   meta:resourcekey="BoundFieldResource3" HtmlEncode ="false"/>
                     <asp:BoundField  DataField ="SupplierName" meta:resourcekey="BoundFieldResource4" />
                     <asp:BoundField  DataField ="Amount"   meta:resourcekey="BoundFieldResource5"  HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign ="Right"/>
                     <asp:BoundField  DataField ="ModuleTypeDesc"  meta:resourcekey="BoundFieldResource6" />
                     <asp:BoundField  DataField ="Comment"  meta:resourcekey="BoundFieldResource7" />
                  </Columns>
              
            </asp:GridView>
        </td>
    </tr>
  
</table>
</center>
</asp:Content>
