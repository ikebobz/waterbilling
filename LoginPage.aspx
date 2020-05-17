<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Portal</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
    <p class='logo'>
    <img alt="" src="logoUNILAG.png" />
    </p>
    <p class='loginmsg'><span>Please enter your Login credentials</span></p>
    <p class='user'>
    <asp:TextBox runat="server" ID="uid" Font-Names="Cambria" Font-Size="14pt"></asp:TextBox><span><img alt="" src="username2.jpg" /></span>
    </p>
     <p class='pass'>
    <asp:TextBox runat="server" ID="pass" Font-Names="Cambria" Font-Size="14pt" 
             TextMode="Password"></asp:TextBox><span><img alt="" src="padlock2.jpg" /></span>
    <p class='dropdown'>
    <asp:DropDownList runat="server" ID="list1" Font-Names="Cambria" Font-Size="14pt"></asp:DropDownList><span class='role'>Please select a role</span>
    </p>
    </p>
    <p class='button'><asp:Button  runat="server" ID="logbtn" Text="Login" 
            Font-Names="Cambria" Font-Size="14pt" onclick="logbtn_Click"/></p>
  </div>
    </form>
</body>
</html>
