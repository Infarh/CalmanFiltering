using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CalmanFiltering.Models
{
    public class Movement1D
    {
        public IReadOnlyList<double> Times { get; }

        public IReadOnlyList<DataPoint> Axeleration { get; }

        public IReadOnlyList<DataPoint> Speed { get; }

        public IReadOnlyList<DataPoint> Movement { get; }

        public int DataPointsCount => Times.Count;

        public (double Start, double End) Time => (Times[0], Times[^1]);

        public (double Start, double End) Position => (Movement[0].Y, Movement[^1].Y);

        private Movement1D(double[] Times, DataPoint[] Axeleration, DataPoint[] Speed, DataPoint[] Movement)
        {
            this.Times = Times;
            this.Axeleration = Axeleration;
            this.Speed = Speed;
            this.Movement = Movement;
        }

        public Movement1D(IList<double> Times, IList<double> Axeleration, IList<double> Speed, IList<double> Movement)
        {
            if (Times is null) throw new ArgumentNullException(nameof(Times));
            if (Axeleration is null) throw new ArgumentNullException(nameof(Axeleration));
            if (Speed is null) throw new ArgumentNullException(nameof(Speed));
            if (Movement is null) throw new ArgumentNullException(nameof(Movement));

            var count = Times.Count;
            if (count == 0) throw new ArgumentException("Число временных отсчётов равно 0", nameof(Times));
            if (Axeleration.Count != count) throw new ArgumentException("Длина массива значений ускорения не совпадает с длиной массива отметок времени");
            if (Speed.Count != count) throw new ArgumentException("Длина массива значений скорости не совпадает с длиной массива отметок времени");
            if (Movement.Count != count) throw new ArgumentException("Длина массива значений перемещения не совпадает с длиной массива отметок времени");

            this.Times = Times as IReadOnlyList<double> ?? new ReadOnlyCollection<double>(Times);

            var axeleration = new List<DataPoint>(count);
            var speed = new List<DataPoint>(count);
            var movement = new List<DataPoint>(count);
            for (var i = 0; i < count; i++)
            {
                var t = Times[i];
                axeleration.Add((t, Axeleration[i]));
                speed.Add((t, Speed[i]));
                movement.Add((t, Movement[i]));
            }

            this.Axeleration = axeleration;
            this.Speed = speed;
            this.Movement = movement;
        }

        public Movement1D TrimByStartTime(double StartTime)
        {
            var index = 0;
            while (index < Times.Count && Times[index] < StartTime) index++;
            if (index == Times.Count) return this;

            var count = Times.Count - index;

            var times = new double[count];
            var axeleration = new DataPoint[count];
            var speed = new DataPoint[count];
            var movement = new DataPoint[count];

            for (var i = 0; i < count; i++)
            {
                times[i] = Times[index + i];
                axeleration[i] = Axeleration[index + i];
                speed[i] = Speed[index + i];
                movement[i] = Movement[index + i];
            }

            return new Movement1D(times, axeleration, speed, movement);
        }
    }
}