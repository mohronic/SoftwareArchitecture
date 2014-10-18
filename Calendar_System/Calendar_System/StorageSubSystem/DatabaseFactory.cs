namespace Calendar_System.StorageSubSystem
{
    /// <summary>
    /// Chooses which storage implementation will be used. The logic behind this is not implemented yet.
    /// This means that this class will be used in the factory pattern and the strategy pattern. We also felt
    /// that there was no need for a abstract factory - only a factory.
    /// </summary>
    class DatabaseFactory
    {
        private AbstractStorage _storage;

        public DatabaseFactory()
        {

        }
        public AbstractStorage CreateStorage(string databaseType)
        {
            IStorage iStorage;
            if (databaseType == "online")
            {
                iStorage = new DatabaseStorageImplementor();   
            }
            else if (databaseType == "offline")
            {
                iStorage = new FileStorageImplementor();
            }
            else
            {
                iStorage = new TestStorageImplementor();
            }
            return new AbstractStorage(iStorage);
        }

        public void SetOnlineStorage()
        {
            _storage.SetStorage(new DatabaseStorageImplementor());
        }
        public void SetOfflineStorage()
        {
            _storage.SetStorage(new FileStorageImplementor());
        }
        public void SetTestStorage()
        {
            _storage.SetStorage(new TestStorageImplementor());
        }
    }   
}
