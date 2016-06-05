<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMTCPTemplateNew.aspx.cs" Inherits="WaveLab.Web.SMTCPTemplateNew" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script type ="text/javascript">
$(document).ready(function()
{
 $(".date").datepicker({
   showOn:"button",
   buttonImageOnly:true,
   dateFormat:"yy-mm-dd",
   changeYear:true,
   changeMonth:true
 });
 
 $(".date").mask("9999-99-99",{});
 
 $("input:submit").button();
});
function  upload()
{
   
    var effectiveDate=$("#<%=tbxEffectiveDate.ClientID %>");
    if(effectiveDate.val().length==0)
    {
      alert($("#<%=lblEffectiveDateMsg.ClientID %>").attr("title"));
      effectiveDate.focus();
      return false;
    }
    if(checkDate(effectiveDate.val())==false)
    {
      alert($("#<%=lblDateFormatMsg.ClientID %>").attr("title"));
      effectiveDate.focus();
      return false;
    }
    
    var uploader=$("#<%=fileUploader.ClientID%>");
    if(uploader.val().length==0)
    {
        alert($("#<%=lblUploadValueMsg.ClientID %>").attr("title"));;
        return false;
    }
    var fileString=uploader.val();
    var index=fileString.lastIndexOf(".")
    if(fileString.substr(index+1).toUpperCase()!="XLS")
    {
        alert($("#<%=lblFileTypeMsg.ClientID %>").attr("title"));;
        return false;
    }
    return true;
}

function goBack()
{
    self.location.href="SMTCPTemplateCtl.aspx";
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
    <asp:ImageButton ID="imgBtnBack" runat ="server" SkinID ="imgBtnSkinBack"  
         OnClientClick ="return goBack()" meta:resourcekey="imgBtnBackResource1"/>
<center>
     <br />
   <asp:Label ID ="lblTitle" runat="server"  SkinID ="skinCTitle" 
     meta:resourcekey="lblTitleResource1" /><br />
   <br />
 
  <table style=" text-align:left ;" >

        <tr>
            <td><asp:Label ID="lblEffectiveDate" runat="server"  ForeColor ="Red"
                    meta:resourcekey="lblEffectiveDateResource1"/></td>
            <td  colspan ="2" valign="middle">
                <asp:TextBox ID ="tbxEffectiveDate" runat ="server"  MaxLength ="10"  CssClass ="date"
                    Width ="80px" meta:resourcekey="tbxEffectiveDateResource1"/> 
                <asp:Label ID="lblDateFormat" runat ="server"   Text ="<%$Resources:globalResource,DateFormat%>" /> 
                <asp:Label ID="lblEffectiveDateMsg"  runat="server" 
                    meta:resourcekey="lblEffectiveDateMsgResource1" />
                <asp:Label ID="lblDateFormatMsg" runat ="server"   
                    ToolTip ="<%$ Resources:globalResource,DateFormatMsg %>" 
                    meta:resourcekey="lblDateFormatMsgResource1" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblDocument" runat="server" 
                    meta:resourcekey="lblDocumentResource1" /></td>
            <td>
                <asp:FileUpload ID="fileUploader" runat="server"  Width ="300px"
                    meta:resourcekey="fileUploaderResource1"   />
            </td>
            <td>
                <asp:NewButton ID="btnUpload" runat="server"  Width ="80px"  ButtonType ="new"  OnClientClick ="return upload()"
                    meta:resourcekey="btnUploadResource1" onclick="btnUpload_Click" />
                <asp:Label ID="lblUploadValueMsg" runat="server" 
                    ToolTip="<%$ Resources:globalResource,uploadValueMsg %>" 
                    meta:resourcekey="lblUploadValueMsgResource1" />
                <asp:Label ID="lblFileTypeMsg" runat="server" 
                    ToolTip="<%$ Resources:globalResource,excelFileTypeMsg %>" 
                    meta:resourcekey="lblFileTypeMsgResource1" />
            </td>
        </tr>
  </table>
       
</center>
</asp:Content>