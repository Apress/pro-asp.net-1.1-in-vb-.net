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
	Public Class TransactionTest : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" + "Integrated Security=SSPI"
			Dim con As SqlConnection = New SqlConnection(connectionString)

			Dim cmd1 As SqlCommand = New SqlCommand("INSERT INTO Employees2 (LastName, FirstName) VALUES ('Joe','Tester')")
			Dim cmd2 As SqlCommand = New SqlCommand("INSERT INTO Employees2 (LastName, FirstName) VALUES ('Harry','Sullivan')")

			Dim tran As SqlTransaction = Nothing
			Try
				' Open the connection and create the transaction.
				con.Open()
				tran = con.BeginTransaction()

				' Enlist two commands in the transaction.
				cmd1.Transaction = tran
				cmd2.Transaction = tran

				' Execute both commands and commit the transaction.
				cmd1.ExecuteNonQuery()
				cmd2.ExecuteNonQuery()

				' To test the transaction rollback, uncomment the line below.
				'throw new ApplicationException();

				tran.Commit()
				lblInfo.Text = "Transaction committed."
			Catch
				' In the case of error, roll back the transaction.
				tran.Rollback()
				lblInfo.Text = "Transaction aborted."
			Finally
				con.Close()
			End Try


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
