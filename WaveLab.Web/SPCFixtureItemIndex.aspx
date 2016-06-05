<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCFixtureItemIndex.aspx.cs" Inherits="WaveLab.Web.SPCFixtureItemIndex" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

    <script type="text/javascript">
$(document).ready(function() {
    $("input:submit").button();    
});
function makeWindow(mode,key)
{
    var url, paras;
    switch (mode) {
        case "Create":
            url = "SPCFixtureItemCreate.aspx?backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            paras = "toolbar=0,status=0,scrollbars=1,resizable=0,width=700px,Height=500px";
            break;
        case "Edit":
            url = "SPCFixtureItemEdit.aspx?FixtureItemPK=" + key + "&backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            paras = "toolbar=0,status=0,scrollbars=1,resizable=0,width=700px,Height=500px";
            break;
        case "DataInput":
            url = "SPCFixtureDataInput.aspx?FixtureItemPK=" + key + "&backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            paras = "toolbar=0,status=0,scrollbars=1,width=1000px,resizable=1,Height=700px";
            break;
        case "SPCView":
            url = "SPCFixtureReturnLossLatest.aspx?FixtureItemPK=" + key + "&backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            paras = "toolbar=0,status=0,scrollbars=1,resizable=1,width=1000px,Height=700px";
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
                                    <asp:Label ID ="lblFixture" runat ="server" meta:resourcekey="lblFixtureResource1"/>
                                </td>
                                <td>
                                    <asp:TextBox ID ="tbxFixture" runat ="server"  Width="180px" 
                                        meta:resourcekey="tbxFixtureResource1"/>
                                </td>
                                 <td>
                                <asp:Label ID ="lblFrequencyBand" runat ="server" meta:resourcekey="lblFrequencyBandResource1"/>
                            </td>
                            <td>
                                <asp:TextBox ID ="tbxFrequencyBand" runat ="server"  Width="180px" 
                                    meta:resourcekey="tbxFrequencyBandResource1"/>
                            </td>
                               
                             </tr>                             
                          <tr>                                
                            
                            <td>
                                    <asp:Label ID ="lblCH" runat ="server" meta:resourcekey="lblCHResource1"/>
                                </td>
                                <td>
                                    <asp:TextBox ID ="tbxCH" runat ="server"  Width="180px" 
                                        meta:resourcekey="tbxCHResource1"/>
                                </td>
                            <td></td>
                            <td></td>
                         </tr>   
                        </table>
                    </td>
                    <td align ="right">                   
                        <asp:NewButton ID="btnSearch" runat="server"  Width ="60px" OnClientClick ="return verify()"
                               onclick="btnSearch_Click" meta:resourcekey="btnSearchResource1"/>&nbsp;
                        <asp:NewButton ID="btnCreate" runat="server"  Width ="60px"  Text ="<%$ Resources:globalResource,CreateText %>" 
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
             <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False"  DataKeyNames="FixtureItemPK"
                SkinID="skinGridView" Width ="100%" meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" 
                 onrowdeleting="GVList_RowDeleting" onrowdatabound="GVList_RowDataBound">
              <Columns>
                  <asp:BoundField  DataField="Fixture" SortExpression ="Fixture" meta:resourcekey="BoundFieldResource1"/>
                  <asp:BoundField  DataField="FrequencyBand" SortExpression ="Frequency_Band" meta:resourcekey="BoundFieldResource2"/>
                   <asp:BoundField  DataField="CH" SortExpression ="CH" meta:resourcekey="BoundFieldResource3"/>
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtDataInput" runat ="server"  meta:resourcekey="lbtDataInputResource1" />                       
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtSPCView" runat ="server"  meta:resourcekey="lbtSPCViewResource1" />                      
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource5">
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
        <td style ="padding-top:10px">
            <webdiyer:AspNetPager ID="PagerNavigator"   runat="server" ShowPageIndex ="true"
                onpagechanged="PagerNavigator_PageChanged" />
        </td>
    </tr>
</table>
</center>
</asp:Content>
