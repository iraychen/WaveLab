<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCSDPartRxPowerCreate.aspx.cs" Inherits="WaveLab.Web.SPCSDPartRxPowerCreate" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

<script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
    $(document).ready(function() {
        $("input:submit").button();
        if ($("#<%=chxDivide.ClientID %>").attr("checked") == true) {
            $("#<%=ddlCHNo.ClientID %>").show();
        } else {
            $("#<%=ddlCHNo.ClientID %>").hide();
        }

        $("#<%=chxDivide.ClientID %>").bind("click", function() {
            if ($(this).attr("checked") == true) {
                $("#<%=ddlCHNo.ClientID %>").show();
            } else {
                $("#<%=ddlCHNo.ClientID %>").hide();
            }
        });
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
    var LSL = $("#<%=tbxLSL.ClientID %>");
    if (LSL.val().length == 0) {
        alert($("#<%=lblLSLMsg.ClientID %>").attr("title"));
        return false;
    } 
    var USL = $("#<%=tbxUSL.ClientID %>");
    if (USL.val().length == 0) {
        alert($("#<%=lblUSLMsg.ClientID %>").attr("title"));
        return false;
    }
    var reg = /^[+-]?[0-9]+.?[0-9]*$/;
    if (
       ($.trim($("#<%=tbxLSL.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxLSL.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxUSL.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxUSL.ClientID %>").val())) == false) 
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
                    <asp:Label ID="lblCHNo" runat="server"  
                        meta:resourcekey="lblCHNoResource1"/>
                </td>
                <td>
                    <asp:CheckBox ID="chxDivide" runat="server" />
                    <span style="margin-left:10px">
                        <asp:DropDownList ID ="ddlCHNo" runat="server" Width="50" 
                            meta:resourcekey="ddlCHNoResource1"></asp:DropDownList>
                     </span>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:Label ID="lblMode" runat="server"  
                        meta:resourcekey="lblModeResource1"/>
                </td>
                <td>
                    <asp:DropDownList ID ="ddlMode" runat="server" 
                        meta:resourcekey="ddlModeResource1">
                        <asp:ListItem Selected="True" meta:resourcekey="ListItemResource1"></asp:ListItem>
                        </asp:DropDownList>
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
              SkinID="skinGridView"  Width ="100%"  DataKeyNames="StationNo,Divide,CHNo,Mode,CH,PW,SerialNo"
            meta:resourcekey="GVListResource1" onsorting="GVList_Sorting" >
              <Columns>                 
                  <asp:BoundField  DataField="CH" SortExpression ="CH"  
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource1">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                 <asp:BoundField  DataField="PW" SortExpression ="PW"  
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource2">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                    <asp:BoundField  DataField="SerialNo" SortExpression ="SerialNo"  
                      HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        meta:resourcekey="BoundFieldResource3">
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
        ActiveTabIndex="0"         
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
                                <asp:Label ID ="lblLSL" runat ="server"
                                    meta:resourcekey="lblLSLResource1" />
                            </td>
                            <td>
                                <asp:TextBox ID ="tbxLSL" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                                meta:resourcekey="tbxLSLResource1"/> 
                                 <asp:Label ID ="lblLSLMsg" runat ="server"
                                    meta:resourcekey="lblLSLMsgResource1" />
                            </td>
                         </tr>
                          <tr>
                            <td >
                                <asp:Label ID ="lblUSL" runat ="server"
                                    meta:resourcekey="lblUSLResource1" />
                            </td>
                            <td>
                                <asp:TextBox ID ="tbxUSL" runat ="server"     Width="150px" CssClass="mask_pnum" MaxLength="10"
                                meta:resourcekey="tbxUSLResource1"/> 
                                 <asp:Label ID ="lblUSLMsg" runat ="server"
                                    meta:resourcekey="lblUSLMsgResource1" />
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