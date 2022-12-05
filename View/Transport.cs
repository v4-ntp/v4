using System;

namespace View
{
    [Serializable]
    /// <summary>
    /// Класс описывающий транспортное средство.
    /// </summary>
    public class Transport
    {
        /// <summary>
        /// Свойство для описания названия
        /// транспортного средства.
        /// </summary>
        public string TransportName { get; set; }

        /// <summary>
        /// Свойство для описания количества
        /// затраченного топлива транспортом.
        /// </summary>
        public double? FuelUsed { get; set; }
    }
}