<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ProductNew.aspx.cs" Inherits="WaveLab.Web.ProductNew" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var productDesc=$("#<%=tbxProductDesc.ClientID %>");
    if(trim(productDesc.val()).length==0)
    {
      alert($("#<%=lblProductDescMsg.ClientID %>").attr("title"));
      productDesc.focus();
      return false;
    }
    return true;
}

function goBack()
{
    self.location.href="ProductCtl.aspx";
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<asp:ImageButton ID="imgBtnBack" runat ="server" SkinID ="imgBtnSkinBack"  
         OnClientClick ="return goBack()" meta:resourcekey="imgBtnBackResource1"/>
<center>
     <br />
   <asp:Label ID ="Label1" runat="server"  SkinID ="skinCTitle" 
     meta:resourcekey="lblTitleResource" /><br />
   <br />
 
  <table style=" text-align:left ;"  width="350px">
   <tr>
   <td>
     <table  width="100%" class="setup-table">
        <tr>
            <td><asp:Label ID="lblProductDesc" runat="server"  ForeColor ="Red"
                    meta:resourcekey="lblProductDescResource1"/></td>
            <td>
                 <asp:TextBox ID="tbxProductDesc" runat="server" MaxLength="50" width="200px" 
                     meta:resourcekey="tbxProductDescResource1" />
                  <asp:Label ID="lblProductDescMsg" runat="server" 
                    meta:resourcekey="lblProductDescMsgResource1"/>
            </td>
        </tr>
  </table>
        
    </td>
   </tr>
  </table>
 
  <br />
  <br />
  <asp:NewButton ID="btnSave" runat="server"  
        OnClientClick="return verify()"  ButtonType ="new"
        Width ="80" meta:resourcekey="btnSaveResource1" onclick="btnSave_Click"/>
  &nbsp;
  <asp:NewButton ID="btnReset" runat ="server" 
        OnClientClick="return formReset()"  Width ="80" 
        meta:resourcekey="btnResetResource1"/>
</center>
</asp:Content>