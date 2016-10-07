Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.ComponentModel

Namespace CustomServerControlsLibrary
	Public Class DbDropDown : Inherits System.Web.UI.WebControls.WebControl : Implements IPostBackDataHandler
    Private dSource As IEnumerable
    Public Property DataSource() As IEnumerable
      Get
        Return dSource
      End Get
      Set(ByVal Value As IEnumerable)
        dSource = Value
      End Set
    End Property

    Private dataText As String
    Public Property DataTextField() As String
      Get
        Return dataText
      End Get
      Set(ByVal Value As String)
        dataText = Value
      End Set
    End Property

    Private dataValue As String
    Public Property DataValueField() As String
      Get
        Return dataValue
      End Get
      Set(ByVal Value As String)
        dataValue = Value
      End Set
    End Property

    Protected Overrides Sub OnDataBinding(ByVal e As EventArgs)
      MyBase.OnDataBinding(e)

      ' Clear child controls and view state.
      Controls.Clear()
      If HasChildViewState Then
        ClearChildViewState()
      End If

      ' Create controls from data.
      CreateControlHierarchy(True)

      ' Indicate that the controls have been created.
      ChildControlsCreated = True

      ' Turn on view state tracking.
      If IsTrackingViewState Then
        TrackViewState()
      End If
    End Sub


    Private nItemCount As Integer = -1
    Public ReadOnly Property ItemCount() As Integer
      Get
        Return nItemCount
      End Get
    End Property

    Private selectednIndex As Integer
    Public ReadOnly Property SelectedIndex() As Integer
      Get
        Return selectednIndex
      End Get
    End Property

    ' Examine the posted value to see if the index has changed.
    Public Function LoadPostData(ByVal postDataKey As String, ByVal postData As NameValueCollection) As Boolean Implements IPostBackDataHandler.LoadPostData
      Dim selectedValue As String
      Dim currentIndex As Integer = 0
      Dim hasIndexChanged As Boolean = False

      ' Get the posted value.
      selectedValue = postData(postDataKey)

      ' Make sure the controls are created.
      EnsureChildControls()

      ' Loop through the controls selecting the appropriate one
      ' and deselecting all others.
      For Each ctrl As Control In Controls
        If Not IIf(TypeOf ctrl Is DbListItem, CType(ctrl, DbListItem), CType(Nothing, DbListItem)) Is Nothing Then
          If String.Compare((CType(ctrl, DbListItem)).Value, selectedValue, True) = 0 Then
            CType(ctrl, DbListItem).Selected = True

            ' If the index has changed, flip our flag to 
            ' true so our event will be raised.
            If selectednIndex <> currentIndex Then
              selectednIndex = currentIndex
              hasIndexChanged = True
            End If
          Else
            CType(ctrl, DbListItem).Selected = False
          End If
          currentIndex += 1
        End If
      Next ctrl
      Return hasIndexChanged
    End Function

    ' Called if LoadPostData returns true.
    Public Sub RaisePostDataChangedEvent() Implements IPostBackDataHandler.RaisePostDataChangedEvent
      OnSelectedIndexChanged()
    End Sub

    Public Event SelectedIndexChanged As EventHandler

    ' Method to raise the index changed event.
    Protected Sub OnSelectedIndexChanged()
      If Not SelectedIndexChangedEvent Is Nothing Then
        RaiseEvent SelectedIndexChanged(Me, EventArgs.Empty)
      End If
    End Sub

    ' Create the child controls using view state.
    Protected Overrides Sub CreateChildControls()
      Controls.Clear()
      ' If items were created with data, 
      ' then create the hierarchy.
      If nItemCount > 0 Then
        CreateControlHierarchy(False)
      End If
    End Sub

    Protected Sub CreateControlHierarchy(ByVal useDataSource As Boolean)
      Dim items As IEnumerator

      ' Set the enumerator to the data source or the item array.
      If useDataSource Then
        items = dSource.GetEnumerator()
      Else
        items = New DummyDataSource(nItemCount).GetEnumerator()
      End If

      Dim count As Integer = 0

      Do While items.MoveNext()
        Dim item As DbListItem = Nothing
        If useDataSource Then
          Dim itemText As String = CStr(DataBinder.GetPropertyValue(items.Current, DataTextField))
          Dim itemValue As String = CStr(DataBinder.GetPropertyValue(items.Current, DataValueField))

          ' Create the new item with the supplied values.
          item = New DbListItem(itemValue, itemText, False)
          item.TrackViewState()
        Else
          ' Create a new empty item.
          ' It's values will be retrieved from view state.
          item = New DbListItem
        End If

        ' Add the item to the controls collection
        Controls.Add(item)
        count += 1
      Loop

      If useDataSource Then
        ' Store the number of items in a private member variable.
        nItemCount = count
      End If
    End Sub


    Protected Overrides Sub AddAttributesToRender(ByVal writer As HtmlTextWriter)
      MyBase.AddAttributesToRender(writer)
      writer.AddAttribute(HtmlTextWriterAttribute.Id, UniqueID)
      writer.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID)
    End Sub

    Public Sub New()
    End Sub



    ' Restore the view state of the control.
    Protected Overrides Sub LoadViewState(ByVal state As Object)
      '''''			MyBase.New(HtmlTextWriterTag.Select)
      ' Cast the state object to a triplet.
      Dim oldState As Triplet = CType(state, Triplet)

      ' Load the state for the base control.
      MyBase.LoadViewState(oldState.First)

      ' Get the selected index out of the state.
      selectednIndex = CInt(oldState.Second)

      ' Get the item count from state.
      nItemCount = CInt(oldState.Third)
    End Sub

    ' Create the view state for this control.
    Protected Overrides Function SaveViewState() As Object
      ' Create a new triplet with the base state and
      ' the selected index of the list.
      Dim state As Triplet = New Triplet(MyBase.SaveViewState(), selectednIndex, nItemCount)
      Return state
    End Function

  End Class

	' Represents an item in the list.
	Public Class DbListItem : Inherits System.Web.UI.WebControls.WebControl
    Private strText As String
    Public Property Text() As String
      Get
        Return strText
      End Get
      Set(ByVal Value As String)
        strText = Value
      End Set
    End Property

    Private itemValue As String
    Public Property Value() As String
      Get
        Return itemValue
      End Get
      Set(ByVal Value As String)
        itemValue = Value
      End Set
    End Property

    Private bSelected As Boolean
    Public Property Selected() As Boolean
      Get
        Return bSelected
      End Get
      Set(ByVal Value As Boolean)
        bSelected = Value
      End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(ByVal itemValue As String, ByVal strText As String, ByVal isSelected As Boolean)
      Text = strText
      Value = itemValue
      Selected = isSelected
    End Sub

    ' Render the option tag using the properties of the control.
    Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
      ' Add the value attribute.
      output.AddAttribute(HtmlTextWriterAttribute.Value, Value)

      ' If this item is selected, then add that attribute.
      If Selected Then
        output.AddAttribute(HtmlTextWriterAttribute.Selected, "true")
      End If

      ' Render the option tag with the text in it.
      output.RenderBeginTag(HtmlTextWriterTag.Option)
      output.Write(Text)
      output.RenderEndTag()
    End Sub

    ' Internal method to let the list indicate
    ' that this object should track its view state
    Friend Shadows Sub TrackViewState()
      MyBase.TrackViewState()
    End Sub

    ' Load the view state into the object.
    Protected Overrides Sub LoadViewState(ByVal state As Object)
      ' Get the three properties out of
      ' the triplet object that is the state.
      Dim tri As Triplet = CType(state, Triplet)
      Text = CStr(tri.First)
      Value = CStr(tri.Second)
      Selected = CBool(tri.Third)
    End Sub

    ' Save the state of the object.
    Protected Overrides Function SaveViewState() As Object
      ' Create a new triplet with the three properties.
      Dim tri As Triplet = New Triplet(Text, Value, Selected)
      Return tri
    End Function

  End Class

	' The DummyDataSource class provides the ability to
	' create the control hierarchy on postback. 
	Friend NotInheritable Class DummyDataSource : Implements IEnumerable
		Private dataItemCount As Integer

		Public Sub New(ByVal dataItemCount As Integer)
			Me.dataItemCount = dataItemCount
		End Sub

		Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
			Return New DummyDataSourceEnumerator(dataItemCount)
		End Function

		' The enumerator for the dummy data source.
		Private Class DummyDataSourceEnumerator : Implements IEnumerator
			 Private count As Integer
      Private index As Integer

			Public Sub New(ByVal count As Integer)
				Me.count = count
				Me.index = -1
			End Sub

			Public ReadOnly Property Current() As Object Implements IEnumerator.Current
				Get
					Return Nothing
				End Get
			End Property

			Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
				index += 1
				Return index < count
			End Function

			Public Sub Reset() Implements IEnumerator.Reset
				Me.index = -1
			End Sub
		End Class
	End Class

End Namespace
