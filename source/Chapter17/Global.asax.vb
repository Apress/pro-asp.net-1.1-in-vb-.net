Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.Security
Imports System.Security.Principal

Namespace Chapter17
	''' <summary>
	''' Summary description for Global.
	''' </summary>
	Public Class Global : Inherits System.Web.HttpApplication
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
			' Check that the request has been authenticated.
			If Request.IsAuthenticated Then
				' Get the roles from the ticket.
				Dim roleList As String = (CType(Context.User.Identity, FormsIdentity)).Ticket.UserData

				' Split the roles into an array.
				Dim roles As String() = roleList.Split("%"c)

				' Create a new GenericPrincipal with this role information.
				Dim newPrincipal As GenericPrincipal = New GenericPrincipal(Context.User.Identity, roles)

				' Add the principal to the security context
				' (replacing the current GenericPrincipal).
				Context.User = newPrincipal
			End If
		End Sub

		Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		#Region "Web Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
		End Sub
		#End Region
	End Class
End Namespace

