<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCPullingForceNew.aspx.cs" Inherits="WaveLab.Web.SPCPullingForceNew" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
$(document).ready(function(){
    $(".date").datepicker({
        showOn: "button",
        buttonImageOnly: true,
        dateFormat: "yy-mm-dd",
        changeYear: true,
        changeMonth: true
    });
    $(".date").mask("9999-99-99", {});
    $("input:submit").button();
    $(".mask_int").keyfilter(/[\d]/);
    $(".mask_pnum").keyfilter(/[\d\-\.]/);
});

function verify() {
    var machineNo = $("#<%=tbxMachineNo.ClientID %>");
    if (machineNo.val().length == 0) {
        alert($("#<%=lblMachineNoMsg.ClientID %>").attr("title"));
        return false;
    }
    
    var testingDate = $("#<%=tbxWorkingDate.ClientID %>");
    if (testingDate.val().length == 0) {
        alert($("#<%=lblDateRequiredMsg.ClientID %>").attr("title"));
        return false;
    }
    if (checkDate(testingDate.val()) == false) {
        alert($("#<%=lblDateFormatMsg.ClientID %>").attr("title"));
        return false;
    }

    if ($.trim($("#<%=tbxX1.ClientID %>").val()).length == 0 ||
        $.trim($("#<%=tbxX2.ClientID %>").val()).length == 0 || 
        $.trim($("#<%=tbxX3.ClientID %>").val()).length == 0 || 
        $.trim($("#<%=tbxX4.ClientID %>").val()).length == 0 ||
        $.trim($("#<%=tbxX5.ClientID %>").val()).length == 0 ||
        $.trim($("#<%=tbxX6.ClientID %>").val()).length == 0 ||
        $.trim($("#<%=tbxX7.ClientID %>").val()).length == 0 ||
        $.trim($("#<%=tbxX8.ClientID %>").val()).length == 0 || 
        $.trim($("#<%=tbxX9.ClientID %>").val()).length == 0 || 
        $.trim($("#<%=tbxX10.ClientID %>").val()).length == 0) {
        alert($("#<%=lblNumberRequiredMsg.ClientID %>").attr("title"));
        return false;
    }

    var reg = /^[+-]?[0-9]+.?[0-9]*$/;

    if (($.trim($("#<%=tbxMachinePressure.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxMachinePressure.ClientID %>").val())) == false) ||
        ($.trim($("#<%=tbxPowerFirstPoint.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxPowerFirstPoint.ClientID %>").val())) == false) ||
        ($.trim($("#<%=tbxPowerSecondPoint.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxPowerSecondPoint.ClientID %>").val())) == false)) {
        alert($("#<%=lblNumberFormatErrorMsg.ClientID %>").attr("title"));
        return false;
    }

    if (reg.test($.trim($("#<%=tbxX1.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxX2.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxX3.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxX4.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxX5.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxX6.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxX7.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxX8.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxX9.ClientID %>").val())) == false ||
    reg.test($.trim($("#<%=tbxX10.ClientID %>").val())) == false
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
  <table style=" text-align:left ;"   width="700" cellpadding="2">
   <tr>
   <td colspan="2">
      <fieldset>
             <table width="100%" class="form-table">
                <tr>
                    <td style="width:200px"><asp:Label ID="lblMachineNo" runat="server" 
                            meta:resourcekey="lblMachineNoResource1"/></td>
                    <td style="width:500px">
                       <asp:TextBox ID="tbxMachineNo" runat="server" MaxLength="40" Width="150px" 
                            meta:resourcekey="tbxMachineNoResource1" />
                       <asp:Label ID="lblMachineNoMsg" runat="server" 
                            meta:resourcekey="lblMachineNoMsgResource1"/>
                    </td>
                </tr>
                <tr>
                    <td ><asp:Label ID="lblWorkingDate" runat="server"  
                            meta:resourcekey="lblWorkingDateResource1"/>
                    </td>
                    <td>
                         <asp:TextBox ID="tbxWorkingDate" runat="server" 
                             Width="150px"    CssClass="date"
                             meta:resourcekey="tbxWorkingDateResource1" />
                            <asp:Label ID="lblWorkingDateFormat" runat ="server" 
                                                   Text ="<%$ Resources:globalResource,DateFormat %>" 
                                                   meta:resourcekey="lblWorkingDateFormatResource1"  /> 
                    </td>
		        </tr>
		        <tr>
                    <td><asp:Label ID="lblMWMType" runat="server" 
                            meta:resourcekey="lblMWMTypeResource1"/></td>
                    <td>
                       <asp:TextBox ID="tbxMWMType" runat="server" MaxLength="50" Width="150px" 
                            meta:resourcekey="tbxMWMTypeResource1" />                
                    </td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lblMachinePressure" runat="server" 
                            meta:resourcekey="lblMachinePressureResource1"/></td>
                    <td>
                       <asp:TextBox ID="tbxMachinePressure" runat="server" MaxLength="10" Width="150px"  CssClass="mask_int"
                            meta:resourcekey="tbxMachinePressureResource1" />                
                    </td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lblPowerFirstPoint" runat="server" 
                            meta:resourcekey="lblPowerFirstPointResource1"/></td>
                    <td>
                       <asp:TextBox ID="tbxPowerFirstPoint" runat="server" MaxLength="10" Width="150px" CssClass="mask_int"
                            meta:resourcekey="tbxPowerFirstPointResource1" />                
                    </td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lblPowerSecondPoint" runat="server" 
                            meta:resourcekey="lblPowerSecondPointResource1"/></td>
                    <td>
                       <asp:TextBox ID="tbxPowerSecondPoint" runat="server" MaxLength="10" Width="150px" CssClass="mask_int"
                            meta:resourcekey="tbxPowerSecondPointResource1" />                
                    </td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lblOperator" runat="server" 
                            meta:resourcekey="lblOperatorResource1"/></td>
                    <td>
                       <asp:TextBox ID="tbxOperator" runat="server" MaxLength="50" Width="150px" 
                            meta:resourcekey="tbxOperatorResource1" />                
                    </td>
                </tr>
		        <tr>
                    <td >
                        <asp:Label ID ="lblX1" runat ="server"
                            meta:resourcekey="lblX1Resource1" />
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxX1" runat ="server"    Width="150px" CssClass="mask_pnum" MaxLength="10"
                        meta:resourcekey="tbxX1Resource1"/> 
                    </td>
                 </tr>
                 <tr>
                    <td ><asp:Label ID="lblX2" runat="server" 
                            meta:resourcekey="lblX2Resource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxX2" runat="server" Width="150px" CssClass="mask_pnum" MaxLength="10"
                             meta:resourcekey="tbxX2Resource1" />
                    </td>
                 </tr>
                <tr>
                    <td ><asp:Label ID="lblX3" runat="server" 
                            meta:resourcekey="lblX3Resource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxX3" runat="server" Width="150px"  CssClass="mask_pnum" MaxLength="10"
                             meta:resourcekey="tbxX3Resource1" />
                    </td>
                 </tr>
                  <tr>
                    <td >
                        <asp:Label ID ="lblX4" runat ="server"
                            meta:resourcekey="lblX4Resource1" />
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxX4" runat ="server"   Width="150px" CssClass="mask_pnum" MaxLength="10"
                        meta:resourcekey="tbxX4Resource1"/> 
                    </td>
                 </tr>
                 <tr>
                    <td ><asp:Label ID="lblX5" runat="server" 
                            meta:resourcekey="lblX5Resource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxX5" runat="server" Width="150px" CssClass="mask_pnum" MaxLength="10"
                             meta:resourcekey="tbxX5Resource1" />
                    </td>
                 </tr>
                <tr>
                    <td ><asp:Label ID="lblX6" runat="server" 
                            meta:resourcekey="lblX6Resource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxX6" runat="server" Width="150px" CssClass="mask_pnum" MaxLength="10"
                             meta:resourcekey="tbxX6Resource1" />
                    </td>
                 </tr>
                  <tr>
                    <td ><asp:Label ID="lblX7" runat="server" 
                            meta:resourcekey="lblX7Resource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxX7" runat="server" Width="150px" CssClass="mask_pnum" MaxLength="10"
                             meta:resourcekey="tbxX7Resource1" />
                    </td>
                 </tr>
                  <tr>
                    <td ><asp:Label ID="lblX8" runat="server" 
                            meta:resourcekey="lblX8Resource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxX8" runat="server" Width="150px" CssClass="mask_pnum" MaxLength="10"
                             meta:resourcekey="tbxX8Resource1" />
                    </td>
                 </tr>
                  <tr>
                    <td ><asp:Label ID="lblX9" runat="server" 
                            meta:resourcekey="lblX9Resource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxX9" runat="server" Width="150px" CssClass="mask_pnum" MaxLength="10"
                             meta:resourcekey="tbxX9Resource1" />
                    </td>
                 </tr>
                  <tr>
                    <td ><asp:Label ID="lblX10" runat="server" 
                            meta:resourcekey="lblX10Resource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxX10" runat="server" Width="150px" CssClass="mask_pnum" MaxLength="10"
                             meta:resourcekey="tbxX10Resource1" />
                    </td>
                 </tr>
          </table>
       </fieldset>       
    </td>
   </tr>
    <tr>
    <td>
            <asp:Label ID="lblNumberFormatTip" ForeColor="Red" runat="server"  meta:resourcekey="lblNumberFormatTipResource1"/>
        </td>
        <td align="right">      
           <asp:Label ID="lblDateRequiredMsg" runat ="server"                                   
                 ToolTip ="<%$ Resources:globalResource,DateRequiredMsg %>" 
                 meta:resourcekey="lblDateRequiredMsgResource1" />
            <asp:Label ID="lblDateFormatMsg" runat ="server"   
                            ToolTip ="<%$ Resources:globalResource,DateFormatMsg %>" 
                 meta:resourcekey="lblDateFormatMsgResource1" />   
             <asp:Label ID="lblNumberRequiredMsg" runat ="server"   
                                                   meta:resourcekey="lblNumberRequiredMsgResource1"  />
            <asp:Label ID="lblNumberFormatErrorMsg" runat ="server"   
                                                    
                ToolTip ="<%$ Resources:globalResource,NumberFormatErrorMsg %>" 
                meta:resourcekey="lblNumberFormatErrorMsgResource1" />
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