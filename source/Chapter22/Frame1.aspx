<%@ Page Language = "vb" Codebehind="Frame1.aspx.vb" AutoEventWireup="false" Inherits="Chapter22.Frame1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Frame1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<a href="http://www.apress.com" target="content">Apress</a><BR>
				<br>
				<img src="buttonOriginal.jpg" onClick="parent.content.location='http://www.apress.com'">
			</P>
			<P>
				<asp:Button id="Button1" runat="server" Text="Click Here for Google" Width="144px"></asp:Button></P>
		</form>
	</body>
</HTML>
