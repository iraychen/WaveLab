<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCSDPartMAMCreate.aspx.cs" Inherits="WaveLab.Web.SPCSDPartMAMCreate" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
    var LSL_TxLoPower = $("#<%=tbxLSL_TxLoPower.ClientID %>");
    if (LSL_TxLoPower.val().length == 0) {
        alert($("#<%=lblLSL_TxLoPowerMsg.ClientID %>").attr("title"));
        return false;
    }
    var USL_TxLoPower = $("#<%=tbxUSL_TxLoPower.ClientID %>");
    if (USL_TxLoPower.val().length == 0) {
        alert($("#<%=lblUSL_TxLoPowerMsg.ClientID %>").attr("title"));
        return false;
    }
   
    var USL_RxAGC = $("#<%=tbxUSL_RxAGC.ClientID %>");
    if (USL_RxAGC.val().length == 0) {
        alert($("#<%=lblUSL_RxAGCMsg.ClientID %>").attr("title"));
        return false;
    }
    var reg = /^[+-]?[0-9]+.?[0-9]*$/;
    if (
       ($.trim($("#<%=tbxLSL_TxLoPower.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLSL_TxLoPower.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUSL_TxLoPower.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUSL_TxLoPower.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxLSL_RxAGC.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLSL_RxAGC.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUSL_RxAGC.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUSL_RxAGC.ClientID %>").val())) == false)
    ) {
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
              SkinID="skinGridView"  Width ="100%"  DataKeyNames="StationNo,SerialNo"
            meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" >
              <Columns>                 
                  
                    <asp:BoundField  DataField="SerialNo" SortExpression ="SerialNo"  
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource1">
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
                    <asp:Label ID ="lblLSL_TxLoPower" runat ="server"
                        meta:resourcekey="lblLSL_TxLoPowerResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxLSL_TxLoPower" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxLSL_TxLoPowerResource1"/> 
                     <asp:Label ID ="lblLSL_TxLoPowerMsg" runat ="server"
                        meta:resourcekey="lblLSL_TxLoPowerMsgResource1" />
                </td>
             </tr>
              <tr>
                <td >
                    <asp:Label ID ="lblUSL_TxLoPower" runat ="server"
                        meta:resourcekey="lblUSL_TxLoPowerResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxUSL_TxLoPower" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxUSL_TxLoPowerResource1"/> 
                     <asp:Label ID ="lblUSL_TxLoPowerMsg" runat ="server"
                        meta:resourcekey="lblUSL_TxLoPowerMsgResource1" />
                </td>
             </tr>
             <tr>
                <td >
                    <asp:Label ID ="lblLSL_RxAGC" runat ="server"
                        meta:resourcekey="lblLSL_RxAGCResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxLSL_RxAGC" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxLSL_RxAGCResource1"/> 
                     <asp:Label ID ="lblLSL_RxAGCMsg" runat ="server"
                        meta:resourcekey="lblLSL_RxAGCMsgResource1" />
                </td>
             </tr>
              <tr>
                <td >
                    <asp:Label ID ="lblUSL_RxAGC" runat ="server"
                        meta:resourcekey="lblUSL_RxAGCResource1" />
                </td>
                <td>
                    <asp:TextBox ID ="tbxUSL_RxAGC" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                    meta:resourcekey="tbxUSL_RxAGCResource1"/> 
                     <asp:Label ID ="lblUSL_RxAGCMsg" runat ="server"
                        meta:resourcekey="lblUSL_RxAGCMsgResource1" />
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
                            meta:resourcekey="btnCancelResource1" OnClientClick="return cancel()" />
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