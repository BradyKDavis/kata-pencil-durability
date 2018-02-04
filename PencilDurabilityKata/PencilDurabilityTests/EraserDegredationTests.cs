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
            //arrange

            //act
            //assert
            Assert.Throws<ArgumentException>(() => sut = new Pencil(int.MaxValue, int.MaxValue, -1));
        }

        [Test]
        public void TestThatWhenEraserIsOutOfDurabilityItOnlyErasesWhatItCanFromTheRight()
        {
            //arrange
            sut = new Pencil(int.MaxValue, int.MaxValue, 5);

            //act
            sut.Write(paper, "Exceptionally done.");
            sut.Erase(paper, "exceptionally");

            //assert
            Assert.AreEqual("Exceptio      done.", paper.Text);
        }

        [Test]
        public void TestThatWhenEraserIsOutOfDurabilityCallsToEraseDoNothing()
        {
            //arrange
            sut = new Pencil(int.MaxValue, int.MaxValue, 3);

            //act
            sut.Write(paper, "Did you ever hear the tragedy of Darth Plageius the Wise?");
            sut.Erase(paper, "did");

            //assert
            Assert.AreEqual("    you ever hear the tragedy of Darth Plageius the Wise?", paper.Text);
            //act
            sut.Erase(paper, "you");
            //assert
            Assert.AreEqual("    you ever hear the tragedy of Darth Plageius the Wise?", paper.Text);
        }
    }
}
