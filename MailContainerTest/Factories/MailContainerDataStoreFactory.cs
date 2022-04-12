using MailContainerTest.Data;

namespace MailContainerTest.Factories
{
    public class MailContainerDataStoreFactory
    {
        public IContainerDataStore CreateDataStore(string dataStoreType)
        {
            if (dataStoreType == "Backup")
            {
                return new BackupMailContainerDataStore();
            }
            else
            {
                return new MailContainerDataStore();
            }
        }
    }
}
