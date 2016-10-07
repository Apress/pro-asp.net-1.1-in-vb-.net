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
	Public Class ViewStateObjects : Inherits System.Web.UI.Page
		Protected Name As System.Web.UI.WebControls.TextBox
		Protected EmpID As System.Web.UI.WebControls.TextBox
		Protected Age As System.Web.UI.WebControls.TextBox
		Protected Email As System.Web.UI.WebControls.TextBox
		Protected Password As System.Web.UI.WebControls.TextBox
		Protected WithEvents cmdSave As System.Web.UI.WebControls.Button
		Protected WithEvents cmdDisplay As System.Web.UI.WebControls.Button
		Protected lblResults As System.Web.UI.WebControls.Label
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
'			Me.cmdSave.Click += New System.EventHandler(Me.cmdSave_Click);
'			Me.cmdDisplay.Click += New System.EventHandler(Me.cmdDisplay_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		' This will be created at the beginning of each request.
		Private textToSave As Hashtable = New Hashtable()

		Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
			' Put the text in the Hashtable.
			SaveAllText(Table1.Controls, True)

			' Store the entire collection in view state.
			ViewState("TextData") = textToSave
		End Sub

		Private Sub SaveAllText(ByVal controls As ControlCollection, ByVal saveNested As Boolean)
			For Each control As Control In controls
				If TypeOf control Is TextBox Then
					' Add the text to a collection.
					textToSave.Add(control.ID, (CType(control, TextBox)).Text)
				End If
				If (Not control.Controls Is Nothing) AndAlso saveNested Then
					SaveAllText(control.Controls, True)
				End If
			Next control
		End Sub

		Private Sub cmdDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDisplay.Click
			If Not ViewState("TextData") Is Nothing Then
				' Retrieve the hashtable.
				Dim savedText As Hashtable = CType(ViewState("TextData"), Hashtable)

				' Display all the text by looping through the hashtable.
				lblResults.Text = ""
				For Each item As DictionaryEntry In savedText
					lblResults.Text += CStr(item.Key) + " = " + CStr(item.Value) + "<br>"
				Next item
			End If
		End Sub
	End Class
End Namespace
