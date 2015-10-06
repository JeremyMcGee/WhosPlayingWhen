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

        public Func<IEnumerable<Child>> GetInitialChildren { private get; set; }

        public IEnumerable<Child> GetAll()
        {
            string backingStoreFilename = GetBackingStoreFilename();
            if (!File.Exists(backingStoreFilename))
            {
                return GetInitialChildren.Invoke();
            }

            string json = File.ReadAllText(backingStoreFilename);
            return JsonConvert.DeserializeObject<IEnumerable<Child>>(json);
        }

        public void RemoveBackingStore()
        {
            string backingStoreFilename = GetBackingStoreFilename();

            if (File.Exists(backingStoreFilename))
            {
                File.Delete(backingStoreFilename);
            }
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