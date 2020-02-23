using System;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using Akavache;
using Akavache.Sqlite3;

namespace XamarinFormsClean.Common.Data.Source.Local
{
    public static class ApplicationStorage
    {
        private const string DatabaseFileName = "xamarin-forms-clean.db";
        private const string SecureDatabaseFileName = "xamarin-forms-clean-secure.db";
        
        private static readonly Lazy<IBlobCache> DefaultLazy =
            new Lazy<IBlobCache>(GetBlobCache,
                LazyThreadSafetyMode.PublicationOnly);

        public static IBlobCache Default => DefaultLazy.Value;

        private static readonly Lazy<IBlobCache> SecureLazy =
            new Lazy<IBlobCache>(GetSecureBlobCache,
                LazyThreadSafetyMode.PublicationOnly);

        public static IBlobCache Secure => SecureLazy.Value;

        private static IBlobCache GetBlobCache() =>
            new SQLitePersistentBlobCache(
                GetDatabasePath(DatabaseFileName),
                BlobCache.TaskpoolScheduler);

        private static IBlobCache GetSecureBlobCache() =>
            new SQLiteEncryptedBlobCache(
                GetDatabasePath(SecureDatabaseFileName),
                scheduler: BlobCache.TaskpoolScheduler);
        
        private static string GetDatabasePath(string databaseFileName) =>
            Path.Combine(
                System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.LocalApplicationData),
                databaseFileName);

        public static void EnsureFlushed()
        {
            var blobStorageArray = new[] {Default, Secure};
            
            blobStorageArray
                .Select(blobStorage => blobStorage.Flush())
                .Merge()
                .Wait();
        }
    }
}