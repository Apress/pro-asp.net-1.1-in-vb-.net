<%@ Page Language = "vb" Codebehind="Validators.aspx.vb" AutoEventWireup="false" Inherits="Chapter05.Validators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ASP.NET Validators</title>
		<script language="JavaScript">
			function EmpIDClientValidate(ctl, args)
			{
				args.IsValid=(args.Value%5 == 0);
			}
		</script>
	</HEAD>
	<body>
		<form method="post" runat="server" ID="FormValidators">
			<asp:table runat="server" ID="Table1">
				<asp:TableRow>
					<asp:TableCell Width="50px" Text="Description" Font-Bold="true" ForeColor="blue" />
					<asp:TableCell Width="200px" Text="Value" Font-Bold="true" ForeColor="blue" />
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell Text="Name:" />
					<asp:TableCell>
						<asp:TextBox runat="server" Width="200px" ID="Name" />
						<asp:RequiredFieldValidator runat="server" ID="ValidateName" ControlToValidate="Name" ErrorMessage="Name is required"
							Display="dynamic">*
				</asp:RequiredFieldValidator>
						<asp:RegularExpressionValidator runat="server" ID="ValidateName2" ControlToValidate="Name" validationExpression="[a-z A-Z]*"
							ErrorMessage="Name cannot contain digits" Display="dynamic">*
    			</asp:RegularExpressionValidator>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell Text="ID (multiple of 5):" />
					<asp:TableCell>
						<asp:TextBox runat="server" Width="200px" ID="EmpID" />
						<asp:RequiredFieldValidator runat="server" ID="ValidateEmpID" ControlToValidate="EmpID" ErrorMessage="ID is required"
							Display="dynamic">*
				</asp:RequiredFieldValidator>
						<asp:CustomValidator runat="server" ID="ValidateEmpID2" ControlToValidate="EmpID" ClientValidationFunction="EmpIDClientValidate"
							ErrorMessage="ID must be a multiple of 5" Display="dynamic">*
    			</asp:CustomValidator>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell Text="Day off:<br><small>08/05/02-08/20/02</small>" />
					<asp:TableCell>
						<asp:TextBox runat="server" Width="200px" ID="DayOff" />
						<asp:RequiredFieldValidator runat="server" ID="ValidateDayOff" ControlToValidate="DayOff" ErrorMessage="Day Off is required"
							Display="dynamic">*
				</asp:RequiredFieldValidator>
						<asp:RangeValidator runat="server" ID="ValidateDayOff2" ControlToValidate="DayOff" MinimumValue="08/05/2002"
							MaximumValue="08/20/2002" Type="Date" ErrorMessage="Day Off is not within the valid interval" Display="dynamic">*
    			</asp:RangeValidator>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell Text="Age&nbsp<small>( >= 18 )</small>:" />
					<asp:TableCell>
						<asp:TextBox runat="server" Width="200px" ID="Age" />
						<asp:RequiredFieldValidator runat="server" ControlToValidate="Age" ErrorMessage="Age is required" Display="dynamic"
							ID="Requiredfieldvalidator1" Name="Requiredfieldvalidator1">*
				</asp:RequiredFieldValidator>
						<asp:CompareValidator runat="server" ID="ValidateAge" ControlToValidate="Age" ValueToCompare="18" Type="Integer"
							Operator="GreaterThanEqual" ErrorMessage="You must be at least 18-year-old" Display="dynamic">*
    			</asp:CompareValidator>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell Text="E-mail:" />
					<asp:TableCell>
						<asp:TextBox runat="server" Width="200px" ID="Email" />
						<asp:RequiredFieldValidator runat="server" ControlToValidate="Email" ErrorMessage="E-mail is required" Display="dynamic"
							ID="Requiredfieldvalidator2" Name="Requiredfieldvalidator2">*
				</asp:RequiredFieldValidator>
						<asp:RegularExpressionValidator runat="server" ID="ValidateEmail" ControlToValidate="Email" validationExpression=".*@.{2,}\..{2,}"
							ErrorMessage="E-mail is not in a valid format" Display="dynamic">*
    				</asp:RegularExpressionValidator>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell Text="Password:" />
					<asp:TableCell>
						<asp:TextBox TextMode="Password" runat="server" Width="200px" ID="Password" />
						<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is required"
							Display="dynamic" ID="Requiredfieldvalidator3" Name="Requiredfieldvalidator3">
							<img src="imgError.gif" border="0">
						</asp:RequiredFieldValidator>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell Text="Re-enter Password:" />
					<asp:TableCell>
						<asp:TextBox runat="server" TextMode="Password" Width="200px" ID="Password2" />
						<asp:RequiredFieldValidator runat="server" ControlToValidate="Password2" ErrorMessage="Password2 is required"
							Display="dynamic" ID="Requiredfieldvalidator4" Name="Requiredfieldvalidator4">
							<img src="imgError.gif" border="0">
						</asp:RequiredFieldValidator>
						<asp:CompareValidator runat="server" ControlToValidate="Password2" ControlToCompare="Password" Type="String"
							ErrorMessage="The passwords don't match" Display="dynamic" ID="Comparevalidator1" Name="Comparevalidator1">
							<img src="imgError.gif" border="0">
						</asp:CompareValidator>
					</asp:TableCell>
				</asp:TableRow>
			</asp:table><BR>
			<asp:Button runat="server" Text="Submit" ID="Submit" /><BR>
			<br>
			<asp:CheckBox runat="server" ID="EnableValidators" Checked="True" AutoPostBack="True" Text="Validators enabled" />
			<br>
			<asp:CheckBox runat="server" ID="EnableClientSide" Checked="True" AutoPostBack="True" Text="Client-side validation enabled" />
			<br>
			<asp:CheckBox runat="server" ID="ShowSummary" Checked="True" AutoPostBack="True" Text="Show summary" />
			<br>
			<asp:CheckBox runat="server" ID="ShowMsgBox" Checked="False" AutoPostBack="True" Text="Show message box" />
			<br>
			<br>
			<asp:ValidationSummary runat="server" ID="ValidationSum" DisplayMode="BulletList" HeaderText="<b>Please review the following errors:</b>"
				ShowSummary="true" />
		</form>
		<asp:Label runat="server" ID="Result" ForeColor="magenta" Font-Bold="true" EnableViewState="False" />
	</body>
</HTML>
