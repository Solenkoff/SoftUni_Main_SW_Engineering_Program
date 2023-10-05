using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("Pesho", "itemId");
        }

        [Test]
        public void When_AddItemToNonexistingCell_ShouldThrowArgumetnException()
        {
            string nonexistingSell = "NoCell";

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem(nonexistingSell, item);
            });
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }


        [Test]
        public void When_AddItemToOccupiedCell_ShouldThrowArgumetnException()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("A2", new Item("Gogo", "gogoId"));
            });

            Assert.AreEqual(ex.Message, "Cell is already taken!");
        }


        [Test]
        public void When_AddItemExists_ShouldThrowInvalidOperationException()
        {

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("B2", item);
            });

            Assert.AreEqual(ex.Message, "Item is already in cell!");
        }


        [Test]
        public void When_DataIsCorrect_ReturnsCorrectMessage()
        {
            string result = vault.AddItem("A2", item);

            Assert.That(result, Is.EqualTo($"Item:{item.ItemId} saved successfully!"));
        }


        [Test]
        public void When_DataIsCorrect_AddsItemSuccessfully()
        {
            vault.AddItem("A2", item);
            Item result = vault.VaultCells["A2"];
            Assert.That(result, Is.EqualTo(item));
        }


        [Test]
        public void When_RemovingItemFromNonexistingCell_ShouldThrowArgumetnException()
        {
            string nonexistingSell = "NoCell";

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem(nonexistingSell, item);
            });
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }


        [Test]
        public void When_RemovingItemThatSNotInTheCell_ShouldThrowArgumetnException()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("B4", item);
            });

            Assert.AreEqual(ex.Message, "Item in that cell doesn't exists!");
        }


        [Test]
        public void When_RemovingItem_ReturnsCorrectMessage()
        {
            vault.AddItem("B4", item);

            string result = vault.RemoveItem("B4", item);

            Assert.That(result, Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
        }

        [Test]
        public void When_RemovingItem_ItsBeenRemoved()
        {
            vault.AddItem("B4", item);
            vault.RemoveItem("B4", item);

            Assert.That(vault.VaultCells["B4"], Is.EqualTo(null));
        }


        [Test]
        public void When_VaultIsInitialised_ShouldHaveCorrectCells()
        {
            var initalValue = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            var initialValueAsList = initalValue.ToImmutableDictionary().ToList();
            var vaultVlauesAsList = vault.VaultCells.ToList();

            for (int i = 0; i < initialValueAsList.Count; i++)
            {
                Assert.AreEqual(initialValueAsList[i].Key, vaultVlauesAsList[i].Key);
                Assert.AreEqual(initialValueAsList[i].Value, vaultVlauesAsList[i].Value);
            }
        }
    }
}