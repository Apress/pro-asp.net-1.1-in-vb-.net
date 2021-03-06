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
	''' Summary description for CalculatedColumn.
	''' </summary>
	Public Class CalculatedColumn : Inherits System.Web.UI.Page
		Protected DataGrid1 As System.Web.UI.WebControls.DataGrid

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Create the Connection, DataAdapter, and DataSet.
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" + "Integrated Security=SSPI"
			Dim con As SqlConnection = New SqlConnection(connectionString)

			Dim sqlCat As String = "SELECT CategoryID, CategoryName FROM Categories"
			Dim sqlProd As String = "SELECT ProductName, CategoryID, UnitPrice FROM Products"

			Dim da As SqlDataAdapter = New SqlDataAdapter(sqlCat, con)
			Dim ds As DataSet = New DataSet()

			Try
				con.Open()

				' Fill the DataSet with the Categories table.
				da.Fill(ds, "Categories")

				' Change the command text and retrieve the Products table.
				' You could also use another DataAdapter object for this task.
				da.SelectCommand.CommandText = sqlProd
				da.Fill(ds, "Products")
			Finally
				con.Close()
			End Try

			' Define the relationship between Categories and Products.
			Dim relat As DataRelation = New DataRelation("CatProds", ds.Tables("Categories").Columns("CategoryID"), ds.Tables("Products").Columns("CategoryID"))
			' Add the relationship to the DataSet.
			ds.Relations.Add(relat)

			' Create the calculated columns.
			Dim count As DataColumn = New DataColumn("Products (#)", GetType(Integer), "COUNT(Child(CatProds).CategoryID)")
			Dim max As DataColumn = New DataColumn("Most Expensive Product", GetType(Decimal), "MAX(Child(CatProds).UnitPrice)")
			Dim min As DataColumn = New DataColumn("Least Expensive Product", GetType(Decimal), "MIN(Child(CatProds).UnitPrice)")

			' Add the columns.
			ds.Tables("Categories").Columns.Add(count)
			ds.Tables("Categories").Columns.Add(max)
			ds.Tables("Categories").Columns.Add(min)

			' Show the data.
			DataGrid1.DataSource = ds.Tables("Categories")
			DataGrid1.DataBind()
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
