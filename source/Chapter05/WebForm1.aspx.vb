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
	''' Summary description for WebForm1.
	''' </summary>
	Public Class WebForm1 : Inherits System.Web.UI.Page
		Protected TextBox1 As System.Web.UI.HtmlControls.HtmlInputText

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Only perform the initialization the first time the page is requested.
			' After that, this information is tracked in view state.
			If (Not Page.IsPostBack) Then
				' Set the style attributes to configure appearance.
				TextBox1.Style("font-size") = "20px"
				TextBox1.Style("color") = "red"
				' Use a slightly different but equivalent syntax
				' for setting a style attribute.
				TextBox1.Style.Add("background-color", "lightyellow")

				' Set the default text.
				TextBox1.Value = "<Enter e-mail address here>"

				' Set other non-standard attributes.
				TextBox1.Attributes("onfocus") = "alert(TextBox1.value)"

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
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region
	End Class
End Namespace
