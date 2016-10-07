<%@ Page Language = "vb" Codebehind="ImageTest.aspx.vb" AutoEventWireup="false" Inherits="Chapter05.ImageTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ImageTest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:ImageButton id="ImageButton1" style="Z-INDEX: 101; LEFT: 18px; POSITION: absolute; TOP: 21px"
				runat="server" ImageUrl="button.png"></asp:ImageButton>
			<asp:Label id="lblResult" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 163px"
				runat="server" Height="60px" Width="393px"></asp:Label>
		</form>
	</body>
</HTML>
