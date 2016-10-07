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
Imports DatabaseComponent

Namespace Chapter11
	''' <summary>
	''' Summary description for Details.
	''' </summary>
	Public Class Details : Inherits System.Web.UI.Page
		Protected WithEvents gridDetails As System.Web.UI.WebControls.DataGrid
		Protected listDetail As System.Web.UI.WebControls.DataList
		Private db As NorthwindDB = New NorthwindDB()

		Private valueInStock As Decimal = 0

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If Not Session("SelectedCategory") Is Nothing Then
				Dim ds As DataSet = db.GetCategoriesProductsDataSet()
				Dim view As DataView = ds.Tables("Products").DefaultView
				view.RowFilter = "CategoryID =" + Session("SelectedCategory").ToString()

				' The easiest way to calculate the total value for
				' the displayed records is to work through the DataView,
				' not the DataTable. That's because the DataView will
				' include only the rows in the apporopriate category.
				For Each rowView As DataRowView In view
					Dim row As DataRow = rowView.Row
					valueInStock += CShort(row("UnitsInStock")) * CDec(row("UnitPrice"))
				Next rowView

				' Bind the grid.
				gridDetails.DataSource = view
				gridDetails.DataBind()
			End If
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
'			Me.gridDetails.ItemCreated += New System.Web.UI.WebControls.DataGridItemEventHandler(Me.gridDetails_ItemCreated);
'			Me.gridDetails.SelectedIndexChanged += New System.EventHandler(Me.gridDetails_SelectedIndexChanged);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub gridDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridDetails.SelectedIndexChanged
			Dim ds As DataSet = db.GetCategoriesProductsDataSet()
			Dim view As DataView = New DataView(ds.Tables("Products"))
			view.RowFilter = "ProductID =" + gridDetails.DataKeys(gridDetails.SelectedIndex).ToString()
			listDetail.DataSource = view
			listDetail.DataBind()
		End Sub


		Private Sub gridDetails_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridDetails.ItemCreated
			' Check if this item is a footer.
			Dim itemType As ListItemType = e.Item.ItemType
			If (itemType = ListItemType.Footer) Then
				' Set the first cell to span over the entire row.
				e.Item.Cells(0).ColumnSpan = 3
				e.Item.Cells(0).HorizontalAlign = HorizontalAlign.Center

				' Remove the unneeded cells.
				e.Item.Cells.RemoveAt(2)
				e.Item.Cells.RemoveAt(1)

				' Add the text.
				e.Item.Cells(0).Text = "Total value in stock: " + valueInStock.ToString("C")
			End If

		End Sub

	End Class
End Namespace
