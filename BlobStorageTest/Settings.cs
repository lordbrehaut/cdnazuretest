using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobStorageTest
{
    public class Settings
    {
        public string StorageConnectionString {get; set;}
        public string StorageContainer { get; set; }
        public string CdnConnectionString { get; set; }

        public string StaticContentBaseUrl
        {
            get
            {
                var account = CloudStorageAccount.Parse(StorageConnectionString);
                return string.Format("{0}/{1}", account.BlobEndpoint.ToString().TrimEnd('/'), StorageContainer.TrimStart('/'));
            }
        }
    }
}
