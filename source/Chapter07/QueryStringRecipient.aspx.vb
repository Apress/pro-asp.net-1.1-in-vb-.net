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

Namespace OutputCaching
	''' <summary>
	''' Summary description for QueryStringRecipient.
	''' </summary>
	Public Class QueryStringRecipient : Inherits System.Web.UI.Page
		Protected lblDate As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			lblDate.Text = "The time is now:<br>" + DateTime.Now.ToString()
			Select Case Request.QueryString("Version")
				Case "cmdLarge"
					lblDate.Font.Size = FontUnit.XLarge
				Case "cmdNormal"
					lblDate.Font.Size = FontUnit.Large
				Case "cmdSmall"
					lblDate.Font.Size = FontUnit.Small
			End Select
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
