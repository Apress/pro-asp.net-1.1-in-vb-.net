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
Imports System.Security.Principal

Namespace Chapter16
	''' <summary>
	''' Summary description for ImpersonationTest.
	''' </summary>
	Public Class ImpersonationTest : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If TypeOf User Is WindowsPrincipal Then
				DisplayIdentity()

				' Impersonate the IIS identity.
				Dim id As WindowsIdentity
				id = CType(User.Identity, WindowsIdentity)
				Dim impersonateContext As WindowsImpersonationContext
				impersonateContext = id.Impersonate()
				DisplayIdentity()

				' Revert to the original ID as shown below.
				impersonateContext.Undo()
				DisplayIdentity()
			Else
				' User isn't Windows authenticated.
				' Throw an error to or take other steps.
			End If
		End Sub

		Private Sub DisplayIdentity()
			' Get the identity under which the code is currently executing.
			Dim identity As WindowsIdentity = WindowsIdentity.GetCurrent()
			lblInfo.Text += "Executing as: " + identity.Name + "<br>"
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
