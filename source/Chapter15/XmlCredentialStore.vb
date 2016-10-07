Imports Microsoft.VisualBasic
Imports System
Imports System.Xml
Imports System.Xml.XPath
Imports System.Web.Security

Namespace Chapter15
	Public Class XmlCredentialStore : Implements ICredentialStore
		Private usersFile As String

		Public Sub New(ByVal usersFile As String)
			Me.usersFile = usersFile
		End Sub

		Public Function Authenticate(ByVal userName As String, ByVal password As String, <System.Runtime.InteropServices.Out()> ByRef userData As String) As Boolean Implements ICredentialStore.Authenticate
			userData = Nothing

			' Pass the call on to the other version of the 
			' Authenticate() method.
			Return Authenticate(userName, password)
		End Function

		Public Function Authenticate(ByVal userName As String, ByVal password As String) As Boolean Implements ICredentialStore.Authenticate
			' Create the XML document object.
			Dim usersXml As XmlDocument = New XmlDocument()

			' Create a namespace manager for the document (we need it later).
			Dim namespaceManager As XmlNamespaceManager = New XmlNamespaceManager(usersXml.NameTable)

			' The XML document might fail to load so error handling
			' makes sense.
			Try
				usersXml.Load(usersFile)
            Catch er As Exception
                ' We could not load the XML file so the user can't be 
                ' authenticated. Another option is to throw some sort of
                ' exception to alert the web page.
                Return False
            End Try

            ' Get the <users> node.
            Dim users As XmlNode = usersXml.GetElementsByTagName("users").Item(0)

            ' Get the hashing algorithm.
            Dim hashingAlgorithm As String = users.Attributes("passwordFormat").Value

            Dim passwordToCompare As String
            If (Not hashingAlgorithm Is Nothing) AndAlso (Not hashingAlgorithm Is "Clear") Then
                ' If a hashing algorith is specified, hash the password.
                passwordToCompare = FormsAuthentication.HashPasswordForStoringInConfigFile(password, hashingAlgorithm)
            Else
                ' Otherwise, use the plain text of the password.
                passwordToCompare = password
            End If

            ' Get the root node.
            Dim root As XmlNode = usersXml.DocumentElement

            ' Create an XPath expression to match a user node
            ' with the correct user name and password.
            ' NOTE: You may need to protect against XPath code injection!
            Dim userXPath As String = "descendant::user[@userName='" + userName + "' and @password='" + passwordToCompare + "']"

            ' Find the matching user node.
            Dim matchingUser As XmlNode = root.SelectSingleNode(userXPath, namespaceManager)
            If Not matchingUser Is Nothing Then
                ' Perform the final sanity check.
                If (matchingUser.Attributes("userName").Value = userName) AndAlso (matchingUser.Attributes("password").Value = passwordToCompare) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

		End Function
	End Class




End Namespace
