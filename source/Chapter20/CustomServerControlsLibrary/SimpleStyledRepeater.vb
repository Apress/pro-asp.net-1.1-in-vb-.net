Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel

Namespace CustomServerControlsLibrary
	<ParseChildren(True)> _
	Public Class SimpleStyledRepeater : Inherits WebControl : Implements INamingContainer
		Public Sub New()
			MyBase.New()
			RepeatCount = 1

			' Note that in order to reduce page size, this
			' control doesn't store style information in view state.
			' That means if you change styles programmatically,
			' the changes will be lost after each postback.
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

        <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(SimpleRepeaterItem))> _
        Public Property ItemTemplate() As ITemplate
            Get
                Return itlItemTemplate
            End Get
            Set(ByVal Value As ITemplate)
                itlItemTemplate = Value
            End Set
        End Property

        Private itlAlternatingItemTemplate As ITemplate

        <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(SimpleRepeaterItem))> _
        Public Property AlternatingItemTemplate() As ITemplate
            Get
                Return itlAlternatingItemTemplate
            End Get
            Set(ByVal Value As ITemplate)
                itlAlternatingItemTemplate = Value
            End Set
        End Property

        Private itlHeaderTemplate As ITemplate

        <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(SimpleRepeaterItem))> _
        Public Property HeaderTemplate() As ITemplate
            Get
                Return itlHeaderTemplate
            End Get
            Set(ByVal Value As ITemplate)
                itlHeaderTemplate = Value
            End Set
        End Property

        Private itlFooterTemplate As ITemplate

        <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(SimpleRepeaterItem))> _
        Public Property FooterTemplate() As ITemplate
            Get
                Return itlFooterTemplate
            End Get
            Set(ByVal Value As ITemplate)
                itlFooterTemplate = Value
            End Set
        End Property

        Private stylItemStyle As Style
        Private stylAlternatingItemStyle As Style
        Private stylHeaderStyle As Style
        Private stylFooterStyle As Style

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(True), PersistenceMode(PersistenceMode.InnerProperty)> _
        Public ReadOnly Property ItemStyle() As Style
            Get
                If ItemStyle Is Nothing Then
                    ItemStyle = New Style
                    If IsTrackingViewState Then
                        CType(ItemStyle, IStateManager).TrackViewState()
                    End If
                End If
                Return ItemStyle
            End Get
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(True), PersistenceMode(PersistenceMode.InnerProperty)> _
        Public ReadOnly Property AlternatingItemStyle() As Style
            Get
                If AlternatingItemStyle Is Nothing Then
                    AlternatingItemStyle = New Style
                    If IsTrackingViewState Then
                        CType(AlternatingItemStyle, IStateManager).TrackViewState()
                    End If
                End If
                Return AlternatingItemStyle
            End Get
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(True), PersistenceMode(PersistenceMode.InnerProperty)> _
        Public ReadOnly Property HeaderStyle() As Style
            Get
                If HeaderStyle Is Nothing Then
                    HeaderStyle = New Style
                    If IsTrackingViewState Then
                        CType(HeaderStyle, IStateManager).TrackViewState()
                    End If
                End If
                Return HeaderStyle
            End Get
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(True), PersistenceMode(PersistenceMode.InnerProperty)> _
        Public ReadOnly Property FooterStyle() As Style
            Get
                If FooterStyle Is Nothing Then
                    FooterStyle = New Style
                    If IsTrackingViewState Then
                        CType(FooterStyle, IStateManager).TrackViewState()
                    End If
                End If
                Return FooterStyle
            End Get
        End Property

        Protected Overrides Sub CreateChildControls()
            Controls.Clear()

            If (RepeatCount > 0) AndAlso (Not itlItemTemplate Is Nothing) Then
                ' Start by outputing the header template (if supplied).
                If Not HeaderTemplate Is Nothing Then
                    Dim headerContainer As SimpleRepeaterItem = New SimpleRepeaterItem(0, RepeatCount)
                    HeaderTemplate.InstantiateIn(headerContainer)
                    Controls.Add(headerContainer)

                    If Not HeaderStyle Is Nothing Then
                        headerContainer.ApplyStyle(HeaderStyle)
                    End If
                End If

                ' Output the content the specified number of times.
                For i As Integer = 0 To RepeatCount - 1
                    Dim container As SimpleRepeaterItem = New SimpleRepeaterItem(i + 1, RepeatCount)

                    ' Create a style for alternate items.
                    Dim altStyle As Style = New Style
                    altStyle.MergeWith(ItemStyle)
                    altStyle.CopyFrom(AlternatingItemStyle)

                    If (i Mod 2 = 0) AndAlso (Not AlternatingItemTemplate Is Nothing) Then
                        ' This is an alternating item and there is an alternating template.
                        AlternatingItemTemplate.InstantiateIn(container)
                        container.ApplyStyle(altStyle)
                    Else
                        itlItemTemplate.InstantiateIn(container)
                        If Not ItemStyle Is Nothing Then
                            container.ApplyStyle(ItemStyle)
                        End If
                    End If

                    Controls.Add(container)
                Next i

                ' Once all of the items have been rendered,
                ' add the footer template if specified.
                If Not FooterTemplate Is Nothing Then
                    Dim footerContainer As SimpleRepeaterItem = New SimpleRepeaterItem(RepeatCount, RepeatCount)
                    FooterTemplate.InstantiateIn(footerContainer)
                    Controls.Add(footerContainer)
                    If Not FooterStyle Is Nothing Then
                        footerContainer.ApplyStyle(FooterStyle)
                    End If
                End If
            Else
                ' Show an error message.
                Controls.Add(New LiteralControl("Specify the record count and an item template"))
            End If
        End Sub

        Public Overrides Sub DataBind()
            EnsureChildControls()
            MyBase.DataBind()
        End Sub


    End Class

End Namespace
