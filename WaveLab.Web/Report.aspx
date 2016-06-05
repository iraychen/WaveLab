<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="WaveLab.Web.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<style type="text/css">
 
  .list li {  list-style-type:katakana-iroha;    margin: 3px; padding: 0.4em; font-size: 1em; height: 18px;  }
  .list li a { font-weight:bold; text-decoration:underline; }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">

<table>
    <tr>
        <td>
            <asp:Image ID ="imgTitle" runat="server" SkinID ="ImgskinSearchTitle"  meta:resourcekey="imgTitleResource1" />
        </td>
        <td valign="bottom">  
            <asp:Label ID="lblTitle" runat="server" SkinId="skinTitle" meta:resourcekey="lblTitleResource1"/>
        </td>
    </tr>
</table>
<hr style="border-bottom:solid 1px #f5f5f5" />
<ol id="selectable" runat="server" class="list">

</ol>
</asp:Content>
