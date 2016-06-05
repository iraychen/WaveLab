<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCProjectEdit.aspx.cs" Inherits="WaveLab.Web.SPCProjectEdit" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
$(document).ready(function() {
    $(".mask_pnum").keyfilter(/[\d\.]/);

    $("input:submit").button();
});

function verify() {
    var minTimes= $("#<%=tbxMinTimes.ClientID %>");
    if (minTimes.val().length == 0) {
        alert($("#<%=lblMinTimesMsg.ClientID %>").attr("title"));
        return false;
    }
    var maxTimes = $("#<%=tbxMaxTimes.ClientID %>");
    if (maxTimes.val().length == 0) {
        alert($("#<%=lblMaxTimesMsg.ClientID %>").attr("title"));
        return false;
    }
    var receiver = $("#<%=tbxReceiver.ClientID %>");
    if (receiver.val().length == 0) {
        alert($("#<%=lblReceiverMsg.ClientID %>").attr("title"));
        return false;
    }
    return true;

}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">

<center>
  <table style=" text-align:left ;"   width="650" cellpadding="2">
   <tr>
   <td colspan="2">
      <fieldset>
             <table width="100%" class="form-table">
                <tr>
                    <td ><asp:Label ID="lblProjectCode" runat="server"  meta:resourcekey="lblProjectCodeResource1"/>
                    </td>
                    <td>
                       <asp:Literal ID="ltlProjectCode" runat="server" 
                            meta:resourcekey="ltlProjectCodeResource1"></asp:Literal>                         
                    </td>
		        </tr>
		        <tr>
                    <td ><asp:Label ID="lblProjectDesc" runat="server"  meta:resourcekey="lblProjectDescResource1"/>
                    </td>
                    <td>
                         <asp:Literal ID="ltlProjectDesc" runat="server" 
                             meta:resourcekey="ltlProjectDescResource1"></asp:Literal>                              
                    </td>
		        </tr>  
		        <tr>
		            <td>
		                <asp:Label ID="lblMinTimes" runat="server" ForeColor="Red" meta:resourcekey="lblMinTimesResource1"/>
		                
		            </td>
		            <td>
		                <asp:TextBox ID="tbxMinTimes" runat="server"  CssClass="mask_pnum" meta:resourcekey="tbxMinTimesResource1"/>
		                <asp:Label ID="lblMinTimesMsg" runat="server" meta:resourcekey="lblMinTimesMsgResource1"/>
		            </td>
		        </tr>
		         <tr>
		            <td>
		                <asp:Label ID="lblMaxTimes" runat="server" ForeColor="Red" meta:resourcekey="lblMaxTimesResource1"/>
		            </td>
		            <td>
		                <asp:TextBox ID="tbxMaxTimes" runat="server"   CssClass="mask_pnum" meta:resourcekey="tbxMaxTimesResource1"/>
		                <asp:Label ID="lblMaxTimesMsg" runat="server" meta:resourcekey="lblMaxTimesMsgResource1"/>
		            </td>
		        </tr>
		        <tr>
		            <td>
		                <asp:Label ID="lblGroupingNo" runat="server"  meta:resourcekey="lblGroupingNoResource1"/>
		                
		            </td>
		            <td>
		                <asp:TextBox ID="tbxGroupingNo" runat="server"  CssClass="mask_pnum" meta:resourcekey="tbxGroupingNoResource1"/>		             
		            </td>
		        </tr>
                <tr>
                    <td style="width:100px" valign="top">
                        <asp:Label ID="lblReceiver" runat="server"  ForeColor="Red"
                            meta:resourcekey="lblReceiverResource1"/>
                    </td>
                    <td style="width:500px">
                       <asp:TextBox ID="tbxReceiver" runat="server" TextMode="MultiLine" 
                             Rows="8"  Width="400px"     
                            meta:resourcekey="tbxReceiverResource1" />
                       <asp:Label ID="lblReceiverMsg" runat="server" 
                            meta:resourcekey="lblReceiverMsgResource1"/>
                    </td>
                </tr>
                 <tr>
                    <td valign="top">
                        <asp:Label ID="lblCC" runat="server" 
                            meta:resourcekey="lblCCResource1"/>
                    </td>
                    <td>
                       <asp:TextBox ID="tbxCC" runat="server" TextMode="MultiLine" 
                             Rows="8"  Width="400px"     
                            meta:resourcekey="tbxCCResource1" />
                    </td>
                </tr>
                    
		           
          </table>
       </fieldset>       
    </td>
   </tr>
   <tr>
        <td>
             <asp:Label ID="lblInputTip" runat="server" ForeColor="Red" 
                            meta:resourcekey="lblInputTipResource1"></asp:Label>
        </td>
        <td align="right">                
            <asp:NewButton  ID="btnSave" runat="server"  Width ="80px" Text ="<%$ Resources:globalResource,SaveText %>"
                OnClientClick="return verify()" onclick="btnSave_Click" 
                 meta:resourcekey="btnSaveResource1"/>
            &nbsp;
            <asp:NewButton ID="btnCancel" runat ="server"  Width ="80px" Text ="<%$ Resources:globalResource,CancelText %>"
                OnClientClick="return cancel()" meta:resourcekey="btnCancelResource1" />
        </td>
    </tr>
  </table>
</center>
</asp:Content>