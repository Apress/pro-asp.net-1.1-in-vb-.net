<%@ Page Language = "vb" Codebehind="DataGrid5_SimplePaging.aspx.vb" AutoEventWireup="false" Inherits="Chapter10.DataGridSimplePaging" %>
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
				Width="100%" AllowSorting="true" AllowPaging="true" PageSize="3" PagerStyle-HorizontalAlign="Right"
				PagerStyle-PageButtonCount="4" PagerStyle-Mode="NumericPages" PagerStyle-BackColor="Beige"
				PagerStyle-ForeColor="Red" HeaderStyle-Font-Size="10" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Red"
				HeaderStyle-BackColor="Yellow" HeaderStyle-BorderColor="Red" HeaderStyle-BorderWidth="5" FooterStyle-BorderColor="Red"
				FooterStyle-BorderWidth="5" ItemStyle-BackColor="LightCyan" ItemStyle-ForeColor="DarkBlue"
				AlternatingItemStyle-BackColor="LightYellow" AlternatingItemStyle-ForeColor="Maroon" AlternatingItemStyle-Font-Italic="true"
				SelectedItemStyle-ForeColor="Yellow" SelectedItemStyle-BackColor="Red" SelectedItemStyle-Font-Bold="true">
				<Columns>
					<asp:BoundColumn HeaderText="ID" ItemStyle-Width="30px" DataField="EmployeeID" SortExpression="EmployeeID" />
					<asp:BoundColumn HeaderText="Title" ItemStyle-Width="50px" DataField="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
					<asp:BoundColumn HeaderText="Last Name" ItemStyle-Width="150px" DataField="LastName" SortExpression="LastName" />
					<asp:BoundColumn HeaderText="First Name" DataField="FirstName" SortExpression="FirstName" />
					<asp:ButtonColumn CommandName="Select" ItemStyle-Width="20px" Text="<img border=0 src=message.gif>" />
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
