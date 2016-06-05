<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTFileInduceNew.aspx.cs" Inherits="WaveLab.Web.SMTFileInduceNew" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready(function()
{
   $("#<%=ddlSYSModuleType.ClientID %>").bind("change",function()
   {
        var params="({";
        params+="\"ModuleTypeId\":\""+$(this).val()+"\"";
        params+="})";
        $.ajax({url:"SMTFileInduce.ashx",
				type: "Post",
				data:eval(params),
				dataType: "json",
				async:true,
				success: function(result){ 
				    //genBoard
				    if(result.HasGenBoard!=null && result.HasGenBoard=="N")
		            {
		                $("#<%=trGenBoard.ClientID%>").attr("disabled","disabled");
		                $("#<%=trGenBoard.ClientID%>"+" :input").val("");
		                $("#<%=trGenBoard.ClientID%>"+" :input").attr("disabled","disabled");
                    }
                    else
                    {
                        $("#<%=trGenBoard.ClientID%>").removeAttr("disabled");
                        $("#<%=trGenBoard.ClientID%>"+" :input").removeAttr("disabled");
                    }
                    
                    //SpeBoard
		            if(result.HasSpeBoard!=null && result.HasSpeBoard=="N")
		            {
		                $("#<%=trSpeBoard.ClientID%>").attr("disabled","disabled");
		                $("#<%=trSpeBoard.ClientID%>"+" :input").val("");
		                $("#<%=trSpeBoard.ClientID%>"+" :input").attr("disabled","disabled");
                    }
                    else
                    {
                        $("#<%=trSpeBoard.ClientID%>").removeAttr("disabled");
                        $("#<%=trSpeBoard.ClientID%>"+" :input").removeAttr("disabled");
                    }
                    
                    //SMTFabrication
				    if(result.HasSMTFabrication!=null && result.HasSMTFabrication=="N")
		            {
		                $("#<%=trSMTFabrication.ClientID%>").attr("disabled","disabled");
		                $("#<%=trSMTFabrication.ClientID%>"+" :input").val("");
		                $("#<%=trSMTFabrication.ClientID%>"+" :input").attr("disabled","disabled");
                    }
                    else
                    {
                        $("#<%=trSMTFabrication.ClientID%>").removeAttr("disabled");
                        $("#<%=trSMTFabrication.ClientID%>"+" :input").removeAttr("disabled");
                    }
                    
                    //ComponentPart
				    if(result.HasComponentPart!=null && result.HasComponentPart=="N")
		            {
		                $("#<%=trComponentPart.ClientID%>").attr("disabled","disabled");
		                $("#<%=trComponentPart.ClientID%>"+" :input").val("");
		                $("#<%=trComponentPart.ClientID%>"+" :input").attr("disabled","disabled");
                    }
                    else
                    {
                        $("#<%=trComponentPart.ClientID%>").removeAttr("disabled");
                        $("#<%=trComponentPart.ClientID%>"+" :input").removeAttr("disabled");
                    }
                    
                    //GroupPart
				    if(result.HasGroupPart!=null && result.HasGroupPart=="N")
		            {
		                $("#<%=trGroupPart.ClientID%>").attr("disabled","disabled");
		                $("#<%=trGroupPart.ClientID%>"+" :input").val("");
		                $("#<%=trGroupPart.ClientID%>"+" :input").attr("disabled","disabled");
                    }
                    else
                    {
                        $("#<%=trGroupPart.ClientID%>").removeAttr("disabled");
                        $("#<%=trGroupPart.ClientID%>"+" :input").removeAttr("disabled");
                    }
                    
                     //BondingFabrication
				    if(result.HasBondingFabrication!=null && result.HasBondingFabrication=="N")
		            {
		                $("#<%=trBondingFabrication.ClientID%>").attr("disabled","disabled");
		                $("#<%=trBondingFabrication.ClientID%>"+" :input").val("");
		                $("#<%=trBondingFabrication.ClientID%>"+" :input").attr("disabled","disabled");
                    }
                    else
                    {
                        $("#<%=trBondingFabrication.ClientID%>").removeAttr("disabled");
                        $("#<%=trBondingFabrication.ClientID%>"+" :input").removeAttr("disabled");
                    }
				}    
	    });	 
   });
   $("input:submit").button();
});
function verify()
{
    var materialCode=$("#<%=tbxMaterialCode.ClientID %>");
    var materialDesc=$("#<%=tbxMaterialDesc.ClientID %>");
    var pcb=$("#<%=tbxPCB.ClientID %>");
    var ModuleTypeId=$("#<%=ddlSYSModuleType.ClientID %>")
    if(trim(materialCode.val()).length==0)
    {
      alert($("#<%=lblMaterielCodeMsg.ClientID %>").attr("title"));
      materialCode.focus();
      return false;
    }
    if(trim(materialDesc.val()).length==0)
    {
      alert($("#<%=lblMaterielDescMsg.ClientID %>").attr("title"));
      materialDesc.focus();
      return false;
    }
    
    if(trim(pcb.val()).length==0)
    {
      alert($("#<%=lblPCBMsg.ClientID %>").attr("title"));
      pcb.focus();
      return false;
    }
    if(ModuleTypeId.val().length==0)
    {
      alert($("#<%=lblSYSModuleTypeMsg.ClientID %>").attr("title"));
      ModuleTypeId.focus();
      return false;
    }
    return true;
}

