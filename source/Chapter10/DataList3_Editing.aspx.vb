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
	Public Class DataList3 : Inherits System.Web.UI.Page
		Protected MoreInfo As System.Web.UI.WebControls.Label
		Protected WithEvents Datalist1 As DataList

		Private connectionString As String = "Data Source=localhost;" + "Initial Catalog=Northwind;Integrated Security=SSPI"

		Protected ReadOnly Property TitlesOfCourtesy() As String()
			Get
				Return New String(3){"Mr.", "Dr.", "Ms.", "Mrs."}
			End Get
		End Property

		Protected Function GetSelectedTitle(ByVal title As Object) As Integer
			Return Array.IndexOf(TitlesOfCourtesy, title.ToString())
		End Function

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				BindList()
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
'			Me.Datalist1.CancelCommand += New System.Web.UI.WebControls.DataListCommandEventHandler(Me.Datalist1_Cancel);
'			Me.Datalist1.EditCommand += New System.Web.UI.WebControls.DataListCommandEventHandler(Me.Datalist1_Edit);
'			Me.Datalist1.UpdateCommand += New System.Web.UI.WebControls.DataListCommandEventHandler(Me.Datalist1_Update);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub Datalist1_Edit(ByVal sender As Object, ByVal e As DataListCommandEventArgs) Handles Datalist1.EditCommand
			Datalist1.EditItemIndex = CInt(e.Item.ItemIndex)
			BindList()
		End Sub

		Private Sub Datalist1_Cancel(ByVal sender As Object, ByVal e As DataListCommandEventArgs) Handles Datalist1.CancelCommand
			Datalist1.EditItemIndex = -1
			BindList()
		End Sub

		Private Sub Datalist1_Update(ByVal sender As Object, ByVal e As DataListCommandEventArgs) Handles Datalist1.UpdateCommand
			' Get the ID of the record to update.
			Dim empID As Integer = CInt(Datalist1.DataKeys(e.Item.ItemIndex))

			' Get the references to the edit controls.
			Dim title As DropDownList = CType(e.Item.FindControl("EditTitle"), DropDownList)
			Dim lastName As TextBox = CType(e.Item.FindControl("EditLastName"), TextBox)
			Dim firstName As TextBox = CType(e.Item.FindControl("EditFirstName"), TextBox)

			' Create the Connection and the Command.
			Dim sql As String = "UPDATE Employees SET TitleOfCourtesy = @TitleOfCourtesy, " + "LastName = @LastName, FirstName = @FirstName WHERE EmployeeID = @EmployeeID"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand(sql, con)

			' Create the required parameters.
			cmd.Parameters.Add(New SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25))
			cmd.Parameters("@TitleOfCourtesy").Value = title.SelectedItem.Text.Trim()
			cmd.Parameters.Add(New SqlParameter("@LastName", SqlDbType.NVarChar, 20))
			cmd.Parameters("@LastName").Value = lastName.Text.Trim()
			cmd.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.NVarChar, 10))
			cmd.Parameters("@FirstName").Value = firstName.Text.Trim()
			cmd.Parameters.Add(New SqlParameter("@EmployeeID", SqlDbType.Int, 4))
			cmd.Parameters("@EmployeeID").Value = empID

			' Execute the Command.
			Try
				con.Open()
				cmd.ExecuteNonQuery()
			Finally
				cmd.Connection.Close()
			End Try

			' Stop the editing and rebind the list.
			Datalist1.EditItemIndex = -1
			BindList()
		End Sub


		Private Sub BindList()
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
		End Sub

	End Class
End Namespace
