<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RptMCTCount.aspx.cs" Inherits="WaveLab.Web.RptMCTCount" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
 <br /><br />
<center>
    <asp:Label ID="lblTitle" runat="server" SkinId="skinRptTitle"
            meta:resourcekey="lblTitleResource1"></asp:Label><br/><br/>
    <table cellSpacing="0" cellPadding="20" border="1"   width ="400" >
        <tr>
            <td align ="center">
                <table  class ="report-table" width="100%"  style ="text-align:left">
                    <tr>
                        <td>
                            <asp:Label ID ="lblProduct" runat ="server" 
                                meta:resourcekey="lblProductResource1" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProduct" runat ="server" 
                                meta:resourcekey="ddlProductResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <asp:Label ID="lblMaterialType" runat="server" 
                                meta:resourcekey="lblMaterialTypeResource1" />
                        </td>
                        <td>
                              <asp:DropDownList ID="ddlMaterialType" runat ="server" 
                                meta:resourcekey="ddlMaterialTypeResource1" />
                        </td>
                     </tr>
                     <tr>
                        <td>
                           <asp:Label ID="lblMaterialCode" runat="server" 
                                meta:resourcekey="lblMaterialCodeResource1" />
                        </td>
                        <td>
                           <asp:TextBox ID="tbxMaterialCode" runat ="server" MaxLength ="50" 
                                meta:resourcekey="tbxMaterialCodeResource1" Width="200px" />
                        </td>
                    </tr>
                    <tr>
                         <td>
                           <asp:Label ID="lblMaterialDesc" runat="server" 
                                meta:resourcekey="lblMaterialDescResource1" />
                        </td>
                       
                        <td>
                            <asp:TextBox ID="tbxMaterialDesc" runat="server" MaxLength="50" 
                                meta:resourcekey="tbxMaterialDescResource1" Width="200px" />
                        </td>
                    </tr>
                     <tr>
                         <td>
                           <asp:Label ID="lblSuplierName" runat="server" 
                                meta:resourcekey="lblSuplierNameResource1" />
                        </td>
                       
                        <td>
                            <asp:TextBox ID="tbxSuplierName" runat="server" MaxLength="50" 
                                meta:resourcekey="tbxSuplierNameResource1" Width="200px" />
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
             meta:resourcekey="btnSubmitResource1" 
            onclick="btnSubmit_Click"/>&nbsp;
    <asp:NewButton ID="btnReset" runat="server" Width ="100px" 
            OnClientClick ="return formReset()" meta:resourcekey="btnResetResource1"/>
            
</center>

</asp:Content>