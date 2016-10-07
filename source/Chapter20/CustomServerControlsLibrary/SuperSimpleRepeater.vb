Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel

Namespace CustomServerControlsLibrary
	Public Class SuperSimpleRepeater : Inherits WebControl : Implements INamingContainer
		Public Sub New()
			MyBase.New()
			RepeatCount = 1
		End Sub

		Public Property RepeatCount() As Integer
			Get
				Return CInt(ViewState("RepeatCount"))
			End Get
			Set
				ViewState("RepeatCount") = Value
			End Set
		End Property

        Private itlItemTemplate As ITemplate

		<PersistenceMode(PersistenceMode.InnerProperty)> _
		Public Property ItemTemplate() As ITemplate
			Get
                Return itlItemTemplate
			End Get
			Set
                itlItemTemplate = Value
			End Set
		End Property

		Protected Overrides Sub CreateChildControls()
			'clear out the control colletion if there
			'are any children we want to wipe them out 
			'before starting
			Controls.Clear()

			'as long as we are repeating at least once
			'and the template is defined, then loop and 
			'instantiate the template in a panel
			If (RepeatCount > 0) AndAlso (Not itemTemplate Is Nothing) Then
				For i As Integer = 0 To RepeatCount - 1
					Dim container As Panel = New Panel()
					itemTemplate.InstantiateIn(container)
					Controls.Add(container)
				Next i
			Else 'otherwise we output a message
				Controls.Add(New LiteralControl("Specify the record count and an item template"))
			End If
		End Sub


	End Class
End Namespace
