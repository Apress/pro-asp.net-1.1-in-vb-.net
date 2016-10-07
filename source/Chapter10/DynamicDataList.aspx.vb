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
	Public Class DynamicDataList : Inherits System.Web.UI.Page
		Protected SimpleMode As System.Web.UI.WebControls.RadioButton
		Protected ExtendedMode As System.Web.UI.WebControls.RadioButton
		Protected Datalist1 As System.Web.UI.WebControls.DataList

		Private connectionString As String = "Data Source=localhost;" + "Initial Catalog=Northwind;Integrated Security=SSPI"

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' decide which template must be used
			Dim templateFile As String = (IIf(SimpleMode.Checked, "DataList_SimpleTemplate.ascx", "DataList_ExtTemplate.ascx"))
			' load the item template
			Datalist1.ItemTemplate = Page.LoadTemplate(templateFile)

			' bind to the list 
			BindList()
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


		Private Sub BindList()
			Dim sql As String = "SELECT * FROM Employees"

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
