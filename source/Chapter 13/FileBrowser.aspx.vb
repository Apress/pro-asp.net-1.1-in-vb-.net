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
Imports System.Diagnostics

Namespace Chapter13
	''' <summary>
	''' Summary description for FileBrowser.
	''' </summary>
	Public Class FileBrowser : Inherits System.Web.UI.Page
		Protected WithEvents gridFileList As System.Web.UI.WebControls.DataGrid
		Protected listFile As System.Web.UI.WebControls.DataList
		Protected lblCurrentDir As System.Web.UI.WebControls.Label
		Protected WithEvents cmdUp As System.Web.UI.WebControls.Button
		Protected WithEvents gridDirList As System.Web.UI.WebControls.DataGrid

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				ShowDirectoryContents(Server.MapPath("\"))
			End If
		End Sub

		Private Sub ShowDirectoryContents(ByVal path As String)
			' Define the current directory.
			Dim dir As DirectoryInfo = New DirectoryInfo(path)

			' Get the DirectoryInfo and FileInfo objects.
			Dim files As FileInfo() = dir.GetFiles()
			Dim dirs As DirectoryInfo() = dir.GetDirectories()

			' Show the directory listing.
			lblCurrentDir.Text = "Currently showing " + path
			gridFileList.DataSource = files
			gridDirList.DataSource = dirs
			Page.DataBind()

			' Clear any selection.
			gridFileList.SelectedIndex = -1

			' Keep track of the current path.
			ViewState("CurrentPath") = path
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

		Private Sub gridDirList_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gridDirList.ItemCommand
			' Get the selected directory.
			Dim dir As String = CStr(gridDirList.DataKeys(e.Item.ItemIndex))

			' Now refresh the directory list to
			' show the selected directory.
			ShowDirectoryContents(dir)
		End Sub

		Private Sub gridFileList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridFileList.SelectedIndexChanged
			' Get the selected file.
			Dim file As String = CStr(gridFileList.DataKeys(gridFileList.SelectedIndex))

			' The DataList shows a collection (or list) of items.
			' To accomodate this design, you must add the file
			' to a collection of some sort.
			Dim files As ArrayList = New ArrayList()
			files.Add(New FileInfo(file))

			' Now show the selected file.
			listFile.DataSource = files
			listFile.DataBind()
		End Sub

		Protected Function GetVersionInfoString(ByVal path As Object) As String
			Dim info As FileVersionInfo = FileVersionInfo.GetVersionInfo(CStr(path))
			Return info.FileName + " " + info.FileVersion + "<br>" + info.ProductName + " " + info.ProductVersion
		End Function

		Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUp.Click
            Dim strPath As String = CStr(ViewState("CurrentPath"))
            strPath = Path.Combine(strPath, "..")
            strPath = Path.GetFullPath(strPath)
            ShowDirectoryContents(strPath)
		End Sub
	End Class
End Namespace
