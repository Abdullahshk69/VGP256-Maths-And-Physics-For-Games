using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadraticBezierCurve : MonoBehaviour
{
    [SerializeField] private Slider t;
    [SerializeField] private RectTransform A, B, C;

    [SerializeField] private Image interpolate;

    private void Update()
    {
        interpolate.transform.position = QuadraticInterpolation(A.position, B.position, C.position, t.value);
    }

    public static Vector2 QuadraticInterpolation(Vector2 A, Vector2 B, Vector2 C, float t)
    {
        Vector2 E = LinearInterpolation.LinearInterpolate(A, B, t);
        Vector2 F = LinearInterpolation.LinearInterpolate(B, C, t);
        Vector2 interpolate = LinearInterpolation.LinearInterpolate(E, F, t);

        return interpolate;
    }
}
