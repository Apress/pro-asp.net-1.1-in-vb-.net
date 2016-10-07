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

Namespace Chapter09
	''' <summary>
	''' Summary description for DataSetVersioning.
	''' </summary>
	Public Class DataSetVersioning : Inherits System.Web.UI.Page
		Protected Datagrid4 As System.Web.UI.WebControls.DataGrid
		Protected Datagrid3 As System.Web.UI.WebControls.DataGrid
		Protected Datagrid2 As System.Web.UI.WebControls.DataGrid
		Protected Datagrid5 As System.Web.UI.WebControls.DataGrid
		Protected Datagrid1 As System.Web.UI.WebControls.DataGrid

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" + "Integrated Security=SSPI"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim sql As String = "SELECT TOP 3 EmployeeID, TitleOfCourtesy, LastName, FirstName FROM Employees"
			Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
			Dim ds As DataSet = New DataSet()

			' Fill the DataSet.
			da.Fill(ds, "Employees")
			Dim table As DataTable = ds.Tables("Employees")

			' Bind the original data to grid #1.
			Datagrid1.DataSource = table
			Datagrid1.DataBind()

			' Edit the third row.
			table.Rows(2).BeginEdit()
			table.Rows(2)("LastName") = "Thompson"
			table.Rows(2)("FirstName") = "Jenny"
			table.Rows(2).EndEdit()

			' Create a new row.
			Dim newRow As DataRow = table.NewRow()
			newRow("TitleOfCourtesy") = "Mr."
			newRow("LastName") = "Bellinaso"
			newRow("FirstName") = "Marco"
			table.Rows.Add(newRow)

			' Delete the first row.
			table.Rows(0).Delete()

			' Bind the edited data to grid #2.
			Datagrid2.DataSource = table
			Datagrid2.DataBind()

			' Bind the added rows to grid #3.
			Dim view3 As DataView = New DataView(table)
			view3.RowStateFilter = DataViewRowState.Added
			Datagrid3.DataSource = view3
			Datagrid3.DataBind()

			' Bind the deleted rows to grid #4.
			Dim view4 As DataView = New DataView(table)
			view4.RowStateFilter = DataViewRowState.Deleted
			Datagrid4.DataSource = view4
			Datagrid4.DataBind()

			' Show the original data from the edited rows in grid #5.
			Dim view5 As DataView = New DataView(table)
			view5.RowStateFilter = DataViewRowState.ModifiedOriginal
			Datagrid5.DataSource = view5
			Datagrid5.DataBind()
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
