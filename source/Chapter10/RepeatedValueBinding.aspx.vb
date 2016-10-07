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

Namespace Chapter10
	''' <summary>
	''' Summary description for RepeatedValueBinding.
	''' </summary>
	Public Class RepeatedValueBinding : Inherits System.Web.UI.Page
		Protected Listbox1 As System.Web.UI.WebControls.ListBox
		Protected DropdownList1 As System.Web.UI.WebControls.DropDownList
		Protected OptionList1 As System.Web.UI.WebControls.RadioButtonList
		Protected CheckList1 As System.Web.UI.WebControls.CheckBoxList
		Protected WithEvents cmdGetSelection As System.Web.UI.WebControls.Button
		Protected Result As System.Web.UI.WebControls.Literal
		Protected Select1 As System.Web.UI.HtmlControls.HtmlSelect
		Protected Select2 As System.Web.UI.HtmlControls.HtmlSelect

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				' create the data source
				Dim ht As Hashtable = New Hashtable(3)
				ht.Add("Lasagna", "Key1")
				ht.Add("Spaghetti", "Key2")
				ht.Add("Pizza", "Key3")

				' set the controls' DataSource property
				Select1.DataSource = ht
				Select2.DataSource = ht
				Listbox1.DataSource = ht
				DropdownList1.DataSource = ht
				CheckList1.DataSource = ht
				OptionList1.DataSource = ht

				' bind the data to all the control
				Page.DataBind()
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
'			Me.cmdGetSelection.Click += New System.EventHandler(Me.cmdGetSelection_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdGetSelection_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGetSelection.Click
			Result.Text += "- Item selected in Select1: " + Select1.Items(Select1.SelectedIndex).Text + " - " + Select1.Value + "<br>"
			Result.Text += "- Item selected in Select2: " + Select2.Items(Select2.SelectedIndex).Text + " - " + Select2.Value + "<br>"
			Result.Text += "- Item selected in Listbox1: " + Listbox1.SelectedItem.Text + " - " + Listbox1.SelectedItem.Value + "<br>"
			Result.Text += "- Item selected in DropdownList1: " + DropdownList1.SelectedItem.Text + " - " + DropdownList1.SelectedItem.Value + "<br>"
			Result.Text += "- Item selected in OptionList1: " + OptionList1.SelectedItem.Text + " - " + OptionList1.SelectedItem.Value + "<br>"
			Result.Text += "- Items selected in CheckList1: "
			For Each li As ListItem In CheckList1.Items
				If li.Selected Then
					Result.Text += li.Text + " - " + li.Value + " "
				End If
			Next li
		End Sub
	End Class
End Namespace
