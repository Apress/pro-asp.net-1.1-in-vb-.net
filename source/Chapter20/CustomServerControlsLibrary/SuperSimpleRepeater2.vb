Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel

Namespace CustomServerControlsLibrary

	Public Class SuperSimpleRepeater2 : Inherits WebControl : Implements INamingContainer
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

    Private nIndex As ITemplate

        <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(SimpleRepeaterItem))> _
        Public Property itlItemTemplate() As ITemplate
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


    Protected Overrides Sub CreateChildControls()
      Controls.Clear()

      If (RepeatCount > 0) AndAlso (Not itlItemTemplate Is Nothing) Then
        ' Start by outputing the header template (if supplied).
        If Not HeaderTemplate Is Nothing Then
          Dim headerContainer As SimpleRepeaterItem = New SimpleRepeaterItem(0, RepeatCount)
          HeaderTemplate.InstantiateIn(headerContainer)
          'headerContainer.DataBind();
          Controls.Add(headerContainer)
        End If

        ' Output the content the specified number of times.
        For i As Integer = 0 To RepeatCount - 1
          Dim container As SimpleRepeaterItem = New SimpleRepeaterItem(i + 1, RepeatCount)

          If (i Mod 2 = 0) AndAlso (Not AlternatingItemTemplate Is Nothing) Then
            ' This is an alternating item and there is an alternating template.
            AlternatingItemTemplate.InstantiateIn(container)
          Else
            itlItemTemplate.InstantiateIn(container)
          End If
          'container.DataBind();
          Controls.Add(container)
        Next i

        ' Once all of the items have been rendered,
        ' add the footer template if specified.
        If Not FooterTemplate Is Nothing Then
          Dim footerContainer As SimpleRepeaterItem = New SimpleRepeaterItem(RepeatCount, RepeatCount)
          FooterTemplate.InstantiateIn(footerContainer)
          'footerContainer.DataBind();
          Controls.Add(footerContainer)
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



	Public Class SimpleRepeaterItem : Inherits WebControl : Implements INamingContainer
    Private nIndex As Integer
    Public ReadOnly Property Index() As Integer
      Get
        Return nIndex
      End Get
    End Property

    Private nTotal As Integer
    Public ReadOnly Property Total() As Integer
      Get
        Return nTotal
      End Get
    End Property

    ' A constructor that allows you to set the index and total count
    ' when you create an item.
    Public Sub New(ByVal itemIndex As Integer, ByVal totalCount As Integer)
      nIndex = itemIndex
      nTotal = totalCount
    End Sub
  End Class
End Namespace
