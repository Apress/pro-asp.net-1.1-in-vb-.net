Imports System.Data.SqlClient
Public Class WebForm1
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents MyDataGrid As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

Private Sub Page_Load _
(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim connectionString As String
  Dim strSql As String
  connectionString = "Data Source=localhost;Initial Catalog="
  connectionString = connectionString & "Northwind;Integrated Security=SSPI"
  Dim con As New SqlConnection(connectionString)
  strSql = "Select CompanyName, ContactName,ContactTitle, City, FROM Customers"
  Dim cmd As New SqlCommand(strSql, con)
  con.Open()
  Dim reader As SqlDataReader
  reader = cmd.ExecuteReader()
  MyDataGrid.DataSource = reader
  MyDataGrid.DataBind()
  con.Close()
End Sub

End Class
