Imports Microsoft.VisualBasic
Imports System
Imports System.Security.Principal

Namespace Chapter18
	''' <summary>
	''' Summary description for CustomIdentity.
	''' </summary>
	Public Class CustomIdentity : Implements IIdentity
		Public ReadOnly Property AuthenticationType() As String Implements IIdentity.AuthenticationType
			Get
				Return "CustomAuthenticationType"
			End Get
		End Property

        Private m_name As String
		Public ReadOnly Property Name() As String Implements IIdentity.Name
			Get
                Return m_name
			End Get
		End Property

		Private email As String
		Public ReadOnly Property EmailAddress() As String
			Get
				Return email
			End Get
		End Property

		Public ReadOnly Property IsAuthenticated() As Boolean Implements IIdentity.IsAuthenticated
			Get
				Return True
			End Get
		End Property
        Public Sub New(ByVal strName As String, ByVal strEmail As String)
            Me.m_name = strName
            Me.email = strEmail
        End Sub

    End Class
End Namespace
