<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCRxPowerList.aspx.cs" Inherits="WaveLab.Web.SPCRxPowerList" culture="auto" meta:resourcekey="PageResource2" uiculture="auto" %>
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
function makeWindow(popType, RxPowerPK) {
   var url;
   var win;
   var strPara = "toolbar=0,status=0,scrollbars=1,resizable=1,width=1000px,Height=700px";
   switch (popType) {
       case "VIEW":
           url = "SPCRxPowerView.aspx?RxPowerPK=" + RxPowerPK;
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
                                        <asp:Label ID ="lblType" runat="server" meta:resourcekey="lblTypeResource1"  />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxType" runat="server"  Width="200px" 
                                            meta:resourcekey="tbxTypeResource1"/>
                                      <%--  <asp:Button ID="btnBrower" runat ="server"  OnClientClick ="return makeDialogWindow('MODEL')"
                                            meta:resourcekey="btnBrowerResource1"/>--%>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMode" runat="server" meta:resourcekey="lblModeResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxMode" runat ="server"  MaxLength="50" Width="200px" 
                                            meta:resourcekey="tbxModeResource1"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCH" runat="server" meta:resourcekey="lblCHResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxCH" runat ="server"  MaxLength="50"  Width="200px" 
                                            meta:resourcekey="tbxCHResource1"/>
                                    </td>
                                     <td>
                                        <asp:Label ID="lblPW" runat="server" meta:resourcekey="lblPWResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxPW" runat ="server"  MaxLength="50"  Width="200px" 
                                            meta:resourcekey="tbxPWResource1"/>
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
                    SkinID="skinGridView" Width ="100%" onrowdatabound="GVList_RowDataBound" DataKeyNames="RxPowerPK"
                    meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" 
                     onrowdeleting="GVList_RowDeleting" >
                  <Columns>
                      <asp:BoundField  DataField="Type" SortExpression ="type"  
                            meta:resourcekey="BoundFieldResource1"/>
                      <asp:BoundField  DataField="Mode" SortExpression ="mode" 
                            meta:resourcekey="BoundFieldResource2"/>
                      <asp:BoundField  DataField="CH" SortExpression ="ch" 
                            meta:resourcekey="BoundFieldResource3"/>
                      <asp:BoundField  DataField="PW" SortExpression ="pw" 
                            meta:resourcekey="BoundFieldResource4"/>
                      <asp:BoundField  DataField="DateFrom" SortExpression ="date_from" DataFormatString="{0:yyyy-MM-dd}" 
                            meta:resourcekey="BoundFieldResource5"/>
                    <asp:BoundField  DataField="DateTo" SortExpression ="date_to" DataFormatString="{0:yyyy-MM-dd}" 
                            meta:resourcekey="BoundFieldResource6"/>
                      <asp:BoundField  DataField="LastUpdateDate" SortExpression ="last_update_date"  DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" 
                            meta:resourcekey="BoundFieldResource7"/>
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtView" runat ="server" 
                                meta:resourcekey="lbtViewResource1" />
                            <asp:LinkButton ID="lbtDelete" runat ="server" CommandName="delete" 
                                meta:resourcekey="lbtDeleteResource1" />
                        </ItemTemplate>
                     </asp:TemplateField>
               </Columns>     
            </asp:GridView>
            </td>
        </tr>
        <tr>
        <td>
            <webdiyer:AspNetPager ID="PagerNavigator"   runat="server"
                onpagechanged="PagerNavigator_PageChanged" />
        </td>
    </tr>
    </table>
</center>
</asp:Content>
