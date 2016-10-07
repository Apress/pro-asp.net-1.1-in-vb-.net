<%@ Page Language = "vb" Codebehind="ShoppingCart.aspx.vb" AutoEventWireup="false" Inherits="Chapter11.MultipleSelection" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MultipleSelection</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Label id="Label2" runat="server" Font-Names="Verdana" Font-Bold="True">Shopping Cart:</asp:Label></P>
			<asp:DataGrid id="gridCart" runat="server" AutoGenerateColumns="False" GridLines="Vertical" BorderColor="#CC9966"
				BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" Font-Names="Verdana"
				Font-Size="XX-Small">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<ItemStyle ForeColor="#330099" BorderStyle="None" BorderColor="White" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
				<FooterStyle Height="2px" ForeColor="#330099" BackColor="Bisque"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="ProductID" HeaderText="ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="ProductName" HeaderText="Product Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Units">
						<HeaderStyle Width="5px"></HeaderStyle>
						<ItemTemplate>
							<asp:TextBox runat="server" Font-Size="XX-Small" Width="31px" Text='<%# DataBinder.Eval(Container, "DataItem.Units") %>'>
							</asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Total" HeaderText="Total" DataFormatString="{0:C}"></asp:BoundColumn>
					<asp:ButtonColumn Text="Update"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:DataGrid>
			<P>
				<asp:Label id="Label1" runat="server" Font-Names="Verdana" Font-Bold="True">Product List:</asp:Label></P>
			<asp:DataGrid id="gridProducts" runat="server" Font-Size="XX-Small" Font-Names="Verdana" CellPadding="4"
				BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" DataKeyField="ProductID"
				GridLines="Vertical" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<ItemStyle ForeColor="#330099" BorderStyle="None" BorderColor="White" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
				<FooterStyle Height="2px" ForeColor="#330099" BackColor="Bisque"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="ProductID" HeaderText="ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="ProductName" HeaderText="Product Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}"></asp:BoundColumn>
					<asp:ButtonColumn Text="Add..." CommandName="Select"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
