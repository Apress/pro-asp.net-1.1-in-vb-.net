<%@ Page Language = "vb" Codebehind="DataSetToXml.aspx.vb" AutoEventWireup="false" Inherits="SimpleXML.DataSetToXml" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataSetToXml</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="DataSetToXml" method="post" runat="server">
			<asp:Xml id="XmlControl" runat="server" DocumentSource="SuperProTransform.xml" TransformSource="SuperProProductList.xslt"></asp:Xml>
		</form>
	</body>
</HTML>
