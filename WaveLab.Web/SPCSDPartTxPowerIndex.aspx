<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCSDPartTxPowerIndex.aspx.cs" Inherits="WaveLab.Web.SPCSDPartTxPowerIndex" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

    <script type="text/javascript">
$(document).ready(function() {
    $("input:submit").button();    
});
function makeWindow(mode,stationProjectPK)
{
    var url, paras;
    switch (mode) {
        case "Create":
            url = "SPCSDPartTxPowerCreate.aspx?backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            paras = "toolbar=0,status=0,scrollbars=1,resizable=1,width=800px,Height=600px";
            break;
        case "Edit":
            url = "SPCSDPartTxPowerEdit.aspx?SDPartPK=" + stationProjectPK + "&backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            paras = "toolbar=0,status=0,scrollbars=1,resizable=0,width=700px,Height=500px";
            break;       
        default:
            break;
    }

    var win = window.open(url, "secwin", paras);
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
                                <asp:Label ID ="lblStationNo" runat ="server" meta:resourcekey="lblStationNoResource1"/>
                            </td>
                            <td>
                                <asp:TextBox ID ="tbxStationNo" runat ="server"  Width="180px" 
                                    meta:resourcekey="tbxStationNoResource1"/>
                            </td>
                            <td>
                                <asp:Label ID ="lblCHNo" runat ="server" meta:resourcekey="lblCHNoResource1"/>
                            </td>
                            <td>
                                <asp:CheckBox ID="chxDivide" runat="server" />
                            </td>
                         </tr> 
                          <tr>
                            <td>
                                 <asp:Label ID="lblMode" runat="server"  
                                    meta:resourcekey="lblModeResource1"/>
                            </td>
                            <td>
                              <asp:TextBox ID="tbxMode" runat="server" Width="180px"  meta:resourcekey="tbxModeResource1" Text="128QAM"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID ="lblSerialNo" runat="server" 
                                    meta:resourcekey="lblSerialNoResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbxSerialNo" runat="server"  Width="180px" 
                                    meta:resourcekey="tbxSerialNoResource1"></asp:TextBox>
                            </td>
                        </tr>                                                          
                        </table>
                    </td>
                    <td align ="right">                   
                        <asp:Button ID="btnSearch" runat="server"  Width ="60px"   
                               onclick="btnSearch_Click" meta:resourcekey="btnSearchResource1"/>&nbsp;
                        <asp:Button ID="btnCreate" runat="server"  Width ="60px"  Text ="<%$ Resources:globalResource,CreateText %>" 
                               OnClientClick ="return makeWindow('Create','')" 
                            meta:resourcekey="btnCreateResource1" />
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
             <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False"  DataKeyNames="SDPartPK"
                SkinID="skinGridView" Width ="100%" meta:resourcekey="GVListResource1" onsorting="GVList_Sorting"  
                 onrowdeleting="GVList_RowDeleting" onrowdatabound="GVList_RowDataBound">
              <Columns>
                  <asp:BoundField  DataField="StationNo" SortExpression ="Station_No" 
                        meta:resourcekey="BoundFieldResource1"/>
                 <asp:BoundField  DataField="CHNo" SortExpression ="CH_No"
                        meta:resourcekey="BoundFieldResource2"/>   
                  <asp:BoundField  DataField="Mode" SortExpression ="Mode" 
                        meta:resourcekey="BoundFieldResource3"/>
                 <asp:BoundField  DataField="CH" SortExpression ="CH"
                        meta:resourcekey="BoundFieldResource4"/>  
                  <asp:BoundField  DataField="PW" SortExpression ="PW"
                        meta:resourcekey="BoundFieldResource5"/>
                 <asp:BoundField  DataField="SerialNo" SortExpression ="Serial_No"
                        meta:resourcekey="BoundFieldResource6"/>
                 <asp:BoundField  DataField="Enable" SortExpression ="Enable"
                        meta:resourcekey="BoundFieldResource7"/>
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
        <td>
            <asp:HiddenField ID="hfdCurLink" runat="server" /> 
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
