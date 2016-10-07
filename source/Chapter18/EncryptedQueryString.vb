Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Web
Imports System.Security.Cryptography

Namespace Chapter18
	''' <summary>
	''' Summary description for EncryptedQueryString.
	''' </summary>
	Public Class EncryptedQueryString: Inherits System.Collections.Specialized.StringDictionary
		Private crypt As SymmetricAlgorithm
		Public Sub New(ByVal crypt As SymmetricAlgorithm)
			Me.crypt = crypt
		End Sub

		Public Sub New(ByVal crypt As SymmetricAlgorithm, ByVal encryptedString As String)
			Me.crypt = crypt
			Deserialize(encryptedString)
		End Sub

		Public Overrides Function ToString() As String
			' Build the query string.
			' The name and value are separated with the = character.
			' Each subsequent name/value pair is separated with the & character.
			' To ensure that the setting value doesn't already use
			' the & or = characters (which would then be mistaken for a delimiter)
			' this code encodes the name and value before putting
			' it into the string.
			Dim server As HttpServerUtility = HttpContext.Current.Server
			Dim sb As StringBuilder = New StringBuilder()
			For Each item As DictionaryEntry In Me
				sb.Append(server.UrlEncode(item.Key.ToString()))
				sb.Append("=")
				sb.Append(server.UrlEncode(item.Value.ToString()))
				sb.Append("&")
			Next item

			' Remove the last &.
			sb.Remove(sb.Length-1, 1)

			' Perform the encryption.
			Dim encryptedData As Byte() = EncryptionUtil.EncryptString(sb.ToString(), crypt)

			' Convert the encrypted byte array to a URL-legal string.
			' This would also be a good place to check that the data isn't too large
			' to fit in a typical 4 KB query string.
			Return HexEncoding.ToString(encryptedData)
		End Function

		Private Sub Deserialize(ByVal encryptedString As String)
			Dim server As HttpServerUtility = HttpContext.Current.Server

			' Decode the string back into a byte array.
			Dim encryptedData As Byte() = HexEncoding.GetBytes(encryptedString)

			' Decrypt the string.
			Dim decryptedString As String = EncryptionUtil.DecryptToString(encryptedData, crypt)

			' Split the string into values.
			Dim values As String() = decryptedString.Split("&"c)
			For Each val As String In values
				Dim nameValuePair As String() = val.Split("="c)
				MyBase.Add(server.UrlDecode(nameValuePair(0)), server.UrlDecode(nameValuePair(1)))
			Next val
		End Sub
	End Class




End Namespace

