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
Imports DatabaseComponent

Namespace Chapter09
	''' <summary>
	''' Summary description for DataSetUpdate.
	''' </summary>
	Public Class DataSetCustomUpdate : Inherits System.Web.UI.Page
		Protected Datagrid1 As System.Web.UI.WebControls.DataGrid
		Protected CommandsText As System.Web.UI.WebControls.Literal
		Protected Datagrid2 As System.Web.UI.WebControls.DataGrid

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim db As Employee2DB = New Employee2DB()

			Dim table1 As DataTable = db.GetAllEmployees()

			' Bind the original data to the first grid.
			Datagrid1.DataSource = table1
			Datagrid1.DataBind()

			' Do some editing.
			table1.Rows(2).BeginEdit()
			table1.Rows(2)("LastName") = "Thompson"
			table1.Rows(2)("FirstName") = "Jenny"
			table1.Rows(2).EndEdit()

			' Create two new rows.
			Dim newRow As DataRow = table1.NewRow()
			newRow("TitleOfCourtesy") = "Mr."
			newRow("LastName") = "Bellinaso"
			newRow("FirstName") = "Marco"
			table1.Rows.Add(newRow)

			newRow = table1.NewRow()
			newRow("TitleOfCourtesy") = "Mrs."
			newRow("LastName") = "Virginia"
			newRow("FirstName") = "Woolf"
			table1.Rows.Add(newRow)

			' Delete a row.
			table1.Rows(0).Delete()

			' Update the data source.
			table1 = db.UpdateEmployeeBatch(table1)

			' Get fresh data from the database, and bind to the second grid.
			Datagrid2.DataSource = table1
			Datagrid2.DataBind()
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
