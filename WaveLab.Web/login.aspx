<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WaveLab.Web.login" meta:resourcekey="PageResource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login Page</title>
    <link type="text/css" rel="stylesheet" href="css/jquery-ui-1.8.17.custom.css" />
    <script type="text/javascript" src="js/jquery-1.4.2.js"></script>
    <script type ="text/javascript" src ="js/jquery-ui-1.8.17.custom.js" ></script>
    <script type="text/javascript">
        $(document).ready( function() {
			$("input:submit").button();
			$("#btnLogin").bind("click",function(){
                if($("#tbxUserName").val().length==0){
                    alert($("#labUserNameMsg").attr("title"));
                    $("#tbxUserName").focus();
                    return false;
                }
                if($("#tbxPassWord").val().length==0){
                    alert($("#labPassWordMsg").attr("title"));
                    $("#tbxPassWord").focus();
                    return false;
                } 
               
                return true;
			});
			$("#btnClear").bind("click",function(){
			    document.all.form1.reset();
                return false;
			});
		});
    </script>
    <style type ="text/css">
        html,body,form{height: 100%;}
        .content {table-layout: fixed;border-collapse: collapse;height: 100%;width: 100%;}    
        .content thead td { height: 50px; border-bottom:solid 1px #BFBFBF; background-color:#fefefe; padding-left:10px;}   
        .content tfoot td { height: 20px;}   
    </style>
</head>
<body >
    <form id="form1" runat="server" >         
        <table class ="content">
            <thead>
                <tr >
                    <td valign="top">
                        <asp:Image ID="imgLogo" runat="server"  ImageUrl="~/images/logo.png" 
                            meta:resourcekey="imgLogoResource1"/> 
                    </td>
                     <td align ="right" valign ="top">
                          <asp:Label ID="labEnvironment" runat="server"   SkinId="skinEnvironment"    Font-Bold ="true"
                                    Text="<%$Resources:globalResource,environment %>"/>
                     </td>
                </tr>
            </thead>
            <tbody>
                 <tr>
                    <td align ="center" colspan ="2" style="vertical-align:top;padding-top:70px">
                        <table style ="height:350px" >
                            <tr>
                                <td style ="width:500px;" align="center" valign ="top">
                                   <table  style="text-align:left;" cellpadding="0"  cellspacing ="0">
                                        <tr style ="height:35px">
                                            <td><asp:Image ID="imgUabrand" runat="server"  ImageUrl="~/images/Uabrand.gif" Border="0"/> </td>
                                            <td>
                                               <asp:Image ID="imgSystemName" runat="server"  ImageUrl="~/images/system-name.png" Border="0" 
                                                    meta:resourcekey="imgsystem_name_loginResource1"/>
                                            </td>
                                        </tr>
                                        <tr style="height:35px"><td colspan="2"></td></tr>
                                        <tr style ="height:65px;">
                                             <td><asp:Image ID="imgSettings" runat="server"  ImageUrl="~/images/settings.png" Border="0" Height="16"/></td>
				                             <td><asp:Label ID="lblTimeOut" runat="server" 
						                            meta:resourcekey="lblTimeOutResource1" /></td>
                                        </tr>
                                        <tr style ="height:65px">
                                             <td ><asp:Image ID="imgComputer" runat="server"  ImageUrl="~/images/computer.png" Border="0" Height="16"/></td>
				                             <td><asp:Label ID="lblComputer" runat="server" 
						                            meta:resourcekey="lblComputerResource1" /></td>
                                        </tr>
                                        <tr style ="height:65px">
                                             <td ><asp:Image ID="imgTip" runat="server"  ImageUrl="~/images/account.png" Border="0" Height="16"/></td>
				                             <td><asp:Label ID="lblAccount" runat="server" 
						                            meta:resourcekey="lblAccountResource1" /></td>
                                        </tr>
                                         <tr style ="height:65px">
                                             <td ><asp:Image ID="imgHelp" runat="server"  ImageUrl="~/images/help.png" Border="0" Height="16"/></td>
				                             <td><asp:Label ID="lblHelp" runat="server" 
						                            meta:resourcekey="lblHelpResource1" /></td>
                                        </tr>
                                   </table>   
                                </td>
                                <td style ="width:1px" >
                                    <table style="height:350px;border-left:solid 1px #BFBFBF"><tr><td></td></tr></table>
                                </td>
                                <td style ="width:499px;" valign="top" align="center">
                                    <table style ="text-align:left;height:100%" cellpadding="0" cellspacing ="0">
                                        <tr style ="height:35px">
                                           <td>
                                                <table  cellpadding="0"  cellspacing ="0">
                                                    <tr>
                                                       <td style ="padding-top:2px"><asp:Image ID="imgKey" runat="server"  ImageUrl="~/images/key.png" Border="0"/> </td>
                                                       <td>
                                                          <asp:Image ID="imgUserLogin" runat="server"  ImageUrl="~/images/user-login.png" Border="0" 
                                                    meta:resourcekey="imgUserLoginResource1"/>
                                                       </td>
                                                    </tr>
                                                </table>
                                           </td>
                                        </tr>
                                        <tr style="height:35px"><td></td></tr>
                                        <tr>
                                            <td>
                                                <table style="border:solid 1px #bfbfbf; background-color:#eeeeee;  width:300px; height:250px"  cellspacing ="20" >
                                                    <tr>
                                                        <td>
		                                                    <table cellspacing ="0">
		                                                        <tr>
		                                                            <td valign="top"><asp:Image ID="imgLoginUser" runat="server"  ImageUrl="~/images/login_user.gif" Border="0" Height="17"/></td>
		                                                            <td valign="bottom"><asp:Label ID="labUserName" runat="server"  Font-Bold="true"
				                                                        meta:resourcekey="labUserNameResource" /></td>
		                                                        </tr>
		                                                    </table>
			                                            </td>
                                                    </tr>
                                                    <tr >
				                                        <td>
					                                        <asp:TextBox ID="tbxUserName" runat="server"  Width="250px" 
						                                        meta:resourcekey="tbxUserNameResource" TabIndex="1"  MaxLength ="50"/>
                        								   
					                                        <asp:Label ID ="labUserNameMsg" runat ="server"  meta:resourcekey="labUserNameMsgResource"/>
				                                        </td>
			                                        </tr>
			                                        <tr >
			                                             <td>
				                                            <table cellspacing ="0">
				                                                <tr>
				                                                    <td valign="top"> <asp:Image ID="imgLoginPassword" runat="server"  ImageUrl="~/images/login_password.png" Border="0" Height="17"/></td>
				                                                    <td valign="bottom"><asp:Label ID="labPassWord" runat="server"  Font-Bold="true"
						                                        meta:resourcekey="labPassWordResource" /></td>
				                                                </tr>
				                                            </table>
				                                        </td>
			                                        </tr>
			                                        <tr>
				                                        <td>
					                                        <asp:TextBox ID="tbxPassWord" runat="server"  TextMode ="Password" Width="250px"
							                                         meta:resourcekey="tbxPassWordResource" TabIndex="2" MaxLength ="50"/> 
					                                        <asp:Label ID ="labPassWordMsg" runat ="server" meta:resourcekey="labPassWordMsgResource"/>
				                                        </td>
			                                        </tr>
			                                        <tr style ="height:40px">
			                                            <td>
			                                          
                                                            <asp:NewButton ID="btnLogin" runat="server" meta:resourcekey="btnLoginResource"  Font-Size="Larger"
                                                                Width="80px"  Height="25" TabIndex="3" onclick="btnLogin_Click" />&nbsp;
                                                           <asp:NewButton ID="btnClear" runat="server" meta:resourcekey="btnClearResource" Font-Size="Larger" 
                                                                Width="80px"  Height="25" TabIndex="4" />
			                                            </td>
			                                        </tr>
                                                </table>
                                            </td>
                                        </tr>
                                   </table>   
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td valign ="top" colspan ="2">
                        <table style ="width:100%; margin-top:30px">
                            <tr>
                                <td valign="bottom">
                                    <table style="border-bottom:solid 1px #BFBFBF;width:100%;">
                                        <tr><td></td></tr>
                                    </table>
                                </td>
                            </tr>
                           <tr>
                                 <td align="left" style ="padding-left:10px"  >
						                <asp:Label ID="lblTip" runat="server" 
				                                 meta:resourcekey="lblTipResource1" />
		                         </td>
                            </tr>
                        </table>
                    </td>
                    
                </tr>
               
            </tfoot>
        </table> 
    </form>
</body>
</html>
