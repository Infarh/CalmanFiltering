using System;

namespace CalmanFiltering.Models
{
    public readonly struct DataPoint : IEquatable<DataPoint>
    {
        public double X { get; }

        public double Y { get; }

        public DataPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(DataPoint other) => X.Equals(other.X) && Y.Equals(other.Y);

        public override bool Equals(object obj) => obj is DataPoint other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(DataPoint left, DataPoint right) => left.Equals(right);
        public static bool operator !=(DataPoint left, DataPoint right) => !left.Equals(right);

        public static implicit operator DataPoint((double X, double Y) Point) => new DataPoint(Point.X, Point.Y);
    }
}