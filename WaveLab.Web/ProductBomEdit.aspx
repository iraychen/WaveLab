<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ProductBomEdit.aspx.cs" Inherits="WaveLab.Web.ProductBomEdit" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
$(document).ready(function()
{
    $(".mask_pnum").keyfilter(/[\d\.]/);
    
    $("input:submit").button();
});
function verify()
{
    var supplierName=$("#<%=tbxSupplierName.ClientID %>");
    var amount=$("#<%=tbxAmount.ClientID %>");
    if(trim(supplierName.val()).length==0)
    {
      alert($("#<%=lblSupplierNameMsg.ClientID %>").attr("title"));
      supplierName.focus();
      return false;
    }
    
     if(trim(amount.val()).length==0)
    {
      alert($("#<%=lblAmountMsg.ClientID %>").attr("title"));
      amount.focus();
      return false;
    }
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
  <table style=" text-align:left;width:600px">
    <tr>
        <td>
           <br />
           <asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" 
             meta:resourcekey="lblTitleResource" /><br />
           <br />
        </td>
    </tr>
   <tr>
   <td>
      <fieldset>
          <table  width="100%" class="form-table" >
            <tr>
                <td style ="width:100">
                    <asp:Label ID="lblProduct" runat="server" ForeColor ="Red"
                        meta:resourcekey="lblProductResource1" />
                </td>
                <td>
                    <asp:Label ID ="lblProductDesc" runat ="server"  ForeColor ="Blue"
                        meta:resourcekey="lblProductDescResource1" />
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
                    <asp:Label ID="lblMaterialCode" runat="server"  ForeColor ="Red"
                        meta:resourcekey="lblMaterialCodeResource1" />
                </td>
                <td>
                    <asp:Label ID ="lblMaterialCodeInfo" runat ="server" ForeColor ="Blue"
                        meta:resourcekey="lblMaterialCodeInfoResource1" />
                </td>
            </tr>
            <tr>
                 <td>
                    <asp:Label ID="lblMaterialDesc" runat="server"  ForeColor ="Red"
                        meta:resourcekey="lblMaterialDescResource1" />
                </td>
                <td>
                   <asp:Label ID ="lblMaterialDescInfo" runat ="server" ForeColor ="Blue"
                        meta:resourcekey="lblMaterialDescInfoResource1" />
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Label ID="lblSupplierName" runat="server"  ForeColor ="Red"
                        meta:resourcekey="lblSupplierNameResource1" />
                </td>
                <td>
                    <asp:TextBox ID="tbxSupplierName" runat="server" MaxLength="50" Width ="400"
                        meta:resourcekey="tbxSupplierNameResource1" />
                    <asp:Label ID ="lblSupplierNameMsg" runat ="server" 
                        meta:resourcekey="lblSupplierNameMsgResource1" />
                </td>
            </tr>

              <tr>
                 <td>
                   <asp:Label ID="lblAmount" runat="server" ForeColor ="Red"
                        meta:resourcekey="lblAmountResource1" />
                </td>
                <td>
                     <asp:TextBox ID="tbxAmount" runat="server" MaxLength="50"   CssClass="mask_pnum" Width="100"
                        meta:resourcekey="tbxAmountResource1" />
                    <asp:Label ID ="lblAmountMsg" runat ="server" 
                        meta:resourcekey="lblAmountMsgResource1" />
                </td>
            </tr>
            <tr>
                 <td>
                    <asp:Label ID ="lblSYSModuleType" runat ="server" 
                        meta:resourcekey="lblSYSModuleTypeResource1" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlSYSModuleType" runat ="server" 
                        meta:resourcekey="ddlSYSModuleTypeResource1" />
                </td>
            </tr>
              <tr>
                <td valign ="top"><asp:Label ID="lblComment" runat="server" 
                        meta:resourcekey="lblCommentResource1"/></td>
                <td >
                     <asp:TextBox ID="tbxComment" runat="server"  TextMode ="MultiLine"  Rows="5" Width ="400" MaxLength ="100"
                         meta:resourcekey="tbxCommentResource1" />
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
