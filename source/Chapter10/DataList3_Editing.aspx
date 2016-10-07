<%@ Page CodeBehind="DataList3_Editing.aspx.vb" Language = "vb" AutoEventWireup="false" Inherits="Chapter10.DataList3" %>
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
			<asp:DataList runat="server" ID="Datalist1" Width="100%" GridLines="Horizontal" RepeatColumns="1"
				DataKeyField="EmployeeID" HeaderStyle-Font-Size="15" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Red"
				HeaderStyle-BackColor="Yellow" HeaderStyle-BorderColor="Red" HeaderStyle-BorderWidth="5" FooterStyle-BorderColor="Red"
				FooterStyle-BorderWidth="5" ItemStyle-BackColor="LightCyan" ItemStyle-ForeColor="DarkBlue"
				AlternatingItemStyle-BackColor="LightYellow" AlternatingItemStyle-ForeColor="Maroon" AlternatingItemStyle-Font-Italic="true"
				SelectedItemStyle-ForeColor="Yellow" SelectedItemStyle-BackColor="Red" SelectedItemStyle-Font-Bold="true">
				<SelectedItemStyle Font-Bold="True" ForeColor="Yellow" BackColor="Red"></SelectedItemStyle>
				<HeaderTemplate>
					Employees
				</HeaderTemplate>
				<AlternatingItemStyle Font-Italic="True" ForeColor="Maroon" BackColor="LightYellow"></AlternatingItemStyle>
				<FooterTemplate>
				</FooterTemplate>
				<ItemStyle ForeColor="DarkBlue" BackColor="LightCyan"></ItemStyle>
				<ItemTemplate>
					<asp:Button runat="server" Text="Edit" CommandName="Edit" ID="Button1" />
					<%# DataBinder.Eval(Container.DataItem, "TitleOfCourtesy") %>
					<b>
						<%# DataBinder.Eval(Container.DataItem, "LastName") %>
					</b>,
					<%# DataBinder.Eval(Container.DataItem, "FirstName") %>
				</ItemTemplate>
				<FooterStyle BorderWidth="5px" BorderColor="Red"></FooterStyle>
				<HeaderStyle Font-Size="15pt" Font-Bold="True" BorderWidth="5px" ForeColor="Red" BorderColor="Red"
					BackColor="Yellow"></HeaderStyle>
				<EditItemTemplate>
					<asp:LinkButton runat="server" Text="Update" CommandName="Update" ID="Linkbutton1" /><br>
					<asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" ID="Linkbutton2" />
					<asp:DropDownList runat="server" ID="EditTitle" DataSource='<%# TitlesOfCourtesy %>' SelectedIndex='<%# GetSelectedTitle(DataBinder.Eval(Container.DataItem, "TitleOfCourtesy")) %>' />
					<asp:TextBox runat="server" ID="EditLastName" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>' />
					<asp:TextBox runat="server" ID="EditFirstName" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>' />
				</EditItemTemplate>
			</asp:DataList>
		</form>
	</body>
</HTML>
