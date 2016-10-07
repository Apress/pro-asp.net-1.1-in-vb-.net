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

Namespace Chapter08
	''' <summary>
	''' Summary description for SqlInjection.
	''' </summary>
	Public Class SqlInjectionCorrected : Inherits System.Web.UI.Page
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected WithEvents cmdGetRecords As System.Web.UI.WebControls.Button
		Protected txtID As System.Web.UI.WebControls.TextBox
		Protected DataGrid1 As System.Web.UI.WebControls.DataGrid

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
'			Me.cmdGetRecords.Click += New System.EventHandler(Me.cmdGetRecords_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdGetRecords_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGetRecords.Click
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" + "Integrated Security=SSPI"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim sql As String = "SELECT Orders.CustomerID, Orders.OrderID, COUNT(UnitPrice) AS Items, " + "SUM(UnitPrice * Quantity) AS Total FROM Orders " + "INNER JOIN [Order Details] " + "ON Orders.OrderID = [Order Details].OrderID " + "WHERE Orders.CustomerID = @CustID " + "GROUP BY Orders.OrderID, Orders.CustomerID"
			Dim cmd As SqlCommand = New SqlCommand(sql, con)
			cmd.Parameters.Add("@CustID", txtID.Text)

			con.Open()
			Dim reader As SqlDataReader = cmd.ExecuteReader()
			DataGrid1.DataSource = reader
			DataGrid1.DataBind()
			reader.Close()
			con.Close()
		End Sub
	End Class
End Namespace
