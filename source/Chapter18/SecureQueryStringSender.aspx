<%@ Page Language = "vb" Codebehind="SecureQueryStringSender.aspx.vb" AutoEventWireup="false" Inherits="Chapter18.SecureQueryStringSender" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SecureQueryStringSender</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox id="txtData" style="Z-INDEX: 101; LEFT: 196px; POSITION: absolute; TOP: 17px" runat="server"></asp:TextBox>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 17px; POSITION: absolute; TOP: 17px" runat="server">Enter some data to encrypt:</asp:Label>
			<asp:Button id="cmdOK" style="Z-INDEX: 103; LEFT: 19px; POSITION: absolute; TOP: 65px" runat="server"
				Text="Go" Width="111px"></asp:Button>
		</form>
	</body>
</HTML>
