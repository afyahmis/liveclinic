using LiveClinic.SharedKernel.Common;
using NUnit.Framework;

namespace LiveClinic.SharedKernel.Tests.Model
{
    [TestFixture]
    public class ValueObjectTests
    {
        [Test]
        public void check_Equality()
        {
            var nameA=new PersonName("John","Test","Demo");
            var nameB=new PersonName("John","Test","Demo");
            var nameC=new PersonName("John","XXX","Demo");
            Assert.AreEqual(nameA,nameB);
            Assert.AreNotEqual(nameA,nameC);
        }
    }
}
