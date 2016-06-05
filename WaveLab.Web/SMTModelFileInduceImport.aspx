﻿<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTModelFileInduceImport.aspx.cs" Inherits="WaveLab.Web.SMTModelFileInduceImport" Title="无标题页"  meta:resourcekey="PageResource1"  %>
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
            <asp:LinkButton ID="lbtSample" runat ="server"  Font-Size ="13px" Font-Bold ="True"
                            meta:resourcekey="lbtSampleResource1" 
                onclick="lbtSample_Click"  />
        </td>
    </tr>
    <tr>
        <td align ="right"  style ="width :70%">
            <table style="text-align:left">
                <tr>
                    <td><asp:Label ID="lblSYSModuleType" runat="server" 
                            meta:resourcekey="lblSYSModuleTypeResource1" /></td>
                    <td colspan ="2">
                        <asp:DropDownList ID="ddlSYSModuleType" runat="server"  Width="80px"
                            meta:resourcekey="ddlSYSModuleTypeResource1" /></td>
                    
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
                <tr><td><asp:Label ID ="lblExistsTip" runat="server" ForeColor ="Orange"  meta:resourcekey="lblExistsTipResource1" /></td></tr>
                <tr><td><asp:Label ID ="lblFormatTip" runat="server" ForeColor ="Gray"  meta:resourcekey="lblFormatTipResource1" /></td></tr>
                <tr><td><asp:Label ID ="lblFormatTipDesc" runat="server" ForeColor ="Gray"  meta:resourcekey="lblFormatTipDescResource1" /></td></tr>
                 <tr><td><asp:Label ID ="lblFormatTipDesc2" runat="server" ForeColor ="Gray"  meta:resourcekey="lblFormatTipDesc2Resource1" /></td></tr>
            </table>
        </td>
    </tr>
    <tr>
        <td  colspan ="2">
            <asp:Label ID="lblRecCount" runat="server" 
                meta:resourcekey="lblRecCountResource1" />&nbsp;&nbsp;
            <asp:Label ID="lblExistsCount" runat="server"  ForeColor ="Orange" 
                meta:resourcekey="lblExistsCountResource1"/>&nbsp;&nbsp;
            <asp:Label ID="lblErrorCount" runat="server"  ForeColor ="Gray" 
                meta:resourcekey="lblErrorCountResource1"/>
        </td>
    </tr>
    <tr>
        <td  colspan ="2">           
            <asp:GridView ID="GVList" runat="server"  SkinID ="null" GridLines ="None" CssClass="import-gridview"
                    AutoGenerateColumns="False"  Width ="100%" CellPadding ="2" CellSpacing ="1"
                    DataKeyNames="ModuleTypeId" onrowdatabound="GVList_RowDataBound"  
                    meta:resourcekey="GVListResource1"  >
              <Columns>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
                    <HeaderTemplate >
                        <input type ="checkbox" id="allCheckBox" OnClick='JavaScript:allCheck()' />
                        <asp:Label ID="lblAll" runat="server" meta:resourcekey="lblAllResource1" />
                        
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:CheckBox ID="check" runat="server" meta:resourcekey="checkResource1" 
                            Checked ="True" />
                        <asp:HiddenField ID="hfdExists" runat="server" Value ="N" />
                    </ItemTemplate>
                 </asp:TemplateField>
                <asp:BoundField  DataField ="BillSerialNumber"  SortExpression ="Bill_Serial_Number"  
                      meta:resourcekey="BoundFieldResource1" />
                 <asp:BoundField  DataField ="ModuleDesc"  SortExpression ="Module_Desc"  
                      meta:resourcekey="BoundFieldResource2" />
                 <asp:BoundField  DataField ="PCB" SortExpression ="pcb"  
                      meta:resourcekey="BoundFieldResource3"  />
                 <asp:BoundField  DataField ="SerialNumber" SortExpression ="SerialNumber"  
                     meta:resourcekey="BoundFieldResource4"   />
                 <asp:BoundField  DataField ="Version"  SortExpression ="Version"  
                      meta:resourcekey="BoundFieldResource5"  />
                 <asp:BoundField  DataField ="SpeBoard" SortExpression ="speboard"  
                      meta:resourcekey="BoundFieldResource6" />
                 <asp:BoundField  DataField ="SpeBoardDN" SortExpression ="speboarddn"  
                      meta:resourcekey="BoundFieldResource7" />
                 <asp:BoundField  DataField ="SpeBoardDVS" SortExpression ="speboarddvs"  
                      meta:resourcekey="BoundFieldResource8" />
                 <asp:BoundField  DataField ="FabricationDN" SortExpression ="fabricationdn"   
                      meta:resourcekey="BoundFieldResource9" />
                 <asp:BoundField  DataField ="FabricationDVS" SortExpression ="fabricationdvs"  
                      meta:resourcekey="BoundFieldResource10" />
                 <asp:BoundField  DataField ="SteelMesh" SortExpression ="SteelMesh"  
                     meta:resourcekey="BoundFieldResource11"   />   
                 <asp:BoundField  DataField ="CoorPattern"  SortExpression ="CoorPattern"  
                      meta:resourcekey="BoundFieldResource12"  />
                 <asp:BoundField  DataField ="Comments" 
                      meta:resourcekey="BoundFieldResource13" >
                
<HeaderStyle Font-Size="10px"></HeaderStyle>

<ItemStyle Font-Size="10px"></ItemStyle>
                  </asp:BoundField>
                
              </Columns>
              <RowStyle BackColor ="White" />
              <AlternatingRowStyle BackColor ="White" />
            </asp:GridView>
        </td>
    </tr>
  
</table>
</center>
</asp:Content>
