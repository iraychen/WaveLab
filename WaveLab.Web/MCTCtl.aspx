<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MCTCtl.aspx.cs" Inherits="WaveLab.Web.MCTCtl" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript">
$(document).ready(function()
{
 $(".date").datepicker({
   showOn:"button",
   buttonImageOnly:true,
   dateFormat:"yy-mm-dd",
   changeYear:true,
   changeMonth:true
 });
 
 $(".date").mask("9999-99-99",{});
 
 $("input:submit").button();
});
function verify()
{
    var creationdate=$("#<%=tbxCreationDate.ClientID %>");
    if(checkDate(creationdate.val())==false)
    {
      alert($("#<%=lblDateFormatMsg.ClientID %>").attr("title"));
      creationdate.focus();
      return false;
    }
    return true;
}
function makeWindow(mode,value)
{
    var url;
    var win;
    var strPara="toolbar=0,status=0,scrollbars=1,resizable=1,width=700px,Height=580px";
    switch(mode)
    {
        case "VIEW":
            url="MCTDetail.aspx?mctid="+value;
            break;
        default:
            break;
    }
    win=window.open(url,"secwin",strPara);
    return false;
}
function redirect(mode,value,value1,value2)
{
    var url;
    switch(mode)
    {
        case "RP":
            url="MCTReplace.aspx?suppliername="+value+"&partno="+value1+"&model="+value2+"&backlink="+$("#<%=hfdCurLink.ClientID %>").val();
            break ;
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
<table width ="99%" style="text-align:left" border ="0" cellpadding="0" cellspacing ="0">
     <tr>
       <td colspan ="2">
           <fieldset>
              <table width="100%">
                <tr>
                    <td>
                        <table border ="0" cellpadding ="0" cellspacing ="0"  width ="100%">
                            <tr>
                                <td>
                                   <asp:Label ID="lblSupplierName" runat="server" 
                                        meta:resourcekey="lblSupplierNameDescResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxSupplierName" runat="server" MaxLength="50"  
                                        meta:resourcekey="tbxSupplierNameResource1" />
                                </td>
                                <%-- <td>
                                   <asp:Label ID="lblCreatedBy" runat="server" 
                                        meta:resourcekey="lblCreatedByResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxCreatedBy" runat="server" MaxLength="50" 
                                        meta:resourcekey="tbxCreatedByResource1" />
                                </td>--%>
                                
                                 <td>
                                   <asp:Label ID="lblCreationDate" runat="server" 
                                        meta:resourcekey="lblCreationDateResource1" />
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxCreationDate" runat="server" MaxLength="10"  Width ="80" CssClass ="date"
                                        meta:resourcekey="tbxCreationDateResource1" />
                                    <asp:Label ID="lblDateFormat" runat ="server"   Text ="<%$Resources:globalResource,DateFormat%>" /> 
                                    <asp:Label ID="lblDateFormatMsg" runat ="server"   
                                        ToolTip ="<%$ Resources:globalResource,DateFormatMsg %>" 
                                        meta:resourcekey="lblDateFormatMsgResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label id ="lblPartNo" runat ="server" meta:resourcekey="lblPartNoResource1"/></td>
                                <td>
                                    <asp:TextBox ID ="tbxPartNo" runat ="server" meta:resourcekey="tbxPartNoResource1"/>
                                </td>
                                 <td><asp:Label id ="lblModel" runat ="server" meta:resourcekey="lblModelResource1"/></td>
                                <td colspan ="3">
                                    <asp:TextBox ID ="tbxModel" runat ="server" meta:resourcekey="tbxModelResource1"/>
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
           </fieldset>
       </td>
    </tr>
    <tr>
        <td align ="center" colspan ="2"><asp:Label ID="lblRecCount" runat="server" 
                meta:resourcekey="lblRecCountResource1" /></td>
    </tr>
    <tr>
        <td colspan ="2">
            <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  
                SkinId="skinGridView" DataKeyNames ="MCTId"
                AutoGenerateColumns="False"  Width ="100%"   EnableViewState ="false"
                meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" 
                onrowdatabound="GVList_RowDataBound" onrowdeleting="GVList_RowDeleting">
              <Columns>
                 <asp:BoundField  DataField ="SupplierName"  SortExpression ="supplier_name"
                      meta:resourcekey="BoundFieldResource1" >
                  </asp:BoundField>
               
                 <asp:BoundField  DataField ="PartNo"  SortExpression ="c.part_no" 
                      meta:resourcekey="BoundFieldResource10" />
                 <asp:BoundField  DataField ="Model"  SortExpression ="c.model" HtmlEncode ="false" 
                      meta:resourcekey="BoundFieldResource11" />
                 <asp:BoundField  DataField ="CreationDate"  SortExpression ="a.creation_date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"
                      meta:resourcekey="BoundFieldResource9" />
                 <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
                    <ItemTemplate>
                        <asp:LinkButton ID ="lbtView" runat ="server"   meta:resourcekey="lbtViewResource1" />
                    </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField meta:resourcekey="TemplateFieldResource2" >
                    <ItemTemplate>
                        <asp:LinkButton ID ="lbtReplace" runat ="server"   meta:resourcekey="lbtReplaceResource1" />
                    </ItemTemplate>
                 </asp:TemplateField>
                 <asp:ButtonField  ButtonType ="Link" CommandName ="delete" ItemStyle-Width ="30" 
                      meta:resourcekey="ButtonFieldResource1">
                  </asp:ButtonField>
              </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td colspan ="2" style ="padding-top:10px">
            <webdiyer:AspNetPager ID="PagerNavigator" runat="server" 
                onpagechanged="PagerNavigator_PageChanged"  />
        </td>
    </tr>
    <tr>
        <td colspan ="2">
            <asp:HiddenField ID="hfdCurLink" runat="server" /> 
        </td>
    </tr>
</table>
</center>
</asp:Content>