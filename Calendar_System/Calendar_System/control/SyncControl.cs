using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.model;
using Calendar_System.view;

namespace Calendar_System.control
{
    class SyncControl
    {
        private AbstractStorage _abstractStorage;
        public SyncControl(AbstractStorage abstractStorage)
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
