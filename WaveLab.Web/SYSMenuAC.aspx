<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSMenuAC.aspx.cs" Inherits="WaveLab.Web.SYSMenuAC" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script  type="text/javascript">
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
   
<table style=" text-align:left ;"  width="100%" cellpadding="5">
   <tr>
    <td>
        <table style="text-align:left; font-weight:normal; width:100%;">
            <tr>
                <td>
                     <asp:Label ID="lblMenu" runat="server"/> &nbsp;
                     <asp:Label ID="lblMenuInfo"  runat="server" ForeColor="Blue" 
                         meta:resourcekey="lblMenuInfoResource1" ></asp:Label>
                </td>
            </tr>
            <tr align="center" >
                <td>
                    <asp:Label ID="lblRoleCount" runat="server" 
                        meta:resourcekey="lblRoleCountResource1"></asp:Label>
                </td>
            </tr>
            <tr>
               <td>
                   <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  AutoGenerateColumns="False" 
                   DataKeyNames="RoleId" meta:resourcekey="GVListResource1" EnableViewState="true" SkinID="skinGridView"
                       onrowdatabound="GVList_RowDataBound" onsorting="GVList_Sorting"   >
                      <Columns>
                         <asp:BoundField  SortExpression ="role_desc" DataField="RoleDesc" 
                              meta:resourcekey="BoundFieldResource1"/>
                         <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
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
    <td align ="right">
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
