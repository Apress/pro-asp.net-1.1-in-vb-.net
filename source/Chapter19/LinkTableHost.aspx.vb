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

Namespace UserControls
	''' <summary>
	''' Summary description for LinkTableHost.
	''' </summary>
	Public Class LinkTableHost : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label
		Protected LinkTable1 As LinkTable

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Set the title.
			LinkTable1.Title = "A List of Links"

			' Set the hyperlinked item list.
			Dim items As LinkTableItem() = New LinkTableItem(2) {}
			items(0) = New LinkTableItem("Test Item 1", "http://www.apress.com")
			items(1) = New LinkTableItem("Test Item 2", "http://www.apress.com")
			items(2) = New LinkTableItem("Test Item 3", "http://www.apress.com")
			LinkTable1.Items = items

			' Attach the event hander.
			AddHandler LinkTable1.LinkClicked, AddressOf LinkClicked
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

		Private Sub LinkClicked(ByVal sender As Object, ByVal e As LinkTableEventArgs)
			lblInfo.Text = "You clicked '" + e.SelectedItem.Text + "' but this page chose not to direct you to '" + e.SelectedItem.Url + "'."
			e.Cancel = True
		End Sub

	End Class
End Namespace
