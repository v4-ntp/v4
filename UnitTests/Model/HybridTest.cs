using System;

using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Тестовый набор для класса HybridTest.
    /// </summary>
    [TestFixture]
    public class HybridTest
    {
        /// <summary>
        /// Тестирование свойства TransportName.
        /// </summary>
        [Test(Description = "Тестирование свойства TransportName")]
        [TestCase(TestName = "Тестирование " +
            "свойства TransportName")]
        public void TestName()
        {
            Assert.AreEqual("Машина-гибрид", new HybridCar(998,
                998, 998)
                .TransportName);

            Assert.AreNotEqual("машина-гибрид", new HybridCar(100,
                200, 300)
                .TransportName);

            Assert.AreNotEqual("Вертолёт", new HybridCar(998, 998,
                998)
                .TransportName);

            Assert.AreNotEqual("Машина", new HybridCar(998, 998,
                998)
                .TransportName);

            Assert.AreNotEqual("самолёт", new HybridCar(998, 998,
                998)
                .TransportName);
        }

        /// <summary>
        /// Тестирование свойства FuelUsed
        /// (положительное тестирование).
        /// </summary>
        /// <param name="fullCoveredDistance">Общее преодолённое
        /// расстояние.</param>
        /// <param name="coveredDistanceElectricMotor">
        /// Преодолённое расстояние на электродвигателе.</param>
        /// <param name="fuelConsumption">Расход топлива.</param>
        [Test]
        [TestCase(HybridCar.minParamValue + 0.001,
            HybridCar.minParamValue + 0.001,
            HybridCar.minParamValue + 0.001,
            TestName = "Тест количества затраченного " +
            "топлива при минимально допустимых параметрах.")]

        [TestCase(HybridCar.minParamValue + 1,
            HybridCar.minParamValue + 1,
            HybridCar.minParamValue + 1,
            TestName = "Тест количества затраченного " +
            "топлива при минимально допустимых параметрах +1.")]

        [TestCase(998, 998, 998,
            TestName = "Тест количества затраченного топлива.")]

        [TestCase(HybridCar.maxFullCoveredDistance - 0.001,
            HybridCar.maxCoreredDistanceElectricMotor - 0.001,
            HybridCar.maxFuelSpend - 0.001,
            TestName = "Тест количества затраченного" +
            " топлива при максимально допустимых параметрах.")]

        [TestCase(HybridCar.maxFullCoveredDistance - 1,
            HybridCar.maxCoreredDistanceElectricMotor - 1,
            HybridCar.maxFuelSpend - 1,
            TestName = "Тест количества затраченного" +
            " топлива при максимально допустимых параметрах-1.")]

        public void TestPosetivSpendFuel(
            double fullCoveredDistance,
            double coveredDistanceElectricMotor,
            double fuelConsumption)
        {
            HybridCar hybridCar =
                new HybridCar(fullCoveredDistance,
                coveredDistanceElectricMotor, fuelConsumption);
            Assert.True(hybridCar.FuelUsed == ((fullCoveredDistance
                - coveredDistanceElectricMotor)
                * fuelConsumption));
        }

        /// <summary>
        /// Тестирование свойства FuelUsed
        ///(негативное тестирование).
        /// </summary>
        /// <param name="totalCoveredDistance">Общее преодолённое
        /// расстояние.</param>
        /// <param name="coreredDistanceElectricMotor">Преодолённое
        /// расстояние на электродвигателе.</param>
        /// <param name="fuelConsumption">Расход топлива.</param>
        [Test]
        [TestCase(HybridCar.minParamValue - 1,
            HybridCar.minParamValue + 1,
            HybridCar.minParamValue + 1,
            TestName = "Тест затраченного топлива (при " +
            "недопустимом (малом) значении общего расстояния).")]

        [TestCase(HybridCar.minParamValue + 1,
            HybridCar.minParamValue - 1,
            HybridCar.minParamValue + 1,
            TestName = "Тест затраченного топлива (при" +
            " недопустимом (малом) значении расстояния на" +
            " электричестве).")]

        [TestCase(HybridCar.minParamValue + 1,
            HybridCar.minParamValue + 1,
            HybridCar.minParamValue - 1,
            TestName = "Тест затраченного топлива (при" +
            " недопустимом (малом) значении расхода).")]

        [TestCase(HybridCar.minParamValue - 1,
            HybridCar.minParamValue - 1,
            HybridCar.minParamValue - 1,
            TestName = "Тест затраченного топлива (при" +
            " отрицательных значениях).")]

        [TestCase(HybridCar.maxFullCoveredDistance + 1,
            998, 998, TestName = "Тест затраченного топлива" +
            " (при недопустимом (большом) значении " +
            "общего расстояния).")]

        [TestCase(998, HybridCar.maxCoreredDistanceElectricMotor
            + 1, 998, TestName = "Тест затраченного топлива " +
            "(при недопустимом (большом) расстоянии" +
            " на электричестве).")]

        [TestCase(998, 998, HybridCar.maxFuelSpend + 1,
            TestName = "Тест затраченного топлива (при" +
            " недопустимом (большом) значении расхода).")]

        public void TestNegotiveSpendFuel(
            double totalCoveredDistance,
            double coreredDistanceElectricMotor,
            double fuelConsumption)
        {
            Assert.Throws<Exception>(delegate ()
            {
                HybridCar hybridCar =
                new HybridCar(totalCoveredDistance,
                    coreredDistanceElectricMotor, fuelConsumption);
            });
        }
    }
}