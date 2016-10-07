Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class GenerateSchema
	Private Shared connectionString As String = "Data Source=localhost;" + "Initial Catalog=Northwind;Integrated Security=SSPI"

	Private Shared categorySQL As String = "SELECT * FROM Categories"
	Private Shared productSQL As String = "SELECT * FROM Products"

	Public Shared Sub Main()

		' Create ADO.NET objects.
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim com As SqlCommand = New SqlCommand(categorySQL, con)
		Dim adapter As SqlDataAdapter = New SqlDataAdapter(com)
		Dim ds As DataSet = New DataSet("NorthwindDataSet")

		' Execute the command.
		Try
			con.Open()
			adapter.FillSchema(ds, SchemaType.Mapped, "Categories")

			' Modify the command and re-execute it.
			adapter.SelectCommand.CommandText = productSQL
			adapter.FillSchema(ds, SchemaType.Mapped, "Products")
		Catch err As Exception
			Console.WriteLine(err.ToString())
		Finally
			con.Close()
		End Try
		ds.WriteXmlSchema("c:\Northwind.xsd")
	End Sub
End Class
