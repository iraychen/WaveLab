<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MIMeasureDataNew.aspx.cs" Inherits="WaveLab.Web.MIMeasureDataNew" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready(function()
{
     $(".date").datepicker({
        dateFormat: "yy-mm-dd",
        changeYear: true,
        changeMonth: true
    });
    $(".date").mask("9999-99-99", {});
    $("input:submit").button();
});

function verify() {
  var flag=true;
  $.each($(".date"), function() {
      if (checkDate($(this).val()) == false) {
          alert($("#<%=lblDateFormatMsg.ClientID %>").attr("title"));
          $(this).focus();
          flag = false;
          return false;
      }
  });
  return flag;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">

<table  border="0" cellpadding ="1" cellspacing ="0" width ="100%">
    <tr>
        <td><HR  color="#cccccc" SIZE="1"></td>
    </tr>
    <tr>
        <td  align ="center">
            <asp:Label ID="lblTitle" runat ="server" SkinID ="skinCTitle" 
                meta:resourcekey="lblTitleResource1" />
        </td>
    </tr>
    <tr>
        <td>
            <table  width ="100%" class="setup-table">
                 <tr>
                   <td style ="width:20%"><asp:Label ID="lblOrderNo" runat ="server"  Font-Bold ="True" 
                           meta:resourcekey="lblOrderNoResource1"/></td>
                   <td style ="width:30%"><asp:Literal ID="ltlOrderNo" runat ="server" 
                           meta:resourcekey="ltlOrderNoResource1" /></td>
                   <td style ="width:20%"><asp:Label ID="lblSerialNo" runat ="server" Font-Bold ="True"
                           meta:resourcekey="lblSerialNoResource1" /></td>
                   <td style ="width:30%"><asp:Literal ID="ltlSerialNo" runat ="server" 
                           meta:resourcekey="ltlSerialNoResource1" /> </td>
                 </tr>
                 <tr>
                   <td><asp:Label ID="lblCode" runat ="server"  Font-Bold ="True" 
                           meta:resourcekey="lblCodeResource1"/></td>
                   <td><asp:Literal ID="ltlCode" runat ="server" meta:resourcekey="ltlCodeResource1" /></td>
                   <td><asp:Label ID="lblModel" runat ="server" Font-Bold ="True"
                           meta:resourcekey="lblModelResource1" /></td>
                   <td><asp:Literal ID="ltlModel" runat ="server" 
                           meta:resourcekey="ltlModelResource1" /></td>
                 </tr>
            </table>
        </td>
    </tr>
     <tr>
        <td><HR  color="#cccccc" SIZE="1"></td>
    </tr>
    <tr>
        <td>
            <table  width ="100%" class ="setup-table" style ="text-align:center">
                <!--RSSI-->
                <tr>
                    <td rowspan ="3" valign="middle"><asp:Label ID="lblRSSI" runat ="server" 
                            Font-Bold="True" meta:resourcekey="lblRSSIResource1"/></td>
                    <td><asp:Label ID="lblRSSIMode" runat ="server" 
                            meta:resourcekey="lblRSSIModeResource1" Font-Bold ="True"/></td>
                    <td><asp:Label ID="lblNegative20" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblNegative20Resource1"/></td>
                    <td><asp:Label ID="lblNegative30" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblNegative30Resource1"/></td>
                    <td><asp:Label ID="lblNegative40" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblNegative40Resource1" /></td>
                    <td><asp:Label ID="lblNegative50" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblNegative50Resource1"/></td>
                    <td><asp:Label ID="lblNegative60" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblNegative60Resource1"/></td>
                    <td><asp:Label ID="lblNegative70" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblNegative70Resource1"/></td>
                    <td><asp:Label ID="lblNegative80" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblNegative80Resource1"/></td>
                    <td><asp:Label ID="lblNegative90" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblNegative90Resource1"/></td>
                    <td  style ="width:60px"><asp:Label ID="lblFinalFlag" runat ="server"  Font-Bold ="true"
                            meta:resourcekey="lblFinalFlagResource1"/></td>
                    <td><asp:Label ID="lblOperator" runat ="server" Font-Bold ="true"
                            meta:resourcekey="lblOperatorResource1"/></td>
                    <td><asp:Label ID="lblTestTime" runat ="server" Font-Bold ="true"
                            meta:resourcekey="lblTestTimeResource1"/><BR/>
                       <asp:Label ID="lblDateFormat" runat ="server"  Font-Size="10PX"
                                           Text ="<%$ Resources:globalResource,DateFormat %>" 
                                           meta:resourcekey="lblDateFormatResource1"  />   
                    </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="tbxRSSIMode1" runat ="server"  Width="200px"  
                            meta:resourcekey="tbxRSSIMode1Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative120" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative120Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative130" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative130Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative140" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative140Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative150" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative150Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative160" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative160Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative170" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative170Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative180" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative180Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative190" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative190Resource1"/></td>
                    <td rowspan ="2">
                        <asp:RadioButtonList ID="rblRSSIFinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td rowspan ="2">
                        <asp:TextBox ID ="tbxRSSIOperator" runat ="server"  Width="80"/>
                    </td>
                    <td rowspan ="2">
                        <asp:TextBox ID ="tbxRSSITestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="tbxRSSIMode2" runat ="server" Width="200px" 
                            meta:resourcekey="tbxRSSIMode2Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative220" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative220Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative230" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative230Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative240" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative240Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative250" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative250Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative260" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative260Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative270" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative270Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative280" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative280Resource1"/></td>
                    <td><asp:TextBox ID="tbxNegative290" runat ="server" Width="40px" 
                            meta:resourcekey="tbxNegative290Resource1"/></td>
                </tr>
                
                <!--SNR（for m协议）-->
                <tr>
                    <td rowspan ="2"  valign="middle"><asp:Label ID ="lblSNR" runat ="server" 
                            Font-Bold="True" meta:resourcekey="lblSNRResource1"/></td>
                    <td><asp:Label ID="lblSNRMode" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblSNRModeResource1" /></td>
                    <td  rowspan ="2" colspan ="3"> <asp:Label ID="lblSNRTarget" runat ="server" 
                            ForeColor ="Green" meta:resourcekey="lblSNRTargetResource1" /></td>
                    <td colspan ="2"><asp:Label ID="lblSNRLocalLeft" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblSNRLocalLeftResource1" /></td>
                    <td><asp:Label ID="lblSNRIFPoint" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblSNRIFPointResource1"/></td>
                    <td colspan ="2"><asp:Label ID="lblSNRLocalRight" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblSNRLocalRightResource1"/></td>
                    <td rowspan ="2">
                        <asp:RadioButtonList ID="rblSNRFinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td rowspan ="2">
                        <asp:TextBox ID ="tbxSNROperator" runat ="server"  Width="80"/>
                    </td>
                    <td rowspan ="2">
                        <asp:TextBox ID ="tbxSNRTestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlSNRMode" runat ="server" Width ="200px" 
                            meta:resourcekey="ddlSNRModeResource1">
                            <asp:ListItem Selected ="True" meta:resourcekey="ListItemResource1" ></asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td  colspan ="2"><asp:TextBox ID="tbxSNRLocalLeft" runat ="server" Width="100px" 
                            meta:resourcekey="tbxSNRLocalLeftResource1"/></td>
                    <td><asp:TextBox ID="tbxSNRIFPoint" runat ="server" Width="50px" 
                            meta:resourcekey="tbxSNRIFPointResource1"/></td>
                    <td  colspan ="2"><asp:TextBox ID="tbxSNRLocalRight" runat ="server" Width="100px" 
                            meta:resourcekey="tbxSNRLocalRightResource1"/></td>
                   
                </tr>
                
                <!--微震动误码数-->
                <tr>
                    <td rowspan ="2"  valign="middle"><asp:Label ID ="lblMicroVibration" 
                            runat ="server" Font-Bold="True" meta:resourcekey="lblMicroVibrationResource1"/></td>
                    <td><asp:Label ID="lblMicroVibrationMode" runat ="server" 
                            meta:resourcekey="lblMicroVibrationModeResource1" Font-Bold ="True"/></td>
                    <td  rowspan ="2" colspan ="3"> <asp:Label ID="lblMicroVibrationTarget" 
                            runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblMicroVibrationTargetResource1" /></td>
                    <td colspan ="5"><asp:Label ID="lblMicroVibrationErrorCount" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblMicroVibrationErrorCountResource1" /></td>
                    <td rowspan ="2">
                        <asp:RadioButtonList ID="rblMicroVibrationFinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td rowspan ="2">
                        <asp:TextBox ID ="tbxMicroVibrationOperator" runat ="server"  Width="80"/>
                    </td>
                    <td rowspan ="2">
                        <asp:TextBox ID ="tbxMicroVibrationTestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="tbxMicroVibrationMode" runat ="server"  Width="200px" 
                            meta:resourcekey="tbxMicroVibrationModeResource1"/></td>
                    <td  colspan ="5"><asp:TextBox ID="tbxMicroVibrationErrorCount" runat ="server"  
                            Width="120px" meta:resourcekey="tbxMicroVibrationErrorCountResource1"/></td>
                </tr>
                 
                <!--收信门限（for m协议）-->
                <tr>
                    <td rowspan ="3"  valign="middle">
                        <asp:Label ID="lblAGCM" runat ="server" 
                            Font-Bold="True" meta:resourcekey="lblAGCMResource1"/></td>
                    <td><asp:Label ID="lblAGCMMode" runat ="server" 
                            meta:resourcekey="lblAGCMModeResource1" Font-Bold ="True"/></td>
                    <td colspan ="3" rowspan="3">
                        <asp:Label ID="lblAGCMTarget" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblAGCMTargetResource1"/></td>
                    <td><asp:Label ID="lblAGCMChannel" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblAGCMChannelResource1"/></td>
                    <td><asp:Label ID="lblAGCMLUpperLimit" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblAGCMUpperLimitResource1" /></td>
                    <td><asp:Label ID="lblAGCMUpperAttenuation" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblAGCMUpperAttenuationResource1"/></td>
                    <td><asp:Label ID="lblAGCMLowerLimit" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblAGCMLowerLimitResource1"/></td>
                    <td><asp:Label ID="lblAGCMLowerAttenuation" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblAGCMLowerAttenuationResource1"/></td>
                     <td rowspan ="3">
                        <asp:RadioButtonList ID="rblAGCMFinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td rowspan ="3">
                        <asp:TextBox ID ="tbxAGCMOperator" runat ="server"  Width="80"/>
                    </td>
                    <td rowspan ="3">
                        <asp:TextBox ID ="tbxAGCMTestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>
                </tr>
                <tr>
                    <td rowspan ="2"><asp:TextBox ID="tbxAGCMMode" runat ="server"  Width="200px" 
                            meta:resourcekey="tbxAGCMModeResource1"/></td>
                    <td><asp:TextBox ID="tbxAGCMR1Channel" runat ="server" Width="70px" 
                            meta:resourcekey="tbxAGCMR1ChannelResource1"/></td>
                    <td><asp:TextBox ID="tbxAGCMR1UpperLimit" runat ="server" Width="40px" 
                            meta:resourcekey="tbxAGCMR1UpperLimitResource1"/></td>
                    <td><asp:TextBox ID="tbxAGCMR1UpperAttenuation" runat ="server" Width="40px" 
                            meta:resourcekey="tbxAGCMR1UpperAttenuationResource1"/></td>
                    <td><asp:TextBox ID="tbxAGCMR1LowerLimit" runat ="server" Width="40px" 
                            meta:resourcekey="tbxAGCMR1LowerLimitResource1"/></td>
                    <td><asp:TextBox ID="tbxAGCMR1LowerAttenuation" runat ="server" Width="40px" 
                            meta:resourcekey="tbxAGCMR1LowerAttenuationResource1"/></td>
                </tr>
                <tr>
                     <td><asp:TextBox ID="tbxAGCMR2Channel" runat ="server" Width="70px" 
                            meta:resourcekey="tbxAGCMR2ChannelResource1"/></td>
                    <td><asp:TextBox ID="tbxAGCMR2UpperLimit" runat ="server" Width="40px" 
                            meta:resourcekey="tbxAGCMR2UpperLimitResource1"/></td>
                    <td><asp:TextBox ID="tbxAGCMR2UpperAttenuation" runat ="server" Width="40px" 
                            meta:resourcekey="tbxAGCMR2UpperAttenuationResource1"/></td>
                    <td><asp:TextBox ID="tbxAGCMR2LowerLimit" runat ="server" Width="40px" 
                            meta:resourcekey="tbxAGCMR2LowerLimitResource1"/></td>
                    <td><asp:TextBox ID="tbxAGCMR2LowerAttenuation" runat ="server" Width="40px" 
                            meta:resourcekey="tbxAGCMR2LowerAttenuationResource1"/></td>
                </tr>
                
                <!--收信门限（for IP Radio）-->
                <tr>
                    <td rowspan ="4"  valign="middle"><asp:Label ID="lblAGCIPR" runat ="server" 
                            Font-Bold="True" meta:resourcekey="lblAGCIPRResource1"/></td>
                    <td><asp:Label ID="lblAGCIPRMode" runat ="server" 
                            meta:resourcekey="lblAGCIPRModeResource1" Font-Bold ="True"/></td>
                    <td colspan ="3" rowspan="4"><asp:Label ID="lblAGCIPRTarget" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblAGCIPRTargetResource1"/></td>
                    <td><asp:Label ID="lblAGCIPRChannel" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblAGCIPRChannelResource1"/></td>
                    <td colspan ="2">
                        <asp:Label ID="lblAGCIPRUpperLimit" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblAGCIPRUpperLimitResource1" /></td>
                    <td colspan ="2">
                        <asp:Label ID="lblAGCIPRLowerLimit" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblAGCIPRLowerLimitResource1"/></td>
                    <td rowspan ="4">
                        <asp:RadioButtonList ID="rblAGCIPRFinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td rowspan ="4">
                        <asp:TextBox ID ="tbxAGCIPROperator" runat ="server"  Width="80"/>
                    </td>
                    <td rowspan ="4">
                        <asp:TextBox ID ="tbxAGCIPRTestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>
                </tr>
                <tr>
                    <td rowspan ="3">
                        <asp:DropDownList ID="ddlAGCIPRMode" runat ="server" Width ="200px" 
                            meta:resourcekey="ddlAGCIPRModeResource1">
                            <asp:ListItem Selected ="True" meta:resourcekey="ListItemResource3" ></asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource4"></asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tbxAGCIPRR1Channel" runat ="server" Width="70px" 
                            meta:resourcekey="tbxAGCIPRR1ChannelResource1"/></td>
                    <td colspan ="2"><asp:TextBox ID="tbxAGCIPRR1UpperLimit" runat ="server" Width="80px" 
                            meta:resourcekey="tbxAGCIPRR1UpperLimitResource1"/></td>
                    <td colspan ="2"><asp:TextBox ID="tbxAGCIPRR1LowerLimit" runat ="server" Width="80px" 
                            meta:resourcekey="tbxAGCIPRR1LowerLimitResource1"/></td>
                </tr>
                <tr>
                     <td><asp:TextBox ID="tbxAGCIPRR2Channel" runat ="server" Width="70px" 
                            meta:resourcekey="tbxAGCIPRR2ChannelResource1"/></td>
                    <td colspan ="2"><asp:TextBox ID="tbxAGCIPRR2UpperLimit" runat ="server" Width="80px" 
                            meta:resourcekey="tbxAGCIPRR2UpperLimitResource1"/></td>
                    <td colspan ="2"><asp:TextBox ID="tbxAGCIPRR2LowerLimit" runat ="server" Width="80px" 
                            meta:resourcekey="tbxAGCIPRR2LowerLimitResource1"/></td>
                </tr>
                <tr>
                     <td><asp:TextBox ID="tbxAGCIPRR3Channel" runat ="server" Width="70px" 
                            meta:resourcekey="tbxAGCIPRR3ChannelResource1"/></td>
                    <td colspan ="2"><asp:TextBox ID="tbxAGCIPR3UpperLimit" runat ="server" Width="80px" 
                            meta:resourcekey="tbxAGCIPR3UpperLimitResource1"/></td>
                    <td colspan ="2"><asp:TextBox ID="tbxAGCIPR3LowerLimit" runat ="server" Width="80px" 
                            meta:resourcekey="tbxAGCIPR3LowerLimitResource1"/></td>
                </tr>
                
                <!--收信门限（for xcr）-->
                <tr>
                    <td rowspan ="3"  valign="middle"><asp:Label ID="lblAGCXCR" runat ="server" 
                            Font-Bold="True" meta:resourcekey="lblAGCXCRResource1"/></td>
                    <td><asp:Label ID="lblAGCXCRMode" runat ="server" 
                            meta:resourcekey="lblAGCXCRModeResource1" Font-Bold ="True"/></td>
                    <td colspan ="3" rowspan="3"><asp:Label ID="lblAGCXCRTarget" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblAGCXCRTargetResource1"/></td>
                    <td><asp:Label ID="lblAGCXCRChannel" runat ="server"  Font-Bold ="True"
                            meta:resourcekey="lblAGCXCRChannelResource1"/></td>
                    <td colspan ="2">
                        <asp:Label ID="lblAGCXCRUpperLimit" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblAGCXCRUpperLimitResource1" /></td>
                    <td colspan ="2">
                        <asp:Label ID="lblAGCXCRLowerLimit" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblAGCXCRLowerLimitResource1"/></td>
                     <td rowspan ="3">
                        <asp:RadioButtonList ID="rblAGCXCRFinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td rowspan ="3">
                        <asp:TextBox ID ="tbxAGCXCROperator" runat ="server"  Width="80"/>
                    </td>
                    <td rowspan ="3">
                        <asp:TextBox ID ="tbxAGCXCRTestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="tbxAGCXCRR1Mode" runat ="server"  Width="200px" 
                            meta:resourcekey="tbxAGCXCRR1ModeResource1"/></td>
                    <td><asp:TextBox ID="tbxAGCXCRR1Channel" runat ="server" Width="70px" 
                            meta:resourcekey="tbxAGCXCRR1ChannelResource1"/></td>
                    <td colspan ="2"><asp:TextBox ID="tbxAGCXCRR1UpperLimit" runat ="server" Width="80px" 
                            meta:resourcekey="tbxAGCXCRR1UpperLimitResource1"/></td>
                    <td colspan ="2"><asp:TextBox ID="tbxAGCXCRR1LowerLimit" runat ="server" Width="80px" 
                            meta:resourcekey="tbxAGCXCRR1LowerLimitResource1"/></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="tbxAGCXCRR2Mode" runat ="server"  Width="200px"  
                            meta:resourcekey="tbxAGCXCRR2ModeResource1"/></td>
                     <td><asp:TextBox ID="tbxAGCXCRR2Channel" runat ="server" Width="70px" 
                            meta:resourcekey="tbxAGCXCRR2ChannelResource1"/></td>
                    <td colspan ="2"><asp:TextBox ID="tbxAGCXCRR2UpperLimit" runat ="server" Width="80px" 
                            meta:resourcekey="tbxAGCXCRR2UpperLimitResource1"/></td>
                    <td colspan ="2"><asp:TextBox ID="tbxAGCXCR2LowerLimit" runat ="server" Width="80px" 
                            meta:resourcekey="tbxAGCXCR2LowerLimitResource1"/></td>
                </tr>
                
                <!--气密-->
                <tr>
                    <td valign="middle"  style ="width:300px"><asp:Label ID="lblAirtight" runat ="server" Font-Bold="True"
                             meta:resourcekey="lblAirtightResource1"/></td>
                    <td></td>
                    <td colspan ="3"><asp:Label ID="lblAirtightTarget" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblAirtightTargetResource1"/></td>
                    <td colspan ="5"><asp:TextBox ID="tbxAirtight" runat ="server" Width="280px" 
                            meta:resourcekey="tbxAirtightResource1"/></td>
                     <td>
                        <asp:RadioButtonList ID="rblAirtightFinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td >
                        <asp:TextBox ID ="tbxAirtightOperator" runat ="server"  Width="80"/>
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxAirtightTestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>
                </tr>
                
                <!--温循（for G3、XMC）-->
                <tr>
                    <td rowspan ="3"  valign="middle">
                        <asp:Label ID="lblTemG3XMC" runat ="server" 
                            Font-Bold="True" meta:resourcekey="lblTemG3XMCResource1"/></td>
                    <td><asp:Label ID="lblTemG3XMCMode" runat ="server" 
                            meta:resourcekey="lblTemG3XMCModeResource1" Font-Bold ="True"/></td>
                    <td colspan ="3" rowspan="3">
                        <asp:Label ID="lblTemG3XMCTarget" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblTemG3XMCTargetResource1"/></td>
                    <td colspan ="2">
                        <asp:Label ID="lblTemG3XMCErrorNo" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblTemG3XMCErrorNoResource1"/></td>
                    <td colspan ="3"><asp:TextBox ID="tbxTemG3XMCErrorNo" runat ="server" Width="150px" 
                            meta:resourcekey="tbxTemG3XMCErrorNoResource1"/></td>
                    <td rowspan ="3">
                        <asp:RadioButtonList ID="rblTemG3XMCFinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td  rowspan ="3">
                        <asp:TextBox ID ="tbxTemG3XMCOperator" runat ="server"  Width="80"/>
                    </td>
                    <td  rowspan ="3">
                        <asp:TextBox ID ="tbxTemG3XMCTestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>      
                </tr>
                <tr>
                    <td rowspan ="2">
                        <asp:TextBox ID="tbxTemG3XMCMode" runat ="server"  Width="200px"  
                            meta:resourcekey="tbxTemG3XMCModeResource1"/></td>
                    <td colspan ="2">
                        <asp:Label ID="lblTemG3XMCErrorSeconds" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblTemG3XMCErrorSecondsResource1"/></td>
                    <td colspan ="3"><asp:TextBox ID="tbxTemG3XMCErrorSeconds" runat ="server" Width="150px" 
                            meta:resourcekey="tbxTemG3XMCErrorSecondsResource1"/></td>
                </tr>
                <tr>
                     <td colspan ="2">
                         <asp:Label ID="lblTemG3XMCAIS" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblTemG3XMCAISResource1"/></td>
                    <td colspan ="3"><asp:TextBox ID="tbxTemG3XMCAIS" runat ="server" Width="150px" 
                            meta:resourcekey="tbxTemG3XMCAISResource1"/></td>
                </tr>
                
                <!--温循（for PTN机）-->
                <tr>
                    <td rowspan ="2"  valign="middle">
                        <asp:Label ID="lblTemPTN" runat ="server" 
                            Font-Bold="True" meta:resourcekey="lblTemPTNResource1"/></td>
                    <td><asp:Label ID="lblTemPTNMode" runat ="server" 
                            meta:resourcekey="lblTemPTNModeResource1" Font-Bold ="True"/></td>
                    <td rowspan="2" colspan ="3">
                        <asp:Label ID="lblTemPTNTarget" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblTemPTNTargetResource1"/></td>
                    <td colspan ="2">
                        <asp:Label ID="lblTemPTNLossRate" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblTemPTNLossRateResource1"/></td>
                    <td colspan ="3"><asp:TextBox ID="tbxTemPTNLossRate" runat ="server" Width="150px" 
                            meta:resourcekey="tbxTemPTNLossRateResource1"/></td>
                     <td rowspan ="2">
                        <asp:RadioButtonList ID="rblTemPTNFinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td  rowspan ="2">
                        <asp:TextBox ID ="tbxTemPTNOperator" runat ="server"  Width="80"/>
                    </td>
                    <td  rowspan ="2">
                        <asp:TextBox ID ="tbxTemPTNTestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>      
                </tr>
                <tr>
                    <td> <asp:DropDownList ID="ddlTemPTNMode" runat ="server" Width ="200px" 
                            meta:resourcekey="ddlTemPTNModeResource1">
                            <asp:ListItem Selected ="True" meta:resourcekey="ListItemResource3" ></asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource4"></asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource5"></asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan ="2">
                        <asp:Label ID="lblTemPTNErrorSeconds" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblTemPTNErrorSecondsResource1"/></td>
                    <td colspan ="3"><asp:TextBox ID="tbxTemPTNErrorSeconds" runat ="server" Width="150px" 
                            meta:resourcekey="tbxTemPTNErrorSecondsResource1"/></td>
                </tr>
                
                <!--温循（for 一体机ML-6101(GE)）-->
                <tr>
                    <td valign="middle"><asp:Label ID="lblTemOML6101" runat ="server" Font-Bold="True"
                             meta:resourcekey="lblTemOML6101Resource1"/></td>
                    <td></td>
                    <td colspan ="3"><asp:Label ID="lblTemOML6101Target" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblTemOML6101TargetResource1"/></td>
		            <td colspan="2">
	                    <asp:Label ID="lblTemOML6101LossRate" runat ="server"  Font-Bold ="True"
                                                meta:resourcekey="lblTemOML6101LossRateResource1"/>
                    </td>
                    <td colspan ="3"><asp:TextBox ID="tbxTemOML6101LossRate" runat ="server" Width="150px" 
                            meta:resourcekey="tbxTemOML6101LossRateResource1"/></td>
                     <td>
                        <asp:RadioButtonList ID="rblTemOML6101FinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxTemOML6101Operator" runat ="server"  Width="80"/>
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxTemOML6101TestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>      
                </tr>
                
                <!--温循（for 一体机ML-6205）-->
                 <tr>
                    <td valign="middle"><asp:Label ID="lblTemOML6205" runat ="server" Font-Bold="True"
                             meta:resourcekey="lblTemOML6205Resource1"/></td>
                    <td></td>
                    <td colspan ="3"><asp:Label ID="lblTemOML6205Target" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblTemOML6205TargetResource1"/></td>
		            <td colspan="2">
	                    <asp:Label ID="lblTemOML6205TotalError" runat ="server"  Font-Bold ="True"
                                                meta:resourcekey="lblTemOML6205TotalErrorResource1"/>
                    </td>
                    <td colspan ="3"><asp:TextBox ID="tbxTemOML6205TotalError" runat ="server" Width="150px" 
                            meta:resourcekey="tbxTemOML6205TotalErrorResource1"/></td>
                     <td>
                        <asp:RadioButtonList ID="rblTemOML6205FinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxTemOML6205Operator" runat ="server"  Width="80"/>
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxTemOML6205TestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>   
                </tr>
                
                <!--温循（for 一体机ML-6202）-->
                <tr>
                    <td valign="middle"><asp:Label ID="lblTemOML6202" runat ="server" Font-Bold="True"
                             meta:resourcekey="lblTemOML6202Resource1"/></td>
                    <td></td>
                    <td colspan ="3"><asp:Label ID="lblTemOML6202Target" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblTemOML6202TargetResource1"/></td>
		            <td colspan="2">
	                    <asp:Label ID="lblTemOML6202TotalError" runat ="server"  Font-Bold ="True"
                                                meta:resourcekey="lblTemOML6202TotalErrorResource1"/>
                    </td>
                    <td colspan ="3"><asp:TextBox ID="tbxTemOML6202TotalError" runat ="server" Width="150px" 
                            meta:resourcekey="tbxTemOML6202TotalErrorResource1"/></td>
                     <td>
                        <asp:RadioButtonList ID="rblTemOML6202FinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxTemOML6202Operator" runat ="server"  Width="80"/>
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxTemOML6202TestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>     
                </tr>
                
                <!--快速温变（for G3、XMC、一体机)-->
                <tr>
                    <td rowspan ="3"  valign="middle">
                        <asp:Label ID="lblFTC" runat ="server" 
                            Font-Bold="True" meta:resourcekey="lblFTCResource1"/></td>
                    <td><asp:Label ID="lblFTCMode" runat ="server" 
                            meta:resourcekey="lblFTCModeResource1" Font-Bold ="True"/></td>
                    <td colspan ="3" rowspan="3">
                        <asp:Label ID="lblFTCTarget" runat ="server" ForeColor ="Green" 
                            meta:resourcekey="lblFTCTargetResource1"/></td>
                    <td colspan ="2">
                        <asp:Label ID="lblFTCErrorNo" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblFTCErrorNoResource1"/></td>
                    <td colspan ="3"><asp:TextBox ID="tbxFTCErrorNo" runat ="server" Width="150px" 
                            meta:resourcekey="tbxFTCErrorNoResource1"/></td>
                     <td rowspan ="3">
                        <asp:RadioButtonList ID="rblFTCFinalFlag" runat ="server"   CssClass="cl-table">
                            <asp:ListItem  meta:resourcekey="ListItemResource6" />
                            <asp:ListItem meta:resourcekey="ListItemResource7" />
                            <asp:ListItem  Selected ="True" meta:resourcekey="ListItemResource8" />
                        </asp:RadioButtonList>
                    </td>
                    <td rowspan ="3">
                        <asp:TextBox ID ="tbxFTCOperator" runat ="server"  Width="80"/>
                    </td>
                    <td rowspan ="3">
                        <asp:TextBox ID ="tbxFTCTestTime" runat ="server" MaxLength="0" Width="80" CssClass ="date"/>
                    </td>     
                </tr>
                <tr>
                    <td rowspan ="2">
                        <asp:TextBox ID="tbxFTCMode" runat ="server"  Width="200px"  
                            meta:resourcekey="tbxFTCModeResource1"/></td>
                    <td colspan ="2">
                        <asp:Label ID="lblFTCErrorSeconds" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblFTCErrorSecondsResource1"/></td>
                    <td colspan ="3"><asp:TextBox ID="tbxFTCErrorSeconds" runat ="server" Width="150px" 
                            meta:resourcekey="tbxFTCErrorSecondsResource1"/></td>
                </tr>
                <tr>
                     <td colspan ="2">
                         <asp:Label ID="lblFTCAIS" runat ="server" Font-Bold ="True"
                            meta:resourcekey="lblFTCAISResource1"/></td>
                    <td colspan ="3"><asp:TextBox ID="tbxlblFTCAIS" runat ="server" Width="150px" 
                            meta:resourcekey="tbxlblFTCAISResource1"/></td>
                </tr>
            </table>
        </td>
    </tr>
   
    <tr>
        <td align ="right">
           <br/>
           <asp:Label ID="lblDateFormatMsg" runat ="server"   
                                        ToolTip ="<%$ Resources:globalResource,DateFormatMsg %>" />
           <asp:NewButton ID="btnPrevStep" runat="server"  Width ="70px" 
                Text ="<%$ Resources:globalResource,PrevStepText %>" 
                onclick="btnPrevStep_Click"/>
           &nbsp;
           <asp:NewButton  ID="btnSave" runat="server"    Width ="80" Text ="<%$ Resources:globalResource,SaveText %>" OnClientClick ="return verify()"
           onclick="btnSave_Click"/>
           &nbsp;
          <asp:NewButton ID="btnCancel" runat ="server"   Width ="80" Text ="<%$ Resources:globalResource,CancelText %>"
            OnClientClick="return cancel()"/>
           
        </td>
    </tr>
    </table>
</asp:Content>
