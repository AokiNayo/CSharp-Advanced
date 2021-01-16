using System;
using NUnit.Framework;
using System.Linq;

namespace Robots.Tests
{
    using System;

    public class RobotsTests
    {
        [Test]
        [TestCase("AokiNayo",155)]
        public void RobotConstructorInitializedCorrectly(string name, int maximumBattery)
        {
            Robot robot = new Robot(name, maximumBattery);

            Assert.AreEqual(name, robot.Name);
            Assert.AreEqual(maximumBattery, robot.MaximumBattery);
            Assert.AreEqual(maximumBattery, robot.Battery);
        }

        [Test]
        [TestCase(150)]
        public void RobotManagerConstructorInitializedCorrectly(int capacity)
        {
            RobotManager robotManager = new RobotManager(capacity); // Check list in constructor

            Assert.AreEqual(capacity,robotManager.Capacity);
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        [TestCase(-150)]
        public void RobotManagerCapacityException(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
        }

        [Test]
        [TestCase("Nayo", 150, 15)]
        public void AddEqualRobotsNameThrowsException(string name, int maximumBattery, int capacity)
        {
            Robot robot = new Robot(name,maximumBattery);
            RobotManager robotManager = new RobotManager(capacity);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        [TestCase("Nayo", 150, 0)]
        public void AddEqualCapacityThrowsException(string name, int maximumBattery, int capacity)
        {
            Robot robot = new Robot(name, maximumBattery);
            RobotManager robotManager = new RobotManager(capacity);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        // TODO: FOR ADD METHOD CHECK IF "ADD" WORKS CORRECTLY

        [Test]
        [TestCase("Nayo", 150, 5, 0)]
        public void RemoveRobotByName(string name, int maximumBattery, int capacity, int expected)
        {
            Robot robot = new Robot(name, maximumBattery);
            RobotManager robotManager = new RobotManager(capacity);

            robotManager.Add(robot);
            robotManager.Remove(name);

            Assert.AreEqual(expected, robotManager.Count);
        }

        [Test]
        [TestCase("Nayo", 150, 5, 0)]
        public void RemoveRobotByNameThrowsException(string name, int maximumBattery, int capacity, int expected)
        {
            RobotManager robotManager = new RobotManager(capacity);

            Assert.Throws <InvalidOperationException>(() => robotManager.Remove(name));
        }

        [Test]
        [TestCase("Nayo", 150, 5, 0, 15)]
        public void Work(string name, int maximumBattery, int capacity, int expected, int batteryUsage)
        {
            Robot robot = new Robot(name, maximumBattery);
            RobotManager robotManager = new RobotManager(capacity);

            robotManager.Add(robot);
            robotManager.Work(name,"Programming", batteryUsage);

            Assert.AreEqual(135,robot.Battery);
        }

        [Test]
        [TestCase("Nayo", 150, 5, 0, 15)]
        public void WorkThrowsNullException(string name, int maximumBattery, int capacity, int expected,
            int batteryUsage)
        {
            Robot robot = new Robot(name, maximumBattery);
            RobotManager robotManager = new RobotManager(capacity);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work(name, "Programming", batteryUsage));
        }

        [Test]
        [TestCase("Nayo", 0, 5, 0, 15)]
        public void WorkThrowsNotEnoughBatteryException(string name, int maximumBattery, int capacity, int expected,
            int batteryUsage)
        {
            Robot robot = new Robot(name, maximumBattery);
            RobotManager robotManager = new RobotManager(capacity);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work(name, "Programming", batteryUsage));
        }


        [Test]
        [TestCase("Nayo", 150, 5, 0, 15)]
        public void Charge(string name, int maximumBattery, int capacity, int expected,
            int batteryUsage)
        {
            Robot robot = new Robot(name, maximumBattery);
            RobotManager robotManager = new RobotManager(capacity);

            robotManager.Add(robot);
            robotManager.Work(name, "Programming", batteryUsage);
            robotManager.Charge(name);

            Assert.AreEqual(150, robot.Battery);
        }

        [Test]
        [TestCase("Nayo", 150, 5, 15)]
        public void ChargeException(string name, int maximumBattery, int capacity, int batteryUsage)
        {
            RobotManager robotManager = new RobotManager(capacity);

            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(name));
        }
    }
}
