<%@ Page CodeBehind="Repeater2_Formatted.aspx.vb" Language = "vb" AutoEventWireup="false" Inherits="Chapter10.Repeater2" %>
<html>
	<body>
		<form method="post" runat="server" ID="Form1">
			<asp:Repeater runat="server" ID="Repeater1">
				<HeaderTemplate>
					<font color="red" size="5"><b>Employees</b></font>
					<hr size="4" color="red">
				</HeaderTemplate>
				<ItemTemplate>
					<li>
						<font name="Verdana" color="darkblue">
							<%# DataBinder.Eval(Container.DataItem, "TitleOfCourtesy") %>
							<b>
								<%# DataBinder.Eval(Container.DataItem, "LastName") %>
							</b>,
							<%# DataBinder.Eval(Container.DataItem, "FirstName") %>
						</font>
					</li>
				</ItemTemplate>
				<AlternatingItemTemplate>
					<li>
						<font name="Courier" color="Maroon"><i>
								<%# DataBinder.Eval(Container.DataItem, "TitleOfCourtesy") %>
								<b>
									<%# DataBinder.Eval(Container.DataItem, "LastName") %>
								</b>,
								<%# DataBinder.Eval(Container.DataItem, "FirstName") %>
							</i></font>
					</li>
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
</html>
