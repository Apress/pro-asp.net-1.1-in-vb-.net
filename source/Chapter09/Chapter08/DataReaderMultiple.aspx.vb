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
Imports System.Data.SqlClient
Imports System.Text

Namespace Chapter08
	''' <summary>
	''' Summary description for Command1.
	''' </summary>
	Public Class DataReaderMultiple : Inherits System.Web.UI.Page
		Protected HtmlContent As System.Web.UI.WebControls.Literal

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' Create the Command and the Connection.
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" + "Integrated Security=SSPI"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim sql As String = "SELECT TOP 5 EmployeeID, FirstName, LastName FROM Employees;" + "SELECT TOP 5 ContactName, ContactTitle FROM Customers;" + "SELECT TOP 5 SupplierID, CompanyName, ContactName FROM Suppliers"

			Dim cmd As SqlCommand = New SqlCommand(sql, con)

			' Open the Connection and get the DataReader.
			con.Open()
			Dim reader As SqlDataReader = cmd.ExecuteReader()

			' Cycle through the records and all the rowsets,
			' and build the HTML string.
			Dim htmlStr As StringBuilder = New StringBuilder("")
			Dim i As Integer = 0
			Do
				htmlStr.Append("<h2>Rowset: ")
				htmlStr.Append(i.ToString())
				htmlStr.Append("</h2>")

				Do While reader.Read()
					htmlStr.Append("<li>")
					' Get all the fields in this row.
					For field As Integer = 0 To reader.FieldCount - 1
						htmlStr.Append(reader.GetName(field).ToString())
						htmlStr.Append(": ")
						htmlStr.Append(reader.GetValue(field).ToString())
						htmlStr.Append("&nbsp;&nbsp;&nbsp;")
					Next field
					htmlStr.Append("</li>")
				Loop
				htmlStr.Append("<br><br>")
				i += 1
			Loop While reader.NextResult()


			' Close the DataReader and the Connection.
			reader.Close()
			con.Close()

			' Show the generated HTML code on the page.
			HtmlContent.Text = htmlStr.ToString()
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
			AddHandler Load, AddressOf Page_Load

		End Sub
		#End Region
	End Class
End Namespace
