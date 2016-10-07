Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.Web.SessionState
Imports System.Security.Cryptography
Imports System.IO
Imports System.Security.Principal
Imports System.Web.Security

Namespace Chapter18
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

			' Retrieve the key.
			Dim fs As FileStream = File.OpenRead(Server.MapPath("key.config"))
			Dim key As Byte() = New Byte(31) {}
			Dim IV As Byte() = New Byte(15) {}
			fs.Read(key, 0, key.Length)
			fs.Read(IV, 0, IV.Length)
			fs.Close()

			' Create a new encryption class with this key.
			Dim crypt As Rijndael = Rijndael.Create()
			crypt.Padding = PaddingMode.Zeros
			crypt.Key = key
			crypt.IV = IV

			' Store the key information in Application state.
			Application("Key") = crypt



			' Track logged in users.
			Application("CurrentUsers") = New Hashtable()
			Application("AnonymousUsers") = New Counter()
		End Sub

		Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
			Dim anonymous As Counter = CType(Application("AnonymousUsers"), Counter)
            If (Not (anonymous Is Nothing)) Then
                SyncLock anonymous
                    anonymous.Count += 1
                End SyncLock
            End If
		End Sub

		Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
			' Check that the request has been authenticated.
			If Request.IsAuthenticated Then
				If TypeOf Context.User.Identity Is FormsIdentity Then
					' Get the email address from the ticket.
					Dim email As String = (CType(Context.User.Identity, FormsIdentity)).Ticket.UserData

					' Create a new identity with this email information.
					Dim identity As CustomIdentity = New CustomIdentity(Context.User.Identity.Name, email)

					' Create and attach a new principal (with no roles).
					Dim newPrincipal As GenericPrincipal = New GenericPrincipal(identity, New String(){})
					Context.User = newPrincipal
				End If
			End If
		End Sub

		Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
			Dim users As Hashtable = CType(Application("CurrentUsers"), Hashtable)
			Dim anonymous As Counter = CType(Application("AnonymousUsers"), Counter)

			If users.Contains(Session.SessionID) Then
				SyncLock users
					users.Remove(Session.SessionID)
				End SyncLock
			Else
				SyncLock anonymous
					anonymous.Count -= 1
				End SyncLock
			End If
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

