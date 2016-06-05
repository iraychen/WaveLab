<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCProjectIndex.aspx.cs" Inherits="WaveLab.Web.SPCProjectIndex" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready(function() {
    $("input:submit").button();    
});
function makeWindow(mode,key)
{
    var url,paras;
    switch(mode)
    {
        case "Edit":
            url = "SPCProjectEdit.aspx?ProjectCode=" + key ;
            paras = "toolbar=0,status=0,scrollbars=1,resizable=0,width=700px,Height=500px";
            break;
        default:
            break;
    }
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
        <td><asp:Label ID="lblRecCount" runat="server" 
                meta:resourcekey="lblRecCountResource1" /></td>
    </tr>
    
    <tr>
        <td>
             <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False" 
                SkinID="skinGridView" Width ="100%" meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" 
                  onrowdatabound="GVList_RowDataBound">
              <Columns>
                  <asp:BoundField  DataField="ProjectCode" SortExpression ="Project_Code"  
                        meta:resourcekey="BoundFieldResource1"/>
                  <asp:BoundField  DataField="ProjectDesc" SortExpression ="Project_Desc"  
                        meta:resourcekey="BoundFieldResource2"/>
                  <asp:BoundField  DataField="MinTimes" SortExpression ="Min_Times"  
                        meta:resourcekey="BoundFieldResource3"/>
                  <asp:BoundField  DataField="MaxTimes" SortExpression ="Max_Times"  
                        meta:resourcekey="BoundFieldResource4"/>
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtEdit" runat ="server"  meta:resourcekey="lbtEditResource1" />
                    </ItemTemplate>
                 </asp:TemplateField>
           </Columns>     
        </asp:GridView>
        </td>
    </tr>    
</table>
</center>
</asp:Content>