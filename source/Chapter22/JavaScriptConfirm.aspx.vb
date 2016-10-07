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

Namespace Chapter22
	''' <summary>
	''' Summary description for JavaScriptConfirm.
	''' </summary>
	Public Class JavaScriptConfirm : Inherits System.Web.UI.Page
		Protected cmdSubmit As System.Web.UI.HtmlControls.HtmlInputButton

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim script As String = _
      "<script type='text/javascript' language='JavaScript'>" + ControlChars.CrLf & _
      "  function confirmSubmit() {" + ControlChars.CrLf & _
      "   var doc = document.forms[0];" + ControlChars.CrLf & _
      "   var msg = 'Are you sure you want to submit this data?';" & ControlChars.CrLf & _
      "   if (confirm(msg))" + ControlChars.CrLf & _
      "   {" + ControlChars.CrLf & _
      "     doc.submit();" + ControlChars.CrLf & _
      "   }" + ControlChars.CrLf & _
      "   else" + ControlChars.CrLf & _
      "   {" + ControlChars.CrLf & _
      "     // do nothing" + ControlChars.CrLf & _
      "   }" + ControlChars.CrLf & _
      "  }" + ControlChars.CrLf & _
      " </script>"

			Page.RegisterClientScriptBlock("Confirm", script)

			cmdSubmit.Attributes.Add("onClick", "confirmSubmit();")
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
	End Class
End Namespace
