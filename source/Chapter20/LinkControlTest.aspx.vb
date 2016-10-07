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

Namespace CustomServerControls
	''' <summary>
	''' Summary description for LinkControlTest.
	''' </summary>
	Public Class LinkControlTest : Inherits System.Web.UI.Page
		Protected LinkWebControl1 As CustomServerControlsLibrary.LinkWebControl
		Protected lblHtml As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

			' Create the in-memory objects that will catch the rendered output.
			Dim writer As StringWriter = New StringWriter()
			Dim output As HtmlTextWriter = New HtmlTextWriter(writer)

			' Render the control.
			LinkWebControl1.RenderControl(output)

			' Display the HTML (and encode it properly so that
			' it appears as text in the browser).
			lblHtml.Text = "The HTML for LinkWebControl1 is<br><blockquote>" + Server.HtmlEncode(writer.ToString()) + "</blockquote>"
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
