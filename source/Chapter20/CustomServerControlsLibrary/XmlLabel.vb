Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Text.RegularExpressions

Namespace CustomServerControlsLibrary
	Public Class XmlLabel : Inherits Label
		Protected Overrides Sub RenderContents(ByVal output As HtmlTextWriter)
			' Don't call the base implementation of RenderContents().
			' You need to replace the rendering logic for the label text
			' with your own routine.
			Dim xmlText As String = XmlLabel.ConvertXmlTextToHtmlText(Text)
			output.Write(xmlText)
		End Sub

		' This is a static method, just in case you want to use it
		' idependent of any control object.
		Public Shared Function ConvertXmlTextToHtmlText(ByVal inputText As String) As String
			' Replace all start and end tags.
			Dim startPattern As String = "<([^>]+)>"
			Dim regEx As Regex = New Regex(startPattern)
			Dim outputText As String = regEx.Replace(inputText, "&lt;<b>$1&gt;</b>")

			outputText = outputText.Replace(" ", "&nbsp;")
			outputText = outputText.Replace(Constants.vbCrLf, "<br>")

			Return outputText
		End Function
	End Class
End Namespace
