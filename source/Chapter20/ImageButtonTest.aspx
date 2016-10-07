<%@ Page Language = "vb" Codebehind="ImageButtonTest.aspx.vb" AutoEventWireup="false" Inherits="Chapter20.RolloverButtonTest" %>
<%@ Register TagPrefix="cc1" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControlsLibrary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RolloverButtonTest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<cc1:CustomImageButton id="CustomImageButton1" runat="server" ImageUrl="button1.jpg"></cc1:CustomImageButton></P>
			<P>
				<asp:Label id="lblInfo" runat="server"></asp:Label></P>
		</form>
	</body>
</HTML>
