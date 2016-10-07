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

Namespace DataCaching
	''' <summary>
	''' Summary description for SimpleCacheTest.
	''' </summary>
	Public Class SimpleCacheTest : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label
		Protected WithEvents Button1 As System.Web.UI.WebControls.Button

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

			If Me.IsPostBack Then
				lblInfo.Text += "Page posted back.<br>"
			Else
				lblInfo.Text += "Page created.<br>"
			End If

			If Cache("TestItem") Is Nothing Then
				lblInfo.Text += "Creating TestItem...<br>"
				Dim testItem As DateTime = DateTime.Now

				lblInfo.Text += "Storing TestItem in cache"
				lblInfo.Text += " for 30 seconds.<br>"
				Cache.Insert("TestItem", testItem, Nothing, DateTime.Now.AddSeconds(30), TimeSpan.Zero)
			Else
				lblInfo.Text += "Retrieving TestItem...<br>"
				Dim testItem As DateTime = CDate(Cache("TestItem"))
				lblInfo.Text += "TestItem is '" + testItem.ToString()
				lblInfo.Text += "'<br>"
			End If

			lblInfo.Text += "<br>"

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
'			Me.Button1.Click += New System.EventHandler(Me.Button1_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

		End Sub
	End Class
End Namespace
