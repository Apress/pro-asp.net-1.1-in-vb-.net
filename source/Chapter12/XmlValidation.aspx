<%@ Page Language = "vb" Codebehind="XmlValidation.aspx.vb" AutoEventWireup="false" Inherits="SimpleXML.XmlValidation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>XmlValidation</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<DIV style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; Z-INDEX: 105; LEFT: 16px; BORDER-LEFT: 2px groove; WIDTH: 576px; BORDER-BOTTOM: 2px groove; POSITION: absolute; TOP: 16px; HEIGHT: 87px; BACKGROUND-COLOR: lightyellow"
				ms_positioning="GridLayout">
				<asp:button id="cmdValidate" style="Z-INDEX: 100; LEFT: 361px; POSITION: absolute; TOP: 28px"
					runat="server" Text="Validate XML" Width="182px" Height="27px" Font-Size="Smaller" Font-Names="Tahoma"></asp:button>
				<asp:RadioButton id="optValid" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 16px" runat="server"
					Text="Use DvdList.xml" Width="264px" Height="16px" Font-Size="X-Small" Font-Names="Verdana" Checked="True"
					GroupName="Valid"></asp:RadioButton>
				<asp:RadioButton id="optInvalidData" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 40px"
					runat="server" Text="Use DvdListInvalid.xml" Width="264px" Height="16px" Font-Size="X-Small"
					Font-Names="Verdana" GroupName="Valid"></asp:RadioButton></DIV>
			<asp:Label id="lblStatus" style="Z-INDEX: 104; LEFT: 19px; POSITION: absolute; TOP: 132px"
				runat="server" Width="568px" Height="32px" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True"
				EnableViewState="False"></asp:Label>
		</form>
	</body>
</HTML>
