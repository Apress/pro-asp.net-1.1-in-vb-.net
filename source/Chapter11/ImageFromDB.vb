Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System.Web

Namespace Chapter11
	Public Class ImageFromDB : Implements IHttpHandler
		Private connectionString As String

		Public Sub New()
			' Get connection string from web.config.
			connectionString = ConfigurationSettings.AppSettings("ConnectionString")
		End Sub

		Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
			' Get the ID for this request.
			Dim id As String = context.Request.QueryString("id")
			If id Is Nothing Then
			Throw New ApplicationException("Must specify ID.")
			End If

			' Create a parameterized command for this record.
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim SQL As String = "SELECT logo FROM pub_info WHERE pub_id=@ID"
			Dim cmd As SqlCommand = New SqlCommand(SQL, con)
			cmd.Parameters.Add("@ID", id)

			Try
				con.Open()
				Dim r As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)

				If r.Read() Then
					Dim bufferSize As Integer = 100 ' Size of the buffer.
					Dim bytes As Byte() = New Byte(bufferSize - 1) {} ' The buffer (one block of data).
					Dim bytesRead As Long ' The number of bytes read.
					Dim readFrom As Long = 0 ' The starting index.

					' Read the field 100 bytes at a time.
					Do
						bytesRead = r.GetBytes(0, readFrom, bytes, 0, bufferSize)
						context.Response.BinaryWrite(bytes)
						readFrom += bufferSize
					Loop While bytesRead = bufferSize
				End If
				r.Close()
			Finally
				con.Close()
			End Try
		End Sub

		Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
			Get
				Return True
			End Get
		End Property

	End Class
End Namespace
