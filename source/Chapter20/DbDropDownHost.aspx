<%@ Page Language = "vb" AutoEventWireup="false" CodeBehind="DbDropDownHost.aspx.vb" Inherits="Chapter20.DbDropDownHost" %>
<%@ Register TagPrefix="apress" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControlsLibrary" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html public "-//w3c//dtd html 4.0 transitional//en" >
<HTML>
	<HEAD>
		<title>DbDropDownHost</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body ms_positioning="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<apress:DBDropdown id="dropdownSample" runat="server"></apress:DBDropdown>
			<br>
			<asp:Button id="submit" runat="server" text="Submit"></asp:Button>
			<br>
			<asp:Label id="Message" runat="server" enableviewstate="False"></asp:Label>
		</form>
	</body>
</HTML>
