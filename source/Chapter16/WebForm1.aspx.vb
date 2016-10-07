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
Imports System.Security.Principal

Namespace Chapter16
	''' <summary>
	''' Summary description for WebForm1.
	''' </summary>
	Public Class WebForm1 : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If Request.IsAuthenticated Then
				' Display generic identity information.
				lblInfo.Text = "<b>Name: </b>" + User.Identity.Name
				lblInfo.Text += "<br><b>Authenticated With: </b>"
				lblInfo.Text += User.Identity.AuthenticationType

				Dim principal As WindowsPrincipal = CType(User, WindowsPrincipal)
				lblInfo.Text += "<br><b>Power user? </b>"
				lblInfo.Text += principal.IsInRole(WindowsBuiltInRole.PowerUser).ToString()

				Dim identity As WindowsIdentity = CType(User.Identity, WindowsIdentity)
				lblInfo.Text += "<br><b>Token: </b>"
				lblInfo.Text += identity.Token.ToString()
				lblInfo.Text += "<br><b>Guest? </b>"
				lblInfo.Text += identity.IsGuest.ToString()
				lblInfo.Text += "<br><b>System? </b>"
				lblInfo.Text += identity.IsSystem.ToString()



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
