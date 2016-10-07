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

Namespace Chapter3
	''' <summary>
	''' Summary description for PageFlow.
	''' </summary>
	Public Class PageFlowTracing : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label
		Protected WithEvents Button1 As System.Web.UI.WebControls.Button

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Trace.IsEnabled=True
			lblInfo.Text += "Page.Load event handled.<br>"
			If Page.IsPostBack Then
				lblInfo.Text += "<b>This is the second time you've seen this page.</b><br>"
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
'			Me.Button1.Click += New System.EventHandler(Me.Button1_Click);
'			Me.Unload += New System.EventHandler(Me.PageFlow_Unload);
'			Me.Load += New System.EventHandler(Me.Page_Load);
'			Me.Init += New System.EventHandler(Me.PageFlow_Init);
'			Me.PreRender += New System.EventHandler(Me.PageFlow_PreRender);

		End Sub
		#End Region

		Private Sub PageFlow_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
			lblInfo.Text += "Page.Init event handled.<br>"
		End Sub

		Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
			' You can supply just a message, or include a category label,
			' as shown here.
			Trace.Write("Button1_Click", "About to update the label.")
			lblInfo.Text += "Button1.Click event handled.<br>"
			Trace.Write("Button1_Click", "Label updated.")
		End Sub

		Private Sub PageFlow_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
			lblInfo.Text += "Page.PreRender event handled.<br>"
		End Sub

		Private Sub PageFlow_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
			' This text never appears because the HTML is already rendered for the page.
			lblInfo.Text += "Page.Unload event handled.<br>"
		End Sub

	End Class
End Namespace
