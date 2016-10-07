<%@ Page Language = "vb" Codebehind="LoginNoCookie.aspx.vb" AutoEventWireup="false" Inherits="Chapter15.LoginNoCookie" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Login</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<DIV style="BORDER-RIGHT: 2px groove; PADDING-RIGHT: 10px; BORDER-TOP: 2px groove; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; BORDER-LEFT: 2px groove; WIDTH: 352px; PADDING-TOP: 10px; BORDER-BOTTOM: 2px groove; FONT-FAMILY: Verdana; HEIGHT: 186px"
				ms_positioning="FlowLayout">
				<P>
					<asp:Label id="Label1" runat="server" Width="89px" Font-Size="X-Small">Name:</asp:Label>
					<asp:TextBox id="txtName" runat="server" Width="152px"></asp:TextBox><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Font-Size="X-Small" ErrorMessage="Contains invalid characters."
						ControlToValidate="txtName" ValidationExpression="[a-z|A-Z|0-9]*" Display="Dynamic"></asp:RegularExpressionValidator>
					<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Font-Size="X-Small" ErrorMessage="Required."
						ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator><BR>
					<asp:Label id="Label2" runat="server" Width="89px" Font-Size="X-Small">Password:</asp:Label>
					<asp:TextBox id="txtPassword" runat="server" Width="152px" TextMode="Password"></asp:TextBox><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" Font-Size="X-Small" ErrorMessage="Contains invalid characters."
						ControlToValidate="txtPassword" ValidationExpression="[a-z|A-Z|0-9|!?$%&amp;*@?]*" Display="Dynamic"></asp:RegularExpressionValidator>
					<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Font-Size="X-Small" ErrorMessage="Required."
						ControlToValidate="txtPassword" Display="Dynamic"></asp:RequiredFieldValidator></P>
				<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Button id="cmdLogin" runat="server" Width="113px" Text="Login"></asp:Button></P>
				<P>
					<asp:Label id="lblStatus" runat="server" Width="291px" ForeColor="#C00000" Height="11px" Font-Size="X-Small"></asp:Label></P>
			</DIV>
			<P>&nbsp;</P>
			<P>
				<asp:Label id="Label3" runat="server" Width="376px" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"> Acounts are dan/secret and jenny/opensesame</asp:Label></P>
		</form>
	</body>
</HTML>
