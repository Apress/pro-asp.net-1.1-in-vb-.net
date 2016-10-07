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
	''' Summary description for MultipleSelection.
	''' </summary>
	Public Class MultipleSelection : Inherits System.Web.UI.Page
		Protected WithEvents gridProducts As System.Web.UI.WebControls.DataGrid
		Protected WithEvents gridCart As System.Web.UI.WebControls.DataGrid

		Protected Label1 As System.Web.UI.WebControls.Label
		Protected Label2 As System.Web.UI.WebControls.Label
		Protected TextBox1 As System.Web.UI.WebControls.TextBox

		Private db As NorthwindDB = New NorthwindDB()
		Private ds As DataSet
		Private cart As ShoppingCart

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Update the product list.
			ds = db.GetCategoriesProductsDataSet()
			gridProducts.DataSource = ds.Tables("Products")
			gridProducts.DataBind()

			' Check for the shopping cart. If it doesn't
			' exist, create a new cart and make it available.
			If Session("Cart") Is Nothing Then
				cart = New ShoppingCart()
			Else
				cart = CType(Session("Cart"), ShoppingCart)
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
'			Me.gridCart.ItemCommand += New System.Web.UI.WebControls.DataGridCommandEventHandler(Me.gridCart_ItemCommand);
'			Me.gridProducts.SelectedIndexChanged += New System.EventHandler(Me.gridProducts_SelectedIndexChanged);
'			Me.Load += New System.EventHandler(Me.Page_Load);
'			Me.PreRender += New System.EventHandler(Me.MultipleSelection_PreRender);

		End Sub
		#End Region


		Private Sub gridProducts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridProducts.SelectedIndexChanged
			' Get the full record for the one selected row.
			Dim rows As DataRow() = ds.Tables("Products").Select("ProductID=" + gridProducts.DataKeys(gridProducts.SelectedIndex).ToString())
			Dim row As DataRow = rows(0)

			' Search to see if an item of this type is already in the cart.
			Dim inCart As Boolean = False
			For Each item As ShoppingCartItem In cart
				' Increment the number count.
				If item.ProductID = CInt(row("ProductID")) Then
					item.Units += 1
					inCart = True
					Exit For
				End If
			Next item

			' If the item isn't in the cart, add it.
			If (Not inCart) Then
        Dim newitem As ShoppingCartItem = New ShoppingCartItem(CInt(row("ProductID")), CStr(row("ProductName")), CDec(row("UnitPrice")), 1)
        cart.Add(newitem)
			End If

			' Don't keep the item selected in the product list.
			gridProducts.SelectedIndex = -1
		End Sub

		Private Sub gridCart_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gridCart.ItemCommand
			' The text box is the second control.
			' The first control in a template column
			' is always a blank LiteralControl.
			Dim txt As TextBox = CType(gridCart.Items(e.Item.DataSetIndex).Cells(3).Controls(1), TextBox)
			Try
				' Update the appropriate cart item.
				Dim newCount As Integer = Integer.Parse(txt.Text)
				If newCount > 0 Then
					cart(e.Item.DataSetIndex).Units = newCount
				Else If newCount = 0 Then
					cart.RemoveAt(e.Item.DataSetIndex)
				End If
			Catch
				' Ignore invalid (non-numeric) entries.
			End Try
		End Sub

		Private Sub MultipleSelection_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
			' Store the shopping cart.
			Session("Cart") = cart

			' Show the shopping cart in the grid.
			gridCart.DataSource = cart
			gridCart.DataBind()
		End Sub
	End Class


	Public Class ShoppingCartItem
  Private nProductID As Integer
  Private strProductName As String
  Private dUnitPrice As Decimal
  Private nUnits As Integer

  Public ReadOnly Property ProductID() As Integer
   Get
    Return nProductID
   End Get
  End Property
  Public ReadOnly Property ProductName() As String
   Get
    Return strProductName
   End Get
  End Property
  Public ReadOnly Property UnitPrice() As Decimal
   Get
    Return dUnitPrice
   End Get
  End Property
  Public Property Units() As Integer
   Get
    Return nUnits
   End Get
   Set(ByVal Value As Integer)
    nUnits = Value
   End Set
  End Property
  Public ReadOnly Property Total() As Decimal
   Get
    Return Units * UnitPrice
   End Get
  End Property
  Public Sub New(ByVal nProductID As Integer, ByVal strProductName As String, ByVal dUnitPrice As Decimal, ByVal nUnits As Integer)
   Me.nProductID = nProductID
   Me.strProductName = strProductName
   Me.dUnitPrice = dUnitPrice
   Me.nUnits = nUnits
  End Sub
 End Class


	Public Class ShoppingCart : Inherits CollectionBase
		Public Default Property Item(ByVal index As Integer) As ShoppingCartItem
			Get
				Return(CType(List(index), ShoppingCartItem))
			End Get
			Set
				List(index) = Value
			End Set
		End Property
		Public Function Add(ByVal value As ShoppingCartItem) As Integer
			Return(List.Add(value))
		End Function
		Public Function IndexOf(ByVal value As ShoppingCartItem) As Integer
			Return(List.IndexOf(value))
		End Function
		Public Sub Insert(ByVal index As Integer, ByVal value As ShoppingCartItem)
			List.Insert(index, value)
		End Sub
		Public Sub Remove(ByVal value As ShoppingCartItem)
			List.Remove(value)
		End Sub
		Public Function Contains(ByVal value As ShoppingCartItem) As Boolean
			Return(List.Contains(value))
		End Function
	End Class


End Namespace
