<%@ Page Language = "vb" Codebehind="DynamicButton.aspx.vb" AutoEventWireup="false" Inherits="Chapter04.DynamicButton" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DynamicButton</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="Panel1" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 32px" runat="server"
				Width="364px" Height="142px">
				<P>
					<asp:Label id="Label1" runat="server">(No value.)</asp:Label></P>
				<P>
					<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder>
					<asp:Button id="cmdReset" runat="server" Width="112px" Text="Reset Text"></asp:Button><BR>
					<HR>
					<asp:Button id="cmdCreate" runat="server" Width="137px" Text="Create Button"></asp:Button>
					<asp:Button id="cmdRemove" runat="server" Width="141px" Text="Remove Button"></asp:Button>
				<P></P>
			</asp:Panel>
		</form>
	</body>
</HTML>
