using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AttackDurabilityDecreaseAfterAttack()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        //Assert.AreEqual(9, axe.DurabilityPoints);
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
    }

    [Test]
    public void AttackWithABrokenWeapon()
    {
        Axe axe = new Axe(25, 0);
        Dummy dummy = new Dummy(100, 100);

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "You sucessfully attacked with broken Axe");

    }
}