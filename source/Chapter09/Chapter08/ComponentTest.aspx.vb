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
Imports System.Data.SqlClient
Imports System.Text
Imports DatabaseComponent

Namespace Chapter08
	''' <summary>
	''' Summary description for Command3.
	''' </summary>
	Public Class Command3 : Inherits System.Web.UI.Page
		Protected HtmlContent As System.Web.UI.WebControls.Literal

		' Create the database component.
		Private db As EmployeeDB = New EmployeeDB()

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			WriteEmployeesList()

			Dim empID As Integer = db.InsertEmployee(New EmployeeDetails(0, "Mr.", "Bellinaso", "Marco"))
			HtmlContent.Text += "<br>Inserted 1 employee.<br>"

			WriteEmployeesList()

			db.DeleteEmployee(empID)
			HtmlContent.Text += "<br>Deleted 1 employee.<br>"

			WriteEmployeesList()
		End Sub


		Private Sub WriteEmployeesList()
			Dim htmlStr As StringBuilder = New StringBuilder("")

			Dim numEmployees As Integer = db.CountEmployees()
			htmlStr.Append("<br>Total employees: <b>")
			htmlStr.Append(numEmployees.ToString())
			htmlStr.Append("</b><br><br>")

			Dim employees As EmployeeDetails() = db.GetEmployees()
			For Each emp As EmployeeDetails In employees
				htmlStr.Append("<li>")
				htmlStr.Append(emp.EmployeeID)
				htmlStr.Append(" ")
				htmlStr.Append(emp.TitleOfCourtesy)
				htmlStr.Append(" <b>")
				htmlStr.Append(emp.FirstName)
				htmlStr.Append("</b>, ")
				htmlStr.Append(emp.LastName)
				htmlStr.Append("</li>")
			Next emp
			htmlStr.Append("<br>")
			HtmlContent.Text += htmlStr.ToString()
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
