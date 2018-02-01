using NUnit.Framework;
using System;
using PencilDurabilityKata.Kata;
namespace PencilDurabilityTests
{
    [TestFixture]
    public class EraserDegredationTests
    {
        private Pencil sut;

        private Paper paper;

        [SetUp]
        public void init()
        {
            paper = new Paper();
        }

        [Test]
        public void TestThatWhenEraserIsGivenNegativeDurabilityArgumentErrorIsThrown()
        {
            Assert.Throws<ArgumentException>(() => sut = new Pencil(int.MaxValue, int.MaxValue, -1));
        }
    }
}
