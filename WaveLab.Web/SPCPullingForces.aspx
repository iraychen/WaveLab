<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCPullingForces.aspx.cs" Inherits="WaveLab.Web.SPCPullingForces" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
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
function makeWindow(mode,key)
{
    var url;
    switch(mode)
    {
        case "NEW":
            url = "SPCPullingForceNew.aspx?backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url = "SPCPullingForceEdit.aspx?key=" + key+"&backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break ;
        default:
            break;
    }
    var paras="toolbar=0,status=0,scrollbars=1,resizable=0,width=750px,Height=580px";
    var win=window.open(url,"secwin",paras);   
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
        <td>
           <fieldset>
           <table width="100%" border ="0" cellpadding="2" cellspacing ="0">
                <tr>
                    <td>
                        <table style =" width:100%">
                             <tr>
                                <td>
                                    <asp:Label ID ="lblMachineNo" runat ="server" meta:resourcekey="lblMachineNoResource1"/>
                                </td>
                                <td>
                                    <asp:TextBox ID ="tbxMachineNo" runat ="server"  Width="180px" 
                                        meta:resourcekey="tbxMachineNoResource1"/>
                                </td>
                                <td><asp:Label ID="lblOperator" runat="server" meta:resourcekey="lblOperatorResource1"/></td>
                                <td>
                                    <asp:TextBox ID="tbxOperator" runat="server"  Width="180px" 
                                        meta:resourcekey="tbxOperatorResource1"/>
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
             <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False"  DataKeyNames="PullingForcePK"
                SkinID="skinGridView" Width ="100%" meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" 
                 onrowdeleting="GVList_RowDeleting" onrowdatabound="GVList_RowDataBound">
              <Columns>
                  <asp:BoundField  DataField="MachineNo" SortExpression ="Machine_No"  
                        meta:resourcekey="BoundFieldResource1"/>
                  <asp:BoundField  DataField="WorkingDate" SortExpression ="Working_Date"  DataFormatString="{0:yyyy-MM-dd}"
                        meta:resourcekey="BoundFieldResource2"/>
                  <asp:BoundField  DataField="MWMType" SortExpression ="MWM_Type"  
                        meta:resourcekey="BoundFieldResource3"/>
                  <asp:BoundField  DataField="MachinePressure" SortExpression ="Machine_Pressure"  
                        meta:resourcekey="BoundFieldResource4"/>
                  <asp:BoundField  DataField="PowerFirstPoint" SortExpression ="Power_First_Point"  
                        meta:resourcekey="BoundFieldResource5"/>
                  <asp:BoundField  DataField="PowerSecondPoint" SortExpression ="Power_Second_Point"  
                        meta:resourcekey="BoundFieldResource6"/>
                  <asp:BoundField  DataField="Operator" SortExpression ="Operator"  
                        meta:resourcekey="BoundFieldResource7"/>
                  <asp:BoundField  DataField="X1" SortExpression ="X1"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource8"/>
                  <asp:BoundField  DataField="X2" SortExpression ="X2"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource9"/>
                  <asp:BoundField  DataField="X3" SortExpression ="X3"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource10"/>
                  <asp:BoundField  DataField="X4" SortExpression ="X4"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource11"/>
                  <asp:BoundField  DataField="X5" SortExpression ="X5"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource12"/>
                  <asp:BoundField  DataField="X6" SortExpression ="X6"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource13"/>
                  <asp:BoundField  DataField="X7" SortExpression ="X7"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource14"/>
                  <asp:BoundField  DataField="X8" SortExpression ="X8"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource15"/>
                  <asp:BoundField  DataField="X9" SortExpression ="X9"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource16"/>
                  <asp:BoundField  DataField="X10" SortExpression ="X10"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource17"/>
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtEdit" runat ="server"  meta:resourcekey="lbtEditResource1" />
                        <asp:LinkButton ID="lbtDelete" runat ="server" CommandName="Delete"  meta:resourcekey="lbtDeleteResource1" />
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
