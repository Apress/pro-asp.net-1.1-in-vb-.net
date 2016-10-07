Imports Microsoft.VisualBasic
Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.Web.Security
Imports System.Collections
Imports System.Web
Imports System.Security.Cryptography

Namespace Chapter18
	Public Class UsersDB
		Private connectionSetting As String

		Public Sub New(ByVal connectionStringSettingName As String)
			Me.connectionSetting = connectionStringSettingName
		End Sub

		Public Sub SetCreditCard(ByVal userName As String, ByVal cardNumber As String)
			Dim encryptedData As Byte() = EncryptionUtil.EncryptString(cardNumber,CType(HttpContext.Current.Application("Key"), Rijndael))

			' Retrieve the connection string from the configuration file.				
			Dim con As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings(connectionSetting))

			' Create a parameterized command with placeholders.
			Dim SQL As String = "UPDATE Users SET CreditCardData = @CreditCardData " + "WHERE UserName = @UserName"
			Dim cmd As SqlCommand = New SqlCommand(SQL, con)

			' Add a @UserName parameter of "TestUser"
			cmd.Parameters.Add("@CreditCardData", encryptedData)
			cmd.Parameters.Add("@UserName", userName)

			Try
				' Update the record.
				con.Open()
				cmd.ExecuteNonQuery()
			Finally
				con.Close()
			End Try
		End Sub

		Public Function GetCreditCard(ByVal userName As String) As String
			' Retrieve the connection string from the configuration file.				
			Dim con As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings(connectionSetting))

			' Create a parameterized command with placeholders.
			Dim SQL As String = "SELECT CreditCardData FROM Users " + "WHERE UserName = @UserName"
			Dim cmd As SqlCommand = New SqlCommand(SQL, con)
			cmd.Parameters.Add("@UserName", userName)

			Dim encryptedData As Byte()
			Try
				' Update the record.
				con.Open()
				Dim reader As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)
				reader.Read()
				encryptedData = CType(reader("CreditCardData"), Byte())
				reader.Close()
			Catch
				Return Nothing
			Finally
				con.Close()
			End Try

			' Decrypt and return the credit card number.
			Return EncryptionUtil.DecryptToString(encryptedData, CType(HttpContext.Current.Application("Key"), Rijndael))
		End Function



	End Class
End Namespace
