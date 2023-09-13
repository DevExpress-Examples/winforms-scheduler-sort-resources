Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports System.Collections.Generic

Namespace SchedulerSortResources

    Public Partial Class Form1
        Inherits Form

        Private dataModel As DataModel = New DataModel()

        Public Property CurrentSortOrder As ResourcesSortOrder
            Get
                Return CType(comboBox1.SelectedIndex, ResourcesSortOrder)
            End Get

            Set(ByVal value As ResourcesSortOrder)
                comboBox1.SelectedIndex = CInt(value)
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
            FillResources()
            CurrentSortOrder = ResourcesSortOrder.Ascending
        End Sub

        Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If CurrentSortOrder = ResourcesSortOrder.None Then
                schedulerControl1.RefreshData()
            Else
                ApplySorting()
            End If
        End Sub

        Private Sub schedulerStorage1_ResourceCollectionLoaded(ByVal sender As Object, ByVal e As System.EventArgs)
            ApplySorting()
        End Sub

        Private Sub AppointmentsModified(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            ApplySorting()
        End Sub

        Private Sub ApplySorting()
            Dim comparer As IComparer(Of Resource) = Nothing
            If CurrentSortOrder = ResourcesSortOrder.Ascending Then
                comparer = New ResourceCaptionComparer()
            ElseIf CurrentSortOrder = ResourcesSortOrder.Descending Then
                comparer = New ResourceCaptionReverseComparer()
            ElseIf CurrentSortOrder = ResourcesSortOrder.NOfAppointments Then
                comparer = New ResourceNOfAppointmentsComparer(schedulerStorage1)
            Else
                Return
            End If

            schedulerStorage1.Resources.Items.Sort(comparer)
            schedulerControl1.ActiveView.LayoutChanged()
        End Sub

        Private Sub FillResources()
            Dim users As String() = New String() {"Peter Dolan", "Ryan Fischer", "Andrew Miller", "Tom Hamlett", "Jerry Campbell", "Carl Lucas"}
            dataModel.Resources.AddResourcesRow("Unassigned", Color.DarkGray.ToArgb())
            For i As Integer = 0 To users.Length - 1
                dataModel.Resources.AddResourcesRow(users(i), schedulerControl1.ResourceColorSchemas(i).Cell.ToArgb())
            Next

            schedulerStorage1.Resources.ColorSaving = ColorSavingType.ArgbColor
            schedulerStorage1.Resources.DataSource = dataModel
        End Sub
    End Class

    Public Enum ResourcesSortOrder
        None = 0
        Ascending = 1
        Descending = 2
        NOfAppointments = 3
    End Enum
End Namespace
