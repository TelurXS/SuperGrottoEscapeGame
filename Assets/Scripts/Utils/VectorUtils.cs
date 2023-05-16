using UnityEngine;

public static class VectorUtils
{
    public static Vector2 WithX(this Vector2 vector, float x)
    {
        return new Vector2(x, vector.y);
    }

    public static Vector2 WithY(this Vector2 vector, float y)
    {
        return new Vector2(vector.x, y);
    }

    public static Vector2 GenerateRandom(float minX = -1, float maxX = 1, float minY = -1, float maxY = 1)
    {
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
}
