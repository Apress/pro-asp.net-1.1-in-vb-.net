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

Namespace Chapter23
	''' <summary>
	''' Summary description for CreateChart.
	''' </summary>
	Public Class CreateChart : Inherits System.Web.UI.Page
		Protected Image1 As System.Web.UI.WebControls.Image
		Protected lstPieSlices As System.Web.UI.WebControls.ListBox
		Protected WithEvents cmdAdd As System.Web.UI.WebControls.Button
		Protected txtLabel As System.Web.UI.WebControls.TextBox
		Protected txtValue As System.Web.UI.WebControls.TextBox
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected Label2 As System.Web.UI.WebControls.Label

		' The data that will be used to create the pie chart.
		Private pieSlices As ArrayList = New ArrayList()

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			 ' Retrieve the pie slices that are defined so far.
			If Not Session("ChartData") Is Nothing Then
				pieSlices = CType(Session("ChartData"), ArrayList)
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
'			Me.cmdAdd.Click += New System.EventHandler(Me.cmdAdd_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);
'			Me.PreRender += New System.EventHandler(Me.CreateChart_PreRender);

		End Sub
		#End Region

		Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
			' Create a new pie slice.
			Dim pieSlice As PieSlice = New PieSlice(txtLabel.Text, Single.Parse(txtValue.Text))
			pieSlices.Add(pieSlice)

			' Bind the list box to the new data.
			lstPieSlices.DataSource = pieSlices
			lstPieSlices.DataBind()
		End Sub

		Private Sub CreateChart_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
			' Before rendering the page, store the current collection
			' of pie slices.
			Session("ChartData") = pieSlices
		End Sub
	End Class
End Namespace
