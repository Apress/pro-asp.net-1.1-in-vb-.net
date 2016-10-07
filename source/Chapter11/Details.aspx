<%@ Page Language = "vb" Codebehind="Details.aspx.vb" AutoEventWireup="false" Inherits="Chapter11.Details" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Details</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="gridDetails" runat="server" DataKeyField="ProductID" Font-Size="XX-Small" Font-Names="Verdana"
				CellPadding="4" BackColor="Bisque" BorderWidth="1px" BorderStyle="Solid" BorderColor="#CC9966"
				AutoGenerateColumns="False" GridLines="None" Width="316px" ShowFooter="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<ItemStyle BorderWidth="0px" ForeColor="#330099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#804000" BackColor="Bisque"></HeaderStyle>
				<FooterStyle Font-Bold="True" ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:ButtonColumn DataTextField="ProductID" HeaderText="Product ID" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="ProductName" HeaderText="Product Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:DataGrid>&nbsp;
			<asp:DataList id="listDetail" style="Z-INDEX: 102; LEFT: 345px; POSITION: absolute; TOP: 16px"
				runat="server" CellPadding="10" BackColor="WhiteSmoke" BorderWidth="5px" BorderStyle="None"
				BorderColor="#CC9966" GridLines="Both" Font-Size="XX-Small" Font-Names="Verdana" Width="291px">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="#330099" BackColor="WhiteSmoke"></ItemStyle>
				<ItemTemplate>
					<b>
						<%# DataBinder.Eval(Container.DataItem, "ProductName") %>
					</b>
					<br>
					<br>
					<i>
						<%# DataBinder.Eval(Container.DataItem, "QuantityPerUnit") %>
					</i>
					<hr>
					There are <b>
						<%# DataBinder.Eval(Container.DataItem, "UnitsInStock") %>
					</b>units that are currently in stock.
					<br>
					There are <b>
						<%# DataBinder.Eval(Container.DataItem, "UnitsOnOrder") %>
					</b>units that are currently on order.
					<br>
					The reorder level for this product is <b>
						<%# DataBinder.Eval(Container.DataItem, "ReorderLevel") %>
					</b>
					<br>
					<br>
				</ItemTemplate>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
			</asp:DataList></form>
	</body>
</HTML>
