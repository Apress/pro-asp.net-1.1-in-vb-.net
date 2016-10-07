<%@ Page Language = "vb" Codebehind="TimeDisplayHost.aspx.vb" AutoEventWireup="false" Inherits="UserControls.DateTimeDisplayHost" %>
<%@ Register TagPrefix="uc1" TagName="TimeDisplay" Src="TimeDisplay.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DateTimeDisplayHost</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P>
				<uc1:TimeDisplay id="TimeDisplay2" runat="server"></uc1:TimeDisplay>
				<hr>
				<uc1:TimeDisplay id="TimeDisplay1" Format="dddd, dd MMMM yyyy HH:mm:ss tt (GMT z)" runat="server"></uc1:TimeDisplay>
			</P>
		</form>
	</body>
</HTML>
