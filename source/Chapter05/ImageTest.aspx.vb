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
	''' Summary description for ImageTest.
	''' </summary>
	Public Class ImageTest : Inherits System.Web.UI.Page
		Protected lblResult As System.Web.UI.WebControls.Label
		Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton

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
'			Me.ImageButton1.Click += New System.Web.UI.ImageClickEventHandler(Me.ImageButton1_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
			lblResult.Text = "You clicked at (" + e.X.ToString() + ", " + e.Y.ToString() + "). "

			If (e.Y < 100) AndAlso (e.Y > 20) AndAlso (e.X > 20) AndAlso (e.X < 275) Then
				lblResult.Text += "You clicked on the button surface."
			Else
				lblResult.Text += "You clicked the button border."
			End If
		End Sub
	End Class
End Namespace
