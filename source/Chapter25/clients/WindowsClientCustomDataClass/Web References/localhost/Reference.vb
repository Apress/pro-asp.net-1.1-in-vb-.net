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
Namespace WindowsClientCustomDataClass.localhost


	''' <remarks/>
	<System.Diagnostics.DebuggerStepThroughAttribute(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Web.Services.WebServiceBindingAttribute(Name:="EmployeesServiceCustomDataClassSoap", Namespace:="http://tempuri.org/")> _
	Public Class EmployeesServiceCustomDataClass : Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

		''' <remarks/>
		Public Sub New()
			Me.Url = "http://localhost/Chapter25/EmployeesServiceCustomDataClass.asmx"
		End Sub

		''' <remarks/>
		<System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetEmployees", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
		Public Function GetEmployees() As EmployeeDetails()
			Dim results As Object() = Me.Invoke("GetEmployees", New Object(){})
			Return (CType(results(0), EmployeeDetails()))
		End Function

		''' <remarks/>
		Public Function BeginGetEmployees(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
			Return Me.BeginInvoke("GetEmployees", New Object(){}, callback, asyncState)
		End Function

		''' <remarks/>
		Public Function EndGetEmployees(ByVal asyncResult As System.IAsyncResult) As EmployeeDetails()
			Dim results As Object() = Me.EndInvoke(asyncResult)
			Return (CType(results(0), EmployeeDetails()))
		End Function
	End Class


End Namespace
