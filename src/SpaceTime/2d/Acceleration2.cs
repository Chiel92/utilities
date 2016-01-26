﻿using System;
using Bearded.Utilities.Math;
using OpenTK;

namespace Bearded.Utilities.SpaceTime
{
    struct Acceleration2 : IBackedBy<Vector2>, IEquatable<Acceleration2>
    {
        private readonly Vector2 value;

        public Acceleration2(Vector2 value)
        {
            this.value = value;
        }

        #region properties

        public Vector2 NumericValue { get { return this.value; } }

        public Direction2 Direction { get { return Direction2.Of(this.value); } }

        public Acceleration Length { get { return new Acceleration(this.value.Length); } }

        #endregion

        #region methods

        #region projection

        public Acceleration ProjectedOn(Vector2 vector)
        {
            return this.projectedOn(vector.NormalizedSafe());
        }

        public Acceleration ProjectedOn(Difference2 vector)
        {
            return this.projectedOn(vector.NumericValue.NormalizedSafe());
        }

        public Acceleration ProjectedOn(Direction2 direction)
        {
            return this.projectedOn(direction.Vector);
        }

        private Acceleration projectedOn(Vector2 normalisedVector)
        {
            return new Acceleration(Vector2.Dot(this.value, normalisedVector));
        }

        #endregion

        #region equality and hashcode

        public bool Equals(Acceleration2 other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Acceleration2 && this.Equals((Acceleration2)obj);
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        #endregion

        #endregion

        #region operators

        #region algebra

        public static Acceleration2 operator +(Acceleration2 a0, Acceleration2 a1)
        {
            return new Acceleration2(a0.value + a1.value);
        }
        public static Acceleration2 operator -(Acceleration2 a0, Acceleration2 a1)
        {
            return new Acceleration2(a0.value - a1.value);
        }

        #endregion

        #region scaling

        public static Acceleration2 operator -(Acceleration2 a)
        {
            return new Acceleration2(-a.value);
        }
        public static Acceleration2 operator *(Acceleration2 a, float scalar)
        {
            return new Acceleration2(a.value * scalar);
        }
        public static Acceleration2 operator *(float scalar, Acceleration2 a)
        {
            return new Acceleration2(a.value * scalar);
        }
        public static Acceleration2 operator /(Acceleration2 a, float divisor)
        {
            return new Acceleration2(a.value / divisor);
        }

        #endregion

        #region ratio

        public static Vector2 operator /(Acceleration2 a, Acceleration divisor)
        {
            return a.value / divisor.NumericValue;
        }

        #endregion

        #region integrate

        public static Velocity2 operator *(Acceleration2 a, TimeSpan t)
        {
            return new Velocity2(a.value * (float)t.NumericValue);
        }
        public static Velocity2 operator *(TimeSpan t, Acceleration2 a)
        {
            return new Velocity2(a.value * (float)t.NumericValue);
        }

        #endregion

        #region comparision

        public static bool operator ==(Acceleration2 a0, Acceleration2 a1)
        {
            return a0.value == a1.value;
        }

        public static bool operator !=(Acceleration2 a0, Acceleration2 a1)
        {
            return a0.value != a1.value;
        }

        #endregion

        #endregion

    }
}