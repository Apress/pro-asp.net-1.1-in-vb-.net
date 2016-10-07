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
	''' Summary description for Validators.
	''' </summary>
	Public Class ViewStateTest : Inherits System.Web.UI.Page
		Protected Name As System.Web.UI.WebControls.TextBox
		Protected EmpID As System.Web.UI.WebControls.TextBox
		Protected DayOff As System.Web.UI.WebControls.TextBox
		Protected Age As System.Web.UI.WebControls.TextBox
		Protected Email As System.Web.UI.WebControls.TextBox
		Protected Password As System.Web.UI.WebControls.TextBox
		Protected WithEvents cmdSave As System.Web.UI.WebControls.Button
		Protected WithEvents cmdRestore As System.Web.UI.WebControls.Button
Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
  Protected Table1 As System.Web.UI.WebControls.Table

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Put user code to initialize the page here
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

  End Sub
		#End Region

		Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
			' Save the current text.
			SaveAllText(Table1.Controls, True)
		End Sub

		Private Sub SaveAllText(ByVal controls As ControlCollection, ByVal saveNested As Boolean)
			For Each control As Control In controls
				If TypeOf control Is TextBox Then
					' Store the text using the unique control ID.
					ViewState(control.ID) = (CType(control, TextBox)).Text
				End If

				If (Not control.Controls Is Nothing) AndAlso saveNested Then
					SaveAllText(control.Controls, True)
				End If
			Next control
		End Sub

		Private Sub cmdRestore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRestore.Click
			' Retrieve the last saved text.
     RestoreAllText(Table1.Controls, True)

		End Sub

		Private Sub RestoreAllText(ByVal controls As ControlCollection, ByVal saveNested As Boolean)
			For Each control As Control In controls
				If TypeOf control Is TextBox Then
					If Not ViewState(control.ID) Is Nothing Then
					  CType(control, TextBox).Text = CStr(ViewState(control.ID))
					End If
				End If

				If (Not control.Controls Is Nothing) AndAlso saveNested Then
					RestoreAllText(control.Controls, True)
				End If
			Next control
		End Sub
	End Class
End Namespace
