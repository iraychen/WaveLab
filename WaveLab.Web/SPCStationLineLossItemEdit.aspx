<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCStationLineLossItemEdit.aspx.cs" Inherits="WaveLab.Web.SPCStationLineLossItemEdit" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

<script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
$(document).ready(function(){
    $("input:submit").button();
});

function verify() {
    var stationNo = $("#<%=tbxStationNo.ClientID %>");
    var CHNo = $("#<%=tbxCHNo.ClientID %>");
    var frequencyBand = $("#<%=tbxFrequencyBand.ClientID %>");
    var item = $("#<%=tbxItem.ClientID %>");
    if (stationNo.val().length == 0) {
        alert($("#<%=lblStationNoMsg.ClientID %>").attr("title"));
        return false;
    }
    if (CHNo.val().length == 0) {
        alert($("#<%=lblCHNoMsg.ClientID %>").attr("title"));
        return false;
    }
    if (frequencyBand.val().length == 0) {
        alert($("#<%=lblFrequencyBandMsg.ClientID %>").attr("title"));
        return false;
    }
    if (item.val().length == 0) {
        alert($("#<%=lblItemMsg.ClientID %>").attr("title"));
        return false;
    }
    var LCL_X = $("#<%=tbxLCL_X.ClientID %>");
    var UCL_X = $("#<%=tbxUCL_X.ClientID %>");
    var LCL_MR = $("#<%=tbxLCL_MR.ClientID %>");
    var UCL_MR = $("#<%=tbxUCL_MR.ClientID %>");
    var reg = /^[+-]?[0-9]+.?[0-9]*$/;
    if (      
       ($.trim($("#<%=tbxLCL_X.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLCL_X.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUCL_X.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUCL_X.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxLCL_MR.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLCL_MR.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUCL_MR.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUCL_MR.ClientID %>").val())) == false)
    ) {
        alert($("#<%=lblNumberFormatErrorMsg.ClientID %>").attr("title"));
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
             <table width="680" class="form-table">
                <tr>
                    <td style="width:100px">
                        <asp:Label ID="lblStationNo" runat="server"  ForeColor="Red"
                            meta:resourcekey="lblStationNoResource1"/>
                    </td>
                    <td style="width:500px">
                       <asp:TextBox ID="tbxStationNo" runat="server" MaxLength="40" Width="250px" 
                            meta:resourcekey="tbxStationNoResource1" />
                       <asp:Label ID="lblStationNoMsg" runat="server" 
                            meta:resourcekey="lblStationNoMsgResource1"/>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblCHNo" runat="server" ForeColor="Red"
                            meta:resourcekey="lblCHNoResource1"/>
                    </td>
                    <td>
                       <asp:TextBox ID="tbxCHNo" runat="server" MaxLength="40" Width="250px" 
                            meta:resourcekey="tbxCHNoResource1" />
                       <asp:Label ID="lblCHNoMsg" runat="server" 
                            meta:resourcekey="lblCHNoMsgResource1"/>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblFrequencyBand" runat="server" ForeColor="Red"
                            meta:resourcekey="lblFrequencyBandResource1"/>
                    </td>
                    <td>
                       <asp:TextBox ID="tbxFrequencyBand" runat="server" MaxLength="40" Width="250px" 
                            meta:resourcekey="tbxFrequencyBandResource1" />
                       <asp:Label ID="lblFrequencyBandMsg" runat="server" 
                            meta:resourcekey="lblFrequencyBandMsgResource1"/>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblItem" runat="server" ForeColor="Red"
                            meta:resourcekey="lblItemResource1"/>
                    </td>
                    <td>
                       <asp:TextBox ID="tbxItem" runat="server" MaxLength="40" Width="250px" 
                            meta:resourcekey="tbxItemResource1" />
                          <asp:Label ID="lblItemMsg" runat="server" 
                            meta:resourcekey="lblItemMsgResource1"/>
                    </td>
                </tr>
                
		         <tr id="LCL_XRow"  runat="server">
                    <td >
                        <asp:Label ID ="lblLCL_X" runat ="server"
                            meta:resourcekey="lblLCL_XResource1" />
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxLCL_X" runat ="server"     Width="200px" CssClass="mask_pnum" MaxLength="10"
                        meta:resourcekey="tbxLCL_XResource1"/> 
                    </td>
                 </tr>
                  <tr id="UCL_XRow"  runat="server">
                    <td >
                        <asp:Label ID ="lblUCL_X" runat ="server"
                            meta:resourcekey="lblUCL_XResource1" />
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxUCL_X" runat ="server"     Width="200px" CssClass="mask_pnum" MaxLength="10"
                        meta:resourcekey="tbxUCL_XResource1"/> 
                    </td>
                 </tr>
                 <tr id="LCL_MRRow"  runat="server">
                    <td >
                        <asp:Label ID ="lblLCL_MR" runat ="server"
                            meta:resourcekey="lblLCL_MRResource1" />
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxLCL_MR" runat ="server"     Width="200px" CssClass="mask_pnum" MaxLength="10"
                        meta:resourcekey="tbxLCL_MRResource1"/> 
                    </td>
                  </tr>
                 <tr id="UCL_MRRow"  runat="server">
                    <td >
                        <asp:Label ID ="lblUCL_MR" runat ="server"
                            meta:resourcekey="lblUCL_MRResource1" />
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxUCL_MR" runat ="server"     Width="200px" CssClass="mask_pnum" MaxLength="10"
                        meta:resourcekey="tbxUCL_MRResource1"/> 
                    </td>
                </tr>
                <tr>
                    <td valign="top"><asp:Label ID="lblMachineInfo" runat="server"  meta:resourcekey="lblMachineInfoResource1"/>
                    </td>
                    <td>
                         <asp:TextBox ID="tbxMachineInfo" runat="server"  TextMode="MultiLine" 
                             Rows="10"  Width="400px"                          
                             meta:resourcekey="tbxMachineInfoResource1" />                          
                    </td>
		        </tr>
		        <tr>
                    <td valign="top"><asp:Label ID="lblModifiedLog" runat="server"  meta:resourcekey="lblModifiedLogResource1"/>
                    </td>
                    <td>
                         <asp:TextBox ID="tbxModifiedLog" runat="server"  TextMode="MultiLine" 
                             Rows="10"  Width="400px"                          
                             meta:resourcekey="tbxModifiedLogResource1" />                          
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
             <asp:Label ID="lblNumberFormatErrorMsg" runat ="server"  ToolTip ="<%$ Resources:globalResource,NumberFormatErrorMsg %>" 
                                    meta:resourcekey="lblNumberFormatErrorMsgResource1" />         
            <asp:NewButton  ID="btnSave" runat="server"  Width ="80px" Text ="<%$ Resources:globalResource,SaveText %>"
                OnClientClick="return verify()" onclick="btnSave_Click" 
                 meta:resourcekey="btnSaveResource1"/>
            &nbsp;
            <asp:NewButton ID="btnCancel" runat ="server"  Width ="80px" Text ="<%$ Resources:globalResource,CancelText %>"
                OnClientClick="return cancel()" meta:resourcekey="btnCancelResource1" />
 &nbsp;
                               <asp:Button ID="btnViewLog" runat ="server"  Width ="80px" 
                                    meta:resourcekey="btnViewLogResource1" onclick="btnViewLog_Click"/>
        </td>
    </tr>
  </table>
</center>
</asp:Content>