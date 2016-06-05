<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ProductAudit.aspx.cs" Inherits="WaveLab.Web.ProductAudit" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function makeWindow(mode,value)
{
    var url;
    var win;
    var strPara="toolbar=0,status=0,scrollbars=1,resizable=1,width=700px,Height=580px";
    switch(mode)
    {
        case "MCT":
            url="MCTDetail.aspx?mctid="+value;
            break;
        default:
            break;
    }
    win=window.open(url,"secwin",strPara);
    return false;
}
function goBack()
{
    self.location.href="ProductCtl.aspx";
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<asp:ImageButton ID="imgBtnBack" runat ="server" SkinID ="imgBtnSkinBack"  
         OnClientClick ="return goBack()" meta:resourcekey="imgBtnBackResource1"/>
<center>
   <br /><asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" 
     meta:resourcekey="lblTitleResource1" /><br /><br />
 
  <table style="text-align:left ;">
   <tr>
   <td>
     <table  width="100%"  border="0" cellpadding ="0" cellspacing ="0">
        <tr>
            <td colspan ="2"><asp:Label ID="lblProduct" runat="server" 
                    meta:resourcekey="lblProductResource1"/>:
                <asp:Label ID="lblProductDesc" runat="server"  ForeColor ="Blue"
                    meta:resourcekey="lblProductDescResource1"/>
            </td>
        </tr>
        <tr>
            <td >
                <asp:RadioButtonList ID="rblFilter" runat ="server"  AutoPostBack ="true"
                    RepeatDirection ="Horizontal" meta:resourcekey="rblFilterResource1" 
                    onselectedindexchanged="rblFilter_SelectedIndexChanged">
                   <asp:ListItem Selected ="True" meta:resourcekey="rblFilterResource1_ListItemResource1"></asp:ListItem>
                   <asp:ListItem meta:resourcekey="rblFilterResource1_ListItemResource2"></asp:ListItem>
                   <asp:ListItem meta:resourcekey="rblFilterResource1_ListItemResource3"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td align ="right">
                <asp:NewButton ID="btnExportExcel" runat ="server" 
                    meta:resourcekey="btnExportExcelResource1"  Width ="70" 
                    onclick="btnExportExcel_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan ="2">
                <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  
                    SkinId="skinGridView" EnableViewState ="false"
                    AutoGenerateColumns="False"  Width ="100%"  
                    meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" 
                    onrowdatabound="GVList_RowDataBound" >
                   <Columns>
                      <asp:BoundField  DataField ="MaterialCode" SortExpression ="material_code" 
                          meta:resourcekey="BoundFieldResource1" />
                      <asp:BoundField  DataField ="MaterialDesc" SortExpression ="material_desc" HtmlEncode ="false" 
                          meta:resourcekey="BoundFieldResource2" />
                      <asp:BoundField  DataField ="SupplierName"  SortExpression ="supplier_name"
                          meta:resourcekey="BoundFieldResource3" >
                      </asp:BoundField>
                      <asp:BoundField  DataField ="Supplied"  SortExpression ="supplied"
                          meta:resourcekey="BoundFieldResource4" >
                      </asp:BoundField>
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  ItemStyle-Width ="50" Visible="false">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtMCTView" runat ="server" 
                                meta:resourcekey="lbtMCTViewResource1" />
                        </ItemTemplate>
                      </asp:TemplateField>
                  </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr style ="margin-top:5px">
            <td colspan ="2" >
                <asp:Label ID ="lblRecCount" runat ="server" />
            </td>
        </tr>
       <tr>
            <td colspan ="2" align="center">
                <br />
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblAudited" runat ="server" 
                                meta:resourcekey="lblAuditedResource1" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblAudited" runat ="server"   CssClass ="cl-table" Width ="80"
                                RepeatDirection ="Horizontal" meta:resourcekey="rblAuditedResource1">
                                <asp:ListItem meta:resourcekey="rblAuditedResource1_ListItemResource1"></asp:ListItem>
                                <asp:ListItem meta:resourcekey="rblAuditedResource1_ListItemResource2" Selected ="False"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
      </table>
    </td>
   </tr>
  </table>
 
   <br />
  <asp:NewButton ID="btnSave" runat="server"   
        meta:resourcekey="btnSaveResource1" Width ="80"  onclick="btnSave_Click"/>
  &nbsp;
  <asp:NewButton ID="btnReset" runat ="server" 
        meta:resourcekey="btnResetResource1"  Width ="80"  OnClientClick ="return formReset()"/>
</center>
</asp:Content>