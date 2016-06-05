<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSSecurityMasterRoleMapping.aspx.cs" Inherits="WaveLab.Web.SYSSecurityMasterRoleMapping" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function allCheck()
{
    $.each($("#<%=GVList.ClientID %> :checkbox:gt(0)"),function(){
            $(this).attr("checked", $("#allCheckBox").attr("checked"));
	});
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
    <table style ="text-align:left;width:100%" cellpadding="5" >
        <tr>
            <td>
                <table style ="text-align:left;width:100%" >
                    <tr>
                        <td style ="width:50px">
                           <asp:Label ID="lblUserId" runat="server" meta:resourcekey="lblUserIdResource1"  
                                Font-Bold ="True"/>
                        </td>
                        <td  style ="width:550px">
                            <asp:Label ID="lblUserIdVal" runat="server" meta:resourcekey="lblUserIdValResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="2">
                            <asp:Label ID ="lblRecCount" runat ="server" meta:resourcekey="lblRecCountResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="2">
                             <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  AutoGenerateColumns="False" 
                               DataKeyNames="RoleId" meta:resourcekey="GVListResource1" SkinID="skinGridView"
                               onrowdatabound="GVList_RowDataBound" onsorting="GVList_Sorting"   Width="100%" >
                                  <Columns>
                                     <asp:BoundField  DataField="roleDesc"  SortExpression ="role_desc"
                                          meta:resourcekey="BoundFieldResource1"/>
                                     <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                        <HeaderTemplate >
                                            <input type ="checkbox" id="allCheckBox" OnClick='JavaScript:allCheck()' />
                                            <asp:Label ID="lblAll" runat="server" meta:resourcekey="lblAllResource1" />
                                        </HeaderTemplate>
                                        <ItemTemplate >
                                            <asp:CheckBox ID="check" runat="server" meta:resourcekey="checkResource1" />
                                        </ItemTemplate>
                                     </asp:TemplateField>
                                  </Columns>
                               </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right">
                <br />
                <asp:NewButton ID="btnSave" runat="server"  Width ="80"   Text ="<%$ Resources:globalResource,SaveText %>"
                    Action ="MenuRoleMappingSave" onclick="btnSave_Click" />
                  &nbsp;&nbsp;
                <asp:NewButton ID="btnReset" runat="server"  Width ="80"  Text ="<%$ Resources:globalResource,ResetText %>"
                  OnClientClick  ="return formReset();"/>
                 &nbsp;
                 <asp:NewButton ID="btnCancel" runat ="server" Width ="80"  Text ="<%$ Resources:globalResource,CancelText %>"
                    OnClientClick="return cancel()" />
            </td>
        </tr>
    </table>
</center>
</asp:Content>
