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
Imports localhost

Namespace WebClient
	''' <summary>
	''' Summary description for WebForm1.
	''' </summary>
	Public Class WebForm1 : Inherits System.Web.UI.Page
		Protected DataGrid1 As System.Web.UI.WebControls.DataGrid
		Protected WithEvents cmdGetData As System.Web.UI.WebControls.Button

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
'			Me.cmdGetData.Click += New System.EventHandler(Me.cmdGetData_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdGetData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGetData.Click
			' Create the proxy.
			Dim proxy As EmployeesService = New EmployeesService()

			' Uncomment these lines to use the tracing utility
			' (described in Chapter 25).
			'Uri newUrl = new Uri(proxy.Url);
			'proxy.Url = newUrl.Scheme + "://" + newUrl.Host + ":8080" + newUrl.AbsolutePath;

			' Call the web service and get the results.
			Dim ds As DataSet = proxy.GetEmployees()

			' Bind the results.
			DataGrid1.DataSource = ds
			DataGrid1.DataBind()
		End Sub



	End Class
End Namespace
