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
Imports System.Configuration
Imports System.IO

Namespace Chapter11
	''' <summary>
	''' Summary description for WebForm1.
	''' </summary>
	Public Class BlockwiseRender : Inherits System.Web.UI.Page
		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=pubs;Integrated Security=SSPI"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim SQL As String = "SELECT logo FROM pub_info WHERE pub_id='1389'"
			Dim cmd As SqlCommand = New SqlCommand(SQL, con)

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
						Response.BinaryWrite(bytes)
						readFrom += bufferSize
					Loop While bytesRead = bufferSize
				End If
				r.Close()
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
			AddHandler Load, AddressOf Page_Load

		End Sub
		#End Region
	End Class
End Namespace
