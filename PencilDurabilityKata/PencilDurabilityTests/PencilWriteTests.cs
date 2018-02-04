using NUnit.Framework;
using System;
using PencilDurabilityKata.Kata;
namespace PencilDurabilityTests
{
    [TestFixture]
    public class PencilWriteTests
    {
        private Pencil sut;

        private Paper paper;

        public PencilWriteTests()
        {
            sut = new Pencil();
            paper = new Paper();
        }

        [SetUp]
        public void init()
        {
            paper = new Paper();
        }

        [Test]
        public void TestThatWhenPencilWritesStringToEmptyPaperThePaperTextIsWritten()
        {
            //arrange
            String sentence = "foobar";

            //act
            sut.Write(paper, sentence);

            //assert
            Assert.AreEqual(sentence, paper.Text);
        }

        [Test]
        public void TestThatWhenPencilWritesStringToPaperWithTextThenThatTextIsAppended()
        {
            //arrange
            paper = new Paper("This sentence is ");

            //act
            sut.Write(paper, "currently incomplete.");

            //assert
            Assert.AreEqual("This sentence is currently incomplete.", paper.Text);
        }
    }
}
