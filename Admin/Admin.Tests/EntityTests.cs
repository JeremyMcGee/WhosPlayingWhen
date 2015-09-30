namespace Admin.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using NUnit.Framework;

    using Admin.Migrations;
    using Admin.Models;

    [TestFixture]
    public class EntityTests
    {
        [SetUp]
        public static void SetUpFixture()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolDataContext, Configuration>()); 
        }

        [Test]
        public void SchoolHasFixtures()
        {
            
            using (var db = new SchoolDataContext())
            {
                Fixture fixture = new Fixture();
                fixture.Kickoff = DateTime.Now;
                db.Fixtures.Add(fixture);

                School school = new School();
                db.Schools.Add(school);
                
                school.Fixtures.Add(fixture);
                db.SaveChanges();               

                Assert.That(school.Fixtures.Contains<Fixture>(fixture));
            }
        }

        [Test]
        public void ChildHasFixtures()
        {
            using (var db = new SchoolDataContext())
            {
                Fixture fixture = new Fixture();
                fixture.Kickoff = DateTime.Now;
                db.Fixtures.Add(fixture);

                Child child = new Child();
                db.Children.Add(child);

                child.Fixtures.Add(fixture);
                db.SaveChanges();

                Assert.That(child.Fixtures.Contains<Fixture>(fixture));
            }
        }
    }
}
