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

Namespace Chapter08
	''' <summary>
	''' Summary description for TestConnection.
	''' </summary>
	Public Class TestConnection : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Create the connection object.
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" + "Integrated Security=SSPI"
			Dim con As SqlConnection = New SqlConnection(connectionString)

			Try
				' Try to open the connection.
				con.Open()
				lblInfo.Text = "<b>Server Version:</b> " + con.ServerVersion
				lblInfo.Text += "<br><b>Connection Is:</b> " + con.State.ToString()
			Catch err As Exception
				' Handle an error by displaying the information.
				lblInfo.Text = "Error reading the database. "
				lblInfo.Text += err.Message
			Finally
				' Either way, make sure the connection is properly closed.
				' Even if the connection wasn't opened successfully,
				' calling Close() won't cause an error.
				con.Close()
				lblInfo.Text += "<br><b>Now Connection Is:</b> "
				lblInfo.Text += con.State.ToString()
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
