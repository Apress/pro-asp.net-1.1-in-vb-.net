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
	''' Summary description for RolloverButtonTest.
	''' </summary>
	Public Class RolloverButtonTest : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label
		Protected WithEvents CustomImageButton1 As CustomServerControlsLibrary.CustomImageButton

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
'			Me.CustomImageButton1.ImageClicked += New System.EventHandler(Me.CustomImageButton1_ImageClicked);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub CustomImageButton1_ImageClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomImageButton1.ImageClicked
			lblInfo.Text = "You clicked the button."
		End Sub
	End Class
End Namespace
