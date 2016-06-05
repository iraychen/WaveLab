<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCParametersImport.aspx.cs" Inherits="WaveLab.Web.SPCParametersImport" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function upload()
{
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
function goBack() {
    self.location.href = "SPCParametersCtl.aspx";
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<asp:ImageButton ID="imgBtnBack" runat ="server" SkinID ="imgBtnSkinBack"  
         OnClientClick ="return goBack()" meta:resourcekey="imgBtnBackResource1"/>
<center>
<table width ="100%" style="text-align:left" >
    <tr>
    <td colspan ="2" align="center">
    <asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" 
     meta:resourcekey="lblTitleResource1" />
    </td>
</tr>
    <tr >
    <td></td>
        <td align ="right" >
            <asp:LinkButton ID="lbtDocument" runat ="server" Font-Bold ="True"  Font-Size ="13px"
                            meta:resourcekey="lbtDocumentResource1" onclick="lbtDocument_Click"  />
        </td>
    </tr>
    <tr>
        <td align ="right"  style ="width :70%">
            <table style="text-align:left">
                <tr>
                    <td><asp:Label ID="lblDocument" runat="server" 
                            meta:resourcekey="lblDocumentResource1" />:</td>
                    <td>
                        <asp:FileUpload ID="fileUploader" runat="server"  Width ="300px"
                            meta:resourcekey="fileUploaderResource1"   />
                    </td>
                    <td>
                        <asp:NewButton ID="btnUpload" runat="server"  Width ="80px"  OnClientClick ="return upload()"
                            meta:resourcekey="btnUploadResource1" onclick="btnUpload_Click" />
                        <asp:Label ID="lblUploadValueMsg" runat="server" 
                            ToolTip="<%$ Resources:globalResource,uploadValueMsg %>" 
                            meta:resourcekey="lblUploadValueMsgResource1" />
                        <asp:Label ID="lblFileTypeMsg" runat="server" 
                            ToolTip="<%$ Resources:globalResource,excelFileTypeMsg %>" 
                            meta:resourcekey="lblFileTypeMsgResource1" />
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
                <tr><td><asp:Label ID ="lblFormatTip" runat="server" ForeColor ="Orange"  meta:resourcekey="lblFormatTipResource1" /></td></tr>
            </table>
        </td>
    </tr>
    <tr>
        <td  colspan ="2">
            <asp:Label ID="lblRecCount" runat="server" 
                meta:resourcekey="lblRecCountResource1" />&nbsp;&nbsp;
            <asp:Label ID="lblErrorCount" runat="server"  ForeColor ="Orange" 
                meta:resourcekey="lblErrorCountResource1"/>
        </td>
    </tr>
    <tr>
        <td  colspan ="2">
            <asp:GridView ID="GVList" runat="server"   GridLines ="None" CssClass="import-gridview"
                AutoGenerateColumns="False"  Width ="100%" CellPadding ="2" CellSpacing ="1" 
                meta:resourcekey="GVListResource1" onrowdatabound="GVList_RowDataBound" >
                  <Columns>
                      <asp:BoundField  DataField ="N"   meta:resourcekey="BoundFieldResource1" />
                      <asp:BoundField  DataField ="A2"   meta:resourcekey="BoundFieldResource2" />
                      <asp:BoundField  DataField ="D2"   meta:resourcekey="BoundFieldResource3" />
                      <asp:BoundField  DataField ="D3"   meta:resourcekey="BoundFieldResource4" />
                      <asp:BoundField  DataField ="D4"   meta:resourcekey="BoundFieldResource5" />
                      <asp:BoundField  DataField ="A3"   meta:resourcekey="BoundFieldResource6" />
                      <asp:BoundField  DataField ="C4"   meta:resourcekey="BoundFieldResource7" />
                      <asp:BoundField  DataField ="B3"   meta:resourcekey="BoundFieldResource8" />
                      <asp:BoundField  DataField ="B4"   meta:resourcekey="BoundFieldResource9" />
                  </Columns>
                 <RowStyle BackColor ="White" />
                 <AlternatingRowStyle BackColor ="White" />
            </asp:GridView>
        </td>
    </tr>
  
</table>
</center>
</asp:Content>
