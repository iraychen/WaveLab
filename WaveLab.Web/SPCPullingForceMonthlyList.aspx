<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCPullingForceMonthlyList.aspx.cs" Inherits="WaveLab.Web.SPCPullingForceMonthlyList" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
    $(".date").datepicker({
        showOn: "button",
        buttonImageOnly: true,
        dateFormat: "yymm",
        changeYear: true,
        changeMonth: true
    });
    $(".date").mask("999999", {});
});
function verify() {
    var yearMonth = $("#<%=tbxYearMonth.ClientID %>");

    if (yearMonth.val().length!=6 && parseInt(yearMonth.substr(4,2))>12){
        alert($("#<%=lblYearMonthFormatMsg.ClientID %>").attr("title"));
        yearMonth.focus();
        return false;
    }
    return true;
}
function makeWindow(mode, key) {
   var url;
   var win;
   var strPara = "toolbar=0,status=0,scrollbars=1,resizable=1,width=1000px,Height=700px";
   switch (mode) {
       case "VIEW":
           url = "SPCPullingForceMonthlyView.aspx?key=" + key;
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
                                    <td >
                                        <asp:TextBox ID ="tbxMachineNo" runat="server"  Width="200px" 
                                            meta:resourcekey="tbxMachineNoResource1"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblYearMonth" runat="server" meta:resourcekey="lblYearMonthResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxYearMonth" runat ="server"  MaxLength ="7"  CssClass ="date" 
                                            Width ="80px" meta:resourcekey="tbxYearMonthResource1"/>
                                        <asp:Label ID="lblYearMonthFormat" runat ="server" meta:resourcekey="lblYearMonthFormatResource1"  /> 
                                        <asp:Label ID="lblYearMonthFormatMsg" runat ="server" meta:resourcekey="lblYearMonthFormatMsgResource1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align ="right">
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
                      <asp:BoundField  DataField="Yearmonth" SortExpression ="yearmonth" 
                            meta:resourcekey="BoundFieldResource2"/>                    
                      <asp:BoundField  DataField="LastUpdateDate" SortExpression ="last_update_date"  DataFormatString="{0:yyyy-MM-dd}" 
                            meta:resourcekey="BoundFieldResource3"/>
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
