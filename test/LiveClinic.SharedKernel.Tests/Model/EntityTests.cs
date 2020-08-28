using System;
using LiveClinic.SharedKernel.Model;
using NUnit.Framework;
using Serilog;

namespace LiveClinic.SharedKernel.Tests.Model
{
    [TestFixture]
    public class EntityTests
    {
        [Test]
        public void should_Get_PreferredDocName()
        {
            var demo = new Demo();
            var otherDemo = new OtherDemo();
            Assert.AreEqual("demos", demo.PreferredDocName);
            Assert.AreEqual("others", otherDemo.PreferredDocName);
            Log.Information(demo.PreferredDocName);
            Log.Information(otherDemo.PreferredDocName);
        }
    }

    class Demo : Entity<Guid>
    {
    }

    class OtherDemo : Entity<Guid>
    {
        public override string GenerateDocName()
        {
            return "Others";
        }
    }
}
