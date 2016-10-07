<%@ Page Language = "vb" Codebehind="CurrentUserList.aspx.vb" AutoEventWireup="false" Inherits="Chapter18.CurrentUserList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CurrentUserList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DataList id="UsersDataList" runat="server" BorderColor="#999999" BorderStyle="Solid" ForeColor="Black"
				BackColor="White" CellPadding="3" GridLines="Vertical" BorderWidth="1px">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
				<HeaderTemplate>
					Currently Logged In Users
				</HeaderTemplate>
				<FooterTemplate>
					Anonymous Users:
					<%# Application["AnonymousUsers"]%>
				</FooterTemplate>
				<ItemTemplate>
					<%#DataBinder.Eval(Container, "DataItem")%>
				</ItemTemplate>
				<FooterStyle BackColor="#CCCCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
			</asp:DataList>
			<P>
				<asp:Button id="cmdLogOut" runat="server" Text="Log Out"></asp:Button>&nbsp;
				<asp:Button id="cmdLogin" runat="server" Text="Log In"></asp:Button></P>
		</form>
	</body>
</HTML>
