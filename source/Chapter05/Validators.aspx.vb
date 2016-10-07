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
	Public Class Validators : Inherits System.Web.UI.Page
		Protected WithEvents EnableValidators As System.Web.UI.WebControls.CheckBox
		Protected WithEvents EnableClientSide As System.Web.UI.WebControls.CheckBox
		Protected WithEvents ShowSummary As System.Web.UI.WebControls.CheckBox
		Protected WithEvents ShowMsgBox As System.Web.UI.WebControls.CheckBox
		Protected ValidationSum As System.Web.UI.WebControls.ValidationSummary
		Protected Name As System.Web.UI.WebControls.TextBox
		Protected ValidateName As System.Web.UI.WebControls.RequiredFieldValidator
		Protected ValidateName2 As System.Web.UI.WebControls.RegularExpressionValidator
		Protected EmpID As System.Web.UI.WebControls.TextBox
		Protected ValidateEmpID As System.Web.UI.WebControls.RequiredFieldValidator
		Protected ValidateEmpID2 As System.Web.UI.WebControls.CustomValidator
		Protected DayOff As System.Web.UI.WebControls.TextBox
		Protected ValidateDayOff As System.Web.UI.WebControls.RequiredFieldValidator
		Protected ValidateDayOff2 As System.Web.UI.WebControls.RangeValidator
		Protected Age As System.Web.UI.WebControls.TextBox
		Protected Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected ValidateAge As System.Web.UI.WebControls.CompareValidator
		Protected Email As System.Web.UI.WebControls.TextBox
		Protected Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected ValidateEmail As System.Web.UI.WebControls.RegularExpressionValidator
		Protected Password As System.Web.UI.WebControls.TextBox
		Protected Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected Password2 As System.Web.UI.WebControls.TextBox
		Protected Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
		Protected Comparevalidator1 As System.Web.UI.WebControls.CompareValidator
		Protected Table1 As System.Web.UI.WebControls.Table
		Protected WithEvents Submit As System.Web.UI.WebControls.Button
		Protected Result As System.Web.UI.WebControls.Label

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
'			Me.Submit.Click += New System.EventHandler(Me.Submit_Click);
'			Me.EnableValidators.CheckedChanged += New System.EventHandler(Me.Options_Changed);
'			Me.EnableClientSide.CheckedChanged += New System.EventHandler(Me.Options_Changed);
'			Me.ShowSummary.CheckedChanged += New System.EventHandler(Me.Options_Changed);
'			Me.ShowMsgBox.CheckedChanged += New System.EventHandler(Me.Options_Changed);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub Options_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnableValidators.CheckedChanged, EnableClientSide.CheckedChanged, ShowSummary.CheckedChanged, ShowMsgBox.CheckedChanged
			For Each valCtl As BaseValidator In Page.Validators
				valCtl.Enabled=EnableValidators.Checked
				valCtl.EnableClientScript = EnableClientSide.Checked
			Next valCtl
			ValidationSum.ShowMessageBox = ShowMsgBox.Checked
			ValidationSum.ShowSummary = ShowSummary.Checked
		End Sub

		Private Sub Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit.Click
			If Page.IsValid Then
				Result.Text = "Thanks for sending your data"
			Else
				Result.Text = "There are some errors, please correct them and re-send the form."
			End If
		End Sub

		Private Sub EmpIDServerValidate(ByVal sender As Object, ByVal args As ServerValidateEventArgs)
			Try
                args.IsValid = (Integer.Parse(args.Value) Mod 5 = 0)
			Catch
				args.IsValid = False
			End Try
		End Sub
	End Class
End Namespace
