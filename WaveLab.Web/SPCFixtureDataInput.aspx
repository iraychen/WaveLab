<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SPCFixtureDataInput.aspx.cs" Inherits="WaveLab.Web.SPCFixtureDataInput" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript" src ="js/jquery.keyfilter.js"></script>
<script type ="text/javascript">
$(document).ready(function(){
    $(".date").datepicker({
        showOn: "button",
        buttonImageOnly: true,
        dateFormat: "yy-mm-dd",
        changeYear: true,
        changeMonth: true
    });
    $(".date").mask("9999-99-99", {});
    $("input:submit").button();
    $(".mask_pnum").keyfilter(/[\d\-\.]/);
});

function verify() {
    var testingDate = $("#<%=tbxTestingDate.ClientID %>");
    if (testingDate.val().length == 0) {
        alert($("#<%=lblDateRequiredMsg.ClientID %>").attr("title"));
        return false;
    }
    if (checkDate(testingDate.val()) == false) {
        alert($("#<%=lblDateFormatMsg.ClientID %>").attr("title"));
        return false;
    }
    if ($.trim($("#<%=tbxReturnLossValue.ClientID %>").val()).length == 0 || $.trim($("#<%=tbxInsertionLossValue.ClientID %>").val()).length == 0) {
        alert($("#<%=lblNumberRequiredMsg.ClientID %>").attr("title"));
        return false;
    }
    
    var reg = /^[+-]?[0-9]+.?[0-9]*$/;
    if (($.trim($("#<%=tbxReturnLossValue.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxReturnLossValue.ClientID %>").val())) == false)
    || ($.trim($("#<%=tbxInsertionLossValue.ClientID %>").val()).length > 0 && reg.test($.trim($("#<%=tbxInsertionLossValue.ClientID %>").val())) == false)) {
        alert($("#<%=lblNumberFormatErrorMsg.ClientID %>").attr("title"));
        return false;
    }   
    return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
