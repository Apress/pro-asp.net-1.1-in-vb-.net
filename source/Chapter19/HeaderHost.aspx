<%@ Page Language = "vb" Codebehind="HeaderHost.aspx.vb" AutoEventWireup="false" Inherits="UserControls.HeaderHost" %>
<%@ Register TagPrefix="apress" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HeaderHost</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<apress:Header id="Header1" runat="server"></apress:Header>
		</form>
	</body>
</HTML>
