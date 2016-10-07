Imports Microsoft.VisualBasic
Imports System
Imports System.Xml

Namespace SherlockLib
	''' <summary>
	''' Summary description for Quotation.
	''' </summary>
	Public Class Quotation
		Private qsource As String
		Private strDate As String
		Private quotation As String

		Public Sub New(ByVal quoteNode As XmlNode)
			If Not (quoteNode.SelectSingleNode("source")) Is Nothing Then
				qsource = quoteNode.SelectSingleNode("source").InnerText
			End If
			If Not (quoteNode.Attributes.GetNamedItem("date")) Is Nothing Then
				strDate = quoteNode.Attributes.GetNamedItem("date").Value
			End If
			quotation = quoteNode.FirstChild.InnerText
		End Sub

		Public Property Source() As String
			Get
				Return qsource

			End Get
			Set
				qsource = Value
			End Set
		End Property

		Public Property [Date]() As String
			Get
				Return strDate
			End Get
			Set
				strDate = Value
			End Set
		End Property

		Public Property QuotationText() As String
			Get
				Return quotation
			End Get
			Set
				quotation = Value
			End Set
		End Property
	End Class
End Namespace
