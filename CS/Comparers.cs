using System;
using System.Collections;
using System.Collections.Generic;
using DevExpress.XtraScheduler;

namespace SchedulerSortResources {
    public abstract class ResourceBaseComparer : IComparer<Resource>, IComparer {
        #region IComparer Members
        int IComparer.Compare(object x, object y) {
            return CompareCore(x, y);
        }
        public int Compare(Resource x, Resource y) {
            return CompareCore(x, y);
        }
        #endregion

        protected virtual int CompareCore(object x, object y) {
            Resource xRes = (Resource)x;
            Resource yRes = (Resource)y;
            
            if (xRes == null || yRes == null)
                return 0;
            if (Resource.Empty.Equals(xRes) || Resource.Empty.Equals(yRes))
                return 0;
            
            return CompareResources(xRes, yRes);
        }

        protected abstract int CompareResources(Resource xRes, Resource yRes);
    }

    public class ResourceCaptionComparer : ResourceBaseComparer {
        protected override int CompareResources(Resource xRes, Resource yRes) {
            return String.Compare(xRes.Caption, yRes.Caption);
        }
    }

    public class ResourceCaptionReverseComparer : ResourceBaseComparer {
        protected override int CompareResources(Resource xRes, Resource yRes) {
            return String.Compare(yRes.Caption, xRes.Caption);
        }
    }

    public class ResourceNOfAppointmentsComparer : ResourceBaseComparer {
        private SchedulerStorage schedulerStorage;

        public ResourceNOfAppointmentsComparer(SchedulerStorage schedulerStorage) {
            this.schedulerStorage = schedulerStorage;
        }

        protected override int CompareResources(Resource xRes, Resource yRes) {
            // "Unassigned" resource
            if (Convert.ToInt32(yRes.Id) == -1)
                return 1;
            
            // "Unassigned" resource
            if (Convert.ToInt32(xRes.Id) == -1)
                return -1;

            int order = schedulerStorage.Appointments.Items.FindAll(e => e.ResourceId.Equals(yRes.Id)).Count -
                schedulerStorage.Appointments.Items.FindAll(e => e.ResourceId.Equals(xRes.Id)).Count;

            if (order == 0)
                return schedulerStorage.Resources.Items.IndexOf(xRes) - schedulerStorage.Resources.Items.IndexOf(yRes);

            return order;
        }
    }
}
