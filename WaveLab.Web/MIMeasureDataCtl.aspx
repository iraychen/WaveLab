<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MIMeasureDataCtl.aspx.cs" Inherits="WaveLab.Web.MIMeasureDataCtl" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
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

function makeWindow(mode,key1,key2,key3,key4)
{
    var url;
    switch(mode)
    {
        case "NEW":
            url = "SerialNoList.aspx?backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url = "MIMeasureDataEdit.aspx?key1=" + key1 +"&key2=" + key2 +"&key3=" + key3 +"&key4=" + key4 + "&backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break ;
        default:
            break;
    }
    var winparas="toolbar=0,status=0,scrollbars=1,resizable=1,width=1024px,Height=768px";
    var win=window.open(url,"secwin",winparas);   
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<table >
	<tr>
		<td><asp:Image ID ="imgTitle" runat="server" SkinID ="ImgskinTitle" 
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
                                        <asp:Label ID ="lblOrderNo" runat ="server" meta:resourcekey="lblOrderNoResource1"/>
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxOrderNo" runat ="server"  Width="180px" 
                                            meta:resourcekey="tbxOrderNoResource1"/>
                                    </td>
                                    <td><asp:Label ID="lblSerialNo" runat="server" meta:resourcekey="lblSerialNoResource1"/></td>
                                    <td>
                                        <asp:TextBox ID="tbxSerialNo" runat="server"  Width="180px" 
                                            meta:resourcekey="tbxSerialNoResource1"/>
                                    </td>
                                 </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID ="lblCode" runat="server" meta:resourcekey="lblCodeResource1"  />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxCode" runat="server"  Width="180px" 
                                            meta:resourcekey="tbxCodeResource1"/>
                                    </td>
                                    <td>
                                        <asp:Label ID ="lblModel" runat="server" meta:resourcekey="lblModelResource1"  />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxModel" runat="server"  Width="180px" 
                                            meta:resourcekey="tbxModelResource1"/>
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
                            <asp:NewButton ID="btnSearch" runat="server"  Width ="60px" Text ="<%$ Resources:globalResource,SearchText %>"   OnClientClick ="return verify()"
                                   onclick="btnSearch_Click" meta:resourcekey="btnSearchResource1"/>&nbsp;
                            <asp:NewButton ID="btnNew" runat="server"  Width ="60px"  Text ="<%$ Resources:globalResource,NewText %>" 
                                   OnClientClick ="return makeWindow('NEW','')" 
                                meta:resourcekey="btnNewResource1" />
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
                    SkinID="skinGridView" Width ="100%" onrowdatabound="GVList_RowDataBound" DataKeyNames ="MIMeasureDataId"
                meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" 
                     onrowdeleting="GVList_RowDeleting">
                  <Columns>
                      <asp:BoundField  DataField="OrderNo" SortExpression ="c.orderno"  
                            meta:resourcekey="BoundFieldResource1"/>
                      <asp:BoundField  DataField="Model" SortExpression ="c.description" 
                            meta:resourcekey="BoundFieldResource2"/>
                      <asp:BoundField  DataField="Code" SortExpression ="c.meterialno" 
                            meta:resourcekey="BoundFieldResource3"/>
                      <asp:BoundField  DataField="SerialNo" SortExpression ="a.serial_no" 
                            meta:resourcekey="BoundFieldResource4"/>
                      <asp:BoundField  DataField="LastUpdateDate" SortExpression ="a.last_update_date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" 
                            meta:resourcekey="BoundFieldResource5"/>
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" runat ="server"  meta:resourcekey="ImgBtnEditResource1" EnableViewState="false"
                             ImageUrl ="<%$ Resources:globalResource,FormEditImageUrl %>"/>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat ="server" CommandName ="delete" meta:resourcekey="ImgBtnDeleteResource1"
                            ImageUrl="<%$ Resources:globalResource,FormDeleteImageUrl %>"/>
                        </ItemTemplate>
                     </asp:TemplateField>
               </Columns>     
            </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style ="padding-top:10px">
                <webdiyer:AspNetPager ID="PagerNavigator"   runat="server"
                    onpagechanged="PagerNavigator_PageChanged" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:HiddenField ID="hfdCurLink" runat="server" /> 
            </td>
        </tr>
    </table>
</center>
</asp:Content>
