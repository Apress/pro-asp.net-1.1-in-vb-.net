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

Namespace Chapter05
	''' <summary>
	''' Summary description for FileUpload.
	''' </summary>
	Public Class FileUpload : Inherits System.Web.UI.Page
		Protected Uploader As System.Web.UI.HtmlControls.HtmlInputFile
		Protected lblStatus As System.Web.UI.HtmlControls.HtmlGenericControl
		Protected WithEvents cmdUpload As System.Web.UI.HtmlControls.HtmlInputButton

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
'			Me.cmdUpload.ServerClick += New System.EventHandler(Me.cmdUpload_ServerClick);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdUpload_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpload.ServerClick
			' Check if a file was submitted.
			If Uploader.PostedFile.ContentLength <> 0 Then
				Try
					If Uploader.PostedFile.ContentLength > 1064 Then
						' This exceeds the size limit we want to allow,.
						' You should check the size to prevent a denial of
						' service attack that attempts to fill up your
						' web server's hard drive.
						' You might also want to check the amount of 
						' remaining free space.
						lblStatus.InnerText = "Too large. This file is not allowed"
					Else
						' Retrieve the physical directory path for the Upload subdirectory.
						Dim destDir As String = Server.MapPath("./Upload")

						' Extract the filename part from the full path of the original file.
						Dim fileName As String = System.IO.Path.GetFileName(Uploader.PostedFile.FileName)

						' Combine the destination directory with the filename.
						Dim destPath As String = System.IO.Path.Combine(destDir, fileName)

						' Save the file on the server.
						Uploader.PostedFile.SaveAs(destPath)
						lblStatus.InnerText = "Thanks for submitting your file"
					End If
				Catch err As Exception
					lblStatus.InnerText = err.Message
				End Try
			End If

		End Sub
	End Class
End Namespace
