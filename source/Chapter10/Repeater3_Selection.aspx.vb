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

Namespace Chapter10
	''' <summary>
	''' Summary description for Repeater1.
	''' </summary>
	Public Class Repeater3 : Inherits System.Web.UI.Page
		Protected MoreInfo As System.Web.UI.WebControls.Label
		Protected WithEvents Repeater1 As System.Web.UI.WebControls.Repeater

		Private connectionString As String = "Data Source=localhost;" + "Initial Catalog=Northwind;Integrated Security=SSPI"

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				Dim sql As String = "SELECT EmployeeID, FirstName, LastName, TitleOfCourtesy FROM Employees"

				' Create the Command and the Connection.		
				Dim con As SqlConnection = New SqlConnection(connectionString)
				Dim cmd As SqlCommand = New SqlCommand(sql, con)

				' Open the connection and get the DataReader.
				con.Open()
				Dim reader As SqlDataReader = cmd.ExecuteReader()

				' Bind the Reader to the Repeater.
				Repeater1.DataSource = reader
				Repeater1.DataBind()

				' Close the DataReader and the Connection.
				reader.Close()
				con.Close()
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
'			Me.Repeater1.ItemCommand += New System.Web.UI.WebControls.RepeaterCommandEventHandler(Me.Repeater1_ItemCommand);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub Repeater1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
			' Create a command to get the full details for the
			' selected record.
			Dim sql As String = "SELECT * FROM Employees WHERE EmployeeID = " + e.CommandArgument
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand(sql, con)

			' Display the full record details.
			con.Open()
			Dim reader As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)
			Dim str As StringBuilder = New StringBuilder()
			reader.Read()
			str.Append("<b>")
			str.Append(reader("FirstName").ToString())
			str.Append(" ")
			str.Append(reader("LastName").ToString())
			str.Append("<br>")
			str.Append(reader("Title").ToString())
			str.Append("<br>")
			str.Append(reader("Address").ToString())
			str.Append("<br>")
			str.Append(reader("City").ToString())
			str.Append(", ")
			str.Append(reader("Region").ToString())
			str.Append("</b><br>")
			str.Append(reader("Notes").ToString())
			MoreInfo.Text = str.ToString()

			' Clean up.
			reader.Close()
			con.Close()

			' Set the ForeColor According to the CommandName.
			MoreInfo.ForeColor = (IIf(e.CommandName = "Select", System.Drawing.Color.DarkBlue, System.Drawing.Color.Maroon))
		End Sub
	End Class
End Namespace
