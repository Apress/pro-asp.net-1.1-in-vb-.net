<%@ Page Language = "vb" Codebehind="Welcome.aspx.vb" AutoEventWireup="false" Inherits="Chapter2.Welcome" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Welcome</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Welcome" method="post" runat="server">
			<P>
				<asp:Label id="lblSiteName" runat="server" Font-Bold="True" Font-Size="Large">Label</asp:Label></P>
			<P>
				<asp:Label id="lblWelcome" runat="server" Font-Names="Tahoma">Label</asp:Label></P>
		</form>
	</body>
</HTML>
