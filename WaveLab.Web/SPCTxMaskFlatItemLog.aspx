<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCTxMaskFlatItemLog.aspx.cs" Inherits="WaveLab.Web.SPCTxMaskFlatItemLog" meta:resourcekey="PageResource1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script  type ="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
});
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<table style ="width:100%" cellpadding="3">
    <tr>
        <td>
            <fieldset style="width:100%">
             <table style ="text-align:left; width:100%">
                  <tr>
                    <td><asp:Label ID="lblType" runat ="server" meta:resourcekey="lblTypeResource1" /></td>
                    <td><asp:Literal ID="ltlType" runat ="server" meta:resourcekey="ltlTypeResource1" /></td>
                    <td><asp:Label ID="lblMode" runat ="server" meta:resourcekey="lblModeResource1" /></td>
                    <td ><asp:Literal ID="ltlMode" runat ="server" 
                            meta:resourcekey="ltlModeResource1" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblCH" runat ="server" meta:resourcekey="lblCHResource1" /></td>
                    <td><asp:Literal ID="ltlCH" runat ="server" meta:resourcekey="ltlCHResource1" /></td>
                </tr>
             </table>
             </fieldset>
        </td>
    </tr>
    <tr>
        <td><asp:Label ID ="lblRecCount" runat ="server" 
                meta:resourcekey="lblRecCountResource1" /></td>
    </tr>
    <tr>
        <td>
        <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False"  
              SkinID="skinGridView"  Width ="100%" 
            meta:resourcekey="GVListResource1"  >
              <Columns>                 
                  <asp:BoundField  DataField="USL"  DataFormatString="{0:f2}"
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource2">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                 <asp:BoundField  DataField="LCL_X"  DataFormatString="{0:f2}"
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource3">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                   <asp:BoundField  DataField="UCL_X"   DataFormatString="{0:f2}"
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource4">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField  DataField="LCL_R"   DataFormatString="{0:f2}"
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource5">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                   <asp:BoundField  DataField="UCL_R"  DataFormatString="{0:f2}"
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource6">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                   <asp:BoundField  DataField="LastUpdateDate"   DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource7">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
              </Columns>
        </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" Width="80px" meta:resourcekey="btnBackResource1"/>
        </td>
    </tr>
</table>

</asp:Content>
