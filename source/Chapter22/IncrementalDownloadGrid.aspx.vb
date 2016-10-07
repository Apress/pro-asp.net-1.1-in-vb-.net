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

Namespace Chapter22
	''' <summary>
	''' Summary description for IncrementalDownloadGrid.
	''' </summary>
	Public Class IncrementalDownloadGrid : Inherits System.Web.UI.Page
		Protected DataGrid1 As System.Web.UI.WebControls.DataGrid

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

			If (Not Page.IsPostBack) Then
				' Get data.
				Dim ds As DataSet = New DataSet()
				ds.ReadXml(Server.MapPath("Books.xml"))
				DataGrid1.DataSource = ds.Tables("Book")
				DataGrid1.DataBind()
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
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region
	End Class
End Namespace
