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

Namespace Chapter19
	''' <summary>
	''' Summary description for DynamicUserControls.
	''' </summary>
	Public Class DynamicUserControls : Inherits System.Web.UI.Page
		Protected lstControls1 As System.Web.UI.WebControls.DropDownList
		Protected PlaceHolder1 As System.Web.UI.WebControls.PlaceHolder
		Protected PanelLabel1 As System.Web.UI.WebControls.Label
		Protected PlaceHolder2 As System.Web.UI.WebControls.PlaceHolder
		Protected DropDownList2 As System.Web.UI.WebControls.DropDownList
		Protected Label3 As System.Web.UI.WebControls.Label
		Protected DropDownList3 As System.Web.UI.WebControls.DropDownList
		Protected Label4 As System.Web.UI.WebControls.Label
		Protected DIV1 As System.Web.UI.HtmlControls.HtmlGenericControl
		Protected DIV2 As System.Web.UI.HtmlControls.HtmlGenericControl
		Protected DIV3 As System.Web.UI.HtmlControls.HtmlGenericControl
		Protected PlaceHolder3 As System.Web.UI.WebControls.PlaceHolder


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
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			LoadControls(DIV1)
			LoadControls(DIV2)
			LoadControls(DIV3)
		End Sub

		Private Sub LoadControls(ByVal container As Control)
			Dim list As DropDownList = Nothing
			Dim ph As PlaceHolder = Nothing
			Dim lbl As Label = Nothing

			' Find the controls for this panel.
			For Each ctrl As Control In container.Controls
				If TypeOf ctrl Is DropDownList Then
					list = CType(ctrl, DropDownList)
				Else If TypeOf ctrl Is PlaceHolder Then
					ph = CType(ctrl, PlaceHolder)
				Else If TypeOf ctrl Is Label Then
					lbl = CType(ctrl, Label)
				End If
			Next ctrl

			' Load the dynamic content into this panel.
			Dim ctrlName As String = list.SelectedItem.Value
			If ctrlName.EndsWith(".ascx") Then
				ph.Controls.Add(Page.LoadControl(ctrlName))
			End If
			lbl.Text = "Loaded..." + ctrlName
		End Sub

	End Class
End Namespace
