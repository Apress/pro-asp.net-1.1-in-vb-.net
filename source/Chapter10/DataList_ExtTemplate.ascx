<%@ Control Language="C#" %>
<%# DataBinder.Eval( ((DataListItem)Container).DataItem, "TitleOfCourtesy") %>
<b><%# DataBinder.Eval( ((DataListItem)Container).DataItem, "LastName") %></b>,
<%# DataBinder.Eval( ((DataListItem)Container).DataItem, "FirstName") %><br>
<%# DataBinder.Eval( ((DataListItem)Container).DataItem, "Title") %><br>
<%# DataBinder.Eval( ((DataListItem)Container).DataItem, "Address") %> - 
<%# DataBinder.Eval( ((DataListItem)Container).DataItem, "City") %>, 
<%# DataBinder.Eval( ((DataListItem)Container).DataItem, "Region") %>