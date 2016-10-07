<%@ Page Language = "vb" Codebehind="DataGrid7_Templates.aspx.vb" AutoEventWireup="false" Inherits="Chapter10.DataGridTemplates" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		
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
				ItemStyle-ForeColor="DarkBlue" AlternatingItemStyle-BackColor="LightYellow" AlternatingItemStyle-ForeColor="Maroon">
				<AlternatingItemStyle ForeColor="Maroon" BackColor="LightYellow"></AlternatingItemStyle>
				<ItemStyle ForeColor="DarkBlue" BackColor="LightCyan"></ItemStyle>
				<HeaderStyle Font-Size="10pt" Font-Bold="True" BorderWidth="5px" ForeColor="Red" BorderColor="Red"
					BackColor="Yellow"></HeaderStyle>
				<FooterStyle BorderWidth="5px" BorderColor="Red"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="EmployeeID" HeaderText="ID">
						<ItemStyle Width="30px"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="TitleOfCourtesy" HeaderText="Title">
						<ItemStyle Width="50px"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Name">
						<ItemTemplate>
							<b>
								<%# DataBinder.Eval(Container.DataItem, "LastName") %>
							</b>,
							<%# DataBinder.Eval(Container.DataItem, "FirstName") %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="City" HeaderText="City">
						<ItemStyle Width="150px"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="USA?">
						<ItemStyle HorizontalAlign="Center" Width="35px"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox runat="server" Enabled="false" Checked='<%# DataBinder.Eval(Container.DataItem, "Country").ToString() == "USA" %>' ID="Checkbox1"/>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
