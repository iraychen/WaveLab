<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SerialNoList.aspx.cs" Inherits="WaveLab.Web.SerialNoList" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
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
    var orderNo = $("#<%=tbxOrderNo.ClientID %>");
    var code = $("#<%=tbxCode.ClientID %>");
    var model = $("#<%=tbxModel.ClientID %>");
    var serialNo = $("#<%=tbxSerialNo.ClientID %>");

    if ($.trim(orderNo.val()).length == 0 && $.trim(code.val()).length == 0 && $.trim(model.val()).length == 0 && $.trim(serialNo.val()).length == 0)
    {
      alert($("#<%=lblErrorMsg.ClientID %>").attr("title"));
      return false;
    }
    
    
    return true;
}

function Clear() {
    $("#<%=tbxOrderNo.ClientID %>").val("");
    $("#<%=tbxCode.ClientID %>").val("");
    $("#<%=tbxModel.ClientID %>").val("");
    $("#<%=tbxSerialNo.ClientID %>").val("");
    return false;
}

function Redirect(url) {
    document.location.href=url;
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
<br/>
<%--<asp:Label ID ="lblTitle" runat ="server" SkinID ="skinCTitle" meta:resourcekey="lblTitleResource1"/>
<br/>--%>

<table style =" width:100%">
    <tr>
        <td>
            <fieldset style="width:400px">
             <table cellpadding ="5" style ="text-align:left">
                 <tr>
                    <td>
                        <asp:Label ID ="lblOrderNo" runat ="server" meta:resourcekey="lblOrderNoResource1"/>
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxOrderNo" runat ="server"  Width="200px" 
                            meta:resourcekey="tbxOrderNoResource1"/>
                    </td>
                 </tr>
                 <tr>
                    <td>
                        <asp:Label ID ="lblModel" runat="server" meta:resourcekey="lblModelResource1"  />
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxModel" runat="server"  Width="200px" 
                            meta:resourcekey="tbxModelResource1"/>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID ="lblCode" runat="server" meta:resourcekey="lblCodeResource1"  />
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxCode" runat="server"  Width="200px" 
                            meta:resourcekey="tbxCodeResource1"/>
                    </td>
                 </tr>
                 <tr>
                    <td><asp:Label ID="lblSerialNo" runat="server" meta:resourcekey="lblSerialNoResource1"/></td>
                    <td>
                        <asp:TextBox ID="tbxSerialNo" runat="server"  Width="200px" 
                            meta:resourcekey="tbxSerialNoResource1"/>
                    </td>
                 </tr>
                </table>
        </fieldset>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblErrorMsg" runat ="server" meta:resourcekey="lblErrorMsgResource1"/>
            <asp:NewButton id="btnSubmit" Runat="server" Width="100px"  
                    OnClientClick ="return verify()" meta:resourcekey="btnSubmitResource1" 
                    onclick="btnSubmit_Click"/>&nbsp;
            <asp:NewButton ID="btnReset" runat="server" Width ="100px" 
                    OnClientClick ="return Clear()" meta:resourcekey="btnResetResource1"/>   
        </td>
    </tr>
    <tr>
        <td><asp:Label ID ="lblRecCount" runat ="server" /></td>
    </tr>
    <tr>
        <td>
        <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False"  
            EnableViewState ="False" SkinID="skinGridView"  Width ="500px" onrowdatabound="GVList_RowDataBound"
            meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" >
              <Columns>
                  <asp:BoundField  DataField="OrderNo" SortExpression ="a.orderno"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource1"/>
                  <asp:BoundField  DataField="MeterialDesc" SortExpression ="a.meterialno"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource2"/>
                   <asp:BoundField  DataField="MeterialCode" SortExpression ="a.description"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource3"/>
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource1" SortExpression ="b.serial_no"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtSerialNo" runat ="server" meta:resourcekey="lbtSerialNoResource1"/>
                    </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
        </asp:GridView>
        </td>
    </tr>
</table>
 </center>
</asp:Content>
