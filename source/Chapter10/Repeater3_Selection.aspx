<%@ Page CodeBehind="Repeater3_Selection.aspx.vb" Language = "vb" AutoEventWireup="false" Inherits="Chapter10.Repeater3" %>
<HTML>
	<body>
		<form method="post" runat="server" ID="Form1">
			<asp:Label runat="server" ID="MoreInfo" />
			<br>
			<br>
			<asp:Repeater runat="server" ID="Repeater1">
				<HeaderTemplate>
					<font color="red" size="5"><b>Employees</b></font>
					<hr size="4" color="red">
				</HeaderTemplate>
				<ItemTemplate>
					<asp:Button runat="server" Text="Select" CommandName="Select" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EmployeeID") %>' ID="Button1"/>
					<font name="Verdana" color="darkblue">
						<%# DataBinder.Eval(Container.DataItem, "TitleOfCourtesy") %>
						<b>
							<%# DataBinder.Eval(Container.DataItem, "LastName") %>
						</b>,
						<%# DataBinder.Eval(Container.DataItem, "FirstName") %>
					</font>
				</ItemTemplate>
				<AlternatingItemTemplate>
					<asp:Button runat="server" Text="Select" CommandName="SelectAlternating" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EmployeeID") %>' ID="Button2"/>
					<font name="Courier" color="Maroon"><i>
							<%# DataBinder.Eval(Container.DataItem, "TitleOfCourtesy") %>
							<b>
								<%# DataBinder.Eval(Container.DataItem, "LastName") %>
							</b>,
							<%# DataBinder.Eval(Container.DataItem, "FirstName") %>
						</i></font>
				</AlternatingItemTemplate>
				<SeparatorTemplate>
					<hr size="1" noshade>
				</SeparatorTemplate>
				<FooterTemplate>
					<hr size="4" color="red">
				</FooterTemplate>
			</asp:Repeater>
		</form>
	</body>
</HTML>
