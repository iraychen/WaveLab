<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSMenuOrder.aspx.cs" Inherits="WaveLab.Web.SYSMenuOrder" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

<script type="text/javascript" >
$(document).ready( function() {
	$("input:submit").button();
});
function checkSelect()
{
    var items=$("#<%=lbxItems.ClientID %>");
    if(items.val()==null)
    {
    alert($("#<%=lblItems.ClientID %>").attr("title"));
    return false;
    }
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
  <table cellpadding="5">
     <tr>
         <td >
            <table border ="0" cellpadding="0" cellspacing ="0"  style="text-align:left;">
                <tr>
                    <td><asp:Label ID="lblMenuPathTip" runat="server" 
                            meta:resourcekey="lblMenuPathTipResource1" />：
                    </td>
                    <td>
                       <asp:Label ID="lblMenuPath" runat="server" ForeColor="Blue" 
                            meta:resourcekey="lblMenuPathResource1" ></asp:Label>
                    </td>
                </tr>
            </table>
         </td>
     </tr>
     <tr height="25px">
        <td valign="top" align="left">
           <asp:Label ID="lblItems" runat="server" meta:resourcekey="lblItemsResource1" />
        </td>
     </tr>
     <tr>
        <td align="center">
           <table>
               <tr>
               <td>
                 <asp:UpdatePanel ID="uplItems" runat="server">
             <ContentTemplate>
                <asp:ListBox ID="lbxItems" runat="server" Rows="15"  Width="400px" 
                     meta:resourcekey="lbxItemsResource1"></asp:ListBox>
             </ContentTemplate>
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="ibtUp" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="ibtDown" EventName="Click" />
              </Triggers>
          </asp:UpdatePanel>
               </td>
               
                    <td> <asp:ImageButton ID="ibtUp" runat="server" ImageUrl="~/images/up.png"  
                            Width="28"   OnClientClick ="return checkSelect()" 
                            meta:resourcekey="ibtUpResource1" onclick="ibtUp_Click"/><br /><br /> <asp:ImageButton ID="ibtDown" runat="server" ImageUrl="~/images/down.png" 
                            Width="28"  OnClientClick ="return checkSelect()" 
                            meta:resourcekey="ibtDownResource1" onclick="ibtDown_Click" /></td>
                </tr>
           </table>
        
      </tr>
      <tr>
        <td align ="center">
          <br />
          <asp:NewButton ID="btnSave" runat ="server" Width="80px"   Action ="MenuOrder" Text ="<%$ Resources:globalResource,SaveText %>"
                onclick="btnSave_Click" />
          &nbsp;
          <asp:NewButton ID ="btnReset" runat="server"  Width="80px"   Text ="<%$ Resources:globalResource,ResetText %>"
              OnClientClick ="return refresh()"/>
           &nbsp;
          <asp:NewButton ID="btnCancel" runat ="server" Width ="80"  Text ="<%$ Resources:globalResource,CancelText %>"
            OnClientClick="return cancel()" />
        </td>
      </tr>
    </table>
 
</center> 
</asp:Content>
