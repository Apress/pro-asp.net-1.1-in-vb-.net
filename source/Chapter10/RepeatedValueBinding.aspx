<%@ Page Language = "vb" Codebehind="RepeatedValueBinding.aspx.vb" AutoEventWireup="false" Inherits="Chapter10.RepeatedValueBinding" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<body>
		<form method="post" runat="server" ID="Form1">
			<table width="100%">
				<tr>
					<td>
						<select runat="server" ID="Select1" size="3" DataTextField="Key" DataValueField="Value"
							NAME="Select1" />
					</td>
					<td>
						<select runat="server" ID="Select2" DataTextField="Key" DataValueField="Value" NAME="Select2" />
					</td>
					<td>
						<asp:ListBox runat="server" ID="Listbox1" Size="3" DataTextField="Key" DataValueField="Value" />
					</td>
					<td>
						<asp:DropDownList runat="server" ID="DropdownList1" DataTextField="Key" DataValueField="Value" />
					</td>
					<td>
						<asp:RadioButtonList runat="server" ID="OptionList1" DataTextField="Key" DataValueField="Value" />
					</td>
					<td>
						<asp:CheckBoxList runat="server" ID="CheckList1" DataTextField="Key" DataValueField="Value" />
					</td>
				</tr>
			</table>
			<asp:Button runat="server" Text="Get Selection" ID="cmdGetSelection" />
			<br>
			<br>
			<asp:Literal runat="server" ID="Result" EnableViewState="False" />
		</form>
	</body>
</HTML>
