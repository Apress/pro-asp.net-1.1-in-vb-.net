<%@ Page Language = "vb" Codebehind="DataSetUpdate.aspx.vb" AutoEventWireup="false" Inherits="Chapter09.DataSetUpdate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataSetUpdate</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<h2>Original data</h2>
			<asp:DataGrid runat="server" ID="Datagrid1" HeaderStyle-Font-Bold="true" />
			<br>
			<asp:Literal runat="server" ID="CommandsText" />
			<br>
			<h2>Data after editing and updating</h2>
			<asp:DataGrid runat="server" ID="Datagrid2" HeaderStyle-Font-Bold="true" />
		</form>
	</body>
</HTML>
