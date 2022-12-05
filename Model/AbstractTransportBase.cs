using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Абстрактный класс описания базового транспортного средства.
    /// </summary>
    public abstract class AbstractTransportBase
    {
        /// <summary>
        /// Свойство описывающее названия транспортного средства.
        /// </summary>
        public abstract string TransportName { get; }

        /// <summary>
        /// Свойство описывающее количества затраченного топлива.
        /// </summary>
        public abstract double FuelUsed { get; }

        /// <summary>
        /// Константа описывающая минимальное значение параметра.
        /// </summary>
        public const int minParamValue = 0;

        /// <summary>
        /// Константа описывающая максимальное значение
        /// количества затраченного топлива.
        /// </summary>
        public const int maxFuelSpend = 999;

        /// <summary>
        /// Поле описывающее расхода топлива.
        /// </summary>
        private double _fuelSpend;

        /// <summary>
        /// Свойство описывающее расхода топлива.
        /// </summary>
        private protected double FuelSpend
        {
            get => _fuelSpend;
            set => _fuelSpend = ValidateParam("расход топлива",
                value, minParamValue, maxFuelSpend);
        }

        /// <summary>
        /// Метод валидации введённых значений.
        /// </summary>
        /// <param name="parametrName">Название 
        /// введённого параметра.</param>
        /// <param name="parametrValue">Значение 
        /// введённого параметра.</param>
        /// <param name="minParametrValue">Минимальное 
        /// значение введённого параметра.</param>
        /// <param name="maxParametrValue">Максимальное 
        /// значение введённого параметра.</param>
        /// <returns>Результат валидации.</returns>
        public static double ValidateParam(string parametrName,
            double parametrValue, double minParametrValue,
            double maxParametrValue)
        {
            if ((parametrValue > minParametrValue)
                && (parametrValue < maxParametrValue))
                return parametrValue;
            else
                throw new Exception($"Значение параметра" +
                    $" {parametrName} должно быть больше," +
                    $" чем {minParametrValue}" +
                    $" и меньше, чем {maxParametrValue}.");
        }
    }
}