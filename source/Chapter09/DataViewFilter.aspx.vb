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
	''' Summary description for DataViewSort.
	''' </summary>
	Public Class DataViewFilter : Inherits System.Web.UI.Page
		Protected Datagrid1 As System.Web.UI.WebControls.DataGrid
		Protected Datagrid2 As System.Web.UI.WebControls.DataGrid
		Protected Datagrid3 As System.Web.UI.WebControls.DataGrid

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Create the Connection, DataAdapter, and DataSet.
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" + "Integrated Security=SSPI"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim sql As String = "SELECT ProductID, ProductName, UnitsInStock, UnitsOnOrder, Discontinued FROM Products"

			Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
			Dim ds As DataSet = New DataSet()

			' Fill the DataSet
			da.Fill(ds, "Products")

			' Filter for the Chocolade product.
			Dim view1 As DataView = New DataView(ds.Tables("Products"))
			view1.RowFilter = "ProductName = 'Chocolade'"
			Datagrid1.DataSource = view1

			' Filter for products that aren't on order or in stock.
			Dim view2 As DataView = New DataView(ds.Tables("Products"))
			view2.RowFilter = "UnitsInStock = 0 AND UnitsOnOrder = 0"
			Datagrid2.DataSource = view2

			' Filter for products starting with the letter P.
			Dim view3 As DataView = New DataView(ds.Tables("Products"))
			view3.RowFilter = "ProductName LIKE 'P%'"
			Datagrid3.DataSource = view3

			' Bind all the data-bound controls on the page.
			' Alternatively, you could call the DataBind() method
			' of each grid separately
			Me.DataBind()

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
