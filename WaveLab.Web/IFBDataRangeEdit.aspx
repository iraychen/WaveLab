<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="IFBDataRangeEdit.aspx.cs" Inherits="WaveLab.Web.IFBDataRangeEdit" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready(function()
{
    $("input:submit").button();

    $("#<%=GVList.ClientID %> :checkbox:gt(0)").bind("click", function() {
        if ($(this).attr("checked") == true) {
            $.each($(this).parents("tr:first").find(":text"), function() {
                $(this).removeAttr("disabled");
            });
        } else {
            $.each($(this).parents("tr:first").find(":text"), function() {
                $(this).val("");
                $(this).attr("disabled", "disabled");
            });
        }
    });
});

function allCheck() {
    $.each($("#<%=GVList.ClientID %> :checkbox:gt(0)"), function() {
        $(this).attr("checked", $("#allCheckBox").attr("checked"));
    });
}

function verify()
{
    var recCount = 0;
    $.each($("#<%=GVList.ClientID %> :checkbox:gt(0)"), function() {
        if ($(this).attr("checked") == true) {
            recCount++;
        }
    });
    if (recCount == 0) {
        alert($("#<%=lblRecCountMsg.ClientID %>").attr("title"));
        return false;
    } else {
        
    }
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<table style=" text-align:left ;"  width="100%">
   <tr>
        <td>
           <asp:Label ID ="lblTitle1" runat="server"   Font-Bold ="True" 
             meta:resourcekey="lblTitle1Resource1" />
        </td>
    </tr>
   <tr>
       <td>
          <fieldset>
             <table width="100%" class="form-table">
                <tr>
                    <td>
                        <asp:Label ID ="lblData" runat="server" ForeColor ="Red" meta:resourcekey="lblDataResource1"  />
                    </td>
                    <td>
                       <asp:Literal ID="ltlData" runat ="server" meta:resourcekey="ltlDataResource1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID ="lblDescription" runat="server" 
                            meta:resourcekey="lblDescriptionResource1"  />
                    </td>
                    <td>
                        <asp:TextBox ID ="tbxDescription" runat="server"  Width="400px" 
                            meta:resourcekey="tbxDescriptionResource1"/>
                    </td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lblUnit" runat="server" 
                            meta:resourcekey="lblUnitResource1"/></td>
                    <td>
                         <asp:TextBox ID="tbxUnit" runat="server" Width="400px" 
                             meta:resourcekey="tbxUnitResource1" />
                    </td>
                 </tr>
              </table>
          </fieldset>  
      </td>
   </tr>
   <tr>
        <td>
           <asp:Label ID ="lblTitle2" runat="server"   Font-Bold ="True" 
             meta:resourcekey="lblTitle2Resource1" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GVList" runat="server"   GridLines ="None"  SkinID="skinGridView"
                    AutoGenerateColumns="False"  Width ="100%"   onrowdatabound="GVList_RowDataBound"
                    meta:resourcekey="GVListResource1">
              <Columns>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource1" >
                    <HeaderTemplate >
                        <input type ="checkbox" id="allCheckBox" OnClick='JavaScript:allCheck()' />
                        <asp:Label ID="lblAll" runat="server" meta:resourcekey="lblAllResource1" />
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:CheckBox ID="check" runat="server" meta:resourcekey="checkResource1" />
                    </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField meta:resourcekey="TemplateFieldResource2" >
                    <ItemTemplate>
                        <asp:Literal ID="ltlFrequency" runat ="server"   
                            Text='<%# Eval("Frequency") %>'/>
                    </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField meta:resourcekey="TemplateFieldResource3" >
                    <ItemTemplate>
                        <asp:TextBox ID="tbxLowerBound" runat ="server" 
                            meta:resourcekey="tbxLowerBoundResource1" />
                    </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource4" >
                    <ItemTemplate>
                        <asp:TextBox ID="tbxUpperBound" runat ="server" 
                            meta:resourcekey="tbxUpperBoundResource1" />
                    </ItemTemplate>
                 </asp:TemplateField>
                   <asp:TemplateField meta:resourcekey="TemplateFieldResource5" >
                    <ItemTemplate>
                        <asp:TextBox ID="tbxTarget" runat ="server" 
                            meta:resourcekey="tbxTargetResource1" />
                    </ItemTemplate>
                 </asp:TemplateField>
              </Columns>
              <RowStyle BackColor ="White" />
              <AlternatingRowStyle BackColor ="White" />
            </asp:GridView>
        </td>
    </tr>
   <tr>
        <td align="right">
            <br />
             <asp:Label ID="lblRecCountMsg" runat ="server" 
                            meta:resourcekey="lblRecCountMsgResource1" />
            <asp:NewButton  ID="btnSave" runat="server"  Width ="80px" Text ="<%$ Resources:globalResource,SaveText %>"
                OnClientClick="return verify()" onclick="btnSave_Click" 
                meta:resourcekey="btnSaveResource1"/>
            &nbsp;
            <asp:NewButton ID="btnCancel" runat ="server"  Width ="80px" Text ="<%$ Resources:globalResource,CancelText %>"
                OnClientClick="return cancel()" meta:resourcekey="btnCancelResource1" />
        </td>
    </tr>
  </table>
</asp:Content>

