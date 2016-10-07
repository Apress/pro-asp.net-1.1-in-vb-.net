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
Imports System.IO

Namespace Chapter18
	''' <summary>
	''' Summary description for CreateKey.
	''' </summary>
	Public Class CreateKey : Inherits System.Web.UI.Page
		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Don't overwrite an existing key.
			If File.Exists(Server.MapPath("key.config")) Then
				Response.Write("Key already exists in key.config.")
			Else
				' Create the secret key.
				Dim crypt As Rijndael = Rijndael.Create()

				' Save the key.
				Dim fs As FileStream = File.OpenWrite(Server.MapPath("key.config"))
				fs.Write(crypt.Key, 0, crypt.Key.Length)

				' Save the initialization vector.
				fs.Write(crypt.IV, 0, crypt.IV.Length)
				fs.Close()

				Response.Write("Created key in file key.config")
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
