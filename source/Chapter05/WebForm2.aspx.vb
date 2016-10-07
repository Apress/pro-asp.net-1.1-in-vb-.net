Imports System
Imports System.Collections
Imports System.Web.UI
Public Class WebForm2
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Protected WithEvents CheckBox1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Text1 As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents Button1 As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents ListBox1 As System.Web.UI.WebControls.ListBox

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
        Response.Write("<h4>Control_ClientID Sample</h4>")
        ' Get the list of all controls.
        Dim myEnumerator As IEnumerator = Controls.GetEnumerator()
        Response.Write("<br>Enumerating Controls Collection<br>")
        While myEnumerator.MoveNext()
            Dim myControl As Control = CType(myEnumerator.Current, Control)
            ' Display the ClientID property.
            Response.Write("<br>The ClientID property of Control : " & myControl.ClientID)
        End While
        Text1.Value = "Hello"

    End Sub

    Private Sub Text1_ServerChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text1.ServerChange

    End Sub

    Private Sub Text1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Text1.Init

    End Sub
End Class
