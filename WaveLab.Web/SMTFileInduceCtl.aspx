<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTFileInduceCtl.aspx.cs" Inherits="WaveLab.Web.SMTFileInduceCtl" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function redirect(mode,value,value1,value2)
{
    var url;
    switch(mode)
    {
        case "NEW":
            url="SMTFileInduceNew.aspx?backlink="+$("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url="SMTFileInduceEdit.aspx?materialcode="+value+"&materialdesc="+value1+"&pcb="+value2+"&backlink="+$("#<%=hfdCurLink.ClientID %>").val();
            break ;
        case "NEWPCB":
            url = "SMTFileInducePCB.aspx?backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "Import":
            url = "SMTFileInduceImport.aspx?backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
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
<table>
	<tr>
		<td><asp:Image ID ="imgTitle" runat="server" SkinID ="ImgskinTitle" 
			meta:resourcekey="imgTitleResource1" /></td>
		<td valign="bottom"><asp:Label ID ="lblTitle" runat="server"  SkinID ="skinTitle" 
			meta:resourcekey="lblTitleResource1" /></td>
	</tr>
</table>
<center>
<table width ="99%" style="text-align:left" border ="0" cellpadding="0" cellspacing ="0">
    <tr>
       <td>
            <fieldset>
            <table width="100%" >
                <tr>
                    <td>
                        <table border ="0" cellpadding ="0" cellspacing ="2"  width ="100%">
                            <tr>
                               <td>
                                   <asp:Label ID="lblSYSModuleType" runat="server" 
                                        meta:resourcekey="lblSYSModuleTypeResource1" />
                                </td>
                                <td>
                                    <asp:DropDownList ID ="ddlSYSModuleType" runat="server" 
                                        meta:resourcekey="ddlSYSModuleTypeResource1" />
                                </td>
                                <td>
                                   <asp:Label ID="lblMaterialCode" runat="server" 
                                        meta:resourcekey="lblMaterialCodeResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxMaterialCode" runat="server" MaxLength="13" 
                                        meta:resourcekey="tbxMaterialCodeResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   <asp:Label ID="lblMaterialDesc" runat="server" 
                                        meta:resourcekey="lblMaterialDescResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxMaterialDesc" runat="server" MaxLength="40" 
                                        meta:resourcekey="tbxMaterialDescResource1" Width="200px" />
                                </td>
                                <td>
                                   <asp:Label ID="lblPCB" runat="server" 
                                        meta:resourcekey="lblPCBResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxPCB" runat="server" MaxLength="40" 
                                        meta:resourcekey="tbxPCBResource1" Width="200px"  />
                                </td>
                                
                            </tr>
                        </table>
                    </td>
                    <td align ="right">
                        <asp:NewButton ID="btnSearch" runat="server"   Width ="60px" 
                            meta:resourcekey="btnSearchResource1" onclick="btnSearch_Click"/>&nbsp;
                        
                    </td>
                </tr>
            </table>
            </fieldset>
       </td>
    </tr>
   <tr style="height:30px">
        <td>
            <asp:LinkButton ID="lbtNew" runat="server"  Font-Bold="true" 
                            meta:resourcekey="lbtNewResource1" OnClientClick ="return redirect('NEW','')" />
            <font style="width:20px">|</font>
            <asp:LinkButton ID="lbtNewPCB" runat="server" Font-Bold="true" 
                meta:resourcekey="lbtNewPCBResource1" OnClientClick ="return redirect('NEWPCB','')" />
            <font style="width:20px">|</font>
            <asp:LinkButton ID="lbtImport" runat="server" Font-Bold="true" 
                    Text ="<%$ Resources:globalResource,ImportText %>" OnClientClick ="return redirect('Import','')"
                    ></asp:LinkButton>  
        </td>
    </tr>
    <tr>
        <td><asp:Label ID="lblRecCount" runat="server" 
                meta:resourcekey="lblRecCountResource1" /></td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"   CellPadding ="0" CellSpacing ="0"
                AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"
                meta:resourcekey="GVListResource1" onrowdatabound="GVList_RowDataBound"
                onsorting="GVList_Sorting">
              <Columns>
                
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource2"  SortExpression ="a.module_type_id" HeaderStyle-Width="30" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px">
                    <ItemTemplate>
                        <%#Eval("ModuleTypeItem.ModuleTypeDesc")%>
                    </ItemTemplate>
                 </asp:TemplateField>
                  <asp:BoundField  DataField ="MaterialCode"  SortExpression ="material_code" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource1" />
                 <asp:BoundField  DataField ="MaterialDesc"  SortExpression ="material_desc" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource2" />
                 <asp:BoundField  DataField ="PCB" SortExpression ="pcb" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource3"  />
                 <asp:BoundField  DataField ="GenBoard" SortExpression ="genboard" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                     meta:resourcekey="BoundFieldResource4"   />
                 <asp:BoundField  DataField ="GenboardDN"  SortExpression ="genboarddn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource5"  />
                 <asp:BoundField  DataField ="GenBoardDVS" SortExpression ="genboarddvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource6" />
                 <asp:BoundField  DataField ="SpeBoard" SortExpression ="speboard" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource7" />
                 <asp:BoundField  DataField ="SpeBoardDN" SortExpression ="speboarddn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource8" />
                 <asp:BoundField  DataField ="SpeBoardDVS" SortExpression ="speboarddvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource9" />
                 <asp:BoundField  DataField ="SMTFabricationDN" SortExpression ="smtfabricationdn"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource10" />
                 <asp:BoundField  DataField ="SMTFabricationDVS" SortExpression ="smtfabricationdvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource11" />
                 <asp:BoundField  DataField ="ComponentPart" SortExpression ="componentpart" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                     meta:resourcekey="BoundFieldResource12"   />   
                 <asp:BoundField  DataField ="ComponentPartDN"  SortExpression ="componentpartdn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource13"  />
                 <asp:BoundField  DataField ="ComponentPartDVS" SortExpression ="componentpartdvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource14" /> 
                 <asp:BoundField  DataField ="GroupPart" SortExpression ="grouppart" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource15" />
                 <asp:BoundField  DataField ="GroupPartDN" SortExpression ="grouppartdn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource16" />
                 <asp:BoundField  DataField ="GroupPartDVS" SortExpression ="grouppartdvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource17" />
                 <asp:BoundField  DataField ="BondingFabricationDN" SortExpression ="bondingfabricationdn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource18" />
                 <asp:BoundField  DataField ="BondingFabricationDVS" SortExpression ="bondingfabricationdvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource19" />
                 <asp:BoundField  DataField ="Comments" SortExpression ="comments" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"  
                      meta:resourcekey="BoundFieldResource20" />
                 <asp:BoundField  DataField ="Explanation" SortExpression ="explanation" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px" 
                      meta:resourcekey="BoundFieldResource21" />
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="pcb" HeaderStyle-Width="25"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtEdit" runat ="server"  meta:resourcekey="lbtEditResource1"/>
                    </ItemTemplate>
                 </asp:TemplateField>
              </Columns>
             
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td style ="padding-top:10px;">
            <webdiyer:AspNetPager ID="PagerNavigator" runat="server"   Font-Size="10px"
                onpagechanged="PagerNavigator_PageChanged"  />
        </td>
    </tr>
    <tr>
        <td>
            <asp:HiddenField ID="hfdCurLink" runat="server" /> 
        </td>
    </tr>
</table>
</center>
</asp:Content>
