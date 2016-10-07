Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.Security
Imports System.Text

Namespace Chapter15
	''' <summary>
	''' Summary description for GetTicketData.
	''' </summary>
	Public Class GetTicketData : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim htmlString As StringBuilder = New StringBuilder()

			' Has the request been authenticated?
			If Request.IsAuthenticated Then
				' Display generic identity information.
				htmlString.Append("<h3>Generic User Information</h3>")
				htmlString.Append("<b>Name: </b>")
				htmlString.Append(User.Identity.Name)
				htmlString.Append("<br><b>Authenticated With: </b>")
				htmlString.Append(User.Identity.AuthenticationType)
				htmlString.Append("<br><br>")

				' Was forms authentication used?
				If TypeOf User.Identity Is FormsIdentity Then
					' Get the ticket.
					Dim ticket As FormsAuthenticationTicket = (CType(User.Identity, FormsIdentity)).Ticket

					htmlString.Append("<h3>Ticket User Information</h3>")
					htmlString.Append("<b>Name: </b>")
					htmlString.Append(ticket.Name)
					htmlString.Append("<br><b>Issued at: </b>")
					htmlString.Append(ticket.IssueDate)
					htmlString.Append("<br><b>Expires at: </b>")
					htmlString.Append(ticket.Expiration)
					htmlString.Append("<br><b>Cookie version: </b>")
					htmlString.Append(ticket.Version)
					htmlString.Append("<br><b>User data: </b>")
					htmlString.Append(ticket.UserData)
				End If

				' Display the information.
				lblInfo.Text=htmlString.ToString()
			End If

		End Sub

		#Region "Web Form Designer generated code"
		Overrides Protected Sub OnInit(ByVal e As EventArgs)
			'
			' CODEGEN: This call is required by the ASP.NET Web Form Designer.
			'
			InitializeComponent()
			MyBase.OnInit(e)
		End Sub

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region
	End Class
End Namespace
