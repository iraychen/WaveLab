<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTModelConsignProcess.aspx.cs" Inherits="WaveLab.Web.SMTModelConsignProcess" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});

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
                                   <asp:Label ID="lblBillSerialNumber" runat="server" 
                                        meta:resourcekey="lblBillSerialNumberResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxBillSerialNumber" runat="server" MaxLength="13"
                                        meta:resourcekey="tbxBillSerialNumberResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   <asp:Label ID="lblModuleDesc" runat="server" 
                                        meta:resourcekey="lblModuleDescResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxModuleDesc" runat="server" MaxLength="40" 
                                        meta:resourcekey="tbxModuleDescResource1"  />
                                </td>
                                <td>
                                   <asp:Label ID="lblPCB" runat="server" 
                                        meta:resourcekey="lblPCBResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxPCB" runat="server" MaxLength="40" 
                                        meta:resourcekey="tbxPCBResource1"  />
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
    <tr>
        <td><asp:Label ID="lblRecCount" runat="server" 
                meta:resourcekey="lblRecCountResource1" /></td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  
                SkinId="skinGridView"   CellPadding ="0" DataKeyNames="FileInducePK"
                AutoGenerateColumns="False"  Width ="100%"
                meta:resourcekey="GVListResource1"  OnRowCommand="GVList_RowCommand"
                onsorting="GVList_Sorting">
              <Columns>
                  <asp:BoundField  DataField ="BillSerialNumber"  SortExpression ="Bill_Serial_Number"  HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px" 
                      meta:resourcekey="BoundFieldResource1" />
                 <asp:BoundField  DataField ="ModuleDesc"  SortExpression ="Module_Desc"  HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px" 
                      meta:resourcekey="BoundFieldResource2" />
                 <asp:BoundField  DataField ="PCB" SortExpression ="pcb"  HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px" 
                      meta:resourcekey="BoundFieldResource3"  />
                 <asp:BoundField  DataField ="SerialNumber" SortExpression ="Serial_Number"  HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px" 
                     meta:resourcekey="BoundFieldResource4"   />
                 <asp:BoundField  DataField ="Version"  SortExpression ="Version"  HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px" 
                      meta:resourcekey="BoundFieldResource5"  />
                 <asp:BoundField  DataField ="SpeBoard" SortExpression ="speboard"  HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px" 
                      meta:resourcekey="BoundFieldResource6" />
                 <asp:BoundField  DataField ="SpeBoardDN" SortExpression ="speboarddn"  HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px" 
                      meta:resourcekey="BoundFieldResource7" />
                 <asp:BoundField  DataField ="SpeBoardDVS" SortExpression ="speboarddvs"  HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px" 
                      meta:resourcekey="BoundFieldResource8" />
                 <asp:BoundField  DataField ="FabricationDN" SortExpression ="fabricationdn"   HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px" 
                      meta:resourcekey="BoundFieldResource9" />
                 <asp:BoundField  DataField ="FabricationDVS" SortExpression ="fabricationdvs"  HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px" 
                      meta:resourcekey="BoundFieldResource10" />
                 <asp:BoundField  DataField ="SteelMesh" SortExpression ="SteelMesh"  HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px" 
                     meta:resourcekey="BoundFieldResource11"   />   
                 <asp:BoundField  DataField ="CoorPattern"  SortExpression ="CoorPattern"  HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px" 
                      meta:resourcekey="BoundFieldResource12"  />
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="pcb" HeaderStyle-Font-Size="11px" ItemStyle-Font-Size="11px"  >
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtExport" runat ="server" CommandName="Export" CommandArgument ='<%#Eval("FileInducePK") %>'  meta:resourcekey="lbtExportResource1"/>                        
                    </ItemTemplate>
                 </asp:TemplateField>
              </Columns>
             
            </asp:GridView>
        </td>
    </tr>
</table>
</center>
</asp:Content>
