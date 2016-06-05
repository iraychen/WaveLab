<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SampleTemplateCtl.aspx.cs" Inherits="WaveLab.Web.SampleTemplateCtl" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

    <script type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function redirect(mode,value)
{
    var url;
    switch(mode)
    {
        case "NEW":
            url="SampleTemplateNew.aspx";
            break;
        default:
            break;
    }
    self.location.href=url;
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
<table width ="800" style="text-align:left" border ="0" cellpadding="0" cellspacing ="0">
        <tr>
            <td>
                <table width ="100%">
                    <tr>
                        <td>
                           <asp:Label ID="lblSampleTemplateId" runat="server" meta:resourcekey="lblSampleTemplateIdoResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxSampleTemplateId" runat="server" MaxLength="50" 
                                meta:resourcekey="tbxSampleTemplateIdResource1" />
                         </td>
                    </tr>
                </table>
            </td>
            <td valign ="bottom" align ="right">
                <asp:NewButton ID="btnSearch" runat="server"    Width ="60px" 
                    meta:resourcekey="btnSearchResource1" onclick="btnSearch_Click"/>&nbsp;
                <asp:NewButton ID="btnNew" runat="server"  Width ="60px"  
                     meta:resourcekey="btnNewResource1" 
                    OnClientClick ="return redirect('NEW','')" />   
            </td>
        </tr>
        <tr>
            <td align ="center" colspan ="2"><br /><asp:Label ID="lblRecCount" runat="server" 
                    meta:resourcekey="lblRecCountResource1" /></td>
        </tr>
        <tr>
            <td colspan ="2">
                <asp:GridView ID="GVList" runat="server" AllowSorting ="True" Width ="100%"
                    AutoGenerateColumns="False"   DataKeyNames="SampleTemplateId,EffectiveDate" 
                    meta:resourcekey="GVListResource1" onsorting="GVList_Sorting"  SkinID ="skinGridView"
                    onrowdatabound="GVList_RowDataBound" onrowcommand="GVList_RowCommand" 
                    onrowdeleting="GVList_RowDeleting" >
                  <Columns>
                     <asp:BoundField   DataField="SampleTemplateId"  SortExpression ="sample_template_id"
                          meta:resourcekey="BoundFieldResource1"/>
                     <asp:BoundField   DataField="EffectiveDate"  DataFormatString="{0:yyyy-MM-dd}" SortExpression ="effective_date"
                          meta:resourcekey="BoundFieldResource2"/>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
					    <ItemTemplate>
					        <asp:LinkButton ID="lbtView" runat="server"  CommandName ="view"   CommandArgument ='<%# Eval("documentpath") %>'
                                meta:resourcekey="lbtViewResource1" />
					    </ItemTemplate>
					 </asp:TemplateField>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource2" >
					    <ItemTemplate>
					        <asp:LinkButton ID="lbtDelete" runat="server"  CommandName ="delete" 
                                meta:resourcekey="lbtDeleteResource1" />
					    </ItemTemplate>
					 </asp:TemplateField>
                  </Columns>
                </asp:GridView>
              <br />
            </td>
        </tr>
         <tr>
            <td colspan ="2" style ="padding-top:10px">
                <webdiyer:AspNetPager ID="PagerNavigator" runat="server" 
                    onpagechanged="PagerNavigator_PageChanged"/>
            </td>
        </tr>
    </table>
</center>
</asp:Content>

