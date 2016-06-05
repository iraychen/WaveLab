<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCTxMaskFlatDetail.aspx.cs" Inherits="WaveLab.Web.SPCTxMaskFlatOriginal" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">

<center>
<div style="width:650px; text-align:left">
<asp:GridView ID="GVGroupItems" runat="server" SkinId="skinGridView" EnableViewState="False"
    AutoGenerateColumns="False" 
        meta:resourcekey="GVGroupItemsResource1">
  <Columns>
      <asp:BoundField  DataField="SerialNo"
            meta:resourcekey="BoundFieldResource1">
          <HeaderStyle Width="30%" />
      </asp:BoundField>
      <asp:BoundField  DataField="EndTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" 
            meta:resourcekey="BoundFieldResource2">
          <HeaderStyle Width="30%" />
      </asp:BoundField>
      <asp:BoundField  DataField="Val"
            meta:resourcekey="BoundFieldResource3">
          <HeaderStyle Width="40%" />
      </asp:BoundField>
  </Columns>
</asp:GridView>  
</div>  
</center>
</asp:Content>
