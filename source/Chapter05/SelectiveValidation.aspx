<%@ Page Language = "vb" Codebehind="SelectiveValidation.aspx.vb" AutoEventWireup="false" Inherits="Recipe07_10.SelectiveValidation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SelectiveValidation</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 100; LEFT: 27px; POSITION: absolute; TOP: 24px" runat="server"
				Width="174px" Height="20px" Font-Names="Verdana" Font-Size="X-Small">A number less than 120:</asp:Label>
			<asp:RegularExpressionValidator id="RegularExpressionValidator2" style="Z-INDEX: 109; LEFT: 444px; POSITION: absolute; TOP: 64px"
				runat="server" Height="20px" Width="28px" EnableClientScript="False" ControlToValidate="txtEmail" ValidationExpression=".+@."
				ErrorMessage="Not a valid email address">*</asp:RegularExpressionValidator>
			<asp:Label id="lblCustomSummary" style="Z-INDEX: 104; LEFT: 18px; POSITION: absolute; TOP: 170px"
				runat="server" Width="497px" Height="142px" Font-Names="Verdana" Font-Size="X-Small"></asp:Label>
			<asp:TextBox id="txtEmail" style="Z-INDEX: 103; LEFT: 195px; POSITION: absolute; TOP: 57px" runat="server"
				Width="240px" Height="28px"></asp:TextBox>
			<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 29px; POSITION: absolute; TOP: 63px" runat="server"
				Width="174px" Height="20px" Font-Names="Verdana" Font-Size="X-Small">An email address:</asp:Label>
			<asp:TextBox id="txtNumber" style="Z-INDEX: 101; LEFT: 196px; POSITION: absolute; TOP: 17px"
				runat="server" Width="240px" Height="28px"></asp:TextBox>
			<asp:RangeValidator id="RangeValidator1" style="Z-INDEX: 107; LEFT: 445px; POSITION: absolute; TOP: 25px"
				runat="server" Width="135px" Height="20px" ErrorMessage="Value out of range" MaximumValue="119"
				MinimumValue="0" ControlToValidate="txtNumber" EnableClientScript="False" Type="Integer">*</asp:RangeValidator>
			<asp:Button id="cmdValidate" style="Z-INDEX: 108; LEFT: 196px; POSITION: absolute; TOP: 107px"
				runat="server" Width="89px" Height="26px" Text="Validate"></asp:Button>
		</form>
	</body>
</HTML>
