namespace Scanner.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class ChildTests
    {
        [Test]
        public void InformParentWhenChildAppearsOnFixtureList()
        {
            const string childName = "Lawrence McGee";

            var myChild = new Child
            {
                Name = childName
            };

            var fixtureList = new List<Fixture>
            {
                new Fixture
                {
                    Sport = "Rugby Union",
                    Team = "U8",
                    School = "Tockington",
                    Kickoff = new DateTime(2016,1,1,12,00,00),
                    Players = { childName }
                }
            };

            myChild.UpdateFixtureList(fixtureList);

            Assert.That(myChild.ParentShouldBeInformed(), Is.True);
            Assert.That(myChild.GetMessageForParent().Contains("Now playing in U8 Rugby Union at Tockington on 01 January 2016 12:00"));
        }

        [Test]
        public void InformParentWhenChildDisappearsFromFixtureList()
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
                    Kickoff = new DateTime(2016,1,1,12,00,00),
                    Players = { childName }
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
                    Kickoff = new DateTime(2016,1,1,12,00,00),
                    Players = { anotherName }
                }
            };

            var myChildWithUpdatedFixture = myChildWithInitialFixture.UpdateFixtureList(updatedFixtureList);

            Assert.That(myChildWithUpdatedFixture.ParentShouldBeInformed(), Is.True);
            Assert.That(myChild.GetMessageForParent().Contains("Now NOT playing in U8 Rugby Union at Tockington on 01 January 2016 12:00"));
        }

        [Test]
        public void DontInformParentWhenFixtureListUnchanged()
        {
            const string childName = "Lawrence McGee";

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
                    Kickoff = new DateTime(2016,1,1,12,00,00),
                    Players = { childName }
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
                    Kickoff = new DateTime(2016,1,1,12,00,00),
                    Players = { childName }
                }
            };

            var myChildWithUpdatedFixture = myChildWithInitialFixture.UpdateFixtureList(updatedFixtureList);

            Assert.That(myChildWithUpdatedFixture.ParentShouldBeInformed(), Is.False);
        }

        [Test]
        public void DontInformParentWhenChildOnListButAnotherChildDropped()
        {
            const string childName = "Lawrence McGee";
            const string anotherName = "Vicky Henderson";

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
                    Kickoff = new DateTime(2016,1,1,12,00,00),
                    Players = { childName, anotherName }
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
                    Kickoff = new DateTime(2016,1,1,12,00,00),
                    Players = { childName }
                }
            };

            var myChildWithUpdatedFixture = myChildWithInitialFixture.UpdateFixtureList(updatedFixtureList);

            Assert.That(myChildWithUpdatedFixture.ParentShouldBeInformed(), Is.False);
        }

        [Test]
        public void InformParentWhenFixtureDetailsChange()
        {
            const string childName = "Lawrence McGee";

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
                    Kickoff = new DateTime(2016,1,1,12,00,00),
                    Players = { childName }
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
                    Kickoff = new DateTime(2016,1,1,14,00,00),
                    Players = { childName }
                }
            };

            var myChildWithUpdatedFixture = myChildWithInitialFixture.UpdateFixtureList(updatedFixtureList);

            Assert.That(myChildWithUpdatedFixture.ParentShouldBeInformed(), Is.True);

            Assert.That(myChild.GetMessageForParent().Contains("Now NOT playing in U8 Rugby Union at Tockington on 01 January 2016 12:00"));
            Assert.That(myChild.GetMessageForParent().Contains("Now playing in U8 Rugby Union at Tockington on 01 January 2016 14:00"));
        }

        [Test]
        public void InformParentWhenFixtureCancelled()
        {
            const string childName = "Lawrence McGee";
            const string anotherName = "Andrew Smith";

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
                    Kickoff = new DateTime(2016,1,1,12,00,00),
                    Players = { childName }
                },

                new Fixture
                {
                    Sport = "Rugby Union",
                    Team = "U8",
                    School = "Clifton",
                    Kickoff = new DateTime(2016,1,2,12,00,00),
                    Players = { anotherName }
                }
            };

            var myChildWithInitialFixture = myChild.UpdateFixtureList(initialFixtureList);

            var updatedFixtureList = new List<Fixture>
            {
                new Fixture
                {
                    Sport = "Rugby Union",
                    Team = "U8",
                    School = "Clifton",
                    Kickoff = new DateTime(2016,1,2,12,00,00),
                    Players = { anotherName }
                }
            };

            var myChildWithUpdatedFixture = myChildWithInitialFixture.UpdateFixtureList(updatedFixtureList);

            Assert.That(myChildWithUpdatedFixture.ParentShouldBeInformed(), Is.True);

            Assert.That(myChild.GetMessageForParent().Contains("Now NOT playing in U8 Rugby Union at Tockington on 01 January 2016 12:00"));
        }

        [Test]
        public void DontInformParentWhenFixtureDetailsChangeButFixtureHasPast()
        {
            const string childName = "Lawrence McGee";

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
                    Kickoff = new DateTime(2014,1,1,12,00,00),
                    Players = { childName }
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
                    Kickoff = new DateTime(2014,1,1,14,00,00),
                    Players = { childName }
                }
            };

            var myChildWithUpdatedFixture = myChildWithInitialFixture.UpdateFixtureList(updatedFixtureList);

            Assert.That(myChildWithUpdatedFixture.ParentShouldBeInformed(), Is.False);
        }
    }
}
