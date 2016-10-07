<%@ Page Language = "vb" Codebehind="TitledTextBoxTest.aspx.vb" AutoEventWireup="false" Inherits="Chapter20.TitledTextBoxTest" %>
<%@ Register TagPrefix="cc1" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControlsLibrary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TitledTextBoxTest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<cc1:TitledTextBox id="TitledTextBox1" title="Name" style="Z-INDEX: 101; LEFT: 20px; POSITION: absolute; TOP: 19px"
				runat="server" Width="253px" Height="39px" Text="[Enter Text Here]"></cc1:TitledTextBox>
			<asp:Label id="lblInfo" style="Z-INDEX: 102; LEFT: 21px; POSITION: absolute; TOP: 81px" runat="server"
				Width="262px" Height="29px" EnableViewState="False"></asp:Label>
			<asp:Button id="Button1" style="Z-INDEX: 103; LEFT: 287px; POSITION: absolute; TOP: 20px" runat="server"
				Width="87px" Height="25px" Text="Submit"></asp:Button>
		</form>
	</body>
</HTML>
