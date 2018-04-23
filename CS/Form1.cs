using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using System.Collections.Generic;

namespace SchedulerSortResources {
    public partial class Form1 : Form {
        private DataModel dataModel = new DataModel();

        public ResourcesSortOrder CurrentSortOrder {
            get {
                return (ResourcesSortOrder)comboBox1.SelectedIndex;
            }
            set {
                comboBox1.SelectedIndex = (int)value;
            }
        }

        public Form1() {
            InitializeComponent();

            FillResources();
            CurrentSortOrder = ResourcesSortOrder.Ascending;
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (CurrentSortOrder == ResourcesSortOrder.None)
                schedulerControl1.RefreshData();
            else
                ApplySorting();
        }

        private void schedulerStorage1_ResourceCollectionLoaded(object sender, System.EventArgs e) {
            ApplySorting();
        }

        private void AppointmentsModified(object sender, PersistentObjectsEventArgs e) {
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

        private void FillResources() {
            string[] users = new string[] { "Peter Dolan", "Ryan Fischer", "Andrew Miller", "Tom Hamlett",
                                                        "Jerry Campbell", "Carl Lucas" };

            dataModel.Resources.AddResourcesRow("Unassigned", Color.DarkGray.ToArgb());

            for (int i = 0; i < users.Length; i++) {
                dataModel.Resources.AddResourcesRow(users[i], schedulerControl1.ResourceColorSchemas[i].Cell.ToArgb());
            }

            schedulerStorage1.Resources.ColorSaving = ColorSavingType.ArgbColor;
            schedulerStorage1.Resources.DataSource = dataModel;
        }

    }

    public enum ResourcesSortOrder {
        None = 0,
        Ascending = 1,
        Descending = 2,
        NOfAppointments = 3
    }
}
