<%@ Register TagPrefix="apress" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControlsLibrary" %>
<%@ Page Language = "vb" Codebehind="RichLabelTest.aspx.vb" AutoEventWireup="false" Inherits="Chapter21.XmlLabelTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>XmlLabelTest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<apress:RichLabel id="RichLabel1" runat="server" Height="144px" Width="382px" BackColor="#C3C8D2">
				<Format Type="Xml" HighlightTag="i"></Format>
			</apress:RichLabel>&nbsp;
		</form>
	</body>
</HTML>
