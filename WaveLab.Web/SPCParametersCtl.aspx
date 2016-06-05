<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCParametersCtl.aspx.cs" Inherits="WaveLab.Web.SPCParametersCtl" culture="auto" meta:resourcekey="PageResource2" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
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
           <td align ="right">
                <asp:NewButton ID="btnExport" runat="server"  Width ="80px"  
                    meta:resourcekey="btnExportResource1" onclick="btnExport_Click"  />&nbsp;
           </td>
        </tr>
        <tr>
            <td align ="center" colspan ="2"><asp:Label ID="lblRecCount" runat="server" 
                    meta:resourcekey="lblRecCountResource1" /></td>
        </tr>
        <tr>
            <td colspan ="2">
                <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                    AutoGenerateColumns="False"  Width ="100%" EnableViewState ="False"
                     meta:resourcekey="GVListResource1" >
                  <Columns>
                      <asp:BoundField  DataField ="N"   meta:resourcekey="BoundFieldResource1" />
                      <asp:BoundField  DataField ="A2"   meta:resourcekey="BoundFieldResource2" />
                      <asp:BoundField  DataField ="D2"   meta:resourcekey="BoundFieldResource3" />
                      <asp:BoundField  DataField ="D3"   meta:resourcekey="BoundFieldResource4" />
                      <asp:BoundField  DataField ="D4"   meta:resourcekey="BoundFieldResource5" />
                      <asp:BoundField  DataField ="A3"   meta:resourcekey="BoundFieldResource6" />
                      <asp:BoundField  DataField ="C4"   meta:resourcekey="BoundFieldResource7" />
                      <asp:BoundField  DataField ="B3"   meta:resourcekey="BoundFieldResource8" />
                      <asp:BoundField  DataField ="B4"   meta:resourcekey="BoundFieldResource9" />
                  </Columns>
                 
                </asp:GridView>
            </td>
        </tr>
    </table>
</center>
</asp:Content>
