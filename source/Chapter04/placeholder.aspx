<%@ Page Language="vb" AutoEventWireup="false" Codebehind="placeholder.aspx.vb" Inherits="placeholder"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>placeholder</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder>
			<asp:Button id="newButton" style="Z-INDEX: 101; LEFT: 96px; POSITION: absolute; TOP: 120px"
				runat="server" Text="Button"></asp:Button>
			<asp:Button id="Button2" style="Z-INDEX: 102; LEFT: 240px; POSITION: absolute; TOP: 288px" runat="server"
				Text="Button"></asp:Button>
			<asp:TextBox id="newTextBox" style="Z-INDEX: 103; LEFT: 240px; POSITION: absolute; TOP: 184px"
				runat="server">n</asp:TextBox>
		</form>
	</body>
</HTML>
