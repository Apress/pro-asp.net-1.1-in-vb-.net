<%@ Page Language = "vb" Codebehind="CustomCalendarTest.aspx.vb" AutoEventWireup="false" Inherits="Chapter20.CustomCalendarTest" %>
<%@ Register TagPrefix="cc1" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControlsLibrary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CustomCalendarTest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<cc1:RestrictedCalendar id="RestrictedCalendar7" runat="server">
				<DateTime Value="8/27/2004 12:00:00 AM" />
				<DateTime Value="8/28/2004 12:00:00 AM" />
			</cc1:RestrictedCalendar>
		</form>
	</body>
</HTML>
