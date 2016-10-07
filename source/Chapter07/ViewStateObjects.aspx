<%@ Page Language = "vb" Codebehind="ViewStateObjects.aspx.vb" AutoEventWireup="false" Inherits="Chapter05.ViewStateObjects" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
	</HEAD>
	<body>
		<form method="post" runat="server" ID="FormValidators">
			<asp:table runat="server" ID="Table1" Width="404px" Height="262px">
				<asp:TableRow>
					<asp:TableCell Width="50px" Text="Description" Font-Bold="true" ForeColor="blue" />
					<asp:TableCell Width="200px" Text="Value" Font-Bold="true" ForeColor="blue" />
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell Text="Name:" />
					<asp:TableCell>
						<asp:TextBox runat="server" Width="200px" ID="Name" />
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell Text="ID:" />
					<asp:TableCell>
						<asp:TextBox runat="server" Width="200px" ID="EmpID" />
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell Text="Age:" />
					<asp:TableCell>
						<asp:TextBox runat="server" Width="200px" ID="Age" />
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell Text="E-mail:" />
					<asp:TableCell>
						<asp:TextBox runat="server" Width="200px" ID="Email" />
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell Text="Password:" />
					<asp:TableCell>
						<asp:TextBox TextMode="Password" runat="server" Width="200px" ID="Password" />
					</asp:TableCell>
				</asp:TableRow>
			</asp:table><BR>
			<asp:Button runat="server" Text="Save" ID="cmdSave" />&nbsp;
			<asp:Button id="cmdDisplay" runat="server" Text="Display"></asp:Button><BR>
			<BR>
			<asp:Label id="lblResults" runat="server" Font-Bold="True"></asp:Label>
			<br>
			<br>
			<br>
			<br>
			<br>
			<br>
		</form>
	</body>
</HTML>
