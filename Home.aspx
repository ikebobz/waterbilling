<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body class='home'>
    <form id="form1" runat="server">
    <div>
    <p class='logo'>
    <img alt="" src="logoUNILAG.png" />
    </p>
    <ul class='globalmenu'>
    <li><a runat='server' id='student' href="default.aspx">Resident Information Center</a></li>
<li><a runat='server' id='subject' href="courseinfo.aspx">Service Officer Information Center</a></li>
<li><a runat='server' id="score" href='Billing.aspx'>Billing & Data </a></li>
<li><a runat='server' id="useracc" href='useraccount.aspx'>User Account Information Center</a></li>
<li><a runat='server' id="report" href='marksmgt.aspx'>Reporting</a></li>
    </ul>
    <p class='identifier'><span>Powered by OGU CHINENYE </span></p>
    <p class='grplogo'><img id='groupicon'alt="" src='group.jpg' /></p>
    </div>
    </form>
</body>
</html>
