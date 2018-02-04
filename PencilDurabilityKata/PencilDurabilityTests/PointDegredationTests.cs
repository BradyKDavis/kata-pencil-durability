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
            //arrange
            sut = new Pencil(5);

            //act
            sut.Write(paper, "hello");

            //assert
            Assert.AreEqual("hello", paper.Text);
        }

        [Test]
        public void TestPencilWithNotEnoughPointToWriteSentenceWillWriteSpacesInstead()
        {
            //arrange
            sut = new Pencil(3);

            //act
            sut.Write(paper, "foobar");

            //assert
            Assert.AreEqual("foo   ", paper.Text);
        }

        [Test]
        public void TestPencilWithNotEnoughPointToWriteSentenceWillNotCountSpaces()
        {
            //arrange
            sut = new Pencil(8);

            //act
            sut.Write(paper, "this is writing");

            //assert
            Assert.AreEqual("this is wr     ", paper.Text);
        }

        [Test]
        public void TestPencilWithNotEnoughPointToWriteSentenceWillNotCountNewlines()
        {
            //arrange
            sut = new Pencil(8);

            //act
            sut.Write(paper, "this \n is \n sparta");

            //assert
            Assert.AreEqual("this \n is \n sp    ", paper.Text);
        }

        [Test]
        public void TestPencilWithNotEnoughPointToWriteSentenceWillDoublyCountCapitals()
        {
            //arrange
            sut = new Pencil(8);

            //act
            sut.Write(paper, "Hello World!");

            //assert
            Assert.AreEqual("Hello W     ", paper.Text);
        }

        [Test]
        public void TestPencilWithNotEnoughPointToWriteSentenceWritesLastCapitalIfAtEndDurability()
        {
            //arrange
            sut = new Pencil(3);

            //act
            sut.Write(paper, "ABC");

            //assert
            Assert.AreEqual("AB ", paper.Text);
        }

        [Test]
        public void TestThatWhenPencilIsGivenNegativeDurabilityArgumentExceptionThrown()
        {
            //arrange
            //act
            //assert
            Assert.Throws<ArgumentException>(() => new Pencil(-1));
        }

        [Test]
        public void TestThatWhenPencilIsGivenNegativeDurabilityArgumentExceptionIsThrownAlternate()
        {
            //arrange
            //act
            //assert
            Assert.Throws<ArgumentException>(() => new Pencil(-1, 2));
        }
    }
}
