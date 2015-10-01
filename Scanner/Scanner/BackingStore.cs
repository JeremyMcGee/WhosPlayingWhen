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
            yield break;
        }

        public void SaveAll(IEnumerable<Child> children)
        {

        }
    }
}