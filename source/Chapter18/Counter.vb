Imports Microsoft.VisualBasic
Imports System

Namespace Chapter18

	Public Class Counter
		Public Count As Integer = 0

		Public Overrides Function ToString() As String
			Return Count.ToString()
		End Function
	End Class
End Namespace
