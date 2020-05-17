<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAccount.aspx.cs" Inherits="UserAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Account Management</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="LOGO" >
   <p class="Moddesc">
   <span>User Account Information Center</span>
   </p>
   </div>
   <div id="TextFields">
   <p style="text-align:center"><span>User Account Details</span></p>
   <asp:TextBox runat="server" ID="sname" /><p>User Surname</p>
   <asp:TextBox runat="server" ID="fname" /><p>User FirstName</p>
   <asp:TextBox runat="server" ID="user" /><p>UID</p>
   <asp:TextBox runat="server" ID="pass" /><p>Password</p>
   <asp:DropDownList ID='ddl' runat='server' style="font:14px Cambria"></asp:DropDownList><p>Role</p>
   <div id="btncontainer"><asp:Button ID="Update" runat="server" Text="Update" 
           style="font:14px Cambria;margin-right:30px" onclick="Update_Click"/>
       <asp:CheckBox runat='server' ID='chk1' style="font:14px Cambria" 
           Text='Check to remove a record' AutoPostBack="True" 
           oncheckedchanged="chk1_CheckedChanged"/></div>
    <p style="text-align:center;margin-top:20px"><asp:Label runat='server' id='status' style="font:14px Cambria"></asp:Label></p>
</div>
<div id="infoDisplay">
<p class="givematricno"> <label style="display:inline-block;margin-left:10px">Please specify user surname</label><asp:TextBox runat="server" ID="TextBox1" style="font:14px Cambria"/> 
    <asp:Button ID="Button1" runat="server" Text="GO" 
        style="font:14px Cambria; height: 26px;" onclick="Button1_Click"/></p>

<div id="gridcontainer">
<table class="outset">
<tr class="header">
<td>S/No.</td>
<td>UserID</td>
<td>Password</td>
<td>Role</td>
</tr>
<tr><td>1.</td>
<td runat='server' id='uname'></td>
<td runat='server' id='upass'></td>
<td runat='server' id='urole'></td>
</tr>
</table>
</div>
</div>
<ul class='menu2'>
<li><a href='default.aspx'>Resident Information Centre</a></li>
<li><a href='courseinfo.aspx'>Service Officer Information Centre</a></li>
<li><a href='billing.aspx'>Billing & Data Processing</a></li>
<li><a href='useraccount.aspx'>User Account Management</a></li>
<li><a href="Home.aspx">Home</a></li>
<li><a href="marksmgt.aspx">Reporting</a></li>
<li><a href="LoginPage.aspx">Logout</a></li>
</ul>
  </form>
  </body>
</html>
