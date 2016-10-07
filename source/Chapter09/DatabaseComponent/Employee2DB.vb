Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections

Namespace DatabaseComponent
	Public Class Employee2DB
		Private connectionString As String

		Public Sub New()
			' Get connection string from web.config.
			connectionString = ConfigurationSettings.AppSettings("ConnectionString")
		End Sub

		Public Function GetAllEmployees() As DataTable
			Dim sql As String = "SELECT EmployeeID, TitleOfCourtesy, LastName, FirstName FROM Employees2"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
			Dim ds As DataSet = New DataSet()

			' Fill the DataSet.
			Try
				da.Fill(ds, "Employees")
			Catch
				Throw New ApplicationException("Data error.")
			End Try
			Return ds.Tables("Employees")
		End Function

		Public Function UpdateEmployeeBatch(ByVal dt As DataTable) As DataTable
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim da As SqlDataAdapter = New SqlDataAdapter()

			' Create the Insert command, and set its parameters.
			da.InsertCommand = New SqlCommand("InsertEmployee2", con)
			da.InsertCommand.CommandType = CommandType.StoredProcedure

			Dim insParam1 As SqlParameter = New SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25)
			insParam1.SourceVersion = DataRowVersion.Current
			insParam1.SourceColumn = "TitleOfCourtesy"

			Dim insParam2 As SqlParameter = New SqlParameter("@LastName", SqlDbType.NVarChar, 20)
			insParam2.SourceVersion = DataRowVersion.Current
			insParam2.SourceColumn = "LastName"

			Dim insParam3 As SqlParameter = New SqlParameter("@FirstName", SqlDbType.NVarChar, 10)
			insParam3.SourceVersion = DataRowVersion.Current
			insParam3.SourceColumn = "FirstName"

			Dim insParam4 As SqlParameter = New SqlParameter("@EmployeeID", SqlDbType.Int, 4)
			insParam4.SourceColumn = "EmployeeID"
			insParam4.Direction = ParameterDirection.Output

			' Add the parameters.
			da.InsertCommand.Parameters.Add(insParam1)
			da.InsertCommand.Parameters.Add(insParam2)
			da.InsertCommand.Parameters.Add(insParam3)
			da.InsertCommand.Parameters.Add(insParam4)


			' Create the Update command, and set its parameters.
			da.UpdateCommand = New SqlCommand("UpdateEmployee2", con)
			da.UpdateCommand.CommandType = CommandType.StoredProcedure

			Dim updParam1 As SqlParameter = New SqlParameter("@EmployeeID", SqlDbType.Int, 4)
			updParam1.SourceVersion = DataRowVersion.Original
			updParam1.SourceColumn = "EmployeeID"

			Dim updParam2 As SqlParameter = New SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25)
			updParam2.SourceVersion = DataRowVersion.Current
			updParam2.SourceColumn = "TitleOfCourtesy"

			Dim updParam3 As SqlParameter = New SqlParameter("@LastName", SqlDbType.NVarChar, 20)
			updParam3.SourceVersion = DataRowVersion.Current
			updParam3.SourceColumn = "LastName"

			Dim updParam4 As SqlParameter = New SqlParameter("@FirstName", SqlDbType.NVarChar, 10)
			updParam4.SourceVersion = DataRowVersion.Current
			updParam4.SourceColumn = "FirstName"

			' Add the parameters.
			da.UpdateCommand.Parameters.Add(updParam1)
			da.UpdateCommand.Parameters.Add(updParam2)
			da.UpdateCommand.Parameters.Add(updParam3)
			da.UpdateCommand.Parameters.Add(updParam4)


			' Create the Delete command, and set its parameters.
			da.DeleteCommand = New SqlCommand("DeleteEmployee2", con)
			da.DeleteCommand.CommandType = CommandType.StoredProcedure

			Dim delParam1 As SqlParameter = New SqlParameter("@EmployeeID", SqlDbType.Int, 4)
			delParam1.SourceVersion = DataRowVersion.Original
			delParam1.SourceColumn = "EmployeeID"

			' Add the parameter.
			da.DeleteCommand.Parameters.Add(delParam1)

			' Update the data source.
			Try
				da.Update(dt)
			Catch
				Throw New ApplicationException("Data error.")
			End Try
			Return dt
		End Function
	End Class
End Namespace

