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

Namespace FormsSecurity_UserList
	''' <summary>
	''' Summary description for PasswordHasher.
	''' </summary>
	Public Class PasswordHasher : Inherits System.Web.UI.Page
		Protected txtPassword As System.Web.UI.WebControls.TextBox
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected WithEvents cmdHash As System.Web.UI.WebControls.Button
		Protected optSHA1 As System.Web.UI.WebControls.RadioButton
		Protected optMD5 As System.Web.UI.WebControls.RadioButton
		Protected Label2 As System.Web.UI.WebControls.Label
		Protected txtHash As System.Web.UI.WebControls.TextBox

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
'			Me.cmdHash.Click += New System.EventHandler(Me.cmdHash_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdHash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdHash.Click
			Dim algorithm As String = ""

			If optSHA1.Checked Then
				algorithm = "SHA1"
			Else
				algorithm = "MD5"
			End If

			txtHash.Text = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, algorithm)

		End Sub
	End Class
End Namespace
