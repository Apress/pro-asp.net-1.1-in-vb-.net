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
Imports System.Web.HttpClientCertificate

Namespace Chapter04
	''' <summary>
	''' Summary description for DynamicButton.
	''' </summary>
	Public Class DynamicButton : Inherits System.Web.UI.Page
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected PlaceHolder1 As System.Web.UI.WebControls.PlaceHolder
		Protected WithEvents cmdReset As System.Web.UI.WebControls.Button
		Protected WithEvents cmdRemove As System.Web.UI.WebControls.Button
		Protected WithEvents cmdCreate As System.Web.UI.WebControls.Button
		Protected Panel1 As System.Web.UI.WebControls.Panel

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Create a new button object.


            Dim newButton As Button = New Button

			' Assign some text and an ID so you can retrieve it later.
			newButton.Text = "* Dynamic Button *"
			newButton.ID = "newButton"

			' Attach an event handler to the Button.Click event.
			AddHandler newButton.Click, AddressOf Button_Click

			' Add the putton to a placeholder.
			PlaceHolder1.Controls.Add(newButton)
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
'			Me.cmdReset.Click += New System.EventHandler(Me.cmdReset_Click);
'			Me.cmdRemove.Click += New System.EventHandler(Me.cmdRemove_Click);
'			Me.cmdCreate.Click += New System.EventHandler(Me.cmdCreate_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region


		Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Label1.Text = "You clicked the dynamic button."
		End Sub

		Private Sub cmdReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdReset.Click
			Label1.Text = "(No value.)"
		End Sub

		Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
			' Search for the button, no matter what level it's at.
			Dim foundButton As Button = CType(Page.FindControl("newButton"), Button)

			' Remove the button.
			If Not foundButton Is Nothing Then
				foundButton.Parent.Controls.Remove(foundButton)
			End If
		End Sub

		Private Sub cmdCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
			' (Button is automatically created in postback.)
		End Sub
	End Class
End Namespace
