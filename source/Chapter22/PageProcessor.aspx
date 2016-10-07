<%@ Page Language = "vb" Codebehind="PageProcessor.aspx.vb" AutoEventWireup="false" Inherits="Chapter22.PageProcessor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>LoadPage</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
	var iLoopCounter = 1;
	var iMaxLoop = 5;
	var iIntervalId;
	
	function BeginPageLoad()
	{
	    /* Redirect the browser to another page while keeping focus */
		location.href = "<%=PageToLoad %>";
		/* Update progress meter every 1/2 second */
		iIntervalId = window.setInterval("iLoopCounter=UpdateProgressMeter(iLoopCounter,iMaxLoop)", 500);
	}
	function EndPageLoad()
	{
		window.clearInterval(iIntervalId);
		ProgressMeter.innerText = "Page Loaded - Now Transfering";
	}
	function UpdateProgressMeter(iCurrentLoopCounter, iMaximumLoops)
	{
		iCurrentLoopCounter += 1;
		if(iCurrentLoopCounter <= iMaximumLoops)
		 {
			ProgressMeter.innerText += ".";
			return iCurrentLoopCounter
		 }
		else
		 {
			ProgressMeter.innerText = "";
			return 1;
		 }
	}	
		</script>
	</HEAD>
	<body onLoad="javascript:BeginPageLoad();" onUnload="javascript:EndPageLoad();">
		<form id="frmPageLoader" method="post" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" width="99%" height="99%" align="center"
				vAlign="middle">
				<tr>
					<td align="center" vAlign="middle">
						<font color="navy" size="5"><span id="MessageText">Loading Page - Please Wait</span>
							<span id="ProgressMeter" style="WIDTH:25px;TEXT-ALIGN:left"></span></font>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
