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
	''' Summary description for DataReaderListBinding.
	''' </summary>
	Public Class DataReaderListBinding : Inherits System.Web.UI.Page
		Protected Listbox1 As System.Web.UI.WebControls.ListBox
		Protected WithEvents cmdGetSelection As System.Web.UI.WebControls.Button
		Protected Result As System.Web.UI.WebControls.Literal

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				' Create the command and the connection.
				Dim connectionString As String = "Data Source=localhost;" + "Initial Catalog=Northwind;Integrated Security=SSPI"

				Dim sql As String = "SELECT EmployeeID, TitleOfCourtesy + ' ' + FirstName + ' ' + LastName As FullName FROM Employees"
				Dim con As SqlConnection = New SqlConnection(connectionString)
				Dim cmd As SqlCommand = New SqlCommand(sql, con)

				' Open the connection and get the DataReader.
				con.Open()
				Dim reader As SqlDataReader = cmd.ExecuteReader()

				' bind the reader to the Listbox
				Listbox1.DataSource = reader
				Listbox1.DataBind()

				' Close the reader and the connection.
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
'			Me.cmdGetSelection.Click += New System.EventHandler(Me.cmdGetSelection_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdGetSelection_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGetSelection.Click
			Result.Text += "<b>Selected employees:</b>"
			For Each li As ListItem In Listbox1.Items
				If li.Selected Then
					Result.Text += String.Format("<li>({0}) {1}</li>", li.Value, li.Text)
				End If
			Next li
		End Sub

	End Class
End Namespace
