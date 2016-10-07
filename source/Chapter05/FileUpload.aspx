<%@ Page Language = "vb" Codebehind="FileUpload.aspx.vb" AutoEventWireup="false" Inherits="Chapter05.FileUpload" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FileUpload</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server" enctype="multipart/form-data">
			Select a file to upload:<br>
			<P><INPUT id="Uploader" type="file" name="File1" runat="server" style="WIDTH: 497px; HEIGHT: 22px"
					size="63"></P>
			<P><INPUT id="cmdUpload" type="button" value="Upload" name="Button1" runat="server"></P>
			<DIV id="lblStatus" style="DISPLAY: inline; WIDTH: 497px; HEIGHT: 79px" runat="server"
				ms_positioning="FlowLayout"></DIV>
		</form>
	</body>
</HTML>
