<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTModelFileInduceNew.aspx.cs" Inherits="WaveLab.Web.SMTModelFileInduceNew" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready(function()
{
   $("input:submit").button();
});
function verify() 
{
    var ModuleTypeId = $("#<%=ddlSYSModuleType.ClientID %>")
    if (ModuleTypeId.val().length == 0) {
        alert($("#<%=lblSYSModuleTypeMsg.ClientID %>").attr("title"));
        ModuleTypeId.focus();
        return false;
    }

    var billSerialNumber = $("#<%=tbxBillSerialNumber.ClientID %>");
    var moduleDesc=$("#<%=tbxModuleDesc.ClientID %>");
    var pcb=$("#<%=tbxPCB.ClientID %>");

    if (trim(billSerialNumber.val()).length == 0)
    {
        alert($("#<%=lblBillSerialNumberMsg.ClientID %>").attr("title"));
        billSerialNumber.focus();
      return false;
    }
    if (trim(moduleDesc.val()).length == 0)
    {
        alert($("#<%=lblModuleDescMsg.ClientID %>").attr("title"));
        moduleDesc.focus();
      return false;
    }
    
    if(trim(pcb.val()).length==0)
    {
        alert($("#<%=lblPCBMsg.ClientID %>").attr("title"));
        pcb.focus();
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
                    <asp:Label ID ="lblPrimaryKeyTitle" runat ="server" Font-Bold ="True" 
                        meta:resourcekey="lblPrimaryKeyTitleResource1" />
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
                    <td>
                        <asp:Label ID ="lblBillSerialNumber" runat="server"  ForeColor ="Red" meta:resourcekey="lblBillSerialNumberResource1"/>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxBillSerialNumber" runat="server" MaxLength ="50"  Width ="200px" 
                            meta:resourcekey="tbxBillSerialNumberResource1" />
                        <asp:Label ID="lblBillSerialNumberMsg" runat="server"  meta:resourcekey="lblBillSerialNumberMsgResource1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblModuleDesc" runat="server" ForeColor ="Red" meta:resourcekey="lblModuleDescResource1" />
                    </td>
                    <td>
                        <asp:TextBox ID="tbxModuleDesc" runat="server"  MaxLength ="50"   
                            meta:resourcekey="tbxModuleDescResource1" Width ="200px"/>
                        <asp:Label ID="lblModuleDescMsg" runat="server"  meta:resourcekey="lblModuleDescMsgResource1" />
                    </td>
                     <td><asp:Label ID="lblPCB" runat="server" ForeColor="Red"  meta:resourcekey="lblPCBResource1" /></td>
                    <td>
                        <asp:TextBox ID="tbxPCB" runat="server"  MaxLength ="50"  Width ="200px" 
                            meta:resourcekey="tbxPCBResource1"/>
                        <asp:Label ID="lblPCBMsg" runat="server"  meta:resourcekey="lblPCBMsgResource1" />
                    </td>
                </tr>
             </table>
          </fieldset>
        </td>
     </tr>

    <!--Gen Board--> 
    <tr>
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblSerialNumberTitle" runat ="server" Font-Bold ="True" 
                        meta:resourcekey="lblSerialNumberTitleResource1" />
                </legend>
                 <table   width="100%" cellspacing ="0" cellpadding ="3">
                    <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblSerialNumber" runat="server"   meta:resourcekey="lblSerialNumberResource1" />
                        </td>
                        <td colspan ="3">
                             <asp:TextBox ID="tbxSerialNumber" runat="server" MaxLength="50" width="200px" meta:resourcekey="tbxSerialNumberResource1" />
                        </td>
                        <td>
                            <asp:Label ID="lblVersion" runat="server"  meta:resourcekey="lblVersionResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxVersion" runat="server"  MaxLength ="2" Width ="60px"  meta:resourcekey="tbxVersionResource1"/>
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
                            <asp:TextBox ID="tbxSpeBoardDN" runat="server" width="200px" MaxLength ="50"  meta:resourcekey="tbxSpeBoardDNResource1"/>
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
    <tr>
        <td>
            <fieldset>
                <legend>
                    <asp:Label ID ="lblFabricationTitle" runat ="server" Font-Bold ="True" 
                        meta:resourcekey="lblFabricationTitleResource1" />
                </legend>
                <table   style ="width:100%" cellspacing ="0" cellpadding ="3">
                     <tr>
                        <td class="titlestyle">
                            <asp:Label ID="lblFabricationDN" runat="server"   meta:resourcekey="lblFabricationDNResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxFabricationDN" runat="server" width="200px" MaxLength="50"  meta:resourcekey="tbxFabricationDNResource1" />
                        </td>
                        <td>
                            <asp:Label ID="lblFabricationDVS" runat="server"   meta:resourcekey="lblFabricationDVSResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxFabricationDVS" runat="server"  MaxLength="2"  meta:resourcekey="tbxFabricationDVSResource1" Width="60px"/>
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
                 <table  width="100%" cellspacing ="0" cellpadding ="3">
                   <tr>
                        <td class="titlestyle"><asp:Label ID="lblSteelMesh" runat="server"  meta:resourcekey="lblSteelMeshResource1" />
                        </td>
                        <td >
                             <asp:TextBox ID="tbxSteelMesh" runat="server" MaxLength="100" width="200px" meta:resourcekey="tbxSteelMeshResource1" />
                        </td>
          
                        <td class="titlestyle">
                            <asp:Label ID="lblCoorPattern" runat="server"  meta:resourcekey="lblCoorPatternResource1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxCoorPattern" runat="server" width="200px" MaxLength ="100"  meta:resourcekey="tbxCoorPatternResource1"/>
                        </td>
                  </tr>
                   <tr>
                        <td valign ="top"><asp:Label ID="lblComments" runat="server" 
                                meta:resourcekey="lblCommentsResource1"/></td>
                        <td colspan ="3">
                             <asp:TextBox ID="tbxComments" runat="server"  TextMode ="MultiLine"  Rows="5" Width ="300px"
                                 meta:resourcekey="tbxCommentsResource1" MaxLength ="100" />
                        </td>
                    </tr>
                    
                </table>
           </fieldset>
        </td>
    </tr>
    <tr>
        <td>
            <br />     
  <asp:NewButton ID="btnSave" runat="server"  cl-table 
        OnClientClick="return verify()"  
        Width ="80px" meta:resourcekey="btnSaveResource1" onclick="btnSave_Click" />
  &nbsp;
  <asp:NewButton ID="btnReset" runat ="server" cl-table 
        OnClientClick="return formReset()"  Width ="80px" 
        meta:resourcekey="btnResetResource1"/>
  <br />
        </td>
    </tr>
  </table>

  
</center>
</asp:Content>