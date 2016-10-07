Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web
Imports System.Web.Services

Namespace Chapter24
	''' <summary>
	''' Summary description for StatefulService.
	''' </summary>
	Public Class StatefulService : Inherits System.Web.Services.WebService
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

		<WebMethod(EnableSession:=True)> _
		Public Sub StoreName(ByVal name As String)
			Session("Name") = name
		End Sub

		<WebMethod(EnableSession:=True)> _
		Public Function GetName() As String
			If Session("Name") Is Nothing Then
				Return ""
			Else
				Return CStr(Session("Name"))
			End If
		End Function
	End Class
End Namespace
