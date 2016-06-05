<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTFileInduceNewPCBSubmit.aspx.cs" Inherits="WaveLab.Web.SMTFileInduceNewPCBSubmit" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function goToCtrPage()
{
    self.location.href='<%=System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) %>';
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<asp:ImageButton ID="imgBtnBack" runat ="server" SkinID ="imgBtnSkinBack"  
        meta:resourcekey="imgBtnBackResource1" onclick="imgBtnBack_Click"/>
<center>
   <asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" 
     meta:resourcekey="lblTitleResource1" /><br />
  <table style=" text-align:left ; width:100%" >
    
     <tr>
        <td>
            <asp:Label ID="lblRecCount" runat="server"  meta:resourcekey="lblRecCountResource1"/>
        </td>
     </tr>
    <tr>
        <td>
            <asp:GridView ID="GVList" runat="server" AllowSorting ="True"  SkinId="skinGridView"
                AutoGenerateColumns="False"  Width ="100%"  DataKeyNames ="materialcode,materialdesc,pcb"
                meta:resourcekey="GVListResource1" onsorting="GVList_Sorting"  >
              <Columns>
                  <asp:BoundField  DataField ="MaterialCode"  SortExpression ="material_code" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource1" />
                 <asp:BoundField  DataField ="MaterialDesc"  SortExpression ="material_desc" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource2" />
                 <asp:BoundField  DataField ="PCB" SortExpression ="pcb" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource3"  />
                 <asp:BoundField  DataField ="GenBoard" SortExpression ="genboard" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                     meta:resourcekey="BoundFieldResource4"   />
                 <asp:BoundField  DataField ="GenboardDN"  SortExpression ="genboarddn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource5"  />
                 <asp:BoundField  DataField ="GenBoardDVS" SortExpression ="genboarddvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource6" />
                 <asp:BoundField  DataField ="SpeBoard" SortExpression ="speboard" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource7" />
                 <asp:BoundField  DataField ="SpeBoardDN" SortExpression ="speboarddn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource8" />
                 <asp:BoundField  DataField ="SpeBoardDVS" SortExpression ="speboarddvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource9" />
                 <asp:BoundField  DataField ="SMTFabricationDN" SortExpression ="smtfabricationdn"  HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource10" />
                 <asp:BoundField  DataField ="SMTFabricationDVS" SortExpression ="smtfabricationdvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource11" />
                 <asp:BoundField  DataField ="ComponentPart" SortExpression ="componentpart" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                     meta:resourcekey="BoundFieldResource12"   />   
                 <asp:BoundField  DataField ="ComponentPartDN"  SortExpression ="componentpartdn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource13"  />
                 <asp:BoundField  DataField ="ComponentPartDVS" SortExpression ="componentpartdvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource14" /> 
                 <asp:BoundField  DataField ="GroupPart" SortExpression ="grouppart" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource15" />
                 <asp:BoundField  DataField ="GroupPartDN" SortExpression ="grouppartdn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource16" />
                 <asp:BoundField  DataField ="GroupPartDVS" SortExpression ="grouppartdvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource17" />
                 <asp:BoundField  DataField ="BondingFabricationDN" SortExpression ="bondingfabricationdn" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource18" />
                 <asp:BoundField  DataField ="BondingFabricationDVS" SortExpression ="bondingfabricationdvs" HeaderStyle-Font-Size="10px" ItemStyle-Font-Size ="10px"
                      meta:resourcekey="BoundFieldResource19" />
              </Columns>
            </asp:GridView>
            <br />
        </td>
    </tr>
     <tr>
        <td align="center">
            <fieldset style="width:450px">
             <table style =" text-align:left; width:350px" class ="form-table">
                 <tr style ="height:25px">
                      <td><asp:Label ID="lblSYSModuleType" runat="server"  meta:resourcekey="lblSYSModuleTypeResource1"/></td>
                      <td>
                        <asp:Label ID="lblSYSModuleTypeInfo" runat="server"  ForeColor ="Blue" 
                              meta:resourcekey="lblSYSModuleTypeInfoResource1"/>
                      </td>
                </tr> 
                 <tr style ="height:25px">
                    <td><asp:Label ID="lblPCB" runat="server" 
                            meta:resourcekey="lblPCBResource1" /></td>
                    <td>
                        <asp:Label ID="lblPCBInfo" runat="server"  ForeColor ="Blue"
                            meta:resourcekey="lblPCBInfoResource1" /></td>
                </tr>
                 <tr style ="height:25px">
                    <td><asp:Label ID="lblNewPCB" runat="server" 
                            meta:resourcekey="lblNewPCBResource1" /></td>
                    <td>
                        <asp:Label ID="lblNewPCBInfo" runat="server"  ForeColor ="Blue"
                            meta:resourcekey="lblNewPCBInfoResource1" />
                        <asp:Label ID="lblPriorirtyItem" runat="server"  meta:resourcekey="lblPriorirtyItemResource1" ForeColor ="Blue"/>
                            </td>
                </tr>
                <tr style ="height :25px">
                    <td valign ="top"><asp:Label ID="lblComments" runat="server" 
                                        meta:resourcekey="lblCommentsResource1"/></td>
                    <td valign ="top">
                        <asp:Label ID="lblCommentsInfo" runat="server" meta:resourcekey="lblCommentsInfoResource1" />
                    </td>
                </tr>   
            </table>
           </fieldset>
        </td>
     </tr>
  </table>
  <asp:NewButton ID="btnSubmit" runat="server"   Width ="80" 
      meta:resourcekey="btnSubmitResource1" onclick="btnbtnSubmit_Click" />
  <br /><br />
</center>
</asp:Content>
