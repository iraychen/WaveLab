<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SYSRoleAC.aspx.cs" Inherits="WaveLab.Web.SYSRoleAC" Title="无标题页"  meta:resourcekey="PageResource1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
<script  type="text/javascript">
$(document).ready( function() {
	$("input:submit").button();
});
function redirect(mode,value)
{
    var url;
    switch (mode)
    {
        case "COPY":
            url = "SYSRoleACCopy.aspx?roleid=" + value;
            break;
        default:
            break;
    }
    self.location.href=url;
    return false;
}
function  ALLCheck()
{ 
    var o = window.event.srcElement; 
    if (o.tagName == "INPUT" && o.type == "checkbox") 
    { 
        DoCheck(o,0); 
    } 
} 
function DoCheck( o,panduan) 
{ 
    if(panduan==0) 
    { 
        var d=o.id;
        var e= d.replace("CheckBox","Nodes");
        var div= window.document.getElementById(e);
        if(div!=null) 
        { 
            var check=div.getElementsByTagName("INPUT");
            for(i=0;i<check.length;i++) 
            { 
                if(check[i].type=="checkbox") 
                { 
                    check[i].checked=o.checked;
                } 
            } 
        } 
    } 
    else
    {
        var divid=null; 
        try 
        { 
            divid =o.parentElement.parentElement.parentElement.parentElement.parentElement; 
        } 
        catch (ex) 
        { 
            document.write (ex.description); 
        } 
        if ( divid == null) 
        { 
            return; 
        } 
        var id= divid.id.replace("Nodes","CheckBox");
        var checkbox=divid.getElementsByTagName("INPUT"); 
        var s=0; 
        for(i=0;i<checkbox.length;i++) 
        { 
            if(checkbox[i].checked) 
            { 
                s++; 
                break; 
            } 
        } 
        if(s==checkbox.length) 
        { 
           window.document.getElementById(id).checked=true; 
        } 
        else 
        { 
            window.document.getElementById(id).checked=false; 
        } 
        DoCheck(window.document.getElementById(id),1); 
    } 
} 


var count;
function  checkSelect(objname)
{

    var div=document.getElementById("ctl00_bodyPlaceHolder_"+objname);
  
    count=0;
    checkCount(div);
    if(count==0)
    {
        switch(objname)
        {
            case "treeViewAllMenus":
                alert($("#<%=lblAllMenus.ClientID%>").attr("title"));
                break;
            case "treeViewSelectedMenus":
                alert($("#<%=lblSelectedMenus.ClientID%>").attr("title"));
                break;
            default:
                break;
        }
        return false;
    }
    return true;
}

function checkCount(parentNode)
{
    var childs=parentNode.childNodes;
    if(childs.length==0)
    {
        return false;
    }
    for(var i=0;i<childs.length;i++)
    {
        if(childs(i).tagName =="INPUT")
        {
            if(childs(i).type=="checkbox"   &&   childs(i).parentNode==parentNode && childs(i).checked)   
            {
                count=count+1;
                return false;
            }
        }
        else
        {
            checkCount(childs(i));
        }
    }
}

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
 <center>
   <br />
   <table style=" text-align:left ;"  width="100%" cellpadding="5" cellspacing="0" >
   <tr>
    <td>
        <table  style="text-align:left;" width="630px">
          <tr>
            <td>
              
                <asp:Label ID ="lblRoleDesc" runat="server" meta:resourcekey="lblRoleDescResource1" />:&nbsp;&nbsp;
                <asp:Label ID="lblRoldeInfoDesc" runat="server" ForeColor="Blue" 
                    meta:resourcekey="lblRoleInfoDescResource1"/>
            </td>
             <td align="right">
                 <asp:NewButton ID="btnCopy" runat="server"  Width="60px"  Action ="RoleMenuMappingCopy"
                     meta:resourcekey="btnCopyResource1" />
                  <asp:NewButton ID="btnCancel" runat="server"  Width="60px" Text ="<%$ Resources:globalResource,CancelText %>"
                      OnClientClick ="return cancel()"/>
             </td>
         </tr>
         <tr>
             <td colspan ="2" >
                <table width="100%">
                   <tr>
                         <td  valign="top"><asp:Label ID="lblAllMenus" runat="server" 
                                 meta:resourcekey="lblAllMenusResource1" /></td>
                         <td >
                         </td>
                         <td><asp:Label ID="lblSelectedMenus" runat="server" 
                                 meta:resourcekey="lblSelectedMenusResource1" /></td>
                   </tr>
                   <tr>
                      <td>
                          <div style="overflow :auto; height:350px; width:275px; border:solid 1px gray">
                               <asp:TreeView ID="treeViewAllMenus" runat="server" ExpandDepth="0" 
                                   ShowCheckBoxes="All"  onclick="ALLCheck()" 
                                   meta:resourcekey="treeViewAllMenusResource1" ShowLines="True" >
                               </asp:TreeView>
                          </div> 
                      </td>
                      <td align="center" width="50">
                          <table>
                                 <tr>
                                     <td> 
                                         <asp:NewButton ID ="btnAdd" runat="server"     Action ="RoleMenuMappingAdd"
                                             OnClientClick ="return checkSelect('treeViewAllMenus')" 
                                             meta:resourcekey="btnAddResource1" onclick="btnAdd_Click"/></td>
                                 </tr>
                                 <tr>
                                     <td><br/></td>
                                 </tr>
                                  <tr>
                                     <td> 
                                         <asp:NewButton ID="btnDel" runat="server"     Action ="RoleMenuMappingDelete"
                                             OnClientClick ="return checkSelect('treeViewSelectedMenus')" 
                                             meta:resourcekey="btnDelResource1" onclick="btnDel_Click"/></td>
                                 </tr>
                          </table>
                      </td>
                      <td>
                          <div style="overflow :auto; height:350px;width:275px;border:solid 1px gray">
                               <asp:TreeView ID="treeViewSelectedMenus" runat="server" ExpandDepth="0" 
                                   ShowCheckBoxes="All" onclick="ALLCheck()" 
                                   meta:resourcekey="treeViewSelectedMenusResource1" ShowLines="True"></asp:TreeView>
                          </div>
                      </td>
                   </tr>
             </table>
             </td>
         </tr>
        </table>
     </td>
     </tr>
     </table>
    <br />
    <br />
    
</center>
</asp:Content>
