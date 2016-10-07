<%@ Page Language = "vb" Codebehind="Calendar.aspx.vb" AutoEventWireup="false" Inherits="RichControls.Calendar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Calendar</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Calendar runat="server" ID="Calendar1" ForeColor="red" BackColor="lightyellow" />
			<asp:Label id="lblDates" style="Z-INDEX: 102; LEFT: 14px; POSITION: absolute; TOP: 240px" runat="server"
				Width="313px" Height="72px" Font-Bold="True"></asp:Label></form>
	</body>
</HTML>
