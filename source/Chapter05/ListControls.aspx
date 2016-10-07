<%@ Page Language = "vb" Codebehind="ListControls.aspx.vb" AutoEventWireup="false" Inherits="Chapter05.ListControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListControls</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form runat="server" ID="Form1">
			<asp:ListBox runat="server" ID="Listbox1" SelectionMode="Multiple" Rows="5">
				<asp:ListItem Selected="true">Option 1</asp:ListItem>
				<asp:ListItem>Option 2</asp:ListItem>
			</asp:ListBox>
			<br>
			<br>
			<asp:DropDownList runat="server" ID="DropdownList1">
				<asp:ListItem Selected="true">Option 1</asp:ListItem>
				<asp:ListItem>Option 2</asp:ListItem>
			</asp:DropDownList>
			<br>
			<br>
			<asp:CheckBoxList runat="server" ID="CheckboxList1" RepeatColumns="3">
				<asp:ListItem Selected="true">Option 1</asp:ListItem>
				<asp:ListItem>Option 2</asp:ListItem>
			</asp:CheckBoxList>
			<br>
			<asp:RadioButtonList runat="server" ID="RadiobuttonList1" RepeatDirection="Horizontal" RepeatColumns="2">
				<asp:ListItem Selected="true">Option 1</asp:ListItem>
				<asp:ListItem>Option 2</asp:ListItem>
			</asp:RadioButtonList>
			<asp:Button runat="server" Text="Submit" ID="Button1" NAME="Button1" />
		</form>
	</body>
</HTML>
