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

Namespace Chapter22
	''' <summary>
	''' Summary description for RolloverTest.
	''' </summary>
	Public Class RolloverTest : Inherits System.Web.UI.Page
		Protected RollOverButton2 As CustomServerControlsLibrary.RollOverButton
		Protected WithEvents RollOverButton1 As CustomServerControlsLibrary.RollOverButton

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
'			Me.RollOverButton1.ImageClicked += New System.EventHandler(Me.RollOverButton1_ImageClicked);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub RollOverButton1_ImageClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles RollOverButton1.ImageClicked
			Response.Write("Message clicked.")
		End Sub
	End Class
End Namespace
