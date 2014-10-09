namespace Calendar_System.StorageSubSystem
{
    /// <summary>
    /// Chooses which storage implementation will be used. The logic behind this is not implemented yet.
    /// This means that this class will be used in the factory pattern and the strategy pattern. We also felt
    /// that there was no need for a abstract factory - only a factory.
    /// </summary>
    class DatabaseFactory
    {
        AbstractStorage _storage;

        public DatabaseFactory(AbstractStorage storage)
        {
            _storage = storage;
        }
        public void CreateOnlineStorage()
        {
            _storage.SetStorage(new DatabaseStorageImplementor());
        }

        public void CreateFileStorage()
        {
            _storage.SetStorage(new TestStorageImplementor());
        }

        public void CreateTestStorage()
        {
            _storage.SetStorage(new TestStorageImplementor());
        }
    }   
}
