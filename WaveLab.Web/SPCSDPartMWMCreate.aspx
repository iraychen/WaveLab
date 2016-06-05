<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCSDPartMWMCreate.aspx.cs" Inherits="WaveLab.Web.SPCSDPartMWMCreate" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

<script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
    $(document).ready(function() {
        $("input:submit").button();
       
    });

function verify() {
    var i = 0;
    $.each($("#<%=GVList.ClientID %> :checkbox"), function() {
        if ($(this).attr("checked") == true) {
            i++;
        }
    });
    if (i == 0) {
        alert($("#<%=lblMustSelectMsg.ClientID %>").attr("title"));
        return false;
    } else if(i!=1){
        alert($("#<%=lblSelectCountMsg.ClientID %>").attr("title"));
        return false;
    }
    var LSL_TxGain = $("#<%=tbxLSL_TxGain.ClientID %>");
    if (LSL_TxGain.val().length == 0) {
        alert($("#<%=lblLSL_TxGainMsg.ClientID %>").attr("title"));
        return false;
    }
    var USL_TxGain = $("#<%=tbxUSL_TxGain.ClientID %>");
    if (USL_TxGain.val().length == 0) {
        alert($("#<%=lblUSL_TxGainMsg.ClientID %>").attr("title"));
        return false;
    }
    var LSL_RxIFGain = $("#<%=tbxLSL_RxIFGain.ClientID %>");
    if (LSL_RxIFGain.val().length == 0) {
        alert($("#<%=lblLSL_RxIFGainMsg.ClientID %>").attr("title"));
        return false;
    }
    var USL_RxIFGain = $("#<%=tbxUSL_RxIFGain.ClientID %>");
    if (USL_RxIFGain.val().length == 0) {
        alert($("#<%=lblUSL_RxIFGainMsg.ClientID %>").attr("title"));
        return false;
    }
    var reg = /^[+-]?[0-9]+.?[0-9]*$/;
    if (
       ($.trim($("#<%=tbxLSL_TxGain.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLSL_TxGain.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUSL_TxGain.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUSL_TxGain.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxLSL_RxIFGain.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLSL_RxIFGain.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUSL_RxIFGain.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUSL_RxIFGain.ClientID %>").val())) == false) 
    ){
        alert($("#<%=lblNumberFormatErrorMsg.ClientID %>").attr("title"));
        return false;
    }   
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">

