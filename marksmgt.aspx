<%@ Page Language="C#" AutoEventWireup="true" CodeFile="marksmgt.aspx.cs" Inherits="marksmgt" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Score Management</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
	<div id="LOGO" >
   <p class="Moddesc">
   <span>Reporting </span>
   </p>
   </div>
   <div id="longpanel">
   <p style="text-align:center;font-size:16px;font-weight:bold">Consumption in cubic metre</p>
   <p>
  <asp:TextBox runat="server" ID="surname" /> <asp:Checkbox  runat="server" 
           ID="chk_surname" AutoPostBack="True" 
           oncheckedchanged="chk_surname_CheckedChanged"/><label>Consumption per Household</label>
   </p>
   <p>
   <asp:TextBox  runat="server" id="zone" /><asp:Checkbox  runat="server" 
           ID="chk_zone" AutoPostBack="True" oncheckedchanged="chk_zone_CheckedChanged"/><label>Consumption per Zone</label>
   </p>
   <p>
   <label>Select start date</label>
   <asp:TextBox runat="server" ID="date_begin"></asp:TextBox>
   <label style="margin-left:50px">Select End date</label>
   <asp:TextBox runat="server" ID="date_end"></asp:TextBox>
       <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="date_begin" />
       <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="date_end"/>
       <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="getResidents"
        MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="surname" FirstRowSelected="False">
       </ajaxToolkit:AutoCompleteExtender>
   </p>
   <p>
       <asp:Button ID="report" runat="server" Text="Generate"  
           style="margin-left:10px" onclick="report_Click"/>
   </p>
   </div>
   <div id="longpanel2">
    <p style="text-align:center;font-size:16px;font-weight:bold">Revenue in Naira</p>
   <p>
  <asp:TextBox runat="server" ID="rev_surname" /> <asp:Checkbox  runat="server" 
           ID="rev_chk_surname" AutoPostBack="True" 
           oncheckedchanged="rev_chk_surname_CheckedChanged"/><label>Revenue per Household</label>
           <label>Rate/cubic metre</label><asp:TextBox runat="server" ID="rate"></asp:TextBox>
   </p>
   <p>
   <asp:TextBox  runat="server" id="rev_zone" /><asp:Checkbox  runat="server" 
           ID="rev_chk_zone" AutoPostBack="True" 
           oncheckedchanged="rev_chk_zone_CheckedChanged"/><label>Revenue per Zone</label>
   </p>
   <p>
   <label>Select start date</label>
   <asp:TextBox runat="server" ID="rev_date_begin"></asp:TextBox>
   <label style="margin-left:50px">Select End date</label>
   <asp:TextBox runat="server" ID="rev_date_end"></asp:TextBox>
       <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="rev_date_begin" />
       <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="rev_date_end"/>
       <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServiceMethod="getResidents"
        MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="rev_surname" FirstRowSelected="False">
       </ajaxToolkit:AutoCompleteExtender>
   </p>
   <p>
       <asp:Button ID="rev_report" runat="server" Text="Generate"  
           style="margin-left:10px" onclick="rev_report_Click"/>
   </p>
   </div>
   <p><asp:Label runat="server" ID="status" style="display:inline-block;margin-left:10px"></asp:Label>
       <asp:Button ID="print" runat="server" Text="Print Report" 
           onclick="print_Click" />
   </p>
<div>
    <CR:CrystalReportViewer ID="report_viewer" runat="server" AutoDataBind="true" 
        EnableParameterPrompt="False"  />
</div>
  <ul class='menu_score'><li><a href='default.aspx'>Resident Information Centre</a></li>
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
