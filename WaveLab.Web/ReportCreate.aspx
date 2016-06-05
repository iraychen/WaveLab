<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ReportCreate.aspx.cs" Inherits="WaveLab.Web.ReportCreate" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="ctHead" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var reportGroup=$("#<%=ddlReportGroup.ClientID %>");
    var title=$("#<%=tbxTitle.ClientID %>");
    if (trim(reportGroup.val()).length == 0)
    {
        alert($("#<%=lblReportGroupMsg.ClientID %>").attr("title"));
      reportGroup.focus();
      return false;
    }
    if (trim(title.val()).length == 0) {
        alert($("#<%=lblTitleMsg.ClientID %>").attr("title"))
        title.focus();
        return false;
    }
    return true;
}

</script>
</asp:Content>
<asp:Content ID="ctMain" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
   <table style=" text-align:left;"  width="100%" cellpadding="5">
    <tr>
    <td>
        <fieldset>
         <table  width="100%" class="form-table">
            <tr>
                <td style ="width:50px"><asp:Label ID="lblReportGroup" runat="server"  ForeColor="Red"
                        meta:resourcekey="lblReportGroupResource1" /></td>
                <td style ="width:450px" colspan="3">                             
                   <asp:DropDownList ID="ddlReportGroup" runat="server" 
                        meta:resourcekey="ddlReportGroupResource1"></asp:DropDownList>
                         <asp:Label ID="lblReportGroupMsg" runat="server" 
                         meta:resourcekey="lblReportGroupMsgResource1" />
                </td>
            </tr>         
            <tr>
                <td>
                    <asp:Label ID ="lblTitle" runat ="server" ForeColor="Red"
                    meta:resourcekey="lblTitleResource1" ></asp:Label>
                      <asp:Label ID="lblTitleMsg" runat="server" 
                         meta:resourcekey="lblTitleMsgResource1" />
                </td>
                <td colspan ="3">
                    <asp:TextBox ID ="tbxTitle" runat ="server" Width ="300px" 
                        meta:resourcekey="tbxTitleResource1" ></asp:TextBox>
                      <asp:Label ID="Label1" runat="server" 
                         meta:resourcekey="lblTitleMsgResource1" />
                </td>
            </tr>
            <tr>
                <td><asp:Label ID ="lblUrl" runat="server" 
                       meta:resourcekey="lblUrlResource1" /></td>
                <td colspan ="3">
                      <asp:TextBox ID="tbxUrl" runat="server" MaxLength="200" Width="300px" 
                          meta:resourcekey="tbxUrlResource1"></asp:TextBox>
                         
                </td>
            </tr>
            
         </table>
      </fieldset>
    </td>
   </tr>
   <tr>
    <td align ="right">
       <br />
      <asp:Button ID="btnSave" runat="server"  Width ="80px"   Text ="<%$ Resources:globalResource,SaveText %>"
            OnClientClick="return verify()" onclick="btnSave_Click" 
            meta:resourcekey="btnSaveResource1"/>
      &nbsp;
      <asp:Button ID="btnCancel" runat ="server" Width ="80px"  Text ="<%$ Resources:globalResource,CancelText %>"
            OnClientClick="return cancel()" meta:resourcekey="btnCancelResource1" />
    </td>
    </tr>
  </table>
 
  
</center>
</asp:Content>
