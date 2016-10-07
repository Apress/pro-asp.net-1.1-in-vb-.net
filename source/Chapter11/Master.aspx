<%@ Page Language = "vb" Codebehind="Master.aspx.vb" AutoEventWireup="false" Inherits="Chapter11.Master" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Master</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="gridMaster" runat="server" Font-Size="XX-Small" Font-Names="Verdana" CellPadding="4"
				BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" DataKeyField="CategoryID"
				GridLines="Vertical" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<ItemStyle ForeColor="#330099" BorderStyle="None" BorderColor="White" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
				<FooterStyle Height="2px" ForeColor="#330099" BackColor="Bisque"></FooterStyle>
				<Columns>
					<asp:ButtonColumn Text="&gt;" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="CategoryName" HeaderText="Category Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="Description" HeaderText="Description"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:DataGrid>&nbsp;
		</form>
	</body>
</HTML>
