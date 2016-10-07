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
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Formatters.Soap

Namespace Chapter13
	''' <summary>
	''' Summary description for UserLogger.
	''' </summary>
	Public Class UserLoggerSerialization : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label
		Protected WithEvents cmdRead As System.Web.UI.WebControls.Button
		Protected Button1 As System.Web.UI.WebControls.Button
		Protected WithEvents cmdDelete As System.Web.UI.WebControls.Button

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Page.IsPostBack) Then
				Log("Page loaded for the first time.")
			Else
				Log("Page posted back.")
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
'			Me.cmdDelete.Click += New System.EventHandler(Me.cmdDelete_Click);
'			Me.cmdRead.Click += New System.EventHandler(Me.cmdRead_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRead.Click
			If Not ViewState("LogFile") Is Nothing Then
				Dim fileName As String = CStr(ViewState("LogFile"))
				Dim fs As FileStream = New FileStream(fileName, FileMode.Open)
				Try
					' Create a formatter.
					Dim formatter As BinaryFormatter = New BinaryFormatter()

					' Get all the serialized objects.
					Do While fs.Position < fs.Length
						' Deserialize the object from the file.
						Dim entry As LogEntry = CType(formatter.Deserialize(fs), LogEntry)

						' Display its information.
                        lblInfo.Text += entry.theDate.ToString() + "<br>"
						lblInfo.Text += entry.Message + "<br>"
					Loop
				Finally
					If TypeOf fs Is IDisposable Then
						Dim disp As IDisposable = fs
						disp.Dispose()
					End If
				End Try
			End If
		End Sub

		Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
			If Not ViewState("LogFile") Is Nothing Then
				File.Delete(CStr(ViewState("LogFile")))
			End If
		End Sub

		Private Sub Log(ByVal message As String)
			' Check for the file.	
			Dim mode As FileMode
			If ViewState("LogFile") Is Nothing Then
				' First, create a unique user-specific file name.
				ViewState("LogFile") = GetFileName()

				' The log file must be created.
				mode = FileMode.Create
			Else
				' Add to the existing file.
				mode = FileMode.Append
			End If

			' Write the message.
			' A using block ensures the file is automatically closed,
			' even in the case of error.
			Dim fileName As String = CStr(ViewState("LogFile"))
			Dim fs As FileStream = New FileStream(fileName, mode)
			Try
				' Create a LogEntry object.
				Dim entry As LogEntry = New LogEntry(message)

				' Create a formatter.
				Dim formatter As BinaryFormatter = New BinaryFormatter()
				'SoapFormatter formatter = new SoapFormatter();

				' Serialize the object to a file.
				formatter.Serialize(fs, entry)

				' Serialize to a memory stream so you can display it.
				Dim ms As MemoryStream = New MemoryStream()
				formatter.Serialize(ms, entry)

				' Read it back and write it to the Debug window.
				Dim r As StreamReader = New StreamReader(ms, System.Text.Encoding.ASCII)
				ms.Position = 0
				Dim x As String = r.ReadToEnd()
				r.Close()
				ms.Close()
			Finally
				If TypeOf fs Is IDisposable Then
					Dim disp As IDisposable = fs
					disp.Dispose()
				End If
			End Try
		End Sub

		Private Function GetFileName() As String
			' Create a unique filename.
			Dim fileName As String = "user." + Guid.NewGuid().ToString()

			' Put the file in the current web application path.
			Return Path.Combine(Request.PhysicalApplicationPath, fileName)
		End Function
	End Class

	<Serializable()> _
	Public Class LogEntry
        Private strMessage As String
        Private dteDate As DateTime

        Public Property Message() As String
            Get
                Return strMessage
            End Get
            Set(ByVal Value As String)
                strMessage = Value
            End Set
        End Property
        Public Property theDate() As DateTime
            Get
                Return dteDate
            End Get
            Set(ByVal Value As DateTime)
                dteDate = Value
            End Set
        End Property

       Public Sub New(ByVal strMessage As String)
            Me.strMessage = strMessage
            Me.dteDate = DateTime.Now
        End Sub
    End Class

End Namespace
