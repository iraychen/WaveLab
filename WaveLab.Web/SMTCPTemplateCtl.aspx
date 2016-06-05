<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTCPTemplateCtl.aspx.cs" Inherits="WaveLab.Web.SMTCPTemplateCtl" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function redirect(mode,value)
{
    var url;
    switch(mode)
    {
        case "NEW":
            url="SMTCPTemplateNew.aspx";
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
<table >
	<tr>
		<td><asp:Image ID ="imgTitle" runat="server" SkinID ="ImgskinTitle" 
			meta:resourcekey="imgTitleResource1" /></td>
		<td valign="bottom"><asp:Label ID ="lblTitle" runat="server"  SkinID ="skinTitle" 
			meta:resourcekey="lblTitleResource1" /></td>
	</tr>
</table>
<center>
<table width ="800" style="text-align:left" border ="0" cellpadding="0" cellspacing ="0">
        <tr>
            <td colspan ="2" valign ="bottom" align ="right">
                <asp:NewButton ID="btnNew" runat="server"  Width ="60"  
                     meta:resourcekey="btnNewResource1" OnClientClick ="return redirect('NEW','')" />
            </td>
        </tr>
        <tr>
            <td align ="center" colspan ="2"><br /><asp:Label ID="lblRecCount" runat="server" 
                    meta:resourcekey="lblRecCountResource1" /></td>
        </tr>
        <tr>
            <td  colspan ="2">
                <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   EnableViewState ="true"
                    AutoGenerateColumns="False"   DataKeyNames="effectivedate,documentpath" 
                    meta:resourcekey="GVListResource1" onsorting="GVList_Sorting"  SkinID ="skinGridView"
                    onrowdatabound="GVList_RowDataBound" onrowcommand="GVList_RowCommand" onrowdeleting="GVList_RowDeleting" 
                    >
                  <Columns>
                     <asp:BoundField   DataField="EffectiveDate"  DataFormatString="{0:yyyy-MM-dd}" SortExpression ="effective_date"
                          meta:resourcekey="BoundFieldResource1"/>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
					    <ItemTemplate>
					        <asp:LinkButton ID="lbtView" runat="server"  CommandName ="view"   CommandArgument ='<%#Eval("documentpath") %>'
                                meta:resourcekey="lbtViewResource1" />
					    </ItemTemplate>
					 </asp:TemplateField>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource2" >
					    <ItemTemplate>
					        <asp:LinkButton ID="lbtDelete" runat="server"  CommandName ="delete" 
                                meta:resourcekey="lbtDeleteResource1" />
					    </ItemTemplate>
					 </asp:TemplateField>
                  </Columns>
                </asp:GridView>
              <br />
            </td>
        </tr>
       
    </table>
</center>
</asp:Content>

