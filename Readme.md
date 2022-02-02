<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128542619/17.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2293)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
*Files to look at*:

* [Default.aspx](./CS/Solution/Default.aspx) (VB: [Default.aspx](./VB/Solution/Default.aspx))
* [Default.aspx.cs](./CS/Solution/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Solution/Default.aspx.vb))

# How to show ASPxLoadingPanel during export
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e2293/)**
<!-- run online end -->


<p>When you export a grid with a lage amount of data, you might want to show the ASPxLoadingPanel during exporting. Generally, it is possible to show the LoadingPanel when you start the exporting process. However, you will not be able to determine the moment when it should be hidden, since no events are generated in the client side when the exporting result is shown...</p><p>This example illustrates how to overcome this limit by using the <b>ASPxCallback</b> control. To get the desired results, we've used the Callback control's client-side <a href="https://docs.devexpress.com/AspNet/js-ASPxClientCallback.CallbackComplete"><u>CallbackComplete</u></a> event to hide the LoadingPanel, since this event is raised when a callback initiated by the client <a href="https://docs.devexpress.com/AspNet/js-ASPxClientCallback.PerformCallback(parameter)">ASPxClientCallback.PerformCallback</a> method and processed within the server <a href="https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxCallback.Callback">ASPxCallback.Callback</a> event’s handler returns back to the client. However, since exporting is not possible on callbacks, it is necessary to keep the exported data to a stream in the Session. Then, send a postback to the server and continue the exporting process.</p>

<br/>