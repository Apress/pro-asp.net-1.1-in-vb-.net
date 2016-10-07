<%@ Register TagPrefix="apress" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControlsLibrary" %>
<%@ Page Language = "vb" Codebehind="StyledRepeaterHost.aspx.vb" AutoEventWireup="false" Inherits="Chapter20.StyledRepeaterHost" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>StyledRepeaterHost</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="StyledRepeaterHost" method="post" runat="server">
			<apress:simplestyledrepeater id="repeater" runat="server" Height="278px" Width="363px" repeatcount="10">
				<AlternatingItemStyle Font-Bold="True" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" BackColor="Red"></AlternatingItemStyle>
				<HeaderStyle Font-Italic="True" BackColor="#FFFFC0"></HeaderStyle>
				<AlternatingItemTemplate>
						Item
						<%# Container.Index %>
						of
						<%# Container.Total%>
				</AlternatingItemTemplate>
				<ItemTemplate>
						<hr>
						Item
						<%# Container.Index %>
						of
						<%# Container.Total%>
						<br>
						<hr>
				</ItemTemplate>
				<HeaderTemplate>
  Now showing <%# Container.Total %> Items for your viewing pleasure.<br>
 
</HeaderTemplate>
			</apress:simplestyledrepeater></form>
	</body>
</HTML>
