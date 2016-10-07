<%@ Page Language = "vb" Codebehind="Controls.aspx.vb" AutoEventWireup="false" Inherits="Chapter3.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Controls</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<P><i>This is static HTML (not a web control).</i></P>
		<form id="Controls" method="post" runat="server">
			<asp:panel id="MainPanel" runat="server" Height="112px">
				<P>
					<asp:Button id="Button1" runat="server" Text="Button1"></asp:Button>
					<asp:Button id="Button2" runat="server" Text="Button2"></asp:Button>
					<asp:Button id="Button3" runat="server" Text="Button3"></asp:Button></P>
				<P>
					<asp:Label id="Label1" runat="server" Width="48px">Name:</asp:Label>
					<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></P>
			</asp:panel>
			<P><asp:button id="Button4" runat="server" Text="Button4"></asp:button></P>
		</form>
		<P><i>This is static HTML (not a web control).</i>
		</P>
	</body>
</HTML>
