<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSMenuEdit.aspx.cs" Inherits="WaveLab.Web.SYSMenuEdit" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="ctHead" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var itemDesc=$("#<%=tbxMenuDesc.ClientID %>");
    var menuItem=$("#<%=rbtMenuItem.ClientID %>");
    var url=$("#<%=tbxUrl.ClientID %>");
    if(trim(itemDesc.val()).length==0)
    {
      alert($("#<%=lblMenuDescMsg.ClientID %>").attr("title"));
      itemDesc.focus();
      return false;
    }
    if(menuItem.attr("checked")==true)
    {
        if(trim(url.val()).length==0)
        {
         alert($("#<%=lblUrlMsg.ClientID %>").attr("title"))
         url.focus();
         return false;
        }
    }
    return true;
}

function selectItemType()
{
    var subMenu=$("#<%=rbtSubMenu.ClientID %>");
    var menuItem=$("#<%=rbtMenuItem.ClientID %>");
    var urlRow=$("#<%=urlRow.ClientID %>");
    var imageUrlRow=$("#<%=imageUrlRow.ClientID %>")
    
    if(subMenu.attr("checked")==true)
    {
        urlRow.hide();
        imageUrlRow.hide();
    }
    else
    {
        urlRow.show();
        imageUrlRow.show();
    }
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
                    <td style ="width:50px"><font color="red"><asp:Label ID="lblMenuDesc" runat="server" 
                            meta:resourcekey="lblMenuDescResource1" /></font></td>
                    <td style ="width:450px" colspan="3">
                       <asp:TextBox ID="tbxMenuDesc" runat="server" MaxLength="50" width="300" 
                            meta:resourcekey="tbxMenuDescResource1"></asp:TextBox>
                            <asp:Label ID="lblMenuDescMsg" runat="server" 
                            meta:resourcekey="lblMenuDescMsgResource1" />
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblParent" runat="server" 
                            meta:resourcekey="lblParentResource1" /></td>
                    <td colspan="3">
                       <asp:DropDownList ID="ddlParent" runat="server" 
                            meta:resourcekey="ddlParentResource1"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label id="lblEnabled" runat ="server" 
                            meta:resourcekey="lblEnabledResource1"/></td>
                    <td colspan ="3">
                         <asp:DropDownList ID="ddlEnabled" runat="server" Width="80px" 
                             meta:resourcekey="ddlEnabledResource1">
                              <asp:ListItem Value="Y" meta:resourcekey="ListItemResource1">Y</asp:ListItem>
                              <asp:ListItem Value="N" meta:resourcekey="ListItemResource2">N</asp:ListItem>
                         </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblMenuType" runat ="server"  meta:resourcekey="lblMenuTypeResource1"/></td>
                    <td colspan="3">
                        <asp:RadioButton ID="rbtMenuItem" runat="server"  GroupName="MenuItem" 
                            onclick="selectItemType()"  Checked="True" meta:resourcekey="rbtMenuItemResource1"/>
                        <asp:RadioButton ID="rbtSubMenu" runat="server"  GroupName="MenuItem" 
                            onclick="selectItemType()" meta:resourcekey="rbtSubMenuResource1"/>
                    </td>
                </tr>
                <tr id="urlRow" runat ="server">
                    <td><asp:Label ID ="lblUrl" runat="server" 
                           meta:resourcekey="lblUrlResource1" /></td>
                    <td colspan ="3">
                          <asp:TextBox ID="tbxUrl" runat="server" MaxLength="100" Width="300" 
                              meta:resourcekey="tbxUrlResource1"></asp:TextBox>
                               <asp:Label ID="lblUrlMsg" runat="server" 
                             meta:resourcekey="lblUrlMsgResource1" />
                    </td>
                </tr>
                <tr id="imageUrlRow" runat ="server">
                    <td>
                        <asp:Label ID ="lblImageUrl" runat ="server" meta:resourcekey="lblImageUrlResource1" ></asp:Label>
                    </td>
                    <td colspan ="3">
                        <asp:TextBox ID ="tbxImageUrl" runat ="server" Width ="300" meta:resourcekey="tbxImageUrlResource1" ></asp:TextBox>
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
                Action ="MenuEdit" OnClientClick="return verify()" onclick="btnSave_Click"/>
          &nbsp;
          <asp:NewButton ID="btnDelete" runat ="server"  Width ="80px"  Text ="<%$ Resources:globalResource,DeleteText %>"
                Action ="MenuDelete"  onclick="btnDelete_Click"/>
           &nbsp;
          <asp:NewButton ID="btnCancel" runat ="server" Width ="80"  Text ="<%$ Resources:globalResource,CancelText %>"
            OnClientClick="return cancel()" />
      </td>
   </tr>
  </table>
</center>
</asp:Content>