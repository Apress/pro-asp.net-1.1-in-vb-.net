﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.573
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.573.
'
Namespace localhost
    
    '<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="Employees ServiceSoap", [Namespace]:="http://www.apress.com/ProASP.NET/")>  _
    Public Class EmployeesService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://localhost/Chapter25/EmployeesService.asmx"
        End Sub
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apress.com/ProASP.NET/GetEmployeesCount", RequestNamespace:="http://www.apress.com/ProASP.NET/", ResponseNamespace:="http://www.apress.com/ProASP.NET/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetEmployeesCount() As Integer
            Dim results() As Object = Me.Invoke("GetEmployeesCount", New Object(-1) {})
            Return CType(results(0),Integer)
        End Function
        
        '<remarks/>
        Public Function BeginGetEmployeesCount(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetEmployeesCount", New Object(-1) {}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetEmployeesCount(ByVal asyncResult As System.IAsyncResult) As Integer
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Integer)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apress.com/ProASP.NET/GetEmployees", RequestNamespace:="http://www.apress.com/ProASP.NET/", ResponseNamespace:="http://www.apress.com/ProASP.NET/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Overloads Function GetEmployees() As System.Data.DataSet
            Dim results() As Object = Me.Invoke("GetEmployees", New Object(-1) {})
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '<remarks/>
        Public Function BeginGetEmployees(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetEmployees", New Object(-1) {}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetEmployees(ByVal asyncResult As System.IAsyncResult) As System.Data.DataSet
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '<remarks/>
        <System.Web.Services.WebMethodAttribute(MessageName:="GetEmployees1"),  _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apress.com/ProASP.NET/GetEmployeesByCity", RequestElementName:="GetEmployeesByCity", RequestNamespace:="http://www.apress.com/ProASP.NET/", ResponseElementName:="GetEmployeesByCityResponse", ResponseNamespace:="http://www.apress.com/ProASP.NET/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Overloads Function GetEmployees(ByVal city As String) As <System.Xml.Serialization.XmlElementAttribute("GetEmployeesByCityResult")> System.Data.DataSet
            Dim results() As Object = Me.Invoke("GetEmployees1", New Object() {city})
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '<remarks/>
        Public Function BeginGetEmployees1(ByVal city As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetEmployees1", New Object() {city}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetEmployees1(ByVal asyncResult As System.IAsyncResult) As System.Data.DataSet
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apress.com/ProASP.NET/GetEmployeesCountError", RequestNamespace:="http://www.apress.com/ProASP.NET/", ResponseNamespace:="http://www.apress.com/ProASP.NET/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetEmployeesCountError() As Integer
            Dim results() As Object = Me.Invoke("GetEmployeesCountError", New Object(-1) {})
            Return CType(results(0),Integer)
        End Function
        
        '<remarks/>
        Public Function BeginGetEmployeesCountError(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetEmployeesCountError", New Object(-1) {}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetEmployeesCountError(ByVal asyncResult As System.IAsyncResult) As Integer
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Integer)
        End Function
    End Class
End Namespace
