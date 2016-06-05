<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RptSMTFileInduceList.aspx.cs" Inherits="WaveLab.Web.RptSMTFileInduceList" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
function goBack()
{
    self.location.href="RptSMTFileInduce.aspx";
    return false;
}
</script>
<style type="text/css">
.titlestyle{width:150px;}
.contentstyle{width:300px;}
.versionstyle{width:40px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<asp:ImageButton ID="imgBtnBack" runat ="server" SkinID ="imgBtnSkinBack"  
         OnClientClick ="return goBack()" meta:resourcekey="imgBtnBackResource1"/>
<center>
   <asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" meta:resourcekey="lblTitleResource1" /><br /><br />
   
   <asp:Label ID="lblRecCount" runat ="server" 
        meta:resourcekey="lblRecCountResource1" />
   <table style="text-align:left; width:700px" border ="0" cellpadding ="5" cellspacing ="0" id="tblResult" runat ="server" >
    <tr>
        <td>
            <table  width="100%" cellspacing ="0" cellpadding ="3">
              <tr>
                <td class="titlestyle">
                    <asp:Label ID="lblSYSModuleType" runat="server"  ForeColor ="Red" meta:resourcekey="lblSYSModuleTypeResource1"/>
                </td>
                <td>
                    <asp:Label ID="lblSYSModuleTypeInfo" runat="server" ForeColor ="Blue" meta:resourcekey="lblSYSModuleTypeInfoResource1" />
                </td>
             </tr>
             <tr>
                <td>
                    <asp:Label ID ="lblMaterialCode" runat="server"  ForeColor ="Red" meta:resourcekey="lblMaterialCodeResource1"/>
                </td>
                <td>
                    <asp:Label ID="lblMaterialCodeInfo" runat="server" ForeColor ="Blue"  meta:resourcekey="lblMaterialCodeInfoResource1" />
                </td>
             </tr>
             <tr>
                <td>
                    <asp:Label ID="lblMaterialDesc" runat="server" ForeColor ="Red" meta:resourcekey="lblMaterialDescResource1" />
                </td>
                <td>
                    <asp:Label ID="lblMaterialDescInfo" runat="server"  ForeColor ="Blue" meta:resourcekey="lblMaterielDescInfoResource1" />
                </td>
            </tr>
             <tr>
                <td><asp:Label ID="lblPCB" runat="server" ForeColor="Red"  meta:resourcekey="lblPCBResource1" /></td>
                <td> 
                    <asp:Label ID="lblPCBInfo" runat="server"  ForeColor ="Blue" meta:resourcekey="lblPCBInfoResource1" />
                </td>
             </tr> 
            </table>
        </td>
    </tr>      

    <!--Gen Board--> 
    <tr>
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblGenBoardTitle" runat ="server" Font-Bold ="True" 
                        meta:resourcekey="lblGenBoardTitleResource1" />
                </legend>
                 <table cellspacing ="0" cellpadding ="3">
                    <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblGenBoard" runat="server" 
                                meta:resourcekey="lblGenBoardResource1" />
                        </td>
                        <td colspan ="3">
                            <asp:Label ID="lblGenBoardInfo" runat="server" 
                                meta:resourcekey="lblGenBoardInfoResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblGenBoardDN" runat="server"  meta:resourcekey="lblGenboardDNResource1" />
                        </td>
                        <td class="contentstyle">
                            <asp:Label ID="lblGenBoardDNInfo" runat="server" 
                                meta:resourcekey="lblGenBoardDNInfoResource1" />
                        </td>
                        <td class="versionstyle">
                            <asp:Label ID="lblGenBoardDVS" runat="server"  meta:resourcekey="lblGenBoardDVSResource1" />
                        </td>
                        <td>
                           <asp:Label ID="lblGenBoardDVSInfo" runat="server" 
                                meta:resourcekey="lblGenBoardDVSInfoResource1" />
                        </td>
                   </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    
    <!--Spe Board--> 
    <tr>
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblSpeBoardTitle" runat ="server" Font-Bold ="True" 
                        meta:resourcekey="lblSpeBoardTitleResource1" />
                </legend>
                 <table cellspacing ="0" cellpadding ="3">
                   <tr>
                        <td class="titlestyle"><asp:Label ID="lblSpeBoard" runat="server"  meta:resourcekey="lblSpeBoardResource1" />
                        </td>
                        <td colspan ="3">
                              <asp:Label ID="lblSpeBoardInfo" runat="server" 
                                  meta:resourcekey="lblSpeBoardInfoResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblSpeBoardDN" runat="server"  meta:resourcekey="lblSpeBoardDNResource1" />
                        </td>
                        <td class="contentstyle">
                             <asp:Label ID="lblSpeBoardDNInfo" runat="server" 
                                 meta:resourcekey="lblSpeBoardDNInfoResource1" />
                        </td>
                        <td class="versionstyle">
                            <asp:Label ID="lblSpeBoardDVS" runat="server"  meta:resourcekey="lblSpeBoardDVSResource1" />
                        </td>
                        <td>
                             <asp:Label ID="lblSpeBoardDVSInfo" runat="server" 
                                 meta:resourcekey="lblSpeBoardDVSInfoResource1" />
                        </td>
                  </tr>
                </table>
            </fieldset>
        </td>
    </tr>
       
    <!--SMT Fabrication-->
    <tr>
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblSMTFabricationTitle" runat ="server" Font-Bold ="True" 
                        meta:resourcekey="lblSMTFabricationTitleResource1" />
                </legend>
                <table cellspacing ="0" cellpadding ="3">
                     <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblSMTFabricationDN" runat="server"   meta:resourcekey="lblSMTFabricationDNResource1" />
                        </td>
                        <td class="contentstyle">
                            <asp:Label ID="lblSMTFabricationDNInfo" runat="server" 
                                meta:resourcekey="lblSMTFabricationDNInfoResource1" />
                        </td>
                        <td class="versionstyle">
                            <asp:Label ID="lblSMTFabricationDVS" runat="server"   meta:resourcekey="lblSMTFabricationDVSResource1" />
                        </td>
                        <td>
                             <asp:Label ID="lblSMTFabricationDVSInfo" runat="server" 
                                 meta:resourcekey="lblSMTFabricationDVSInfoResource1" />
                        </td>
                        
                     </tr>
                </table>
            </fieldset> 
        </td>
    </tr>
    
    <!--Component Part-->
    <tr>
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblComponentPartTitle" runat ="server" Font-Bold ="True" 
                        meta:resourcekey="lblComponentPartTitleResource1" />
                </legend>
                 <table cellspacing ="0" cellpadding ="3">
                   <tr>
                        <td class="titlestyle"><asp:Label ID="lblComponentPart" runat="server"  meta:resourcekey="lblComponentPartResource1" />
                        </td>
                        <td colspan ="3">
                              <asp:Label ID="lblComponentPartInfo" runat="server" 
                                  meta:resourcekey="lblComponentPartInfoResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblComponentPartDN" runat="server"  meta:resourcekey="lblComponentPartDNResource1" />
                        </td>
                        <td class="contentstyle">
                             <asp:Label ID="lblComponentPartDNInfo" runat="server" 
                                 meta:resourcekey="lblComponentPartDNInfoResource1" />
                        </td>
                        <td class="versionstyle">
                            <asp:Label ID="lblComponentPartDVS" runat="server"  meta:resourcekey="lblComponentPartDVSResource1" />
                        </td>
                        <td>
                             <asp:Label ID="lblComponentPartDVSInfo" runat="server" 
                                 meta:resourcekey="lblComponentPartDVSInfoResource1" />
                        </td>
                  </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    
    <!--Group Part-->
    <tr>
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblGroupPartTitle" runat ="server" Font-Bold ="True" 
                        meta:resourcekey="lblGroupPartTitleResource1" />
                </legend>
                 <table cellspacing ="0" cellpadding ="3">
                   <tr>
                        <td class="titlestyle"><asp:Label ID="lblGroupPart" runat="server"  meta:resourcekey="lblGroupPartResource1" />
                        </td>
                        <td colspan ="3">
                              <asp:Label ID="lblGroupPartInfo" runat="server" 
                                  meta:resourcekey="lblGroupPartInfoResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblGroupPartDN" runat="server"  meta:resourcekey="lblGroupPartDNResource1" />
                        </td>
                        <td class="contentstyle">
                             <asp:Label ID="lblGroupPartDNInfo" runat="server" 
                                 meta:resourcekey="lblGroupPartDNInfoResource1" />
                        </td>
                        <td class="versionstyle">
                            <asp:Label ID="lblGroupPartDVS" runat="server"  meta:resourcekey="lblGroupPartDVSResource1" />
                        </td>
                        <td>
                            <asp:Label ID="lblGroupPartDVSInfo" runat="server" 
                                meta:resourcekey="lblGroupPartDVSInfoResource1" />
                        </td>
                  </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    
    <!--Bonding Fabrication-->
    <tr>
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblBondingFabricationTitle" runat ="server" Font-Bold ="True" 
                        meta:resourcekey="lblBondingFabricationTitleResource1" />
                </legend>
                <table cellspacing ="0" cellpadding ="3">
                     <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblBondingFabricationDN" runat="server"   meta:resourcekey="lblBondingFabricationDNResource1" />
                        </td>
                        <td class="contentstyle">
                             <asp:Label ID="lblBondingFabricationDNInfo" runat="server" 
                                 meta:resourcekey="lblBondingFabricationDNInfoResource1" />
                        </td>
                        <td class="versionstyle">
                            <asp:Label ID="lblBondingFabricationDVS" runat="server"   meta:resourcekey="lblBondingFabricationDVSResource1" />
                        </td>
                        <td >
                             <asp:Label ID="lblBondingFabricationDVSInfo" runat="server" 
                                 meta:resourcekey="lblBondingFabricationDVSInfoResource1" />
                        </td>
                        
                     </tr>
                </table>
            </fieldset> 
        </td>
    </tr>
 
  </table>
</center>
</asp:Content>
