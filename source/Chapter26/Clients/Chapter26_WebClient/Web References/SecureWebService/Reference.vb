'------------------------------------------------------------------------------
' <autogenerated>
'	 This code was generated by a tool.
'	 Runtime Version: 1.1.4322.573
'
'	 Changes to this file may cause incorrect behavior and will be lost if 
'	 the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

' 
' This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.573.
' 

Imports Microsoft.VisualBasic
	Imports System.Diagnostics
	Imports System.Xml.Serialization
	Imports System
	Imports System.Web.Services.Protocols
	Imports System.ComponentModel
	Imports System.Web.Services
Namespace Chapter26_WebClient.SecureWebService


	''' <remarks/>
	<System.Diagnostics.DebuggerStepThroughAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Web.Services.WebServiceBindingAttribute(Name:="SecureServiceSoap", Namespace:="http://tempuri.org/")> _
	Public Class SecureService : Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

		''' <remarks/>
		Public Sub New()
			Me.Url = "http://localhost/Chapter26/SecureService.asmx"
		End Sub

		''' <remarks/>
		<System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TestAuthenticated", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
		Public Function TestAuthenticated() As String
			Dim results As Object() = Me.Invoke("TestAuthenticated", New Object(){})
			Return (CStr(results(0)))
		End Function

		''' <remarks/>
		Public Function BeginTestAuthenticated(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
			Return Me.BeginInvoke("TestAuthenticated", New Object(){}, callback, asyncState)
		End Function

		''' <remarks/>
		Public Function EndTestAuthenticated(ByVal asyncResult As System.IAsyncResult) As String
			Dim results As Object() = Me.EndInvoke(asyncResult)
			Return (CStr(results(0)))
		End Function
	End Class
End Namespace
