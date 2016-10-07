<%@ Page CodeBehind="DataList2_Selection.aspx.vb" Language = "vb" AutoEventWireup="false" Inherits="Chapter10.DataList2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Label id="MoreInfo" runat="server"></asp:Label></P>
			<asp:DataList runat="server" ID="Datalist1" Width="100%" GridLines="Horizontal" RepeatColumns="2"
				DataKeyField="EmployeeID" HeaderStyle-Font-Size="15" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Red"
				HeaderStyle-BackColor="Yellow" HeaderStyle-BorderColor="Red" HeaderStyle-BorderWidth="5" FooterStyle-BorderColor="Red"
				FooterStyle-BorderWidth="5" ItemStyle-BackColor="LightCyan" ItemStyle-ForeColor="DarkBlue"
				AlternatingItemStyle-BackColor="LightYellow" AlternatingItemStyle-ForeColor="Maroon" AlternatingItemStyle-Font-Italic="true"
				SelectedItemStyle-ForeColor="Yellow" SelectedItemStyle-BackColor="Red" SelectedItemStyle-Font-Bold="true">
				<HeaderTemplate>
					Employees
				</HeaderTemplate>
				<ItemTemplate>
					<asp:Button runat="server" Text="Select" CommandName="Select" ID="Button1" />
					<%# DataBinder.Eval(Container.DataItem, "TitleOfCourtesy") %>
					<b>
						<%# DataBinder.Eval(Container.DataItem, "LastName") %>
					</b>,
					<%# DataBinder.Eval(Container.DataItem, "FirstName") %>
				</ItemTemplate>
				<FooterTemplate>
				</FooterTemplate>
			</asp:DataList>
		</form>
	</body>
</HTML>
