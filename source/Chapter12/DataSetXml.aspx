<%@ Page Language = "vb" Codebehind="DataSetXml.aspx.vb" AutoEventWireup="false" Inherits="Chapter12.DataSetXml" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataSetXml</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM id="Form2" method="post" runat="server">
			<H2>Data from SQL Server</H2>
			<asp:DataGrid id="Datagrid1" runat="server" HeaderStyle-Font-Bold="true"></asp:DataGrid><BR>
			<BR>
			<H2>Data from the XML file</H2>
			<asp:DataGrid id="Datagrid2" runat="server" HeaderStyle-Font-Bold="true"></asp:DataGrid>
		
  		</FORM>
	</body>
</HTML>
