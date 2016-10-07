Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace Chapter15
	''' <summary>
	''' Summary description for FixLinks.
	''' </summary>
	Public Class FixLinks
		Public Shared Sub UpdateHtmlAnchors(ByVal controls As ControlCollection)
			' Scan the page.
			For Each control As Control In controls
				' Update all HtmlAnchor objects
				If TypeOf control Is HtmlAnchor Then
					Dim anchor As HtmlAnchor = CType(control, HtmlAnchor)
					anchor.HRef = UpdateUrl(anchor.HRef)
				Else If TypeOf control Is HyperLink Then
					Dim link As HyperLink = CType(control, HyperLink)
					link.NavigateUrl = UpdateUrl(link.NavigateUrl)
				End If


				' Search the control tree recursively.
				If Not control.Controls Is Nothing Then
					UpdateHtmlAnchors(control.Controls)
				End If
			Next control
		End Sub

		Public Shared Function UpdateUrl(ByVal targetUrl As String) As String
			Dim context As HttpContext = HttpContext.Current
			If Not context.Request.QueryString(FormsAuthentication.FormsCookieName) Is Nothing Then
				' There is an authentication ticket. Add it.
				If targetUrl.IndexOf("?") = -1 Then
					targetUrl += "?" + FormsAuthentication.FormsCookieName + "=" + context.Request.QueryString(FormsAuthentication.FormsCookieName)
				Else
					targetUrl += "&" + FormsAuthentication.FormsCookieName + "=" + context.Request.QueryString(FormsAuthentication.FormsCookieName)
				End If
			End If
			Return targetUrl
		End Function
	End Class
End Namespace
