<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm2.aspx.vb" Inherits="WebForm2"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:CheckBox id="CheckBox1" style="Z-INDEX: 101; LEFT: 232px; POSITION: absolute; TOP: 408px"
				runat="server"></asp:CheckBox>
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 102; LEFT: 424px; POSITION: absolute; TOP: 216px"
				runat="server" AutoGenerateColumns="False" Width="152px" Height="104px">
				<Columns>
					<asp:HyperLinkColumn HeaderText="Test" FooterText="Test"></asp:HyperLinkColumn>
				</Columns>
			</asp:DataGrid><INPUT id="Text1" style="Z-INDEX: 103; LEFT: 336px; POSITION: absolute; TOP: 144px" type="text"
				name="Text1" runat="server"> <INPUT id="Button1" style="Z-INDEX: 104; LEFT: 344px; POSITION: absolute; TOP: 312px" dataSrc="f"
				type="button" value="Button" name="Button1" runat="server">
			<asp:Button id="Button2" style="Z-INDEX: 105; LEFT: 296px; POSITION: absolute; TOP: 256px" runat="server"
				Text="Button" ForeColor="#FF8080"></asp:Button>
			<asp:ListBox id="ListBox1" style="Z-INDEX: 106; LEFT: 240px; POSITION: absolute; TOP: 312px"
				runat="server" ForeColor="Red">
				<asp:ListItem Value="1">1</asp:ListItem>
				<asp:ListItem Value="2">2</asp:ListItem>
			</asp:ListBox></form>
	</body>
</HTML>
