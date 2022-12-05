using System;

using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Тестовый набор для класса CarTest.
    /// </summary>
    [TestFixture]
    public class CarTest
    {
        /// <summary>
        /// Тестирование свойства TransportName.
        /// </summary>
        [Test(Description = "Тестирование свойства TransportName")]
        [TestCase(TestName = "Тестирование " +
            "свойства TransportName")]
        public void TestName()
        {
            Assert.AreEqual("Машина",
                new Car(99899, 998).TransportName);

            Assert.AreNotEqual("машина",
                new Car(1, 1).TransportName);

            Assert.AreNotEqual("Вертолёт",
                new Car(500, 345).TransportName);

            Assert.AreNotEqual("Пуля",
                new Car(15, 998).TransportName);

            Assert.AreNotEqual("Машина-гибрид",
                new Car(99899, 1).TransportName);
        }

        /// <summary>
        /// Тестирование свойства FuelUsed
        /// (положительное тестирование).
        /// </summary>
        /// <param name = "coveredDistance" > Преодолённое
        /// расстояние.</param>
        /// <param name = "fuelSpent" > Расход топлива.</param>
        [Test]
        [TestCase(AbstractTransportBase.minParamValue + 0.1,
            AbstractTransportBase.minParamValue + 0.1,
            TestName = "Тест количества затраченного топлива " +
            "при минимально допустимых параметрах.")]

        [TestCase(AbstractTransportBase.minParamValue + 1,
            AbstractTransportBase.minParamValue + 1,
            TestName = "Тест количества затраченного топлива " +
            "при минимально допустимых параметрах +1.")]

        [TestCase(500, 300,
            TestName = "Тест количества затраченного топлива.")]

        [TestCase(Car.maxCoveredDistance - 1,
            AbstractTransportBase.maxFuelSpend - 1,
            TestName = "Тест количества затраченного " +
            "топлива при максимально допустимых параметрах -1.")]

        [TestCase(Car.maxCoveredDistance - 0.0001
            , AbstractTransportBase.maxFuelSpend - 0.0001,
            TestName = "Тест количества затраченного " +
            "топлива при максимально допустимых параметрах.")]

        public void TestPosetivConsumedFuel(double coveredDistance,
            double fuelSpent)
        {
            Car car = new Car(coveredDistance, fuelSpent);
            Assert.True(car.FuelUsed == (coveredDistance
                * fuelSpent));
            Assert.AreEqual(coveredDistance, fuelSpent,
                coveredDistance * fuelSpent);
        }

        /// <summary>
        /// Тестирование свойства FuelUsed
        /// (негативное тестирование).
        /// </summary>
        /// <param name="coveredDistance">Преодолённое
        /// расстояние.</param>
        /// <param name="fuelSpent">Расход
        /// топлива.</param>
        [Test]
        [TestCase(Car.maxCoveredDistance, 1,
            TestName = "Тест затраченного топлива" +
            " (при недопустимом (малом) значении расстояния).")]

        [TestCase(1, AbstractTransportBase.minParamValue,
            TestName = "Тест затраченного топлива" +
            " (при недопустимом (малом) значении расхода).")]

        [TestCase(-100, -100, TestName = "Тест затраченного" +
            " топлива (при отрицательных значениях).")]

        [TestCase(Car.maxCoveredDistance + 1, 1,
            TestName = "Тест затраченного топлива" +
            " (при недопустимом (большом) значении расстояния).")]

        [TestCase(1, Car.maxFuelSpend + 1,
            TestName = "Тест затраченного топлива" +
            " (при недопустимом (большом) значении расхода).")]

        public void TestNegotiveConsumedFuel(double
            coveredDistance, double fuelSpent)
        {
            Assert.Throws<Exception>(delegate ()
            {
                Car car = new Car(coveredDistance,
                    fuelSpent);
            });
        }
    }
}