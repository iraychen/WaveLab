<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCTxPowerItems.aspx.cs" Inherits="WaveLab.Web.SPCTxPowerItems" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
});
function verify() {
//    var type = $("#<%=tbxType.ClientID %>");
//    if ($.trim(type.val()).length == 0) {
//        alert($("#<%=lblTypeMsg.ClientID %>").attr("title"));
//        type.focus();
//        return false;
//    }
    return true;
}
function makeWindow(popType,type,mode,ch,pw) {
   var url;
   var win;
   var strPara = "toolbar=0,status=0,scrollbars=1,resizable=1,width=1000px,Height=700px";
   var strDialogPara = "left=50%,toolbar=0,status=0,scrollbars=1,resizable=1,width=780px,Height=580px";
   switch (popType) {
       case "GROUP":
           url = "SPCTxPowerManualGroup.aspx?type=" + type + "&mode=" + mode + "&ch=" + ch + "&pw=" + pw ;
           win = window.open(url, "secwin", strPara);
           break;
       case "APPENDITEM":
           url = "SPCTxPowerItemSelector.aspx?backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
           win = window.open(url, "secwin", strDialogPara);
           break;
       case "Edit":
           url = "SPCTxPowerItemEdit.aspx?TxPowerItemPK=" + type + "&backlink=" + $("#<%=hfdCurLink.ClientID %>").val();
           paras = "toolbar=0,status=0,scrollbars=1,resizable=0,width=700px,Height=500px";
           win = window.open(url, "secwin", paras);
           break;  
       default:
           break;
   }
 
   return false;

}
function returnVal(id, value) {
    $("#" + id).val(value);
}

</script>

<style type ="text/css">
    div{padding:1px}
</style>
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
                                        <asp:Label ID ="lblType" runat="server" meta:resourcekey="lblTypeResource1"  />
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="tbxType" runat="server"  Width="200px" 
                                            meta:resourcekey="tbxTypeResource1"/>
                                        <asp:Label ID ="lblTypeMsg" runat ="server" 
                                            meta:resourcekey="lblTypeMsgResource1" />
                                       <%-- <asp:Button ID="btnBrower" runat ="server"  OnClientClick ="return makeWindow('MODEL')"
                                            meta:resourcekey="btnBrowerResource1"/>--%>
                                    </td>
                                    <td>
                                        <asp:Label ID ="lblItems" runat="server" meta:resourcekey="lblItemsResource1" />
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rblItems" runat="server" meta:resourcekey="rblItemsResource1" RepeatDirection="Horizontal" >
                                            <asp:ListItem  meta:resourcekey="ListItemResource2" Selected ="True" ></asp:ListItem>
                                            <asp:ListItem meta:resourcekey="ListItemResource1"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align ="right">
                            
                            <asp:NewButton ID="btnSearch" runat="server"  Width ="80px"   OnClientClick ="return verify()"
                                   onclick="btnSearch_Click" meta:resourcekey="btnSearchResource1"/>&nbsp;
                            <asp:NewButton ID="btnAppendItem" runat="server"  Width ="80px"   OnClientClick ="return makeWindow('APPENDITEM')"
                                    meta:resourcekey="btnAppendItemResource1"/>&nbsp;
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
                    SkinID="skinGridView" Width ="100%" onrowdatabound="GVList_RowDataBound"
                meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" OnRowDeleting="GVList_RowDeleting" >
                  <Columns>
                      <asp:BoundField  DataField="Type" SortExpression ="a.type"  
                            meta:resourcekey="BoundFieldResource1"/>
                      <asp:BoundField  DataField="Mode" SortExpression ="b.mode" 
                            meta:resourcekey="BoundFieldResource2"/>
                      <asp:BoundField  DataField="CH" SortExpression ="b.ch" 
                            meta:resourcekey="BoundFieldResource3"/>
                      <asp:BoundField  DataField="PW" SortExpression ="b.pw" 
                            meta:resourcekey="BoundFieldResource4"/>
                      
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                           <asp:LinkButton ID="btnSelect" runat ="server" 
                                meta:resourcekey="btnSelectResource1" />
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                        <ItemTemplate>
                        <asp:LinkButton ID="lbtEdit" runat ="server"  meta:resourcekey="lbtEditResource1" />
                        &nbsp;
                        <asp:HiddenField ID="TxPowerItemPK" runat="server" />
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
