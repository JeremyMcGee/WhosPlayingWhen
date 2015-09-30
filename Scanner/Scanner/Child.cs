using System;
using System.Collections.Generic;

namespace Scanner
{
    public class Child
    {
        public string Name { get; set; }

        public string ParentName { get; set; }

        public string ParentEmail { get; set; }

        public static IEnumerable<Child> GetAll()
        {
            yield break;
        }

        public static void SaveAll(IEnumerable<Child> children)
        {
            
        }

        public Child UpdateFixtureList(List<Fixture> fixtures)
        {
            return null;
        }

        public bool InformParent()
        {
            return true;
        }
    }
}