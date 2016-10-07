Imports Microsoft.VisualBasic
	Imports System
	Imports System.Data
	Imports System.Drawing
	Imports System.Web
	Imports System.Web.UI.WebControls
	Imports System.Web.UI.HtmlControls
Namespace UserControls

	''' <summary>
	'''		Summary description for LinkTable.
	''' </summary>
	Public Class LinkTable : Inherits System.Web.UI.UserControl
		Protected WithEvents listContent As System.Web.UI.WebControls.DataList

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
		'''		Required method for Designer support - do not modify
		'''		the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
'			Me.listContent.ItemCommand += New System.Web.UI.WebControls.DataListCommandEventHandler(Me.listContent_ItemCommand);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Protected lblTitle As System.Web.UI.WebControls.Label

		Public Property Title() As String
			Get
				Return lblTitle.Text
			End Get
			Set
				lblTitle.Text = Value
			End Set
		End Property

		Private ltiItem As LinkTableItem()
		Public Property Items() As LinkTableItem()
			Get
				Return ltiItem
			End Get
			Set
				ltiItem = Value

				' Refresh the grid.
				listContent.DataSource = ltiItem
				listContent.DataBind()
			End Set
		End Property

		Public Event LinkClicked As LinkClickedEventHandler
		Private Sub listContent_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles listContent.ItemCommand
			If Not LinkClickedEvent Is Nothing Then
				' Get the HyperLink object that was clicked.
				Dim link As LinkButton = CType(e.Item.Controls(1), LinkButton)

				' Construct the event arguments.
				Dim item As LinkTableItem = New LinkTableItem(link.Text, link.CommandArgument)
				Dim args As LinkTableEventArgs = New LinkTableEventArgs(item)

				' Fire the event.
				RaiseEvent LinkClicked(Me, args)

				' Navigate to the link if the event recipient didn't
				' cancel the operation.
				If (Not args.Cancel) Then
					Response.Redirect(item.Url)
				End If
			End If
		End Sub
	End Class

	Public Delegate Sub LinkClickedEventHandler(ByVal sender As Object, ByVal e As LinkTableEventArgs)

	Public Class LinkTableItem
		Private strText As String
		Public Property Text() As String
			Get
				Return strText
			End Get
			Set
				strText = Value
			End Set
		End Property

		Private strURL As String
		Public Property Url() As String
			Get
				Return strURL
			End Get
			Set
				strURL = Value
			End Set
		End Property

		' Default constructor.
		Public Sub New()
		End Sub

    Public Sub New(ByVal strText As String, ByVal strURL As String)
      Me.strText = strText
      Me.strURL = strURL
    End Sub
  End Class

	Public Class LinkTableEventArgs : Inherits EventArgs
		Private ltiSelectedItem As LinkTableItem
		Public ReadOnly Property SelectedItem() As LinkTableItem
			Get
				Return ltiSelectedItem
			End Get
		End Property

		Private bCancel As Boolean = False
		Public Property Cancel() As Boolean
			Get
				Return bCancel
			End Get
			Set
				bCancel=Value
			End Set
		End Property

		Public Sub New(ByVal item As LinkTableItem)
			ltiSelectedItem = item
		End Sub
	End Class
End Namespace
