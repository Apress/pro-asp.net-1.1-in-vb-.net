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

Namespace Chapter3
	''' <summary>
	''' Summary description for Controls.
	''' </summary>
	Public Class Controls : Inherits System.Web.UI.Page
		Protected Button1 As System.Web.UI.WebControls.Button
		Protected Button2 As System.Web.UI.WebControls.Button
		Protected Button3 As System.Web.UI.WebControls.Button
		Protected TextBox1 As System.Web.UI.WebControls.TextBox
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected Button4 As System.Web.UI.WebControls.Button
		Protected MainPanel As System.Web.UI.WebControls.Panel

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Start examining all the controls.
            DisplayControl(Page.Controls, 0)

			' Add the closing horizontal line.
            Response.Write("<hr>")
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

		Private Sub DisplayControl(ByVal controls As ControlCollection, ByVal depth As Integer)
			For Each control As Control In controls
				' Use the depth parameter to indent the control tree.
				Response.Write(New String("-"c, depth * 4) + "> ")

				' Display this control.
				Response.Write(control.GetType().ToString() + " - <b>" + control.ID + "</b><br>")

				'				if (control is LiteralControl)
				'				{
				'					Response.Write("*** Text: "+((LiteralControl)control).Text + "<br>");
				'				}

				' Check if this control contains more controls.
				If Not control.Controls Is Nothing Then
					DisplayControl(control.Controls, depth + 1)
				End If
			Next control
		End Sub

	End Class
End Namespace
