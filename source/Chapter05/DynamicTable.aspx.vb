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

Namespace Chapter05
	''' <summary>
	''' Summary description for DynamicTable.
	''' </summary>
	Public Class DynamicTable : Inherits System.Web.UI.Page
		Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Create a new HtmlTable object.
			Dim table1 As HtmlTable = New HtmlTable()
			Dim row As HtmlTableRow
			Dim cell As HtmlTableCell

			' Set the table's formatting-related properties.
			table1.Border = 1
			table1.CellPadding = 3
			table1.CellSpacing = 3
			table1.BorderColor = "red"

			' Start adding content to the table.
			For i As Integer = 1 To 5
				' Create a new row and set its background color.
				row = New HtmlTableRow()
                row.BgColor = (IIf((i Mod 2 = 0), "lightyellow", "lightcyan"))

				For j As Integer = 1 To 4
					' Create a cell and set its text.
					cell = New HtmlTableCell()
					cell.InnerHtml = "Row: " + i.ToString() + "<br>Cell: " + j.ToString()

					' Add the cell to the current row.
					row.Cells.Add(cell)
				Next j

				' Add the row to the table.
				table1.Rows.Add(row)
			Next i

			' Add the table to the page.
			Me.Controls.Add(table1)
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
