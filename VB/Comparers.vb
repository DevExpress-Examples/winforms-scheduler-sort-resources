Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports DevExpress.XtraScheduler

Namespace SchedulerSortResources

    Public MustInherit Class ResourceBaseComparer
        Inherits IComparer(Of Resource)
        Implements IComparer

#Region "IComparer Members"
        Private Function Compare(ByVal x As Object, ByVal y As Object) As Integer
            Return Me.CompareCore(x, y)
        End Function

        Public Function Compare(ByVal x As Resource, ByVal y As Resource) As Integer
            Return CompareCore(x, y)
        End Function

#End Region
        Protected Overridable Function CompareCore(ByVal x As Object, ByVal y As Object) As Integer
            Dim xRes As Resource = CType(x, Resource)
            Dim yRes As Resource = CType(y, Resource)
            If xRes Is Nothing OrElse yRes Is Nothing Then Return 0
            If Resource.Empty.Equals(xRes) OrElse Resource.Empty.Equals(yRes) Then Return 0
            Return Me.CompareResources(xRes, yRes)
        End Function

        Protected MustOverride Function CompareResources(ByVal xRes As Resource, ByVal yRes As Resource) As Integer
    End Class

    Public Class ResourceCaptionComparer
        Inherits ResourceBaseComparer

        Protected Overrides Function CompareResources(ByVal xRes As Resource, ByVal yRes As Resource) As Integer
            Return [String].Compare(xRes.Caption, yRes.Caption)
        End Function
    End Class

    Public Class ResourceCaptionReverseComparer
        Inherits ResourceBaseComparer

        Protected Overrides Function CompareResources(ByVal xRes As Resource, ByVal yRes As Resource) As Integer
            Return [String].Compare(yRes.Caption, xRes.Caption)
        End Function
    End Class

    Public Class ResourceNOfAppointmentsComparer
        Inherits ResourceBaseComparer

        Private schedulerStorage As SchedulerStorage

        Public Sub New(ByVal schedulerStorage As SchedulerStorage)
            Me.schedulerStorage = schedulerStorage
        End Sub

        Protected Overrides Function CompareResources(ByVal xRes As Resource, ByVal yRes As Resource) As Integer
            ' "Unassigned" resource
            If Convert.ToInt32(yRes.Id) Is -1 Then Return 1
            ' "Unassigned" resource
            If Convert.ToInt32(xRes.Id) Is -1 Then Return -1
            Dim order As Integer = schedulerStorage.Appointments.Items.FindAll(Function(e) e.ResourceId.Equals(yRes.Id)).Count - schedulerStorage.Appointments.Items.FindAll(Function(e) e.ResourceId.Equals(xRes.Id)).Count
            If order Is 0 Then Return schedulerStorage.Resources.Items.IndexOf(xRes) - schedulerStorage.Resources.Items.IndexOf(yRes)
            Return order
        End Function
    End Class
End Namespace
