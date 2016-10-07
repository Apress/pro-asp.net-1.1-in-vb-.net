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

Namespace Chapter05
	''' <summary>
	''' Summary description for ChangeEvents.
	''' </summary>
	Public Class ChangeEvents : Inherits System.Web.UI.Page
		Protected WithEvents List1 As System.Web.UI.HtmlControls.HtmlSelect
		Protected WithEvents Textbox1 As System.Web.UI.HtmlControls.HtmlInputText
		Protected WithEvents Checkbox1 As System.Web.UI.HtmlControls.HtmlInputCheckBox
		Protected WithEvents Submit1 As System.Web.UI.HtmlControls.HtmlInputButton

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				List1.Items.Add("Option 3")
				List1.Items.Add("Option 4")
				List1.Items.Add("Option 5")
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
'			Me.List1.ServerChange += New System.EventHandler(Me.List1_ServerChange);
'			Me.Textbox1.ServerChange += New System.EventHandler(Me.Ctrl_ServerChange);
'			Me.Checkbox1.ServerChange += New System.EventHandler(Me.Ctrl_ServerChange);
'			Me.Submit1.ServerClick += New System.EventHandler(Me.Submit1_ServerClick);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub Submit1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit1.ServerClick
			Response.Write("<li>ServerClick detected for Submit1.</li>")
		End Sub

		Private Sub Ctrl_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Textbox1.ServerChange, Checkbox1.ServerChange
			Response.Write("<li>ServerChange detected for " + (CType(sender, Control)).ID + "</li>")
		End Sub

		Private Sub List1_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles List1.ServerChange
			Response.Write("<li>ServerChange detected for List1. " + "The selected items are:</li><br>")
			For Each li As ListItem In List1.Items
				If li.Selected Then
					Response.Write("&nbsp;&nbsp;- " + li.Value + "<br>")
				End If
			Next li

		End Sub


	End Class
End Namespace
