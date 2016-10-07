<%@ Page Language = "vb" Codebehind="DataGrid1.aspx.vb" AutoEventWireup="false" Inherits="Chapter10.DataGrid1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataGrid1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="Datagrid1" runat="server" AutoGenerateColumns="False" Width="100%" HeaderStyle-Font-Size="10"
				HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Red" HeaderStyle-BackColor="Yellow" HeaderStyle-BorderColor="Red"
				HeaderStyle-BorderWidth="5" FooterStyle-BorderColor="Red" FooterStyle-BorderWidth="5" ItemStyle-BackColor="LightCyan"
				ItemStyle-ForeColor="DarkBlue" AlternatingItemStyle-BackColor="LightYellow" AlternatingItemStyle-ForeColor="Maroon"
				AlternatingItemStyle-Font-Italic="true">
				<Columns>
					<asp:BoundColumn HeaderText="ID" ItemStyle-Width="30px" DataField="EmployeeID" />
					<asp:BoundColumn HeaderText="Title" ItemStyle-Width="50px" DataField="TitleOfCourtesy" />
					<asp:BoundColumn HeaderText="Last Name" ItemStyle-Width="150px" DataField="LastName" />
					<asp:BoundColumn HeaderText="First Name" DataField="FirstName" />
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
