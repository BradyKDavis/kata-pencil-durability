using NUnit.Framework;
using System;
using PencilDurabilityKata.Kata;
namespace PencilDurabilityTests
{
    [TestFixture]
    public class PencilEditTests
    {
        private Pencil sut;

        private Paper paper;

        [SetUp]
        public void SetUp()
        {
            sut = new Pencil();
            paper = new Paper();
        }

        [Test]
        public void TestEditOverEmptySpacePlacesStringInThatSpace()
        {
            sut.Write(paper, "     is some space in which to put a word.");
            sut.Edit(paper, "Here", 0);
            Assert.AreEqual("Here is some space in which to put a word.", paper.Text);
        }

        [Test]
        public void TestEditInNegativeIndexThrowsArgumentException()
        {
            sut.Write(paper, "foobar");
            Assert.Throws<ArgumentException>(() => sut.Edit(paper, "", -1));
        }

        [Test]
        public void TestEditOverCharactersPlacesConflictSymbolsOverCharacters()
        {
            sut.Write(paper, "This is a test sentence.");
            sut.Edit(paper, "xxxxxx", 4);
            Assert.AreEqual("Thisx@@x@xtest sentence.", paper.Text);
        }

        [Test]
        public void TestEditWithInsufficientPointDurabilityOnlyEditsUpToDurability()
        {
            sut = new Pencil(5);
            paper = new Paper("We will edit over this paper.");
            sut.Edit(paper, "FooBar", 7);
            Assert.AreEqual("We willF@@@t over this paper.", paper.Text);
        }

        [Test]
        public void TestEditNearEndOfPaperAppendsEditToEnd()
        {
            paper = new Paper("Yaddaa ");
            sut.Edit(paper, "yadda yadda", 5);
            Assert.AreEqual("Yadda@adda yadda", paper.Text);
        }
    }
}
