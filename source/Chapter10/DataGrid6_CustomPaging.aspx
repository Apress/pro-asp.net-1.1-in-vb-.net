<%@ Page Language = "vb" Codebehind="DataGrid6_CustomPaging.aspx.vb" AutoEventWireup="false" Inherits="Chapter10.DataGridCustomPaging" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataGridSimplePaging</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="Datagrid1" runat="server" DataKeyField="EmployeeID" AutoGenerateColumns="False"
				Width="100%" AllowSorting="True" AllowPaging="True" PageSize="3" PagerStyle-HorizontalAlign="Right"
				PagerStyle-PageButtonCount="4" PagerStyle-Mode="NumericPages" PagerStyle-BackColor="Beige"
				PagerStyle-ForeColor="Red" HeaderStyle-Font-Size="10" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Red"
				HeaderStyle-BackColor="Yellow" HeaderStyle-BorderColor="Red" HeaderStyle-BorderWidth="5" FooterStyle-BorderColor="Red"
				FooterStyle-BorderWidth="5" ItemStyle-BackColor="LightCyan" ItemStyle-ForeColor="DarkBlue"
				AlternatingItemStyle-BackColor="LightYellow" AlternatingItemStyle-ForeColor="Maroon" AlternatingItemStyle-Font-Italic="true"
				SelectedItemStyle-ForeColor="Yellow" SelectedItemStyle-BackColor="Red" SelectedItemStyle-Font-Bold="true"
				AllowCustomPaging="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="Yellow" BackColor="Red"></SelectedItemStyle>
				<AlternatingItemStyle Font-Italic="True" ForeColor="Maroon" BackColor="LightYellow"></AlternatingItemStyle>
				<ItemStyle ForeColor="DarkBlue" BackColor="LightCyan"></ItemStyle>
				<HeaderStyle Font-Size="10pt" Font-Bold="True" BorderWidth="5px" ForeColor="Red" BorderColor="Red"
					BackColor="Yellow"></HeaderStyle>
				<FooterStyle BorderWidth="5px" BorderColor="Red"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="EmployeeID" SortExpression="EmployeeID" HeaderText="ID" >
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
				<PagerStyle HorizontalAlign="Right" ForeColor="Red" BackColor="Beige" PageButtonCount="4" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
