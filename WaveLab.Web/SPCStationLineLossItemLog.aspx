<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCStationLineLossItemLog.aspx.cs" Inherits="WaveLab.Web.SPCStationLineLossItemLog" meta:resourcekey="PageResource1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script  type ="text/javascript">
$(document).ready(function() {
    $("input:submit").button();
});
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<table style ="width:100%">
    <tr>
        <td>
            <fieldset style="width:100%">
             <table style ="text-align:left; width:100%">
                  <tr>
                <td><asp:Label ID="lblStationNo" runat="server" 
                        meta:resourcekey="lblStationNoResource1"/></td>
                <td>
                    <asp:Literal ID="ltlStationNo" runat="server" 
                        meta:resourcekey="ltlStationNoResource1" />
                </td>
                    <td>
                        <asp:Label ID="lblCHNo" runat="server" 
                            meta:resourcekey="lblCHNoResource1"/>
                    </td>
                    <td>
                      <asp:Literal ID="ltlCHNo" runat="server" 
                            meta:resourcekey="ltlCHNoResource1"/>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblFrequencyBand" runat="server" 
                            meta:resourcekey="lblFrequencyBandResource1"/>
                    </td>
                    <td>
                      <asp:Literal ID="ltlFrequencyBand" runat="server" 
                            meta:resourcekey="ltlFrequencyBandResource1"/>
                    </td>
                    <td>
                        <asp:Label ID="lblItem" runat="server" 
                            meta:resourcekey="lblItemResource1"/>
                    </td>
                    <td>
                       <asp:Literal ID="ltlItem" runat="server" 
                            meta:resourcekey="ltlItemResource1"/>
                    </td>
                   
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
            meta:resourcekey="GVListResource1">
              <Columns>
                 <asp:BoundField  DataField="LCL_X"   DataFormatString="{0:f2}"
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource1">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                   <asp:BoundField  DataField="UCL_X"   DataFormatString="{0:f2}"
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource2">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField  DataField="LCL_MR"   DataFormatString="{0:f2}"
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource3">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                   <asp:BoundField  DataField="UCL_MR"   DataFormatString="{0:f2}"
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource4">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                   <asp:BoundField  DataField="LastUpdateDate"   DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource5">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
              </Columns>
        </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
              <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" Width="80px"  meta:resourcekey="btnBackResource1" />
        </td>
    </tr>
</table>

</asp:Content>
