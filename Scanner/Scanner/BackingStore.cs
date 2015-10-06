using System;
using System.IO;
using Newtonsoft.Json;

namespace Scanner
{
    using System.Collections.Generic;

    public class BackingStore
    {
        private string backingStoreName;

        public BackingStore(string backingStoreName)
        {
            this.backingStoreName = backingStoreName;
        }

        public IEnumerable<Child> GetAll()
        {
            string json = File.ReadAllText(GetBackingStoreFilename());
            return JsonConvert.DeserializeObject<IEnumerable<Child>>(json);
        }

        public void SaveAll(IEnumerable<Child> children)
        {
            string json = JsonConvert.SerializeObject(children);

            var applicationFile = GetBackingStoreFilename();
            File.WriteAllText(applicationFile, json);
        }

        private string GetBackingStoreFilename()
        {
            var applicationFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Scanner");
            Directory.CreateDirectory(applicationFolder);
            var applicationFile = Path.Combine(applicationFolder, string.Format("{0}.json", backingStoreName));
            return applicationFile;
        }
    }
}