function goBack()
{
    self.location.href='<%=System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) %>';
    return false;
}
</script>
<style type="text/css">
    .titlestyle
    {
        width: 130px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<asp:ImageButton ID="imgBtnBack" runat ="server" SkinID ="imgBtnSkinBack"  
         OnClientClick ="return goBack()" meta:resourcekey="imgBtnBackResource1"/>
<center>
   <asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" meta:resourcekey="lblTitleResource1" /><br/>
 
  <table style="text-align:left; width:700px" border ="0" cellpadding ="3" cellspacing ="0" >
     <tr>
        <td>
            <fieldset>
                <legend>    
                    <asp:Label ID ="lblPrimaryKeyTitle" runat ="server" Font-Bold ="true" meta:resourcekey="lblPrimaryKeyTitleResource1" />
                </legend>
               <table  width="100%"  cellspacing ="0" cellpadding ="3">
                <tr>
                    <td>
                        <asp:Label ID="lblSYSModuleType" runat="server"  ForeColor ="Red" meta:resourcekey="lblSYSModuleTypeResource1"/>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSYSModuleType" runat="server"  meta:resourcekey="ddlSYSModuleTypeResource1" />
                        <asp:Label ID="lblSYSModuleTypeMsg" runat="server" meta:resourcekey="lblSYSModuleTypeMsgResource1" />
                    </td>
                    <td><asp:Label ID="lblPCB" runat="server" ForeColor="Red"  meta:resourcekey="lblPCBResource1" /></td>
                    <td>
                        <asp:TextBox ID="tbxPCB" runat="server"  MaxLength ="40"  Width ="200" meta:resourcekey="tbxPCBResource1"/>
                        <asp:Label ID="lblPCBMsg" runat="server"  meta:resourcekey="lblPCBMsgResource1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID ="lblMaterialCode" runat="server"  ForeColor ="Red" meta:resourcekey="lblMaterialCodeResource1"/>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxMaterialCode" runat="server" MaxLength ="13"  Width ="200" meta:resourcekey="tbxMaterialCodeResource1" />
                        <asp:Label ID="lblMaterielCodeMsg" runat="server"  meta:resourcekey="lblMaterialCodeMsgResource1" />
                    </td>
                    <td>
                        <asp:Label ID="lblMaterialDesc" runat="server" ForeColor ="Red" meta:resourcekey="lblMaterialDescResource1" />
                    </td>
                    <td>
                        <asp:TextBox ID="tbxMaterialDesc" runat="server"  MaxLength ="40"   meta:resourcekey="tbxMaterialDescResource1" Width ="200"/>
                        <asp:Label ID="lblMaterielDescMsg" runat="server"  meta:resourcekey="lblMaterielDescMsgResource1" />
                    </td>
                </tr>
             </table>
          </fieldset>
        </td>
     </tr>

    <!--Gen Board--> 
    <tr id="trGenBoard" runat ="server">
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblGenBoardTitle" runat ="server" Font-Bold ="true" meta:resourcekey="lblGenBoardTitleResource1" />
                </legend>
                 <table   width="100%" cellspacing ="0" cellpadding ="3">
                    <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblGenBoard" runat="server"   meta:resourcekey="lblGenBoardResource1" />
                        </td>
                        <td colspan ="3">
                             <asp:TextBox ID="tbxGenBoard" runat="server" MaxLength="50" width="200px" meta:resourcekey="tbxGenBoardResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblGenBoardDN" runat="server"  meta:resourcekey="lblGenboardDNResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxGenBoardDN" runat="server"  MaxLength ="50"  meta:resourcekey="tbxGenBoardDNResource1"/>
                        </td>
                        <td>
                            <asp:Label ID="lblGenBoardDVS" runat="server"  meta:resourcekey="lblGenBoardDVSResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxGenBoardDVS" runat="server"  MaxLength ="2" Width ="60px"  meta:resourcekey="tbxGenBoardDVSResource1"/>
                        </td>
                   </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    
    <!--Spe Board--> 
    <tr id="trSpeBoard" runat ="server">
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblSpeBoardTitle" runat ="server" Font-Bold ="true" meta:resourcekey="lblSpeBoardTitleResource1" />
                </legend>
                 <table  width="100%" cellspacing ="0" cellpadding ="3">
                   <tr>
                        <td class="titlestyle"><asp:Label ID="lblSpeBoard" runat="server"  meta:resourcekey="lblSpeBoardResource1" />
                        </td>
                        <td colspan ="3">
                             <asp:TextBox ID="tbxSpeBoard" runat="server" MaxLength="50" width="200px" meta:resourcekey="tbxSpeBoardResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblSpeBoardDN" runat="server"  meta:resourcekey="lblSpeBoardDNResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxSpeBoardDN" runat="server"  MaxLength ="50"  meta:resourcekey="tbxSpeBoardDNResource1"/>
                        </td>
                        <td>
                            <asp:Label ID="lblSpeBoardDVS" runat="server"  meta:resourcekey="lblSpeBoardDVSResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxSpeBoardDVS" runat="server"  MaxLength ="2" Width ="60px" meta:resourcekey="tbxSpeBoardDVSResource1"/>
                        </td>
                  </tr>
                </table>
            </fieldset>
        </td>
    </tr>
       
    <!--SMT Fabrication-->
    <tr id="trSMTFabrication" runat ="server">
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblSMTFabricationTitle" runat ="server" Font-Bold ="true" meta:resourcekey="lblSMTFabricationTitleResource1" />
                </legend>
                <table   style ="width:100%" cellspacing ="0" cellpadding ="3">
                     <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblSMTFabricationDN" runat="server"   meta:resourcekey="lblSMTFabricationDNResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxSMTFabricationDN" runat="server" MaxLength="50"  meta:resourcekey="tbxFabricationDNResource1" />
                        </td>
                        <td>
                            <asp:Label ID="lblSMTFabricationDVS" runat="server"   meta:resourcekey="lblSMTFabricationDVSResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxSMTFabricationDVS" runat="server"  MaxLength="2"  meta:resourcekey="tbxSMTFabricationDVSResource1" Width="60px"/>
                        </td>
                        
                     </tr>
                </table>
            </fieldset> 
        </td>
    </tr>
    
    <!--Component Part-->
    <tr id="trComponentPart" runat ="server">
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblComponentPartTitle" runat ="server" Font-Bold ="true" meta:resourcekey="lblComponentPartTitleResource1" />
                </legend>
                 <table  width="100%" cellspacing ="0" cellpadding ="3">
                   <tr>
                        <td class="titlestyle"><asp:Label ID="lblComponentPart" runat="server"  meta:resourcekey="lblComponentPartResource1" />
                        </td>
                        <td colspan ="3">
                             <asp:TextBox ID="tbxComponentPart" runat="server" MaxLength="50" width="200px" meta:resourcekey="tbxComponentPartResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblComponentPartDN" runat="server"  meta:resourcekey="lblComponentPartDNResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxComponentPartDN" runat="server"  MaxLength ="50"  meta:resourcekey="tbxComponentPartDNResource1"/>
                        </td>
                        <td>
                            <asp:Label ID="lblComponentPartDVS" runat="server"  meta:resourcekey="lblComponentPartDVSResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxComponentPartDVS" runat="server"  MaxLength ="2" Width ="60px" meta:resourcekey="tbxComponentPartDVSResource1"/>
                        </td>
                  </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    
    <!--Group Part-->
    <tr id="trGroupPart" runat ="server">
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblGroupPartTitle" runat ="server" Font-Bold ="true" meta:resourcekey="lblGroupPartTitleResource1" />
                </legend>
                 <table  width="100%" cellspacing ="0" cellpadding ="3">
                   <tr>
                        <td class="titlestyle"><asp:Label ID="lblGroupPart" runat="server"  meta:resourcekey="lblGroupPartResource1" />
                        </td>
                        <td colspan ="3">
                             <asp:TextBox ID="tbxGroupPart" runat="server" MaxLength="50" width="200px" meta:resourcekey="tbxGroupPartResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblGroupPartDN" runat="server"  meta:resourcekey="lblGroupPartDNResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxGroupPartDN" runat="server"  MaxLength ="50"  meta:resourcekey="tbxGroupPartDNResource1"/>
                        </td>
                        <td>
                            <asp:Label ID="lblGroupPartDVS" runat="server"  meta:resourcekey="lblGroupPartDVSResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxGroupPartDVS" runat="server"  MaxLength ="2" Width ="60px" meta:resourcekey="tbxGroupPartDVSResource1"/>
                        </td>
                  </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    
    <!--Bonding Fabrication-->
    <tr id="trBondingFabrication" runat ="server">
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblBondingFabricationTitle" runat ="server" Font-Bold ="true" meta:resourcekey="lblBondingFabricationTitleResource1" />
                </legend>
                <table   style ="width:100%" cellspacing ="0" cellpadding ="3">
                     <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblBondingFabricationDN" runat="server"   meta:resourcekey="lblBondingFabricationDNResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxBondingFabricationDN" runat="server" MaxLength="50"  meta:resourcekey="tbxFabricationDNResource1" />
                        </td>
                        <td>
                            <asp:Label ID="lblBondingFabricationDVS" runat="server"   meta:resourcekey="lblBondingFabricationDVSResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxBondingFabricationDVS" runat="server"  MaxLength="2"  meta:resourcekey="tbxBondingFabricationDVSResource1" Width="60px"/>
                        </td>
                        
                     </tr>
                </table>
            </fieldset> 
        </td>
    </tr>
    
    <!--Comments and Explanation-->
     <tr>
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblCommentExplanationTitle" runat ="server" Font-Bold ="true" meta:resourcekey="lblCommentExplanationTitleResource1" />
                </legend>
                <table  width="100%" cellspacing ="0" cellpadding ="3">
                    <tr>
                        <td valign ="top"><asp:Label ID="lblComments" runat="server" 
                                meta:resourcekey="lblCommentsResource1"/></td>
                        <td>
                             <asp:TextBox ID="tbxComments" runat="server"  TextMode ="MultiLine"  Rows="5" Width ="300px"
                                 meta:resourcekey="tbxCommentsResource1" MaxLength ="100" />
                        </td>
                    </tr>
                    <tr>
                        <td valign ="top"><asp:Label ID="lblExplanation" runat="server" 
                                meta:resourcekey="lblExplanationResource1"/></td>
                        <td>
                             <asp:TextBox ID="tbxExplanation" runat="server"  TextMode ="MultiLine"  Rows="5" Width ="300px"
                                 meta:resourcekey="tbxCommentsResource1" MaxLength ="100"/>
                        </td>
                    </tr>
                </table>
           </fieldset>
        </td>
    </tr>

  </table>

  <br />     
  <asp:NewButton ID="btnSave" runat="server"  cl-table 
        OnClientClick="return verify()"  
        Width ="80" meta:resourcekey="btnSaveResource1" onclick="btnSave_Click" />
  &nbsp;
  <asp:NewButton ID="btnReset" runat ="server" cl-table 
        OnClientClick="return formReset()"  Width ="80" 
        meta:resourcekey="btnResetResource1"/>
  <br />
</center>
</asp:Content>