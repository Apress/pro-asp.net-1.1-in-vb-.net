<%@ Register TagPrefix="cc1" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControlsLibrary" %>
<%@ Page Language = "vb" Codebehind="RolloverTest.aspx.vb" AutoEventWireup="false" Inherits="Chapter22.RolloverTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RolloverTest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<cc1:RollOverButton id="RollOverButton1" style="Z-INDEX: 100; LEFT: 22px; POSITION: absolute; TOP: 22px"
				runat="server" Width="134px" Height="36px" MouseOverImageUrl="buttonMouseOver.jpg" ImageUrl="buttonOriginal.jpg"></cc1:RollOverButton>
			<cc1:RollOverButton id="RollOverButton2" style="Z-INDEX: 101; LEFT: 21px; POSITION: absolute; TOP: 63px"
				runat="server" Width="134px" Height="36px" MouseOverImageUrl="buttonMouseOver.jpg" ImageUrl="buttonOriginal.jpg"></cc1:RollOverButton>&nbsp;
		</form>
	</body>
</HTML>
