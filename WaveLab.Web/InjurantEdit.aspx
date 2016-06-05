<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="InjurantEdit.aspx.cs" Inherits="WaveLab.Web.InjurantEdit" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var productDescCn=$("#<%=tbxInjurantDescCn.ClientID %>");
    var productDescEn=$("#<%=tbxInjurantDescEn.ClientID %>");
    var casNo=$("#<%=tbxCasNo.ClientID %>");
    
    if(trim(productDescCn.val()).length==0 && trim(productDescEn.val()).length==0 && trim(casNo.val()).length==0)
    {
      alert($("#<%=lblRequiredMsg.ClientID %>").attr("title"));
      return false;
    }
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">

<center>
  <table style=" text-align:left ; width:650px">
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
          <table  width="100%" class="form-table">
            <tr>
                <td>
                   <asp:Label ID="lblInjurantDescCn" runat="server"
                        meta:resourcekey="lblInjurantDescCnResource1" />
                </td>
            
                <td>
                    <asp:TextBox ID="tbxInjurantDescCn" runat="server" MaxLength="50" Width ="400"
                        meta:resourcekey="tbxInjurantDescCnResource1" />
                </td>
            </tr>
            <tr>
               <td>
                   <asp:Label ID="lblInjurantDescEn" runat="server"  
                        meta:resourcekey="lblInjurantDescEnResource1" />
                </td>
                <td>
                   <asp:TextBox ID="tbxInjurantDescEn" runat ="server" MaxLength ="100" Width ="400"
                        meta:resourcekey="tbxInjurantDescEnResource1" />
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Label ID="lblMolecularFormula" runat="server" 
                        meta:resourcekey="lblMolecularFormulaResource1" />
                </td>
                <td>
                    <asp:TextBox ID="tbxMolecularFormula" runat="server" MaxLength="50" Width ="400"
                        meta:resourcekey="tbxMolecularFormulaResource1" />
                </td>
             </tr>
            <tr>
                <td>
                   <asp:Label ID="lblCasNo" runat="server" 
                        meta:resourcekey="lblCasNoResource1" />
                </td>
                <td>
                    <asp:TextBox ID="tbxCasNo" runat="server" MaxLength="50" Width ="400"
                        meta:resourcekey="tbxCasNoResource1" />
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID ="lblInjurantType" runat ="server" 
                        meta:resourcekey="lblInjurantTypeResource1" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlInjurantType" runat ="server" 
                        meta:resourcekey="ddlInjurantTypeResource1" />
                </td>
            </tr>
              <tr>
                <td valign ="top"><asp:Label ID="lblMainPurpose" runat="server" 
                        meta:resourcekey="lblMainPurposeResource1"/></td>
                <td>
                     <asp:TextBox ID="tbxMainPurpose" runat="server"  TextMode ="MultiLine"  Rows="5" Width ="400" MaxLength ="100"
                         meta:resourcekey="tbxMainPurposeResource1" />
                </td>
            </tr>
          </table>
       </fieldset>
    </td>
   </tr>
   <tr>
    <td align ="right">
         <asp:Label ID="lblRequiredMsg" runat="server" 
                    meta:resourcekey="lblRequiredMsgResource1" />
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