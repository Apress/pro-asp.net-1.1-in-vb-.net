<%@ Page Language = "vb" Codebehind="SingleValueBinding.aspx.vb" AutoEventWireup="false" Inherits="Chapter10.SingleValueBinding" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SingleValueBinding</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Image runat="server" ImageUrl='<%# FilePath %>' ID="Image1"/><br>
			<asp:Label runat="server" Text='<%# FilePath %>' ID="Label1"/><br>
			<asp:TextBox runat="server" Text='<%# GetFilePath() %>' ID="Textbox1"/><br>
			<asp:HyperLink runat="server" NavigateUrl='<%# LogoPath.Value %>' 
        Font-Bold="True" Text="Show logo" ID="Hyperlink1"/><br>
			<input type="hidden" runat="server" ID="LogoPath" value="apress.gif" NAME="LogoPath">
			<b>
				<%# FilePath %>
			</b>
			<br>
			<img src="<%# GetFilePath() %>">
		</form>
	</body>
</HTML>
