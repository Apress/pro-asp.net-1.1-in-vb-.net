<%@ Page Language = "vb" Codebehind="FileBrowser.aspx.vb" AutoEventWireup="false" Inherits="Chapter13.FileBrowser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FileBrowser</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<DIV style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; FONT-SIZE: xx-small; Z-INDEX: 101; LEFT: 16px; BORDER-LEFT: 2px groove; WIDTH: 394px; BORDER-BOTTOM: 2px groove; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 48px; HEIGHT: 331px"
				ms_positioning="FlowLayout"><asp:datagrid id="gridDirList" runat="server" AutoGenerateColumns="False" Font-Size="XX-Small"
					Width="418px" GridLines="None" CellPadding="0" CellSpacing="1" DataKeyField="FullName">
					<HeaderStyle Font-Bold="True" BackColor="#CCFFFF"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn>
							<HeaderStyle Width="20px"></HeaderStyle>
							<ItemTemplate>
								<img src="folder.jpg" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:ButtonColumn DataTextField="Name" HeaderText="Name" CommandName="Select">
							<HeaderStyle Width="130px"></HeaderStyle>
						</asp:ButtonColumn>
						<asp:BoundColumn HeaderText="Size">
							<HeaderStyle Width="50px"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="LastWriteTime" HeaderText="Last Modified"></asp:BoundColumn>
					</Columns>
				</asp:datagrid><asp:datagrid id="gridFileList" runat="server" AutoGenerateColumns="False" Font-Size="XX-Small"
					Width="417px" GridLines="None" CellPadding="0" CellSpacing="1" DataKeyField="FullName">
					<SelectedItemStyle BackColor="#C0FFFF"></SelectedItemStyle>
					<HeaderStyle Font-Size="1px"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn>
							<HeaderStyle Width="20px"></HeaderStyle>
							<ItemTemplate>
								<img src="file2.jpg" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:ButtonColumn DataTextField="Name" CommandName="Select">
							<HeaderStyle Width="130px"></HeaderStyle>
						</asp:ButtonColumn>
						<asp:BoundColumn DataField="Length">
							<HeaderStyle Width="50px"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="LastWriteTime"></asp:BoundColumn>
					</Columns>
				</asp:datagrid></DIV>
			&nbsp;
			<DIV style="BORDER-RIGHT: 2px groove; PADDING-RIGHT: 5px; BORDER-TOP: 2px groove; PADDING-LEFT: 5px; FONT-SIZE: xx-small; Z-INDEX: 102; LEFT: 445px; PADDING-BOTTOM: 5px; BORDER-LEFT: 2px groove; WIDTH: 357px; PADDING-TOP: 5px; BORDER-BOTTOM: 2px groove; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 47px; HEIGHT: 331px"
				ms_positioning="FlowLayout"><asp:datalist id="listFile" runat="server" Font-Size="XX-Small">
					<ItemTemplate>
						<b>File:
							<%# DataBinder.Eval(Container.DataItem, "FullName") %>
						</b>
						<br>
						Created at
						<%# DataBinder.Eval(Container.DataItem, "CreationTime") %>
						<br>
						Last updated at
						<%# DataBinder.Eval(Container.DataItem, "LastWriteTime") %>
						<br>
						Last accessed at
						<%# DataBinder.Eval(Container.DataItem, "LastAccessTime") %>
						<br>
						<i>
							<%# DataBinder.Eval(Container.DataItem, "Attributes") %>
						</i>
						<br>
						<%# DataBinder.Eval(Container.DataItem, "Length") %>
						bytes.
						<hr>
						<%# GetVersionInfoString(DataBinder.Eval(Container.DataItem, "FullName")) %>
					</ItemTemplate>
				</asp:datalist></DIV>
			<asp:label id="lblCurrentDir" style="Z-INDEX: 103; LEFT: 109px; POSITION: absolute; TOP: 18px"
				runat="server" Font-Italic="True">Currently showing </asp:label>
			<asp:Button id="cmdUp" style="Z-INDEX: 104; LEFT: 19px; POSITION: absolute; TOP: 16px" runat="server"
				Width="81px" Text="Move Up..." Height="23px"></asp:Button></form>
	</body>
</HTML>
