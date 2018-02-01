using System;
using NUnit.Framework;
using PencilDurabilityKata.Kata;
namespace PencilDurabilityTests
{
    [TestFixture]
    public class PointDegredationTests
    {
        private Pencil sut;

        private Paper paper;

        public PointDegredationTests()
        {
            paper = new Paper();
        }

        [Test]
        public void TestPencilWithEnoughPointToWriteSentenceWillWriteSentence()
        {
            sut = new Pencil(5);
            sut.Write(paper, "hello");
            Assert.AreEqual("hello", paper.Text);
        }
    }
}
