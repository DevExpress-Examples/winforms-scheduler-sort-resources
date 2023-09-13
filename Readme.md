<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128636090/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3124)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms Scheduler - Sort resources

This example shows how to create a comparer to sort Scheduler resources based on a specific condition (in this example, the `Resource.Caption` and the number of resource appointments).

The example also demonstrates how to prevent sorting ("ResourceNOfAppointments" mode) for an "Unassigned" resource. This resource is always displayed first.

The [SchedulerStorageBase.ResourceCollectionLoaded](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraScheduler.SchedulerStorageBase.ResourceCollectionLoaded) event is handled to automaticcally sort resources when the underlying collection changes:

```csharp
private void schedulerStorage1_ResourceCollectionLoaded(object sender, System.EventArgs e) {
    ApplySorting();
}

private void ApplySorting() {
    IComparer<Resource> comparer = null;
    if (CurrentSortOrder == ResourcesSortOrder.Ascending)
        comparer = new ResourceCaptionComparer();
    else if (CurrentSortOrder == ResourcesSortOrder.Descending)
        comparer = new ResourceCaptionReverseComparer();
    else if (CurrentSortOrder == ResourcesSortOrder.NOfAppointments)
        comparer = new ResourceNOfAppointmentsComparer(schedulerStorage1);
    else
        return;
    schedulerStorage1.Resources.Items.Sort(comparer);
    schedulerControl1.ActiveView.LayoutChanged();
}
```


## Files to Review

* [Comparers.cs](./CS/Comparers.cs) (VB: [Comparers.vb](./VB/Comparers.vb))
* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))


## Documentation

* [Resources for Appointments](https://docs.devexpress.com/WindowsForms/1756/controls-and-libraries/scheduler/appointments/resources-for-appointments)
