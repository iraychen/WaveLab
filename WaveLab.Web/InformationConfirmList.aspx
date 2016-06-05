<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="InformationConfirmList.aspx.cs" Inherits="WaveLab.Web.InformationConfirmList" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready(function() {
    $(".date").datepicker({
        showOn: "button",
        buttonImageOnly: true,
        dateFormat: "yy-mm-dd",
        changeYear: true,
        changeMonth: true
    });
    $(".date").mask("9999-99-99", {});
    $("input:submit").button();
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

function formClear() {
    $("#<%=tbxModel.ClientID %>").val("");
    $("#<%=tbxSerialNo.ClientID %>").val("");
	$("#<%=tbxDateFrom.ClientID %>").val("");
    $("#<%=tbxDateTo.ClientID %>").val("");
    return false;
}

function makeWindow(mode,value)
{
    var url;
    var win;
    var strPara="toolbar=0,status=0,scrollbars=1,resizable=1,width=700px,Height=580px";
    switch(mode)
    {
        case "VIEW":
            url="InformationConfirmView.aspx?ConfirmId="+value;
            break;
        default:
            break;
    }
    win=window.open(url,"secwin",strPara);
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<table width ="100%">
    <tr>
        <td>
             <table>
                <tr>
	                <td>
	                    <asp:Image ID ="imgTitle" runat="server" SkinID ="ImgskinSearchTitle"  meta:resourcekey="imgTitleResource1" />
		            </td>
	                <td valign="bottom">  
	                    <asp:Label ID="lblTitle" runat="server" SkinId="skinTitle" meta:resourcekey="lblTitleResource1"/>
	                </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <fieldset>
            <table style =" width:100%">
                <tr>
                    <td>
                         <table style =" width:100%">
                             <tr>
                                <td>
                                    <asp:Label ID ="lblModel" runat="server" meta:resourcekey="lblModelResource1"  />
                                </td>
                                <td>
                                    <asp:TextBox ID ="tbxModel" runat="server"  Width="180px" 
                                        meta:resourcekey="tbxModelResource1"/>
                                </td>
                                <td><asp:Label ID="lblSerialNo" runat="server" meta:resourcekey="lblSerialNoResource1"/></td>
                                <td>
                                    <asp:TextBox ID="tbxSerialNo" runat="server"  Width="180px" 
                                        meta:resourcekey="tbxSerialNoResource1"/>
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
                        <asp:NewButton id="btnSubmit" Runat="server" Width="80px"  
                                OnClientClick ="return verify()" meta:resourcekey="btnSubmitResource1" 
                                onclick="btnSubmit_Click"/>&nbsp;
                        <asp:NewButton ID="btnReset" runat="server" Width ="80px" 
                                OnClientClick ="return formClear()" meta:resourcekey="btnResetResource1"/>
                    </td>
                </tr>
            </table>
            </fieldset>
        </td>
    </tr>
   <tr>
	    <td><asp:Label ID="lblRecCount" runat="server" 
                meta:resourcekey="lblRecCountResource1"></asp:Label></td>
	</tr>
	<tr>
		<td>
		    <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False"  
                    EnableViewState ="False" SkinID="skinGridView" Width ="100%" onrowdatabound="GVList_RowDataBound"
                meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" >
                  <Columns>
                  <asp:BoundField  DataField="Model" SortExpression ="c.model" 
                            meta:resourcekey="BoundFieldResource1"/>
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource1" SortExpression ="a.serial_no">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtSerialNo" runat ="server" meta:resourcekey="lbtSerialNoResource1"/>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField  DataField="StationNo" SortExpression ="a.station_no" meta:resourcekey="BoundFieldResource2"/>
                      <asp:BoundField  DataField="TypeLow" SortExpression ="type_low" meta:resourcekey="BoundFieldResource3"/>
                      <asp:BoundField  DataField="TypeHigh" SortExpression ="type_high" meta:resourcekey="BoundFieldResource4"/>
                      <asp:BoundField  DataField="EndTime" SortExpression ="a.end_time" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" 
                            meta:resourcekey="BoundFieldResource5"/>
                      <asp:BoundField  DataField="RunningTime" SortExpression ="a.end_time" meta:resourcekey="BoundFieldResource6"/>
                      <asp:BoundField  DataField="AppVersion" SortExpression ="a.app_version" meta:resourcekey="BoundFieldResource7"/>
                      <asp:BoundField  DataField="Reason" SortExpression ="reason" 
                            meta:resourcekey="BoundFieldResource10"/>
                       <asp:TemplateField meta:resourcekey="TemplateFieldResource2" SortExpression ="a.final_flag">
                        <ItemTemplate>
                            <asp:Label ID ="lblFinalFlag" runat ="server" />
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
</asp:Content>

