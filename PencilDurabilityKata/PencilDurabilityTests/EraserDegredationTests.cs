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

        [Test]
        public void TestThatWhenEraserIsOutOfDurabilityItOnlyErasesWhatItCanFromTheRight()
        {
            sut = new Pencil(int.MaxValue, int.MaxValue, 5);
            sut.Write(paper, "Exceptionally done.");
            sut.Erase(paper, "exceptionally");
            Assert.AreEqual("Exceptio      done.", paper.Text);
        }
    }
}
