<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2293)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# How to show ASPxLoadingPanel during export


<p>When you export a grid with a lage amount of data, you might want to show the ASPxLoadingPanel during exporting. Generally, it is possible to show the LoadingPanel when you start the exporting process. However, you will not be able to determine the moment when it should be hidden, since none of events are generated at the client side when the exporting result is shown...</p><p>This example illustrates how to overcome this limit by using the asp:UpdatePanel. To get the desired result, we've used the <a href="http://msdn.microsoft.com/en-us/library/bb311028.aspx"><u>Sys.WebForms.PageRequestManager</u></a> Class. The Sys.WebForms.PageRequestManager endRequest event is raised after an asynchronous postback is finished and the control has been returned to the browser. Therefore, it is possible to hide the LoadingPanel  in the endRequest event handler. However, when an export button inside the asp:UpdatePane is being clicked, its postback is transformed in an ajax callback. The problem is that when you use ajax you can't continue using the Response.Write, because Ajax doesn't write the entire page, but only some of its parts. So, it is necessary to keep data exported to a stream in the Session. Then you can send a postback to the server side and show the save dialog without ajax.</p><p><strong>Note:</strong> If ASPxGridView exports data for more than 90 seconds, it is necessary to increase the value of the <a href="http://msdn.microsoft.com/en-us/library/system.web.ui.scriptmanager.asyncpostbacktimeout.aspx"><u>ScriptManager.AsyncPostBackTimeout</u></a> property. This allows you to avoid the "The server request timed out" error during export.</p><p><strong>See Also:</strong> <br />
<a href="https://www.devexpress.com/Support/Center/p/E1442">How to use the ASPxLoadingPanel as a progress indicator for AJAX UpdatePanel</a> <br />
<a href="https://www.devexpress.com/Support/Center/p/E5176">GridView - How to show LoadingPanel during export</a></p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-grid-show-loading-panel-during-export&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-grid-show-loading-panel-during-export&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
