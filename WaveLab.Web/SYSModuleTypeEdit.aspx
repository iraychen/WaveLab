<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSModuleTypeEdit.aspx.cs" Inherits="WaveLab.Web.SYSModuleTypeEdit" Title="无标题页"  meta:resourcekey="PageResource1"  %>

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
                    <td><font color="red"><asp:Label ID="lblSYSModuleType" runat="server" 
                            meta:resourcekey="lblSYSModuleTypeResource1"/></font></td>
                    <td >
                       <asp:Label ID="lblSYSModuleTypeInfo" runat="server"  ForeColor ="Blue"
                            meta:resourcekey="lblSYSModuleTypeInfoResource1" />
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblModuleTypeDesc" runat="server" 
                            meta:resourcekey="lblModuleTypeDescResource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxModuleTypeDesc" runat="server" MaxLength="50" width="300px" 
                             meta:resourcekey="tbxSYSModuleTypeResource1" />
                    </td>
                </tr>
                       <tr>
                    <td><asp:Label ID="lblHasGenBoard" runat="server" 
                            meta:resourcekey="lblHasGenBoardResource1"/></td>
                    <td>
                         <asp:CheckBox ID="cbxHasGenBoard" runat="server" />
                    </td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lblHasSpeBoard" runat="server" 
                            meta:resourcekey="lblHasSpeBoardResource1"/></td>
                    <td>
                         <asp:CheckBox ID="cbxHasSpeBoard" runat="server"  />
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblHasSMTFabrication" runat="server" 
                            meta:resourcekey="lblHasSMTFabricationResource1"/></td>
                    <td>
                         <asp:CheckBox ID="cbxHasSMTFabrication" runat="server" />
                    </td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lblHasComponentPart" runat="server" 
                            meta:resourcekey="lblHasComponentPartResource1"/></td>
                    <td>
                         <asp:CheckBox ID="cbxHasComponentPart" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblHasGroupPart" runat="server" 
                            meta:resourcekey="lblHasGroupPartResource1"/></td>
                    <td>
                         <asp:CheckBox ID="cbxHasGroupPart" runat="server"/>
                    </td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lblHasBondingFabrication" runat="server" 
                            meta:resourcekey="lblHasBondingFabricationResource1"/></td>
                    <td>
                         <asp:CheckBox ID="cbxHasBondingFabrication" runat="server"/>
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
