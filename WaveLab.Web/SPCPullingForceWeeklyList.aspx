﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCPullingForceWeeklyList.aspx.cs" Inherits="WaveLab.Web.SPCPullingForceWeeklyList" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
    $(".date").datepicker({
        showOn: "button",
        buttonImageOnly: true,
        dateFormat: "yy-mm-dd",
        changeYear: true,
        changeMonth: true
    });
    $(".date").mask("9999-99-99", {});
});
function verify() {
    var dateFrom = $("#<%=tbxDateFrom.ClientID %>");
    var dateTo = $("#<%=tbxDateTo.ClientID %>");
    if (checkDate(dateFrom.val()) == false) {
        alert($("#<%=lblDateFormatMsg.ClientID %>").attr("title"));
        dateFrom.focus();
        return false;
    }
    if (checkDate(dateTo.val()) == false) {
        alert($("#<%=lblDateFormatMsg.ClientID %>").attr("title"));
        dateTo.focus();
        return false;
    }
    return true;
}
function makeWindow(mode,key) {
   var url;
   var win;
   var strPara = "toolbar=0,status=0,scrollbars=1,resizable=1,width=1000px,Height=700px";
   switch (mode) {
       case "VIEW":
           url = "SPCPullingForceWeeklyView.aspx?key=" + key;
           break;
       default:
           break;
   }
   win = window.open(url, "secwin", strPara);
   return false;
}

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<table >
	<tr>
		<td><asp:Image ID ="imgTitle" runat="server" SkinID ="imgSkinReport"
			meta:resourcekey="imgTitleResource1" /></td>
		<td valign="bottom"><asp:Label ID ="lblTitle" runat="server"  SkinID ="skinTitle" 
			meta:resourcekey="lblTitleResource1" /></td>
	</tr>
</table>
<center>
<table width ="99%" style="text-align:left" border ="0" cellpadding="0" cellspacing ="0">
        <tr>
           <td >
               <fieldset>
               <table width="100%" border ="0" cellpadding="2" cellspacing ="0">
                    <tr>
                        <td>
                            <table style =" width:100%">
                                <tr>
                                    <td>
                                        <asp:Label ID ="lblMachineNo" runat="server" meta:resourcekey="lblMachineNoResource1"  />
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID ="tbxMachineNo" runat="server"  Width="200px" 
                                            meta:resourcekey="tbxMachineNoResource1"/>
                                    </td>
                                   
                                </tr>                              
                                <tr>
                                 <td >
                                   <asp:Label ID="lblDateFrom" runat="server" 
                                        meta:resourcekey="lblDateFromResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID ="tbxDateFrom" runat ="server"  MaxLength ="10"  CssClass ="date"
                                        Width ="80px" meta:resourcekey="tbxDateFromResource1"/>
                                    <asp:Label ID="lblDateFormFormat" runat ="server" 
                                       Text ="<%$ Resources:globalResource,DateFormat %>" 
                                       meta:resourcekey="lblDateFromFormatResource1"  /> 
                                </td>
                                 
                                <td>
                                    <asp:Label ID="lblDateTo" runat="server" meta:resourcekey="lblDateToResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID ="tbxDateTo" runat ="server"  MaxLength ="10"  CssClass ="date"
                                        Width ="80px" meta:resourcekey="tbxDateToResource1"/>
                                    <asp:Label ID="lblDateToFormat" runat ="server" 
                                       Text ="<%$ Resources:globalResource,DateFormat %>" 
                                       meta:resourcekey="lblDateToFormatResource1"  /> 
                                </td>
                            </tr>
                            </table>
                        </td>
                        <td align ="right">
                            <asp:Label ID="lblDateFormatMsg" runat ="server"   
                                        ToolTip ="<%$ Resources:globalResource,DateFormatMsg %>" 
                            meta:resourcekey="lblDateFormatMsgResource1" />
                            <asp:NewButton ID="btnSubmit" runat="server"  Width ="80px"   OnClientClick ="return verify()"
                                   onclick="btnSubmit_Click" meta:resourcekey="btnSubmitResource1"/>&nbsp;
                           
                        </td>
                    </tr>
                </table>
               </fieldset>
           </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblRecCount" runat="server" 
                    meta:resourcekey="lblRecCountResource1" /></td>
        </tr>
        <tr>
            <td>
                 <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False"  
                    SkinID="skinGridView" Width ="100%" onrowdatabound="GVList_RowDataBound" 
                    meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" >
                  <Columns>
                      <asp:BoundField  DataField="MachineNo" SortExpression ="machine_no"  
                            meta:resourcekey="BoundFieldResource1"/>
                      <asp:BoundField  DataField="DateFrom" SortExpression ="date_from" DataFormatString="{0:yyyy-MM-dd}" 
                            meta:resourcekey="BoundFieldResource2"/>
                     <asp:BoundField  DataField="DateTo" SortExpression ="date_to" DataFormatString="{0:yyyy-MM-dd}" 
                            meta:resourcekey="BoundFieldResource3"/>
                      <asp:BoundField  DataField="LastUpdateDate" SortExpression ="last_update_date"  DataFormatString="{0:yyyy-MM-dd}" 
                            meta:resourcekey="BoundFieldResource4"/>
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtView" runat ="server" 
                                meta:resourcekey="lbtViewResource1" />
                        </ItemTemplate>
                     </asp:TemplateField>
               </Columns>     
            </asp:GridView>
            </td>
        </tr>
        <tr>
        <td>
            <webdiyer:AspNetPager ID="PagerNavigator"   runat="server"
                onpagechanged="PagerNavigator_PageChanged"/>
        </td>
    </tr>
    </table>
</center>
</asp:Content>
