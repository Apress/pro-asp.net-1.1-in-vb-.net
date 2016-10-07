<%@ Register TagPrefix="uc1" TagName="LinkTable" Src="LinkTable.ascx" %>
<%@ Page Language = "vb" Codebehind="LinkTableHost.aspx.vb" AutoEventWireup="false" Inherits="UserControls.LinkTableHost" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LinkTableHost</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<uc1:LinkTable id="LinkTable1" runat="server"></uc1:LinkTable></P>
			<P>
				<asp:Label id="lblInfo" runat="server"></asp:Label></P>
		</form>
	</body>
</HTML>
