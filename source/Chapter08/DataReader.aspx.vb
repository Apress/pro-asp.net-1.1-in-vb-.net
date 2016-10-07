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
	Public Class Command1 : Inherits System.Web.UI.Page
Protected WithEvents OleDbConnection1 As System.Data.OleDb.OleDbConnection
  Protected HtmlContent As System.Web.UI.WebControls.Literal

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Create the Command and the Connection.
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" + "Integrated Security=SSPI"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim sql As String = "SELECT * FROM Employees"
			Dim cmd As SqlCommand = New SqlCommand(sql, con)

			' Open the Connection and get the DataReader.
			con.Open()
			Dim reader As SqlDataReader = cmd.ExecuteReader()

			' Cycle through the records, and build the HTML string.
			Dim htmlStr As StringBuilder = New StringBuilder("")
			Do While reader.Read()
				htmlStr.Append("<li>")
				htmlStr.Append(reader("TitleOfCourtesy"))
				htmlStr.Append(" <b>")
				htmlStr.Append(reader.GetString(1))
				htmlStr.Append("</b>, ")
				htmlStr.Append(reader.GetString(2))
				htmlStr.Append(" - employee from ")
				htmlStr.Append(reader.GetDateTime(6).ToString("d"))
				htmlStr.Append("</li>")
			Loop

			' Close the DataReader and the Connection.
			reader.Close()
			con.Close()

			' Show the generated HTML code on the page.
			HtmlContent.Text = htmlStr.ToString()
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
Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection
'
'OleDbConnection1
'
Me.OleDbConnection1.ConnectionString = "User ID=sa;Data Source=""PSS-WIN2KS"";Tag with column collation when possible=False" & _
";Initial Catalog=Northwind;Use Procedure for Prepare=1;Auto Translate=True;Persi" & _
"st Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=""NYCMLMORO2-DEV"";Use" & _
" Encryption for Data=False;Packet Size=4096"

  End Sub
		#End Region

Private Sub OleDbConnection1_InfoMessage(ByVal sender As System.Object, ByVal e As System.Data.OleDb.OleDbInfoMessageEventArgs) Handles OleDbConnection1.InfoMessage

End Sub
 End Class
End Namespace
