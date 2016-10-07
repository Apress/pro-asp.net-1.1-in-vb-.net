<%@ Page Language = "vb" Codebehind="GetSetCreditCardNumber.aspx.vb" AutoEventWireup="false" Inherits="Chapter18.GetSetCreditCardNumber" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GetSetCreditCardNumber</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<DIV style="BORDER-RIGHT: 2px groove; PADDING-RIGHT: 10px; BORDER-TOP: 2px groove; PADDING-LEFT: 10px; Z-INDEX: 104; LEFT: 26px; PADDING-BOTTOM: 10px; BORDER-LEFT: 2px groove; WIDTH: 352px; PADDING-TOP: 10px; BORDER-BOTTOM: 2px groove; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 22px; HEIGHT: 151px"
				ms_positioning="FlowLayout">
				<P>
					<asp:Label id="Label1" runat="server" Font-Size="X-Small">Credit Card Number:</asp:Label>&nbsp;&nbsp;
					<asp:TextBox id="txtCreditCard" runat="server" MaxLength="15"></asp:TextBox><BR>
					<BR>
					<BR>
					<asp:Button id="cmdGet" runat="server" Width="170px" Text="Retrieve From Database"></asp:Button>
					<asp:Button id="cmdSet" runat="server" Text="Update Database" Width="171px"></asp:Button>&nbsp;
				</P>
			</DIV>
		</form>
	</body>
</HTML>
