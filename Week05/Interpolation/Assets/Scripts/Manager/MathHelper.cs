using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHelper : MonoBehaviour
{
    public static Vector2 LinearInterpolation(Vector2 start, Vector2 end, float t)
    {
        return (1 - t) * start + end * t;
    }
}
