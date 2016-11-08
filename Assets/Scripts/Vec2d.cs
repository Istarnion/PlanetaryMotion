using System;

public struct Vec2d
{
    public double x;
    public double y;

    public double Magnitude
    {
        get
        {
            return Math.Sqrt(x*x + y*y);
        }
        private set {}
    }

    public double SqrMagnitude
    {
        get
        {
            return x*x + y*y;
        }
        private set {}
    }

    public Vec2d(double a, double b)
    {
        x = a;
        y = b;
    }

    public void Normalize()
    {
        double m = Magnitude;
        x /= m;
        y /= m;
    }

    public Vec2d Normalized()
    {
        double m = Magnitude;
        return new Vec2d(x/m, y/m);
    }

    public void Truncate(double length)
    {
        double m = Magnitude;
        x = x/m * length;
        y = y/m * length;
    }

    public static Vec2d operator +(Vec2d a, Vec2d b)
    {
        return new Vec2d(a.x+b.x, a.y+b.y);
    }

    public static Vec2d operator -(Vec2d a, Vec2d b)
    {
        return new Vec2d(a.x-b.x, a.y-b.y);
    }

    public static Vec2d operator *(Vec2d v, double d)
    {
        return new Vec2d(v.x*d, v.y*d);
    }

    public static Vec2d operator *(Vec2d a, Vec2d b)
    {
        return new Vec2d(a.x*b.x, a.y*b.y);
    }

    public static Vec2d operator /(Vec2d v, double d)
    {
        return new Vec2d(v.x/d, v.y/d);
    }

    public static Vec2d operator /(Vec2d a, Vec2d b)
    {
        return new Vec2d(a.x/b.x, a.y/b.y);
    }

    public static double Dot(Vec2d a, Vec2d b)
    {
        return a.x*b.x + a.y*b.y;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Vec2d)) return false;

        var other = (Vec2d)obj;

        return (Math.Abs(x-other.x) < double.Epsilon && Math.Abs(y-other.y) < double.Epsilon);
    }

    public override int GetHashCode()
    {
        return (int)(x * 83492791) ^ (int)(y * 73856093);
    }

    public override string ToString()
    {
        return string.Format("Vec2d: ({0}, {1})", x, y);
    }
}

