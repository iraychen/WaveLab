<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTFileInduceImport.aspx.cs" Inherits="WaveLab.Web.SMTFileInduceImport" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script  type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function allCheck()
{
    $.each($("#<%=GVList.ClientID %> :checkbox:gt(0):enabled"),function(){
            $(this).attr("checked", $("#allCheckBox").attr("checked"));
	});
}

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
    self.location.href = '<%=System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) %>';
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<asp:ImageButton ID="imgBtnBack" runat ="server" SkinID ="imgBtnSkinBack"  
         OnClientClick ="return goBack()" meta:resourcekey="imgBtnBackResource1"/>
<%--<table >
	<tr>
		<td><asp:Image ID ="imgTitle" runat="server" SkinID ="ImgskinTitle" 
			meta:resourcekey="imgTitleResource1" /></td>
		<td valign="bottom"><asp:Label ID ="lblTitle" runat="server"  SkinID ="skinTitle" 
			meta:resourcekey="lblTitleResource1" /></td>
	</tr>
</table>--%>
<center>
 <asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" 
     meta:resourcekey="lblTitleResource1" /><br />
<table width ="98%" style="text-align:left" >
    <tr >
        <td></td>
        <td align ="right">
            <asp:LinkButton ID="lbtSample" runat ="server"  Font-Size ="13px" Font-Bold ="true"
                            meta:resourcekey="lbtSampleResource1" onclick="lbtSample_Click"  />
        </td>
    </tr>
    <tr>
        <td align ="right"  style ="width :70%">
            <table style="text-align:left">
                <tr>
                    <td><asp:Label ID="lblSYSModuleType" runat="server" 
                            meta:resourcekey="lblSYSModuleTypeResource1" /></td>
                    <td colspan ="2"><asp:DropDownList ID="ddlSYSModuleType" runat="server"  Width="80"
                            meta:resourcekey="ddlSYSModuleTypeResource1" /></td>
                    
                </tr>
                <tr>
                    <td><asp:Label ID="lblDocument" runat="server" 
                            meta:resourcekey="lblDocumentResource1" /></td>
                    <td>
                        <asp:FileUpload ID="fileUploader" runat="server"  Width ="300"
                            meta:resourcekey="fileUploaderResource1"   />
                    </td>
                    <td>
                        <asp:NewButton ID="btnUpload" runat="server"  Width ="80"  OnClientClick ="return upload()"
                            meta:resourcekey="btnUploadResource1" onclick="btnUpload_Click" />
                        <asp:Label ID="lblUploadValueMsg" runat="server" ToolTip="<%$ Resources:globalResource,uploadValueMsg %>" />
                        <asp:Label ID="lblFileTypeMsg" runat="server" ToolTip="<%$ Resources:globalResource,excelFileTypeMsg %>" />
                    </td>
                    <td>
                        <asp:NewButton ID="btnImport" runat="server" Width ="80"  Visible ="false"
                            meta:resourcekey="btnImportResource1" onclick="btnImport_Click"/>
                    </td>
                    
                </tr>
            </table>
        </td>
        <td rowspan ="2" align ="right">
            <table style="text-align:left">
                <tr><td><asp:Label ID ="lblExistsTip" runat="server" ForeColor ="Orange"  meta:resourcekey="lblExistsTipResource1" /></td></tr>
                <tr><td><asp:Label ID ="lblFormatTip" runat="server" ForeColor ="Gray"  meta:resourcekey="lblFormatTipResource1" /></td></tr>
                <tr><td><asp:Label ID ="lblFormatTipDesc" runat="server" ForeColor ="Gray"  meta:resourcekey="lblFormatTipDescResource1" /></td></tr>
                 <tr><td><asp:Label ID ="lblFormatTipDesc2" runat="server" ForeColor ="Gray"  meta:resourcekey="lblFormatTipDesc2Resource1" /></td></tr>
            </table>
        </td>
    </tr>
    <tr>
        <td  colspan ="2">
            <asp:Label ID="lblRecCount" runat="server" />&nbsp;&nbsp;
            <asp:Label ID="lblExistsCount" runat="server"  ForeColor ="Orange"/>&nbsp;&nbsp;
            <asp:Label ID="lblErrorCount" runat="server"  ForeColor ="Gray"/>
        </td>
    </tr>
    <tr>
        <td  colspan ="2">           
            <asp:GridView ID="GVList" runat="server" AllowSorting ="false"  SkinID ="null" GridLines ="none" CssClass="import-gridview"
                    AutoGenerateColumns="False"  Width ="100%" EnableViewState ="true" CellPadding ="2" CellSpacing ="1"
                    DataKeyNames="ModuleTypeId" onrowdatabound="GVList_RowDataBound"  
                    meta:resourcekey="GVListResource1"  >
              <Columns>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
                    <HeaderTemplate >
                        <input type ="checkbox" id="allCheckBox" OnClick='JavaScript:allCheck()' />
                        <asp:Label ID="lblAll" runat="server" meta:resourcekey="lblAllResource1" />
                        
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:CheckBox ID="check" runat="server" meta:resourcekey="checkResource1" Checked ="true" />
                        <asp:HiddenField ID="hfdExists" runat="server" Value ="N" />
                    </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField  DataField ="materialcode" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource1" />
                 <asp:BoundField  DataField ="materialdesc" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource2"/>
                 <asp:BoundField  DataField ="pcb" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource3" />
                 <asp:BoundField  DataField ="genBoard" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource4" />
                 <asp:BoundField  DataField ="genboarddn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource5" />
                 <asp:BoundField  DataField ="genBoardDVS" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource6" />
                 <asp:BoundField  DataField ="speBoard" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource7" />
                 <asp:BoundField  DataField ="speBoardDN" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource8" />
                 <asp:BoundField  DataField ="speBoardDVS" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource9" />
                <asp:BoundField  DataField ="SMTFabricationDN"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                  meta:resourcekey="BoundFieldResource10" />
                 <asp:BoundField  DataField ="SMTFabricationDVS" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource11" />
                 <asp:BoundField  DataField ="ComponentPart" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                     meta:resourcekey="BoundFieldResource12"   />   
                 <asp:BoundField  DataField ="ComponentPartDN"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource13"  />
                 <asp:BoundField  DataField ="ComponentPartDVS" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource14" /> 
                 <asp:BoundField  DataField ="GroupPart"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource15" />
                 <asp:BoundField  DataField ="GroupPartDN" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource16" />
                 <asp:BoundField  DataField ="GroupPartDVS" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource17" />
                 <asp:BoundField  DataField ="BondingFabricationDN" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource18" />
                 <asp:BoundField  DataField ="BondingFabricationDVS"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource19" />
                 <asp:BoundField  DataField ="Comments" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource20" />
                 <asp:BoundField  DataField ="Explanation" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource21" />
              </Columns>
              <RowStyle BackColor ="White" />
              <AlternatingRowStyle BackColor ="White" />
            </asp:GridView>
        </td>
    </tr>
  
</table>
</center>
</asp:Content>
