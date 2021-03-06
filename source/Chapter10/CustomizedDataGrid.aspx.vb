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

Namespace Chapter10
	''' <summary>
	''' Summary description for DataGrid1.
	''' </summary>
	Public Class CustomizedDataGrid : Inherits System.Web.UI.Page
		Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid

		Private connectionString As String = "Data Source=localhost;" + "Initial Catalog=Northwind;Integrated Security=SSPI"

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				BindGrid()
			End If
		End Sub

		Private Sub BindGrid()
			Dim ds As DataSet

			' Check the cache.
			If Not Cache("Employees") Is Nothing Then
				ds = CType(Cache("Employees"), DataSet)
			Else
				' Create the DataSet.
				ds = CreateDataSet()

				' Cache the DataSet for five minutes.
				Cache.Insert("Employees", ds, Nothing, DateTime.Now.AddMinutes(5), TimeSpan.Zero)
			End If

			' Retrieve the default view for the DataSet.
			Dim dv As DataView = ds.Tables("Employees").DefaultView

			' Set the sort order.
			dv.Sort = CStr(ViewState("SortExpression"))

			' Bind the grid.
			Datagrid1.DataSource = dv
			Datagrid1.DataBind()
		End Sub

		Private Function CreateDataSet() As DataSet
			Dim sql As String = "SELECT EmployeeID, FirstName, LastName, TitleOfCourtesy FROM Employees "
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
			Dim ds As DataSet = New DataSet()
			da.Fill(ds, "Employees")
			Return ds
		End Function

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

        End Sub
		#End Region

		Private Sub Datagrid1_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid1.ItemCreated
			If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

				' Get the title of courtesy for the item that's being created.
				Dim title As String = (CType(e.Item.DataItem, DataRowView))("TitleOfCourtesy").ToString()

				' If the title of courtesy is "Ms.", "Mrs.", or "Mr.",
				' change the item's colors.
				If title = "Ms." OrElse title = "Mrs." Then
					e.Item.BackColor = System.Drawing.Color.LightPink
					e.Item.ForeColor = System.Drawing.Color.Maroon
				Else If title = "Mr." Then
					e.Item.BackColor = System.Drawing.Color.LightCyan
					e.Item.ForeColor = System.Drawing.Color.DarkBlue
				End If
			End If

		End Sub


        Private Sub Datagrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged

        End Sub
    End Class
End Namespace
