Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

Namespace Chapter24
	''' <summary>
	''' Summary description for SessionHeaderService.
	''' </summary>
	Public Class SessionHeaderService : Inherits System.Web.Services.WebService
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


		Public CurrentSessionHeader As SessionHeader

		<WebMethod(), SoapHeader("CurrentSessionHeader", Direction:=SoapHeaderDirection.Out)> _
		Public Sub CreateSession()
			' Create the header.
			CurrentSessionHeader = New SessionHeader(Guid.NewGuid().ToString())

			' From now on, all session data will be indexed under that key.
      Application(CurrentSessionHeader.SessionID) = New Hashtable
		End Sub

		<WebMethod(), SoapHeader("CurrentSessionHeader", Direction:=SoapHeaderDirection.In)> _
		Public Sub SetSessionData(ByVal ds As DataSet)
			' Locking is not required, because no two clients
			' could share the same session ID.
			Dim session As Hashtable = CType(Application(CurrentSessionHeader.SessionID), Hashtable)
			session.Add("DataSet", ds)
		End Sub

		<WebMethod(), SoapHeader("CurrentSessionHeader", Direction:=SoapHeaderDirection.In)> _
		Public Function GetSessionData() As DataSet
			Dim session As Hashtable = CType(Application(CurrentSessionHeader.SessionID), Hashtable)
			Return CType(session("DataSet"), DataSet)
		End Function

	End Class

	Public Class SessionHeader: Inherits SoapHeader
		Public SessionID As String
    Public Sub New(ByVal strSessionID As String)
      SessionID = strSessionID
    End Sub
    ' Default constructor is required for serialization.
    Public Sub New()
    End Sub
  End Class
End Namespace
