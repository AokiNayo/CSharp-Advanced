using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void InizialedCorrectly()
        {
            BankVault bank = new BankVault();
            bool isTrue = true;

            foreach (var bankVaultCell in bank.VaultCells)
            {
                if (bankVaultCell.Value == null)
                {
                    continue;
                }

                isTrue = false;
            }

            Assert.AreEqual(12,bank.VaultCells.Count);
            Assert.AreEqual(true,isTrue);
        }

        [Test]
        [TestCase("AokiNayo", "27", "A1")]
        public void AddItemExceptions(string owner, string itemId, string cell)
        {
            BankVault bank = new BankVault();
            Item item = new Item(owner, itemId);

            bank.AddItem(cell, item);

            Assert.Throws<ArgumentException>(() => bank.AddItem("cell", item));
            Assert.Throws<ArgumentException>(() => bank.AddItem(cell, item));
        }

        [Test]
        [TestCase("AokiNayo", "27", "A1")]
        public void AddItemInCellCollection(string owner, string itemId, string cell)
        {
            BankVault bank = new BankVault();
            Item item = new Item(owner, itemId);

            bank.AddItem(cell, item);

            Assert.Throws<InvalidOperationException>(() => bank.AddItem("A2", item));
        }

        [Test]
        [TestCase("AokiNayo", "27", "A1")]
        public void AddCorrect(string owner, string itemId, string cell)
        {
            BankVault bank = new BankVault();
            Item item = new Item(owner, itemId);

            string actual = bank.AddItem(cell, item);
            string expected = $"Item:{item.ItemId} saved successfully!";

            Assert.AreEqual(expected,actual);
        }

        [Test]
        [TestCase("AokiNayo", "27", "A1")]
        public void RemoveExceptions(string owner, string itemId, string cell)
        {
            BankVault bank = new BankVault();
            Item item = new Item(owner, itemId);

            Assert.Throws<ArgumentException>(() => bank.RemoveItem("CELL", item));
            Assert.Throws<ArgumentException>(() => bank.RemoveItem(cell, item));
        }

        [Test]
        [TestCase("AokiNayo", "27", "A1")]
        public void RemoveCorrectly(string owner, string itemId, string cell)
        {
            BankVault bank = new BankVault();
            Item item = new Item(owner, itemId);

            bank.AddItem(cell,item);


            string actual = bank.RemoveItem(cell, item);
            string expected = $"Remove item:{item.ItemId} successfully!";

            Assert.AreEqual(expected, actual);
        }
    }
}