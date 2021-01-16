using System;
using System.Linq;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WarriorsCollectionIsNotNullWhenArenaClassInitialized()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollWarrior()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Nayo", 50, 500);

            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void EnrollWarriorException()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Nayo", 50, 500);

            arena.Enroll(warrior);
            
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        [TestCase("Nayo","YonakiAyo")]
        [TestCase("YonakiAyo","AokiNayo")]
        [TestCase("YonakiAyo","Lenalee")]
        public void FightException(string attackerName, string defenderName)
        {
            Arena arena = new Arena();

            Warrior attackerWarrior = new Warrior("Nayo", 50, 500);
            Warrior defenderWarrior = new Warrior("AokiNayo", 50, 500);

            arena.Enroll(attackerWarrior);
            arena.Enroll(defenderWarrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
        }

        [Test]
        [TestCase("AokiNayo", 250, 1000, "Nayo", 100, 250)]
        [TestCase("AokiNayo", 500, 2000, "Nayo", 100, 250)]
        public void WarriorAttackerSuccessfullyAttacksWarriorDefender(string attackerName, int attackerDamage, int attackerHP,
            string defenderName, int defenderDamage, int defenderHP)
        {
            Warrior attackerWarrior = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defenderWarrior = new Warrior(defenderName, defenderDamage, defenderHP);

            Arena arena = new Arena();

            arena.Enroll(attackerWarrior);
            arena.Enroll(defenderWarrior);
            arena.Fight("AokiNayo", "Nayo");

            var attackerHpExpected = attackerHP - defenderDamage;

            Assert.AreEqual(attackerHpExpected, attackerWarrior.HP);
            Assert.AreEqual(0, defenderWarrior.HP);

        }

        [Test]
        [TestCase("AokiNayo", 250, 1000, "Nayo", 100, 500)]
        public void DefenderHPDecrease(string attackerName, int attackerDamage, int attackerHP,
            string defenderName, int defenderDamage, int defenderHP)
        {
            Warrior attackerWarrior = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defenderWarrior = new Warrior(defenderName, defenderDamage, defenderHP);

            Arena arena = new Arena();

            arena.Enroll(attackerWarrior);
            arena.Enroll(defenderWarrior);
            arena.Fight("AokiNayo", "Nayo");

            Assert.That(defenderWarrior.HP, Is.EqualTo(250));

        }


    }
}
