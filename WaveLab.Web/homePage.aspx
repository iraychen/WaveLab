<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="WaveLab.Web.homePage" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<center>
<table style ="text-align:left; width:700px" cellpadding ="20">
     <tr>
        <td colspan ="3">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblBusinessPhilosophy" runat="server"  Font-Size ="13px" Font-Bold ="true"
                            meta:resourcekey="lblBusinessPhilosophyResource1" />
                    </td>
                </tr>
                <tr>
                    <td><asp:Literal ID="ltlBusinessPhilosophy" runat="server" 
                             meta:resourcekey="ltlBusinessPhilosophyResource1" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblQualityPolicy" runat="server"  Font-Size ="13px" Font-Bold ="true"
                             meta:resourcekey="lblQualityPolicyResource1" />
                   </td>
                </tr>
                <tr>
                    <td><asp:Literal ID="ltlQualityPolicy" runat="server" 
                            meta:resourcekey="ltlQualityPolicyResource1" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="img1" runat ="server" ImageUrl ="~/images/theme1.png" BorderWidth ="1" />
        </td>
        <td align="center">
            <asp:Image ID="img2" runat ="server" ImageUrl ="~/images/theme2.png" BorderWidth ="1" />
        </td>
        <td align="right">
            <asp:Image ID="img3" runat ="server" ImageUrl ="~/images/theme3.png" BorderWidth ="1" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="img4" runat ="server" ImageUrl ="~/images/theme4.png" BorderWidth ="1" />
        </td>
        <td align="center">
            <asp:Image ID="img5" runat ="server" ImageUrl ="~/images/theme5.png" BorderWidth ="1" />
        </td>
         <td  align="right">
            <asp:Image ID="img6" runat ="server" ImageUrl ="~/images/theme6.png" BorderWidth ="1" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="img7" runat ="server" ImageUrl ="~/images/theme7.png" BorderWidth ="1"/>
        </td>
        <td align="center">
            <asp:Image ID="img8" runat ="server" ImageUrl ="~/images/theme8.png" BorderWidth ="1"/>
        </td>
         <td  align="right">
            <asp:Image ID="img9" runat ="server" ImageUrl ="~/images/theme9.png" BorderWidth ="1"/>
        </td>
    </tr>
</table>
</center>
</asp:Content>
