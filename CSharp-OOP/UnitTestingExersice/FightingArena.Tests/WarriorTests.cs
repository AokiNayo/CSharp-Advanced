using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("AokiNayo", 50, 500)]
        [TestCase("Nayo", 75, 1500)]
        [TestCase("YonakiAyo", 100, 2000)]

        public void WarriorConstructorShouldSetDataCorrectly(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase(" ", 50, 500)]
        [TestCase("", 75, 1500)]
        [TestCase(null, 100, 2000)]
        public void InvalidNameException(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>((() => new Warrior(name, damage, hp)));
        }

        [Test]
        [TestCase("AokiNayo", 0, 500)]
        [TestCase("Nayo", -50, 1500)]
        public void DamageException(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("AokiNayo", 25, -500)]
        public void HpException(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("AokiNayo", 50, 20)]
        [TestCase("AokiNayo", 50, 30)]
        public void WarriorAttackMinAttackHpException(string name, int damage, int hp)
        {
            Warrior attackerWarrior = new Warrior(name, damage, hp);

            Assert.Throws<InvalidOperationException>(() => attackerWarrior.Attack(attackerWarrior));
        }

        [Test]
        [TestCase("AokiNayo", 50, 1000, "Nayo", 50, 20)]
        [TestCase("AokiNayo", 50, 5000, "Nayo", 50, 10)]
        public void WarriorDefendersHPMustBeGreaterThanAttackerMinHP(string attackerName, int attackerDamage, int attackerHP,
            string defenderName, int defenderDamage, int defenderHP)
        {
            Warrior attackerWarrior = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defenderWarrior = new Warrior(defenderName,defenderDamage,defenderHP);

            Assert.Throws<InvalidOperationException>(() => attackerWarrior.Attack(defenderWarrior));
        }

        [Test]
        [TestCase("AokiNayo", 50, 500, "Nayo", 1000, 1000)]
        [TestCase("AokiNayo", 50, 200, "Nayo", 201, 5000)]
        public void WarriorAttackedHPLessThanDefenderDamageException(string attackerName, int attackerDamage, int attackerHP,
            string defenderName, int defenderDamage, int defenderHP)
        {
            Warrior attackerWarrior = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defenderWarrior = new Warrior(defenderName, defenderDamage, defenderHP);

            Assert.Throws<InvalidOperationException>(() => attackerWarrior.Attack(defenderWarrior));
        }

        [Test]
        [TestCase("AokiNayo", 250, 1000, "Nayo", 100, 250)]
        [TestCase("AokiNayo", 500, 2000, "Nayo", 100, 250)]
        public void WarriorAttackerSuccessfullyAttacksWarriorDefender(string attackerName, int attackerDamage, int attackerHP,
            string defenderName, int defenderDamage, int defenderHP)
        {
            Warrior attackerWarrior = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defenderWarrior = new Warrior(defenderName, defenderDamage, defenderHP);

            attackerWarrior.Attack(defenderWarrior);

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

            attackerWarrior.Attack(defenderWarrior);

            Assert.That(defenderWarrior.HP, Is.EqualTo(250));

        }
    }
}