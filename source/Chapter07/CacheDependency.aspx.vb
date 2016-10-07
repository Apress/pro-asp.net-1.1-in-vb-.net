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

Namespace DataCaching
	''' <summary>
	''' Summary description for CacheDependency.
	''' </summary>
	Public Class CacheDependency : Inherits System.Web.UI.Page
		Protected WithEvents cmdModfiy As System.Web.UI.WebControls.Button
		Protected WithEvents cmdGetItem As System.Web.UI.WebControls.Button
		Protected lblInfo As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Me.IsPostBack) Then
				lblInfo.Text += "Creating dependent item...<br>"
				Cache.Remove("Dependent")
				Dim dependency As System.Web.Caching.CacheDependency = New System.Web.Caching.CacheDependency(Server.MapPath("dependency.txt"))
				Dim item As String = "Dependent cached item"
				lblInfo.Text += "Adding dependent item<br>"
				Cache.Insert("Dependent", item, dependency)
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
'			Me.cmdModfiy.PreRender += New System.EventHandler(Me.cmdModfiy_PreRender);
'			Me.cmdModfiy.Click += New System.EventHandler(Me.cmdModfiy_Click);
'			Me.cmdGetItem.Click += New System.EventHandler(Me.cmdGetItem_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdGetItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGetItem.Click
			If Cache("Dependent") Is Nothing Then
				lblInfo.Text += "Cache item no longer exits.<br>"
			Else
				Dim cacheInfo As String = CStr(Cache("Dependent"))
				lblInfo.Text += "Retrieved item with text: '" + cacheInfo + "'<br>"
			End If
		End Sub

		Private Sub cmdModfiy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdModfiy.Click
			lblInfo.Text += "Modifying dependency.txt file.<br>"
			Dim w As StreamWriter= File.CreateText(Server.MapPath("dependency.txt"))
			w.Write(DateTime.Now)
			w.Flush()
			w.Close()
		End Sub

		Private Sub cmdModfiy_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdModfiy.PreRender
			lblInfo.Text += "<br>"
		End Sub
	End Class
End Namespace
