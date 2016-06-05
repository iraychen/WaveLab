<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTBomCoorpatternCtl.aspx.cs" Inherits="WaveLab.Web.SMTBomCoorPatternCtl" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready( function() {
    $("input:submit").button();
});
function makeWindow(mode,value,value1,value2)
{
    var url;
    switch(mode)
    {
        case "NEW":
            url="SMTBomCoorPatternNew.aspx?backlink="+$("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url="SMTBomCoorPatternEdit.aspx?module="+value+"&bomdn="+value1+"&bomdvs="+value2+"&backlink="+$("#<%=hfdCurLink.ClientID %>").val();
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
<table >
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
           <td >
               <fieldset>
               <table width="100%" border ="0" cellpadding="0" cellspacing ="0">
                    <tr>
                        <td>
                            <table border ="0" cellpadding ="0" cellspacing ="2"  width ="100%">
                                <tr>
                                    <td>
                                       <asp:Label ID="lblModule" runat="server" 
                                            meta:resourcekey="lblModuleResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxModule" runat="server" MaxLength="50" 
                                            meta:resourcekey="tbxModuleResource1" />
                                    </td>
                                     <td>
                                       <asp:Label ID="lblBomDn" runat="server" 
                                            meta:resourcekey="lblBomDnResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxBomDn" runat="server" MaxLength="50" 
                                            meta:resourcekey="tbxBomDnResource1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                       <asp:Label ID="lblBomDVS" runat="server" 
                                            meta:resourcekey="lblBomDVSResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxBomDVS" runat="server" MaxLength="50" 
                                            meta:resourcekey="tbxBomDVSResource1"  />
                                    </td>
                                     <td>
                                       <asp:Label ID="lblCoorPattern" runat="server" 
                                            meta:resourcekey="lblCoorPatternResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxCoorPattern" runat="server" MaxLength="50" 
                                            meta:resourcekey="tbxCoorPatternResource1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align ="right">
                            <asp:NewButton ID="btnSearch" runat="server"  Width ="60px" Text ="<%$ Resources:globalResource,SearchText %>"  
                                   onclick="btnSearch_Click"/>&nbsp;
                           <%-- <asp:NewButton ID="btnNew" runat="server"  Width ="60px"  Text ="<%$ Resources:globalResource,NewText %>" 
                                   OnClientClick ="return makeWindow('NEW','')" />--%>
                        </td>
                    </tr>
                </table>
               </fieldset>
           </td>
        </tr>
        <tr style="height:30px">
            <td>
                <asp:LinkButton ID="lbtNew"  runat="server" Font-Bold="true" 
                    Text ="<%$ Resources:globalResource,NewText %>" OnClientClick ="return makeWindow('NEW','')"></asp:LinkButton>
                <font style="width:20px">|</font>
                <asp:LinkButton ID="lbtImport" runat="server" Font-Bold="true" 
                    Text ="<%$ Resources:globalResource,ImportText %>" 
                    onclick="lbtImport_Click"></asp:LinkButton>           
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblRecCount" runat="server" 
                    meta:resourcekey="lblRecCountResource1" /></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                    AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"    
                    meta:resourcekey="GVListResource1" onrowdatabound="GVList_RowDataBound"
                     onsorting="GVList_Sorting"  >
                  <Columns>
                    
                     <asp:BoundField  SortExpression ="module" DataField="module" 
                          meta:resourcekey="BoundFieldResource1"/>
                     <asp:BoundField  SortExpression ="bomdn" DataField="bomdn"
                          meta:resourcekey="BoundFieldResource2"/>
                      <asp:BoundField  SortExpression ="bomdvs" DataField="bomdvs" 
                          meta:resourcekey="BoundFieldResource3"/>
                      <asp:BoundField  SortExpression ="coorpattern" DataField="coorpattern" 
                          meta:resourcekey="BoundFieldResource4"/>
                      <asp:BoundField  SortExpression ="comments" DataField="comments" 
                          meta:resourcekey="BoundFieldResource5"/>
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="pcb">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtEdit" runat ="server"  meta:resourcekey="lbtEditResource1"/>
                        </ItemTemplate>
                     </asp:TemplateField>
                  </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style ="padding-top:10px">
                <webdiyer:AspNetPager ID="PagerNavigator"   runat="server" 
                    onpagechanged="PagerNavigator_PageChanged" />
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