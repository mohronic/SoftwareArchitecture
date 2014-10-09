using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.model;
using Calendar_System.model.Storage;
using Calendar_System.view;

namespace Calendar_System.control
{
    public class SyncControl
    {
        private IStorage _abstractStorage;
        public SyncControl(IStorage abstractStorage)
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
