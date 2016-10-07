Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports localhost
Imports StatefulWebService
Imports System.Web.Services.Protocols

Namespace WindowsClient
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1 : Inherits System.Windows.Forms.Form
		Private dataGrid1 As System.Windows.Forms.DataGrid
		Private WithEvents cmdGetEmployees As System.Windows.Forms.Button
		Private WithEvents cmdTestState As System.Windows.Forms.Button
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
			Me.cmdTestState = New System.Windows.Forms.Button()
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
			Me.cmdGetEmployees.Location = New System.Drawing.Point(404, 268)
			Me.cmdGetEmployees.Name = "cmdGetEmployees"
			Me.cmdGetEmployees.Size = New System.Drawing.Size(96, 28)
			Me.cmdGetEmployees.TabIndex = 1
			Me.cmdGetEmployees.Text = "Get Employees"
'			Me.cmdGetEmployees.Click += New System.EventHandler(Me.cmdGetEmployees_Click);
			' 
			' cmdTestState
			' 
			Me.cmdTestState.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cmdTestState.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdTestState.Location = New System.Drawing.Point(8, 268)
			Me.cmdTestState.Name = "cmdTestState"
			Me.cmdTestState.Size = New System.Drawing.Size(96, 28)
			Me.cmdTestState.TabIndex = 2
			Me.cmdTestState.Text = "Test State"
'			Me.cmdTestState.Click += New System.EventHandler(Me.cmdTestState_Click);
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
			Me.ClientSize = New System.Drawing.Size(512, 306)
			Me.Controls.Add(Me.cmdTestState)
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

		Private cookieContainer As System.Net.CookieContainer = New System.Net.CookieContainer()

		Private Sub cmdGetEmployees_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGetEmployees.Click
			Me.Cursor = Cursors.WaitCursor

			' Create the proxy.
			Dim proxy As EmployeesService = New EmployeesService()

			' Call the web service and get the results.
			Dim ds As DataSet = proxy.GetEmployees()

			' Bind the results.
			dataGrid1.DataSource = ds.Tables(0)

			Me.Cursor = Cursors.Default
		End Sub

		Private Sub cmdTestState_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTestState.Click
			' Create the proxy.
			Dim proxy As StatefulService = New StatefulService()
			proxy.CookieContainer = cookieContainer

			' Set a name.
			proxy.StoreName("John Smith")

			' Try to retrieve the name.
			MessageBox.Show("You set: " + proxy.GetName())
		End Sub


	End Class
End Namespace
