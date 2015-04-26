using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.FileProviders;

namespace AspNet.FileProviders.AzureStorage.Infrastructure
{
    internal class EnumerableDirectoryContents : IDirectoryContents
    {
        private readonly IEnumerable<IFileInfo> _entries;

        public EnumerableDirectoryContents(IEnumerable<IFileInfo> entries)
        {
            if (entries == null)
            {
                throw new ArgumentNullException(nameof(entries));
            }

            _entries = entries;
        }

        public bool Exists
        {
            get { return _entries.Any(); }
        }

        public IEnumerator<IFileInfo> GetEnumerator()
        {
            return _entries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _entries.GetEnumerator();
        }
    }
}
