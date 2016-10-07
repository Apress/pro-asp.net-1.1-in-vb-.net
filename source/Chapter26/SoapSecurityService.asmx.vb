Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Security
Imports System.Data.SqlClient
Imports System.Web.Security
Imports System.Configuration

Namespace Chapter26
	''' <summary>
	''' Summary description for SoapSecurityService.
	''' </summary>
	Public Class SoapSecurityService : Inherits System.Web.Services.WebService
		Private connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=SSPI"

		Public Ticket As TicketHeader
		Public Sub New()
			'CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent()
		End Sub

		#Region "Component Designer generated code"

		'Required by the Web Services Designer 
		Private components As IContainer = Nothing

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso Not components Is Nothing Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#End Region

		Public Enum HashAlgorithm
			SHA1
			MD5
			Clear
		End Enum

    <WebMethod(), SoapHeader("Ticket", Direction:=SoapHeaderDirection.Out)> _
    Public Sub Login(ByVal userName As String, ByVal password As String, ByVal hHash As HashAlgorithm)
      If Authenticate(userName, password, hHash) Then
        ' Get the user roles.
        Dim roles As String() = GetRoles(userName)

        ' Create a new ticket.
        Dim strTicket As TicketIdentity = New TicketIdentity(userName, roles)

        ' Add this ticket to Application state.
        Application(strTicket.Ticket) = strTicket

        ' Create the SOAP header.
        Ticket = New TicketHeader(strTicket.Ticket)
      Else
        Throw New SecurityException("Invalid credentials.")
      End If
    End Sub

    <WebMethod(Description:="Returns the full list of employees."), SoapHeader("Ticket", Direction:=SoapHeaderDirection.In)> _
    Public Function GetEmployees() As DataSet
      AuthorizeUser(Ticket.Ticket, "Administrator")

      ' Create the command and the connection.
      Dim sql As String = "SELECT EmployeeID, LastName, FirstName, Title, " + "TitleOfCourtesy, HomePhone FROM Employees"
      Dim con As SqlConnection = New SqlConnection(connectionString)
      Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
      Dim ds As DataSet = New DataSet

      ' Fill the DataSet.
      da.Fill(ds, "Employees")
      Return ds
    End Function

    Private Function AuthorizeUser(ByVal strTicket As String) As TicketIdentity
      Dim ticketIdentity As ticketIdentity = CType(Application(strTicket), ticketIdentity)
      If Not strTicket Is Nothing Then
        Return ticketIdentity
      Else
        Throw New SecurityException("Invalid ticket.")
      End If
    End Function

    Private Function AuthorizeUser(ByVal strTicket As String, ByVal role As String) As TicketIdentity
      Dim ticketIdentity As ticketIdentity = AuthorizeUser(strTicket)
      If Array.IndexOf(ticketIdentity.Roles, role) = -1 Then
        Throw New SecurityException("Insufficient permissions.")
      Else
        Return ticketIdentity
      End If
    End Function



    Private connectionSetting As String = "CredentialConnectionString"
    Public Function Authenticate(ByVal userName As String, ByVal password As String, ByVal hHash As HashAlgorithm) As Boolean
      Dim passwordToCompare As String
      If hHash <> HashAlgorithm.Clear Then
        Dim hash As String = ""
        If hHash = HashAlgorithm.MD5 Then
          hash = "MD5"
        End If
        If hHash = HashAlgorithm.SHA1 Then
          hash = "SHA1"
        End If

        ' If a hashing algorith is specified, hash the password.
        passwordToCompare = FormsAuthentication.HashPasswordForStoringInConfigFile(password, hash)
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
            isAuthenticated = True
          End If
        End If
        matchingUser.Close()
      Catch err As Exception
        Return False
      Finally
        con.Close()
      End Try

      Return isAuthenticated
    End Function

    Public Function GetRoles(ByVal userName As String) As String()
      ' Retrieve the connection string from the configuration file.				
      Dim con As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings(connectionSetting))

      ' Create a parameterized command to prevent SQL injection attacks.
      Dim query As String = "SELECT Role FROM UsersRoles INNER JOIN Roles ON UsersRoles.RoleID = Roles.ID WHERE UserName = @UserName"
      Dim cmd As SqlCommand = New SqlCommand(query, con)
      cmd.Parameters.Add("@UserName", userName)

      Dim roles As ArrayList = New ArrayList
      Try
        con.Open()

        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Do While reader.Read()
          roles.Add(CStr(reader("Role")))
        Loop
        reader.Close()
      Catch err As Exception
        ' Don't return any roles.
        Return New String() {}
      Finally
        con.Close()
      End Try

      Return CType(roles.ToArray(GetType(String)), String())
    End Function


  End Class

  Public Class TicketIdentity
    Private strUserName As String
    Public ReadOnly Property UserName() As String
      Get
        Return strUserName
      End Get
    End Property

    Private strRoles As String()
    Public ReadOnly Property Roles() As String()
      Get
        Return strRoles
      End Get
    End Property

    Private strTicket As String
    Public ReadOnly Property Ticket() As String
      Get
        Return strTicket
      End Get
    End Property

    Public Sub New(ByVal theUserName As String, ByVal theRoles As String())
      Me.strUserName = theUserName
      Me.strRoles = theRoles

      ' Create the ticket GUID.
      Me.strTicket = Guid.NewGuid().ToString()
    End Sub
  End Class

  Public Class TicketHeader : Inherits SoapHeader
    Public Ticket As String

    Public Sub New(ByVal strTicket As String)
      Ticket = strTicket
    End Sub

    Public Sub New()
    End Sub
  End Class


End Namespace
