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
	''' Summary description for TitledTextBoxTest.
	''' </summary>
	Public Class TitledTextBoxTest : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label
		Protected Button1 As System.Web.UI.WebControls.Button
		Protected WithEvents TitledTextBox1 As CustomServerControlsLibrary.TitledTextBox

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
'			Me.TitledTextBox1.TextChanged += New System.EventHandler(Me.TitledTextBox1_TextChanged);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub TitledTextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TitledTextBox1.TextChanged
			lblInfo.Text = "Text changed."
		End Sub
	End Class
End Namespace
