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
	''' Summary description for PageProcessor_Start.
	''' </summary>
	Public Class PageProcessor_Start : Inherits System.Web.UI.Page
		Protected WithEvents cmdGo As System.Web.UI.WebControls.Button

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

    End Sub
		#End Region

		Private Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGo.Click
			Server.Transfer("PageProcessor.aspx?Page=PageProcessor_Target.aspx")
		End Sub

  End Class
End Namespace
