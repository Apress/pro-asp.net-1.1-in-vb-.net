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

Namespace RichControls
	''' <summary>
	''' Summary description for Calendar.
	''' </summary>
	Public Class Calendar : Inherits System.Web.UI.Page
		Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar
		Protected lblDates As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("fr-CA")
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
'			Me.Calendar1.DayRender += New System.Web.UI.WebControls.DayRenderEventHandler(Me.Calendar1_DayRender);
'			Me.Calendar1.SelectionChanged += New System.EventHandler(Me.Calendar1_SelectionChanged);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub MyCalendar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			lblDates.Text = "You selected these dates:<br>"

			For Each dt As DateTime In Calendar1.SelectedDates
				lblDates.Text += dt.ToLongDateString() + "<br>"
			Next dt

		End Sub

		Private Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
			lblDates.Text = "You selected these dates:<br>"
			For Each dt As DateTime In Calendar1.SelectedDates
				lblDates.Text += dt.ToLongDateString() + "<br>"
			Next dt

		End Sub

		Private Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar1.DayRender
			If e.Day.IsWeekend Then
				e.Cell.BackColor = System.Drawing.Color.Green
				e.Cell.ForeColor = System.Drawing.Color.Yellow
				e.Day.IsSelectable = False
			End If

		End Sub
	End Class
End Namespace
