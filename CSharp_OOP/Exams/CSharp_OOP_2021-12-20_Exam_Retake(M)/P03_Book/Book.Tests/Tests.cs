namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class Tests
    {
        private Book emptyBook;
        private Book fullBook;
        [SetUp]
        public void SetUp()
        {
            this.emptyBook = new Book("One", "Ivo");
            this.fullBook = new Book("Two", "Pena");
            fullBook.AddFootnote(1, "Brrr");
            fullBook.AddFootnote(2, "Muuu");
            fullBook.AddFootnote(3, "Pssst");
        }

        [Test]
        public void FootnoteCount_GetsTheCountOfFootnotes()
        {
            Assert.AreEqual(0, emptyBook.FootnoteCount);
            Assert.AreEqual(3, fullBook.FootnoteCount);
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_BookNameIsNullOrEmpty_ShouldThrowArgumentException(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Book(bookName, "Ivo");
            }, $"Invalid {bookName}!");
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_AuthorNameIsNullOrEmpty_ShouldThrowArgumentException(string authorName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Book("Nova", authorName);
            }, $"Invalid {authorName}!");
        }


        [Test]
        public void When_FootnoteNumExists_AddFootnoteShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.fullBook.AddFootnote(1, "Novo");
            }, "Footnote already exists!");
        }


        [Test]
        public void AddFootnote_ShouldworkCorrectly()  //////
        {
            int num = 7;
            string text = "Novo";

            this.emptyBook.AddFootnote(num, text);

            Assert.AreEqual(text, this.emptyBook.FindFootnote(num).Substring(13));
            Assert.AreEqual(1, emptyBook.FootnoteCount);
        }


        [Test]
        public void When_FootnoteDoesNotExist_FindFootnoteShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.fullBook.FindFootnote(111);
            }, "Footnote doesn't exists!");
        }


        [Test]
        public void FindFootnote_ReturnsCorrectText()
        {
            string expected = $"Footnote #1: Brrr";
            string actual = this.fullBook.FindFootnote(1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_FootnoteDoesNotExist_AlterFootnoteShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.fullBook.AlterFootnote(111, "newText");
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void AlterFootnote_SuccesfullyAltersFootnotet()
        {
            string newText = "New Text";
            this.fullBook.AlterFootnote(1, newText);
            string alteredText = this.fullBook.FindFootnote(1).Substring(13);
            Assert.AreEqual(newText, alteredText);
        }


        
    }
}