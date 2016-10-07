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
Imports System.Data.SqlClient

Namespace Chapter20
	''' <summary>
	''' Summary description for DbDropDownHost.
	''' </summary>
	Public Class DbDropDownHost : Inherits System.Web.UI.Page
		Protected submit As System.Web.UI.WebControls.Button
		Protected dropdownSample As CustomServerControlsLibrary.DbDropDown
		Protected Message As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

			If (Not IsPostBack) Then
				Dim cnn As SqlConnection = New SqlConnection("server=(local);database=northwind;uid=sa;pwd=;")
				Dim cmd As SqlCommand = New SqlCommand("Select customerid, contactname from customers",cnn)
				Dim rdr As SqlDataReader

				cnn.Open()
				rdr =cmd.ExecuteReader(CommandBehavior.CloseConnection)

				dropdownSample.DataSource=rdr
				dropdownSample.DataTextField = "contactname"
				dropdownSample.DataValueField="customerid"

				DataBind()
				rdr.Close()
				cnn.Dispose()
				cmd.Dispose()
			End If

			AddHandler dropdownSample.SelectedIndexChanged, AddressOf dropdownSample_SelectedIndexChanged
		End Sub

		Public Sub dropdownSample_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Message.Text = "Index Changed"
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
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region


	End Class
End Namespace
