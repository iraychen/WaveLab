﻿<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSActionCtl.aspx.cs" Inherits="WaveLab.Web.SYSActionCtl" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
    $("input:submit").button();
});
function verify()
{
    var action=$("#<%=tbxAction.ClientID %>");
 
    if(trim(action.val()).length==0)
    {
       alert($("#<%=lblActionMsg.ClientID %>").attr("title"));
       action.focus();
       return false;
    }
    return true;
}
 function makeWindow(mode,value,value1)
{
    var url;
    switch(mode)
    {
        case "AC":
            url="SYSActionAC.aspx?actionid="+value+"&tvvalue="+value1;
            break;
        default:
            break;
    }
    var winparas="toolbar=0,status=0,scrollbars=1,resizable=0,width=700px,Height=500px";
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
<table style="text-align:left" border ="0" cellpadding="0" cellspacing ="0">
        <tr>
            <td valign="top">
                <table style ="width:100%">
                    <tr>
                        <td>
                             <asp:Label ID="lblModule" runat ="server" 
                                meta:resourcekey="lblModuleResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="overflow :auto; height:450px; width:200px; border:solid 1px gray">
                                <asp:TreeView ID="tvMenu" runat="server" Width="100%"  AutoPostBack="true"  
                                    CollapseImageToolTip="" ExpandImageToolTip="" NodeWrap="True" 
                                    AutoGenerateDataBindings="False" ShowLines="True"  ExpandDepth="0"  
                                    meta:resourcekey="tvMenuResource1" 
                                    onselectednodechanged="tvMenu_SelectedNodeChanged">
                                    <NodeStyle  ForeColor="DarkBlue" Font-Underline="False" Width="100%" BorderStyle="None"  />
                                    <SelectedNodeStyle ForeColor="#FF3300" BackColor="#FFCCFF" Font-Bold="True" 
                                        Font-Underline="True" />
                                </asp:TreeView>
                            </div>
                        </td>
                    </tr>
                </table>           
            </td>
            <td valign ="top">
             <asp:UpdatePanel ID="updatePanel" runat="server">
                <ContentTemplate>
                <table style ="width:100%">
                     <tr>
                        <td align ="right" id="tdNew" runat="server" >
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID ="lblAction" runat ="server" 
                                            meta:resourcekey="lblActionResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxAction" runat ="server"  MaxLength="50"  Width ="200"
                                            meta:resourcekey="tbxActionResource1"/>
                                        <asp:Label ID ="lblActionMsg" runat ="server" 
                                            meta:resourcekey="lblActionMsgResource1" />
                                    </td>
                                    <td>
                                        <asp:Label ID ="lblActionName" runat ="server" 
                                            meta:resourcekey="lblActionNameResource1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxActionName" runat ="server"  MaxLength="50"  Width ="200"
                                            meta:resourcekey="tbxActionNameResource1"/>
                                    </td>
                                    <td style ="white-space:nowrap">
                                       
                                        <asp:NewButton ID="btnSave" runat="server"  Width ="60px"   Enabled ="false"
                                                OnClientClick ="return verify()" 
                                            meta:resourcekey="btnSaveResource1" onclick="btnSave_Click"  />
                                        <asp:NewButton ID="btnUpdate" runat="server"  Width ="60px"  Enabled ="false"
                                                OnClientClick ="return verify()" 
                                            meta:resourcekey="btnUpdateResource1" onclick="btnUpdate_Click"  />       
                                    </td>
                                </tr>
                               
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID ="lblRecCount" runat ="server" meta:resourcekey="lblRecCountResource1" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                             <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                                AutoGenerateColumns="False"  Width ="100%" DataKeyNames ="ActionId"
                                meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" 
                                 onrowdatabound="GVList_RowDataBound" 
                                 onselectedindexchanged="GVList_SelectedIndexChanged" 
                                  onrowdeleting="GVList_RowDeleting"   >
                                  <Columns>
                                    <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="role_desc">
                                        <ItemTemplate>
                                           <asp:LinkButton ID="lbtEdit" runat ="server"  CommandName ="select"
                                                meta:resourcekey="lbtEditResource1"/>
                                        </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:BoundField DataField ="Action" SortExpression ="action" 
                                          meta:resourcekey="BoundFieldResource1" />
                                     <asp:BoundField DataField ="ActionName" SortExpression ="action_name" 
                                          meta:resourcekey="BoundFieldResource2" />
                                      <asp:TemplateField meta:resourcekey="TemplateFieldResource2" >
                                        <ItemTemplate>
                                           <asp:NewLinkButton ID="lbtDelete" runat ="server"  Action="ActionDelete" CommandName ="Delete" 
                                            meta:resourcekey="lbtDeleteResource1" />
                                        </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField meta:resourcekey="TemplateFieldResource3" >
                                        <ItemTemplate>
                                           <asp:NewLinkButton ID="lbtAC" runat ="server"  meta:resourcekey="lbtACResource1" />
                                        </ItemTemplate>
                                     </asp:TemplateField>
                                  </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                 </ContentTemplate>
               <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                   <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                   <asp:AsyncPostBackTrigger ControlID="GVList" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</center>
</asp:Content>
