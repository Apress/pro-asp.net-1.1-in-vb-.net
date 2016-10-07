Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.Caching
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Namespace Chapter07
	''' <summary>
	''' Summary description for CacheCallbackTest.
	''' </summary>
	Public Class CacheCallbackTest : Inherits System.Web.UI.Page
		Protected lblInfo As System.Web.UI.WebControls.Label
		Protected WithEvents cmdRemove As System.Web.UI.WebControls.Button
		Protected WithEvents cmdCheck As System.Web.UI.WebControls.Button

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If (Not Me.IsPostBack) Then
				lblInfo.Text += "Creating items...<br>"
				Dim itemA As String = "item A"
				Dim itemB As String = "item B"
				Cache.Insert("itemA", itemA, Nothing, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.Default, New CacheItemRemovedCallback(AddressOf ItemRemovedCallback))
				Cache.Insert("itemB", itemB, Nothing, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.Default, New CacheItemRemovedCallback(AddressOf ItemRemovedCallback))
			End If
		End Sub

		Private Sub cmdCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCheck.Click
			Dim itemList As String = ""
			For Each item As DictionaryEntry In Cache
				itemList += item.Key.ToString() + " "
			Next item
			lblInfo.Text += "<br>Found: " + itemList + "<br>"
		End Sub

		Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
			lblInfo.Text += "<br>Removing itemA.<br>"
			Cache.Remove("itemA")
		End Sub

		Private Sub ItemRemovedCallback(ByVal key As String, ByVal value As Object, ByVal reason As CacheItemRemovedReason)
			' This fires after the request has ended, when the
			' item is removed.

			' If either item has been removed, make sure
			' the other item is also removed.
			If key = "itemA" OrElse key = "itemB" Then
				Cache.Remove("itemA")
				Cache.Remove("itemB")
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
'			Me.cmdRemove.Click += New System.EventHandler(Me.cmdRemove_Click);
'			Me.cmdCheck.Click += New System.EventHandler(Me.cmdCheck_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region


	End Class
End Namespace
