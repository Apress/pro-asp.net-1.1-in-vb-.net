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
Imports System.Web.Security

Namespace Chapter15
	''' <summary>
	''' Summary description for Login.
	''' </summary>
	Public Class Login : Inherits System.Web.UI.Page
		Protected txtName As System.Web.UI.WebControls.TextBox
		Protected txtPassword As System.Web.UI.WebControls.TextBox
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected Label2 As System.Web.UI.WebControls.Label
		Protected WithEvents cmdLogin As System.Web.UI.WebControls.Button
		Protected lblStatus As System.Web.UI.WebControls.Label
		Protected RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
		Protected RegularExpressionValidator2 As System.Web.UI.WebControls.RegularExpressionValidator
		Protected Label3 As System.Web.UI.WebControls.Label

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

        End Sub
		#End Region

		Private Sub cmdLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
			' Check if the control values are valid.
			If Page.IsValid Then
				Dim store As ICredentialStore = New DatabaseCredentialStore("CredentialConnectionString", "SHA1")
				If store.Authenticate(txtName.Text, txtPassword.Text) Then
					lblStatus.Text = "Logged in."

					' Get the role information.
					Dim roles As String() = store.GetRoles(txtName.Text)

					' Convert the roles to a single string,
					' so it can be attached to the cookie.
					Dim roleList As String = String.Join("%", roles)

					' Create a new authentication ticket.
					Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, txtName.Text, DateTime.Now, DateTime.Now.AddMinutes(30), False, roleList) ' User data string

					' Encrypt the ticket.
					Dim encryptedTicket As String = FormsAuthentication.Encrypt(ticket)

					' Create the authentication cookie.
					Dim authenticationCookie As HttpCookie = New HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)

					' Attach the cookie to the response.
					Response.Cookies.Add(authenticationCookie)

					' Redirect the user back to their original URL.
					Response.Redirect(FormsAuthentication.GetRedirectUrl(txtName.Text, False))
				Else
					' Show an error message.
					lblStatus.Text = "Try again."
				End If
			End If
		End Sub
	End Class
End Namespace
