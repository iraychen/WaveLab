<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTFileInduceBUC.aspx.cs" Inherits="WaveLab.Web.CPBatchUpdateComents" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type="text/javascript" >
$(document).ready( function() {
	$("input:submit").button();
});
function verify()
{
  var pcb=$("#<%=tbxPCB.ClientID %>");
  if(trim(pcb.val()).length==0)
  {
    alert($("#<%=lblPCBMsg.ClientID%>").attr("title"));
    return false;
  }
  return true ;
}

function allCheck()
{
    $.each($("#<%=GVList.ClientID %> :checkbox:gt(0):enabled"),function(){
        $(this).attr("checked", $("#allCheckBox").attr("checked"));
	});
}

function formSubmit()
{
    var count=0;
    $.each($("#<%=GVList.ClientID %> :checkbox:gt(0):checked"),function(){
        count++;
	});
	if(count==0)
	{
	    alert($("#<%=lblZeroCountMsg.ClientID%>").attr("title"));
	    return false;
	}
	else 
	{
	    return true;
	}
}

function Clear()
{
    $("#<%=tbxComments.ClientID%>").val("");
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
<table width ="100%"  border ="0" cellpadding="0" cellspacing ="0" >
        <tr>
           <td align="center">
            <table width="500">
                <tr>
                    <td>
                        <table border ="0" cellpadding ="0" cellspacing ="0"  width ="100%">
                           <tr>
                                <td><asp:Label ID="lblSYSModuleType" runat="server"  meta:resourcekey="lblSYSModuleTypeResource1"/></td>
                                <td>
                                    <asp:DropDownList ID="ddlSYSModuleType" runat="server" />
                                </td>

                                <td><asp:Label ID="lblPCB" runat="server" ForeColor="Red" 
                                        meta:resourcekey="lblPCBResource1" /></td>
                                <td>
                                    <asp:TextBox ID="tbxPCB" runat="server"  MaxLength ="40"  Width ="200px"
                                        meta:resourcekey="tbxPCBResource1"/>
                                    <asp:Label ID="lblPCBMsg" runat="server" 
                                        meta:resourcekey="lblPCBMsgResource1" />
                                </td>
                                
                            </tr>
                            
                        </table>
                    </td>
                    <td >
                        <asp:NewButton ID="btnSearch" runat="server"    Width ="80"  OnClientClick ="return verify()"
                            meta:resourcekey="btnSearchResource1" onclick="btnSearch_Click"/>
                    </td>
                </tr>
            </table>
           </td>
        </tr>
        <tr>
            <td align="center"><br /><asp:Label ID="lblRecCount" runat="server" 
                    meta:resourcekey="lblRecCountResource1" /></td>
        </tr>
        <tr>
            <td align="center">
               <table id ="tblCP" runat  ="server" width ="800" style ="text-align :left">
                    <tr>
                        <td colspan ="2">    
                            <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                            AutoGenerateColumns="False"  Width ="100%"  DataKeyNames="MaterialCode,MaterialDesc,PCB"
                            meta:resourcekey="GVListResource1"
                             onsorting="GVList_Sorting">
                              <Columns>
                                  <asp:TemplateField meta:resourcekey="TemplateFieldResource1"  SortExpression ="a.module_type_id" >
                                    <ItemTemplate>
                                        <%#Eval("ModuleTypeItem.ModuleTypeDesc")%>
                                    </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:BoundField  DataField ="MaterialCode"  SortExpression ="material_code"
                                      meta:resourcekey="BoundFieldResource1" />
                                 <asp:BoundField  DataField ="MaterialDesc"  SortExpression ="material_desc"
                                      meta:resourcekey="BoundFieldResource2" />
                                 <asp:BoundField  DataField ="PCB" SortExpression ="pcb" 
                                      meta:resourcekey="BoundFieldResource3"  />
                                 <asp:BoundField  DataField ="Comments" SortExpression ="comments" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                                      meta:resourcekey="BoundFieldResource20" />
                                  <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
                                    <HeaderTemplate >
                                        <input type ="checkbox" id="allCheckBox" onclick='JavaScript:allCheck()' />
                                        <asp:Label ID="lblAll" runat="server" meta:resourcekey="lblAllResource1" />&nbsp;&nbsp;
                                    </HeaderTemplate>
                                    <ItemTemplate >
                                        <asp:CheckBox ID="cbxSelect" runat="server" 
                                            meta:resourcekey="cbxSelectResource1"/>
                                    </ItemTemplate>
                                 </asp:TemplateField>    
                              </Columns>
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <%--<td colspan="2" align="center">
                            <fieldset style="width:350px;">
                                <legend><asp:Label ID="lblComments" runat="server"
                                        meta:resourcekey="lblCommentsResource1"/></legend>
                                <asp:TextBox ID="tbxComments" runat="server"  TextMode ="MultiLine"  Rows="5" Width ="300px"
                                 meta:resourcekey="tbxCommentsResource1" MaxLength ="100" />       
                            </fieldset>
                        </td>--%>
                        <td valign ="top" align="right" style ="width:35%">
                            <asp:Label ID="lblComments" runat="server"
                                        meta:resourcekey="lblCommentsResource1"/>
                        </td>
                        <td align ="left" style ="width:75%">
                             <asp:TextBox ID="tbxComments" runat="server"  TextMode ="MultiLine"  Rows="5" Width ="300px"
                                 meta:resourcekey="tbxCommentsResource1" MaxLength ="100" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:Label ID="lblZeroCountMsg" runat="server"
                                        meta:resourcekey="lblZeroCountMsgResource1"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="center"  colspan ="2" >
                            <asp:NewButton ID="btnSave"  runat="server"   Width ="100px"  OnClientClick ="return formSubmit()"
                            meta:resourcekey="btnSaveResource1" onclick="btnSave_Click" />
                            &nbsp;
                            <asp:NewButton ID="btnClear" runat ="server" Width ="100px"  OnClientClick ="return Clear()"
                            meta:resourcekey="btnClearResource1"
                            />
                         
                        </td>
                    </tr>
               </table>
            </td>
        </tr>
       
    </table>
</center>
</asp:Content>
