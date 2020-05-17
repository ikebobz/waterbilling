<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Billing.aspx.cs" Inherits="Billing" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="LOGO1" >
   <p class="Moddesc2">
   <span>Billing & Data Processing</span>
   </p>
  </div>
   <div id="TextFields2">
   <p style="text-align:center"><span>Billing parameters</span></p>
   <p><span style="margin-right:10px">Surname:</span><asp:TextBox runat="server" ID="_sname" style="display:inline-block"/></p>
   <p style="text-align:right;margin-left:0px">
   <span style="margin-left:10px">RUID:</span><asp:TextBox runat="server" ID="_ruid" Enabled="False" style="display:inline-block;margin-left:30px"/>
   </p>
   <p style="text-align:right;margin-left:0px">
   <span style="margin-left:10px">Officer ID:</span><asp:DropDownList ID="DropDownList1"
       runat="server" AutoPostBack="True" 
           onselectedindexchanged="DropDownList1_SelectedIndexChanged">
   </asp:DropDownList>
       <asp:TextBox runat="server" ID="_sid"  style="display:inline-block;margin-left:30px" width="70px"/>
   </p>
   <p style="text-align:right;margin-left:0px">
   <span style="margin-left:10px">Pick Date:</span>
   <asp:TextBox runat="server" ID="_date" style="display:inline-block"/>
   <asp:ImageButton runat="server" ImageUrl="~/cal.jpeg" style="vertical-align:bottom" 
           onclick="Unnamed1_Click"/>
   </p>
       <asp:Calendar ID="Calendar1" runat="server" Visible="False" 
           style="position:absolute;width:300px;left:70px;z-index:1" 
           onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
   <p><span style="margin-left:10px">Meter Reading (cubic metres):</span><asp:TextBox runat="server" ID="_reading" style="display:inline-block" width="150px"/></p>
  <p style="text-align:right;margin-left:0px">
      <asp:Button ID="Update2" runat="server" Text="Update" 
           style="font:14px Cambria" onclick="Update2_Click"/></p>
     <p style="text-align:center;"><asp:Label runat='server' id='status' style="font:14px Cambria"></asp:Label></p>
</div>
<div id="infoDisplay2">
<p class="givecode"><label style="display:inline-block;margin-left:10px">Please specify Resident surname</label><asp:TextBox runat="server" ID="TextBox1" style="font:14px Cambria" /> 
    <asp:Button ID="Button2" runat="server" Text="GO" 
        style="font:14px Cambria; height: 26px" onclick="Button2_Click"/></p>
<p runat="server" id="links" style="margin-left:10px">
</p>
<p runat="server" id="details" style="margin-left:10px">
</p>
<div id="gridcontainer2" runat="server">
<asp:DataGrid runat="server" CssClass="grid" ID="history_grid" >
<HeaderStyle CssClass="gridheader" />
<ItemStyle CssClass="gridItem"/>
<AlternatingItemStyle CssClass="gridaltitem"/>
</asp:DataGrid>
</div>
</div>
<ul class='menu'>
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
