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
	''' Summary description for XmlDOM.
	''' </summary>
	Public Class XmlDOM : Inherits System.Web.UI.Page
Protected WithEvents txtXML As System.Web.UI.WebControls.Literal

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim xmlFile As String = Server.MapPath("DvdList.xml")

			' Load the XML file in an XmlDocument.
			Dim doc As XmlDocument = New XmlDocument()
			doc.Load(xmlFile)

			' Write the description text.
      txtXML.Text = GetChildNodesDescr(doc.ChildNodes, 0)
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

  End Sub
		#End Region

		Private Function GetChildNodesDescr(ByVal nodeList As XmlNodeList, ByVal level As Integer) As String
			Dim indent As String = ""
			For i As Integer = 0 To level - 1
				indent += "&nbsp; &nbsp; &nbsp;"
			Next i

			Dim str As StringBuilder = New StringBuilder("")

			For Each node As XmlNode In nodeList
				Select Case node.NodeType
					Case XmlNodeType.XmlDeclaration
						str.Append("XML Declaration: <b>")
						str.Append(node.Name)
						str.Append(" ")
						str.Append(node.Value)
						str.Append("</b><br>")

					Case XmlNodeType.Element
						str.Append(indent)
						str.Append("Element: <b>")
						str.Append(node.Name)
						str.Append("</b><br>")

					Case XmlNodeType.Text
						str.Append(indent)
						str.Append(" - Value: <b>")
						str.Append(node.Value)
						str.Append("</b><br>")

					Case XmlNodeType.Comment
						str.Append(indent)
						str.Append("Comment: <b>")
						str.Append(node.Value)
						str.Append("</b><br>")
				End Select

				If Not node.Attributes Is Nothing Then
					For Each attrib As XmlAttribute In node.Attributes
						str.Append(indent)
						str.Append(" - Attribute: <b>")
						str.Append(attrib.Name)
						str.Append("</b> Value: <b>")
						str.Append(attrib.Value)
						str.Append("</b><br>")
					Next attrib
				End If

				If node.HasChildNodes Then
					str.Append(GetChildNodesDescr(node.ChildNodes, level+1))
				End If
			Next node

			Return str.ToString()
		End Function
	End Class
End Namespace
