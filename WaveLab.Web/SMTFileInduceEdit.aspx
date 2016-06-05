<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTFileInduceEdit.aspx.cs" Inherits="WaveLab.Web.SMTFileInduceEdit" Title="无标题页"  meta:resourcekey="PageResource1" culture="auto" uiculture="auto"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
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
   <asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" meta:resourcekey="lblTitleResource1" /><br />
 
  <table style="text-align:left; width:700px" border ="0" cellpadding ="3" cellspacing ="0" >
     <tr>
        <td>
            <fieldset>
                <legend>    
                    <asp:Label ID ="lblPrimaryKeyTitle" runat ="server" Font-Bold ="True" 
                        meta:resourcekey="lblPrimaryKeyTitleResource1" />
                </legend>
               <table  width="100%"  cellspacing ="0" cellpadding ="3">
                <tr>
                    <td>
                        <asp:Label ID="lblSYSModuleType" runat="server"  ForeColor ="Red" meta:resourcekey="lblSYSModuleTypeResource1"/>
                    </td>
                    <td>
                        <asp:Label ID="lblSYSModuleTypeInfo" runat="server" ForeColor ="Blue" meta:resourcekey="lblSYSModuleTypeInfoResource1" />
                    </td>
                    <td><asp:Label ID="lblPCB" runat="server" ForeColor="Red"  meta:resourcekey="lblPCBResource1" /></td>
                    <td> 
                        <asp:Label ID="lblPCBInfo" runat="server"  ForeColor ="Blue" meta:resourcekey="lblPCBInfoResource1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID ="lblMaterialCode" runat="server"  ForeColor ="Red" meta:resourcekey="lblMaterialCodeResource1"/>
                    </td>
                    <td>
                        <asp:Label ID="lblMaterialCodeInfo" runat="server" ForeColor ="Blue"  meta:resourcekey="lblMaterialCodeInfoResource1" />
                    </td>
                    <td>
                        <asp:Label ID="lblMaterialDesc" runat="server" ForeColor ="Red" meta:resourcekey="lblMaterialDescResource1" />
                    </td>
                    <td>
                        <asp:Label ID="lblMaterialDescInfo" runat="server"  ForeColor ="Blue" meta:resourcekey="lblMaterielDescInfoResource1" />
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
                    <asp:Label ID ="lblCommentExplanationTitle" runat ="server" Font-Bold ="True" 
                        meta:resourcekey="lblCommentExplanationTitleResource1" />
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
        Width ="80" meta:resourcekey="btnSaveResource1" 
         onclick="btnSave_Click" />
  &nbsp;
  <asp:NewButton ID="btnDelete" runat ="server" cl-table   
        meta:resourcekey="btnDeleteResource1"  
        Width ="80" onclick="btnDelete_Click" />
</center>
</asp:Content>
