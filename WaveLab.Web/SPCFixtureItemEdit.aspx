<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCFixtureItemEdit.aspx.cs" Inherits="WaveLab.Web.SPCFixtureItemEdit" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

    <script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
$(document).ready(function(){
    $("input:submit").button();
});

function verify() {
    var fixture = $("#<%=tbxFixture.ClientID %>");
    if (fixture.val().length == 0) {
        alert($("#<%=lblFixtureMsg.ClientID %>").attr("title"));
        return false;
    }
    var ch = $("#<%=tbxCH.ClientID %>");
    if (ch.val().length == 0) {
        alert($("#<%=lblCHMsg.ClientID %>").attr("title"));
        return false;
    }
    var frequencyBand = $("#<%=tbxFrequencyBand.ClientID %>");
    if (frequencyBand.val().length == 0) {
        alert($("#<%=lblFrequencyBandMsg.ClientID %>").attr("title"));
        return false;
    }
    return true;

}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">

<center>
  <table style=" text-align:left ;"   width="700" cellpadding="2">
   <tr>
   <td colspan="2">
      <fieldset>
             <table width="100%" class="form-table">
                <tr>
                    <td style="width:100px">
                        <asp:Label ID="lblFixture" runat="server"  ForeColor="Red"
                            meta:resourcekey="lblFixtureResource1"/>
                    </td>
                    <td style="width:500px">
                       <asp:TextBox ID="tbxFixture" runat="server" MaxLength="40" Width="250px" 
                            meta:resourcekey="tbxFixtureResource1" />
                       <asp:Label ID="lblFixtureMsg" runat="server" 
                            meta:resourcekey="lblFixtureMsgResource1"/>
                    </td>
                </tr>
                 
                <tr>
                    <td style="width:100px">
                        <asp:Label ID="lblFrequencyBand" runat="server"  ForeColor="Red"
                            meta:resourcekey="lblFrequencyBandResource1"/>
                    </td>
                    <td style="width:500px">
                       <asp:TextBox ID="tbxFrequencyBand" runat="server" MaxLength="40" Width="250px" 
                            meta:resourcekey="tbxFrequencyBandResource1" />
                       <asp:Label ID="lblFrequencyBandMsg" runat="server" 
                            meta:resourcekey="lblFrequencyBandMsgResource1"/>
                    </td>
                </tr>
                <tr>
                    <td style="width:100px">
                        <asp:Label ID="lblCH" runat="server"  ForeColor="Red"
                            meta:resourcekey="lblCHResource1"/>
                    </td>
                    <td style="width:500px">
                       <asp:TextBox ID="tbxCH" runat="server" MaxLength="40" Width="250px" 
                            meta:resourcekey="tbxCHResource1" />
                       <asp:Label ID="lblCHMsg" runat="server" 
                            meta:resourcekey="lblCHMsgResource1"/>
                    </td>
                </tr>           
          </table>
       </fieldset>       
    </td>
   </tr>
   <tr>
        <td>
            
        </td>
        <td align="right">                
            <asp:Button  ID="btnSave" runat="server"  Width ="80px" Text ="<%$ Resources:globalResource,SaveText %>"
                OnClientClick="return verify()" onclick="btnSave_Click" 
                 meta:resourcekey="btnSaveResource1"/>
            &nbsp;
            <asp:Button ID="btnCancel" runat ="server"  Width ="80px" Text ="<%$ Resources:globalResource,CancelText %>"
                OnClientClick="return cancel()" meta:resourcekey="btnCancelResource1" />
        </td>
    </tr>
  </table>
</center>
</asp:Content>