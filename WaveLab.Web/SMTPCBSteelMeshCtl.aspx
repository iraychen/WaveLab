<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTPCBSteelMeshCtl.aspx.cs" Inherits="WaveLab.Web.SMTPCBSteelMeshCtl" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function makeWindow(mode,value)
{
    var url;
    switch(mode)
    {
        case "NEW":
            url="SMTPCBSteelMeshNew.aspx?backlink="+$("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url="SMTPCBSteelMeshEdit.aspx?pcb="+value+"&backlink="+$("#<%=hfdCurLink.ClientID %>").val();
            break ;
        default:
            break;
    }
    var winparas="toolbar=0,status=0,scrollbars=1,resizable=0,width=700px,Height=500px";
    var win=window.open(url,"secwin",winparas);    
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
    <table width ="99%" style="text-align:left; "  border ="0" cellpadding="0" cellspacing ="0">
        <tr>
           <td>
                <table width="100%" border ="0" cellpadding="0" cellspacing ="0">
                    <tr>
                        <td>
                            <table border ="0" cellpadding ="0" cellspacing ="0"  width ="100%">
                                <tr>
                                    <td>
                                       <asp:Label ID="lblPCB" runat="server" 
                                            meta:resourcekey="lblPCBResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxPCB" runat="server" MaxLength="50" 
                                            meta:resourcekey="tbxPCBResource1" />
                                    </td>
                                     <td>
                                       <asp:Label ID="lblSteelMesh" runat="server" 
                                            meta:resourcekey="lblSteelMeshResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxSteelMesh" runat="server" MaxLength="50" 
                                            meta:resourcekey="tbxSteelMeshResource1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign ="bottom" align ="right">
                           <asp:NewButton ID="btnSearch" runat="server"  Width ="60px" Text ="<%$ Resources:globalResource,SearchText %>"  
                               onclick="btnSearch_Click"/>&nbsp;
                           <asp:NewButton ID="btnNew" runat="server"  Width ="60px"  Text ="<%$ Resources:globalResource,NewText %>" 
                               OnClientClick ="return makeWindow('NEW','')" />
                        </td>
                    </tr>
                </table>
           </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblRecCount" runat="server"/></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                    AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"
                    meta:resourcekey="GVListResource1" onrowdatabound="GVList_RowDataBound"
                     onsorting="GVList_Sorting"  >
                  <Columns>
                   
                      <asp:BoundField  DataField="PCB" SortExpression ="pcb"
                          meta:resourcekey="BoundFieldResource1"/>
                     <asp:BoundField   DataField="SteelMesh" SortExpression ="steelmesh"
                          meta:resourcekey="BoundFieldResource2"/>
                     <asp:BoundField   DataField="FactureDate"  DataFormatString="{0:yyyy-MM-dd}" SortExpression ="facture_date"
                          meta:resourcekey="BoundFieldResource3"/>
                      <asp:BoundField  DataField="SerialNo" SortExpression ="serialno" 
                          meta:resourcekey="BoundFieldResource4"/>
                      <asp:BoundField  DataField="DocumentNo" SortExpression ="documentno" 
                          meta:resourcekey="BoundFieldResource5"/>
                      <asp:BoundField  DataField="Comments" SortExpression ="comments" 
                          meta:resourcekey="BoundFieldResource6"/>
                      <asp:BoundField  DataField="Defect" SortExpression ="defect"
                          meta:resourcekey="BoundFieldResource7"/>
                        <asp:TemplateField meta:resourcekey="TemplateFieldResource1" HeaderStyle-Width="25">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbtEdit" runat ="server" meta:resourcekey="lbtEditResource1"  />
                        </ItemTemplate>
                     </asp:TemplateField>
                  </Columns>
                </asp:GridView>            
            </td>
        </tr>
        <tr>
            <td style ="padding-top:10px">
                <webdiyer:AspNetPager ID="PagerNavigator" runat="server"  EnableViewState ="true"
                    onpagechanged="PagerNavigator_PageChanged"/>
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