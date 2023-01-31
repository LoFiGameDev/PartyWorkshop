using System;
using System.Numerics;
//using UnityEngine; This project was made in a Unity Project, which is why this is here and there are some Unity Specific operators/casts

#pragma warning disable CS0660
#pragma warning disable CS0661

[Serializable]
public struct Vector3D
{
    public float X;
    public float Y;
    public float Z;

    /// <summary>
    /// Creates a new Vector3D with given X, Y and Z parameters.
    /// </summary>
    public Vector3D(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }


    #region Operator Overloads
    public static implicit operator Vector3(Vector3D toCast)
    {
        return new Vector3(toCast.X, toCast.Y, toCast.Z);
    }

    //public static implicit operator Vector3D(Vector3 toCast)
    //{
    //    return new Vector3D(toCast.x, toCast.y, toCast.z);
    //}

    //public static implicit operator Vector3D(Vector2 toCast)
    //{
    //    return new Vector3D(toCast.x, toCast.y, 0f);
    //}

    public static Vector3D operator +(Vector3D first, Vector3D second)
    {
        float newX = first.X + second.X;
        float newY = first.Y + second.Y;
        float newZ = first.Z + second.Z;

        return new Vector3D(newX, newY, newZ);
    }

    public static Vector3D operator -(Vector3D first, Vector3D second)
    {
        float newX = first.X - second.X;
        float newY = first.Y - second.Y;
        float newZ = first.Z - second.Z;

        return new Vector3D(newX, newY, newZ);
    }

    public static Vector3D operator *(Vector3D first, float skalar)
    {
        float newX = first.X * skalar;
        float newY = first.Y * skalar;
        float newZ = first.Z * skalar;

        return new Vector3D(newX, newY, newZ);
    }

    public static Vector3D operator *(Vector3D first, Vector3D second)
    {
        float newX = first.X * second.X;
        float newY = first.Y * second.Y;
        float newZ = first.Z * second.Z;

        return new Vector3D(newX, newY, newZ);
    }

    public static Vector3D operator /(Vector3D first, float skalar)
    {
        float newX = first.X / skalar;
        float newY = first.Y / skalar;
        float newZ = first.Z / skalar;

        return new Vector3D(newX, newY, newZ);
    }

    public static bool operator ==(Vector3D first, Vector3D second)
    {
        return first.X == second.X && first.Y == second.Y && first.Z == second.Z;
    }

    public static bool operator !=(Vector3D first, Vector3D second)
    {
        return first.X != second.X || first.Y != second.Y || first.Z != second.Z;
    }

    //public static bool operator ==(Vector3D first, Vector3 second)
    //{
    //    return first.X == second.x && first.Y == second.y && first.Z == second.z;
    //}

    //public static bool operator ==(Vector3 first, Vector3D second)
    //{
    //    return first.x == second.X && first.y == second.Y && first.z == second.Z;
    //}

    //public static bool operator !=(Vector3D first, Vector3 second)
    //{
    //    return first.X != second.x || first.Y != second.y || first.Z != second.z;
    //}

    //public static bool operator !=(Vector3 first, Vector3D second)
    //{
    //    return first.x != second.X || first.y != second.Y && first.z != second.Z;
    //}
    #endregion

    #region Helper functions
    /// <summary>
    /// Returns a new Vector3D where X, Y and Z are 0.
    /// </summary>
    public static Vector3D Zero()
    {
        return new Vector3D();
    }

    /// <summary>
    /// Returns a new Vector3D pointing right (X = 1, Y = 0, Z = 0).
    /// </summary>
    public static Vector3D Right()
    {
        return new Vector3D(1f, 0f, 0f);
    }

    /// <summary>
    /// Returns a new Vector3D pointing left (X = -1, Y = 0, Z = 0).
    /// </summary>
    public static Vector3D Left()
    {
        return new Vector3D(-1f, 0f, 0f);
    }

    /// <summary>
    /// Returns a new Vector3D pointing up (X = 0, Y = 1, Z = 0).
    /// </summary>
    public static Vector3D Up()
    {
        return new Vector3D(0f, 1f, 0f);
    }

    /// <summary>
    /// Returns a new Vector3D pointing down (X = 0, Y = -1, Z = 0).
    /// </summary>
    public static Vector3D Down()
    {
        return new Vector3D(0f, -1f, 0f);
    }

    /// <summary>
    /// Returns a new Vector3D pointing back (X = 0, Y = 0, Z = 1).
    /// </summary>
    public static Vector3D Back()
    {
        return new Vector3D(0f, 0f, 1f);
    }

    /// <summary>
    /// Returns a new Vector3D pointing front (X = 0, Y = 0, Z = -1).
    /// </summary>
    public static Vector3D Front()
    {
        return new Vector3D(0f, 0f, -1f);
    }

    /// <summary>
    /// Reverses the Vector3D by multypling all values by -1.
    /// </summary>
    public Vector3D Reverse()
    {
        return new Vector3D(X * -1, Y *= -1, Z *= -1);
    }
    #endregion

    /// <summary>
    /// Calculates and returns the length of a Vector3D as a float.
    /// </summary>
    public float Magnitude()
    {
        return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    /// <summary>
    /// Normalizes a Vector3D and returns the normalized Vector3D.
    /// </summary>
    public Vector3D Normalize()
    {
        float magnitude = Magnitude();

        if (magnitude.Equals(0f))
        {
            return Zero();
        }

        float newX = X / magnitude;
        float newY = Y / magnitude;
        float newZ = Z / magnitude;

        return new Vector3D(newX, newY, newZ);
    }

    /// <summary>
    /// Returns the Dot-Product of two Vector3D's as a float.
    /// </summary>
    /// <param name="first">First Vector3D</param>
    /// <param name="second">Second Vector2D</param>
    public static float Dot(Vector3D first, Vector3D second)
    {
        float dotProduct = first.X * second.X + first.Y * second.Y + first.Z * second.Z;

        return dotProduct;
    }

    /// <summary>
    /// Returns a new Vector3D that is orthogonal to two Vector3D's.
    /// </summary>
    /// <param name="first">First Vector3D</param>
    /// <param name="second">Second Vector3D</param>
    public static Vector3D Cross(Vector3D first, Vector3D second)
    {
        Vector3D result = new Vector3D();

        result.X = first.Y * second.Z - first.Z * second.Y;
        result.Y = first.Z * second.X - first.X * second.Z;
        result.Z = first.X * second.Y - first.Y * second.X;

        return result;
    }

    /// <summary>
    /// Returns the angle between two Vector3D's in angles as a float.
    /// </summary>
    /// <param name="first">First Vector3D</param>
    /// <param name="second">Second Vector3D</param>
    /// <returns></returns>
    public static float AngleBetween(Vector3D first, Vector3D second)
    {
        float dotProduct = Dot(first, second);

        float value = (dotProduct / (first.Magnitude() * second.Magnitude()));

        float angle = (float)Math.Acos(value) * (180f / MathF.PI);

        return angle;
    }

    public override string ToString()
    {
        return ($"{X} , {Y} , {Z}");
    }
}
