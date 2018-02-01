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
    }
}
