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

Namespace WebControls
	''' <summary>
	''' Summary description for EventTracker.
	''' </summary>
	Public Class EventTracker : Inherits System.Web.UI.Page
		Protected WithEvents txt As System.Web.UI.WebControls.TextBox
		Protected WithEvents chk As System.Web.UI.WebControls.CheckBox
		Protected WithEvents opt1 As System.Web.UI.WebControls.RadioButton
		Protected WithEvents opt2 As System.Web.UI.WebControls.RadioButton
		Protected lstEvents As System.Web.UI.WebControls.ListBox

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
'			Me.txt.TextChanged += New System.EventHandler(Me.CtrlChanged);
'			Me.chk.CheckedChanged += New System.EventHandler(Me.CtrlChanged);
'			Me.opt1.CheckedChanged += New System.EventHandler(Me.CtrlChanged);
'			Me.opt2.CheckedChanged += New System.EventHandler(Me.CtrlChanged);

		End Sub
		#End Region

		Private Sub CtrlChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt.TextChanged, chk.CheckedChanged, opt1.CheckedChanged, opt2.CheckedChanged
			Dim ctrlName As String = (CType(sender, Control)).ID
			lstEvents.Items.Add(ctrlName + " Changed")

			' Select the last item to scroll the list so the most recent
			' entries are visible.
			lstEvents.SelectedIndex = lstEvents.Items.Count - 1

		End Sub

	End Class
End Namespace
