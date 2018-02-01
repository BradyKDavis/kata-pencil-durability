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
        [Test]
        public void AssertThatWhenPencilWritesStringToEmptyPaperThePaperAppendsString()
        {
            String sentence = "foobar";
            sut.Write(paper, sentence);
            Assert.AreEqual(sentence, paper.Text);
        }
    }
}
