Imports Microsoft.VisualBasic
Imports System
Imports System.Text

Namespace Chapter18
	Public Class HexEncoding
		Public Sub New()
			'
			' TODO: Add constructor logic here
			'
		End Sub
		Public Shared Function GetByteCount(ByVal hexString As String) As Integer
			Dim numHexChars As Integer = 0
			Dim c As Char
			' remove all none A-F, 0-9, characters
			For i As Integer = 0 To hexString.Length - 1
				c = hexString.Chars(i)
				If IsHexDigit(c) Then
					numHexChars += 1
				End If
			Next i
			' if odd number of characters, discard last character
			If numHexChars Mod 2 <> 0 Then
				numHexChars -= 1
			End If
			Return numHexChars / 2 ' 2 characters per byte
		End Function

		''' Creates a byte array from the hexadecimal string. Each two characters are combined
		''' to create one byte. First two hexadecimal characters become first byte in returned array.
		''' Non-hexadecimal characters are ignored. 
		Public Shared Function GetBytes(ByVal hexString As String) As Byte()
			Dim sb As StringBuilder = New StringBuilder()

			Dim c As Char
			' remove all none A-F, 0-9, characters
			For i As Integer = 0 To hexString.Length - 1
				c = hexString.Chars(i)
				If IsHexDigit(c) Then
					sb.Append(c)
				End If
			Next i

			Dim newString As String = sb.ToString()

			' if odd number of characters, discard last character
			If newString.Length Mod 2 <> 0 Then
				newString = newString.Substring(0, newString.Length-1)
			End If

			Dim byteLength As Integer = newString.Length / 2
			Dim bytes As Byte() = New Byte(byteLength - 1) {}
			Dim hex As String
			Dim j As Integer = 0
			For i As Integer = 0 To bytes.Length - 1
				hex = New String(New Char() {newString.Chars(j), newString.Chars(j+1)})
				bytes(i) = HexToByte(hex)
				j = j+2
			Next i
			Return bytes
		End Function

        Public Overloads Shared Function ToString(ByVal bytes As Byte()) As String
            Dim hexString As String = ""
            For i As Integer = 0 To bytes.Length - 1
                hexString += bytes(i).ToString("X2")
            Next i
            Return hexString
        End Function

        ''' <summary>
        ''' Determines if given string is in proper hexadecimal string format
        ''' </summary>
        ''' <param name="hexString"></param>
        ''' <returns></returns>
        Public Shared Function InHexFormat(ByVal hexString As String) As Boolean
            Dim hexFormat As Boolean = True

            For Each digit As Char In hexString
                If (Not IsHexDigit(digit)) Then
                    hexFormat = False
                    Exit For
                End If
            Next digit
            Return hexFormat
        End Function

        ''' <summary>
        ''' Returns true is c is a hexadecimal digit (A-F, a-f, 0-9)
        ''' </summary>
        ''' <param name="c">Character to test</param>
        ''' <returns>true if hex digit, false if not</returns>
        Public Shared Function IsHexDigit(ByVal c As Char) As Boolean
            Dim numChar As Integer
            Dim numA As Integer = Convert.ToInt32("A"c)
            Dim num1 As Integer = Convert.ToInt32("0"c)
            c = Char.ToUpper(c)
            numChar = Convert.ToInt32(c)
            If numChar >= numA AndAlso numChar < (numA + 6) Then
                Return True
            End If
            If numChar >= num1 AndAlso numChar < (num1 + 10) Then
                Return True
            End If
            Return False
        End Function
        ''' <summary>
        ''' Converts 1 or 2 character string into equivalant byte value
        ''' </summary>
        ''' <param name="hex">1 or 2 character string</param>
        ''' <returns>byte</returns>
        Private Shared Function HexToByte(ByVal hex As String) As Byte
            If hex.Length > 2 OrElse hex.Length <= 0 Then
                Throw New ArgumentException("hex must be 1 or 2 characters in length")
            End If
            Dim newByte As Byte = Byte.Parse(hex, System.Globalization.NumberStyles.HexNumber)
            Return newByte
        End Function

    End Class
End Namespace
