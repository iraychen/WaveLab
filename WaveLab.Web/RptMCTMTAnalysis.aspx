<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RptMCTMTAnalysis.aspx.cs" Inherits="WaveLab.Web.RptMCTMTAnalysis" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    return true ;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<div >
    <br /><br />
    <center>
    <asp:Label ID="lblTitle" runat="server" SkinId="skinRptTitle"
            meta:resourcekey="lblTitleResource1"></asp:Label><br/><br/>
    <table cellSpacing="0" cellPadding="20" border="1" width ="400">
        <tr>
        <td>
        <table class ="report-table" style =" text-align:left; width:80%"   >
            <tr>
                 <td style ="width:80px">
                   <asp:Label ID="lblProduct" runat="server" 
                        meta:resourcekey="lblProductResource1" />
                </td>
                <td>
                    <asp:DropDownList ID ="ddlProduct" runat="server" 
                        meta:resourcekey="ddlProductResource1" />
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Label ID="lblMaterialType" runat="server" 
                        meta:resourcekey="lblMaterialTypeResource1" />
                </td>
                <td>
                     <asp:DropDownList ID ="ddlMaterialType" runat="server" 
                        meta:resourcekey="ddlMaterialTypeResource1" />
                </td>
            </tr>
           <tr>
                <td>
                    <asp:Label ID ="lblExportType" runat ="server" 
                        meta:resourcekey="lblExportTypeResource1" />
                </td>
                <td>
                    <asp:DropDownList ID ="ddlExportType" runat ="server" 
                        meta:resourcekey="ddlExportTypeResource1">
                         <asp:ListItem meta:resourcekey="ListItemResource1"></asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        </td>
        </tr>
    </table>
    <br/>
    <asp:NewButton id="btnSubmit" Runat="server" Width="100px"  
            OnClientClick ="return verify()" meta:resourcekey="btnSubmitResource1" 
            onclick="btnSubmit_Click"/>&nbsp;
    <asp:NewButton ID="btnReset" runat="server" Width ="100px" 
            OnClientClick ="return formReset()" meta:resourcekey="btnResetResource1"/>
</center>
</div>
</asp:Content>
