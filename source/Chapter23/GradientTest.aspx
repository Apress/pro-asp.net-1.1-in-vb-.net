<%@ Register TagPrefix="cc1" Namespace="CustomControlLibrary" Assembly="GradientLabelControl" %>
<%@ Page Language = "vb" Codebehind="GradientTest.aspx.vb" AutoEventWireup="false" Inherits="Chapter23.GradientTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GradientTest</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<cc1:gradientlabel id="GradientLabel1" runat="server" Text="Test String" GradientColorA="Honeydew"
				GradientColorB="RoyalBlue"></cc1:gradientlabel></form>
	</body>
</HTML>
