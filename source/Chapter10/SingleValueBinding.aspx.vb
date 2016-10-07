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

Namespace Chapter10
	''' <summary>
	''' Summary description for SingleValueBinding.
	''' </summary>
	Public Class SingleValueBinding : Inherits System.Web.UI.Page
		Protected Image1 As System.Web.UI.WebControls.Image
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected Textbox1 As System.Web.UI.WebControls.TextBox
		Protected Hyperlink1 As System.Web.UI.WebControls.HyperLink
		Protected LogoPath As System.Web.UI.HtmlControls.HtmlInputHidden

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Me.DataBind()
		End Sub

		Protected Function GetFilePath() As String
			Return "apress.gif"
		End Function

		Protected ReadOnly Property FilePath() As String
			Get
				Return "apress.gif"
			End Get
		End Property

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
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region
	End Class
End Namespace
