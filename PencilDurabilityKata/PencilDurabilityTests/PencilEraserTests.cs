using NUnit.Framework;
using System;
using PencilDurabilityKata.Kata;
namespace PencilDurabilityTests
{
    [TestFixture]
    public class PencilEraserTests
    {
        private Pencil sut;

        private Paper paper;

        [SetUp]
        public void SetUp()
        {
            paper = new Paper();
        }

        [Test]
        public void WhenPencilErasesWordFromPaperThatWordIsReplacedWithSpaces()
        {
            //arrange
            sut = new Pencil();

            //act
            sut.Write(paper, "This is a cool sentence.");
            sut.Erase(paper, "cool");

            //assert
            Assert.AreEqual(paper.Text, "This is a      sentence.");
        }

        [Test]
        public void WhenPencilErasesWordFromPaperOnlyTheLastOccurenceIsErased()
        {
            //arrange
            sut = new Pencil();

            //act
            sut.Write(paper, "How much wood would a woodchuck chuck if a woodchuck could chuck wood?");
            sut.Erase(paper, "wood");

            //assert
            Assert.AreEqual("How much wood would a woodchuck chuck if a woodchuck could chuck     ?", paper.Text);
        }

        [Test]
        public void WhenPencilErasesWordFromPaperItErasesTheWordIfItIsCapitalizedInTheSentence()
        {
            //arrange
            sut = new Pencil();

            //act
            sut.Write(paper, "Food is good.");
            sut.Erase(paper, "food");

            //assert
            Assert.AreEqual("     is good.", paper.Text);
        }
    }
}
