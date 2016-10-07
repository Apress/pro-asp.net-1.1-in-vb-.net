<%@ Page CodeBehind="Repeater1.aspx.vb" Language = "vb" AutoEventWireup="false" Inherits="Chapter10.RepeaterTest" %>
<%@ Import Namespace="System.Data.Common" %>
<HTML>
	<body>
		<form method="post" runat="server">
			<h2>Employees</h2>
			<asp:Repeater runat="server" ID="Repeater1">
				<ItemTemplate>
					<li>
						<%# Container.DataItem("TitleOfCourtesy") %>
						<b>
							<%# Container.DataItem("LastName") %>
						</b>,
						<%# Container.DataItem("FirstName") %>
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</form>
	</body>
</HTML>
