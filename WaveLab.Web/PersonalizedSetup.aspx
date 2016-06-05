<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PersonalizedSetup.aspx.cs" Inherits="WaveLab.Web.PersonalizedSetup" Title="无标题页" meta:resourcekey="PageResource1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<link type="text/css" href="css/StyleSheet.css" media="screen" rel="stylesheet" />
<script type ="text/javascript" src ="js/jquery.keyfilter.js" ></script>
<script type="text/javascript" src="js/jQuery.dPassword.js"></script>
<script type ="text/javascript">
$(document).ready(function(){
   $(":password").keyfilter(/[0-9a-z]/);
   $("input:submit").button();
});
function verify()
{
  var pwd=$("#<%=tbxPwd.ClientID%>");
  var newPwd=$("#<%=tbxNewPwd.ClientID%>");
  var confirmPwd=$("#<%=tbxConfirmPwd.ClientID%>");
  if(pwd.val().length==0)
  {
    alert($("#<%=lblPwdMsg.ClientID %>").attr("title"));
    pwd.focus();
    return false;
  }
  if(newPwd.val().length==0)
  {
    alert($("#<%=lblNewPwdMsg.ClientID %>").attr("title"));
    newPwd.focus();
    return false;
  }
  if(confirmPwd.val().length==0)
  {
    alert($("#<%=lblConfirmPwdMsg.ClientID %>").attr("title"));
    confirmPwd.focus();
    return false;
  }
  if(newPwd.val()!=confirmPwd.val())
  {
    alert($("#<%=lblNotEqualMsg.ClientID %>").attr("title"));
    newPwd.val("");
    confirmPwd.val("");
    newPwd.focus();
    return false;
  }
  if(pwd.val().length<6)
  {
    alert($("#<%=lblTip.ClientID %>").attr("title"));
    pwd.focus();
    return false;
  }
  if(newPwd.val().length<6)
  {
    alert($("#<%=lblTip.ClientID %>").attr("title"));
    newPwd.focus();
    return false;
  }
  if(confirmPwd.val().length<6)
  {
    alert($("#<%=lblTip.ClientID %>").attr("title"));
    confirmPwd.focus();
    return false;
  }
  return true;
}
</script>
<style  type ="text/css">
.password {font-size : 12px;border : 1px solid #cc9933;width : 200px;font-family : arial, sans-serif;}
.pstrength-minchar {font-size : 10px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<ajaxToolkit:TabContainer runat="server" ID="TabContainer1" Height="500" ActiveTabIndex="0" Width="100%">
    <ajaxToolkit:TabPanel runat="server" ID="Panel1">
        <HeaderTemplate>
            <asp:Label ID="lblPasswordTitle" runat ="server"   meta:resourcekey="lblPasswordTitleResource1"></asp:Label>
        </HeaderTemplate>
        <ContentTemplate>
               <center>
                    <table style="text-align:left;"  border ="0" cellspacing ="0">
                        <tr style ="height :40px">
                            <td colspan ="2" align ="center">
                                <asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" 
                                    meta:resourcekey="lblTitleResource" />
                            </td>
                        </tr>
                        <tr  style ="height :40px">
                            <td>
                                <asp:Label ID="lblPwd" runat="server"  ForeColor="Red" 
                                    meta:resourcekey="lblPwdResource1"/>
                            </td>
                            <td>
                                <asp:TextBox ID="tbxPwd" runat="server" MaxLength="30" Width="200px"  
                                meta:resourcekey="tbxPwdResource1"  TextMode ="Password" />
                                <asp:Label ID="lblPwdMsg" runat="server"  ForeColor="Red" 
                                meta:resourcekey="lblPwdMsgResource1"/> 
                              
                            </td>
                        </tr>
                        <tr style =" height:40px">
                            <td>
                                <asp:Label ID="lblNewPwd" runat="server"  ForeColor="Red" 
                                    meta:resourcekey="lblNewPwdResource1"/>
                            </td>
                            <td>
                                <asp:TextBox ID="tbxNewPwd" runat="server" MaxLength="30"  Width="200px" CssClass="password"
                                    meta:resourcekey="tbxNewPwdResource1" TextMode ="Password"/>
                                     <asp:Label ID="lblNewPwdMsg" runat="server"  ForeColor="Red" 
                                    meta:resourcekey="lblNewPwdMsgResource1"/> 
                                    <ajaxToolkit:PasswordStrength ID="strengthNewPwd" runat="server" TargetControlID="tbxNewPwd"
                                    PreferredPasswordLength="10" 
                                    HelpStatusLabelID="TextBox1_HelpLabel"  
                                    StrengthStyles="TextIndicator_TextBox1_Strength1;TextIndicator_TextBox1_Strength2;TextIndicator_TextBox1_Strength3;TextIndicator_TextBox1_Strength4;TextIndicator_TextBox1_Strength5" 
                                    Enabled="True" 
                                    TextStrengthDescriptionStyles="TextIndicator_TextBox1_Strength1;TextIndicator_TextBox1_Strength2;TextIndicator_TextBox1_Strength3;TextIndicator_TextBox1_Strength4;TextIndicator_TextBox1_Strength5" />
                            </td>
                        </tr>
                        <tr style =" height:40px">
                            <td>
                                <asp:Label ID="lblConfirmPwd" runat="server"  ForeColor="Red" 
                                    meta:resourcekey="lblConfirmPwdResource1"/>
                            </td>
                            <td>
                                <asp:TextBox ID="tbxConfirmPwd" runat="server" MaxLength="30" Width="200px" CssClass="password"
                                    meta:resourcekey="tbxConfirmPwdResource1"  TextMode ="Password"/>
                                     <asp:Label ID="lblConfirmPwdMsg" runat="server"  ForeColor="Red" 
                                    meta:resourcekey="lblConfirmPwdMsgResource1"/> 
                                <ajaxToolkit:PasswordStrength ID="strengthConfirmPwd" runat="server" TargetControlID="tbxConfirmPwd"
                                    PreferredPasswordLength="10" 
                                    HelpStatusLabelID="TextBox1_HelpLabel"
                                    StrengthStyles="TextIndicator_TextBox1_Strength1;TextIndicator_TextBox1_Strength2;TextIndicator_TextBox1_Strength3;TextIndicator_TextBox1_Strength4;TextIndicator_TextBox1_Strength5" 
                                    Enabled="True" 
                                    TextStrengthDescriptionStyles="TextIndicator_TextBox1_Strength1;TextIndicator_TextBox1_Strength2;TextIndicator_TextBox1_Strength3;TextIndicator_TextBox1_Strength4;TextIndicator_TextBox1_Strength5" />
                            </td>
                        </tr>
                 
                        <tr style ="height:40px">
                            <td colspan ="2" align ="center">
                                <asp:Label ID="lblNotEqualMsg" runat="server"  ForeColor="Red" 
                                    meta:resourcekey="lblNotEqualMsgResource1"/> 
                                     <asp:Label ID="lblTip" runat ="server"  ForeColor ="Blue"  meta:resourcekey="lblTipResource1"/>
                                <br/>
                                <asp:NewButton ID="btnSubmit" runat="server"   Width ="80"  Text ="<%$ Resources:globalResource,EnsureText %>"
                                     OnClientClick ="return verify()" onclick="btnSubmit_Click"/>
                                &nbsp;&nbsp;
                                <asp:NewButton ID="btnClose" runat="server"   Width ="80" Text ="<%$ Resources:globalResource,CloseText %>"
                                     OnClientClick ="self.close();return false;"/>
                            </td>
                        </tr>
                        <tr style ="height:220px">
                            <td colspan ="2"></td>
                        </tr>
                    </table>
                    </center>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>
