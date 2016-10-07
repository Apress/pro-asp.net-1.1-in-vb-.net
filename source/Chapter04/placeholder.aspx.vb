Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System


Public Class placeholder
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents PlaceHolder1 As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents newButton As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents newTextBox As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim strTest As String
        strTest = Request.Headers(0).ToString
        strTest = Request.UserAgent

        Dim strTest2 As String
        strTest2 = strTest

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        Dim foundButton As Button
        Dim ctl As Control
        ctl = Page.FindControl("newButton")
        Try
            foundButton = CType(ctl, Button)
            If Not (foundButton Is Nothing) Then
                foundButton.Parent.Controls.Remove(foundButton)
            End If
        Catch ex As Exception
            ' You hit an error, probably in casting
        End Try


    End Sub
End Class
