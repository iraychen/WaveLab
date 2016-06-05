<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCFixtureRILossHistory.aspx.cs" Inherits="WaveLab.Web.SPCFixtureReturnLossHistory" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
       case "ReturnLossView":
           url = "SPCFixtureReturnLossView.aspx?ReturnLossPK=" + key;
           break;
       case "InsertionLossView":
           url = "SPCFixtureInsertionLossView.aspx?InsertionLossPK=" + key;
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

<table width ="99%" style="text-align:left" border ="0" cellpadding="0" cellspacing ="0">
    <tr>
       <td >
           <fieldset>
           <table width="100%" border ="0" cellpadding="2" cellspacing ="0">
                <tr>
                    <td>
                        <table style ="width:100%">
                         <tr>
                            <td>
                                <asp:Label ID="lblType" runat="server" meta:resourcekey="lblTypeResource1"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Horizontal" 
                                    meta:resourcekey="rblTypeResource1">
                                    <asp:ListItem Selected="True" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:Label ID ="lblFixture" runat ="server" meta:resourcekey="lblFixtureResource1"/>
                            </td>
                            <td>
                                <asp:TextBox ID ="tbxFixture" runat ="server"  Width="180px" 
                                    meta:resourcekey="tbxFixtureResource1"/>
                            </td>                                
                         </tr>  
                         <tr>                                
                            
                            <td>
                                <asp:Label ID ="lblFrequencyBand" runat ="server" meta:resourcekey="lblFrequencyBandResource1"/>
                            </td>
                            <td>
                                <asp:TextBox ID ="tbxFrequencyBand" runat ="server"  Width="180px" 
                                    meta:resourcekey="tbxFrequencyBandResource1"/>
                            </td>
                            <td>
                                <asp:Label ID ="lblCH" runat ="server" meta:resourcekey="lblCHResource1"/>
                            </td>
                            <td>
                                <asp:TextBox ID ="tbxCH" runat ="server"  Width="180px" 
                                    meta:resourcekey="tbxCHResource1"/>
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
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource1" SortExpression ="b.Fixture">
                    <ItemTemplate>
                       <asp:Label ID="lblFixture" runat="server" 
                            Text='<%# Eval("FixtureItem.Fixture") %>' 
                           ></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>
                 
                 <asp:TemplateField meta:resourcekey="TemplateFieldResource3" SortExpression ="b.Frequency_Band">
                    <ItemTemplate>
                       <asp:Label ID="lblFrequencyBand" runat="server" 
                            Text='<%# Eval("FixtureItem.FrequencyBand") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>
                   <asp:TemplateField meta:resourcekey="TemplateFieldResource2" SortExpression ="b.CH">
                    <ItemTemplate>
                       <asp:Label ID="lblCH" runat="server" 
                            Text='<%# Eval("FixtureItem.CH") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>
                  <asp:BoundField  DataField="DateFrom" SortExpression ="a.Date_From" DataFormatString="{0:yyyy-MM-dd}" 
                        meta:resourcekey="BoundFieldResource1"/>
                 <asp:BoundField  DataField="DateTo" SortExpression ="a.Date_To" DataFormatString="{0:yyyy-MM-dd}" 
                        meta:resourcekey="BoundFieldResource2"/>                     
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource4">
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
</asp:Content>
