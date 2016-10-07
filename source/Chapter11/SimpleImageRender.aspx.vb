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
	Public Class SimpleRender : Inherits System.Web.UI.Page
		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=pubs;Integrated Security=SSPI"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim SQL As String = "SELECT logo FROM pub_info WHERE pub_id='1389'"

			Dim cmd As SqlCommand = New SqlCommand(SQL, con)

			Try
				con.Open()
				Dim r As SqlDataReader = cmd.ExecuteReader()

				If r.Read() Then
					Dim bytes As Byte() = CType(r("logo"), Byte())
					Response.BinaryWrite(bytes)
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
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region
	End Class
End Namespace
