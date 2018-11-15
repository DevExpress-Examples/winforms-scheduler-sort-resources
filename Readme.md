<!-- default file list -->
*Files to look at*:

* [Comparers.cs](./CS/Comparers.cs) (VB: [Comparers.vb](./VB/Comparers.vb))
* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
<!-- default file list end -->
# How to sort resources


<p>This example shows how you can sort scheduler resources. Actual sorting is performed via the <strong>SchedulerStorage.Resources.Items.Sort()</strong> method call. Note that custom comparers (see Comparers.cs file) are used to compare resource items by desired criteria (in this example, this is a <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerResource_Captiontopic"><u>Resource.Caption Property</u></a> and a number of appointments, which each resource has). Also, we demonstrated how to prevent sorting (in "ResourceNOfAppointments" sorting mode) for a special "Unassigned" resource. This resource is always displayed first.</p><p>The original arrangement order could be easily restored via the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_RefreshDatatopic"><u>SchedulerControl.RefreshData Method</u></a>. As for the automatic re-sorting when the underlying collection (which is bound to resources) is changed, handle the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerSchedulerStorageBase_ResourceCollectionLoadedtopic"><u>SchedulerStorageBase.ResourceCollectionLoaded</u></a> Event. Both approaches are illustrated in this example.</p>

<br/>


