<%@ Page Language = "vb" Codebehind="SoapSecurityTest.aspx.vb" AutoEventWireup="false" Inherits="SecurityTest.SoapSecurityTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label2" style="Z-INDEX: 105; LEFT: 21px; POSITION: absolute; TOP: 51px" runat="server">Password:</asp:label><asp:label id="Label1" style="Z-INDEX: 104; LEFT: 20px; POSITION: absolute; TOP: 18px" runat="server">User Name:</asp:label>
			<asp:TextBox id="txtPassword" style="Z-INDEX: 103; LEFT: 108px; POSITION: absolute; TOP: 48px"
				runat="server" Width="155px" TextMode="Password"></asp:TextBox>
			<asp:TextBox id="txtUserName" style="Z-INDEX: 102; LEFT: 108px; POSITION: absolute; TOP: 18px"
				runat="server"></asp:TextBox>
			<asp:Button id="cmdCall" style="Z-INDEX: 101; LEFT: 22px; POSITION: absolute; TOP: 99px" runat="server"
				Width="112px" Text="Call Method"></asp:Button>
			<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
				BackColor="White" CellPadding="4" Font-Names="Verdana" Font-Size="X-Small" style="Z-INDEX: 106; LEFT: 22px; POSITION: absolute; TOP: 169px">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:DataGrid>
			<asp:Label id="lblInfo" style="Z-INDEX: 107; LEFT: 22px; POSITION: absolute; TOP: 140px" runat="server"
				Width="457px" Height="23px">Use name: <b>dan</b>  password: <b>secret</b></asp:Label></form>
	</body>
</HTML>
