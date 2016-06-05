<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTBomCoorpatternEdit.aspx.cs" Inherits="WaveLab.Web.SMTBomCoorPatternEdit" Title="无标题页"  meta:resourcekey="PageResource1"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
  <table style=" text-align:left ;"   width="100%" cellpadding="5">
   <tr>
   <td>
        <fieldset>
             <table  width="100%" class="form-table">
                <tr>
                    <td><asp:Label ID="lblModule" runat="server"  ForeColor ="Red"
                            meta:resourcekey="lblModuleResource1"/></td>
                    <td>
                       <asp:Label ID="lblModuleInfo" runat="server" ForeColor="Blue" 
                            meta:resourcekey="lblModuleInfoResource1" />
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblBomDn" runat="server"  ForeColor ="Red"
                            meta:resourcekey="lblBomDnResource1"/>
                    </td>
                    <td>
                        <asp:Label ID="lblBomDnInfo" runat="server" ForeColor="Blue" 
                            meta:resourcekey="lblBomDnInfoResource1" />
                    </td>
		        </tr>
		        <tr>
                    <td>
                        <asp:Label ID ="lblBomDvs" runat ="server"  ForeColor ="Red"
                            meta:resourcekey="lblBomDvsResource1" />
                    </td>
                    <td>
                       <asp:Label ID="lblBomDvsInfo" runat="server" ForeColor="Blue" 
                            meta:resourcekey="lblBomDvsInfoResource1" />
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblCoorPattern" runat="server" 
                            meta:resourcekey="lblCoorPatternResource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxCoorPattern" runat="server" Width="400" 
                             meta:resourcekey="tbxCoorPatternResource1" />
                    </td>
                 </tr>
                 <tr>
                    <td valign ="top"><asp:Label ID="lblComments" runat="server" 
                            meta:resourcekey="lblCommentsResource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxComments" runat="server"  TextMode ="MultiLine"  Rows="5" Width="400" 
                             meta:resourcekey="tbxCommentsResource1" />
                    </td>
                </tr>
          </table>
        </fieldset>
    </td>
   </tr>
   <tr>
        <td align ="right">
          <br />
          <asp:NewButton ID="btnSave" runat="server" Width ="80px"  Text ="<%$ Resources:globalResource,SaveText %>"
               OnClientClick="return verify()" onclick="btnSave_Click"/>
          &nbsp;
          <asp:NewButton ID="btnDelete" runat ="server"  Width ="80px" Text ="<%$ Resources:globalResource,DeleteText %>"
               onclick="btnDelete_Click"/>
          &nbsp;
          <asp:NewButton ID="btnCancel" runat ="server"   Width ="80" Text ="<%$ Resources:globalResource,CancelText %>"
            OnClientClick="return cancel()"/>
        </td>
   </tr>
  </table>
</center>
</asp:Content>