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
	''' Summary description for WriteAndReadXml.
	''' </summary>
	Public Class ReadXmlEfficient : Inherits System.Web.UI.Page
		Protected XmlText As System.Web.UI.WebControls.Literal

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			ReadXML()
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


		Private Sub ReadXML()
			Dim xmlFile As String = Server.MapPath("DvdList.xml")

			' Create the reader.
			Dim reader As XmlTextReader = New XmlTextReader(xmlFile)

			Dim str As StringBuilder = New StringBuilder()
			reader.ReadStartElement("DvdList")

			' Read all the <DVD> elements.
			Do While reader.Read()
				If (reader.Name = "DVD") AndAlso (reader.NodeType = XmlNodeType.Element) Then
					reader.ReadStartElement("DVD")
					str.Append("<ul><b>")
					str.Append(reader.ReadElementString("Title"))
					str.Append("</b><li>")
					str.Append(reader.ReadElementString("Director"))
					str.Append("</li><li>")
					str.Append(String.Format("{0:C}", Decimal.Parse(reader.ReadElementString("Price"))))
					str.Append("</li></ul>")
				End If
			Loop
			' Close the reader and show the text.
			reader.Close()
			XmlText.Text = str.ToString()
		End Sub
	End Class
End Namespace
