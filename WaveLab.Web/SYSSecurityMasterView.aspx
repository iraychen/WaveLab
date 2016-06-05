<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSSecurityMasterView.aspx.cs" Inherits="WaveLab.Web.SYSSecurityMasterView" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
 <center>  
   <br /><br />
  <table  width="300px">
    <tr>
        <td>
            <asp:Label ID="lblTitle" runat="server" ForeColor ="red" Font-Bold ="True"   Font-Size="14px"
                meta:resourcekey="lblTitleResource1" /><br/><br/>
        </td>
    </tr>
    <tr>
        <td>
            <fieldset>
               <table  style ="width:100%; text-align:left">
                 <tr style ="height:40px">
                    <td  style ="width:70px">
                        <asp:Label ID ="lblUser" runat="server" meta:resourcekey="lblUserResource1" />:
                    </td>
                    <td>
                        <asp:Label ID="lblUserId" runat ="server" 
                            meta:resourcekey="lblUserIdResource1"  ForeColor ="Blue"/>
                    </td>
                 </tr>
                 <tr style ="height:40px">
                    <td >
                        <asp:Label ID ="lblPwd" runat="server" meta:resourcekey="lblPwdResource1" />:
                    </td>
                    <td>
                        <asp:Label ID="lblPassWord" runat ="server" 
                            meta:resourcekey="lblPassWordResource1"  ForeColor ="Blue"/>
                    </td>
                 </tr>
               </table> 
            </fieldset>
        </td>
    </tr>
    <tr>
        <td>
            <br />
           <table>
            <tr>
                <td>
                    <asp:NewButton ID="btnExport" runat="server"   Width="80"
                        meta:resourcekey="btnExportResource1" onclick="btnExport_Click" />
                </td>
                <td>
                    <asp:NewButton ID="btnClose" runat="server"   Width="80"
                        meta:resourcekey="btnCloseResource1"  OnClientClick ="self.close();return false;"/>
                </td>
            </tr>
           </table>
           
           &nbsp;
           
        </td>
    </tr>
  </table>
 </center>      
</asp:Content>
