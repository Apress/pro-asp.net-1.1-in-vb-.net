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
	<WebService (Name:="Employees Service", Description:="Retrieve the Northwind Employees", Namespace:="http://www.apress.com/ProASP.NET/")> _
	Public Class EmployeesServiceCached : Inherits System.Web.Services.WebService
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

		<WebMethod(Description:="Returns the total number of employees.")> _
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

		<WebMethod(Description:="Returns the full list of employees.")> _
		Public Function GetEmployees() As DataSet
			Return GetEmployeesDataSet()
		End Function

		<WebMethod(Description:="Returns the full list of employees by city.", MessageName:="GetEmployeesByCity")> _
		Public Function GetEmployees(ByVal city As String) As DataSet
			' Copy the DataSet.
			Dim dsFiltered As DataSet = GetEmployeesDataSet().Copy()

			' Remove the rows manually.
			' This is a good approach (rather than using the
			' DataTable.Select() method) because it is impervious
			' to SQL injection attacks.
			For Each row As DataRow In dsFiltered.Tables(0).Rows
				' Perform a case-insensitive compare.
				If String.Compare(row("City").ToString(), city.ToUpper(), True) <> 0 Then
					row.Delete()
				End If
			Next row

			' Remove these rows permanently.
			dsFiltered.AcceptChanges()

			Return dsFiltered
		End Function

		Private Function GetEmployeesDataSet() As DataSet
			Dim ds As DataSet

			If Not Context.Cache("EmployeesDataSet") Is Nothing Then
				' Retrieve it from the cache
				ds = CType(Context.Cache("EmployeesDataSet"), DataSet)
			Else
				' Retrieve it from the database.
				Dim sql As String = "SELECT EmployeeID, LastName, FirstName, Title, " + "TitleOfCourtesy, HomePhone, City FROM Employees"
				Dim con As SqlConnection = New SqlConnection(connectionString)
				Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
				ds = New DataSet()
				da.Fill(ds, "Employees")

				' Track when the DataSet was created. You can
				' retrieve this information in your client to test
				' that caching is working.
				ds.ExtendedProperties.Add("CreatedDate", DateTime.Now)

				' Store it in the cache for ten minutes.
				Context.Cache.Insert("EmployeesDataSet", ds, Nothing, DateTime.Now.AddMinutes(10), TimeSpan.Zero)
			End If
			Return ds
		End Function
	End Class
End Namespace
