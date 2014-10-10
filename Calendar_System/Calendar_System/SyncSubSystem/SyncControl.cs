using Calendar_System.StorageSubSystem;

namespace Calendar_System.Utility
{
    public class SyncControl
    {
        private IAbstractStorage _abstractStorage;
        public SyncControl(IAbstractStorage abstractStorage)
        {
            _abstractStorage = abstractStorage;
            SyncForm sf = new SyncForm(this);
            sf.ShowDialog();
        }

        public void SyncWithDb()
        {
            _abstractStorage.SyncAccount();
        }
    }
}
