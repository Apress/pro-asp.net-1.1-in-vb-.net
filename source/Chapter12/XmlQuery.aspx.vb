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
Imports System.Data.SqlClient
Imports System.Text

Namespace Chapter12
	''' <summary>
	''' Summary description for XmlQuery.
	''' </summary>
	Public Class XmlQuery : Inherits System.Web.UI.Page
		Protected XmlText As System.Web.UI.WebControls.Literal

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim connectionString As String = "Data Source=localhost;" + "Initial Catalog=Northwind;Integrated Security=SSPI"

			' Define the command.
			Dim customerQuery As String = "SELECT FirstName, LastName FROM Employees FOR XML AUTO, ELEMENTS"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim com As SqlCommand = New SqlCommand(customerQuery, con)

			' Execute the command.
			Dim str As StringBuilder = New StringBuilder()
			Try
				con.Open()
				Dim reader As XmlReader = com.ExecuteXmlReader()

				Do While reader.Read()
					' Process each employee.
					If (reader.Name = "Employees") AndAlso (reader.NodeType = XmlNodeType.Element) Then
						reader.ReadStartElement("Employees")
						str.Append(reader.ReadElementString("FirstName"))
						str.Append(" ")
						str.Append(reader.ReadElementString("LastName"))
						str.Append("<br>")
						reader.ReadEndElement()
					End If
				Loop
				reader.Close()
			Finally
				con.Close()
			End Try
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
