using System;
using System.Runtime.CompilerServices;
using MathCore;

namespace CalmanFiltering.Models
{
    /// <summary>Модель движения</summary>
    public class Moving1D
    {
        /// <summary>Возведение в квадрат</summary>
        /// <param name="x">Водводимая в квадрат величина</param>
        /// <returns>Квадрат значения</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double Sqr(double x) => x * x;

        /// <summary>Функция Нормального распределения</summary>
        /// <param name="x">Аргумент</param>
        /// <param name="sigma">Среднеквадратичное отклонение</param>
        /// <param name="mu">Матекматическое ожидание</param>
        /// <returns>Значение распределение в указанной точке</returns>
        private static double Normal(double x, double sigma = 1, double mu = 0) => Math.Exp(-Sqr((x - mu) / sigma) / 2) / sigma / Consts.sqrt_pi2;

        /// <summary>Скорость, добавляемая в модель после первого воздействия [м/с]</summary>
        public double Amax1 { get; set; } = 5;

        /// <summary>Момент времени максимума первого воздействия [с]</summary>
        public double t1 { get; set; } = 6;

        /// <summary>Длительность первого воздействия</summary>
        public double DeltaT1 { get; set; } = 4;

        /// <summary>Скорость, добавляемая в модель после воторого воздействия [м/с]</summary>
        public double Amax2 { get; set; } = 5;

        /// <summary>Момент времени максимума второго воздействия [с]</summary>
        public double t2 { get; set; } = 18;

        /// <summary>Длительность второго воздействия</summary>
        public double DeltaT2 { get; set; } = 2;

        /// <summary>Время моделирования</summary>
        public (double Min, double Max) ModelingTime => (t1 - 3 * DeltaT1, t2 + 3 * DeltaT2);

        /// <summary>Временная зависимость ускорения, приобретаемого моделью в ходе воздействия</summary>
        /// <param name="t">Момент времени вычисления значения ускорения</param>
        /// <returns>Значение ускорения в указанный момент времени</returns>
        public double Axeleration(double t) => Amax1 * Normal(t, DeltaT1 * .5, t1) - Amax2 * Normal(t, DeltaT2 * .5, t2);


    }
}
