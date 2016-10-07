Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web
Imports System.Web.Services

Namespace Chapter26
	''' <summary>
	''' Summary description for SecureService.
	''' </summary>
	Public Class SecureService : Inherits System.Web.Services.WebService
		Public Sub New()
			'CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent()
		End Sub

		#Region "Component Designer generated code"

		'Required by the Web Services Designer 
		Private components As IContainer = Nothing

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso Not components Is Nothing Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#End Region

		<WebMethod()> _
		Public Function TestAuthenticated() As String
			If (Not User.Identity.IsAuthenticated) Then
				Return "Not authenticated."
			Else
				Return "Authenticated as: " + User.Identity.Name
			End If
		End Function

	End Class
End Namespace
