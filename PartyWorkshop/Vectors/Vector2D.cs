using System.Numerics;
//using UnityEngine; This project was made in a Unity Project, which is why this is here and there are some Unity Specific operators/casts

#pragma warning disable CS0660
#pragma warning disable CS0661

[Serializable]
public struct Vector2D
{
    public float X;
    public float Y;

    /// <summary>
    /// Creates a new Vector2D with given X and Y paramters.
    /// </summary>
    public Vector2D(float x, float y)
    {
        X = x;
        Y = y;
    }

    #region Operator Overloads
    public static implicit operator Vector2(Vector2D toCast)
    {
        return new Vector2(toCast.X, toCast.Y);
    }

    //public static implicit operator Vector2D(Vector2 toCast)
    //{
    //    return new Vector2D(toCast.x, toCast.y);
    //}

    //public static implicit operator Vector2D(Vector3 toCast)
    //{
    //    return new Vector2D(toCast.x, toCast.y);
    //}

    public static implicit operator Vector2D(Vector3D toCast)
    {
        return new Vector2D(toCast.X, toCast.Y);
    }

    public static implicit operator Vector3(Vector2D toCast)
    {
        return new Vector3(toCast.X, toCast.Y, 0f);
    }

    public static implicit operator Vector3D(Vector2D toCast)
    {
        return new Vector3D(toCast.X, toCast.Y, 0f);
    }

    public static Vector2D operator +(Vector2D first, Vector2D second)
    {
        float newX = first.X + second.X;
        float newY = first.Y + second.Y;

        return new Vector2D(newX, newY);
    }

    public static Vector2D operator -(Vector2D first, Vector2D second)
    {
        float newX = first.X - second.X;
        float newY = first.Y - second.Y;

        return new Vector2D(newX, newY);
    }

    public static Vector2D operator *(Vector2D first, float skalar)
    {
        float newX = first.X * skalar;
        float newY = first.Y * skalar;

        return new Vector2D(newX, newY);
    }

    public static Vector2D operator *(Vector2D first, int skalar)
    {
        float newX = first.X * skalar;
        float newY = first.Y * skalar;

        return new Vector2D(newX, newY);
    }

    public static Vector2D operator *(Vector2D first, Vector2D second)
    {
        float newX = first.X * second.X;
        float newY = first.Y * second.Y;

        return new Vector2D(newX, newY);
    }

    public static Vector2D operator /(Vector2D first, float skalar)
    {
        float newX = first.X / skalar;
        float newY = first.Y / skalar;

        return new Vector2D(newX, newY);
    }

    public static bool operator ==(Vector2D first, Vector2D second)
    {
        return first.X == second.X && first.Y == second.Y;
    }

    public static bool operator !=(Vector2D first, Vector2D second)
    {
        return first.X != second.X || first.Y != second.Y;
    }

    //public static bool operator ==(Vector2D first, Vector2 second)
    //{
    //    return first.X == second.x && first.Y == second.y;
    //}

    //public static bool operator !=(Vector2D first, Vector2 second)
    //{
    //    return first.X != second.x || first.Y != second.y;
    //}
    #endregion

    #region Helper functions
    /// <summary>
    /// Returns a new Vector2D where X and Y are 0.
    /// </summary>
    public static Vector2D Zero()
    {
        return new Vector2D();
    }

    /// <summary>
    /// Returns a new Vector2D pointing right (X = 1, Y = 0).
    /// </summary>
    public static Vector2D Right()
    {
        return new Vector2D(1f, 0f);
    }

    /// <summary>
    /// Returns a new Vector2D pointing left (X = -1, Y = 0).
    /// </summary>
    public static Vector2D Left()
    {
        return new Vector2D(-1f, 0f);
    }

    /// <summary>
    /// Returns a new Vector2D pointing up (X = 0, Y = 1).
    /// </summary>
    public static Vector2D Up()
    {
        return new Vector2D(0f, 1f);
    }

    /// <summary>
    /// Returns a new Vector2D pointing down (X = 0, Y = -1).
    /// </summary>
    public static Vector2D Down()
    {
        return new Vector2D(0f, -1f);
    }

