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

Namespace Chapter09
	''' <summary>
	''' Summary description for DataSetUpdate.
	''' </summary>
	Public Class DataSetUpdate : Inherits System.Web.UI.Page
		Protected Datagrid1 As System.Web.UI.WebControls.DataGrid
		Protected CommandsText As System.Web.UI.WebControls.Literal
		Protected Datagrid2 As System.Web.UI.WebControls.DataGrid

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" + "Integrated Security=SSPI"
			Dim sql As String = "SELECT EmployeeID, TitleOfCourtesy, LastName, FirstName FROM Employees2"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
			Dim ds As DataSet = New DataSet()

			' Create the CommandBuilder, and assign the commands to the DataAdapter.
			Dim cmdBuilder As SqlCommandBuilder = New SqlCommandBuilder(da)
			da = cmdBuilder.DataAdapter

			' Fill the DataSet.
			da.Fill(ds, "Employees")
			Dim table1 As DataTable = ds.Tables("Employees")

			' Bind the original data to the first grid.
			Datagrid1.DataSource = table1
			Datagrid1.DataBind()

			' Do some editing on the DataTable.
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

			' Update the data in the database.
			da.Update(ds, "Employees")

			' Create the HTML string with the command text.
			Dim str As StringBuilder = New StringBuilder("")
			str.Append("<hr><b>InsertCommand:</b><br>")
			str.Append(cmdBuilder.GetInsertCommand().CommandText)
			str.Append("<br><br>")
			str.Append("<b>UpdateCommand:</b><br>")
			str.Append(cmdBuilder.GetUpdateCommand().CommandText)
			str.Append("<br><br>")
			str.Append("<b>DeleteCommand:</b><br>")
			str.Append(cmdBuilder.GetDeleteCommand().CommandText)
			str.Append("<hr>")

			CommandsText.Text = str.ToString()

			' Get fresh data from the database, and bind to the second grid.
			ds.Clear()
			da.Fill(ds, "Employees")
			Datagrid2.DataSource = ds.Tables("Employees")
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
