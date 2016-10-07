<%@ Page Language = "vb" Codebehind="CreateChart.aspx.vb" AutoEventWireup="false" Inherits="Chapter23.CreateChart" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CreateChart</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Image id="Image1" style="Z-INDEX: 101; LEFT: 19px; POSITION: absolute; TOP: 152px" runat="server"
				BorderStyle="Ridge" BorderWidth="2px" ImageUrl="DynamicChart.aspx"></asp:Image>
			<DIV style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; Z-INDEX: 102; LEFT: 20px; BORDER-LEFT: 2px groove; WIDTH: 476px; BORDER-BOTTOM: 2px groove; POSITION: absolute; TOP: 16px; HEIGHT: 121px"
				ms_positioning="GridLayout">
				<asp:ListBox id="lstPieSlices" style="Z-INDEX: 100; LEFT: 248px; POSITION: absolute; TOP: 12px"
					runat="server" Width="200px" Height="92px"></asp:ListBox>
				<asp:Button id="cmdAdd" style="Z-INDEX: 101; LEFT: 84px; POSITION: absolute; TOP: 64px" runat="server"
					Text="Add Data Slice" Width="137px" Height="24px"></asp:Button>
				<asp:TextBox id="txtLabel" style="Z-INDEX: 103; LEFT: 72px; POSITION: absolute; TOP: 12px" runat="server"
					Width="149px" Height="20px">Slice</asp:TextBox>
				<asp:TextBox id="txtValue" style="Z-INDEX: 104; LEFT: 72px; POSITION: absolute; TOP: 36px" runat="server"
					Width="149px" Height="20px">100</asp:TextBox>
				<asp:Label id="Label1" style="Z-INDEX: 106; LEFT: 12px; POSITION: absolute; TOP: 16px" runat="server"
					Width="48px" Height="16px" Font-Names="Arial" Font-Size="X-Small">Label:</asp:Label>
				<asp:Label id="Label2" style="Z-INDEX: 107; LEFT: 12px; POSITION: absolute; TOP: 40px" runat="server"
					Width="52px" Height="16px" Font-Names="Arial" Font-Size="X-Small">Value:</asp:Label></DIV>
		</form>
	</body>
</HTML>
