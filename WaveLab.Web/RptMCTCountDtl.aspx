<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RptMCTCountDtl.aspx.cs" Inherits="WaveLab.Web.RptMCTCountDtl" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
 <center>
   <br />
   <asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" 
     meta:resourcekey="lblTitleResource" /><br />
   <br />
 <table width="100%" cellpadding="0" cellspacing="0" style="text-align:left;">
    <tr>
        <td align ="center" >
          <table  style="text-align:left;" >
                <tr>
                    <td>
                        <table style ="width:670px">
                             <tr>
                                <td><asp:Label ID ="lblMaterialCodeKey" runat ="server" 
                                        meta:resourcekey="lblMaterialCodeKeyResource1" /> </td>
                                <td style ="width:500px">
                                    <asp:Label ID ="lblMaterialCodeVal" runat ="server" 
                                        meta:resourcekey="lblMaterialCodeValResource1" />
                                </td>
                            </tr>   
                             <tr>
                                <td><asp:Label ID ="lblMaterialDescKey" runat ="server" 
                                        meta:resourcekey="lblMaterialDescKeyResource1" /> </td>
                                <td>
                                    <asp:Label ID ="lblMaterialDescVal" runat ="server" 
                                        meta:resourcekey="lblMaterialDescValResource1" />
                                </td>
                            </tr>   
                            <tr>
                                <td><asp:Label ID ="lblSupplierNameKey" runat ="server" 
                                        meta:resourcekey="lblSupplierNameKeyResource1" /> </td>
                                <td >
                                    <asp:Label ID ="lblSupplierNameVal" runat ="server" 
                                        meta:resourcekey="lblSupplierNameValResource1" />
                                </td>
                            </tr>   
                        </table>
                    </td>
                </tr>
                <tr>
                    <td >
                         <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   
                            GridLines ="None"  EnableViewState ="False" SkinID ="skinRptGridView"
                                AutoGenerateColumns="False"  Width ="100%" CellPadding ="2" 
                            CellSpacing ="1"  onsorting="GVList_Sorting" 
                            meta:resourcekey="GVListResource1" onrowdatabound="GVList_RowDataBound"  >
                              <Columns>
                                 <asp:BoundField  DataField ="ComponentDesc"  SortExpression ="component_desc" meta:resourcekey="BoundFieldResource1" />
                                 <asp:BoundField  DataField ="HomoMaterialName" SortExpression ="homo_material_name" meta:resourcekey="BoundFieldResource2" />
                                 <asp:BoundField  DataField ="SubstanceName" SortExpression ="substance_name" meta:resourcekey="BoundFieldResource3" />
                                 <asp:BoundField  DataField ="CasNo" SortExpression ="cas_no" meta:resourcekey="BoundFieldResource4" />
                                 <asp:BoundField  DataField ="SubstanceMass" SortExpression ="substance_mass" meta:resourcekey="BoundFieldResource5" DataFormatString="{0:f5}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                                 <asp:BoundField  DataField ="ContentRate" SortExpression ="content_rate" meta:resourcekey="BoundFieldResource6" DataFormatString="{0:f3}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                              </Columns>
                        </asp:GridView>
                    </td>
                </tr> 
            </table>
        </td>
     </tr>      
 </table>
</center>
</asp:Content>