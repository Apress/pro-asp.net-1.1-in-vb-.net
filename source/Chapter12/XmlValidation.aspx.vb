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
Imports System.Xml.Schema
Imports System.IO
Imports System.Xml

Namespace SimpleXML
	''' <summary>
	''' Summary description for XmlValidation.
	''' </summary>
	Public Class XmlValidation : Inherits System.Web.UI.Page
		Protected WithEvents cmdValidate As System.Web.UI.WebControls.Button
		Protected optValid As System.Web.UI.WebControls.RadioButton
		Protected optInvalidData As System.Web.UI.WebControls.RadioButton
		Protected lblStatus As System.Web.UI.WebControls.Label

		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Put user code to initialize the page here
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
'			Me.cmdValidate.Click += New System.EventHandler(Me.cmdValidate_Click);
'			Me.Load += New System.EventHandler(Me.Page_Load);

		End Sub
		#End Region

		Private Sub cmdValidate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdValidate.Click
			Dim filePath As String = ""
			If optValid.Checked Then
				filePath = Server.MapPath("DvdList.xml")
			Else If optInvalidData.Checked Then
				filePath += Server.MapPath("DvdListInvalid.xml")
			End If

			lblStatus.Text=""

			' Open the XML file.
			Dim fs As FileStream = New FileStream(filePath, FileMode.Open)
			Dim r As XmlTextReader = New XmlTextReader(fs)

			' Create the validating reader.
			Dim vr As XmlValidatingReader = New XmlValidatingReader(r)
			vr.ValidationType = ValidationType.Schema

			' Add the XSD file to the validator.
			Dim schemas As XmlSchemaCollection = New XmlSchemaCollection()
			schemas.Add("", Server.MapPath("DvdList.xsd"))
			vr.Schemas.Add(schemas)

			' Connect the event handler.
			AddHandler vr.ValidationEventHandler, AddressOf MyValidateHandler

			' Read through the document.
			Do While vr.Read()
				' Process document here.
				' If an error is found, an exception will be thrown.
			Loop

			vr.Close()

			lblStatus.Text+="<br>Complete."
		End Sub

		Public Sub MyValidateHandler(ByVal sender As Object, ByVal e As ValidationEventArgs)
			lblStatus.Text += "Error: " + e.Message + "<br>"
		End Sub

	End Class
End Namespace