    /// <summary>
    /// Reverses the Vector2D by multiplying all values by -1.
    /// </summary>
    public Vector2D Reverse()
    {
        return new Vector2D(X *= -1, Y *= -1);
    }
    #endregion

    /// <summary>
    /// Returns the length of the Vector2D as a float.
    /// </summary>
    public float Magnitude()
    {
        float distance;

        distance = (float)Math.Sqrt(X * X + Y * Y);

        return distance;
    }

    /// <summary>
    /// Normalizes the Vector2D and returns it.
    /// </summary>
    public Vector2D Normalize()
    {
        float magnitude = Magnitude();

        if (magnitude == 0f)
        {
            return new Vector2D(0f, 0f);
        }

        float newX = X / magnitude;
        float newY = Y / magnitude;

        return new Vector2D(newX, newY);
    }

    /// <summary>
    /// Returns the Dot-Product of two Vector2D's as a float.
    /// </summary>
    /// <param name="first">First Vector2D</param>
    /// <param name="second">Second Vector2D</param>
    public static float Dot(Vector2D first, Vector2D second)
    {
        float value = first.X * second.X + first.Y * second.Y;

        return value;
    }

    /// <summary>
    /// Returns the Cross product of two Vector2D's as a float.
    /// </summary>
    /// <param name="first">First Vector2D</param>
    /// <param name="second">Second Vector2D</param>
    /// <returns></returns>
    public static float Cross(Vector2D first, Vector2D second)
    {
        float crossProduct = (first.X * second.Y) - (first.Y * second.X);

        return crossProduct;
    }

    /// <summary>
    /// Returns the angle between two Vector2D's in angles as a float.
    /// </summary>
    /// <param name="first">First Vector2D</param>
    /// <param name="second">Second Vector2D</param>
    /// <returns></returns>
    public static float AngleBetween(Vector2D first, Vector2D second)
    {
        float dotProduct = Dot(first, second);

        float multipliedLengths = first.Magnitude() * second.Magnitude();

        if (multipliedLengths == 0)
        {
            return 0;
        }

        float cosine = dotProduct / multipliedLengths;

        float angle = (float)Math.Acos(cosine) * (180f / MathF.PI);

        return angle;
    }

    ///// <summary>
    ///// Converts any Unity-Vector2-Enumerable to a Vector2D[]. This is needed as you can't create implicit or explicit casts for arrays as far as I understand.
    ///// </summary>
    ///// <param name="toCast">The Vector2 array that is to be cast</param>
    ///// <returns></returns>
    //public static Vector2D[] UnityVector2ArrayToOwn(IEnumerable<Vector2> toCast)
    //{
    //    Vector2[] toCastArray = toCast.ToArray();

    //    Vector2D[] newArray = new Vector2D[toCastArray.Length];

    //    for (int i = 0; i < toCastArray.Length; i++)
    //    {
    //        newArray[i] = toCastArray[i];
    //    }

    //    return newArray;
    //}

    /// <summary>
    /// Rotates a Vector2D around another Vector2D by given amount.
    /// </summary>
    /// <param name="toRotate">The Vector2D that is to be rotated</param>
    /// <param name="rotateAround">The Vector2D which toRotate will be rotated around</param>
    /// <param name="amount">The amount of rotation in radians</param>
    /// <returns></returns>
    public static Vector2D RotatePointAroundAnotherZ(Vector2D toRotate, Vector2D rotateAround, float amount)
    {
        float rotatedX = MathF.Cos(amount) * (toRotate.X - rotateAround.X) - MathF.Sin(amount) * (toRotate.Y
            - rotateAround.Y) + rotateAround.X;
        float rotatedY = MathF.Sin(amount) * (toRotate.X - rotateAround.X) + MathF.Cos(amount) * (toRotate.Y
            - rotateAround.Y) + rotateAround.Y;

        return new Vector2D(rotatedX, rotatedY);
    }

    public override string ToString()
    {
        return ($"{X} , {Y}");
    }
}
