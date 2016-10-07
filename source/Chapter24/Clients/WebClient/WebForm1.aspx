<%@ Page Language = "vb" Codebehind="WebForm1.aspx.vb" AutoEventWireup="false" Inherits="WebClient.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form runat="server" ID="Form1">
			<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
				BackColor="White" CellPadding="4" Font-Names="Verdana" Font-Size="X-Small">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:DataGrid>
			<P>
				<asp:Button id="cmdGetData" runat="server" Text="Get Data"></asp:Button></P>
		</form>
	</body>
</HTML>
