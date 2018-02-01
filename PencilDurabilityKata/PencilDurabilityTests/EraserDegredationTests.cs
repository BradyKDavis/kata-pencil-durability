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

        [Test]
        public void TestThatWhenEraserIsOutOfDurabilityCallsToEraseDoNothing()
        {
            sut = new Pencil(int.MaxValue, int.MaxValue, 3);
            sut.Write(paper, "Did you ever hear the tragedy of Darth Plageius the Wise?");
            sut.Erase(paper, "did");
            Assert.AreEqual("    you ever hear the tragedy of Darth Plageius the Wise?", paper.Text);
            sut.Erase(paper, "you");
            Assert.AreEqual("    you ever hear the tragedy of Darth Plageius the Wise?", paper.Text);
        }


    }
}
