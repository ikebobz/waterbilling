<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Management</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div id="LOGO" >
   <p class="Moddesc">
   <span>Resident Information Center</span>
   </p>
   </div>
   <div id="TextFields">
   <p style="text-align:center"><span>New Resident Details</span></p>
   <asp:TextBox runat="server" ID="_sname" /><p>Surname</p>
   <asp:TextBox runat="server" ID="_fname" /><p>FirstName</p>
   <asp:TextBox runat="server" ID="_oname" /><p>OtherName</p>
   <asp:TextBox runat="server" ID="_addr" /><p>Address</p>
   <asp:TextBox runat="server" ID="_phone" /><p>Phone No</p>
   <asp:TextBox runat="server" ID="_email" /><p>Email</p>
   <asp:TextBox runat="server" ID="_zone" /><p>Zone</p>
   <div id="btncontainer"><asp:Button ID="Update" runat="server" Text="Update" 
           style="font:14px Cambria" onclick="Update_Click"/></div>
           <p style="text-align:center;"><asp:Label runat='server' id='status' style="font:14px Cambria"></asp:Label></p>
</div>
<div id="infoDisplay">
<p class="givematricno"><label style="display:inline-block;margin-left:10px">Please specify RUID</label> <asp:TextBox runat="server" ID="TextBox1" style="font:14px Cambria"/> 
    <asp:Button ID="Button1" runat="server" Text="GO" 
        style="font:14px Cambria; height: 26px;" onclick="Button1_Click"/></p>
<p class="givematricno"><label style="display:inline-block;margin-left:10px">Please specify Surname</label><asp:TextBox runat="server" ID="TextBox2" style="font:14px Cambria"/> 
    <asp:Button ID="Button2" runat="server" Text="GO" 
        style="font:14px Cambria; height: 26px;" onclick="Button2_Click"/></p>

<div id="gridcontainer" runat="server">
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
