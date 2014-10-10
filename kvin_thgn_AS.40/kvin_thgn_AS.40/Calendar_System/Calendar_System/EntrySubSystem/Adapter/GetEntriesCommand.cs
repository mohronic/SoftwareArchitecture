namespace Calendar_System.EntrySubSystem.Adapter
{
    class GetEntriesCommand : ICommand
    {
        private GoogleAdapter _googleAdapter;

        public GetEntriesCommand(GoogleAdapter googleAdapter)
        {
            _googleAdapter = googleAdapter;
        }
        public void Execute()
        {
            _googleAdapter.GetEntries();
        }
    }
}
