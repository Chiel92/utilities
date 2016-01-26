﻿using System;
using Bearded.Utilities.Math;
using OpenTK;

namespace Bearded.Utilities.SpaceTime
{
    public struct Speed : IBackedBy<float>, IEquatable<Speed>, IComparable<Speed>
    {
        private readonly float value;

        public Speed(float value)
        {
            this.value = value;
        }

        public float NumericValue { get { return this.value; } }

        public Squared<Speed> Squared { get { return Squared<Speed>.FromRoot(this.value); } }

        public static Speed Zero { get { return new Speed(0); } }
        public static Speed One { get { return new Speed(1); } }

        #region methods

        #region equality and hashcode

        public bool Equals(Speed other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Speed && this.Equals((Speed)obj);
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        #endregion

        #region compare

        public int CompareTo(Speed other)
        {
            return this.value.CompareTo(other.value);
        }

        #endregion

        #endregion

        #region operators

        #region algebra

        public static Speed operator +(Speed s0, Speed s1)
        {
            return new Speed(s0.value + s1.value);
        }
        public static Speed operator -(Speed s0, Speed s1)
        {
            return new Speed(s0.value - s1.value);
        }

        #endregion

        #region scaling

        public static Speed operator -(Speed s)
        {
            return new Speed(-s.value);
        }
        public static Speed operator *(Speed s, float scalar)
        {
            return new Speed(s.value * scalar);
        }
        public static Speed operator *(float scalar, Speed s)
        {
            return new Speed(s.value * scalar);
        }
        public static Speed operator /(Speed s, float divisor)
        {
            return new Speed(s.value / divisor);
        }

        #endregion

        #region ratio

        public static float operator /(Speed dividend, Speed divisor)
        {
            return dividend.value / divisor.value;
        }

        #endregion

        #region differentiate

        public static Acceleration operator /(Speed s, TimeSpan t)
        {
            return new Acceleration(s.value / (float)t.NumericValue);
        }

        #endregion

        #region integrate

        public static Unit operator *(Speed s, TimeSpan t)
        {
            return new Unit(s.value * (float)t.NumericValue);
        }
        public static Unit operator *(TimeSpan t, Speed s)
        {
            return new Unit(s.value * (float)t.NumericValue);
        }

        #endregion

        #region add dimension

        public static Velocity2 operator *(Speed s, Direction2 d)
        {
            return new Velocity2(d.Vector * s.value);
        }
        public static Velocity2 operator *(Direction2 d, Speed s)
        {
            return new Velocity2(d.Vector * s.value);
        }

        public static Velocity2 operator *(Speed u, Vector2 v)
        {
            return new Velocity2(v * u.value);
        }
        public static Velocity2 operator *(Vector2 v, Speed u)
        {
            return new Velocity2(v * u.value);
        }

        #endregion

        #region comparision

        public static bool operator ==(Speed s0, Speed s1)
        {
            return s0.value == s1.value;
        }

        public static bool operator !=(Speed s0, Speed s1)
        {
            return s0.value != s1.value;
        }

        public static bool operator <(Speed s0, Speed s1)
        {
            return s0.value < s1.value;
        }

        public static bool operator >(Speed s0, Speed s1)
        {
            return s0.value > s1.value;
        }

        public static bool operator <=(Speed s0, Speed s1)
        {
            return s0.value <= s1.value;
        }

        public static bool operator >=(Speed s0, Speed s1)
        {
            return s0.value >= s1.value;
        }

        #endregion

        #endregion

    }
}