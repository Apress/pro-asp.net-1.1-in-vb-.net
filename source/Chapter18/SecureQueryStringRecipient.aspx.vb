Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.Security.Cryptography

Namespace Chapter18
	''' <summary>
	''' Summary description for SecureQueryStringRecipient.
	''' </summary>
	Public Class SecureQueryStringRecipient : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim queryString As EncryptedQueryString = New EncryptedQueryString(CType(HttpContext.Current.Application("Key"), Rijndael), Request.QueryString("data"))


			Dim sb As StringBuilder = New StringBuilder()
			For Each item As DictionaryEntry In queryString
				sb.Append("Found ")
				sb.Append(item.Key)
				sb.Append(" = ")
				sb.Append(item.Value)
				sb.Append("<br>")
			Next item
			lblInfo.Text = sb.ToString()

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
