<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MCTReplace.aspx.cs" Inherits="WaveLab.Web.MCTReplace" Title="无标题页" %>
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

function goBack()
{
    self.location.href='<%=System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) %>';
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<asp:ImageButton ID="imgBtnBack" runat ="server" SkinID ="imgBtnSkinBack"  
         meta:resourcekey="imgBtnBackResource1"  onclick="imgBtnBack_Click" />
<center>
   <br /><asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" 
     meta:resourcekey="lblTitleResource1" /><br /><br />
 
 <table width ="98%" style="text-align:left" >
    <tr >
        <td align ="right" colspan="2">
            <table>
                <tr>
                    <td align ="left">
                        <asp:LinkButton ID="lbtTemplateDownLoad" runat ="server"  Font-Bold ="True" Font-Size ="13px"
                            meta:resourcekey="lbtTemplateDownLoadResource1" 
                            onclick="lbtTemplateDownLoad_Click"  />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td   align ="right"  style ="width:65%">
            <table style="text-align:left" >
                <tr>
                    <td>
                        <asp:Label ID ="lblSupplierName" runat ="server" meta:resourcekey="lblSupplierNameResource1" />
                    </td>
                    <td>
                        <asp:Label ID ="lblReplaceSupplierName" runat ="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID ="lblPartNo" runat ="server" meta:resourcekey="lblPartNoResource1" />
                    </td>
                    <td>
                        <asp:Label ID ="lblReplacePartNo" runat ="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID ="lblModel" runat ="server" meta:resourcekey="lblModelResource1" />
                    </td>
                    <td>
                        <asp:Label ID ="lblReplaceModel" runat ="server" />
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
                            ToolTip="<%$ Resources:globalResource,uploadValueMsg %>" 
                            meta:resourcekey="lblUploadValueMsgResource1"  />
                        <asp:Label ID="lblFileTypeMsg" runat="server" 
                            ToolTip="<%$ Resources:globalResource,excelFileTypeMsg %>" 
                            meta:resourcekey="lblFileTypeMsgResource1"/>
                    </td>
                    <td>
                        <asp:NewButton ID="btnImport" runat="server" Width ="80px"  Visible ="False"
                            meta:resourcekey="btnImportResource1" onclick="btnImport_Click"/>
                    </td>
                    
                </tr>
            </table>
        </td>
        <td  align ="right">
            <table style="text-align:left">
                <tr><td><asp:Label ID ="lblFormatTip" runat="server" ForeColor ="Gray"  meta:resourcekey="lblFormatTipResource1" /></td></tr>
                <tr><td><asp:Label ID ="lblInjurantTip" runat="server" ForeColor ="Red"
                        meta:resourcekey="lblInjurantTipResource1" /></td></tr>
            </table>
        </td>
    </tr>
   <%-- <tr>
        <td>
            <asp:Label ID="lblErrorCount" runat="server"  ForeColor ="Red" 
                meta:resourcekey="lblErrorCountResource1"/>
        </td>
    </tr>    --%>    
    <tr>
        <td  colspan ="2">
            <table id="tblMaterialComposition" runat ="server" width ="100%" visible="false" style ="text-align:left">
                <tr>
                    <td ><asp:Label ID="lblBasicInformation" runat ="server"  
                            Font-Bold ="True" Font-Size ="Larger" 
                            meta:resourcekey="lblBasicInformationResource1"/></td>               
                </tr> 
                <tr>
                    <td>
                        <table style ="width:800px">
                            
                            <tr>
                                <td><asp:Label ID ="lblSupplierNameKey" runat ="server" 
                                        meta:resourcekey="lblSupplierNameKeyResource1" /> </td>
                                <td colspan ="3">
                                    <asp:Label ID ="lblSupplierNameVal" runat ="server" 
                                        meta:resourcekey="lblSupplierNameValResource1" />
                                </td>
                            </tr>   
                            <tr>
                                <td style ="width:80px"><asp:Label ID ="lblCompletedDateKey" runat ="server" 
                                        meta:resourcekey="lblCompletedDateKeyResource1" /></td>
                                <td style ="width:320px">
                                    <asp:Label ID ="lblCompletedDateVal" runat ="server" 
                                        meta:resourcekey="lblCompletedDateValResource1" />
                                </td>
                                 <td><asp:Label ID ="lblDeparmentKey" runat ="server" 
                                         meta:resourcekey="lblDeparmentKeyResource1" /></td>
                                <td>
                                    <asp:Label ID ="lblDeparmentVal" runat ="server" 
                                        meta:resourcekey="lblDeparmentValResource1" />
                                </td>
                            </tr>  
                            <tr>
                                <td><asp:Label ID ="lblCompleteByKey" runat ="server" 
                                        meta:resourcekey="lblCompleteByKeyResource1" /></td>
                                <td>
                                    <asp:Label ID ="lblCompleteByVal" runat ="server" 
                                        meta:resourcekey="lblCompleteByValResource1" />
                                </td>
                                 <td><asp:Label ID ="lblEmailKey" runat ="server" 
                                         meta:resourcekey="lblEmailKeyResource1" /></td>
                                <td>
                                    <asp:Label ID ="lblEmailVal" runat ="server" 
                                        meta:resourcekey="lblEmailValResource1" />
                                </td>
                            </tr>
                             <tr>
                                <td><asp:Label ID ="lblTelKey" runat ="server" 
                                        meta:resourcekey="lblTelKeyResource1" /></td>
                                <td>
                                    <asp:Label ID ="lblTelVal" runat ="server" 
                                        meta:resourcekey="lblTelValResource1" />
                                </td>
                                 <td><asp:Label ID ="lblFaxKey" runat ="server" 
                                         meta:resourcekey="lblFaxKeyResource1" /></td>
                                <td>
                                    <asp:Label ID ="lblFaxVal" runat ="server" 
                                        meta:resourcekey="lblFaxValResource1" />
                                </td>
                            </tr>   
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                    <asp:Label ID="lblSubstancesInProduct" runat ="server"  
                            Font-Bold ="True" Font-Size ="Larger" 
                            meta:resourcekey="lblSubstancesInProductResource1"/></td>               
                </tr>  
                <tr>
                    <td >
                         <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   SkinID ="null" 
                            GridLines ="None" CssClass="import-gridview"
                                AutoGenerateColumns="False"  Width ="100%" CellPadding ="2" 
                            CellSpacing ="1"
                            meta:resourcekey="GVListResource1" onrowdatabound="GVList_RowDataBound"  >
                              <Columns>
                                 <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialDesc" Text='<%# Eval("MaterialDesc") %>'  
                                            runat ="server" meta:resourcekey="lblMaterialDescResource1" />
                                        <asp:HiddenField ID="hfdIsPass" runat="server"/>
                                    </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:BoundField  DataField ="Model" meta:resourcekey="BoundFieldResource1" HtmlEncode ="false"/>
                                 <asp:BoundField  DataField ="PartNo"  meta:resourcekey="BoundFieldResource2" />
                                 <asp:BoundField  DataField ="ComponentDesc"  meta:resourcekey="BoundFieldResource3" />
                                 <asp:BoundField  DataField ="HomoMaterialName" meta:resourcekey="BoundFieldResource4" />
                                 <asp:BoundField  DataField ="SubstanceName" meta:resourcekey="BoundFieldResource5" />
                                 <asp:BoundField  DataField ="CasNo" meta:resourcekey="BoundFieldResource6" />
                                 <asp:BoundField  DataField ="SubstanceMass" meta:resourcekey="BoundFieldResource7"   HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                                 <asp:BoundField  DataField ="ContentRate" meta:resourcekey="BoundFieldResource8"  HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                                <%-- <asp:BoundField  DataField ="Comment"   meta:resourcekey="BoundFieldResource9" />--%>
                              </Columns>
                        </asp:GridView>
                    </td>
                </tr> 
                 <tr>
                    <td>
                        <asp:Label ID="lblRecCount" runat="server"  meta:resourcekey="lblRecCountResource1" />&nbsp;&nbsp;
                    </td>
                </tr>                  
            </table>
        </td>
    </tr>
  
</table>
</center>
</asp:Content>
