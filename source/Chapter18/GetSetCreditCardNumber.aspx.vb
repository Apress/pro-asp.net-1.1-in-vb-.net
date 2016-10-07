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

Namespace Chapter18
	''' <summary>
	''' Summary description for GetSetCreditCardNumber.
	''' </summary>
	Public Class GetSetCreditCardNumber : Inherits System.Web.UI.Page
		Protected txtCreditCard As System.Web.UI.WebControls.TextBox
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected WithEvents cmdSet As System.Web.UI.WebControls.Button
		Protected WithEvents cmdGet As System.Web.UI.WebControls.Button

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
'			Me.cmdGet.Click += New System.EventHandler(Me.cmdGet_Click);
'			Me.cmdSet.Click += New System.EventHandler(Me.cmdSet_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSet.Click
			' Rather than recreate this credentials object, you could store it in application state.
			Dim db As UsersDB = New UsersDB("CredentialConnectionString")
			db.SetCreditCard(User.Identity.Name, txtCreditCard.Text)
		End Sub

		Private Sub cmdGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGet.Click
			' Rather than recreate this credentials object, you could store it in application state.
			Dim db As UsersDB = New UsersDB("CredentialConnectionString")
			txtCreditCard.Text = db.GetCreditCard(User.Identity.Name)
		End Sub
	End Class
End Namespace
