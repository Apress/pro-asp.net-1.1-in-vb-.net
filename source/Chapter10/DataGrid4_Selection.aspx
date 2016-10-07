<%@ Page Language = "vb" Codebehind="DataGrid4_Selection.aspx.vb" AutoEventWireup="false" Inherits="Chapter10.DataGrid4" %>
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
				AlternatingItemStyle-Font-Italic="true" AllowSorting="True" DataKeyField="EmployeeID" SelectedItemStyle-ForeColor="Yellow"
				SelectedItemStyle-BackColor="Red" SelectedItemStyle-Font-Bold="true">
				<AlternatingItemStyle Font-Italic="True" ForeColor="Maroon" BackColor="LightYellow"></AlternatingItemStyle>
				<ItemStyle ForeColor="DarkBlue" BackColor="LightCyan"></ItemStyle>
				<HeaderStyle Font-Size="10pt" Font-Bold="True" BorderWidth="5px" ForeColor="Red" BorderColor="Red"
					BackColor="Yellow"></HeaderStyle>
				<FooterStyle BorderWidth="5px" BorderColor="Red"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="EmployeeID" SortExpression="EmployeeID" HeaderText="ID">
						<ItemStyle Width="30px"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="TitleOfCourtesy" SortExpression="TitleOfCourtesy" HeaderText="Title">
						<ItemStyle Width="50px"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="LastName" SortExpression="LastName" HeaderText="Last Name">
						<ItemStyle Width="150px"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="FirstName" SortExpression="FirstName" HeaderText="First Name"></asp:BoundColumn>
					<asp:ButtonColumn Text="&lt;img border=0 src=message.gif&gt;" CommandName="Select">
						<ItemStyle Width="20px"></ItemStyle>
					</asp:ButtonColumn>
				</Columns>
			</asp:DataGrid>
			<P>
				<asp:Label id="MoreInfo" runat="server"></asp:Label></P>
		</form>
	</body>
</HTML>
