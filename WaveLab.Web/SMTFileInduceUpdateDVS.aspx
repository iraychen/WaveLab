<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTFileInduceUpdateDVS.aspx.cs" Inherits="WaveLab.Web.UpdateCPDVS" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function goBack()
{
    self.location.href="SMTDocumentCtl.aspx";
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<asp:ImageButton ID="imgBtnBack" runat ="server" SkinID ="imgBtnSkinBack"  
         OnClientClick ="return goBack()" meta:resourcekey="imgBtnBackResource1"/>
 <center>         
 <asp:Label ID="lblTitle" runat="server"  SkinID ="skinCTitle"
            meta:resourcekey="lblTitleResource1"></asp:Label>
<table border = "0" cellpadding ="0" cellspacing ="0"  width="98%" style="text-align:left;font-weight:normal">
<tr>
    <td colspan ="2" valign ="top">
		<asp:Label ID ="lblTip" runat="server" ForeColor ="Blue" meta:resourcekey="lblTipResource1"/>
    </td>
</tr>
	 <tr>
	    <td><asp:Label ID="lblRecCount" runat="server" 
                meta:resourcekey="lblRecCountResource1"></asp:Label></td>
        <td align ="right">
	        <asp:NewButton ID="btnUpdate" runat="server"   cl-table Width ="80px"  
                onclick="btnUpdate_Click" meta:resourcekey="btnUpdateResource1"  />&nbsp;
            <asp:NewButton ID="btnView" runat="server" cl-table Width ="100px"   Visible="false"
                onclick="btnView_Click" meta:resourcekey="btnViewResource1" 
                style="height: 26px"  />
	    </td>
	</tr>
	<tr>
		<td colspan ="2">
		     <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  DataKeyNames="materialcode,materialdesc,pcb"
                AutoGenerateColumns="False"   SkinID ="skinGridView"
                meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" 
                 onrowdatabound="GVList_RowDataBound" >
                  <Columns>
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="a.module_type_desc">
                        <ItemTemplate>
                            <%#Eval("ModuleTypeItem.ModuleTypeDesc")%>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField  DataField ="MaterialCode"  SortExpression ="material_code"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource1" />
                     <asp:BoundField  DataField ="MaterialDesc" SortExpression ="material_desc" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource2" />
                     <asp:BoundField  DataField ="PCB" SortExpression ="pcb" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource3" />
                     <asp:BoundField  DataField ="GenBoard"  SortExpression ="genboard"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource4" />
                     <asp:BoundField  DataField ="GenBoardDN"  SortExpression ="genboarddn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource5" />
                     <asp:BoundField  DataField ="GenBoardDVS"  SortExpression ="genboarddvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource6" />
                     <asp:BoundField  DataField ="NewGenBoardDVS"  SortExpression ="newgenboarddvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource7" />
                     <asp:BoundField  DataField ="SpeBoard" SortExpression="speBoard" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource8" />
                     <asp:BoundField  DataField ="SpeBoardDN"  SortExpression ="speboarddn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource9" />                   
                     <asp:BoundField  DataField ="SpeBoardDVS"  SortExpression ="speboarddvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource10" />
                     <asp:BoundField  DataField ="NewSpeBoardDVS"  SortExpression ="newspeboarddvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource11" />
                     <asp:BoundField  DataField ="SMTFabricationDN"  SortExpression ="smtfabricationdn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource12" />
                     <asp:BoundField  DataField ="SMTFabricationDVS"  SortExpression ="smtfabricationdvs"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource13" />
                     <asp:BoundField  DataField ="NewSMTFabricationDVS"  SortExpression ="newsmtfabricationdvs"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource14" />      
                        
                     <asp:BoundField  DataField ="ComponentPart"  SortExpression ="componentpart"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource15" />
                     <asp:BoundField  DataField ="ComponentPartDN"  SortExpression ="componentpartdn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource16" />
                     <asp:BoundField  DataField ="ComponentPartDVS"  SortExpression ="componentpartdvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource17" />
                     <asp:BoundField  DataField ="NewComponentPartDVS"  SortExpression ="newcomponentpartdvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource18" />
                     <asp:BoundField  DataField ="GroupPart" SortExpression="grouppart" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource19" />
                     <asp:BoundField  DataField ="GroupPartDN"  SortExpression ="grouppartdn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource20" />                   
                     <asp:BoundField  DataField ="GroupPartDVS"  SortExpression ="grouppartdvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource21" />
                     <asp:BoundField  DataField ="NewGroupPartDVS"  SortExpression ="newgrouppartdvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource22" />
                     <asp:BoundField  DataField ="BondingFabricationDN"  SortExpression ="bondingfabricationdn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource23" />
                     <asp:BoundField  DataField ="BondingFabricationDVS"  SortExpression ="bondingfabricationdvs"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource24" />
                     <asp:BoundField  DataField ="NewBondingFabricationDVS"  SortExpression ="newbondingfabricationdvs"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                        meta:resourcekey="BoundFieldResource25" />                        
                  </Columns>
                 <RowStyle BackColor ="White" />
                 <AlternatingRowStyle BackColor ="White" />
            </asp:GridView>
		</td>
	</tr>
</table>
</center>
</asp:Content>
