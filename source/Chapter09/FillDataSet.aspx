<%@ Page Language = "vb" Codebehind="FillDataSet.aspx.vb" AutoEventWireup="false" Inherits="Chapter09.FillDataSet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FillDataSet</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" width="100%">
				<TR>
					<TD>
						<asp:Repeater id="Repeater1" runat="server">
							<HeaderTemplate>
								<h2>Repeater</h2>
							</HeaderTemplate>
							<ItemTemplate>
								<li>
									<%# DataBinder.Eval(Container.DataItem, "TitleOfCourtesy") %>
									<b>
										<%# DataBinder.Eval(Container.DataItem, "LastName") %>
									</b>,
									<%# DataBinder.Eval(Container.DataItem, "FirstName") %>
								</li>
							</ItemTemplate>
						</asp:Repeater></TD>
					<TD>
						<H2>foreach approach</H2>
						<asp:Literal id="HtmlContent" runat="server"></asp:Literal></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
