<%@ Page Language = "vb" Codebehind="FailedScriptInjection.aspx.vb" AutoEventWireup="false" Inherits="Chapter04.FailedScriptInjection" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ScriptInjection</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:TextBox id="txtInput" runat="server" Width="298px">&lt;script&gt;alert('Script Injection');&lt;/script&gt;</asp:TextBox>
				<asp:Button id="cmdSubmit" runat="server" Text="Submit"></asp:Button></P>
			<P>
				<asp:Label id="lblInfo" runat="server"></asp:Label></P>
		</form>
	</body>
</HTML>
