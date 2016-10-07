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
Imports System.Text
Imports System.Data.SqlClient

Namespace Chapter09
	''' <summary>
	''' Summary description for FillDataSet.
	''' </summary>
	Public Class FillDataSet : Inherits System.Web.UI.Page
		Protected HtmlContent As System.Web.UI.WebControls.Literal
		Protected Repeater1 As System.Web.UI.WebControls.Repeater

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Create the Connection, DataAdapter, and DataSet.
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" + "Integrated Security=SSPI"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim sql As String = "SELECT * FROM Employees"

			Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
			Dim ds As DataSet = New DataSet()

			' Fill the DataSet.
			da.Fill(ds, "Employees")

			' Cycle through the records, and build the HTML string.
			Dim htmlStr As StringBuilder = New StringBuilder("")
			For Each dr As DataRow In ds.Tables("Employees").Rows
				htmlStr.Append("<li>")
				htmlStr.Append(dr("TitleOfCourtesy").ToString())
				htmlStr.Append(" <b>")
				htmlStr.Append(dr("LastName").ToString())
				htmlStr.Append("</b>, ")
				htmlStr.Append(dr("FirstName").ToString())
				htmlStr.Append("</li>")
			Next dr

			' Show the generated HTML string.
			HtmlContent.Text = htmlStr.ToString()

			' Bind the DataSet to the Repeater.
			Repeater1.DataSource = ds
			Repeater1.DataMember = "Employees"
			Repeater1.DataBind()

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
