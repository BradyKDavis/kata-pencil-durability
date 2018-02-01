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
            String sentence = "foobar";
            sut.Write(paper, sentence);
            Assert.AreEqual(sentence, paper.Text);
        }

        [Test]
        public void TestThatWhenPencilWritesStringToPaperWithTextThenThatTextIsAppended()
        {
            paper = new Paper("This sentence is ");
            sut.Write(paper, "currently incomplete.");
            Assert.AreEqual("This sentence is currently incomplete.", paper.Text);
        }
    }
}
