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
	''' Summary description for DataList1.
	''' </summary>
	Public Class DataList2 : Inherits System.Web.UI.Page
		Protected MoreInfo As System.Web.UI.WebControls.Label
		Protected WithEvents Datalist1 As DataList

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
				Datalist1.DataSource = reader
				Datalist1.DataBind()

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

        End Sub
		#End Region

		Private Sub Datalist1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Datalist1.SelectedIndexChanged
			Dim empID As Integer = CInt(Datalist1.DataKeys(Datalist1.SelectedIndex))
			Dim sql As String = "SELECT * FROM Employees WHERE EmployeeID = " + empID.ToString()
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand(sql, con)

			' open the connection and get the Reader
			con.Open()
			Dim reader As SqlDataReader = cmd.ExecuteReader()

			' show the results
			Dim str As StringBuilder = New StringBuilder("")
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

			' close the reader and the connection
			reader.Close()
			con.Close()

			Dim lit As ListItemType = Datalist1.Items(Datalist1.SelectedIndex).ItemType
            MoreInfo.ForeColor = System.Drawing.Color.Maroon
		End Sub

        Private Sub Datalist1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles Datalist1.ItemCommand
            Dim x As String = "Hello"

        End Sub
    End Class
End Namespace
