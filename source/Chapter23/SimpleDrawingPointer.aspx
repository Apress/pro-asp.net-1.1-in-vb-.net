<%@ Page Language = "vb" Codebehind="SimpleDrawingPointer.aspx.vb" AutoEventWireup="false" Inherits="Chapter23.SimpleDrawingPointer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SimpleDrawingPointer</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Image id="Image1" runat="server" ImageUrl="SimpleDrawing.aspx"></asp:Image></P>
			<P>
				<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
				<asp:Button id="Button1" runat="server" Text="Button"></asp:Button></P>
			<P>
				<asp:DropDownList id="DropDownList1" runat="server">
					<asp:ListItem Value="Sample Item">Sample Item</asp:ListItem>
				</asp:DropDownList></P>
			<P>
				<asp:Image id="Image2" runat="server" ImageUrl="SimpleDrawing.aspx"></asp:Image></P>
		</form>
	</body>
</HTML>
