<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RptProductBomList.aspx.cs" Inherits="WaveLab.Web.RptProductBomList" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
     function goBack()
    {
        self.location.href="RptProductBom.aspx";
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
			<div id="divParas" style="WIDTH: 600px;  margin-left:0px; padding-left:0px" runat="server"></div>
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
                meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" >
                  <Columns>
                      <asp:TemplateField  meta:resourcekey="TemplateFieldResource1" SortExpression ="product_desc">
                        <ItemTemplate >
                           <%# Eval("ProductItem.ProductDesc") %>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField  DataField ="MaterialCode"   SortExpression ="material_code"
                          meta:resourcekey="BoundFieldResource1" >
                      </asp:BoundField>
                     <asp:TemplateField  meta:resourcekey="TemplateFieldResource2" SortExpression ="material_type_desc">
                        <ItemTemplate >
                           <%# Eval("MaterialTypeItem.MaterialTypeDesc") %>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField  DataField ="MaterialDesc" SortExpression ="material_code" HtmlEncode="false"
                          meta:resourcekey="BoundFieldResource2" />
                     <asp:BoundField  DataField ="SupplierName" meta:resourcekey="BoundFieldResource3" SortExpression ="supplier_name" />
                     <asp:BoundField  DataField ="Amount" SortExpression ="amount" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign ="Right"
                          meta:resourcekey="BoundFieldResource4" />
                     <asp:TemplateField  meta:resourcekey="TemplateFieldResource3" SortExpression ="module_type_desc">
                        <ItemTemplate>
                           <%# Eval("ModuleTypeItem.ModuleTypeDesc") %>
                        </ItemTemplate>
                      </asp:TemplateField>
                     <asp:BoundField  DataField ="Comment" SortExpression ="comment"
                          meta:resourcekey="BoundFieldResource5" />
                  </Columns>
                 <RowStyle BackColor ="White" />
                 <AlternatingRowStyle BackColor ="White" />
            </asp:GridView>
		</td>
	</tr>
</table>
</center>
</asp:Content>