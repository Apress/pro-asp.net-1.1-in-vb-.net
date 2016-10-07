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

Namespace Chapter05
	''' <summary>
	''' Summary description for AdTest.
	''' </summary>
	Public Class AdTest : Inherits System.Web.UI.Page
		Protected lnkBanner As System.Web.UI.WebControls.HyperLink
		Protected WithEvents AdRotator1 As System.Web.UI.WebControls.AdRotator

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
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
'			Me.AdRotator1.AdCreated += New System.Web.UI.WebControls.AdCreatedEventHandler(Me.AdRotator1_AdCreated);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub AdRotator1_AdCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AdCreatedEventArgs) Handles AdRotator1.AdCreated
			' Synchronize the Hyperlink control.
			lnkBanner.NavigateUrl = e.NavigateUrl
			' Synchronize the text of the link.
			lnkBanner.Text = "Click here for information about our sponsor: "
			lnkBanner.Text += e.AlternateText
		End Sub
	End Class
End Namespace
