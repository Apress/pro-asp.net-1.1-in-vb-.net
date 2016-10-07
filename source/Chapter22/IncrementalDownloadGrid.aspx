<%@ Page Language = "vb" Codebehind="IncrementalDownloadGrid.aspx.vb" AutoEventWireup="false" Inherits="Chapter22.IncrementalDownloadGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cart</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderColor="#CC9966"
				BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" Font-Names="Verdana" Width="100%"
				Font-Size="X-Small">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="Title" HeaderText="Title"></asp:BoundColumn>
					<asp:BoundColumn DataField="isbn" HeaderText="ISBN"></asp:BoundColumn>
					<asp:BoundColumn DataField="Publisher" HeaderText="Publisher"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderTemplate>
							Book Cover
						</HeaderTemplate>
						<ItemTemplate>
							<img src="UnknownBook.gif"
				  	   onerror="javascript:this.src='Unknownbook.gif'"
			           onload="javascript:this.src='GetBookImage.aspx?isbn=<%# DataBinder.Eval(Container.DataItem, "isbn") %>';">
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:DataGrid><br>
			<br>
		</form>
	</body>
</HTML>
