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

Namespace Chapter10
	''' <summary>
	''' Summary description for DataGrid1.
	''' </summary>
	Public Class DataGridEditing : Inherits System.Web.UI.Page
		Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid

		Private connectionString As String = "Data Source=localhost;" + "Initial Catalog=Northwind;Integrated Security=SSPI"

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				BindGrid()
			End If
		End Sub

		Private Sub BindGrid()
			' Caching no longer makes sense because the data can change.
			' However, you could keep the caching code and
			' explicitly remove the cached object
			' every time an edit is completed.

			' Create the DataSet.
			Dim ds As DataSet = CreateDataSet()

			' Retrieve the default view for the DataSet.
			Dim dv As DataView = ds.Tables("Employees").DefaultView

			' Set the sort order.
			dv.Sort = CStr(ViewState("SortExpression"))

			' Bind the grid.
			Datagrid1.DataSource = dv
			Datagrid1.DataBind()
		End Sub

		Private Function CreateDataSet() As DataSet
			Dim sql As String = "SELECT * FROM Employees "
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
			Dim ds As DataSet = New DataSet()
			da.Fill(ds, "Employees")
			Return ds
		End Function

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
'			Me.Datagrid1.CancelCommand += New System.Web.UI.WebControls.DataGridCommandEventHandler(Me.Datagrid1_Cancel);
'			Me.Datagrid1.EditCommand += New System.Web.UI.WebControls.DataGridCommandEventHandler(Me.Datagrid1_Edit);
'			Me.Datagrid1.UpdateCommand += New System.Web.UI.WebControls.DataGridCommandEventHandler(Me.Datagrid1_Update);
'			Me.Datagrid1.DeleteCommand += New System.Web.UI.WebControls.DataGridCommandEventHandler(Me.Datagrid1_Delete);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub Datagrid1_Edit(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles Datagrid1.EditCommand
			Datagrid1.EditItemIndex = CInt(e.Item.ItemIndex)
			BindGrid()
		End Sub

		Private Sub Datagrid1_Cancel(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles Datagrid1.CancelCommand
			Datagrid1.EditItemIndex = -1
			BindGrid()
		End Sub

		Private Sub Datagrid1_Update(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles Datagrid1.UpdateCommand
			' Get the ID of the record to update.
			Dim empID As Integer = CInt(Datagrid1.DataKeys(e.Item.ItemIndex))

			' Get the references to the edit controls.
			Dim title As DropDownList = CType(e.Item.FindControl("EditTitle"), DropDownList)
			Dim lastName As TextBox = CType(e.Item.FindControl("EditLastName"), TextBox)
			Dim firstName As TextBox = CType(e.Item.FindControl("EditFirstName"), TextBox)
			Dim city As TextBox = CType(e.Item.Cells(5).Controls(0), TextBox)

			' Create the connection and the UPDATE command.
			Dim sql As String = "UPDATE Employees SET TitleOfCourtesy = @TitleOfCourtesy, "+ "LastName = @LastName, FirstName = @FirstName, City = @City WHERE EmployeeID = @EmployeeID"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand(sql, con)

			' Create the required parameters.
			cmd.Parameters.Add(New SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25))
			cmd.Parameters("@TitleOfCourtesy").Value = title.SelectedItem.Text.Trim()
			cmd.Parameters.Add(New SqlParameter("@LastName", SqlDbType.NVarChar, 20))
			cmd.Parameters("@LastName").Value = lastName.Text.Trim()
			cmd.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.NVarChar, 10))
			cmd.Parameters("@FirstName").Value = firstName.Text.Trim()
			cmd.Parameters.Add(New SqlParameter("@City", SqlDbType.NVarChar, 15))
			cmd.Parameters("@City").Value = city.Text.Trim()
			cmd.Parameters.Add(New SqlParameter("@EmployeeID", SqlDbType.Int, 4))
			cmd.Parameters("@EmployeeID").Value = empID

			' Execute the command.			
			Try
				con.Open()
				cmd.ExecuteNonQuery()
			Catch e1 As SqlException
				' handle exception... 
			Finally
				con.Close()
			End Try

			' Stop the editing and rebind the grid.
			Datagrid1.EditItemIndex = -1
			BindGrid()
		End Sub

		Private Sub Datagrid1_Delete(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles Datagrid1.DeleteCommand
			' Get the ID of the record to update.
			Dim empID As Integer = CInt(Datagrid1.DataKeys(e.Item.ItemIndex))

			' Create the connection and the DELETE command.
			Dim sql As String = "DELETE FROM Employees WHERE EmployeeID = " + empID.ToString()
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand(sql, con)

			' Execute the command.
			Try
				con.Open()
				cmd.ExecuteNonQuery()
			Finally
				con.Close()
			End Try

			' Rebind the grid.
			Datagrid1.EditItemIndex = -1
			BindGrid()
		End Sub

		Protected ReadOnly Property TitlesOfCourtesy() As String()
			Get
				Return New String(3){"Mr.", "Dr.", "Ms.", "Mrs."}
			End Get
		End Property

		Protected Function GetSelectedTitle(ByVal title As Object) As Integer
			Return Array.IndexOf(TitlesOfCourtesy, title.ToString())
		End Function
	End Class
End Namespace
