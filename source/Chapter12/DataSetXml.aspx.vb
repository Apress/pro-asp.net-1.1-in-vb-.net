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
Imports System.Xml

Namespace Chapter12
	''' <summary>
	''' Summary description for DataSetXml.
	''' </summary>
	Public Class DataSetXml : Inherits System.Web.UI.Page
		Protected Datagrid2 As System.Web.UI.WebControls.DataGrid
		Protected Datagrid1 As System.Web.UI.WebControls.DataGrid

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' create the connection, DataAdapter and DataSet
			Dim connString As String = "Data Source=localhost;database=Northwind;Integrated Security=SSPI"
			Dim sql As String = "SELECT TOP 5 EmployeeID, TitleOfCourtesy, LastName, FirstName FROM Employees"
			Dim conn As SqlConnection = New SqlConnection(connString)
			Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)
			Dim ds As DataSet = New DataSet()

			' Fill the DataSet and fill the first grid.
			da.Fill(ds, "Employees")
			Datagrid1.DataSource = ds.Tables("Employees")
			Datagrid1.DataBind()

			' Generate the XML file.
			Dim xmlFile As String = Server.MapPath("Employees.xml")
			ds.WriteXml(xmlFile, XmlWriteMode.WriteSchema)

			' Load the XML file.
			Dim dsXml As DataSet = New DataSet()
			dsXml.ReadXml(xmlFile)
			' Fill the second grid.
			Datagrid2.DataSource = dsXml.Tables("Employees")
			Datagrid2.DataBind()
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
