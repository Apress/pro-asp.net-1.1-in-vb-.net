<%@ Page Language = "vb" Codebehind="SecurityTest.aspx.vb" AutoEventWireup="false" Inherits="SecureServiceTest.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblInfo" style="Z-INDEX: 100; LEFT: 22px; POSITION: absolute; TOP: 165px" runat="server"
				Font-Size="Large" Font-Bold="True" Font-Names="Verdana" Height="117px" Width="552px"></asp:label><asp:label id="Label2" style="Z-INDEX: 107; LEFT: 21px; POSITION: absolute; TOP: 51px" runat="server">Password:</asp:label><asp:label id="Label1" style="Z-INDEX: 106; LEFT: 20px; POSITION: absolute; TOP: 18px" runat="server">User Name:</asp:label>
			<asp:TextBox id="txtPassword" style="Z-INDEX: 104; LEFT: 108px; POSITION: absolute; TOP: 48px"
				runat="server" Width="155px" TextMode="Password"></asp:TextBox>
			<asp:TextBox id="txtUserName" style="Z-INDEX: 103; LEFT: 108px; POSITION: absolute; TOP: 18px"
				runat="server"></asp:TextBox>
			<asp:Button id="cmdAuthenticated" style="Z-INDEX: 102; LEFT: 195px; POSITION: absolute; TOP: 99px"
				runat="server" Width="160px" Text="Authenticated Call"></asp:Button>
			<asp:Button id="cmdUnauthenticated" style="Z-INDEX: 101; LEFT: 22px; POSITION: absolute; TOP: 99px"
				runat="server" Width="160px" Text="Unauthenticated Call"></asp:Button></form>
	</body>
</HTML>
