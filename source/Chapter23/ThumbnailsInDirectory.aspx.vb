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
Imports System.IO

Namespace Chapter23
	''' <summary>
	''' Summary description for ThumbnailsInDirectory.
	''' </summary>
	Public Class ThumbnailsInDirectory : Inherits System.Web.UI.Page
		Protected listThumbs As System.Web.UI.WebControls.DataList
		Protected WithEvents cmdShow As System.Web.UI.WebControls.Button
		Protected txtDir As System.Web.UI.WebControls.TextBox
		Protected Label1 As System.Web.UI.WebControls.Label



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
'			Me.cmdShow.Click += New System.EventHandler(Me.cmdShow_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdShow.Click
			' Get a string array with all the image files.
			Dim dir As DirectoryInfo = New DirectoryInfo(txtDir.Text)
			listThumbs.DataSource = dir.GetFiles("*.bmp")

			' Bind the string array.
			listThumbs.DataBind()
		End Sub

		Protected Function GetImageUrl(ByVal path As Object) As String
			Return "ThumbnailViewer.aspx?x=50&y=50&FilePath=" + Server.UrlEncode(CStr(path))
		End Function

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		End Sub


	End Class
End Namespace
