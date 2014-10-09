namespace Calendar_System.WorkgroupSubSystem
{
    public class WorkgroupControl
    {
        public void WorkGroupFormCreateWorkgroup()
        {
            var workgroupForm = new WorkgroupForm();
        }

        public void ModifyWorkgroup(Workgroup workgroup)
        {
            var workgroupForm = new WorkgroupForm(workgroup);
        }

        public void DeleteWordgroup(Workgroup workgroup)
        {
            
        }
    }
}
