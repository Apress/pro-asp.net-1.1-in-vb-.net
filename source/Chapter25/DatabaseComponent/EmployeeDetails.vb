Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml.Serialization

Namespace DatabaseComponent
	Public Class EmployeeDetails
        Private m_employeeID As Integer
        Private m_firstName As String
        Private m_lastName As String
        Private m_titleOfCourtesy As String

		<XmlAttribute("id")> _
		Public Property EmployeeID() As Integer
			Get
                Return m_employeeID
			End Get
			Set
                m_employeeID = Value
			End Set
		End Property

		<XmlElement("First")> _
		Public Property FirstName() As String
			Get
                Return m_firstName
			End Get
			Set
                m_firstName = Value
			End Set
		End Property

		<XmlElement("Last")> _
		Public Property LastName() As String
			Get
                Return m_lastName
			End Get
			Set
                m_lastName = Value
			End Set
		End Property

		<XmlAttribute("Title")> _
		Public Property TitleOfCourtesy() As String
			Get
                Return m_titleOfCourtesy
			End Get
			Set
                m_titleOfCourtesy = Value
			End Set
		End Property

		Public Sub New(ByVal employeeID As Integer, ByVal firstName As String, ByVal lastName As String, ByVal titleOfCourtesy As String)
			Me.employeeID = employeeID
			Me.firstName = firstName
			Me.lastName = lastName
			Me.titleOfCourtesy = titleOfCourtesy
		End Sub

		Public Sub New()
		End Sub
	End Class

End Namespace
