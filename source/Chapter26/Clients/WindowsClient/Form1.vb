Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports localhost
Imports System.Web.Services.Protocols


Namespace WindowsClient
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1 : Inherits System.Windows.Forms.Form
		Private dataGrid1 As System.Windows.Forms.DataGrid
		Private WithEvents cmdGetEmployees As System.Windows.Forms.Button
		Private WithEvents cmdTest As System.Windows.Forms.Button
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.dataGrid1 = New System.Windows.Forms.DataGrid()
			Me.cmdGetEmployees = New System.Windows.Forms.Button()
			Me.cmdTest = New System.Windows.Forms.Button()
			CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' dataGrid1
			' 
			Me.dataGrid1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.dataGrid1.DataMember = ""
			Me.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.dataGrid1.Location = New System.Drawing.Point(8, 8)
			Me.dataGrid1.Name = "dataGrid1"
			Me.dataGrid1.Size = New System.Drawing.Size(496, 252)
			Me.dataGrid1.TabIndex = 0
			' 
			' cmdGetEmployees
			' 
			Me.cmdGetEmployees.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cmdGetEmployees.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdGetEmployees.Location = New System.Drawing.Point(372, 268)
			Me.cmdGetEmployees.Name = "cmdGetEmployees"
			Me.cmdGetEmployees.Size = New System.Drawing.Size(132, 28)
			Me.cmdGetEmployees.TabIndex = 1
			Me.cmdGetEmployees.Text = "Get Employees (Async)"
'			Me.cmdGetEmployees.Click += New System.EventHandler(Me.cmdGetEmployees_Click);
			' 
			' cmdTest
			' 
			Me.cmdTest.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdTest.Location = New System.Drawing.Point(8, 268)
			Me.cmdTest.Name = "cmdTest"
			Me.cmdTest.Size = New System.Drawing.Size(188, 28)
			Me.cmdTest.TabIndex = 2
			Me.cmdTest.Text = "Click Me While the Call is Underway"
'			Me.cmdTest.Click += New System.EventHandler(Me.cmdTest_Click);
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
			Me.ClientSize = New System.Drawing.Size(512, 306)
			Me.Controls.Add(Me.cmdTest)
			Me.Controls.Add(Me.cmdGetEmployees)
			Me.Controls.Add(Me.dataGrid1)
			Me.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.Name = "Form1"
			Me.Text = "EmployeesService Client"
			CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.Run(New Form1())
		End Sub


		Private Sub cmdGetEmployees_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGetEmployees.Click
			' Disable the button so that only one asynchronous
			' call will be permitted at a time.
			cmdGetEmployees.Enabled = False

			' Create the proxy.
			Dim proxy As EmployeesService = New EmployeesService()

			' Create the callback delegate.
            Dim callback As AsyncCallback = New AsyncCallback(AddressOf fnCallback)

			' Call the web service asynchronously and
			' pass the callback and the proxy object.
			' There is no need to store the IAsyncResult object,
			' because this example doesn't check the state.
			proxy.BeginGetEmployees(callback, proxy)
		End Sub

        Private Sub fnCallback(ByVal asyncResult As IAsyncResult)
            ' Retrieve the proxy from state.
            Dim proxy As EmployeesService = CType(asyncResult.AsyncState, EmployeesService)

            ' Complete the call.
            Dim ds As DataSet = proxy.EndGetEmployees(asyncResult)

            ' Update the user interface on the right thread.
            Me.Invoke(New UpdateGridDelegate(AddressOf UpdateGrid), New Object() {ds})
        End Sub

        Private Delegate Sub UpdateGridDelegate(ByVal newDataSet As DataSet)
        Private Sub UpdateGrid(ByVal newDataSet As DataSet)
            ' Bind the results.
            dataGrid1.DataSource = newDataSet.Tables(0)

            ' Re-enabled the button for another refresh.
            cmdGetEmployees.Enabled = True
        End Sub

        Private Sub cmdTest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTest.Click
            MessageBox.Show("Even when the web service call is underway, you can interact with this application.")
        End Sub

    End Class
End Namespace
