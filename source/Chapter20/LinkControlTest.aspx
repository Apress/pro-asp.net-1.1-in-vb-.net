<%@ Page Language = "vb" Codebehind="LinkControlTest.aspx.vb" AutoEventWireup="false" Inherits="CustomServerControls.LinkControlTest" %>
<%@ Register TagPrefix="cc1" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControlsLibrary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LinkControlTest</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P><cc1:linkwebcontrol id="LinkWebControl1" runat="server" Text="Click to visit Apress" ForeColor="#C00000"
					Font-Size="Large" Font-Names="Verdana" BackColor="#FFFF80"></cc1:linkwebcontrol></P>
			<P>&nbsp;</P>
			<P><asp:label id="lblHtml" runat="server"></asp:label></P>
		</form>
	</body>
</HTML>
