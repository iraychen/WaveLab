<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTPCBPriorityItemCtl.aspx.cs" Inherits="WaveLab.Web.SMTPCBPriorityItemCtl" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
 <script  type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function allCheck()
{
    $.each($("#<%=GVList.ClientID %> :checkbox:gt(0):enabled"),function(){
            $(this).attr("checked", $("#allCheckBox").attr("checked"));
	});
}

function verify()
{
    return true;
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
           <td colspan ="2">
            <table width="350" border ="0" cellpadding="0" cellspacing ="0">
                <tr>
                    <td>
                        <table border ="0" cellpadding ="0" cellspacing ="0"  width ="100%">
                            <tr>
                                <td>
                                   <asp:Label ID="lblPCB" runat="server" 
                                        meta:resourcekey="lblPCBResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxPCB" runat="server" MaxLength="50"  Width ="200"
                                        meta:resourcekey="tbxPCBResource1" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align ="right">
                        <asp:NewButton ID="btnSearch" runat="server"    Width ="60px" 
                            meta:resourcekey="btnSearchResource1" onclick="btnSearch_Click"/>&nbsp;
                    </td>
                </tr>
               
            </table>
           </td>
        </tr>
        <tr>
            <td align ="center" colspan ="2"><br /><asp:Label ID="lblRecCount" runat="server" 
                    meta:resourcekey="lblRecCountResource1" /></td>
        </tr>
        <tr>
            <td colspan ="2">
                <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                    AutoGenerateColumns="False"  Width ="100%"  DataKeyNames ="pcb"
                    meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" 
                    onrowdatabound="GVList_RowDataBound"  >
                  <Columns>
                     
                     <asp:BoundField  SortExpression ="a.pcb" DataField="pcb" 
                          meta:resourcekey="BoundFieldResource1"/>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
                        <HeaderTemplate >
                     <%--    <input type ="checkbox" id="allCheckBox" OnClick='JavaScript:allCheck()' />
                            <asp:Label ID="lblAll" runat="server" meta:resourcekey="lblAllResource1" />&nbsp;&nbsp;--%>
                            <asp:Label ID ="lblPriorityItem" runat="server"  meta:resourcekey="lblPriorityItemResource1"/>
                           
                        </HeaderTemplate>
                        <ItemTemplate >
                            <asp:CheckBox ID="cbxSelect" runat="server" 
                                meta:resourcekey="cbxSelectResource1"/>
                        </ItemTemplate>
                     </asp:TemplateField>
                  </Columns>
                </asp:GridView>
                <br />
                 <asp:Label ID ="lblNoRecordsCheck" runat="server" meta:resourcekey="lblNoRecordsCheckResource1" />
            </td>
        </tr>
    </table>
    <asp:NewButton ID="btnSave" runat="server" Width ="80px"  cl-table  OnClientClick ="return verify()"
                            meta:resourcekey="btnSaveResource1" 
        onclick="btnSave_Click"/>
                            &nbsp;
    <asp:NewButton ID="btnReset" runat="server" Width="80px" 
        OnClientClick ="return formReset()" cl-table 
        meta:resourcekey="btnResetResource1"  />                            
</center>
</asp:Content>
