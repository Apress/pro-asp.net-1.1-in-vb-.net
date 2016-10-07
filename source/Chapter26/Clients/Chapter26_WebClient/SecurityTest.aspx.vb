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
Imports Chapter26_WebClient.SecureWebService

Namespace SecureServiceTest
	''' <summary>
	''' Summary description for WebForm1.
	''' </summary>
	Public Class WebForm1 : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label
		Protected WithEvents cmdAuthenticated As System.Web.UI.WebControls.Button
		Protected Label2 As System.Web.UI.WebControls.Label
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected txtPassword As System.Web.UI.WebControls.TextBox
		Protected txtUserName As System.Web.UI.WebControls.TextBox
		Protected WithEvents cmdUnauthenticated As System.Web.UI.WebControls.Button

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Put user code to initialize the page here
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
'			Me.cmdAuthenticated.Click += New System.EventHandler(Me.cmdAuthenticated_Click);
'			Me.cmdUnauthenticated.Click += New System.EventHandler(Me.cmdUnauthenticated_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdUnauthenticated_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUnauthenticated.Click
			Dim securedService As SecureService = New SecureService()
			lblInfo.Text = securedService.TestAuthenticated()

		End Sub

		Private Sub cmdAuthenticated_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAuthenticated.Click
			Dim securedService As SecureService = New SecureService()

			' Specity some user credentials for the web service.
			Dim credentials As NetworkCredential = New NetworkCredential(txtUserName.Text, txtPassword.Text)
			securedService.Credentials = credentials

			lblInfo.Text = securedService.TestAuthenticated()

		End Sub
	End Class
End Namespace
