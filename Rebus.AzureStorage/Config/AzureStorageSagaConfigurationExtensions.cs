using Microsoft.WindowsAzure.Storage;
using Rebus.Auditing.Sagas;
using Rebus.AzureStorage.Sagas;
using Rebus.Config;
using Rebus.Sagas;

namespace Rebus.AzureStorage.Config
{
    public static class AzureStorageSagaConfigurationExtensions
    {
        public static void UseAzureStorage(this StandardConfigurer<ISagaStorage> configurer, CloudStorageAccount cloudStorageAccount,
            string tableName = "RebusSagaIndex",
            string containerName = "RebusSagaStorage")
        {
            configurer.Register(c=>new AzureStorageSagaStorage(cloudStorageAccount, tableName, containerName));
        }

        public static void UseAzureStorage(this StandardConfigurer<ISagaSnapshotStorage> configurer,
            CloudStorageAccount cloudStorageAccount, string containerName = "RebusSagaStorage")
        {
            configurer.Register(c=>new AzureStorageSagaSnapshotStorage(cloudStorageAccount, containerName));
        }
    }
}