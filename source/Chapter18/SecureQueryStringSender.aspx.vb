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
Imports System.Security.Cryptography

Namespace Chapter18
	''' <summary>
	''' Summary description for SecureQueryStringSender.
	''' </summary>
	Public Class SecureQueryStringSender : Inherits System.Web.UI.Page
		Protected txtData As System.Web.UI.WebControls.TextBox
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected WithEvents cmdOK As System.Web.UI.WebControls.Button

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
'			Me.cmdOK.Click += New System.EventHandler(Me.cmdOK_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
			Dim queryString As EncryptedQueryString = New EncryptedQueryString(CType(HttpContext.Current.Application("Key"), Rijndael))
			queryString("testValue1") = "This is a sample string."
			queryString("testValue2") = "6171742"
			queryString("TextBox") = txtData.Text

			' Note that when redirecting, all the values become a single
			' encrypted query string argument.
			Response.Redirect("SecureQueryStringRecipient.aspx?data=" + queryString.ToString())
		End Sub
	End Class
End Namespace
