<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTPCBSteelMeshNew.aspx.cs" Inherits="WaveLab.Web.SMTPCBSteelMeshNew" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready(function()
{
 $(".date").datepicker({
   showOn:"button",
   buttonImageOnly:true,
   dateFormat:"yy-mm-dd",
   changeYear:true,
   changeMonth:true
 });
 
 $(".date").mask("9999-99-99",{});
 
 $("input:submit").button();
});
function verify()
{
    var pcb=$("#<%=tbxPCB.ClientID %>");
    var steelmesh=$("#<%=tbxSteelMesh.ClientID %>");
    var facturedate=$("#<%=tbxFactureDate.ClientID %>");
    if(trim(pcb.val()).length==0)
    {
      alert($("#<%=lblPCBMsg.ClientID %>").attr("title"));
      pcb.focus();
      return false;
    }
    if(trim(steelmesh.val()).length==0)
    {
      alert($("#<%=lblSteelMeshMsg.ClientID %>").attr("title"));
      steelmesh.focus();
      return false;
    }
    
    if(checkDate(facturedate.val())==false)
    {
      alert($("#<%=lblDateFormatMsg.ClientID %>").attr("title"));
      facturedate.focus();
      return false;
    }
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
  <table style=" text-align:left ;"  width="100%" cellpadding="5">
   <tr>
       <td>
          <fieldset>
             <table width="100%" class="form-table">
                <tr>
                    <td><asp:Label ID="lblPCB" runat="server"  ForeColor ="Red"
                            meta:resourcekey="lblPCBResource1"/></td>
                    <td>
                       <asp:TextBox ID="tbxPCB" runat="server" MaxLength="40" Width="400" 
                            meta:resourcekey="tbxPCBResource1" />
                            <asp:Label ID="lblPCBMsg" runat="server" 
                            meta:resourcekey="lblPCBMsgResource1"/>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblSteelMesh" runat="server"  ForeColor ="Red"
                            meta:resourcekey="lblSteelMeshResource1"/>
                            
                            </td>
                    <td>
                         <asp:TextBox ID="tbxSteelMesh" runat="server" MaxLength="50" Width="400" 
                             meta:resourcekey="tbxSteelMeshResource1" />
                        <asp:Label ID="lblSteelMeshMsg" runat="server" 
                            meta:resourcekey="lblSteelMeshMsgResource1"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID ="lblFactureDate" runat ="server" 
                            meta:resourcekey="lblFactureDateResource1" />
                    </td>
                    <td valign="middle">
                        <asp:TextBox ID ="tbxFactureDate" runat ="server"  MaxLength ="10"  CssClass ="date"
                            Width ="80px" meta:resourcekey="tbxFactureDateResource1"/>
                        <asp:Label ID="lblDateFormat" runat ="server"   Text ="<%$Resources:globalResource,DateFormat%>" /> 
                        <asp:Label ID="lblDateFormatMsg" runat ="server"   ToolTip ="<%$Resources:globalResource,DateFormatMsg%>" />
                    </td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lblSerielNo" runat="server" 
                            meta:resourcekey="lblSerielNoResource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxSerielNo" runat="server" Width="400" 
                             meta:resourcekey="tbxSerielNoResource1" />
                    </td>
                 </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblDocumentNo" runat="server" 
                            meta:resourcekey="lblDocumentNoResource1" />
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxDocumentNo"  runat ="server" MaxLength ="20" Width="400" 
                            meta:resourcekey="tbxDocumentNoResource1" />
                    </td>
                </tr>
                 <tr>
                    <td valign ="top"><asp:Label ID="lblComments" runat="server" 
                            meta:resourcekey="lblCommentsResource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxComments" runat="server"  TextMode ="MultiLine"  Rows="5" Width ="400"
                             meta:resourcekey="tbxCommentsResource1" />
                    </td>
                </tr>
                <tr>
                    <td valign ="top"><asp:Label ID="lblDefect" runat="server" 
                            meta:resourcekey="lblDefectResource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxDefect" runat="server"  TextMode ="MultiLine"  Rows="5" Width ="400"
                             meta:resourcekey="tbxDefectResource1" />
                    </td>
                </tr>
              </table>
          </fieldset>  
      </td>
   </tr>
   <tr>
        <td align="right">
            <br />
            <asp:NewButton  ID="btnSave" runat="server"  Width ="80" Text ="<%$ Resources:globalResource,SaveText %>"
                OnClientClick="return verify()" onclick="btnSave_Click"/>
            &nbsp;
            <asp:NewButton ID="btnCancel" runat ="server"  Width ="80" Text ="<%$ Resources:globalResource,CancelText %>"
                OnClientClick="return cancel()" />
        </td>
    </tr>
  </table>
</center>
</asp:Content>