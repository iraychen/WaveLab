<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MAMDataRangeCtl.aspx.cs" Inherits="WaveLab.Web.MAMDataRangeCtl" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
});

function verify() {
    return true;
}

function makeWindow(mode,key1,key2,key3,key4)
{
    var url;
    switch(mode)
    {
        case "NEW":
            url = "MAMDataRangeNew.aspx?backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break;
        case "EDIT":
            url = "MAMDataRangeEdit.aspx?key1=" + key1 + "&key2=" + key2 + "&key3=" + key3 +"&key4=" + key4+ "&backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
            break ;
        default:
            break;
    }
    var winparas="toolbar=0,status=0,scrollbars=1,resizable=1,width=750px,Height=580px";
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
<table width ="99%" style="text-align:left" border ="0" cellpadding="0" cellspacing ="0">
        <tr>
           <td >
               <fieldset>
               <table width="100%" border ="0" cellpadding="2" cellspacing ="0">
                    <tr>
                        <td>
                            <table style =" width:100%">
                                 <tr>
                                    <td>
                                        <asp:Label ID ="lblMAMType" runat ="server"  meta:resourcekey="lblMAMTypeResource1"/>
                                    </td>
                                    <td colspan ="3">
                                        <asp:DropDownList ID ="ddlMAMType" runat ="server"  Width ="150"
                                            meta:resourcekey="ddlMAMTypeResource1"/>
                                    </td>
                                 </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID ="lblData" runat="server" meta:resourcekey="lblDataResource1"  />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxData" runat="server"  Width="180px" 
                                            meta:resourcekey="tbxDataResource1"/>
                                    </td>
                                    <td>
                                        <asp:Label ID ="lblDescription" runat="server" 
                                            meta:resourcekey="lblDescriptionResource1"  />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxDescription" runat="server"  Width="180px" 
                                            meta:resourcekey="tbxDescriptionResource1"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align ="right">
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
                 <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False"  
                    SkinID="skinGridView" Width ="100%" onrowdatabound="GVList_RowDataBound" DataKeyNames ="MAMType,Data"
                meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" 
                     onrowdeleting="GVList_RowDeleting">
                  <Columns>
                      <asp:BoundField  DataField="MAMTypeDesc" SortExpression ="A.MAM_TYPE"  
                            meta:resourcekey="BoundFieldResource1"/>
                      <asp:BoundField  DataField="Data" SortExpression ="A.DATA" 
                            meta:resourcekey="BoundFieldResource2"/>
                      <asp:BoundField  DataField="Description" SortExpression ="A.DESCRIPTION" 
                            meta:resourcekey="BoundFieldResource3"/>
                      <asp:BoundField  DataField="Unit" SortExpression ="A.UNIT" 
                            meta:resourcekey="BoundFieldResource4"/>
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" runat ="server"  
                                meta:resourcekey="ImgBtnEditResource1" EnableViewState="False"
                             ImageUrl ="<%$ Resources:globalResource,FormEditImageUrl %>"/>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat ="server" CommandName ="delete" meta:resourcekey="ImgBtnDeleteResource1"
                            ImageUrl="<%$ Resources:globalResource,FormDeleteImageUrl %>"/>
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
