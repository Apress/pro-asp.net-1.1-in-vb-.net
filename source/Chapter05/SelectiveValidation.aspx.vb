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

Namespace Recipe07_10
	''' <summary>
	''' Summary description for SelectiveValidation.
	''' </summary>
	Public Class SelectiveValidation : Inherits System.Web.UI.Page
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected txtNumber As System.Web.UI.WebControls.TextBox
		Protected Label2 As System.Web.UI.WebControls.Label
		Protected txtEmail As System.Web.UI.WebControls.TextBox
		Protected lblCustomSummary As System.Web.UI.WebControls.Label
		Protected RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
		Protected RangeValidator1 As System.Web.UI.WebControls.RangeValidator
		Protected RegularExpressionValidator2 As System.Web.UI.WebControls.RegularExpressionValidator
		Protected WithEvents cmdValidate As System.Web.UI.WebControls.Button

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
'			Me.cmdValidate.Click += New System.EventHandler(Me.cmdValidate_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdValidate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdValidate.Click
			' Validate the page.
			Me.Validate()

			If (Not Page.IsValid) Then
				lblCustomSummary.Text = ""
				For Each validator As BaseValidator In Me.Validators
					If (Not validator.IsValid) Then
						Dim invalidControl As TextBox = CType(Me.FindControl(validator.ControlToValidate), TextBox)
						lblCustomSummary.Text += "The page contains the following error: <b>" + validator.ErrorMessage + "</b>.<br>" + "The invalid input is: <b>" + invalidControl.Text + "</b>." + "<br><br>"
					End If
				Next validator
			Else
				lblCustomSummary.Text = "Validation succeeded."
			End If
		End Sub
	End Class
End Namespace
