﻿<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSSectionEdit.aspx.cs" Inherits="WaveLab.Web.SYSSectionEdit" Title="无标题页"  meta:resourcekey="PageResource1"  %>
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
  <table style=" text-align:left ;"  width="100%" cellpadding="5">
   <tr>
   <td>
        <fieldset>
         <table  width="100%" class="form-table">
            <tr>
                <td><asp:Label ID="lblSectionId" runat="server"   ForeColor="Red"
                        meta:resourcekey="lblSectionIdResource1"/></td>
                <td >
                   <asp:Label ID="lblSectionIdInfo" runat="server"  ForeColor ="Blue"
                        meta:resourcekey="lblSectionIdInfoResource1" />
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblSectionDesc" runat="server" 
                        meta:resourcekey="lblSectionDescResource1"/></td>
                <td>
                     <asp:TextBox ID="tbxSectionDesc" runat="server" MaxLength="50" Width="300" 
                         meta:resourcekey="tbxSectionDescResource1" />
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
