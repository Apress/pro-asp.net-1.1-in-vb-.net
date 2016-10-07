<%@ Page Language = "vb" AutoEventWireup="false" CodeBehind="SimpleRepeaterHost.aspx.vb" Inherits="Chapter20.SimpleRepeaterHost" %>
<%@ Register TagPrefix="apress" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControlsLibrary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SimpleRepeaterHost</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="SimpleRepeaterHost" method="post" runat="server">
			<apress:SuperSimpleRepeater id="sample" runat="server" RepeatCount="10">
				<ItemTemplate>
					<div align="center">
						<hr>
						Creating templated controls is <b>easy</b> and <i>fun</i>.<br>
						<hr>
					</div>
				</ItemTemplate>
			</apress:SuperSimpleRepeater>
		</form>
	</body>
</HTML>
