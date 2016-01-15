﻿using Bearded.Utilities.Math;
using OpenTK;

namespace Bearded.Utilities.SpaceTime
{
    struct Difference2 : IBackedBy<Vector2>
    {
        private readonly Vector2 value;

        public Difference2(Vector2 value)
        {
            this.value = value;
        }

        #region properties

        public Vector2 NumericValue { get { return this.value; } }

        public Direction2 Direction { get { return Direction2.Of(this.value); } }

        public Unit Length { get { return new Unit(this.value.Length); } }

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

        #endregion
    }
}