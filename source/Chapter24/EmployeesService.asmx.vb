Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web
Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Web.Services.Protocols

Namespace Chapter24
  <WebService(Name:="EmployeesService", Description:="Retrieve the Northwind Employees", Namespace:="http://www.apress.com/ProASP.NET/")> _
Public Class EmployeesService : Inherits System.Web.Services.WebService
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
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso Not components Is Nothing Then
        components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub

#End Region


    Private connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=SSPI"
    <WebMethod(BufferResponse:=False)> _
    Public Function GetLargeStreamofData() As Byte()
      '...
    End Function
    <WebMethod(Description:="Returns the total number of employees.")> _
    Public Function GetEmployeesCount() As Integer
      Dim con As SqlConnection = New SqlConnection(connectionString)
      Dim sql As String = "SELECT COUNT(*) FROM Employees"
      Dim cmd As SqlCommand = New SqlCommand(sql, con)

      ' Open the connection and get the value.
      cmd.Connection.Open()
      Dim numEmployees As Integer = -1
      Try
        numEmployees = CInt(cmd.ExecuteScalar())
      Finally
        cmd.Connection.Close()
      End Try
      Return numEmployees
    End Function




    <WebMethod(Description:="Returns the full list of employees.")> _
    Public Function GetEmployees() As DataSet
      ' Create the command and the connection.
      Dim sql As String = "SELECT EmployeeID, LastName, FirstName, Title, " + "TitleOfCourtesy, HomePhone FROM Employees"
      Dim con As SqlConnection = New SqlConnection(connectionString)
      Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
      Dim ds As DataSet = New DataSet

      ' Fill the DataSet.
      da.Fill(ds, "Employees")
      Return ds
    End Function

    <WebMethod(Description:="Returns the full list of employees by city.", MessageName:="GetEmployeesByCity")> _
    Public Function GetEmployees(ByVal city As String) As DataSet
      ' Create the command and the connection.
      Dim sql As String = "SELECT EmployeeID, LastName, FirstName, Title, " + "TitleOfCourtesy, HomePhone FROM Employees " + "WHERE City LIKE '%'+ @City + '%'"
      Dim con As SqlConnection = New SqlConnection(connectionString)
      Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
      da.SelectCommand.Parameters.Add("@City", city)
      Dim ds As DataSet = New DataSet

      ' Fill the DataSet.
      da.Fill(ds, "Employees")
      Return ds
    End Function
  End Class
End Namespace
