using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс описывающий лётные параметры вертолёта.
    /// </summary>
    public class Helicopter : AbstractTransportBase
    {
        /// <summary>
        /// Конструктор класса Helicopter.
        /// </summary>
        /// <param name="timeFligth">Время в полёте.</param>
        /// <param name="fuelSpend">Расход топлива.</param>
        public Helicopter(double timeFligth, double fuelSpend)
        {
            TimeFligth = timeFligth;
            FuelSpend = fuelSpend;
        }

        /// <summary>
        /// Константа для описания максимального времени в полёте.
        /// </summary>
        public const int maxTimeFligth = 9900;

        /// <summary>
        /// Поле описывающее время в полёте.
        /// </summary>
        private double _timeFligth;

        /// <summary>
        /// Свойство описывающее время в полёте.
        /// </summary>
        private protected double TimeFligth
        {
            get => _timeFligth;
            set => _timeFligth =
                ValidateParam("время полёта",
                value, minParamValue, maxTimeFligth);
        }

        /// <summary>
        /// Свойство для описания названия транспортного средства.
        /// </summary>
        public override string TransportName => "Вертолёт";

        /// <summary>
        /// Свойство для описания количества затраченного
        /// вертолётом топлива.
        /// </summary>
        public override double FuelUsed =>
            FuelSpend * TimeFligth * 0.98;
    }
}