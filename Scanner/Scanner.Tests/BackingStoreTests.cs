namespace Scanner.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class BackingStoreTests
    {
        [Test]
        public void CanSaveAndGetChildrenWithFixtures()
        {
            const string childName = "Lawrence McGee";
            const string anotherName = "Richard Henderson";

            var myChild = new Child
            {
                Name = childName
            };

            var initialFixtureList = new List<Fixture>
            {
                new Fixture
                {
                    Sport = "Rugby Union",
                    Team = "U8",
                    School = "Tockington",
                    Kickoff = new DateTime(2016, 1, 1, 12, 00, 00),
                    Players = {childName}
                }
            };

            var myChildWithInitialFixture = myChild.UpdateFixtureList(initialFixtureList);

            var updatedFixtureList = new List<Fixture>
            {
                new Fixture
                {
                    Sport = "Rugby Union",
                    Team = "U8",
                    School = "Tockington",
                    Kickoff = new DateTime(2016, 1, 1, 12, 00, 00),
                    Players = {anotherName}
                }
            };

            var myChildWithUpdatedFixture = myChildWithInitialFixture.UpdateFixtureList(updatedFixtureList);

            const string backingStore = "test";
            var persister = new BackingStore(backingStore);

            persister.SaveAll(new List<Child> {myChildWithUpdatedFixture});

            var childList = persister.GetAll().ToList();

            Assert.That(childList.Count, Is.EqualTo(1));
            var myRestoredChild = childList[0];

            Assert.That(myRestoredChild.ParentShouldBeInformed(), Is.True);
            Assert.That(
                myRestoredChild.GetMessageForParent()
                    .Contains("Now NOT playing in U8 Rugby Union at Tockington on 01 January 2016 12:00"));
        }

        [Test]
        public void NoChildrenForcesCreationOfInitialChildren()
        {
            const string backingStore = "test";
            var persister = new BackingStore(backingStore);

            persister.RemoveBackingStore();
            persister.GetInitialChildren = GetInitialChildren;

            var childList = persister.GetAll().ToList();

            Assert.That(childList.Count, Is.EqualTo(1));
            Assert.That(childList[0].Name, Is.EqualTo("Julian McGee"));
        }

        public IEnumerable<Child> GetInitialChildren()
        {
            yield return new Child() { Name = "Julian McGee" };
        }
    }
}