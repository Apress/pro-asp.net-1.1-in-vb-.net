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


Namespace Chapter21
    ''' <summary>
    ''' Summary description for CustomCalendarTest.
    ''' </summary>
    Public Class CustomCalendarTest : Inherits System.Web.UI.Page
        Protected RestrictedCalendar2 As CustomServerControlsLibrary.RestrictedCalendar
        Protected RestrictedCalendar3 As CustomServerControlsLibrary.RestrictedCalendar
        Protected RestrictedCalendar4 As CustomServerControlsLibrary.RestrictedCalendar
        Protected RestrictedCalendar5 As CustomServerControlsLibrary.RestrictedCalendar
        Protected RestrictedCalendar6 As CustomServerControlsLibrary.RestrictedCalendar
        Protected RestrictedCalendar7 As CustomServerControlsLibrary.RestrictedCalendar
        Protected RestrictedCalendar8 As CustomServerControlsLibrary.RestrictedCalendar
        Protected RestrictedCalendar1 As CustomServerControlsLibrary.RestrictedCalendar

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Put user code to initialize the page here
        End Sub

#Region "Web Form Designer generated code"
        Protected Overrides Sub OnInit(ByVal e As EventArgs)
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
