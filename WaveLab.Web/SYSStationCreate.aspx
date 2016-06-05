<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSStationCreate.aspx.cs" Inherits="WaveLab.Web.SYSStationCreate" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

<script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
$(document).ready(function(){
    $("input:submit").button();
});

function verify() {
    var stationNo = $("#<%=tbxStationNo.ClientID %>");
    if (stationNo.val().length == 0) {
        alert($("#<%=lblStationNoMsg.ClientID %>").attr("title"));
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
                        <asp:Label ID="lblStationNo" runat="server"  ForeColor="Red"
                            meta:resourcekey="lblStationNoResource1"/>
                    </td>
                    <td>
                       <asp:TextBox ID="tbxStationNo" runat="server" MaxLength="40" Width="250px" 
                            meta:resourcekey="tbxStationNoResource1" />
                       <asp:Label ID="lblStationNoMsg" runat="server" 
                            meta:resourcekey="lblStationNoMsgResource1"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPosition" runat="server"  
                            meta:resourcekey="lblPositionResource1"/>
                    </td>
                    <td>
                       <asp:TextBox ID="tbxPosition" runat="server" MaxLength="40" Width="250px" 
                            meta:resourcekey="tbxPositionResource1" />                    
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