Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath

Namespace Chapter12
	''' <summary>
	''' Summary description for XmlToHtml.
	''' </summary>
	Public Class XmlToHtml : Inherits System.Web.UI.Page
		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim xslFile As String = Server.MapPath("DvdList.xsl")
			Dim xmlFile As String = Server.MapPath("DvdList.xml")
			Dim htmlFile As String = Server.MapPath("DvdList.htm")

			Dim transf As XslTransform = New XslTransform()
			transf.Load(xslFile)
			transf.Transform(xmlFile, htmlFile)

			' Create an XPathDocument.
			Dim xdoc As XPathDocument = New XPathDocument(New XmlTextReader(xmlFile))

			' Create an XPathNavigator.

			Dim xnav As XPathNavigator = xdoc.CreateNavigator()

			' Transform the XML
			Dim reader As XmlReader = transf.Transform(xnav, Nothing)

			' Go the the content and write it.
			reader.MoveToContent()
			Response.Write(reader.ReadOuterXml())
			reader.Close()
		End Sub

		#Region "Web Form Designer generated code"
		Overrides Protected Sub OnInit(ByVal e As EventArgs)
			'
			' CODEGEN: This call is required by the ASP.NET Web Form Designer.
			'
			InitializeComponent()
			MyBase.OnInit(e)
		End Sub

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
'			Me.Load += New System.EventHandler(Me.Page_Load);
		End Sub
		#End Region
	End Class
End Namespace
