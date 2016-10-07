<%@ Page Language = "vb" Codebehind="ImagesFromDatabase.aspx.vb" AutoEventWireup="false" Inherits="Chapter11.ImagesFromDatabase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ImagesFromDatabase</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DataList id="DataList1" runat="server" Font-Names="Verdana" Font-Size="X-Small">
				<ItemTemplate>
					<table border='1'>
						<tr>
							<td><img src='ImageFromDB.ashx?ID=<%# DataBinder.Eval(Container.DataItem, "pub_id") %>'/></td>
						</tr>
					</table>
					<b>
						<%# DataBinder.Eval(Container.DataItem, "pub_name") %>
					</b>
					<br>
					<%# DataBinder.Eval(Container.DataItem, "city") %>
					,
					<%# DataBinder.Eval(Container.DataItem, "state") %>
					,
					<%# DataBinder.Eval(Container.DataItem, "country") %>
					<br>
					<br>
				</ItemTemplate>
			</asp:DataList>

		</form>
	</body>
</HTML>
