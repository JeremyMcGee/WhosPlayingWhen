using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Scanner.Tests
{
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
        public void DontInformParentWhenFixtureListChangesButChildNotOnIt()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DontInformParentWhenFixtureListUnchanged()
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
            Assert.Inconclusive();
        }

        [Test]
        public void InformParentWhenFixtureDetailsChange()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void CanDistinguishBetweenTwoFixturesOnSameDateAtDifferentPlaces()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void CanDistinguishBetweenTwoFixturesAtSamePlaceOnDifferentDates()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void CanDistinguishBetweenTwoFixturesAtSamePlaceOnSameDate()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void InformParentWhenFixtureCancelled()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DontInformParentWhenFixtureDetailsChangeButFixtureHasPast()
        {
            Assert.Inconclusive();
        }
    }
}
