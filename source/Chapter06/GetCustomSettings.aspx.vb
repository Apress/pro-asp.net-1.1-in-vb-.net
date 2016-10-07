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
Imports System.Configuration
Imports System.Collections.Specialized
Imports ConfigurationExtension

Namespace Chapter06
	''' <summary>
	''' Summary description for GetCustomSettings.
	''' </summary>
	Public Class GetCustomSettings : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim connections As DbConnectionConfigSection() = CType(Context.GetConfig("system.web/DatabaseConnections"), DbConnectionConfigSection())

			For Each con As DbConnectionConfigSection In connections
				lblInfo.Text += "Retrieved a connection with...<br>" + "<b>Connection:</b> " + con.ConnectionString + "<br><b>Table:</b> " + con.TableName + "<br><br>"
			Next con
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
