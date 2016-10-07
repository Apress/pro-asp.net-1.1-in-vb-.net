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
Imports System.Net

Namespace StateManagement
	''' <summary>
	''' Summary description for CookieExample.
	''' </summary>
	Public Class CookieExample : Inherits System.Web.UI.Page
		Protected lblWelcome As System.Web.UI.WebControls.Label
		Protected txtName As System.Web.UI.WebControls.TextBox
		Protected WithEvents cmdStore As System.Web.UI.WebControls.Button
		Protected Label1 As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim cookie As HttpCookie = Request.Cookies("Preferences")
			If cookie Is Nothing Then
				lblWelcome.Text = "<b>Unknown Customer</b>"
			Else
				lblWelcome.Text = "<b>Cookie Found.</b><br><br>"
				lblWelcome.Text += "Welcome, " + cookie("Name")
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
'			Me.cmdStore.Click += New System.EventHandler(Me.cmdStore_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdStore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStore.Click
			Dim cookie As HttpCookie = Request.Cookies("Preferences")
			If cookie Is Nothing Then
				cookie = New HttpCookie("Preferences")
			End If

			cookie("Name") = txtName.Text
			cookie.Expires = DateTime.Now.AddYears(1)
			Response.Cookies.Add(cookie)

			lblWelcome.Text = "<b>Cookie Created.</b><br><br>"
			lblWelcome.Text += "New Customer: " + cookie("Name")

		End Sub
	End Class
End Namespace
