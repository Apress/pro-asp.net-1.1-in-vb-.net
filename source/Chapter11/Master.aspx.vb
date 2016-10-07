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
	''' Summary description for Master.
	''' </summary>
	Public Class Master : Inherits System.Web.UI.Page
		Protected WithEvents gridMaster As System.Web.UI.WebControls.DataGrid

		Private db As NorthwindDB = New NorthwindDB()

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				Session("SelectedCategory") = Nothing
			End If
			' Refresh the DataSet every time, even for postbacks.
			' This is not a performance drag, because the DataSet
			' is usuaslly cached.
			gridMaster.DataSource = db.GetCategoriesProductsDataSet()
			gridMaster.DataMember = "Categories"
			gridMaster.DataBind()
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
'			Me.gridMaster.SelectedIndexChanged += New System.EventHandler(Me.gridMaster_SelectedIndexChanged);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub gridMaster_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridMaster.SelectedIndexChanged
			Session("SelectedCategory") = gridMaster.DataKeys(gridMaster.SelectedIndex)

			' Use JavaScript to trigger the redirect in the other window.
			Dim frameScript As String = "<script language='javascript'>" + "window.parent.frames(1).location='Details.aspx';" + "</script>"
			Page.RegisterStartupScript("FrameScript", frameScript)

		End Sub
	End Class
End Namespace
