<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="rptConsignProcessExport.aspx.cs" Inherits="WaveLab.Web.rptConsignProcessExport" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var Aufnr=$("#<%=tbxAufnr.ClientID %>");
    if(trim(Aufnr.val()).length==0)
    {
        alert($("#<%=lblAufnrReqMsg.ClientID %>").attr("title"));
        return false;
    }
    if(trim(Aufnr.val()).length>12)
    {
        alert($("#<%=lblAufnrLengthMsg.ClientID %>").attr("title"));
        return false;
    }
    return true ;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<div style="z-index:98;">
 <br /><br />
<center>
    <asp:Label ID="lblTitle" runat="server" SkinId="skinRptTitle"
            meta:resourcekey="lblTitleResource1"></asp:Label><br/><br/>
    <table cellSpacing="0" cellPadding="20" border="1"  width ="400">
        
        <tr>
            <td>
                <table  class ="report-table" width="100%"  >
                   
                    <tr>
                         <td>
                            <asp:Label ID="lblAufnr" runat="server"  ForeColor ="Red"
                                meta:resourcekey="lblAufnrResource1" />
                        </td>
                        <td>
                             <asp:TextBox ID="tbxAufnr" runat="server" MaxLength="12"  Width ="200px"
                                meta:resourcekey="tbxAufnrResource1" />
                             <ajaxToolkit:FilteredTextBoxExtender ID ="ftbextAufnr" runat ="server"  FilterType ="Numbers" TargetControlID ="tbxAufnr"/>
                             <asp:Label ID="lblAufnrReqMsg" runat ="server" 
                                 meta:resourcekey="lblAufnrReqMsgResource1" />
                             <asp:Label ID ="lblAufnrLengthMsg" runat ="server" 
                                 meta:resourcekey="lblAufnrLengthMsgResource1" />
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
                                <asp:ListItem meta:resourcekey="ListItemResource1">Excel</asp:ListItem>
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
