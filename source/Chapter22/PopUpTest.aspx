<%@ Page Language = "vb" Codebehind="PopUpTest.aspx.vb" AutoEventWireup="false" Inherits="Chapter22.PopUpTest" %>
<%@ Register TagPrefix="cc1" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControlsLibrary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PopUpTest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<cc1:PopUp id="PopUp1" runat="server" PopUnder="False" Url="PopUpAd.aspx" Scrollbars="True"
				Resizable="True"></cc1:PopUp>
		</form>
	</body>
</HTML>
