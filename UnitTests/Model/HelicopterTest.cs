using System;

using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Тестовый набор для класса HelicopterTest.
    /// </summary>
    [TestFixture]
    public class HelicopterTest
    {
        /// <summary>
        /// Тестирование свойства TransportName.
        /// </summary>
        [Test(Description = "Тестирование свойства TransportName")]
        [TestCase(TestName = "Тестирование" +
            " свойства TransportName")]
        public void TestName()
        {
            Assert.AreEqual("Вертолёт",
                new Helicopter(10, 8).TransportName);
            Assert.AreNotEqual("Машина",
                new Helicopter(200, 88).TransportName);
            Assert.AreNotEqual("Самолёт",
                new Helicopter(300, 98).TransportName);
            Assert.AreNotEqual("Машина-гобрид",
                new Helicopter(400, 108).TransportName);
            Assert.AreNotEqual("вертолёт",
                new Helicopter(500, 208).TransportName);
        }

        /// <summary>
        /// Тестирование свойства FuelUsed
        /// (положительное тестирование).
        /// </summary>
        /// <param name="timeFligth">Время полёта.</param>
        /// <param name="fuelSpend">Расход топлива.</param>
        [Test]
        [TestCase(AbstractTransportBase.minParamValue + 0.1,
            AbstractTransportBase.minParamValue + 0.1,
            TestName = "Тест количества затраченного топлива" +
            " при минимально допустимых параметрах.")]

        [TestCase(AbstractTransportBase.minParamValue + 1,
            AbstractTransportBase.minParamValue + 1,
            TestName = "Тест количества затраченного топлива" +
            " при минимально допустимых параметрах +1.")]

        [TestCase(500, 600, TestName = "Тест количества " +
            "затраченного топлива.")]

        [TestCase(Helicopter.maxTimeFligth - 1,
            Helicopter.maxFuelSpend - 1,
            TestName = "Тест количества затраченного" +
            " топлива при максимально допустимых " +
            "параметрах -1.")]

        [TestCase(Helicopter.maxTimeFligth - 0.001,
            Helicopter.maxFuelSpend - 0.001,
            TestName = "Тест количества затраченного" +
            " топлива при максимально " +
            "допустимых параметрах.")]
        public void TestPosetivSpendFuel(double timeFligth,
            double fuelSpend)
        {
            Helicopter helicopter = new Helicopter(timeFligth,
                fuelSpend);
            Assert.AreEqual(timeFligth, fuelSpend,
                timeFligth * fuelSpend * 0.98);
        }

        /// <summary>
        /// Тестирование свойства FuelUsed
        /// (негативное тестирование).
        /// </summary>
        /// <param name="timeFligth">Время полёта.</param>
        /// <param name="fuelConsumption">Расход топлива.</param>
        [Test]
        [TestCase(Helicopter.minParamValue, 1,
            TestName = "Тест затраченного топлива " +
            "(при недопустимом (малом) значении" +
            " времени полёта).")]

        [TestCase(1, Helicopter.minParamValue,
            TestName = "Тест затраченного топлива " +
            "(при недопустимом (малом) значении расхода).")]

        [TestCase(Helicopter.minParamValue - 1,
            Helicopter.minParamValue - 1,
            TestName = "Тест затраченного топлива " +
            "(при отрицательных значениях).")]

        [TestCase(Helicopter.maxTimeFligth + 100, 200,
            TestName = "Тест затраченного топлива" +
            " (при недопустимом (большом) значении " +
            "времени полёта).")]

        [TestCase(10, Helicopter.maxFuelSpend + 1,
            TestName = "Tест затраченного топлива" +
            " (при недопустимом (большом) значении расхода).")]
        public void TestNegotiveSpendFuel(double timeFligth,
            double fuelConsumption)
        {
            Assert.Throws<Exception>(delegate ()
            {
                Helicopter helicopter = new Helicopter(timeFligth,
                    fuelConsumption);
            });
        }
    }
}