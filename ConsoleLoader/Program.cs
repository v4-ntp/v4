using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

using Model;

namespace ConsoleLoader
{
    /// <summary>
    /// Класс, демонстрирующий работу библиотеки Model.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в приложение.
        /// </summary>
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture
                = new CultureInfo("ru-RU");

            CostAutomobile();
            CostHelicopter();
            CostHybrid();

            Console.ReadKey();
        }

        /// <summary>
        /// Статический метод вычисления затраченного
        /// топлива автомобилем.
        /// </summary>
        private static void CostAutomobile()
        {
            Console.WriteLine("Машина");

            double fuelSpend = EnterFuelSpend();
            string parametrCoveredDistance =
                "преодолённое расстояние";

            InstallParamert(parametrCoveredDistance,
                Car.maxCoveredDistance);
            double coveredDistance =
                ValidateParam(parametrCoveredDistance,
                Car.maxCoveredDistance);
            AbstractTransportBase car =
                new Car(coveredDistance, fuelSpend);
            WriteInfo(car);
        }

        /// <summary>
        /// Статический метод вычисления
        /// затраченного топлива вертолётом.
        /// </summary>
        private static void CostHelicopter()
        {
            Console.WriteLine("Вертолёт.");

            string paramertTimeFligth = "время полёта";

            InstallParamert(paramertTimeFligth,
                Helicopter.maxTimeFligth);
            double timeFligth = ValidateParam(paramertTimeFligth,
                Helicopter.maxTimeFligth);
            double fuelConsumption = EnterFuelSpend();
            AbstractTransportBase helicopter =
                new Helicopter(timeFligth, fuelConsumption);
            WriteInfo(helicopter);
        }
        /// <summary>
        /// Статический метод вычисления 
        /// затраченного топлива машиной-гибридом.
        /// </summary>
        private static void CostHybrid()
        {
            Console.WriteLine("Машина-гибрид.");

            string parametrFullCoveredDistance = "общее" +
                " преодолённое расстояние";
            InstallParamert(parametrFullCoveredDistance,
                HybridCar.maxFullCoveredDistance);

            double fullCoveredDistance =
                ValidateParam(parametrFullCoveredDistance,
                HybridCar.maxFullCoveredDistance);
            string parametrCoreredDistanceElectricMotor
                = "преодолённое расстояние на электрическом" +
                " двигателе";
            InstallParamert(parametrCoreredDistanceElectricMotor,
                HybridCar.maxCoreredDistanceElectricMotor);
            double electricalDistance =
                ValidateParam(parametrCoreredDistanceElectricMotor,
                HybridCar.maxCoreredDistanceElectricMotor);
            double fuelConsumption = EnterFuelSpend();
            AbstractTransportBase hybridCar =
                new HybridCar(fullCoveredDistance,
                electricalDistance, fuelConsumption);
            WriteInfo(hybridCar);
        }

        /// <summary>
        /// Статический метод проверки допустимости
        /// введённых значений.
        /// </summary>
        /// <param name="parametrName">Название параметра.</param>
        /// <param name="maxParametrValue">Максимальное 
        /// значение параметра.</param>
        private static void InstallParamert(string parametrName,
            int maxParametrValue)
        {
            Console.WriteLine($"Введите значение" +
                $" {parametrName}. Значение параметра" +
                $" {parametrName} должно быть больше чем " +
                $"{AbstractTransportBase.minParamValue} и" +
                $" меньше чем {maxParametrValue}:");
        }

        /// <summary>
        /// Статический метод для ввода расхода топлива.
        /// </summary>
        /// <returns>Расход топлива.</returns>
        private static double EnterFuelSpend()
        {
            string parametrFuelConsumption = "расход топлива";
            InstallParamert(parametrFuelConsumption,
                AbstractTransportBase.maxFuelSpend);
            double fuelConsumption =
                ValidateParam(parametrFuelConsumption,
                AbstractTransportBase.maxFuelSpend);
            return fuelConsumption;
        }

        /// <summary>
        /// Статический метод валидации введённых значений.
        /// </summary>
        /// <param name="paramertName">Название
        /// введённого параметра.</param>
        /// <param name="maxParametrValue">Максимальное
        /// значение введённого параметра.</param>
        /// <returns> Результат валидаии.</returns>
        private static double ValidateParam(string paramertName,
            int maxParametrValue)
        {
            double value;
            do
            {
                try
                {
                    string parametrValue = Console.ReadLine()
                        .Replace(".", ",");
                    if (parametrValue.Contains(" "))
                    {
                        throw new Exception("Введено" +
                            " некорректное значение.");
                    }
                    value = Convert.ToDouble(parametrValue);
                    AbstractTransportBase
                        .ValidateParam(paramertName, value,
                        AbstractTransportBase.minParamValue,
                        maxParametrValue);
                    Console.WriteLine($"Введено значение:" +
                        $" {value}.");
                    break;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    InstallParamert(paramertName,
                        maxParametrValue);
                }
            } while (true);
            return value;
        }

        /// <summary>
        /// Статический метод вывода информации на консоль.
        /// </summary>
        /// <param name="abstractTransportBase">Объект класса
        /// AbstractTransport</param>
        private static void WriteInfo(AbstractTransportBase
            abstractTransportBase)
        {
            Console.WriteLine($"Название транспортного средства:" +
                $" {abstractTransportBase.TransportName}");
            Console.WriteLine($"Количество затраченного" +
                $" топлива: {abstractTransportBase.FuelUsed}");
        }
    }
}