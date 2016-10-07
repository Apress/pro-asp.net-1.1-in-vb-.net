<%@ Page Language = "vb" Codebehind="UserLoggerSerialization.aspx.vb" AutoEventWireup="false" Inherits="Chapter13.UserLoggerSerialization" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UserLogger</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblInfo" style="Z-INDEX: 101; LEFT: 20px; POSITION: absolute; TOP: 51px" runat="server"
				Height="237px" Width="418px" BorderStyle="Dotted" EnableViewState="False" BorderWidth="1px"
				BackColor="Linen"></asp:Label>
			<asp:Button id="Button1" style="Z-INDEX: 104; LEFT: 20px; POSITION: absolute; TOP: 18px" runat="server"
				Height="22px" Width="90px" Text="Post Back"></asp:Button>
			<asp:Button id="cmdDelete" style="Z-INDEX: 103; LEFT: 215px; POSITION: absolute; TOP: 17px"
				runat="server" Height="22px" Width="90px" Text="Delete Log"></asp:Button>
			<asp:Button id="cmdRead" style="Z-INDEX: 102; LEFT: 117px; POSITION: absolute; TOP: 17px" runat="server"
				Height="22px" Width="90px" Text="Read Log"></asp:Button>
		</form>
	</body>
</HTML>
