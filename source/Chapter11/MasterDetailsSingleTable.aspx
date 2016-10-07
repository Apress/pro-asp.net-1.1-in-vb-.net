<%@ Page Language = "vb" Codebehind="MasterDetailsSingleTable.aspx.vb" AutoEventWireup="false" Inherits="Chapter11.MasterDetailsSingleTable" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MasterDetailsSingleTable</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="gridMaster" runat="server" GridLines="None" BorderWidth="1px" BorderColor="Tan"
				Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
				ForeColor="Black" DataKeyField="CategoryID" Font-Size="X-Small">
				<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="PaleGoldenrod"></AlternatingItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" BackColor="Tan"></HeaderStyle>
				<FooterStyle BackColor="Tan"></FooterStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="Category">
						<ItemStyle VerticalAlign="Top" Width="20%"></ItemStyle>
						<ItemTemplate>
							<br>
							<b>
								<%# DataBinder.Eval(Container.DataItem, "CategoryName") %>
							</b>
							<br>
							<br>
							<%# DataBinder.Eval(Container.DataItem, "Description" ) %>
							<br>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Products">
						<ItemStyle VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:DataGrid id="DataGrid2" runat="server" Font-Size="XX-Small" BackColor="White" AutoGenerateColumns="False"
								CellPadding="4" BorderColor="#CC9966" BorderWidth="1px" Width="100%" BorderStyle="None">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
								<Columns>
									<asp:BoundColumn DataField="ProductName" HeaderText="Product Name">
									<ItemStyle Width="250px" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}"></asp:BoundColumn>
								</Columns>
							</asp:DataGrid>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
			</asp:datagrid>
		</form>
	</body>
</HTML>
