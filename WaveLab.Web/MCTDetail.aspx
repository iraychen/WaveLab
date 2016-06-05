<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MCTDetail.aspx.cs" Inherits="WaveLab.Web.MCTDetail" Title="无标题页" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
                    <td ><asp:Label ID="lblBasicInformation" runat ="server"  
                            Font-Bold ="True" Font-Size ="Larger" 
                            meta:resourcekey="lblBasicInformationResource1"/></td>               
                </tr> 
                <tr>
                    <td>
                        <table style ="width:800px">
                            
                            <tr>
                                <td><asp:Label ID ="lblSupplierNameKey" runat ="server" 
                                        meta:resourcekey="lblSupplierNameKeyResource1" /> </td>
                                <td colspan ="3">
                                    <asp:Label ID ="lblSupplierNameVal" runat ="server" 
                                        meta:resourcekey="lblSupplierNameValResource1" />
                                </td>
                            </tr>   
                            <tr>
                                <td style ="width:80px"><asp:Label ID ="lblCompletedDateKey" runat ="server" 
                                        meta:resourcekey="lblCompletedDateKeyResource1" /></td>
                                <td style ="width:320px">
                                    <asp:Label ID ="lblCompletedDateVal" runat ="server" 
                                        meta:resourcekey="lblCompletedDateValResource1" />
                                </td>
                                 <td style ="width:80px"><asp:Label ID ="lblDeparmentKey" runat ="server" 
                                         meta:resourcekey="lblDeparmentKeyResource1" /></td>
                                <td>
                                    <asp:Label ID ="lblDeparmentVal" runat ="server" 
                                        meta:resourcekey="lblDeparmentValResource1" />
                                </td>
                            </tr>  
                            <tr>
                                <td><asp:Label ID ="lblCompleteByKey" runat ="server" 
                                        meta:resourcekey="lblCompleteByKeyResource1" /></td>
                                <td>
                                    <asp:Label ID ="lblCompleteByVal" runat ="server" 
                                        meta:resourcekey="lblCompleteByValResource1" />
                                </td>
                                 <td><asp:Label ID ="lblEmailKey" runat ="server" 
                                         meta:resourcekey="lblEmailKeyResource1" /></td>
                                <td>
                                    <asp:Label ID ="lblEmailVal" runat ="server" 
                                        meta:resourcekey="lblEmailValResource1" />
                                </td>
                            </tr>
                             <tr>
                                <td><asp:Label ID ="lblTelKey" runat ="server" 
                                        meta:resourcekey="lblTelKeyResource1" /></td>
                                <td>
                                    <asp:Label ID ="lblTelVal" runat ="server" 
                                        meta:resourcekey="lblTelValResource1" />
                                </td>
                                 <td><asp:Label ID ="lblFaxKey" runat ="server" 
                                         meta:resourcekey="lblFaxKeyResource1" /></td>
                                <td>
                                    <asp:Label ID ="lblFaxVal" runat ="server" 
                                        meta:resourcekey="lblFaxValResource1" />
                                </td>
                            </tr>   
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                    <asp:Label ID="lblSubstancesInProduct" runat ="server"  
                            Font-Bold ="True" Font-Size ="Larger" 
                            meta:resourcekey="lblSubstancesInProductResource1"/></td>               
                </tr>  
                <tr>
                    <td >
                         <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   SkinID ="null" 
                            GridLines ="None" CssClass="import-gridview" EnableViewState ="False"
                                AutoGenerateColumns="False"  Width ="100%" CellPadding ="2" 
                            CellSpacing ="1"
                            meta:resourcekey="GVListResource1" onrowdatabound="GVList_RowDataBound"  >
                              <Columns>
                                 <asp:BoundField  DataField ="MaterialDesc" meta:resourcekey="BoundFieldResource1" HtmlEncode ="false"/>
                                 <asp:BoundField  DataField ="Model" meta:resourcekey="BoundFieldResource2" HtmlEncode ="false" />
                                 <asp:BoundField  DataField ="PartNo"  meta:resourcekey="BoundFieldResource3" />
                                 <asp:BoundField  DataField ="ComponentDesc"  meta:resourcekey="BoundFieldResource4" />
                                 <asp:BoundField  DataField ="HomoMaterialName" meta:resourcekey="BoundFieldResource5" />
                                 <asp:BoundField  DataField ="SubstanceName" meta:resourcekey="BoundFieldResource6" />
                                 <asp:BoundField  DataField ="CasNo" meta:resourcekey="BoundFieldResource7" />
                                 <asp:BoundField  DataField ="SubstanceMass" meta:resourcekey="BoundFieldResource8" DataFormatString="{0:f5}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                                 <asp:BoundField  DataField ="ContentRate" meta:resourcekey="BoundFieldResource9" DataFormatString="{0:f3}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                                <%-- <asp:BoundField  DataField ="Comment"   meta:resourcekey="BoundFieldResource10" />--%>
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