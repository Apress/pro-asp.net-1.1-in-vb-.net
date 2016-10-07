Imports Microsoft.VisualBasic
Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.Web.Security

Namespace Chapter15
	''' <summary>
	''' Summary description for DatabaseCredentialStore.
	''' </summary>
	Public Class DatabaseCredentialStore : Implements ICredentialStore
		Private connectionSetting As String
		Private hashingAlgorithm As String

		Public Sub New(ByVal connectionStringSettingName As String, ByVal hashingAlgorithm As String)
			Me.connectionSetting = connectionStringSettingName
			Me.hashingAlgorithm = hashingAlgorithm
		End Sub

		Public Function Authenticate(ByVal userName As String, ByVal password As String) As Boolean Implements ICredentialStore.Authenticate
			' Pass the call on to the other version of the 
			' Authenticate() method.
			Dim ignoredUserData As String
			Return Authenticate(userName, password, ignoredUserData)
		End Function


		Public Function Authenticate(ByVal userName As String, ByVal password As String, <System.Runtime.InteropServices.Out()> ByRef userData As String) As Boolean Implements ICredentialStore.Authenticate
			userData = Nothing

			Dim passwordToCompare As String
			If (Not hashingAlgorithm Is Nothing) AndAlso (Not hashingAlgorithm Is "Clear") Then
				' If a hashing algorithm is specified, hash the password.
				passwordToCompare = FormsAuthentication.HashPasswordForStoringInConfigFile(password, hashingAlgorithm)
			Else
				' Otherwise, use the plain text of the password.
				passwordToCompare = password
			End If

			' Retrieve the connection string from the configuration file.				
			Dim con As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings(connectionSetting))

			' Create a parameterized command to prevent SQL injection attacks.
			Dim query As String = "SELECT UserName, Password, EmailAddress FROM Users WHERE UserName = @UserName"
			Dim cmd As SqlCommand = New SqlCommand(query, con)
			cmd.Parameters.Add("@UserName", userName)

			Dim isAuthenticated As Boolean = False
			Try
				con.Open()

				' The assumption here is that user names must be unique, which should be
				' enforced by an index in the database.
				Dim matchingUser As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

				' Default behavior of SELECT is not case sensitive,
				' so it's up to you to perform a case sensitive comparison.
				If matchingUser.Read() Then
					If (CStr(matchingUser("Password")) = passwordToCompare) AndAlso (CStr(matchingUser("UserName")) = userName) Then
						userData = CStr(matchingUser("emailAddress"))
						isAuthenticated = True
					End If
				End If
				matchingUser.Close()
            Catch er As Exception
                Return False
            Finally
                con.Close()
            End Try

            Return isAuthenticated
		End Function

	End Class
End Namespace
