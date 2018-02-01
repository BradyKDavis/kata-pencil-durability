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
    }
}
