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
	Public Class LoginNoCookie : Inherits System.Web.UI.Page
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
'			Me.cmdLogin.Click += New System.EventHandler(Me.cmdLogin_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
			' Check if the control values are valid.
			If Page.IsValid Then
				If FormsAuthentication.Authenticate(txtName.Text, txtPassword.Text) Then
					lblStatus.Text = "Logged in."

					' Create an authentication ticket.
					Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(txtName.Text, False, 30)

					' Encrypt it.
					Dim encryptedTicket As String = FormsAuthentication.Encrypt(ticket)

					' Create a string to hold the redirect URL.
					Dim destinationURL As String

					' Get the original redirection URL.
					Dim originalURL As String = FormsAuthentication.GetRedirectUrl(txtName.Text,False)


					' Check whether the original URL has query parameters/
					If originalURL.IndexOf("?") = -1 Then
						' Add the encrypted authentication ticket as the only parameter.
						destinationURL = originalURL + "?" + FormsAuthentication.FormsCookieName + "=" + encryptedTicket
					Else
						' Add the encrypted authentication ticket as an additional parameter.
						destinationURL = originalURL + "&" + FormsAuthentication.FormsCookieName + "=" + encryptedTicket
					End If
					Response.Redirect(destinationURL)
				Else
					' Show an error message.
					lblStatus.Text = "Try again."
				End If

			End If
		End Sub
	End Class
End Namespace
