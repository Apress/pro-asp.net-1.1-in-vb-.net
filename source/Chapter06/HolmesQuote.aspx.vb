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

Namespace Chapter2
	''' <summary>
	''' Summary description for HolmesQuote.
	''' </summary>
	Public Class HolmesQuote : Inherits System.Web.UI.Page
		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Put user code to initialize the page here

			Dim quotes As SherlockLib.SherlockQuotes = New SherlockLib.SherlockQuotes(Server.MapPath("./sherlock-holmes.xml"))
			Dim quote As SherlockLib.Quotation = quotes.GetRandomQuote()
			Response.Write("<b>" + quote.Source + "</b> (<i>" + quote.Date + "</i>)")
			Response.Write("<blockquote>" + quote.QuotationText + "</blockquote>")

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
