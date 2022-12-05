namespace Model
{
    /// <summary>
    /// Класс описывающий параметры автомобиля.
    /// </summary>
    public class Car : AbstractTransportBase
    {
        /// <summary>
        /// Конструктор класса Car.
        /// </summary>
        /// <param name="coveredDistance">Преодолённое автомобилем
        /// расстояние.</param>
        /// <param name="fuelSpend">Расход 
        /// топлива автомобиля.</param>
        public Car(double coveredDistance, double fuelSpend)
        {
            CoveredDistance = coveredDistance;
            FuelSpend = fuelSpend;
        }

        /// <summary>
        /// Константа для описания максимального преодолённого
        /// автомобилем расстояния.
        /// </summary>
        public const int maxCoveredDistance = 999000;

        /// <summary>
        /// Поле для описания максимального преодолённого
        /// автомобилем расстояния.
        /// </summary>
        private double _coveredDistance;

        /// <summary>
        /// Свойство для описания преодолённого
        /// автомобилем расстояния.
        /// </summary>
        private protected double CoveredDistance
        {
            get => _coveredDistance;
            set => _coveredDistance =
                ValidateParam("преодолённое расстояние",
                value, minParamValue, maxCoveredDistance);
        }

        /// <summary>
        /// Свойство для описания названия транспортного средства.
        /// </summary>
        public override string TransportName => "Машина";

        /// <summary>
        /// Свойство для описания количества затраченного
        /// автомобилем топлива.
        /// </summary>
        public override double FuelUsed =>
            FuelSpend * CoveredDistance;
    }
}