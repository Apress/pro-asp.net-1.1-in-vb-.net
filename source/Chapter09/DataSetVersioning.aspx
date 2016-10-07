<%@ Import Namespace="System.Data" %>
<%@ Page Language = "vb" Codebehind="DataSetVersioning.aspx.vb" AutoEventWireup="false" Inherits="Chapter09.DataSetVersioning" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataSetVersioning</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM id="Form2" method="post" runat="server">
			<B><U>Original rows</U></B><BR>
			<BR>
			<asp:DataGrid id="Datagrid1" runat="server" HeaderStyle-Font-Bold="true">
				<HeaderStyle Font-Bold="True"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="State">
						<ItemTemplate>
							<%# ((DataRowView)Container.DataItem).Row.RowState.ToString() %>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid><BR>
			<STRONG><U>New version</U></STRONG><BR>
			<BR>
			<asp:DataGrid id="Datagrid2" runat="server" HeaderStyle-Font-Bold="true">
				<Columns>
					<asp:TemplateColumn HeaderText="State">
						<ItemTemplate>
							<%# ((DataRowView)Container.DataItem).Row.RowState.ToString() %>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid><BR>
			<STRONG><U>Added rows</U></STRONG><BR>
			<BR>
			<asp:DataGrid id="Datagrid3" runat="server" HeaderStyle-Font-Bold="true">
				<Columns>
					<asp:TemplateColumn HeaderText="State">
						<ItemTemplate>
							<%# ((DataRowView)Container.DataItem).Row.RowState.ToString() %>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid><BR>
			<STRONG><U>Deleted rows</U></STRONG><BR>
			<BR>
			<asp:DataGrid id="Datagrid4" runat="server" HeaderStyle-Font-Bold="true">
				<Columns>
					<asp:TemplateColumn HeaderText="State">
						<ItemTemplate>
							<%# ((DataRowView)Container.DataItem).Row.RowState.ToString() %>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid><BR>
			<STRONG><U>Original data in edited rows</U></STRONG><BR>
			<BR>
			<asp:DataGrid id="Datagrid5" runat="server" HeaderStyle-Font-Bold="true">
				<Columns>
					<asp:TemplateColumn HeaderText="State">
						<ItemTemplate>
							<%# ((DataRowView)Container.DataItem).Row.RowState.ToString() %>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
		</FORM>
	</body>
</HTML>
