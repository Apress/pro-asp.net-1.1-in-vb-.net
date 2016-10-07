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
Imports System.Xml

Namespace SimpleXML
	''' <summary>
	''' Summary description for DataSetToXml.
	''' </summary>
	Public Class DataSetToXml : Inherits System.Web.UI.Page
		Protected XmlControl As System.Web.UI.WebControls.Xml

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim connectionString As String = "Data Source=localhost;Initial Catalog=pubs;Integrated Security=SSPI"
			Dim SQL As String = "SELECT * FROM authors WHERE city='Oakland'"

			' Create the ADO.NET objects.
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand(SQL, con)
			Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
			Dim ds As DataSet = New DataSet("AuthorsDataSet")

			' Retrieve the data.
			con.Open()
			adapter.Fill(ds, "AuthorsTable")
			con.Close()

			' Create the XmlDataDocument that wraps this DataSet.
			Dim dataDoc As XmlDataDocument = New XmlDataDocument(ds)

			' Display the XML data (with the help of an XSLT) in the XML web control.
			XmlControl.Document = dataDoc
			XmlControl.TransformSource = "authors.xslt"

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