<div style="padding:5px;" >
   <table style="width:100%; text-align:left;margin-top:5px; margin-bottom:5px;"  class="setup-table" cellpadding="5">
    <tr>
        <td style="width:100px"><asp:Label ID="lblFixture" runat="server" 
                meta:resourcekey="lblFixtureResource1"/></td>
        <td>
            <asp:Literal ID="ltlFixture" runat="server" 
                meta:resourcekey="ltlFixtureResource1" />
        </td>
        <td>
            <asp:Label ID="lblFrequencyBand" runat="server" 
                meta:resourcekey="lblFrequencyBandResource1" />
        </td>
        <td>
            <asp:Literal ID="ltlFrequencyBand" runat="server" 
                meta:resourcekey="ltlFrequencyBandResource1" />
        </td>
        
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblCH" runat="server" 
                meta:resourcekey="lblCHResource1" />
        </td>
        <td>
            <asp:Literal ID="ltlCH" runat="server" 
                meta:resourcekey="ltlCHResource1" />
        </td>
        <td></td>
        <td></td>
    </tr>
   </table>
   <br />
   <asp:GridView ID="GVList" runat="server" AllowSorting ="True"   
        AutoGenerateColumns="False"  DataKeyNames="FixtureItemPK,NoOfTimes"
            SkinID="skinGridView" Width ="100%" meta:resourcekey="GVListResource1" 
       onrowediting="GVList_RowEditing" onrowdatabound="GVList_RowDataBound">
          <Columns>
              <asp:BoundField  DataField="NoOfTimes"  meta:resourcekey="BoundFieldResource1"/>
              <asp:BoundField  DataField="TestingDate"   DataFormatString="{0:yyyy-MM-dd}" meta:resourcekey="BoundFieldResource2"/>
              <asp:BoundField  DataField="ReturnLossValue" meta:resourcekey="BoundFieldResource3" DataFormatString="{0:f2}"/> 
              <asp:BoundField  DataField="InsertionLossValue" meta:resourcekey="BoundFieldResource4" DataFormatString="{0:f2}"/>          
              <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtEdit" runat ="server"  CommandName="Edit" meta:resourcekey="lbtEditResource1" />                        
                    </ItemTemplate>
              </asp:TemplateField>    
       </Columns>     
    </asp:GridView>
   <br />
   <ajaxToolkit:TabContainer ID="TabContainerCreate" runat="server" 
        ActiveTabIndex="0"         
        OnDemand="true"
        UseVerticalStripPlacement="true"
        VerticalStripWidth="120px" meta:resourcekey="TabContainerCreateResource1" >
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
                            <td ><asp:Label ID="lblTestingDate" runat="server"  
                                    meta:resourcekey="lblTestingDateResource1"/>
                            </td>
                            <td>
                                 <asp:TextBox ID="tbxTestingDate" runat="server" 
                                     Width="200px"    CssClass="date"
                                     meta:resourcekey="tbxTestingDateResource1" />
                                    <asp:Label ID="lblTestingDateFormat" runat ="server" 
                                                           Text ="<%$ Resources:globalResource,DateFormat %>" 
                                                           meta:resourcekey="lblTestingDateFormatResource1"  /> 
                            </td>
	                    </tr>		      
	                    <tr>
                            <td >
                                <asp:Label ID ="lblReturnLossValue" runat ="server"
                                    meta:resourcekey="lblReturnLossValueResource1" />
                            </td>
                            <td>
                                <asp:TextBox ID ="tbxReturnLossValue" runat ="server"     Width="200px" CssClass="mask_pnum" MaxLength="10"
                                meta:resourcekey="tbxReturnLossValueResource1"/> 
                            </td>
                         </tr>
                         <tr>
                            <td >
                                <asp:Label ID ="lblInsertionLossValue" runat ="server"
                                    meta:resourcekey="lblInsertionLossValueResource1" />
                            </td>
                            <td>
                                <asp:TextBox ID ="tbxInsertionLossValue" runat ="server"     Width="200px" CssClass="mask_pnum" MaxLength="10"
                                meta:resourcekey="tbxInsertionLossValueResource1"/> 
                            </td>
                         </tr>
                      </table>
                   </fieldset>       
                </td>
               </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="Mode" runat="server" />
                        <asp:HiddenField ID="NoOfTimes_Input" runat="server" />
                        <asp:Label ID="lblNumberFormatTip" ForeColor="Red" runat="server"  meta:resourcekey="lblNumberFormatTipResource1"/>
                      
                       <asp:Label ID="lblDateRequiredMsg" runat ="server"                                   
                             ToolTip ="<%$ Resources:globalResource,DateRequiredMsg %>" 
                             meta:resourcekey="lblDateRequiredMsgResource1" />
                        <asp:Label ID="lblDateFormatMsg" runat ="server"   
                                        ToolTip ="<%$ Resources:globalResource,DateFormatMsg %>" 
                             meta:resourcekey="lblDateFormatMsgResource1" />   
                         <asp:Label ID="lblNumberRequiredMsg" runat ="server"   
                                                               meta:resourcekey="lblNumberRequiredMsgResource1"  />
                        <asp:Label ID="lblNumberFormatErrorMsg" runat ="server"   
                                                                
                            ToolTip ="<%$ Resources:globalResource,NumberFormatErrorMsg %>" 
                            meta:resourcekey="lblNumberFormatErrorMsgResource1" />
                        <asp:Button  ID="btnSave" runat="server"  Width ="80px" Text ="<%$ Resources:globalResource,SaveText %>"
                            OnClientClick="return verify()" onclick="btnSave_Click" 
                             meta:resourcekey="btnSaveResource1"/>
                        &nbsp;
                       <asp:Button ID="btnCancel" runat ="server"  Width ="80px" Text ="<%$ Resources:globalResource,CancelText %>"
                            meta:resourcekey="btnCancelResource1" />
                    </td>
                </tr>
              </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GVList" EventName="RowEditing" />
                    <asp:PostBackTrigger ControlID="btnSave"/>
                </Triggers>
            </asp:UpdatePanel>
             
        </ContentTemplate>
       </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</div >
</asp:Content>