<center>
  <table style=" text-align:left ;"   width="100%" cellpadding="2">
   <tr>
   <td>
      <fieldset>
         <table width="100%" class="form-table">
           <tr>
                <td>
                     <asp:Label ID="lblStationNo" runat="server"  
                        meta:resourcekey="lblStationNoResource1"/>
                </td>
                <td>
                    <asp:DropDownList ID ="ddlStationNo" runat="server" 
                        meta:resourcekey="ddlStationNoResource1"></asp:DropDownList>
                </td>
               
                <td>
                    <asp:Label ID ="lblSerialNo" runat="server" 
                        meta:resourcekey="lblSerialNoResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxSerialNo" runat="server"  Width="150px"
                        meta:resourcekey="tbxSerialNoResource1"></asp:TextBox>
                </td>
                 <td align ="right" valign="middle">
        <asp:NewButton id="btnSubmit" Runat="server" Width="80px"  meta:resourcekey="btnSubmitResource1" 
                onclick="btnSubmit_Click"/>&nbsp;

    </td>
            </tr>
          </table>
          
       </fieldset>       
    </td>
   
   </tr>
    <tr>
        <td><asp:Label ID ="lblRecCount" runat ="server" 
                meta:resourcekey="lblRecCountResource1" /></td>
    </tr>
    <tr>
        <td >
        <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   AutoGenerateColumns="False"  
              SkinID="skinGridView"  Width ="100%"  DataKeyNames="StationNo,TxIndex,SerialNo"
            meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" >
              <Columns>                 
                  <asp:BoundField  DataField="TxIndex" SortExpression ="TxIndex"  
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource1">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                
                    <asp:BoundField  DataField="SerialNo" SortExpression ="SerialNo"  
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource2">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                  <asp:TemplateField meta:resourcekey="TemplateFieldResource1" 
                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                   <ItemTemplate>
                       <asp:CheckBox ID="chxSelect" runat="server" 
                           meta:resourcekey="chxSelectResource1" />
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:TemplateField>
              </Columns>
        </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <ajaxToolkit:TabContainer ID="TabContainerTarget" runat="server"   Visible="false"
        ActiveTabTxIndex="0"         
        OnDemand="true"
        UseVerticalStripPlacement="true"
        VerticalStripWidth="120px" meta:resourcekey="TabContainerTargetResource1" >
    <ajaxToolkit:TabPanel ID="TabPanelCreate" runat="server" 
            meta:resourcekey="TabPanelCreateResource1">
        <HeaderTemplate>
          <asp:Label ID ="lblTitleCreate" runat ="server" 
                meta:resourcekey="lblTitleCreateResource1" />
        </HeaderTemplate>
        <ContentTemplate>  
            <asp:UpdatePanel ID="SaveUpdatePanel" runat="server">
                <ContentTemplate>
                 <table style=" text-align:left ; margin-top:5px;"   cellpadding="2">
                <tr>
               <td>
                  <fieldset>
                     <table  class="form-table">                       	      
	                   <tr>
                <td >
                    <asp:Label ID ="lblLSL_TxGain" runat ="server"
                        meta:resourcekey="lblLSL_TxGainResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxLSL_TxGain" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxLSL_TxGainResource1"/> 
                     <asp:Label ID ="lblLSL_TxGainMsg" runat ="server"
                        meta:resourcekey="lblLSL_TxGainMsgResource1" />
                </td>
             </tr>
              <tr>
                <td >
                    <asp:Label ID ="lblUSL_TxGain" runat ="server"
                        meta:resourcekey="lblUSL_TxGainResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxUSL_TxGain" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxUSL_TxGainResource1"/> 
                     <asp:Label ID ="lblUSL_TxGainMsg" runat ="server"
                        meta:resourcekey="lblUSL_TxGainMsgResource1" />
                </td>
             </tr>
              <tr>
                <td >
                    <asp:Label ID ="lblLSL_RxIFGain" runat ="server"
                        meta:resourcekey="lblLSL_RxIFGainResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxLSL_RxIFGain" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxLSL_RxIFGainResource1"/> 
                     <asp:Label ID ="lblLSL_RxIFGainMsg" runat ="server"
                        meta:resourcekey="lblLSL_RxIFGainMsgResource1" />
                </td>
             </tr>
              <tr>
                <td >
                    <asp:Label ID ="lblUSL_RxIFGain" runat ="server"
                        meta:resourcekey="lblUSL_RxIFGainResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxUSL_RxIFGain" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxUSL_RxIFGainResource1"/> 
                     <asp:Label ID ="lblUSL_RxIFGainMsg" runat ="server"
                        meta:resourcekey="lblUSL_RxIFGainMsgResource1" />
                </td>
             </tr>
                      </table>
                   </fieldset>       
                </td>
               </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMustSelectMsg" runat="server" 
                            meta:resourcekey="lblMustSelectMsgResource1"></asp:Label>
                        <asp:Label ID="lblSelectCountMsg" runat="server" 
                            meta:resourcekey="lblSelectCountMsgResource1"></asp:Label>
                        <asp:Label ID="lblNumberFormatErrorMsg" runat ="server"  ToolTip ="<%$ Resources:globalResource,NumberFormatErrorMsg %>" 
                            meta:resourcekey="lblNumberFormatErrorMsgResource1" />
                           
                        <asp:Button  ID="btnSave" runat="server"  Width ="80px" Text ="<%$ Resources:globalResource,SaveText %>"
                            OnClientClick="return verify()" onclick="btnSave_Click" 
                             meta:resourcekey="btnSaveResource1"/>
                        &nbsp;
                       <asp:Button ID="btnCancel" runat ="server"  Width ="80px" Text ="<%$ Resources:globalResource,CancelText %>"
                            meta:resourcekey="btnCancelResource1"  OnClientClick="return cancel()"/>
                    </td>
                </tr>
              </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSave"/>
                </Triggers>
            </asp:UpdatePanel>
             
        </ContentTemplate>
       </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
        </td>
    </tr>
  </table>
</center>
</asp:Content>