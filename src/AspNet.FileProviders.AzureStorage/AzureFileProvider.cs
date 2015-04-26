using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AspNet.FileProviders.AzureStorage.Infrastructure;
using Microsoft.AspNet.FileProviders;
using Microsoft.Framework.Expiration.Interfaces;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AspNet.FileProviders.AzureStorage
{
    public class AzureFileProvider : IFileProvider
    {
        private readonly CloudBlobContainer _blobContainer;

        public AzureFileProvider(CloudBlobContainer blobContainer)
        {
            if (blobContainer == null)
            {
                throw new ArgumentNullException(nameof(blobContainer));
            }

            _blobContainer = blobContainer;
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            IEnumerable<IFileInfo> blobs = _blobContainer
                .ListBlobs(prefix: subpath, useFlatBlobListing: false)
                .ToList()
                .Select(blobItem => blobItem.ToFileInfo());

            return new EnumerableDirectoryContents(blobs);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            if(subpath == null)
            {
                throw new NullReferenceException(nameof(subpath));
            }

            ICloudBlob blob = _blobContainer.GetBlobReferenceFromServer(subpath);

            return new AzureFileInfo(blob);
        }

        public IExpirationTrigger Watch(string filter)
        {
            return NoopTrigger.Instance;
        }
    }

    internal class AzureFileInfo : IFileInfo
    {
        private readonly ICloudBlob _cloudBlob;

        public AzureFileInfo(ICloudBlob cloudBlob)
        {
            if (cloudBlob == null)
            {
                throw new NullReferenceException(nameof(cloudBlob));
            }

            _cloudBlob = cloudBlob;
        }

        public bool Exists
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsDirectory
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DateTimeOffset LastModified
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public long Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string PhysicalPath
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Stream CreateReadStream()
        {
            throw new NotImplementedException();
        }
    }


    internal static class IListBlobItemExtensions
    {
        public static IFileInfo ToFileInfo(this IListBlobItem blobItem)
        {
            throw new NotImplementedException();
        }
    }
}
