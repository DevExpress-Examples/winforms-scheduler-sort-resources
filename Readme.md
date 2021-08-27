<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128636090/14.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3124)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Comparers.cs](./CS/Comparers.cs) (VB: [Comparers.vb](./VB/Comparers.vb))
* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# How to sort resources


<p>This example shows how you can sort scheduler resources. Actual sorting is performed via the <strong>SchedulerStorage.Resources.Items.Sort()</strong> method call. Note that custom comparers (see Comparers.cs file) are used to compare resource items by desired criteria (in this example, this is a <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerResource_Captiontopic"><u>Resource.Caption Property</u></a> and a number of appointments, which each resource has). Also, we demonstrated how to prevent sorting (in "ResourceNOfAppointments" sorting mode) for a special "Unassigned" resource. This resource is always displayed first.</p><p>The original arrangement order could be easily restored via the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_RefreshDatatopic"><u>SchedulerControl.RefreshData Method</u></a>. As for the automatic re-sorting when the underlying collection (which is bound to resources) is changed, handle the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerSchedulerStorageBase_ResourceCollectionLoadedtopic"><u>SchedulerStorageBase.ResourceCollectionLoaded</u></a> Event. Both approaches are illustrated in this example.</p>

<br/>


