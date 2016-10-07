Imports Microsoft.VisualBasic
Imports System
Imports System.Web.Security

Namespace Chapter15
	Public Interface ICredentialStore
		Function Authenticate(ByVal userName As String, ByVal password As String) As Boolean
		Function Authenticate(ByVal userName As String, ByVal password As String, <System.Runtime.InteropServices.Out()> ByRef userData As String) As Boolean
		Function GetRoles(ByVal userName As String) As String()
	End Interface

	Public Class DefaultCredentialStore : Implements ICredentialStore
		Public Function Authenticate(ByVal userName As String, ByVal password As String) As Boolean Implements ICredentialStore.Authenticate
			Return FormsAuthentication.Authenticate(userName, password)
		End Function

		Public Function Authenticate(ByVal userName As String, ByVal password As String, <System.Runtime.InteropServices.Out()> ByRef userData As String) As Boolean Implements ICredentialStore.Authenticate
			userData = Nothing

			' Pass the call on to the other version of the 
			' Authenticate() method.
			Return Authenticate(userName, password)
		End Function

		Public Function GetRoles(ByVal userName As String) As String() Implements ICredentialStore.GetRoles
			Return New String(){}
		End Function
	End Class

End Namespace
