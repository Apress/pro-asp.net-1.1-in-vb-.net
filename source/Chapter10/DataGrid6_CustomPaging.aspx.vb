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
	''' Summary description for DataGridSimplePaging.
	''' </summary>
	Public Class DataGridCustomPaging : Inherits System.Web.UI.Page
		Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid

		Private connectionString As String = "Data Source=localhost;" + "Initial Catalog=Northwind;Integrated Security=SSPI"

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				SetGridItemCount()
				BindGrid()
			End If
		End Sub

		Private Sub SetGridItemCount()
			' Create the Command and the Connection.
			Dim sql As String = "SELECT COUNT(*) FROM Employees"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand(sql, con)
			con.Open()

			' Execute the command and use the return value for the
			' VirtualItemCount property.
			Datagrid1.VirtualItemCount = CInt(cmd.ExecuteScalar())
			con.Close()
		End Sub

		Private Sub BindGrid()
			' Define a Command that uses the stored procedure.
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand("GetEmployeesByPage", con)
			cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add(New SqlParameter("@PageNumber", SqlDbType.Int, 4))
			cmd.Parameters("@PageNumber").Value = Datagrid1.CurrentPageIndex + 1
			cmd.Parameters.Add(New SqlParameter("@PageSize", SqlDbType.Int, 4))
			cmd.Parameters("@PageSize").Value = Datagrid1.PageSize

			' Open the Connection and get the DataReader.
			con.Open()
			Dim reader As SqlDataReader = cmd.ExecuteReader()

			' Bind the DataReader to the DataGrid.
			Datagrid1.DataSource = reader
			Datagrid1.DataBind()

			' Clean up.
			reader.Close()
			con.Close()
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
'			Me.Datagrid1.PageIndexChanged += New System.Web.UI.WebControls.DataGridPageChangedEventHandler(Me.Datagrid1_PageIndexChanged);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub Datagrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid1.PageIndexChanged
			' deselect the currently selected row, if any
			Datagrid1.SelectedIndex = -1

			' change the current page and rebind
			Datagrid1.CurrentPageIndex = e.NewPageIndex
			BindGrid()

		End Sub
	End Class
End Namespace
