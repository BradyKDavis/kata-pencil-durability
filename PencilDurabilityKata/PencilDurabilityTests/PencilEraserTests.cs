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
            sut = new Pencil();
            sut.Write(paper, "This is a cool sentence.");
            sut.Erase(paper, "cool");
            Assert.AreEqual(paper.Text, "This is a      sentence.");
        }

        [Test]
        public void WhenPencilErasesWordFromPaperOnlyTheLastOccurenceIsErased()
        {
            sut = new Pencil();
            sut.Write(paper, "How much wood would a woodchuck chuck if a woodchuck could chuck wood?");
            sut.Erase(paper, "wood");
            Assert.AreEqual("How much wood would a woodchuck chuck if a woodchuck could chuck     ?", paper.Text);
        }
    }
}
