<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ReportIndex.aspx.cs" Inherits="WaveLab.Web.ReportIndex" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

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
        case "Create":
            url="ReportCreate.aspx?backlink="+$("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "Edit":
            url = "ReportEdit.aspx?ReportPK=" + value + "&backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break ;
        default:
            break;
    }
    var winparas="toolbar=0,status=0,scrollbars=1,resizable=0,width=600px,Height=400px";
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
    <table width ="100%" style="text-align:left" border ="0" cellpadding="0" cellspacing ="0">
       <tr>
            <td align ="right">
             <asp:Button ID="btnNew" runat="server"  Width ="60px" Text ="<%$ Resources:globalResource,NewText %>"
                  OnClientClick ="return makeWindow('Create','')"  /><br/>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblRecCount" runat="server" 
                    meta:resourcekey="lblRecCountResource1" /></td>
        </tr>
        <tr>
            <td>
                  <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                    AutoGenerateColumns="False"  Width ="800px"
                    meta:resourcekey="GVListResource1"  DataKeyNames="ReportPK"
                     onsorting="GVList_Sorting"  onrowdatabound="GVList_RowDataBound" 
                      onrowdeleting="GVList_RowDeleting" >
                      <Columns>
                         <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="a.Group_Code" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="lblReportGroup" runat="server" 
                                    Text= '<%# Eval("ReportGroup.Descript") %>' 
                                    meta:resourcekey="lblReportGroupResource1"/>
                            </ItemTemplate>
                         </asp:TemplateField>
                          <asp:BoundField   DataField="Title" SortExpression ="a.Title" HeaderStyle-Width="200"
                              meta:resourcekey="BoundFieldResource1"/>
                          <asp:BoundField   DataField="Url" SortExpression ="a.Url" 
                              meta:resourcekey="BoundFieldResource2"/>
                         <asp:TemplateField meta:resourcekey="TemplateFieldResource2"  HeaderStyle-Width="100">
                            <ItemTemplate>
                                 <asp:LinkButton ID="lbtEdit" runat ="server"  meta:resourcekey="lbtEditResource1" />
                                 <asp:LinkButton ID="lbtDelete" runat ="server" CommandName="Delete"  meta:resourcekey="lbtDeleteResource1" />
                            </ItemTemplate>
                         </asp:TemplateField>                       
                      </Columns>
                   </asp:GridView>
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
