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
Imports System.Web.Security

Namespace Chapter18
	''' <summary>
	''' Summary description for CurrentUserList.
	''' </summary>
	Public Class CurrentUserList : Inherits System.Web.UI.Page
		Protected WithEvents cmdLogOut As System.Web.UI.WebControls.Button
		Protected WithEvents cmdLogin As System.Web.UI.WebControls.Button
		Protected UsersDataList As System.Web.UI.WebControls.DataList

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim users As Hashtable = CType(Application("CurrentUsers"), Hashtable)
			If users.Count > 0 Then
				' Bind the list to the values in the users hashtable.
				UsersDataList.DataSource = users.Values
			Else
				' Bind the list to a string array with a single piece of static text.
				Dim noUsers As String() = {"No users logged in"}
				UsersDataList.DataSource = noUsers
			End If
			 UsersDataList.DataBind()
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
'			Me.cmdLogOut.Click += New System.EventHandler(Me.cmdLogOut_Click);
'			Me.cmdLogin.Click += New System.EventHandler(Me.cmdLogin_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);
'			Me.PreRender += New System.EventHandler(Me.CurrentUserList_PreRender);

		End Sub
		#End Region

		Private Sub cmdLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
			Response.Redirect("Login.aspx")
		End Sub

		Private Sub cmdLogOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLogOut.Click
			If Request.IsAuthenticated Then
				Session.Abandon()
				FormsAuthentication.SignOut()
				Response.Redirect("CurrentUserList.aspx")
			End If
		End Sub

		Private Sub CurrentUserList_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender

		End Sub
	End Class
End Namespace
