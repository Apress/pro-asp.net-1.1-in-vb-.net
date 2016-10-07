<%@ Page Language = "vb" Codebehind="CacheCallbackTest.aspx.vb" AutoEventWireup="false" Inherits="Chapter07.CacheCallbackTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CacheCallbackTest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:button id="cmdCheck" style="Z-INDEX: 104; LEFT: 18px; POSITION: absolute; TOP: 16px" runat="server"
				Width="103px" Height="24px" Text="Check Items"></asp:button>
			<asp:button id="cmdRemove" style="Z-INDEX: 103; LEFT: 136px; POSITION: absolute; TOP: 16px"
				runat="server" Width="135px" Height="24px" Text="Remove One Item"></asp:button>
			<asp:label id="lblInfo" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 72px" runat="server"
				Width="480px" Height="192px" Font-Names="Verdana" Font-Size="X-Small" BorderWidth="2px"
				BorderStyle="Groove" BackColor="LightYellow"></asp:label>
		</form>
	</body>
</HTML>
