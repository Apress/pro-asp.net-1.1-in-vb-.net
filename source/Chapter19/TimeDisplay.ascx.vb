Imports Microsoft.VisualBasic
	Imports System
	Imports System.Data
	Imports System.Drawing
	Imports System.Web
	Imports System.Web.UI.WebControls
	Imports System.Web.UI.HtmlControls
Namespace UserControls
  Public Class TimeDisplay : Inherits System.Web.UI.UserControl
    Protected WithEvents lnkDate As System.Web.UI.WebControls.LinkButton

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      If (Not Page.IsPostBack) Then
        RefreshTime()
      End If
    End Sub

#Region "Web Form Designer generated code"
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
      '
      ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
      '
      InitializeComponent()
      MyBase.OnInit(e)
    End Sub

    Private Sub InitializeComponent()
    End Sub
#End Region

    Private strFormat As String
    Public Property Format() As String
      Get
        Return strFormat
      End Get
      Set(ByVal Value As String)
        strFormat = Value
      End Set
    End Property

    Private Sub lnkDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDate.Click
      RefreshTime()
    End Sub

    Public Sub RefreshTime()
      If strFormat = "" Then
        lnkDate.Text = DateTime.Now.ToLongTimeString()
      Else
        ' This will throw an exception for invalid format strings,
        ' which is acceptable.
        lnkDate.Text = DateTime.Now.ToString(strFormat)
      End If
    End Sub

  End Class
End Namespace
