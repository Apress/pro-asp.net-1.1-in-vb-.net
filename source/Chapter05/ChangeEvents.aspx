<%@ Page Language = "vb" Codebehind="ChangeEvents.aspx.vb" AutoEventWireup="false" Inherits="Chapter05.ChangeEvents" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChangeEvents</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<select runat="server" ID="List1" size="5" multiple Name="List1">
				<option>Option 1</option>
				<option>Option 2</option>
			</select>
			<br>
			<input type="text" runat="server" ID="Textbox1" Size="10" Name="Textbox1"><br>
			<input type="checkbox" runat="server" ID="Checkbox1" Name="Checkbox1">Option 
			text<br>
			<input type="submit" runat="server" ID="Submit1" Name="cmdSubmit" value="Submit Query">
		</form>
	</body>
</HTML>
