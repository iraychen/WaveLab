<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTFileInducePCB.aspx.cs" Inherits="WaveLab.Web.SMTFileInducePCB" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
    var pcb=$("#<%=tbxPCB.ClientID %>");
    if(trim(pcb.val()).length==0)
    {
      alert($("#<%=lblPCBMsg.ClientID %>").attr("title"));
      pcb.focus();
      return false;
    }
    return true;
}

function goBack()
{
    self.location.href='<%=System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) %>';
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<asp:ImageButton ID="imgBtnBack" runat ="server" SkinID ="imgBtnSkinBack"  
         OnClientClick ="return goBack()" meta:resourcekey="imgBtnBackResource1"/>
<center>
    <table>
        <tr>
            <td align="center">
               <br />
               <asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" 
                 meta:resourcekey="lblTitleResource1" /><br />
               <br />
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                  <table style=" text-align:left ;"  class="form-table" cellpadding ="5">
                  <tr>
                        <td><asp:Label ID="lblSYSModuleType" runat="server"  meta:resourcekey="lblSYSModuleTypeResource1"/></td>
                        <td>
                            <asp:DropDownList ID="ddlSYSModuleType" runat="server" />
                        </td>
                  </tr>
                   <tr>
                        <td><asp:Label ID="lblPCB" runat="server" ForeColor="Red" 
                                meta:resourcekey="lblPCBResource1" /></td>
                        <td>
                            <asp:TextBox ID="tbxPCB" runat="server"  MaxLength ="40"  Width ="250px"
                                meta:resourcekey="tbxPCBResource1"/>
                            <asp:Label ID="lblPCBMsg" runat="server" 
                                meta:resourcekey="lblPCBMsgResource1" />
                        </td>
                        
                   </tr>
                  </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td align="center">
               <br />
              <asp:NewButton ID="btnSearch" runat="server"   
                    OnClientClick="return verify()"  
                    Width ="80" meta:resourcekey="btnSearchResource1" onclick="btnSearch_Click" />
              &nbsp;
              <asp:NewButton ID="btnReset" runat ="server"  
                    OnClientClick="return formReset()"  Width ="80" 
                    meta:resourcekey="btnResetResource1"/>
            </td>
        </tr>
    </table>
</center>
</asp:Content>
