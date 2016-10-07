Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web
Imports System.Web.Services
Imports System.Data.SqlClient

Namespace Chapter24
	''' <summary>
	''' Summary description for LogServiceTest.
	''' </summary>
	Public Class LogServiceTest : Inherits System.Web.Services.WebService
		Public Sub New()
			'CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent()
		End Sub

		#Region "Component Designer generated code"

		'Required by the Web Services Designer 
		Private components As IContainer = Nothing

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso Not components Is Nothing Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#End Region

		Private connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=SSPI"

		<SoapLog(Name:="EmployeesService.GetEmployeesCount", Level:=3), WebMethod(Description:="Returns the total number of employees.")> _
		Public Function GetEmployeesCount() As Integer
			' uncomment the following line if you want to test the
			' asynchronous calls with the EmployeesWinAsync project
			' System.Threading.Thread.Sleep(3000);
			' Create the command and the connection.	
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim sql As String = "SELECT COUNT(*) FROM Employees"
			Dim cmd As SqlCommand = New SqlCommand(sql, con)

			' Open the connection and get the value.
			cmd.Connection.Open()
			Dim numEmployees As Integer = -1
			Try
				numEmployees = CInt(cmd.ExecuteScalar())
			Finally
				cmd.Connection.Close()
			End Try
			Return numEmployees
		End Function
	End Class
End Namespace
