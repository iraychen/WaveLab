<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCPullingForceTargets.aspx.cs" Inherits="WaveLab.Web.SPCPullingForceTargets" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
});
function makeWindow(mode,key)
{
    var url;
    switch(mode)
    {
        case "NEW":
            url = "SPCPullingForceTargetNew.aspx";
            break;
        case "EDIT":
            url = "SPCPullingForceTargetEdit.aspx?key=" + key;
            break ;
        default:
            break;
    }
    var paras="toolbar=0,status=0,scrollbars=1,resizable=0,width=700px,Height=500px";
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
        <td align ="right">
              <asp:NewButton ID="btnNew" runat="server"  Width ="60px" 
                            meta:resourcekey="btnNewResource1" OnClientClick ="return makeWindow('NEW','')" />
        </td>
    </tr>
    <tr>
        <td><asp:Label ID="lblRecCount" runat="server" 
                meta:resourcekey="lblRecCountResource1" /></td>
    </tr>
    
    <tr>
        <td>
             <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False"   DataKeyNames="PullingForceTargetPK"
                SkinID="skinGridView" Width ="100%" meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" 
                 onrowdeleting="GVList_RowDeleting" onrowdatabound="GVList_RowDataBound">
              <Columns>
                  <asp:BoundField  DataField="MachineNo" SortExpression ="Machine_No"  
                        meta:resourcekey="BoundFieldResource1"/>
                  <asp:BoundField  DataField="EffectiveDate" SortExpression ="Effective_Date"  DataFormatString="{0:yyyy-MM-dd}"
                        meta:resourcekey="BoundFieldResource2"/>
                  <asp:BoundField  DataField="UCL_X" SortExpression ="UCL_X"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource3"/>
                  <asp:BoundField  DataField="LCL_X" SortExpression ="LCL_X"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource4"/>
                  <asp:BoundField  DataField="CL_X" SortExpression ="CL_X "  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource5"/>
                  <asp:BoundField  DataField="UCL_R" SortExpression ="UCL_R"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource6"/>
                  <asp:BoundField  DataField="LCL_R" SortExpression ="LCL_R"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource7"/>
                  <asp:BoundField  DataField="CL_R" SortExpression ="CL_R"  DataFormatString="{0:f2}"
                        meta:resourcekey="BoundFieldResource8"/>
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
</table>
</center>
</asp:Content>
