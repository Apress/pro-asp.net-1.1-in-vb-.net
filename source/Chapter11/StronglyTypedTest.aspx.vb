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

Namespace Chapter11
	''' <summary>
	''' Summary description for StronglyTypedTest.
	''' </summary>
	Public Class StronglyTypedTest : Inherits System.Web.UI.Page
		Protected lblOutput As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Create the Connection, DataAdapter, and DataSet.
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" + "Integrated Security=SSPI"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim sqlProducts As String = "SELECT * FROM Products"
			Dim sqlCategories As String = "SELECT * FROM Categories"

			' Create the strongly typed DataSet.
			Dim ds As NorthwindDataSet = New NorthwindDataSet()

			' Fill the DataSet.
			Dim da As SqlDataAdapter = New SqlDataAdapter(sqlCategories, con)
			da.Fill(ds.Categories)
			da.SelectCommand.CommandText = sqlProducts
			da.Fill(ds.Products)

			' Build the HTML string.
			Dim htmlStr As StringBuilder = New StringBuilder("")
			For Each row As NorthwindDataSet.CategoriesRow In ds.Categories
				htmlStr.Append("<b>")
				htmlStr.Append(row.CategoryName)
				htmlStr.Append("</b><br><i>")
				htmlStr.Append(row.Description)
				htmlStr.Append("</i><br>")

				' Get the related product rows.
				' Not the this uses the helper method GetProductsRows()
				' instead of the generic GetChildRows().
				' The advantage is you don't need to specify the relationship name.
				Dim products As NorthwindDataSet.ProductsRow() = row.GetProductsRows()
				For Each child As NorthwindDataSet.ProductsRow In products
					htmlStr.Append("<li>")
					htmlStr.Append(child.ProductName)
					htmlStr.Append("</li>")
				Next child
				htmlStr.Append("<br><br>")
			Next row

			' Show the generated HTML.
			lblOutput.Text = htmlStr.ToString()
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
