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
	''' Summary description for MasterDetailsSingleTable.
	''' </summary>
	Public Class MasterDetailsSingleTable : Inherits System.Web.UI.Page
		Protected WithEvents gridMaster As System.Web.UI.WebControls.DataGrid
		Protected DataGrid2 As System.Web.UI.WebControls.DataGrid

		Private db As NorthwindDB = New NorthwindDB()

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				gridMaster.DataSource = db.GetCategoriesProductsDataSet()
				gridMaster.DataMember = "Categories"
				gridMaster.DataBind()
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
'			Me.gridMaster.ItemDataBound += New System.Web.UI.WebControls.DataGridItemEventHandler(Me.gridProducts_ItemDataBound);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

    Private Sub gridMaster_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridMaster.ItemDataBound
      ' Look for DataGrid items.
      If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
        ' Retrieve the DataGrid control in the second column.
        Dim gridChild As DataGrid = CType(e.Item.Cells(1).Controls(1), DataGrid)

        ' Retrieve the DataSet. Once again, this DataSet
        ' is cached, so performance will not suffer. You could
        ' also store it in a page-level variable when the Page.Load
        ' event fires, so its available for the duration of the request.
        Dim ds As DataSet = db.GetCategoriesProductsDataSet()

        ' Filter the view to only show products in the current category.
        Dim view As DataView = ds.Tables("Products").DefaultView
        view.RowFilter = "CategoryID='" & gridMaster.DataKeys(e.Item.ItemIndex) & "'"

        ' Bind the grid.
        gridChild.DataSource = ds.Tables("Products")
        gridChild.DataBind()
      End If

    End Sub
  End Class
End Namespace
