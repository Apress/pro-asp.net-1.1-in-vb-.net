Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.Web.SessionState

Namespace Chapter06
	''' <summary>
	''' Summary description for Global.
	''' </summary>
	Public Class Global : Inherits System.Web.HttpApplication
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

'		DateTime createdAt = DateTime.Now;
'		protected void Application_Error(Object sender, EventArgs e)
'		{
'			Response.Write("<font face=\"Tahoma\" size=\"2\" color=\"red\">");
'			Response.Write("Oops! Looks like an error occurred!!<hr></font>");
'			Response.Write("<font face=\"Arial\" size=\"2\">");
'			Response.Write(Server.GetLastError().Message.ToString());
'			Response.Write("<hr>"+Server.GetLastError().ToString());
'			Response.Write("<br>This application object created: " + createdAt.ToString());
'			Server.ClearError();
'		}

		Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
			Response.Write("Application ended.<br>")
		End Sub

		#Region "Web Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			' 
			' Global
			' 


		End Sub
		#End Region



	End Class
End Namespace

