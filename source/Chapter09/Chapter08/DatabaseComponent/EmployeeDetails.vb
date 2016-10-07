Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace DatabaseComponent
	Public Class EmployeeDetails
		Private nEmployeeID As Integer
		Private strFirstName As String
		Private strLastName As String
		Private strTitleOfCourtesy As String

		Public Property EmployeeID() As Integer
			Get
				Return nEmployeeID
			End Get
			Set
				nEmployeeID = Value
			End Set
		End Property
		Public Property FirstName() As String
			Get
				Return strFirstName
			End Get
			Set
				strFirstName = Value
			End Set
		End Property
		Public Property LastName() As String
			Get
				Return strLastName
			End Get
			Set
				strLastName = Value
			End Set
		End Property
		Public Property TitleOfCourtesy() As String
			Get
				Return strTitleOfCourtesy
			End Get
			Set
				strTitleOfCourtesy = Value
			End Set
		End Property

 	Public Sub New(ByVal nEmployeeID As Integer, ByVal strFirstName As String, ByVal strLastName As String, ByVal strTitleOfCourtesy As String)
			Me.nEmployeeID = nEmployeeID
			Me.strFirstName = strFirstName
			Me.strLastName = strLastName
			Me.strTitleOfCourtesy = strTitleOfCourtesy
		End Sub
	End Class

End Namespace
