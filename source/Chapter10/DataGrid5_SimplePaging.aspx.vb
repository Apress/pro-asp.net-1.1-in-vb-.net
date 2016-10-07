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
	''' Summary description for DataGridSimplePaging.
	''' </summary>
	Public Class DataGridSimplePaging : Inherits System.Web.UI.Page
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
'			Me.Datagrid1.PageIndexChanged += New System.Web.UI.WebControls.DataGridPageChangedEventHandler(Me.Datagrid1_PageIndexChanged);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub Datagrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid1.PageIndexChanged
			' deselect the currently selected row, if any
			Datagrid1.SelectedIndex = -1

			' change the current page and rebind
			Datagrid1.CurrentPageIndex = e.NewPageIndex
			BindGrid()

		End Sub
	End Class
End Namespace
