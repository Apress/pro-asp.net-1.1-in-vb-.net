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

Namespace Chapter21
    ''' <summary>
    ''' Summary description for XmlLabelTest.
    ''' </summary>
    Public Class XmlLabelTest : Inherits System.Web.UI.Page
        Protected RichLabel1 As CustomServerControlsLibrary.RichLabel

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim r As StreamReader = File.OpenText(Server.MapPath("DvdList.xml"))
            Dim text As String = r.ReadToEnd()
            r.Close()

            RichLabel1.Text = text

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
