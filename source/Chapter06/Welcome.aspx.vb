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
Imports System.Configuration

Namespace Chapter2
	''' <summary>
	''' Summary description for Welcome.
	''' </summary>
	Public Class Welcome : Inherits Page
		Protected lblSiteName As Label
		Protected lblWelcome As Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Put user code to initialize the page here
			lblSiteName.Text = ConfigurationSettings.AppSettings("websitename")
			lblWelcome.Text = ConfigurationSettings.AppSettings("welcomemessage")

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
