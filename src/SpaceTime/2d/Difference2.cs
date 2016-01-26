﻿using System;
using Bearded.Utilities.Math;
using OpenTK;

namespace Bearded.Utilities.SpaceTime
{
    public struct Difference2 : IBackedBy<Vector2>, IEquatable<Difference2>
    {
        private readonly Vector2 value;

        public Difference2(Vector2 value)
        {
            this.value = value;
        }

        public Difference2(float x, float y)
            : this(new Vector2(x, y))
        {
        }

        public Difference2(Unit x, Unit y)
            : this(new Vector2(x.NumericValue, y.NumericValue))
        {
        }

        public static Difference2 In(Direction2 direction, Unit u)
        {
            return direction * u;
        }

        #region properties

        public Vector2 NumericValue { get { return this.value; } }

        public Unit X { get { return new Unit(this.value.X); } }
        public Unit Y { get { return new Unit(this.value.Y); } }

        public Direction2 Direction { get { return Direction2.Of(this.value); } }

        public Unit Length { get { return new Unit(this.value.Length); } }

        public Squared<Unit> LengthSquared { get { return new Squared<Unit>(this.value.LengthSquared); } }

        #endregion

        #region methods

        #region lerp

        public static Difference2 Lerp(Difference2 d0, Difference2 d1, float t)
        {
            return d0 + (d1 - d0) * t;
        }

        public Difference2 LerpTo(Difference2 d, float t)
        {
            return Lerp(this, d, t);
        }

        #endregion

        #region projection

        public Unit ProjectedOn(Vector2 vector)
        {
            return this.projectedOn(vector.NormalizedSafe());
        }
        public Unit ProjectedOn(Difference2 vector)
        {
            return this.projectedOn(vector.NumericValue.NormalizedSafe());
        }
        public Unit ProjectedOn(Direction2 direction)
        {
            return this.projectedOn(direction.Vector);
        }

        private Unit projectedOn(Vector2 normalisedVector)
        {
            return new Unit(Vector2.Dot(this.value, normalisedVector));
        }

        #endregion

        #region equality and hashcode

        public bool Equals(Difference2 other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Difference2 && this.Equals((Difference2)obj);
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        #endregion

        #endregion

        #region operators

        #region algebra

        public static Difference2 operator +(Difference2 d0, Difference2 d1)
        {
            return new Difference2(d0.value + d1.value);
        }
        public static Difference2 operator -(Difference2 d0, Difference2 d1)
        {
            return new Difference2(d0.value - d1.value);
        }

        #endregion

        #region scaling

        public static Difference2 operator -(Difference2 d)
        {
            return new Difference2(-d.value);
        }
        public static Difference2 operator *(Difference2 d, float scalar)
        {
            return new Difference2(d.value * scalar);
        }
        public static Difference2 operator *(float scalar, Difference2 d)
        {
            return new Difference2(d.value * scalar);
        }
        public static Difference2 operator /(Difference2 d, float divisor)
        {
            return new Difference2(d.value / divisor);
        }

        #endregion

        #region ratio

        public static Vector2 operator /(Difference2 d, Unit divisor)
        {
            return d.value / divisor.NumericValue;
        }

        #endregion

        #region differentiate

        public static Velocity2 operator /(Difference2 d, TimeSpan t)
        {
            return new Velocity2(d.value / (float)t.NumericValue);
        }

        #endregion

        #region comparision

        public static bool operator ==(Difference2 d0, Difference2 d1)
        {
            return d0.value == d1.value;
        }

        public static bool operator !=(Difference2 d0, Difference2 d1)
        {
            return d0.value != d1.value;
        }

        #endregion

        #endregion

    }
}