using System.Collections.Generic;
using System.Diagnostics;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.WorkgroupSubSystem
{
    public class WorkgroupControl
    {
        public WorkgroupControl(string message)
        {
            if (message == "newWorkgroup")
            {
                WorkgroupFormCreateWorkgroup();
            }
            if (message == "modifyWorkgroup")
            {
                // Simulates searching - not implemented yet.
                var workgroup = new Workgroup("bla", new List<User>());
                WorkgroupFormModifyWorkgroup(workgroup);
            }
        }

        public void WorkgroupFormCreateWorkgroup()
        {
            var wgf = new WorkgroupForm();
            wgf.Show();
        }

        public void WorkgroupFormModifyWorkgroup(Workgroup workgroup)
        {
            var wgf = new WorkgroupForm(workgroup);
            wgf.Show();
        }
    }
}
