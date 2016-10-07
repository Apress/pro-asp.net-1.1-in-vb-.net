<%@ Page Language = "vb" Codebehind="DynamicUserControls.aspx.vb" AutoEventWireup="false" Inherits="Chapter19.DynamicUserControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<DIV style="BORDER-RIGHT: 1px ridge; PADDING-RIGHT: 10px; BORDER-TOP: 1px ridge; PADDING-LEFT: 10px; FONT-SIZE: x-small; PADDING-BOTTOM: 10px; MARGIN: 10px; BORDER-LEFT: 1px ridge; WIDTH: 298px; PADDING-TOP: 10px; BORDER-BOTTOM: 1px ridge; FONT-FAMILY: Verdana; HEIGHT: 58px; BACKGROUND-COLOR: beige"
				ms_positioning="FlowLayout" id="DIV1" runat="server">
				<asp:DropDownList id="lstControls1" runat="server" Width="215px" AutoPostBack="True">
					<asp:ListItem Value="(None)">(None)</asp:ListItem>
					<asp:ListItem Value="Header.ascx">Header</asp:ListItem>
					<asp:ListItem Value="TimeDisplay.ascx">TimeDisplay</asp:ListItem>
				</asp:DropDownList>
				<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder><BR>
				<asp:Label id="PanelLabel1" runat="server" Font-Italic="True" EnableViewState="False">Panel with custom content</asp:Label>
			</DIV>
			<DIV style="BORDER-RIGHT: 1px ridge; PADDING-RIGHT: 10px; BORDER-TOP: 1px ridge; PADDING-LEFT: 10px; FONT-SIZE: x-small; PADDING-BOTTOM: 10px; MARGIN: 10px; BORDER-LEFT: 1px ridge; WIDTH: 298px; PADDING-TOP: 10px; BORDER-BOTTOM: 1px ridge; FONT-FAMILY: Verdana; HEIGHT: 58px; BACKGROUND-COLOR: beige"
				ms_positioning="FlowLayout" id="DIV2" runat="server">
				<asp:DropDownList id="DropDownList2" runat="server" AutoPostBack="True" Width="215px">
						<asp:ListItem Value="(None)">(None)</asp:ListItem>
					<asp:ListItem Value="Header.ascx">Header</asp:ListItem>
					<asp:ListItem Value="TimeDisplay.ascx">TimeDisplay</asp:ListItem>
				</asp:DropDownList>
				<asp:PlaceHolder id="PlaceHolder2" runat="server"></asp:PlaceHolder><BR>
				<asp:Label id="Label3" runat="server" EnableViewState="False" Font-Italic="True">Panel with custom content</asp:Label></DIV>
			<DIV style="BORDER-RIGHT: 1px ridge; PADDING-RIGHT: 10px; BORDER-TOP: 1px ridge; PADDING-LEFT: 10px; FONT-SIZE: x-small; PADDING-BOTTOM: 10px; MARGIN: 10px; BORDER-LEFT: 1px ridge; WIDTH: 298px; PADDING-TOP: 10px; BORDER-BOTTOM: 1px ridge; FONT-FAMILY: Verdana; HEIGHT: 58px; BACKGROUND-COLOR: beige"
				ms_positioning="FlowLayout" id="DIV3" runat="server">
				<asp:DropDownList id="DropDownList3" runat="server" AutoPostBack="True" Width="215px">
						<asp:ListItem Value="(None)">(None)</asp:ListItem>
					<asp:ListItem Value="Header.ascx">Header</asp:ListItem>
					<asp:ListItem Value="TimeDisplay.ascx">TimeDisplay</asp:ListItem>
				</asp:DropDownList>
				<asp:PlaceHolder id="PlaceHolder3" runat="server"></asp:PlaceHolder><BR>
				<asp:Label id="Label4" runat="server" EnableViewState="False" Font-Italic="True">Panel with custom content</asp:Label></DIV>
		</form>
	</body>
</HTML>
