<%@ Page Language = "vb" Codebehind="ThumbnailsInDirectory.aspx.vb" AutoEventWireup="false" Inherits="Chapter23.ThumbnailsInDirectory" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ThumbnailsInDirectory</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Label id="Label1" runat="server">Directory: </asp:Label>&nbsp;
				<asp:TextBox id="txtDir" runat="server" Width="343px">c:\Windows\</asp:TextBox>
				<asp:Button id="cmdShow" runat="server" Text="Show Thumbnails" Width="123px"></asp:Button></P>
			<asp:DataList id="listThumbs" runat="server">
				<ItemStyle Font-Size="X-Small" Font-Names="Verdana"></ItemStyle>
				<ItemTemplate>
					<img src='<%# GetImageUrl(DataBinder.Eval(Container.DataItem, "FullName")) %>' />
					<%# DataBinder.Eval(Container.DataItem, "Name") %>
					<hr>
				</ItemTemplate>
			</asp:DataList>
		</form>
	</body>
</HTML>
