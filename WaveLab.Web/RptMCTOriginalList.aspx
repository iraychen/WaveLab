<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RptMCTOriginalList.aspx.cs" Inherits="WaveLab.Web.RptMCTOriginalList" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
function goBack()
{
    self.location.href="RptMCTOriginal.aspx";
    return false;
} 
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<table class="noPrint" style ="width:100%">
    <tr>
         <td>
            <asp:ImageButton ID="imgBtnBack" runat ="server" SkinID ="imgBtnSkinBack"  
             OnClientClick ="return goBack()" meta:resourcekey="imgBtnBackResource1" />
         </td>
         <td align ="right">
             <asp:ImageButton ID="imgBtnRefresh" runat ="server" SkinID ="imgBtnSkinRefresh"  
             OnClientClick ="javascript:refresh();return false;"  />
         </td>
    </tr>
</table>
 <center>         
 <asp:Label ID="lblTitle" runat="server" SkinId="skinRptTitle"
            meta:resourcekey="lblTitleResource1"></asp:Label>
<table border = "0" cellpadding ="0" cellspacing ="0"  width="99%" style="text-align:left;font-weight:normal">
	<tr>
		<td colspan ="2" >
			<div id="divParas" style="WIDTH: 600px;  margin-left:2px;" runat="server"></div>
		</td>
	</tr>
	<tr>
	    <td colspan ="2"><asp:Label ID="lblRecCount" runat="server" 
                meta:resourcekey="lblRecCountResource1"></asp:Label></td>
	</tr>
	<tr>
		<td colspan ="2">
		     <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False"  
                    EnableViewState ="False" SkinID="skinRptGridView" Width ="100%"
                meta:resourcekey="GVListResource1" onsorting="GVList_Sorting"                 
                 onrowdatabound="GVList_RowDataBound">
                  <Columns>
                  <asp:BoundField  DataField ="ProductDesc" SortExpression ="m.product_desc" meta:resourcekey="BoundFieldResource1" />
                     <asp:BoundField  DataField ="MaterialTypeDesc" SortExpression ="m.material_type_desc" meta:resourcekey="BoundFieldResource2" />
                     <asp:BoundField  DataField ="MaterialCode"   SortExpression ="m.material_code" meta:resourcekey="BoundFieldResource3" />
                     <asp:BoundField  DataField ="MaterialDesc" SortExpression ="m.material_desc" meta:resourcekey="BoundFieldResource4" />
                     <asp:BoundField  DataField ="SupplierName" SortExpression ="m.supplier_name" meta:resourcekey="BoundFieldResource5" />
                     <asp:BoundField  DataField ="ComponentDesc" SortExpression ="m.component_desc" meta:resourcekey="BoundFieldResource6" />
                     <asp:BoundField  DataField ="HomoMaterialName" SortExpression ="m.homo_material_name" meta:resourcekey="BoundFieldResource7"  />
                     <asp:BoundField  DataField ="SubstanceName" SortExpression ="substance_name" meta:resourcekey="BoundFieldResource8"  />
                     <asp:BoundField  DataField ="CasNo" SortExpression ="n.cas_no" meta:resourcekey="BoundFieldResource9"  />
                     <asp:BoundField  DataField ="SubstanceMass" SortExpression ="n.substance_mass" meta:resourcekey="BoundFieldResource10"  DataFormatString="{0:f5}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                     <asp:BoundField  DataField ="ContentRate" SortExpression ="n.content_rate" meta:resourcekey="BoundFieldResource11" DataFormatString="{0:f3}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                  </Columns>
            </asp:GridView>
		</td>
	</tr>
</table>
</center>
</asp:Content>