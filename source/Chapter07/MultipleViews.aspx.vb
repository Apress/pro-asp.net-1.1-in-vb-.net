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
Imports System.Data.OleDb

Namespace DataCaching
	''' <summary>
	''' Summary description for MultipleViews.
	''' </summary>
	Public Class MultipleViews : Inherits System.Web.UI.Page
		Protected lblCacheStatus As System.Web.UI.WebControls.Label
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected chkColumns As System.Web.UI.WebControls.CheckBoxList
		Protected gridPubs As System.Web.UI.WebControls.DataGrid
		Protected WithEvents cmdApply As System.Web.UI.WebControls.Button

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Me.IsPostBack) Then
				Cache.Remove("Titles")

				Dim dsPubs As DataSet
				If Cache("Titles") Is Nothing Then
					dsPubs = RetrieveData()
					Cache.Insert("Titles", dsPubs, Nothing, DateTime.MaxValue, TimeSpan.FromMinutes(2))
					lblCacheStatus.Text = "Created and added to cache."
				Else
					dsPubs = CType(Cache("Titles"), DataSet)
					lblCacheStatus.Text = "Retrieved from cache."
				End If
				chkColumns.DataSource = dsPubs.Tables(0).Columns
				chkColumns.DataMember = "Item"
				chkColumns.DataBind()
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
'			Me.cmdApply.Click += New System.EventHandler(Me.cmdApply_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Function RetrieveData() As DataSet
			Dim connectionString As String
			connectionString = "Provider=SQLOLEDB.1; " + "Data Source=localhost;Initial Catalog=Pubs;Integrated Security=SSPI"

			Dim SQLSelect As String = "SELECT * FROM Titles"

			' Define ADO.NET objects.
			Dim con As OleDbConnection = New OleDbConnection(connectionString)
			Dim cmd As OleDbCommand = New OleDbCommand(SQLSelect, con)
			Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
			Dim dsPubs As DataSet = New DataSet()

			con.Open()
			adapter.Fill(dsPubs, "Titles")
			con.Close()

			Return dsPubs
		End Function

		Private Sub cmdApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdApply.Click
			Dim dsPubs As DataSet
			If Cache("Titles") Is Nothing Then
				dsPubs = RetrieveData()
				Cache.Insert("Titles", dsPubs, Nothing, DateTime.MaxValue, TimeSpan.FromMinutes(2))
				lblCacheStatus.Text = "Created and added to cache."
			Else
				dsPubs = CType(Cache("Titles"), DataSet)
				dsPubs = dsPubs.Copy()
				lblCacheStatus.Text = "Retrieved from cache."
			End If

			For Each item As ListItem In chkColumns.Items
				If item.Selected Then
					dsPubs.Tables(0).Columns.Remove(item.Text)
				End If
			Next item

			gridPubs.DataSource = dsPubs.Tables(0)
			gridPubs.DataBind()

		End Sub

	End Class
End Namespace
