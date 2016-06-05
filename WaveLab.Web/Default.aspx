<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WaveLab.Web._default"  meta:resourcekey="PageResource1"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>无标题页</title>
    <link type="text/css" rel="stylesheet" href="css/jquery-ui-1.8.17.custom.css"/>
    <link type="text/css" rel="stylesheet" href="css/jquery.layout.css" />
    <link type="text/css" rel="stylesheet" href="css/jquery.ztree.css"/>
    
    <script type="text/javascript" src="js/jquery-1.4.2.js"></script>
    <script type ="text/javascript" src ="js/jquery-ui-1.8.17.custom.js"></script>
    <script type="text/javascript" src="js/jquery.layout.js"></script>
    <script type="text/javascript" src="js/jquery.ztree.js"></script>
	<script type="text/javascript">
	    $(document).ready(function(){
            var pageLayout = $("body").layout({
	            defaults: {size:"auto",	paneClass:"pane",resizerClass:"resizer",togglerClass:"toggler",		
                    buttonClass:"button",contentIgnoreSelector:"span",hideTogglerOnSlide:true,		
                    togglerTip_open:"",togglerTip_closed:"", resizerTip:"",sliderTip: "",fxName:"slide",
                    fxSpeed_open:500,fxSpeed_close:500,fxSettings_open:{ easing: "easeInQuint" },fxSettings_close:{ easing: "easeOutQuint" }
	            },	
	            north: {size:55,spacing_open:1,closable:false,resizable:false},
	            west: {size:200,minSize:150,maxSize:300,spacing_open:4,contentSelector:".content",spacing_closed:21,togglerLength_closed:21,togglerAlign_closed:"top",	
                    togglerLength_open:0,togglerTip_open:"",togglerTip_closed:"",resizerTip_open:"",slideTrigger_open:"click",resizable:true
                },
	            center:{
	            }
            });
	        var westSelector = "body .ui-layout-west"; 
	        $("<span></span>").addClass("pin-button").prependTo( westSelector );
            pageLayout.addPinBtn( westSelector +" .pin-button", "west");
            
            var setting = {
                view: { showTitle: false},
			    data: {
			      simpleData: {enable: true }
			    }
		    };
            $.getJSON("SYSMenu.ashx",null,function(zNodes){
				$.fn.zTree.init($("#tree"), setting, zNodes);
            });
	    });
	    function makeWindow(url){
            var winparas="toolbar=0,status=0,scrollbars=1,resizable=0,width=700px,Height=500px";
            var win=window.open(url,"secwin",winparas);
            return false;
        }
	</script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="ui-layout-north">
            <table style ="text-align:left; width:100%; ">
                <tr>
                    <td style ="vertical-align:top;"> 
                       <div style ="float:left ;">
                            <asp:Image ID="imgLogo" runat="server" Border="0" meta:resourcekey="imgLogoResource1" />
                        </div>
                        <%-- <div style ="float:left ; position:relative; margin-top:10px; margin-left:5px;">
                            <asp:Image ID="imgSystemName" runat="server"  Border="0" meta:resourcekey="imgSystemNameResource1" />
                        </div>--%>
                    </td>
                    <td  align ="right" valign ="bottom">
                       <table  border ="0" cellpadding ="0" cellspacing ="0" style ="height:50px">
                        <tr style="height:25px">
                            <td align ="right" valign ="top">
                                <asp:Label ID="labEnvironment" runat="server"   SkinId="skinEnvironment" 
                                    Text="<%$Resources:globalResource,environment %>"/>
                            </td>
                        </tr>
                         <tr>
                            <td style="height:25px">
                                <table  border ="0" cellpadding ="2" cellspacing ="0">
                                    <tr>
                                        <td>
                                            <asp:Image ID="imgLoginUser" runat="server"  ImageUrl="~/images/login_user.gif" Border="0" Height="16" />
                                        </td>
                                        <td>
                                           <asp:LinkButton ID="lbtUser" runat="server" 
                                                meta:resourcekey="lbtUserResource1" OnClientClick ="return false;"/>
                                        </td>
                                        <td valign ="bottom"  style ="padding-bottom:6px">
                                            <asp:Label ID ="lblSeparator1" runat ="server" Text ="|" />
                                        </td>   
                                        <td>
                                           <asp:LinkButton ID="lbtSetup" runat="server"
                                                meta:resourcekey="lbtSetupResource1" OnClientClick ="makeWindow('PersonalizedSetup.aspx');return false;"/>
                                        </td>
                                         <td valign ="bottom"  style ="padding-bottom:6px">
                                            <asp:Label ID ="lblSeparator2" runat ="server" Text ="|" />
                                        </td>   
                                        <td>
                                            <asp:LinkButton ID="lbtLogout" runat="server" 
                                                meta:resourcekey="lbtLogoutResource1" onclick="lbtLogout_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            
                        </tr>
                    </table>
                    </td>
                </tr>
            </table>
        </div>

        <div class="ui-layout-west">
            <div class="header"></div>
            <div class="content">
               <ul id="tree" class="ztree"  style="text-align:left"></ul>
            </div>
        </div>
        <div class="ui-layout-center">
            <iframe   name="main"  src="homePage.aspx" frameborder="0"></iframe>
        </div>
    </form>
</body>
 </html>
  
















