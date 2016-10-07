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
	''' Summary description for SimpleDrawing.
	''' </summary>
	Public Class SimpleDrawing : Inherits System.Web.UI.Page
		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Create the in-memory bitmap where you will draw the image. 
			' This bitmap is 300 pixels wide and 50 pixels high.
			Dim image As Bitmap = New Bitmap(300, 50)
			Dim g As Graphics = Graphics.FromImage(image)

			' Draw a solid white rectangle..
			' Start from point (1, 1).
			' Make it 298 pixels wide and 48 pixels high.
      g.FillRectangle(Brushes.Yellow, 0, 0, 300, 50)
      g.DrawRectangle(Pens.Green, 0, 0, 299, 49)

			' Draw some text using a fancy font.
			Dim font As Font = New Font("Impact", 20, FontStyle.Regular)
			g.DrawString("This is a test.", font, Brushes.Blue, 10, 5)

			' Render the image to the HTML output stream.
			image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif)

			g.Dispose()
			image.Dispose()

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
