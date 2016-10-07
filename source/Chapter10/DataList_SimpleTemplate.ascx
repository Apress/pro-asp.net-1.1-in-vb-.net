<%@ Control Language="C#" %>
<%# DataBinder.Eval( ((DataListItem)Container).DataItem, "TitleOfCourtesy") %>
<b><%# DataBinder.Eval( ((DataListItem)Container).DataItem, "LastName") %></b>,
<%# DataBinder.Eval( ((DataListItem)Container).DataItem, "FirstName") %>     