using System;
using System.Text;
using UnityEngine;

[Serializable]
public struct Vec2d : IEquatable<Vec2d>
{
    #region Private Fields

    private static Vec2d zeroVector = new Vec2d(0f, 0f);
    private static Vec2d unitVector = new Vec2d(1f, 1f);
    private static Vec2d unitXVector = new Vec2d(1f, 0f);
    private static Vec2d unitYVector = new Vec2d(0f, 1f);

    #endregion Private Fields


    #region Public Fields

    public double x;
    public double y;

    #endregion Public Fields


    #region Properties

    public static Vec2d Zero
    {
        get { return zeroVector; }
    }

    public static Vec2d One
    {
        get { return unitVector; }
    }

    public static Vec2d UnitX
    {
        get { return unitXVector; }
    }

    public static Vec2d UnitY
    {
        get { return unitYVector; }
    }

    #endregion Properties


    #region Constructors

    public Vec2d(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public Vec2d(double value)
    {
        this.x = value;
        this.y = value;
    }

    #endregion Constructors


    #region Public Methods

    public static Vec2d Add(Vec2d value1, Vec2d value2)
    {
        value1.x += value2.x;
        value1.y += value2.y;
        return value1;
    }

    public static void Add(ref Vec2d value1, ref Vec2d value2, out Vec2d result)
    {
        result.x = value1.x + value2.x;
        result.y = value1.y + value2.y;
    }

    public static double Distance(Vec2d value1, Vec2d value2)
    {
        double v1 = value1.x - value2.x, v2 = value1.y - value2.y;
        return (double)Math.Sqrt((v1 * v1) + (v2 * v2));
    }

    public static void Distance(ref Vec2d value1, ref Vec2d value2, out double result)
    {
        double v1 = value1.x - value2.x, v2 = value1.y - value2.y;
        result = (double)Math.Sqrt((v1 * v1) + (v2 * v2));
    }

    public static double DistanceSquared(Vec2d value1, Vec2d value2)
    {
        double v1 = value1.x - value2.x, v2 = value1.y - value2.y;
        return (v1 * v1) + (v2 * v2);
    }

    public static void DistanceSquared(ref Vec2d value1, ref Vec2d value2, out double result)
    {
        double v1 = value1.x - value2.x, v2 = value1.y - value2.y;
        result = (v1 * v1) + (v2 * v2);
    }

    public static Vec2d Divide(Vec2d value1, Vec2d value2)
    {
        value1.x /= value2.x;
        value1.y /= value2.y;
        return value1;
    }

    public static void Divide(ref Vec2d value1, ref Vec2d value2, out Vec2d result)
    {
        result.x = value1.x / value2.x;
        result.y = value1.y / value2.y;
    }

    public static Vec2d Divide(Vec2d value1, double divider)
    {
        double factor = 1 / divider;
        value1.x *= factor;
        value1.y *= factor;
        return value1;
    }

    public static void Divide(ref Vec2d value1, double divider, out Vec2d result)
    {
        double factor = 1 / divider;
        result.x = value1.x * factor;
        result.y = value1.y * factor;
    }

    public static double Dot(Vec2d value1, Vec2d value2)
    {
        return (value1.x * value2.x) + (value1.y * value2.y);
    }

    public static void Dot(ref Vec2d value1, ref Vec2d value2, out double result)
    {
        result = (value1.x * value2.x) + (value1.y * value2.y);
    }

    public override bool Equals(object obj)
    {
        if(obj is Vec2d)
        {
            return Equals((Vec2d)this);
        }

        return false;
    }

    public bool Equals(Vec2d other)
    {
        return Math.Abs(x - other.x) < 0.001 && Math.Abs(y - other.y) < 0.001;
    }

    public static Vec2d Reflect(Vec2d vector, Vec2d normal)
    {
        Vec2d result;
        double val = 2.0f * ((vector.x * normal.x) + (vector.y * normal.y));
        result.x = vector.x - (normal.x * val);
        result.y = vector.y - (normal.y * val);
        return result;
    }

    public static void Reflect(ref Vec2d vector, ref Vec2d normal, out Vec2d result)
    {
        double val = 2.0f * ((vector.x * normal.x) + (vector.y * normal.y));
        result.x = vector.x - (normal.x * val);
        result.y = vector.y - (normal.y * val);
    }

    public override int GetHashCode()
    {
        return x.GetHashCode() + y.GetHashCode();
    }

    public double Length()
    {
        return (double)Math.Sqrt((x * x) + (y * y));
    }

    public double LengthSquared()
    {
        return (x * x) + (y * y);
    }

    public static Vec2d Max(Vec2d value1, Vec2d value2)
    {
        return new Vec2d(value1.x > value2.x ? value1.x : value2.x, 
            value1.y > value2.y ? value1.y : value2.y);
    }

    public static void Max(ref Vec2d value1, ref Vec2d value2, out Vec2d result)
    {
        result.x = value1.x > value2.x ? value1.x : value2.x;
        result.y = value1.y > value2.y ? value1.y : value2.y;
    }

    public static Vec2d Min(Vec2d value1, Vec2d value2)
    {
        return new Vec2d(value1.x < value2.x ? value1.x : value2.x, 
            value1.y < value2.y ? value1.y : value2.y); 
    }

    public static void Min(ref Vec2d value1, ref Vec2d value2, out Vec2d result)
    {
        result.x = value1.x < value2.x ? value1.x : value2.x;
        result.y = value1.y < value2.y ? value1.y : value2.y;
    }

    public static Vec2d Multiply(Vec2d value1, Vec2d value2)
    {
        value1.x *= value2.x;
        value1.y *= value2.y;
        return value1;
    }

    public static Vec2d Multiply(Vec2d value1, double scaleFactor)
    {
        value1.x *= scaleFactor;
        value1.y *= scaleFactor;
        return value1;
    }

    public static void Multiply(ref Vec2d value1, double scaleFactor, out Vec2d result)
    {
        result.x = value1.x * scaleFactor;
        result.y = value1.y * scaleFactor;
    }

    public static void Multiply(ref Vec2d value1, ref Vec2d value2, out Vec2d result)
    {
        result.x = value1.x * value2.x;
        result.y = value1.y * value2.y;
    }

    public static Vec2d Negate(Vec2d value)
    {
        value.x = -value.x;
        value.y = -value.y;
        return value;
    }

    public static void Negate(ref Vec2d value, out Vec2d result)
    {
        result.x = -value.x;
        result.y = -value.y;
    }

    public void Normalize()
    {
        double val = 1.0f / (double)Math.Sqrt((x * x) + (y * y));
        x *= val;
        y *= val;
    }

    public static Vec2d Normalize(Vec2d value)
    {
        double val = 1.0f / (double)Math.Sqrt((value.x * value.x) + (value.y * value.y));
        value.x *= val;
        value.y *= val;
        return value;
    }

    public static void Normalize(ref Vec2d value, out Vec2d result)
    {
        double val = 1.0f / (double)Math.Sqrt((value.x * value.x) + (value.y * value.y));
        result.x = value.x * val;
        result.y = value.y * val;
    }

    public static Vec2d Subtract(Vec2d value1, Vec2d value2)
    {
        value1.x -= value2.x;
        value1.y -= value2.y;
        return value1;
    }

    public static void Subtract(ref Vec2d value1, ref Vec2d value2, out Vec2d result)
    {
        result.x = value1.x - value2.x;
        result.y = value1.y - value2.y;
    }

    public override string ToString()
    {
        return string.Format("{{X:{0} Y:{1}}}", x, y);
    }

    #endregion Public Methods


    #region Operators

    public static Vec2d operator -(Vec2d value)
    {
        value.x = -value.x;
        value.y = -value.y;
        return value;
    }


    public static bool operator ==(Vec2d value1, Vec2d value2)
    {
        return value1.x == value2.x && value1.y == value2.y;
    }


    public static bool operator !=(Vec2d value1, Vec2d value2)
    {
        return value1.x != value2.x || value1.y != value2.y;
    }


    public static Vec2d operator +(Vec2d value1, Vec2d value2)
    {
        value1.x += value2.x;
        value1.y += value2.y;
        return value1;
    }


    public static Vec2d operator -(Vec2d value1, Vec2d value2)
    {
        value1.x -= value2.x;
        value1.y -= value2.y;
        return value1;
    }


    public static Vec2d operator *(Vec2d value1, Vec2d value2)
    {
        Debug.Log("Should this really be used?");
        value1.x *= value2.x;
        value1.y *= value2.y;
        return value1;
    }


    public static Vec2d operator *(Vec2d value, double scaleFactor)
    {
        value.x *= scaleFactor;
        value.y *= scaleFactor;
        return value;
    }


    public static Vec2d operator *(double scaleFactor, Vec2d value)
    {
        value.x *= scaleFactor;
        value.y *= scaleFactor;
        return value;
    }


    public static Vec2d operator /(Vec2d value1, Vec2d value2)
    {
        value1.x /= value2.x;
        value1.y /= value2.y;
        return value1;
    }


    public static Vec2d operator /(Vec2d value1, double divider)
    {
        double factor = 1 / divider;
        value1.x *= factor;
        value1.y *= factor;
        return value1;
    }

    #endregion Operators
}