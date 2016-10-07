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
Imports System.Threading

Namespace WebClient
	''' <summary>
	''' Summary description for WebForm1.
	''' </summary>
	Public Class WebForm1 : Inherits System.Web.UI.Page
		Protected WithEvents cmdSynchronous As System.Web.UI.WebControls.Button
		Protected WithEvents cmdAsynchronous As System.Web.UI.WebControls.Button
		Protected lblInfo As System.Web.UI.WebControls.Label
		Protected WithEvents cmdMultiple As System.Web.UI.WebControls.Button
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
'			Me.cmdSynchronous.Click += New System.EventHandler(Me.cmdSynchronous_Click);
'			Me.cmdAsynchronous.Click += New System.EventHandler(Me.cmdAsynchronous_Click);
'			Me.cmdMultiple.Click += New System.EventHandler(Me.cmdMultiple_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdSynchronous_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSynchronous.Click
			' Record the start time.
			Dim startTime As DateTime = DateTime.Now

			' Get the web service data.
			Dim proxy As EmployeesService = New EmployeesService()
			DataGrid1.DataSource = proxy.GetEmployees()
			DataGrid1.DataBind()

			' Perform some other time-consuming tasks.
			DoSomethingSlow()

			' Determine the total time taken.
			Dim timeTaken As TimeSpan = DateTime.Now.Subtract(startTime)
      lblInfo.Text = "Synchronous operations took " + timeTaken.TotalSeconds.ToString() + " seconds."
		End Sub

		Private Sub cmdAsynchronous_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAsynchronous.Click
			' Record the start time.
			Dim startTime As DateTime = DateTime.Now

			' Start the web service.
			Dim proxy As EmployeesService = New EmployeesService()
			Dim handle As IAsyncResult = proxy.BeginGetEmployees(Nothing, Nothing)

			' Perform some other time-consuming tasks.
			DoSomethingSlow()

			' Retrieve the result. If it isn't ready, wait.
			DataGrid1.DataSource = proxy.EndGetEmployees(handle)
			DataGrid1.DataBind()

			' Determine the total time taken.
			Dim timeTaken As TimeSpan = DateTime.Now.Subtract(startTime)
			lblInfo.Text = "Asynchronous operations took " + timeTaken.TotalSeconds + " seconds."
		End Sub

		Private Sub DoSomethingSlow()
			' Simulate a slow operation by pausing for three seconds.
			System.Threading.Thread.Sleep(3000)
		End Sub

		Private Sub cmdMultiple_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdMultiple.Click
			' Record the start time.
			Dim startTime As DateTime = DateTime.Now

			Dim proxy As EmployeesService = New EmployeesService()

			' Call three methods asynchronously.
			Dim async1 As IAsyncResult = proxy.BeginGetEmployees(Nothing, Nothing)
			Dim async2 As IAsyncResult = proxy.BeginGetEmployees(Nothing, Nothing)
			Dim async3 As IAsyncResult = proxy.BeginGetEmployees(Nothing, Nothing)

			' Create an array of WaitHandle objects.
			Dim waitHandles As WaitHandle() = {async1.AsyncWaitHandle, async2.AsyncWaitHandle, async3.AsyncWaitHandle}

			' Wait for all the calls to finish.
			WaitHandle.WaitAll(waitHandles)

			' You can now retrieve the results.
			Dim ds1 As DataSet = proxy.EndGetEmployees(async1)
			Dim ds2 As DataSet = proxy.EndGetEmployees(async2)
			Dim ds3 As DataSet = proxy.EndGetEmployees(async3)

			Dim dsMerge As DataSet = New DataSet()
			dsMerge.Merge(ds1)
			dsMerge.Merge(ds2)
			dsMerge.Merge(ds3)
			DataGrid1.DataSource = dsMerge
			DataGrid1.DataBind()

			' Determine the total time taken.
			Dim timeTaken As TimeSpan = DateTime.Now.Subtract(startTime)
			lblInfo.Text = "Calling three methods took " + timeTaken.TotalSeconds + " seconds."
		End Sub


	End Class
End Namespace
