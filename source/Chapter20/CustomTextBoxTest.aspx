<%@ Register TagPrefix="cc1" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControlsLibrary" %>
<%@ Page Language = "vb" Codebehind="CustomTextBoxTest.aspx.vb" AutoEventWireup="false" Inherits="Chapter20.CustomTextBoxTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CustomTextBoxTest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<cc1:CustomTextBox id="CustomTextBox1" runat="server" Text="Sample Text"></cc1:CustomTextBox>&nbsp;
				<asp:Button id="Button1" runat="server" Text="Submit"></asp:Button></P>
			<P>
				<asp:Label id="lblInfo" runat="server" EnableViewState="False"></asp:Label></P>
		</form>
	</body>
</HTML>
