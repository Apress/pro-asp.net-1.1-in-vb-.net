Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections

Namespace DatabaseComponent
	Public Class EmployeeDB
		Private connectionString As String

		Public Sub New()
			' Get connection string from web.config.
			connectionString = ConfigurationSettings.AppSettings("ConnectionString")
		End Sub

		Public Function InsertEmployee(ByVal emp As EmployeeDetails) As Integer
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand("InsertEmployee", con)
			cmd.CommandType = CommandType.StoredProcedure

			cmd.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.NVarChar, 10))
			cmd.Parameters("@FirstName").Value = emp.FirstName
			cmd.Parameters.Add(New SqlParameter("@LastName", SqlDbType.NVarChar, 20))
			cmd.Parameters("@LastName").Value = emp.LastName
			cmd.Parameters.Add(New SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25))
			cmd.Parameters("@TitleOfCourtesy").Value = emp.TitleOfCourtesy
			cmd.Parameters.Add(New SqlParameter("@EmployeeID", SqlDbType.Int, 4))
			cmd.Parameters("@EmployeeID").Direction = ParameterDirection.Output

			Try
				con.Open()
				cmd.ExecuteNonQuery()
				Return CInt(cmd.Parameters("@EmployeeID").Value)
			Catch err As SqlException
				' Replace the error with something less specific.
				' You could also log the error now.
				Throw New ApplicationException("Data error.")
			Finally
				con.Close()
			End Try
		End Function

		Public Sub DeleteEmployee(ByVal employeeID As Integer)
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand("DeleteEmployee", con)
			cmd.CommandType = CommandType.StoredProcedure

			cmd.Parameters.Add(New SqlParameter("@EmployeeID", SqlDbType.Int, 4))
			cmd.Parameters("@EmployeeID").Value = employeeID

			Try
				con.Open()
				cmd.ExecuteNonQuery()
			Catch err As SqlException
				' Replace the error with something less specific.
				' You could also log the error now.
				Throw New ApplicationException("Data error.")
			Finally
				con.Close()
			End Try
		End Sub

		Public Function GetEmployees() As EmployeeDetails()
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand("GetAllEmployees", con)
			cmd.CommandType = CommandType.StoredProcedure

			' Create a collection for all the employee records.
			Dim employees As ArrayList = New ArrayList()

			Try
				con.Open()
				Dim reader As SqlDataReader = cmd.ExecuteReader()

				Do While reader.Read()
					Dim emp As EmployeeDetails = New EmployeeDetails(CInt(reader("EmployeeID")), CStr(reader("FirstName")), CStr(reader("LastName")), CStr(reader("TitleOfCourtesy")))
					employees.Add(emp)
				Loop
				reader.Close()

				Return CType(employees.ToArray(GetType(EmployeeDetails)), EmployeeDetails())
			Catch err As SqlException
				' Replace the error with something less specific.
				' You could also log the error now.
				Throw New ApplicationException("Data error.")
			Finally
				con.Close()
			End Try
		End Function

		Public Function CountEmployees() As Integer
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand("CountEmployees", con)
			cmd.CommandType = CommandType.StoredProcedure

			Try
				con.Open()
				Return CInt(cmd.ExecuteScalar())
			Catch err As SqlException
				' Replace the error with something less specific.
				' You could also log the error now.
				Throw New ApplicationException("Data error.")
			Finally
				con.Close()
			End Try
		End Function
	End Class
End Namespace
