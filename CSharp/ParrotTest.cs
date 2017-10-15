using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace parrot
{
    [TestClass]
    public class ParrotTest
    {
        [TestMethod]
        public void GetSpeedOfEuropeanParrot()
        {
            var parrot = Parrot.European();
            Assert.AreEqual(12.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedOfAfricanParrot_With_One_Coconut()
        {
            var parrot = Parrot.African(1);
            Assert.AreEqual(3.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedOfAfricanParrot_With_Two_Coconuts()
        {
            var parrot = Parrot.African(2);
            Assert.AreEqual(0.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedOfAfricanParrot_With_No_Coconuts()
        {
            var parrot = Parrot.African(0);
            Assert.AreEqual(12.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedNorwegianBlueParrot_nailed()
        {
            var parrot = Parrot.NorwegianBlue(0.0, true);
            Assert.AreEqual(0.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedNorwegianBlueParrot_not_nailed()
        {
            var parrot = Parrot.NorwegianBlue(1.5, false);
            Assert.AreEqual(18.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedNorwegianBlueParrot_not_nailed_high_voltage()
        {
            var parrot = Parrot.NorwegianBlue(4, false);
            Assert.AreEqual(24.0, parrot.GetSpeed());
        }
    }
}
