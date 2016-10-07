<%@ Page Language = "vb" Codebehind="AdTest.aspx.vb" AutoEventWireup="false" Inherits="Chapter05.AdTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdTest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:AdRotator id="AdRotator1" style="Z-INDEX: 101; LEFT: 18px; POSITION: absolute; TOP: 14px"
				runat="server" Target="_blank" AdvertisementFile="ads.xml"></asp:AdRotator>
			<asp:HyperLink id="lnkBanner" style="Z-INDEX: 103; LEFT: 25px; POSITION: absolute; TOP: 159px"
				runat="server">HyperLink</asp:HyperLink>
		</form>
	</body>
</HTML>
