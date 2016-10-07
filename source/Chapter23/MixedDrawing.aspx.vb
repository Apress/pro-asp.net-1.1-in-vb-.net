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
Imports System.Drawing.Drawing2D
Imports System.IO

Namespace Chapter23
	''' <summary>
	''' Summary description for MixedDrawing.
	''' </summary>
	Public Class MixedDrawing : Inherits System.Web.UI.Page
		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Create the in-memory bitmap where you will draw the image. 
			' This bitmap is 450 pixels wide and 100 pixels high.
			Dim image As Bitmap = New Bitmap(450, 100)
			Dim g As Graphics = Graphics.FromImage(image)

			' Ensure high-quality curves.
			g.SmoothingMode = SmoothingMode.AntiAlias

			' Paint the background.
			g.FillRectangle(Brushes.White, 0, 0, 450, 100)

			' Add an ellipse.
			g.FillEllipse(Brushes.PaleGoldenrod, 120, 13, 300, 50)
			g.DrawEllipse(Pens.Green, 120, 13, 299, 49)

			' Draw some text using a fancy font.
			Dim font As Font = New Font("Harrington", 20, FontStyle.Bold)
			g.DrawString("Oranges are tasty!", font, Brushes.DarkOrange, 150, 20)

			' Add a graphic from a file.
			Dim orangeImage As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("oranges.gif"))
			g.DrawImageUnscaled(orangeImage, 0, 0)

			' Render the image to the HTML output stream.
			Response.ContentType = "image/png"
			Dim mem As MemoryStream = New MemoryStream()
			image.Save(mem, System.Drawing.Imaging.ImageFormat.Png)
			mem.WriteTo(Response.OutputStream)

			' Clean up.
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
