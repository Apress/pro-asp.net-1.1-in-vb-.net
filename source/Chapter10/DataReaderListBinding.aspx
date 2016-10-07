<%@ Page Language = "vb" Codebehind="DataReaderListBinding.aspx.vb" AutoEventWireup="false" Inherits="Chapter10.DataReaderListBinding" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataReaderListBinding</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:ListBox runat="server" ID="Listbox1" Size="10" SelectionMode="Multiple" DataTextField="FullName"
				DataValueField="EmployeeID" Height="178px" />
			<br>
			<asp:Button runat="server" Text="Get Selection" ID="cmdGetSelection" />
			<br>
			<br>
			<asp:Literal runat="server" ID="Result" EnableViewState="False" /></form>
	</body>
</HTML>
