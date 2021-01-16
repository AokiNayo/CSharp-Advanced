using System;
using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        Axe axe = new Axe(25, 50);
        Dummy dummy = new Dummy(100, 100);

        axe.Attack(dummy);

        Assert.AreEqual(75, dummy.Health);
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        Axe axe = new Axe(25, 50);
        Dummy dummy = new Dummy(0, 100);

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        Dummy dummy = new Dummy(0,100);

        dummy.GiveExperience();

        Assert.AreEqual(dummy.GiveExperience(), 100);
    }

    [Test]
    public void AliveDummyCantGiveXP()
    {
        Dummy dummy = new Dummy(100, 100);

        Assert.Throws<InvalidOperationException>((() => dummy.GiveExperience()));
    }

}
