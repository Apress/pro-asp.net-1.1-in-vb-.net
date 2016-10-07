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
Imports Chapter26_WebClient.SoapSecurity

Namespace SecurityTest
	''' <summary>
	''' Summary description for SoapSecurityTest.
	''' </summary>
	Public Class SoapSecurityTest : Inherits System.Web.UI.Page
		Protected Label2 As System.Web.UI.WebControls.Label
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected txtPassword As System.Web.UI.WebControls.TextBox
		Protected txtUserName As System.Web.UI.WebControls.TextBox
		Protected DataGrid1 As System.Web.UI.WebControls.DataGrid
		Protected lblInfo As System.Web.UI.WebControls.Label
		Protected WithEvents cmdCall As System.Web.UI.WebControls.Button

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
'			Me.cmdCall.Click += New System.EventHandler(Me.cmdCall_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdCall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCall.Click
			Dim proxy As SoapSecurityService = New SoapSecurityService()

			Try
				proxy.Login(txtUserName.Text, txtPassword.Text, HashAlgorithm.SHA1)
				DataGrid1.DataSource = proxy.GetEmployees()
				DataGrid1.DataBind()
				lblInfo.Text = ""
			Catch err As Exception
				lblInfo.Text = err.Message
			End Try
		End Sub
	End Class
End Namespace
