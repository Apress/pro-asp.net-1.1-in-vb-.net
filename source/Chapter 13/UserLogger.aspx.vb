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

Namespace Chapter13
	''' <summary>
	''' Summary description for UserLogger.
	''' </summary>
	Public Class UserLogger : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label
		Protected WithEvents cmdRead As System.Web.UI.WebControls.Button
		Protected Button1 As System.Web.UI.WebControls.Button
		Protected WithEvents cmdDelete As System.Web.UI.WebControls.Button

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				Log("Page loaded for the first time.")
			Else
				Log("Page posted back.")
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
'			Me.cmdRead.Click += New System.EventHandler(Me.cmdRead_Click);
'			Me.cmdDelete.Click += New System.EventHandler(Me.cmdDelete_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRead.Click
			If Not ViewState("LogFile") Is Nothing Then
				Dim fileName As String = CStr(ViewState("LogFile"))
				Dim fs As FileStream = New FileStream(fileName, FileMode.Open)
				Try
					Dim r As StreamReader = New StreamReader(fs)

					' Read line by line (allows you to add
					' line breaks to the web page).
					Dim line As String
					Do
						line = r.ReadLine()
						If Not line Is Nothing Then
							lblInfo.Text += line + "<br>"
						End If
					Loop While Not line Is Nothing

					r.Close()
				Finally
					If TypeOf fs Is IDisposable Then
						Dim disp As IDisposable = fs
						disp.Dispose()
					End If
				End Try
			End If
		End Sub

		Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
			If Not ViewState("LogFile") Is Nothing Then
				File.Delete(CStr(ViewState("LogFile")))
			End If
		End Sub

		Private Sub Log(ByVal message As String)
			' Check for the file.	
			Dim mode As FileMode
			If ViewState("LogFile") Is Nothing Then
				' First, create a unique user-specific file name.
				ViewState("LogFile") = GetFileName()

				' The log file must be created.
				mode = FileMode.Create
			Else
				' Add to the existing file.
				mode = FileMode.Append
			End If

			' Write the message.
			' A using block ensures the file is automatically closed,
			' even in the case of error.
			Dim fileName As String = CStr(ViewState("LogFile"))
			Dim fs As FileStream = New FileStream(fileName, mode)
			Try
				Dim w As StreamWriter = New StreamWriter(fs)
				w.WriteLine(DateTime.Now)
				w.WriteLine(message)
				w.Close()
			Finally
				If TypeOf fs Is IDisposable Then
					Dim disp As IDisposable = fs
					disp.Dispose()
				End If
			End Try
		End Sub

		Private Function GetFileName() As String
			' Create a unique filename.
			Dim fileName As String = "user." + Guid.NewGuid().ToString()

			' Put the file in the current web application path.
			Return Path.Combine(Request.PhysicalApplicationPath, fileName)
		End Function
	End Class
End Namespace
