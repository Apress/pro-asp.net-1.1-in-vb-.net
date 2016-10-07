Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Xml
Imports System.Configuration

Namespace ConfigurationExtension
	Public Class DbConnectionConfigSectionHandler : Implements IConfigurationSectionHandler
		Public Overridable Function Create(ByVal parent As Object, ByVal configContext As Object, ByVal section As XmlNode) As Object Implements IConfigurationSectionHandler.Create
			If section.ChildNodes.Count > 0 Then
				Dim connections As DbConnectionConfigSection() = New DbConnectionConfigSection(section.ChildNodes.Count - 1) {}
				For i As Integer = 0 To section.ChildNodes.Count - 1
					Dim connectionString As String = GetStringValueOfAttribute(section.ChildNodes(i), "connectionString")
					Dim tableName As String = GetStringValueOfAttribute(section.ChildNodes(i), "tableName")

					connections(i) = New DbConnectionConfigSection(connectionString, tableName)
				Next i
				Return connections
			Else
				Return Nothing
			End If

		End Function

		Public Function GetStringValueOfAttribute(ByVal node As XmlNode, ByVal attribute As String) As String
			Dim match As XmlNode = node.Attributes.RemoveNamedItem(attribute)
			If match Is Nothing Then
				Throw New ConfigurationException("Attribute required: " + attribute)
			Else
				Return match.Value
			End If
		End Function
	End Class

	Public Class DbConnectionConfigSection
		Private strConnectionString As String
		Public ReadOnly Property ConnectionString() As String
			Get
				Return strConnectionString
			End Get
		End Property

		Private strTable As String
		Public ReadOnly Property TableName() As String
			Get
				Return strTable
			End Get
		End Property

		Public Sub New(ByVal strConnectionString As String, ByVal strTable As String)
			Me.strConnectionString = strConnectionString
			Me.strTable = strTable
		End Sub
	End Class
End Namespace
