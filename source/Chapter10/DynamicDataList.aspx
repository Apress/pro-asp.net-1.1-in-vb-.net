<%@ Page CodeBehind="DynamicDataList.aspx.vb" Language = "vb" AutoEventWireup="false" Inherits="Chapter10.DynamicDataList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<body>
		<form method="post" runat="server" ID="Form1">
			<b>Mode:</b>
			<asp:RadioButton runat="server" ID="SimpleMode" Text="Simple" Checked="true" GroupName="ModeGroup"
				AutoPostBack="true" />
			<asp:RadioButton runat="server" ID="ExtendedMode" Text="Extended" GroupName="ModeGroup" AutoPostBack="true" />
			<br>
			<br>
			<asp:DataList runat="server" ID="Datalist1" Width="100%" RepeatColumns="2" GridLines="Horizontal"
				HeaderStyle-Font-Size="15" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Red" HeaderStyle-BackColor="Yellow"
				HeaderStyle-BorderColor="Red" HeaderStyle-BorderWidth="5" FooterStyle-BorderColor="Red" FooterStyle-BorderWidth="5"
				ItemStyle-BackColor="LightCyan" ItemStyle-ForeColor="DarkBlue" AlternatingItemStyle-BackColor="LightYellow"
				AlternatingItemStyle-ForeColor="Maroon" AlternatingItemStyle-Font-Italic="true">
				<HeaderTemplate>
					Employees
				</HeaderTemplate>
				<FooterTemplate>
				</FooterTemplate>
			</asp:DataList>
		</form>
	</body>
</HTML>
