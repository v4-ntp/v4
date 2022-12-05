using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс описывающий параметры машины-гибрида.
    /// </summary>
    public class HybridCar : AbstractTransportBase
    {
        /// <summary>
        /// Конструктор класса HybridCar.
        /// </summary>
        /// <param name="fullCoveredDistance">Общее преодолённое
        /// расстояние машиной-гибридом.</param>
        /// <param name="coreredDistanceElectricMotor">Преодолённое
        /// расстояние на электродвигателе
        /// машиной-гибридом.</param>
        /// <param name="fuelSpend">Расход топлива
        /// машины-гибрида.</param>
        public HybridCar(double fullCoveredDistance,
                double coreredDistanceElectricMotor,
                double fuelSpend)
        {
            FullCoveredDistance = fullCoveredDistance;
            CoreredDistanceElectricMotor =
                coreredDistanceElectricMotor;
            FuelSpend = fuelSpend;
        }

        /// <summary>
        /// Константа описывающая максимальное
        /// общее преодолённое расстояние.
        /// </summary>
        public const int maxFullCoveredDistance = 99000;

        /// <summary>
        /// Поле описывающее общее преодолённое расстояние.
        /// </summary>
        private double _fullGeneralDistance;

        /// <summary>
        /// Свойство описывающее общее преодолённое расстояние.
        /// </summary>
        private protected double FullCoveredDistance
        {
            get => _fullGeneralDistance;
            set => _fullGeneralDistance =
                ValidateParam("общее преодолённое расстояние",
                    value, minParamValue, maxFullCoveredDistance);
        }

        /// <summary>
        /// Константа описывающая максимальное
        /// преодолённое расстояние на электродвигателе.
        /// </summary>
        public const int maxCoreredDistanceElectricMotor = 9999;

        /// <summary>
        /// Поле описывающее преодолённое
        /// расстояние на электродвигателе.
        /// </summary>
        private double _coreredDistanceElectricMotor;

        /// <summary>
        /// Свойство для описания преодолённого
        /// расстояния на электродвигателе.
        /// </summary>
        private protected double CoreredDistanceElectricMotor
        {
            get => _coreredDistanceElectricMotor;
            set => _coreredDistanceElectricMotor =
                ValidateParam("преодолённое расстояние на" +
                " электрическом двигателе", value, minParamValue,
                    maxCoreredDistanceElectricMotor);
        }

        /// <summary>
        /// Метод вычисления количества затраченного
        /// топлива машиной-гибридом.
        /// </summary>
        /// <returns>Количество затраченного топлива
        /// машиной-гибридом.</returns>
        private double CalculateFuelUsed()
        {
            if (FullCoveredDistance >
                CoreredDistanceElectricMotor)
                return (FullCoveredDistance
                    - CoreredDistanceElectricMotor)
                    * FuelSpend;
            else
                return 0;
        }

        /// <summary>
        /// Свойство для описания названия транспортного средства.
        /// </summary>
        public override string TransportName => "Машина-гибрид";

        /// <summary>
        /// Свойство для описания количества затраченного
        /// топлива машиной-гибридом.
        /// </summary>
        public override double FuelUsed => CalculateFuelUsed();
    }
}