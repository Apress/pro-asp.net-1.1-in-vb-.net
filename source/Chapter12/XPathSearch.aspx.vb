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
Imports System.Text

Namespace Chapter12
	''' <summary>
	''' Summary description for XPathSearch.
	''' </summary>
	Public Class XPathSearch : Inherits System.Web.UI.Page
		Protected XmlText As System.Web.UI.WebControls.Literal

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Load the XML file.
			Dim xmlFile As String = Server.MapPath("DvdList.xml")
			Dim doc As XmlDocument = New XmlDocument()
			doc.Load(xmlFile)

			' Retrieve the title of every science fiction move.
			Dim nodes As XmlNodeList = doc.SelectNodes("/DvdList/DVD/Title[../@Category='Science Fiction']")

			' Display the titles.
			Dim str As StringBuilder = New StringBuilder()
			For Each node As XmlNode In nodes
				str.Append("Found: <b>")

				' Show the text contained in this <Title> element.
				str.Append(node.ChildNodes(0).Value)
				str.Append("</b><br>")
			Next node
			XmlText.Text = str.ToString()
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
