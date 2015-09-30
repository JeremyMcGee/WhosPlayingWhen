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
            var myChild = new Child();

            var fixtureList = new List<Fixture>()
            {
                new Fixture()
            };

            myChild.UpdateFixtureList(fixtureList);

            Assert.That(myChild.InformParent(), Is.True);
        }

        [Test]
        public void InformParentWhenChildDisappearsFromFixtureList()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DontInformParentWhenFixtureListChangesButChildNotOnIt()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DontInformParentWhenFixtureListUnchanged()
        {
            Assert.Inconclusive();  
        }

        [Test]
        public void InformParentWhenFixtureDetailsChange()
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
