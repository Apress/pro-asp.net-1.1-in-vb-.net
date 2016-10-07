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
	''' Summary description for ListControls.
	''' </summary>
	Public Class ListControls : Inherits System.Web.UI.Page
		Protected Listbox1 As System.Web.UI.WebControls.ListBox
		Protected DropdownList1 As System.Web.UI.WebControls.DropDownList
		Protected CheckboxList1 As System.Web.UI.WebControls.CheckBoxList
		Protected RadiobuttonList1 As System.Web.UI.WebControls.RadioButtonList
		Protected WithEvents Button1 As System.Web.UI.WebControls.Button

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				For i As Integer = 3 To 5
					Listbox1.Items.Add("Option " + i.ToString())
					DropdownList1.Items.Add("Option " + i.ToString())
					CheckboxList1.Items.Add("Option " + i.ToString())
					RadiobuttonList1.Items.Add("Option " + i.ToString())
				Next i
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
'			Me.Button1.Click += New System.EventHandler(Me.Button1_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
			Response.Write("<b>Selected items for Listbox1:</b><br>")
			For Each li As ListItem In Listbox1.Items
				If li.Selected Then
				Response.Write("- " + li.Text + "<br>")
				End If
			Next li

			Response.Write("<b>Selected item for DropdownList1:</b><br>")
			Response.Write("- " + DropdownList1.SelectedItem.Text + "<br>")

			Response.Write("<b>Selected items for CheckboxList1:</b><br>")
			For Each li As ListItem In CheckboxList1.Items
				If li.Selected Then
				Response.Write("- " + li.Text + "<br>")
				End If
			Next li

			Response.Write("<b>Selected item for RadiobuttonList1:</b><br>")
			Response.Write("- " + RadiobuttonList1.SelectedItem.Text + "<br>")
		End Sub
	End Class
End Namespace
