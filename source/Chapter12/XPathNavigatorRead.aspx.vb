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
Imports System.Xml.XPath
Imports System.Text

Namespace Chapter12
	''' <summary>
	''' Summary description for XPathNavigatorRead.
	''' </summary>
	Public Class XPathNavigatorRead : Inherits System.Web.UI.Page
		Protected XmlText As System.Web.UI.WebControls.Literal

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim xmlFile As String = Server.MapPath("DvdList.xml")

			' Load the XML file in an XmlDocument.
			Dim doc As XmlDocument = New XmlDocument()
			doc.Load(xmlFile)

			' Create the navigator.
			Dim xnav As XPathNavigator = doc.CreateNavigator()

			XmlText.Text = GetXNavDescr(xnav, 0)
		End Sub

		Private Function GetXNavDescr(ByVal xnav As XPathNavigator, ByVal level As Integer) As String
			Dim indent As String = ""
			For i As Integer = 0 To level - 1
				indent += "&nbsp; &nbsp; &nbsp;"
			Next i

			Dim str As StringBuilder = New StringBuilder("")

			Select Case xnav.NodeType
				Case XPathNodeType.Root
					str.Append("<b>ROOT</b>")
					str.Append("<br>")

				Case XPathNodeType.Element
					str.Append(indent)
					str.Append("Element: <b>")
					str.Append(xnav.Name)
					str.Append("</b><br>")

				Case XPathNodeType.Text
					str.Append(indent)
					str.Append(" - Value: <b>")
					str.Append(xnav.Value)
					str.Append("</b><br>")

				Case XPathNodeType.Comment
					str.Append(indent)
					str.Append("Comment: <b>")
					str.Append(xnav.Value)
					str.Append("</b><br>")
			End Select

			If xnav.HasAttributes Then
				xnav.MoveToFirstAttribute()
				Do
					str.Append(indent)
					str.Append(" - Attribute: <b>")
					str.Append(xnav.Name)
					str.Append("</b> Value: <b>")
					str.Append(xnav.Value)
					str.Append("</b><br>")
				Loop While xnav.MoveToNextAttribute()

				' Return to the parent.
				xnav.MoveToParent()
			End If

			If xnav.HasChildren Then
				xnav.MoveToFirstChild()

				Do
					str.Append(GetXNavDescr(xnav, level+1))
				Loop While xnav.MoveToNext()

				' Return to the parent.
				xnav.MoveToParent()
			End If

			Return str.ToString()
		End Function

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
			AddHandler Load, AddressOf Page_Load

		End Sub
		#End Region
	End Class
End Namespace
