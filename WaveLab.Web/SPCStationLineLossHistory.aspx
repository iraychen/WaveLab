<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCStationLineLossHistory.aspx.cs" Inherits="WaveLab.Web.SPCStationLineLossHistory" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
           url = "SPCStationLineLossView.aspx?LineLossPK=" + key;
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
                                    <asp:Label ID ="lblStationNo" runat ="server" meta:resourcekey="lblStationNoResource1"/>
                                </td>
                                <td>
                                    <asp:TextBox ID ="tbxStationNo" runat ="server"  Width="180px" 
                                        meta:resourcekey="tbxStationNoResource1"/>
                                </td>
                                <td>
                                    <asp:Label ID="lblCHNo" runat="server" 
                                        meta:resourcekey="lblCHNoResource1"/>
                                </td>
                                <td>
                                   <asp:TextBox ID="tbxCHNo" runat="server" MaxLength="40" Width="180px" 
                                        meta:resourcekey="tbxCHNoResource1" />
                                </td>
                             </tr>                             
                           <tr>
                            <td>
                                <asp:Label ID="lblFrequencyBand" runat="server"
                                    meta:resourcekey="lblFrequencyBandResource1"/>
                            </td>
                            <td>
                               <asp:TextBox ID="tbxFrequencyBand" runat="server" MaxLength="40" Width="180px" 
                                    meta:resourcekey="tbxFrequencyBandResource1" />
                            </td>
                    
                            <td>
                                <asp:Label ID="lblItem" runat="server"
                                    meta:resourcekey="lblItemResource1"/>
                            </td>
                            <td>
                               <asp:TextBox ID="tbxItem" runat="server" MaxLength="40" Width="180px" 
                                    meta:resourcekey="tbxItemResource1" />
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
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource1" SortExpression ="b.Station_No">
                        <ItemTemplate>
                           <asp:Label ID="lblStationNo" runat="server" Text=<%#Eval("LineLossItem.StationNo") %>></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource2" SortExpression ="b.CH_No">
                        <ItemTemplate>
                           <asp:Label ID="lblCHNo" runat="server" Text=<%#Eval("LineLossItem.CHNo") %>></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>
                       <asp:TemplateField meta:resourcekey="TemplateFieldResource3" SortExpression ="b.Frequency_Band">
                        <ItemTemplate>
                           <asp:Label ID="lblFrequencyBand" runat="server" Text=<%#Eval("LineLossItem.FrequencyBand") %>></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>
                       <asp:TemplateField meta:resourcekey="TemplateFieldResource4" SortExpression ="b.Item">
                        <ItemTemplate>
                           <asp:Label ID="lblItem" runat="server" Text=<%#Eval("LineLossItem.Item") %>></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>
                      <asp:BoundField  DataField="DateFrom" SortExpression ="a.Date_From" DataFormatString="{0:yyyy-MM-dd}" 
                            meta:resourcekey="BoundFieldResource1"/>
                     <asp:BoundField  DataField="DateTo" SortExpression ="a.Date_To" DataFormatString="{0:yyyy-MM-dd}" 
                            meta:resourcekey="BoundFieldResource2"/>                     
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource5">
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
