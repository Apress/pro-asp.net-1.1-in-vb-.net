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

Namespace Chapter10
	''' <summary>
	''' Summary description for Repeater1.
	''' </summary>
	Public Class Repeater2 : Inherits System.Web.UI.Page
		Protected Repeater1 As System.Web.UI.WebControls.Repeater

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				Dim sql As String = "SELECT FirstName, LastName, TitleOfCourtesy FROM Employees"

				' Create the Command and the Connection.
				Dim connectionString As String = "Data Source=localhost;" + "Initial Catalog=Northwind;Integrated Security=SSPI"
				Dim con As SqlConnection = New SqlConnection(connectionString)
				Dim cmd As SqlCommand = New SqlCommand(sql, con)

				' Open the connection and get the DataReader.
				con.Open()
				Dim reader As SqlDataReader = cmd.ExecuteReader()

				' Bind the Reader to the Repeater.
				Repeater1.DataSource = reader
				Repeater1.DataBind()

				' Close the DataReader and the Connection.
				reader.Close()
				con.Close()
			End If
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
