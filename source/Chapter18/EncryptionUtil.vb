Imports Microsoft.VisualBasic
Imports System
Imports System.Security.Cryptography
Imports System.IO

Namespace Chapter18
	''' <summary>
	''' Summary description for EncryptionUtil.
	''' </summary>
	Public Class EncryptionUtil
		Public Shared Function EncryptString(ByVal stringToEncrypt As String, ByVal crypt As SymmetricAlgorithm) As Byte()
			' Create a cryptographic stream for encryption.
			Dim ms As MemoryStream = New MemoryStream()
			Dim cs As CryptoStream = New CryptoStream(ms, crypt.CreateEncryptor(), CryptoStreamMode.Write)

			' Write the string to binary data with the help of a BinaryWriter.
			Dim w As BinaryWriter = New BinaryWriter(cs)
			w.Write(stringToEncrypt)
			w.Flush()

			' All the data has been written. Now, make sure the last block
			' is properly padded. Failing to do this will cause an error
			' when you attempt to decrypt the data.
			cs.FlushFinalBlock()

			' Now move the encrypted data out of the stream,
			' and into an array of bytes.
			Return ms.ToArray()
		End Function

		Public Shared Function DecryptToString(ByVal dataToDecrypt As Byte(), ByVal crypt As SymmetricAlgorithm) As String
			' Create a cryptographic stream for decryption.
			Dim ms As MemoryStream = New MemoryStream()
			Dim cs As CryptoStream = New CryptoStream(ms, crypt.CreateDecryptor(), CryptoStreamMode.Write)

			' Write the binary data to the memory stream.
			cs.Write(dataToDecrypt, 0, dataToDecrypt.Length)
			cs.FlushFinalBlock()

			' Read the unencrypted data from the stream into a string,
			' with the help of the BinaryReader.
			Dim r As BinaryReader = New BinaryReader(ms)
			ms.Position = 0
			Dim decryptedData As String = r.ReadString()
			r.Close()

			Return decryptedData
		End Function
	End Class
End Namespace
