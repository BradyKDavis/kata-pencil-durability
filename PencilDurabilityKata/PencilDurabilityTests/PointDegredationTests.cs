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

        [SetUp]
        public void init()
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

        [Test]
        public void TestPencilWithNotEnoughPointToWriteSentenceWillWriteSpacesInstead()
        {
            sut = new Pencil(3);
            sut.Write(paper, "foobar");
            Assert.AreEqual("foo   ", paper.Text);
        }
    }
}
