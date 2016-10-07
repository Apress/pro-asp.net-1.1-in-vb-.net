<%@ Register TagPrefix="apress" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControlsLibrary" %>
<%@ Page Language = "vb" AutoEventWireup="false" CodeBehind="SimpleRepeaterHost2.aspx.vb" Inherits="Chapter21.SimpleRepeaterHost2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SimpleRepeater2Host</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="SimpleRepeater2Host" method="post" runat="server">
			<apress:SuperSimpleRepeater2 id="SuperSimpleRepeater21" style="Z-INDEX: 101; LEFT: 19px; POSITION: absolute; TOP: 18px"
				runat="server" RepeatCount="10">
				<ItemTemplate>
					<div align="center">
						<hr>
						Item
						<%# Container.Index %>
						of
						<%# Container.Total%>
						<br>
						<hr>
					</div>
				</ItemTemplate>
				<HeaderTemplate>
  <h2 style="Color:Red">Super Simple Repeater Strikes Again!</h2>
  Now showing <%# Container.Total %> Items for your viewing pleasure.
 
</HeaderTemplate>
				<AlternatingItemTemplate>
					<div align="center" style="border-right: fuchsia double; border-top: fuchsia double; border-left: fuchsia double; border-bottom: fuchsia double">
						Item
						<%# Container.Index %>
						of
						<%# Container.Total%>
					</div>
				</AlternatingItemTemplate>
				<FooterTemplate>
					<i>This presentation of the Simple Repeater Control brought to you by the letter <b>W</b></i>
				</FooterTemplate>
			</apress:SuperSimpleRepeater2>&nbsp;
		</form>
	</body>
</HTML>
