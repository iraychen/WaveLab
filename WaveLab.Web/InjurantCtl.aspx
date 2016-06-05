<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="InjurantCtl.aspx.cs" Inherits="WaveLab.Web.InjurantCtl" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
            url="InjurantNew.aspx?backlink="+$("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url="InjurantEdit.aspx?injurantid="+value+"&backlink="+$("#<%=hfdCurLink.ClientID %>").val();
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
           <td>
               <fieldset>
                <table width="100%">
                    <tr>
                        <td>
                            <table border ="0" cellpadding ="0" cellspacing ="2"  width ="100%">
                                <tr>
                                    <td>
                                        <asp:Label ID ="lblInjurantType" runat ="server" 
                                            meta:resourcekey="lblInjurantTypeResource1" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlInjurantType" runat ="server" 
                                            meta:resourcekey="ddlInjurantTypeResource1" />
                                    </td>
                                    <td>
                                       <asp:Label ID="lblInjurantDescCn" runat="server" 
                                            meta:resourcekey="lblInjurantDesc_CnResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxInjurantDescCn" runat="server" MaxLength="50" 
                                            meta:resourcekey="tbxInjurantDescCnResource1" />
                                    </td>
                                  
                                 </tr>
                                <tr>
                                    <td>
                                       <asp:Label ID="lblInjurantDescEn" runat="server" 
                                            meta:resourcekey="lblInjurantDescEnResource1" />
                                    </td>
                                    <td>
                                       <asp:TextBox ID="tbxInjurantDescEn" runat ="server" MaxLength ="100" 
                                            meta:resourcekey="tbxInjurantDescEnResource1" />
                                    </td>
                                     <td>
                                       <asp:Label ID="lblMolecularFormula" runat="server" 
                                            meta:resourcekey="lblMolecularFormulaResource1" />
                                    </td>
                                   
                                    <td>
                                        <asp:TextBox ID="tbxMolecularFormula" runat="server" MaxLength="50" 
                                            meta:resourcekey="tbxMolecularFormulaResource1" />
                                    </td>
                                </tr>
                                <tr>
                                 <td>
                                       <asp:Label ID="lblCasNo" runat="server" 
                                            meta:resourcekey="lblCasNoResource1" />
                                    </td>
                                    <td colspan ="3">
                                        <asp:TextBox ID="tbxCasNo" runat="server" MaxLength="50"  
                                            meta:resourcekey="tbxCasNoResource1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align ="right">
                            <asp:NewButton ID="btnSearch" runat="server"  Width ="60px" Text ="<%$ Resources:globalResource,SearchText %>" 
                                onclick="btnSearch_Click"/>&nbsp;
                         
                            <asp:NewButton ID="btnNew" runat="server"  Width ="60px"  Text ="<%$ Resources:globalResource,NewText %>" 
                                OnClientClick ="return makeWindow('NEW','')" />
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
                <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                    AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"
                    meta:resourcekey="GVListResource1"
                     onsorting="GVList_Sorting">
                  <Columns>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <a href="javascipt:void(0)" 
                                onclick='return makeWindow("EDIT","<%# Eval("InjurantId") %>")'>
                                 <asp:Label ID="lblEdit" runat="server" meta:resourcekey="lblEditResource1" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression ="injurant_type_desc" meta:resourcekey="TemplateFieldResource2">
                        <ItemTemplate>
                             <%# Eval("InjurantTypeItem.InjurantTypeDesc")%>
                        </ItemTemplate>
                     </asp:TemplateField> 
                    <asp:BoundField  DataField ="InjurantDescCn"  SortExpression ="injurant_desc_cn"
                          meta:resourcekey="BoundFieldResource1" />
                     <asp:BoundField  DataField ="InjurantDescEn"  SortExpression ="injurant_desc_en"
                          meta:resourcekey="BoundFieldResource2" />
                     <asp:BoundField  DataField ="MolecularFormula" SortExpression ="molecular_formula"
                          meta:resourcekey="BoundFieldResource3"  />
                     <asp:BoundField  DataField ="CasNo" SortExpression ="cas_no"
                         meta:resourcekey="BoundFieldResource4"   />
                     <asp:BoundField  DataField ="MainPurpose" SortExpression ="main_purpose"
                          meta:resourcekey="BoundFieldResource5" />
                  </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td  style ="padding-top:10px">
                <webdiyer:AspNetPager ID="PagerNavigator" runat="server" onpagechanged="PagerNavigator_PageChanged" />
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