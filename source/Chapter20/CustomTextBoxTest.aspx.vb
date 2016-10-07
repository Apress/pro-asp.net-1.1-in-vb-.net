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

Namespace Chapter20
	''' <summary>
	''' Summary description for CustomTextBoxTest.
	''' </summary>
	Public Class CustomTextBoxTest : Inherits System.Web.UI.Page
		Protected WithEvents Button1 As System.Web.UI.WebControls.Button
		Protected WithEvents CustomTextBox1 As CustomServerControlsLibrary.CustomTextBox
		Protected lblInfo As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
'			Me.CustomTextBox1.TextChanged += New System.EventHandler(Me.CustomTextBox1_TextChanged);
'			Me.Button1.Click += New System.EventHandler(Me.Button1_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub CustomTextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomTextBox1.TextChanged
			lblInfo.Text = "Change event raised for CustomTextBox." + "<br>The new text is <b>" + CustomTextBox1.Text + "</b>"
		End Sub

		Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

		End Sub



	End Class
End Namespace
