<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportviewer.aspx.cs" Inherits="Reportviewer" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ReportViewer</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="LOGO" >
   <p class="Moddesc">
   <span>Scores Management </span>
   </p>
   </div>
   <p id='refresh'>
   <asp:TextBox runat='server' ID='imatno'></asp:TextBox>
   <asp:Label runat='server' ID='lmatno'>Mat.No.</asp:Label>
   <asp:TextBox runat='server' ID='isession'></asp:TextBox>
   <asp:Label runat='server' ID='lsession'>Session</asp:Label>
   <asp:TextBox runat='server' ID='isemester'></asp:TextBox>
   <asp:Label runat='server' ID='Label2'>Semester</asp:Label>
   <asp:Button runat='server' ID='bgenerate' 
           style="margin-left:10px;font:12px Cambria;" Text='Generate' 
           onclick="bgenerate_Click"/>
   </p>
   <p style="margin:5px auto 0px auto;width:100px"><asp:Button runat='server' ID='btnexp' 
           style="margin-left:0px;font:12px Cambria;" Text='Export' 
           onclick="btnexp_Click"/></p>
   <div style="margin:20px auto 0px auto">
       <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
           AutoDataBind="true" CssClass='viewer' DisplayStatusbar="False" 
           DisplayToolbar="False" GroupTreeStyle-BorderStyle="None" Height="50px"  Width="350px"/>
   </div>
   <p runat='server' id='brdsheethdr' style="text-align:center;font:18px Cambria"></p>
   <div>
   <asp:GridView ID="GridView1" runat="server" GridLines="None"
    AllowPaging="true"
    CssClass="mGrid"
    PagerStyle-CssClass="pgr"
    AlternatingRowStyle-CssClass="alt">
       </asp:GridView>
   </div>
   <div class='hide'></div>
   </form>
</body>
</html>
